using System;
using System.Collections.Generic;
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
    public class AsheW : EvadeSkillshot
    {
        public AsheW()
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
        private bool CollisionChecked;
        private Vector2[] CollisionPoints;

        public MissileClient Missile => OwnSpellData.IsPerpendicular ? null : SpawnObject as MissileClient;

        public Vector3 RealStartPosition
        {
            get
            {
                bool debugMode = EvadeMenu.HotkeysMenu["debugMode"].Cast<KeyBind>().CurrentValue;

                if (debugMode)
                    return Debug.GlobalStartPos;
                return _startPos;
            }
        }

        public Vector3 StartPosition
        {
            get
            {
                float speed = OwnSpellData.MissileSpeed;
                float timeElapsed = Environment.TickCount - TimeDetected - OwnSpellData.Delay;
                float traveledDist = speed * timeElapsed / 1000;
                return _startPos.Extend(_endPos, traveledDist).To3D();
            }
        }

        public Vector3 EndPosition
        {
            get
            {

                bool debugMode = EvadeMenu.HotkeysMenu["debugMode"].Cast<KeyBind>().CurrentValue;
                if (debugMode)
                    return Debug.GlobalEndPos;

                return _endPos;
            }
        }

        public override Vector3 GetPosition()
        {
            return StartPosition;
        }

        public override EvadeSkillshot NewInstance(bool debug = false)
        {
            var newInstance = new AsheW { OwnSpellData = OwnSpellData };
            if (debug)
            {
                var newDebugInst = new AsheW
                {
                    OwnSpellData = OwnSpellData,
                    _startPos = Debug.GlobalStartPos,
                    _endPos = Debug.GlobalEndPos,
                    IsValid = true,
                    IsActive = true,
                    TimeDetected = Environment.TickCount,
                    SpawnObject = null
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
            if (Environment.TickCount > TimeDetected + OwnSpellData.Delay + 1000)
            {
                IsValid = false;
                return;
            }

            if (!CollisionChecked)
            {
                CollisionPoints = this.GetCollisionPoints();
                CollisionChecked = true;
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

        Vector2[] GetBeginEdgePoints(Vector2[] edges)
        {
            if (RealStartPosition.Distance(StartPosition) <= 50)
                return new [] {StartPosition.To2D()};

            var endEdges = edges;

            Vector2 direction = (EndPosition - RealStartPosition).To2D();
            var perpVecStart = StartPosition.To2D() + direction.Normalized().Perpendicular();
            var perpVecEnd = StartPosition.To2D() + direction.Normalized().Perpendicular()*1500;

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
                return new[] {p1, p2};


            return new[] { StartPosition.To2D() };
        }

        Vector2 RotateAroundPoint(Vector2 start, Vector2 end, float theta)
        {
            float px = end.X, py = end.Y;
            float ox = start.X, oy = start.Y;

            float x = (float)Math.Cos(theta) * (px - ox) - (float)Math.Sin(theta) * (py - oy) + ox;
            float y = (float)Math.Sin(theta) * (px - ox) + (float)Math.Cos(theta) * (py - oy) + oy;
            return new Vector2(x, y);
        }

        public Vector2[] GetEdgePoints()
        {
            float segmentAngleStep = 4.62f;
            float sidewardsRotationAngle = segmentAngleStep * 5;

            Vector2 rightEdge = RotateAroundPoint(RealStartPosition.To2D(), EndPosition.To2D(), 
                -sidewardsRotationAngle * (float)Math.PI/180);
            Vector2 leftEdge = RotateAroundPoint(RealStartPosition.To2D(), EndPosition.To2D(), sidewardsRotationAngle *
                (float)Math.PI / 180);

            return new[] {rightEdge, leftEdge};
        }

        IEnumerable<Vector2> OrderCollisionPointsHorizontally(Vector2 rightEdgePoint)
        {
            if (!CollisionPoints.Any())
                return CollisionPoints;

            List<Vector2> detailedEdgeLine = new List<Vector2>();
            for (float i = 1; i >= 0; i-=.1f)
            {
                detailedEdgeLine.Add(RealStartPosition.To2D() + (rightEdgePoint - RealStartPosition.To2D())*i);
            }

            return CollisionPoints.OrderBy(cp => detailedEdgeLine.OrderBy(p => p.Distance(cp)).First().Distance(cp));
        }

        class CollisionInfo
        {
            public bool BehindStartLine;
            public Vector2 New_RightCollPointOnStartLine, New_LeftCollPointOnStartLine;
        }

        CollisionInfo AreCollisionPointsBehindBegin(Vector2 rightCollP, Vector2 leftCollP, Vector2 rightBeginP, Vector2 leftBeginP)
        {
            var btweenCollP = rightCollP + (leftCollP - rightCollP)*.5f;
            var extendedRight = RealStartPosition.Extend(rightCollP, 2000);
            var extendedLeft = RealStartPosition.Extend(leftCollP, 2000);

            var intersectionsRight = new Geometry.Polygon.Line(RealStartPosition.To2D(), extendedRight).
                GetIntersectionPointsWithLineSegment(rightBeginP, leftBeginP);
            var intersectionsleft = new Geometry.Polygon.Line(RealStartPosition.To2D(), extendedLeft).
                GetIntersectionPointsWithLineSegment(rightBeginP, leftBeginP);

            bool behind =
                !new Geometry.Polygon.Line(rightBeginP, leftBeginP).IsIntersectingWithLineSegment(
                    RealStartPosition.To2D(),
                    btweenCollP);

            CollisionInfo info = new CollisionInfo {BehindStartLine = behind};

            if (intersectionsRight.Any() && intersectionsleft.Any())
            {
                info.New_RightCollPointOnStartLine = intersectionsRight[0];
                info.New_LeftCollPointOnStartLine = intersectionsleft[0];
            }


            return info;
        }

        public override Geometry.Polygon ToPolygon(float extrawidth = 0)
        {
            Vector2[] edges = GetEdgePoints();
            Vector2 rightEdge = edges[0];
            Vector2 leftEdge = edges[1];

            var beginPoints = GetBeginEdgePoints(edges);
            Vector2 rightBeginPoint = beginPoints[0];
            Vector2 leftBeginPoint = beginPoints.Length == 1 ? Vector2.Zero : beginPoints[1];

            if (leftBeginPoint.IsZero)
                return new Geometry.Polygon();

            var baseTriangle = new Geometry.Polygon();
            baseTriangle.Points.AddRange(new List<Vector2> { RealStartPosition.To2D(), rightEdge, leftEdge });

            var advancedTriangle = new Geometry.Polygon();
            advancedTriangle.Points.AddRange(new List<Vector2> { RealStartPosition.To2D(), rightEdge });

            var dummyTriangle = advancedTriangle;

            if (CollisionPoints.Any())
            {
                foreach (var collisionPoint in OrderCollisionPointsHorizontally(rightEdge))
                {
                    var dir = collisionPoint - RealStartPosition.To2D();
                    var leftColl = RealStartPosition.To2D() + dir + dir.Perpendicular().Normalized() * 25;
                    var rightColl = RealStartPosition.To2D() + dir + dir.Perpendicular2().Normalized() * 25;

                    var backToLineRight = RealStartPosition.Extend(rightColl, EndPosition.Distance(RealStartPosition));
                    var backToLineLeft = RealStartPosition.Extend(leftColl, EndPosition.Distance(RealStartPosition));

                    var earlyCollCheck_Left = backToLineLeft.Extend(leftColl, EndPosition.Distance(RealStartPosition));
                    var earlyCollCheck_Right = backToLineRight.Extend(rightColl, EndPosition.Distance(RealStartPosition));

                    Geometry.Polygon earlyCollisionRectangle = new Geometry.Polygon();
                    earlyCollisionRectangle.Points.AddRange(new List<Vector2>
                    {
                        leftColl, earlyCollCheck_Left, earlyCollCheck_Right, rightColl
                    });
                    bool EarlyCollision =
                        CollisionPoints.Any(x => x != collisionPoint && earlyCollisionRectangle.IsInside(x));

                    Func<Vector2, bool> outsideDummy = point => dummyTriangle.Points.Count < 3 || dummyTriangle.IsOutside(point);

                    if (baseTriangle.IsInside(rightColl) && baseTriangle.IsInside(leftColl)
                        && outsideDummy(rightColl) && outsideDummy(leftColl) && !EarlyCollision &&
                        backToLineLeft.Distance(backToLineRight) >= OwnSpellData.Radius * 2)
                    {
                        CollisionInfo info = AreCollisionPointsBehindBegin(rightColl, leftColl, rightBeginPoint,
                            leftBeginPoint);

                        if (!info.BehindStartLine)
                        {
                            dummyTriangle.Points.Add(backToLineRight);
                            advancedTriangle.Points.Add(backToLineRight);

                            dummyTriangle.Points.Add(rightColl);
                            advancedTriangle.Points.Add(rightColl);


                            dummyTriangle.Points.Add(leftColl);
                            advancedTriangle.Points.Add(leftColl);

                            dummyTriangle.Points.Add(backToLineLeft);
                            advancedTriangle.Points.Add(backToLineLeft);
                        }
                        else //collision points behind startLine
                        {
                            leftColl = info.New_LeftCollPointOnStartLine;
                            rightColl = info.New_RightCollPointOnStartLine;

                            backToLineRight = RealStartPosition.Extend(rightColl, EndPosition.Distance(RealStartPosition));
                            backToLineLeft = RealStartPosition.Extend(leftColl, EndPosition.Distance(RealStartPosition));

                            dummyTriangle.Points.Add(backToLineRight);
                            advancedTriangle.Points.Add(backToLineRight);

                            dummyTriangle.Points.Add(rightColl);
                            advancedTriangle.Points.Add(rightColl);


                            dummyTriangle.Points.Add(leftColl);
                            advancedTriangle.Points.Add(leftColl);

                            dummyTriangle.Points.Add(backToLineLeft);
                            advancedTriangle.Points.Add(backToLineLeft);
                        }
                    }

                }
            }

            advancedTriangle.Points.Add(leftEdge);
            advancedTriangle.Points.RemoveAt(0);
            advancedTriangle.Points.Insert(0, rightBeginPoint);
            advancedTriangle.Points.Insert(0, leftBeginPoint);

            return advancedTriangle;
        }

        public override int GetAvailableTime(Vector2 pos)
        {
            //return Math.Max(0, OwnSpellData.Delay - (Environment.TickCount - TimeDetected));
            var dist1 =
                Math.Abs((EndPosition.Y - StartPosition.Y) * pos.X - (EndPosition.X - StartPosition.X) * pos.Y +
                         EndPosition.X * StartPosition.Y - EndPosition.Y * StartPosition.X) / StartPosition.Distance(EndPosition);

            var actualDist = Math.Sqrt(StartPosition.Distance(pos).Pow() - dist1.Pow());

            var time = OwnSpellData.MissileSpeed > 0 ? (int)(actualDist / OwnSpellData.MissileSpeed * 1000) : 0;

            return time;
        }

        public override bool IsFromFow()
        {
            return Missile != null && !Missile.SpellCaster.IsVisible;
        }
    }
}