using System;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using Moon_Walk_Evade.Evading;
using Moon_Walk_Evade.Utils;
using SharpDX;
using Color = System.Drawing.Color;

namespace Moon_Walk_Evade.Skillshots.SkillshotTypes
{
    public class LinearSkillshot : EvadeSkillshot
    {
        public LinearSkillshot()
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
        private bool DoesCollide, CollisionChecked;
        private Vector2 LastCollisionPos;

        public MissileClient Missile => OwnSpellData.IsPerpendicular ? null : SpawnObject as MissileClient;

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
                {
                    return _endPos;
                }

                if (DoesCollide)
                    return LastCollisionPos.To3D();


                return Missile.StartPosition.ExtendVector3(Missile.EndPosition, OwnSpellData.Range + 100);
            }
        }

        public override Vector3 GetPosition()
        {
            return StartPosition;
        }

        public override EvadeSkillshot NewInstance(bool debug = false)
        {
            var newInstance = new LinearSkillshot { OwnSpellData = OwnSpellData };
            if (debug)
            {
                bool isProjectile = EvadeMenu.HotkeysMenu["isProjectile"].Cast<CheckBox>().CurrentValue;
                var newDebugInst = new LinearSkillshot
                {
                    OwnSpellData = OwnSpellData, _startPos = Debug.GlobalStartPos,
                    _endPos = Debug.GlobalEndPos, IsValid = true, IsActive = true, TimeDetected = Environment.TickCount,
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
            if (!OwnSpellData.IsPerpendicular)
            {
                _startPos = Caster.ServerPosition;
                _endPos = _startPos.ExtendVector3(CastArgs.End, OwnSpellData.Range);
            }
            else
            {
                OwnSpellData.Direction = (CastArgs.End - CastArgs.Start).To2D().Normalized();

                var direction = OwnSpellData.Direction;
                _startPos = (CastArgs.End.To2D() - direction.Perpendicular() * OwnSpellData.SecondaryRadius).To3D();

                _endPos = (CastArgs.End.To2D() + direction.Perpendicular() * OwnSpellData.SecondaryRadius).To3D();
            }
        }

        public override void OnTick()
        {
            if (Missile == null)
            {
                if (Environment.TickCount > TimeDetected + OwnSpellData.Delay + 250)
                {
                    IsValid = false;
                    return;
                }
            }
            else if (Missile != null)
            {
                if (Environment.TickCount > TimeDetected + 6000)
                {
                    IsValid = false;
                    return;
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

            if (!CollisionChecked)
            {
                Vector2 collision = this.GetCollisionPoint();
                DoesCollide = !collision.IsZero;
                LastCollisionPos = collision;
                CollisionChecked = true;
            }
            else if (DoesCollide && !LastCollisionPos.ProjectOn(StartPosition.To2D(), EndPosition.To2D()).IsOnSegment)
                DoesCollide = false;
        }

        public override void OnDraw()
        {
            if (!IsValid)
            {
                return;
            }

            Utils.Utils.Draw3DRect(StartPosition, EndPosition, OwnSpellData.Radius * 2, Color.White);
        }

        public override Geometry.Polygon ToRealPolygon()
        {
            var halfWidth = OwnSpellData.Radius;
            var d1 = StartPosition.To2D();
            var d2 = EndPosition.To2D();
            var direction = (d1 - d2).Perpendicular().Normalized();

            Vector3[] points =
            {
                (d1 + direction*halfWidth).To3DPlayer(),
                (d1 - direction*halfWidth).To3DPlayer(),
                (d2 - direction*halfWidth).To3DPlayer(),
                (d2 + direction*halfWidth).To3DPlayer()
            };
            var p = new Geometry.Polygon();
            p.Points.AddRange(points.Select(x => x.To2D()).ToList());

            return p;
        }

        public override Geometry.Polygon ToPolygon(float extrawidth = 0)
        {
            extrawidth = 20;
            if (OwnSpellData.AddHitbox)
            {
                extrawidth += Player.Instance.HitBoxRadius();
            }

            return new Geometry.Polygon.Rectangle(StartPosition, EndPosition.ExtendVector3(StartPosition, -extrawidth), OwnSpellData.Radius + extrawidth);
        }

        public override int GetAvailableTime(Vector2 pos)
        {
            var dist1 =
                Math.Abs((EndPosition.Y - StartPosition.Y) * pos.X - (EndPosition.X - StartPosition.X) * pos.Y +
                         EndPosition.X * StartPosition.Y - EndPosition.Y * StartPosition.X) / StartPosition.Distance(EndPosition);

            var actualDist = Math.Sqrt(StartPosition.Distance(pos).Pow() - dist1.Pow());

            var time = OwnSpellData.MissileSpeed > 0 ? (int) (actualDist / OwnSpellData.MissileSpeed * 1000) : 0;

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