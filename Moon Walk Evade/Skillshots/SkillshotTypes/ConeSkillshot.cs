using System;
using System.Collections.Generic;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using Moon_Walk_Evade.Utils;
using SharpDX;
using Color = System.Drawing.Color;

namespace Moon_Walk_Evade.Skillshots.SkillshotTypes
{
    class ConeSkillshot : EvadeSkillshot
    {
        public ConeSkillshot()
        {
            Caster = null;
            SpawnObject = null;
            SData = null;
            OwnSpellData = null;
            Team = GameObjectTeam.Unknown;
            IsValid = true;
            TimeDetected = Environment.TickCount;
        }

        public Vector3 _startPos;
        public Vector3 _endPos;

        public MissileClient Missile => OwnSpellData.IsPerpendicular ? null : SpawnObject as MissileClient;

        public Vector3 RealStartPosition
        {
            get
            {
                bool debugMode = EvadeMenu.HotkeysMenu["debugMode"].Cast<KeyBind>().CurrentValue;

                if (debugMode)
                    return Debug.GlobalStartPos;

                if (Missile == null)
                    return _startPos;

                return Missile.StartPosition;
            }
        }

        public Vector3 StartPosition
        {
            get
            {
                bool debugMode = EvadeMenu.HotkeysMenu["debugMode"].Cast<KeyBind>().CurrentValue;
                if (Missile == null)
                {
                    if (debugMode)
                        return Debug.GlobalStartPos;
                    return _startPos;
                }


                if (debugMode)//Simulate Position
                {
                    float speed = OwnSpellData.MissileSpeed;
                    float timeElapsed = Environment.TickCount - TimeDetected - OwnSpellData.Delay;
                    float traveledDist = speed * timeElapsed / 1000;
                    return Debug.GlobalStartPos.Extend(Debug.GlobalEndPos, traveledDist).To3D();
                }

                return Missile.Position;
            }
        }

        public Vector3 EndPosition
        {
            get
            {
                bool debugMode = EvadeMenu.HotkeysMenu["debugMode"].Cast<KeyBind>().CurrentValue;
                if (debugMode)
                    return Debug.GlobalEndPos;

                if (Missile == null)
                    return _endPos;

                return Missile.StartPosition.ExtendVector3(Missile.EndPosition, OwnSpellData.Range);
            }
        }

        public override Vector3 GetPosition()
        {
            return StartPosition;
        }

        public override EvadeSkillshot NewInstance(bool debug = false)
        {
            var newInstance = new ConeSkillshot { OwnSpellData = OwnSpellData };
            if (debug)
            {
                bool isProjectile = EvadeMenu.HotkeysMenu["isProjectile"].Cast<CheckBox>().CurrentValue;
                var newDebugInst = new ConeSkillshot
                {
                    OwnSpellData = OwnSpellData,
                    _startPos = Debug.GlobalStartPos,
                    _endPos = Debug.GlobalEndPos,
                    IsValid = true,
                    IsActive = true,
                    TimeDetected = Environment.TickCount,
                    SpawnObject = isProjectile ? new MissileClient() : null
                };
                return newDebugInst;
            }
            return newInstance;
        }

        public override void OnCreateObject(GameObject obj)
        {
            var missile = obj as MissileClient;

            if (SpawnObject == null && missile != null)
            {
                if (missile.SData.Name == OwnSpellData.ObjectCreationName && missile.SpellCaster.Index == Caster.Index)
                {
                    IsValid = false;
                }
            }
        }

        public override void OnSpellDetection(Obj_AI_Base sender)
        {
            _startPos = Caster.ServerPosition;
            _endPos = _startPos.ExtendVector3(CastArgs.End, OwnSpellData.Range);
        }

        public override void OnTick()
        {
            if (Missile == null)
            {
                if (Environment.TickCount > TimeDetected + OwnSpellData.Delay + 250)
                {
                    IsValid = false;
                }
            }
            else if (Missile != null)
            {
                if (Environment.TickCount > TimeDetected + 6000)
                {
                    IsValid = false;
                }
            }

            if (EvadeMenu.HotkeysMenu["debugMode"].Cast<KeyBind>().CurrentValue)
            {
                float speed = OwnSpellData.MissileSpeed;
                float timeElapsed = Environment.TickCount - TimeDetected - OwnSpellData.Delay;
                float traveledDist = speed * timeElapsed / 1000;

                if (traveledDist >= Debug.GlobalStartPos.Distance(Debug.GlobalEndPos) - 50)
                {
                    IsValid = false;
                    return;
                }
            }
        }

        public override void OnDraw()
        {
            if (!IsValid)
            {
                return;
            }
            if (!EvadeMenu.DrawMenu["drawDangerPolygon"].Cast<CheckBox>().CurrentValue)
            {
                ToPolygon().Draw(Color.White);
            }
        }

        public override Geometry.Polygon ToRealPolygon()
        {
            return ToPolygon();
        }

        Vector2 RotateAroundPoint(Vector2 start, Vector2 end, float theta)
        {
            float px = end.X, py = end.Y;
            float ox = start.X, oy = start.Y;

            float x = (float)Math.Cos(theta) * (px - ox) - (float)Math.Sin(theta) * (py - oy) + ox;
            float y = (float)Math.Sin(theta) * (px - ox) + (float)Math.Cos(theta) * (py - oy) + oy;
            return new Vector2(x, y);
        }

        Vector2[] GetBeginEdgePoints(Vector2[] edges)
        {
            var endEdges = edges;

            Vector2 direction = (EndPosition - RealStartPosition).To2D();
            var perpVecStart = StartPosition.To2D() + direction.Normalized().Perpendicular();
            var perpVecEnd = StartPosition.To2D() + direction.Normalized().Perpendicular() * 1500;

            //right side is not the same?
            var perpVecStart2 = StartPosition.To2D() + direction.Normalized().Perpendicular2();
            var perpVecEnd2 = StartPosition.To2D() + direction.Normalized().Perpendicular2() * 1500;


            Geometry.Polygon.Line leftEdgeLine = new Geometry.Polygon.Line(RealStartPosition.To2D(), endEdges[1]);
            Geometry.Polygon.Line rightEdgeLine = new Geometry.Polygon.Line(RealStartPosition.To2D(), endEdges[0]);

            var inters = leftEdgeLine.GetIntersectionPointsWithLineSegment(perpVecStart, perpVecEnd);
            var inters2 = rightEdgeLine.GetIntersectionPointsWithLineSegment(perpVecStart2, perpVecEnd2);
            Vector2 p1 = Vector2.Zero, p2 = Vector2.Zero;



            if (inters.Any())
            {
                var closestInter = inters.OrderBy(x => x.Distance(StartPosition)).First();
                p2 = closestInter;
            }
            if (inters2.Any())
            {
                var closestInter = inters2.OrderBy(x => x.Distance(StartPosition)).First();
                p1 = closestInter;
            }

            if (!p1.IsZero && !p2.IsZero)
                return new[] { p1, p2 };


            return new[] { StartPosition.To2D(),  StartPosition.To2D() };
        }

        public override Geometry.Polygon ToPolygon(float extrawidth = 0)
        {
            List<Vector2> coneSegemnts = new List<Vector2>();
            for (float i = -OwnSpellData.ConeAngle / 2f; i <= OwnSpellData.ConeAngle / 2f; i++)
            {
                coneSegemnts.Add(RotateAroundPoint(RealStartPosition.To2D(), EndPosition.To2D(), i * (float)Math.PI / 180));
            }

            if (Missile != null)
            {
                var beginPoints = GetBeginEdgePoints(new[] { coneSegemnts.First(), coneSegemnts.Last() });
                coneSegemnts.Insert(0, beginPoints[0]);
                coneSegemnts.Insert(0, beginPoints[1]);
            }
            else
                coneSegemnts.Insert(0, RealStartPosition.To2D());

            Geometry.Polygon polygon = new Geometry.Polygon();
            polygon.Points.AddRange(coneSegemnts);

            return polygon;
        }

        public override int GetAvailableTime(Vector2 pos)
        {
            var dist1 =
                Math.Abs((EndPosition.Y - StartPosition.Y) * pos.X - (EndPosition.X - StartPosition.X) * pos.Y +
                         EndPosition.X * StartPosition.Y - EndPosition.Y * StartPosition.X) / StartPosition.Distance(EndPosition);

            var actualDist = Math.Sqrt(StartPosition.Distance(pos).Pow() - dist1.Pow());

            var time = OwnSpellData.MissileSpeed > 0 ? (int)(actualDist / OwnSpellData.MissileSpeed * 1000) : 0;

            if (Missile == null)
            {
                return Math.Max(0, OwnSpellData.Delay - (Environment.TickCount - TimeDetected));
            }

            return time;
        }

        public override bool IsFromFow()
        {
            return Missile != null && !Missile.SpellCaster.IsVisible;
        }
    }
}
