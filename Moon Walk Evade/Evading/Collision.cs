using System;
using System.Collections.Generic;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using Moon_Walk_Evade.Skillshots.SkillshotTypes;
using Moon_Walk_Evade.Utils;
using SharpDX;

namespace Moon_Walk_Evade.Evading
{
    internal static class Collision
    {
        private static Vector2 WindWallStartPosition = Vector2.Zero;
        private static int WallCastTick;
        public static void Init()
        {
            Obj_AI_Base.OnProcessSpellCast += (sender, args) =>
            {
                if (args.SData.Name == "YasuoWMovingWall" && sender.IsAlly)
                {
                    WindWallStartPosition = sender.Position.To2D();
                    WallCastTick = Environment.TickCount;
                }
            };
        }

        static Geometry.Polygon GetDetailedPolygon(this Geometry.Polygon.Rectangle p)
        {
            Geometry.Polygon detailedRectangle = new Geometry.Polygon();
            for (int i = 0; i < p.Points.Count; i += 2)
            {
                var point = p.Points[i];
                var nextPoint = i == p.Points.Count - 1 ? p.Points[0] : p.Points[i + 1];
                detailedRectangle.Add(nextPoint);

                for (float scaling = 1; scaling >= 0; scaling -= 0.1f)
                {
                    var detailedPoint = point + (nextPoint - point) * scaling;
                    detailedRectangle.Add(detailedPoint);
                }
                detailedRectangle.Add(point);
            }
            return detailedRectangle;
        }

        static Vector2 PointOnCircle(float radius, float angleInDegrees, Vector2 origin)
        {
            float x = origin.X + (float)(radius * Math.Cos(angleInDegrees * Math.PI / 180));
            float y = origin.Y + (float)(radius * Math.Sin(angleInDegrees * Math.PI / 180));

            return new Vector2(x, y);
        }

        static List<Vector2> GetHitboxCirclePoints(Obj_AI_Base unit)
        {
            var list = new List<Vector2>();
            for (int i = 0; i < 360; i++)
            {
                list.Add(PointOnCircle(unit.BoundingRadius, i, unit.Position.To2D()));
            }

            return list;
        }

        /// <summary>
        /// In case minions die after the volley passed through, still remember there was a collision before
        /// </summary>
        static List<Vector2> LastMinionPosArray = new List<Vector2>();

        private static int LastMinionPosArrayTick;

        /// <summary>
        /// + minion hitbox
        /// </summary>
        public static Vector2[] GetCollisionPoints(this AsheW skillshot)
        {
            var collisions = new List<Vector2>();

            if (Environment.TickCount - LastMinionPosArrayTick < 1000)
                collisions.AddRange(LastMinionPosArray);


            Vector2[] edges = skillshot.GetEdgePoints();

            Vector2 rightEdge = edges[0];
            Vector2 leftEdge = edges[1];

            var triangle = new Geometry.Polygon();
            triangle.Points.AddRange(new List<Vector2> { skillshot.RealStartPosition.To2D(), rightEdge, leftEdge});

            if (EvadeMenu.CollisionMenu["minion"].Cast<CheckBox>().CurrentValue)
            {
                foreach (var minion in
                    EntityManager.MinionsAndMonsters.AlliedMinions.Where(x => !x.IsDead && x.IsValid && x.Health >= 100 &&
                                                        x.Distance(skillshot.RealStartPosition) < skillshot.OwnSpellData.Range))
                {
                    if (GetHitboxCirclePoints(minion).Any(x => triangle.IsInside(x)))
                    {
                        LastMinionPosArray.Add(minion.Position.To2D());
                        LastMinionPosArrayTick = Environment.TickCount;

                        collisions.Add(minion.Position.To2D());
                    }
                }
            }

            if (EvadeMenu.CollisionMenu["yasuoWall"].Cast<CheckBox>().CurrentValue && skillshot.Missile != null)
            {
                GameObject wall = null;
                foreach (var gameObject in ObjectManager.Get<GameObject>().
                    Where(gameObject => gameObject.IsValid && System.Text.RegularExpressions.Regex.IsMatch(
                       gameObject.Name, "_w_windwall.\\.troy", System.Text.RegularExpressions.RegexOptions.IgnoreCase)))
                {
                    wall = gameObject;
                }
                if (wall != null)
                {
                    var level = wall.Name.Substring(wall.Name.Length - 6, 1);
                    var wallWidth = 300 + 50 * Convert.ToInt32(level);
                    var wallDirection = (wall.Position.To2D() - WindWallStartPosition).Normalized().Perpendicular();

                    var wallStart = wall.Position.To2D() + wallWidth / 2f * wallDirection;
                    var wallEnd = wallStart - wallWidth * wallDirection;
                    var wallPolygon = new Geometry.Polygon.Rectangle(wallStart, wallEnd, 75).GetDetailedPolygon();

                    collisions.AddRange(wallPolygon.Points.Where(wallPoint => triangle.IsInside(wallPoint)));
                }
            }

            return collisions.ToArray();
        }

        public static Vector2 GetCollisionPoint(this LinearSkillshot skillshot)
        {
            if (!skillshot.OwnSpellData.MinionCollision || skillshot.Missile == null)
                return Vector2.Zero;

            var collisions = new List<Vector2>();

            var currentSpellPos = skillshot.GetPosition().To2D();
            var spellEndPos = skillshot.EndPosition;
            var rect = new Geometry.Polygon.Rectangle(currentSpellPos, spellEndPos.To2D(), skillshot.OwnSpellData.Radius*2);

            if (EvadeMenu.CollisionMenu["minion"].Cast<CheckBox>().CurrentValue)
            {
                bool useProj = EvadeMenu.CollisionMenu["useProj"].Cast<CheckBox>().CurrentValue;
                foreach (var minion in
                    EntityManager.MinionsAndMonsters.AlliedMinions.Where(x => !x.IsDead && x.IsValid && x.Health >= 200 &&
                                                        x.Distance(skillshot.StartPosition) < skillshot.OwnSpellData.Range))
                {
                    if (rect.IsInside(minion) && !useProj)
                        collisions.Add(minion.Position.To2D());
                    else if (useProj)
                    {
                        var proj = minion.Position.To2D()
                            .ProjectOn(skillshot.StartPosition.To2D(), skillshot.EndPosition.To2D());
                        if (proj.IsOnSegment && proj.SegmentPoint.Distance(minion) <= skillshot.OwnSpellData.Radius)
                            collisions.Add(proj.SegmentPoint);
                    }
                }
            }

            if (EvadeMenu.CollisionMenu["yasuoWall"].Cast<CheckBox>().CurrentValue && skillshot.Missile != null)
            {
                GameObject wall = null;
                foreach (var gameObject in ObjectManager.Get<GameObject>().
                    Where(gameObject => gameObject.IsValid && System.Text.RegularExpressions.Regex.IsMatch(
                       gameObject.Name, "_w_windwall.\\.troy", System.Text.RegularExpressions.RegexOptions.IgnoreCase)))
                {
                    wall = gameObject;
                }
                if (wall != null)
                {
                    var level = wall.Name.Substring(wall.Name.Length - 6, 1);
                    var wallWidth = 300 + 50*Convert.ToInt32(level);
                    var wallDirection = (wall.Position.To2D() - WindWallStartPosition).Normalized().Perpendicular();

                    var wallStart = wall.Position.To2D() + wallWidth/2f*wallDirection;
                    var wallEnd = wallStart - wallWidth*wallDirection;
                    var wallPolygon = new Geometry.Polygon.Rectangle(wallStart, wallEnd, 75);

                    var intersections = wallPolygon.GetIntersectionPointsWithLineSegment(skillshot.GetPosition().To2D(),
                        skillshot.EndPosition.To2D());


                    if (intersections.Length > 0)
                    {
                        float wallDisappearTime = WallCastTick + 250 + 3750 - Environment.TickCount;

                        collisions.AddRange(intersections.Where(intersec =>
                            intersec.Distance(currentSpellPos)/skillshot.OwnSpellData.MissileSpeed*1000 <
                            wallDisappearTime).ToList());
                    }
                }
            }

            var result = collisions.Count > 0 ? collisions.
                OrderBy(c => c.Distance(currentSpellPos)).ToList().First() : Vector2.Zero;

            return result;
        }
    }
}
