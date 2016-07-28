using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu.Values;
using EloBuddy.SDK.Rendering;
using Moon_Walk_Evade.EvadeSpells;
using Moon_Walk_Evade.Skillshots;
using Moon_Walk_Evade.Skillshots.SkillshotTypes;
using Moon_Walk_Evade.Utils;
using SharpDX;
using Color = System.Drawing.Color;

namespace Moon_Walk_Evade.Evading
{
    public class MoonWalkEvade
    {
        #region Properties

        public int ServerTimeBuffer => 80 + 45;

        public bool EvadeEnabled => EvadeMenu.HotkeysMenu["enableEvade"].Cast<KeyBind>().CurrentValue;

        public bool DodgeDangerousOnly => EvadeMenu.HotkeysMenu["dodgeOnlyDangerousH"].Cast<KeyBind>().CurrentValue ||
            EvadeMenu.HotkeysMenu["dodgeOnlyDangerousT"].Cast<KeyBind>().CurrentValue;

        public int ExtraEvadeRange => EvadeMenu.MainMenu["extraEvadeRange"].Cast<Slider>().CurrentValue;

        public bool RandomizeExtraEvadeRange => EvadeMenu.MainMenu["randomizeExtraEvadeRange"].Cast<CheckBox>().CurrentValue;

        public bool AllowRecalculateEvade => EvadeMenu.MainMenu["recalculatePosition"].Cast<CheckBox>().CurrentValue;

        public bool RestorePosition => EvadeMenu.MainMenu["moveToInitialPosition"].Cast<CheckBox>().CurrentValue;

        public bool DisableDrawings => EvadeMenu.DrawMenu["disableAllDrawings"].Cast<CheckBox>().CurrentValue;

        public bool DrawEvadePoint => EvadeMenu.DrawMenu["drawEvadePoint"].Cast<CheckBox>().CurrentValue;

        public bool DrawEvadeStatus => EvadeMenu.DrawMenu["drawEvadeStatus"].Cast<CheckBox>().CurrentValue;

        public bool DrawDangerPolygon => EvadeMenu.DrawMenu["drawDangerPolygon"].Cast<CheckBox>().CurrentValue;

        public int IgnoreAt => EvadeMenu.MainMenu["ignoreComfort"].Cast<Slider>().CurrentValue;

        public int MinComfortDistance => EvadeMenu.MainMenu["minComfortDist"].Cast<Slider>().CurrentValue;

        public int IssueOrderTickLimit => 0;

        #endregion

        #region Vars

        public SpellDetector SpellDetector { get; private set; }

        public EvadeSkillshot[] Skillshots { get; private set; }
        public Geometry.Polygon[] Polygons { get; private set; }
        public List<Geometry.Polygon> ClippedPolygons { get; private set; }
        public Vector2 LastIssueOrderPos;

        private readonly Dictionary<EvadeSkillshot, Geometry.Polygon> _skillshotPolygonCache;

        private EvadeResult LastEvadeResult;
        private Text StatusText;
        private int EvadeIssurOrderTime;

        #endregion

        public MoonWalkEvade(SpellDetector detector)
        {
            Skillshots = new EvadeSkillshot[] { };
            Polygons = new Geometry.Polygon[] { };
            ClippedPolygons = new List<Geometry.Polygon>();
            StatusText = new Text("MoonWalkEvade", new Font("Euphemia", 10F, FontStyle.Bold)); //Calisto MT
            _skillshotPolygonCache = new Dictionary<EvadeSkillshot, Geometry.Polygon>();

            SpellDetector = detector;
            SpellDetector.OnUpdateSkillshots += OnUpdateSkillshots;
            SpellDetector.OnSkillshotActivation += OnSkillshotActivation;
            SpellDetector.OnSkillshotDetected += OnSkillshotDetected;
            SpellDetector.OnSkillshotDeleted += OnSkillshotDeleted;

            Player.OnIssueOrder += PlayerOnIssueOrder;
            Obj_AI_Base.OnProcessSpellCast += OnProcessSpellCast;
            Dash.OnDash += OnDash;
            Game.OnTick += Ontick;
            Drawing.OnDraw += OnDraw;
        }

        private void OnUpdateSkillshots(EvadeSkillshot skillshot, bool remove, bool isProcessSpell)
        {
            CacheSkillshots();
            DoEvade();
        }

        private void OnSkillshotActivation(EvadeSkillshot skillshot)
        {
            CacheSkillshots();
            DoEvade();
        }

        private void OnSkillshotDetected(EvadeSkillshot skillshot, bool isProcessSpell)
        {
            //TODO: update
            if (skillshot.ToPolygon().IsInside(Player.Instance))
            {
                LastEvadeResult = null;
            }
        }

        private void OnSkillshotDeleted(EvadeSkillshot skillshot)
        {
            if (RestorePosition && !SpellDetector.DetectedSkillshots.Any())
            {
                if (AutoPathing.IsPathing && Player.Instance.IsWalking())
                {
                    var destination = AutoPathing.Destination;
                    AutoPathing.StopPath();
                    Player.IssueOrder(GameObjectOrder.MoveTo, destination.To3DWorld(), false);
                }
                else if (LastEvadeResult != null && Player.Instance.IsMovingTowards(LastEvadeResult.EvadePoint))
                {
                    Player.IssueOrder(GameObjectOrder.MoveTo, LastIssueOrderPos.To3DWorld(), false);
                }
            }
        }

        private void Ontick(EventArgs args)
        {
            if (!Player.Instance.IsWalking() && LastEvadeResult != null)
            {
                //MoveTo(LastEvadeResult.WalkPoint);
            }

            DoEvade();
        }

        private void PlayerOnIssueOrder(Obj_AI_Base sender, PlayerIssueOrderEventArgs args)
        {
            if (!sender.IsMe)
            {
                return;
            }

            if (args.Order == GameObjectOrder.AttackUnit)
            {
                LastIssueOrderPos =
                    (Player.Instance.Distance(args.Target, true) >
                     Player.Instance.GetAutoAttackRange(args.Target as AttackableUnit).Pow()
                        ? args.Target.Position
                        : Player.Instance.Position).To2D();
            }
            else
            {
                LastIssueOrderPos = (args.Target != null ? args.Target.Position : args.TargetPosition).To2D();
            }

            CacheSkillshots();
            switch (args.Order)
            {
                case GameObjectOrder.Stop:
                    if (DoEvade(null, args))
                    {
                        args.Process = false;
                    }
                    break;

                case GameObjectOrder.HoldPosition:
                    if (DoEvade(null, args))
                    {
                        args.Process = false;
                    }
                    break;

                case GameObjectOrder.AttackUnit:
                    if (DoEvade(null, args))
                    {
                        args.Process = false;
                    }
                    break;

                default:
                    if (DoEvade(Player.Instance.GetPath(LastIssueOrderPos.To3DWorld(), true), args))
                    {
                        args.Process = false;
                    }
                    break;
            }
        }

        private void OnProcessSpellCast(Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
        {
            if (!sender.IsMe)
            {
                return;
            }

            if (args.SData.Name == "summonerflash")
            {
                LastEvadeResult = null;
            }
        }

        private void OnDash(Obj_AI_Base sender, Dash.DashEventArgs dashEventArgs)
        {
            if (!sender.IsMe || LastEvadeResult == null)
            {
                return;
            }

            LastEvadeResult = null;
            Player.IssueOrder(GameObjectOrder.MoveTo, LastIssueOrderPos.To3DWorld(), false);
        }

        private void OnDraw(EventArgs args)
        {
            if (DisableDrawings)
            {
                return;
            }

            if (DrawEvadePoint && LastEvadeResult != null)
            {
                if (LastEvadeResult.IsValid && LastEvadeResult.EnoughTime && !LastEvadeResult.Expired())
                {
                    Circle.Draw(new ColorBGRA(255, 0, 0, 255), Player.Instance.BoundingRadius, 25, LastEvadeResult.WalkPoint);
                }
            }

            if (DrawEvadeStatus)
            {
                StatusText.Color = EvadeEnabled ? Color.White : Color.Red;
                if (DodgeDangerousOnly) StatusText.Color = Color.DarkOrange;
                StatusText.TextValue = "MoonWalkEvade ";
                StatusText.Position = Player.Instance.Position.WorldToScreen() - new Vector2(StatusText.Bounding.Width / 2f, -25);
                StatusText.Draw();
            }

            if (DrawDangerPolygon)
            {
                foreach (var pol in Geometry.ClipPolygons(SpellDetector.ActiveSkillshots.Select(c => c.ToPolygon())).ToPolygons())
                {
                    pol.DrawPolygon(Color.White, 3);
                }
            }
        }

        public void CacheSkillshots()
        {
            Skillshots =
                (DodgeDangerousOnly
                    ? SpellDetector.ActiveSkillshots.Where(c => c.OwnSpellData.IsDangerous)
                    : SpellDetector.ActiveSkillshots).ToArray();

            _skillshotPolygonCache.Clear();

            Polygons = Skillshots.Select(c =>
            {
                var pol = c.ToPolygon();
                _skillshotPolygonCache.Add(c, pol);

                return pol;
            }).ToArray();

            ClippedPolygons = Geometry.ClipPolygons(Polygons).ToPolygons();
        }

        public bool IsPointSafe(Vector2 point)
        {
            return !_skillshotPolygonCache.Any(c =>
            {
                if (c.Key.OwnSpellData.IsVeigarE)
                {
                    return c.Key.ToInnerPolygon().IsOutside(point) && c.Key.ToOuterPolygon().IsInside(point);
                }
                return c.Value.IsInside(point);
            });
        }

        public bool IsPathSafe(Vector2[] path)
        {
            return IsPathSafeEx(path);
        }

        public bool IsPathSafe(Vector3[] path)
        {
            return IsPathSafe(path.ToVector2());
        }

        public bool IsHeroInDanger(AIHeroClient hero = null)
        {
            hero = hero ?? Player.Instance;
            bool indanger = !IsPointSafe(hero.ServerPosition.To2D());
            return indanger;
        }

        public int GetTimeAvailable(AIHeroClient hero = null)
        {
            hero = hero ?? Player.Instance;
            var skillshots = Skillshots.Where(c => _skillshotPolygonCache[c].IsInside(hero.Position)).ToArray();

            if (!skillshots.Any())
            {
                return short.MaxValue;
            }

            var times =
                skillshots.Select(c => c.GetAvailableTime(hero.ServerPosition.To2D()))
                    .Where(t => t > 0)
                    .OrderByDescending(t => t);

            return times.Any() ? times.Last() : short.MaxValue;
        }

        public int GetDangerValue(AIHeroClient hero = null)
        {
            hero = hero ?? Player.Instance;
            var skillshots = Skillshots.Where(c => _skillshotPolygonCache[c].IsInside(hero.Position)).ToArray();

            if (!skillshots.Any())
                return 0;

            var values = skillshots.Select(c => c.OwnSpellData.DangerValue).OrderByDescending(t => t);
            return values.Any() ? values.First() : 0;
        }

        float GetShortesTimeAvailiableInInsidePath(Vector2[] path, EvadeSkillshot spell)
        {
            List<Vector2> detailedPath = new List<Vector2>();
            var first = path.FirstOrDefault();
            var last = path.LastOrDefault();

            float shortestTime = spell.GetAvailableTime(Player.Instance.Position.To2D());
            shortestTime = Math.Max(0, shortestTime - (Game.Ping + ServerTimeBuffer));


            if (first == default(Vector2) || last == default(Vector2) || first == last)
                return shortestTime;

            detailedPath.Add(first);
            detailedPath.Add(last);



            foreach (Vector2 pathPoint in detailedPath.Where(x => spell.ToPolygon().IsInside(x)))
            {
                float maxTime = spell.GetAvailableTime(pathPoint);
                float time = Math.Max(0, maxTime - (Game.Ping + ServerTimeBuffer));
                shortestTime = Math.Min(shortestTime, time);
            }

            return shortestTime;
        }

        public bool IsPathSafeEx(Vector2[] path, AIHeroClient hero = null)
        {
            hero = hero ?? Player.Instance;
            path = new[] { hero.Position.To2D(), LastIssueOrderPos };

            var pathStart = path[0];
            var pathEnd = path[1];

            foreach (var pair in _skillshotPolygonCache)
            {
                EvadeSkillshot skillshot = pair.Key;
                var polygon = pair.Value;
                Func<Vector2, bool> isInside = point =>
                {
                    if (skillshot.OwnSpellData.IsVeigarE)
                    {
                        return skillshot.ToInnerPolygon().IsOutside(point) && skillshot.ToOuterPolygon().IsInside(point);
                    }

                    return polygon.IsInside(point);
                };


                var intersections =
                    polygon.GetIntersectionPointsWithLineSegment(hero.Position.To2D(), pathEnd);

                if (intersections.Length == 0 && isInside(hero.Position.To2D()) && isInside(pathEnd))
                {
                    var time2 = skillshot.GetAvailableTime(pathEnd);

                    if (hero.WalkingTime(hero.Position.To2D(), pathEnd) >= time2 - Game.Ping)
                    {
                        //Chat.Print(Game.Time + "   path unsafe");
                        return false;
                    }
                }
                else if (intersections.Length == 0 && !isInside(pathStart) && !isInside(pathEnd))
                    continue; //safe path for now => next skillshot

                if (intersections.Length == 1)
                {
                    bool beingInside = isInside(pathStart);
                    if (beingInside)
                    {
                        float skillshotTime = skillshot.GetAvailableTime(intersections[0]);
                        skillshotTime = Math.Max(0, skillshotTime - (Game.Ping + ServerTimeBuffer));
                        bool enoughTime = hero.WalkingTime(hero.Position.To2D(), intersections[0]) < skillshotTime;
                        if (!enoughTime)
                        {
                            //Chat.Print(Game.Time + "   path unsafe");
                            return false;
                        }
                    }
                    else //being outside
                    {
                        float walkTimeToEdge = hero.WalkingTime(hero.Position.To2D(), intersections[0]);
                        float skillshotTime = skillshot.GetAvailableTime(intersections[0]);
                        skillshotTime = Math.Max(0, skillshotTime - (Game.Ping + ServerTimeBuffer));

                        float time = skillshotTime - walkTimeToEdge;
                        if (time > -100)
                        {
                            //Chat.Print(Game.Time + "   path unsafe");
                            return false;
                        }
                    }
                }
                else if (intersections.Length >= 2) //cross
                {
                    if (skillshot.OwnSpellData.ForbidCrossing)
                        return false;

                    var firstDangerPoint = intersections.OrderBy(x => x.Distance(hero)).First();
                    var crossPoint = intersections.OrderBy(x => x.Distance(hero)).Last();

                    var walkTimeToDangerStart = hero.WalkingTime(hero.Position.To2D(), firstDangerPoint);
                    var walkTimeToDangerEnd = hero.WalkingTime(hero.Position.To2D(), crossPoint);

                    float maxTime1 = skillshot.GetAvailableTime(firstDangerPoint);
                    float time1 = Math.Max(0, maxTime1 - Game.Ping + ServerTimeBuffer);

                    float maxTime2 = skillshot.GetAvailableTime(crossPoint);
                    float time2 = Math.Max(0, maxTime2 - Game.Ping + ServerTimeBuffer);

                    bool dangerStartUnsafe = time1 - walkTimeToDangerStart > 0;
                    bool dangerEndUnsafe = walkTimeToDangerEnd > time2;

                    if (dangerStartUnsafe && dangerEndUnsafe)
                    {
                        //Chat.Print(Game.Time + "   path unsafe");
                        return false;
                    }
                }
            }

            return true;
        }

        public bool IsPathSafeEx(Vector2 end, AIHeroClient hero = null)
        {
            hero = hero ?? Player.Instance;

            return IsPathSafeEx(hero.GetPath(end.To3DWorld(), true).ToVector2(), hero);
        }

        public bool CheckPathCollision(Obj_AI_Base unit, Vector2 movePos)
        {
            var path = unit.GetPath(Player.Instance.Position, movePos.To3D());

            if (path.Length > 0)
            {
                if (movePos.Distance(path[path.Length - 1].To2D()) > 5 || path.Length > 2)
                {
                    return true;
                }
            }

            return false;
        }


        public Vector2[] GetSmoothEvadePoints(Vector2 movePos)
        {
            int posChecked = 0;
            int maxPosToCheck = 50;
            int posRadius = 50;
            int radiusIndex = 0;

            Vector2 heroPoint = Player.Instance.Position.To2D();

            List<Vector2> posTable = new List<Vector2>();

            while (posChecked < maxPosToCheck)
            {
                radiusIndex++;

                int curRadius = radiusIndex * (2 * posRadius);
                int curCircleChecks = (int)Math.Ceiling((2 * Math.PI * curRadius) / (2 * (double)posRadius));

                for (int i = 1; i < curCircleChecks; i++)
                {
                    posChecked++;
                    var cRadians = (2 * Math.PI / (curCircleChecks - 1)) * i; //check decimals
                    var pos = new Vector2((float)Math.Floor(heroPoint.X + curRadius * Math.Cos(cRadians)), (float)Math.Floor(heroPoint.Y + curRadius * Math.Sin(cRadians)));

                    posTable.Add(pos);
                }
            }

            return posTable.ToArray();
        }

        private Vector2[] GetJukePoints()
        {
            int posChecked = 0;
            int maxPosToCheck = 150;
            int posRadius = 80;
            int radiusIndex = 0;

            Vector2 heroPoint = Player.Instance.Position.To2D();

            List<Vector2> posTable = new List<Vector2>();

            while (posChecked < maxPosToCheck)
            {
                radiusIndex++;

                int curRadius = radiusIndex * (2 * posRadius);
                int curCircleChecks = (int)Math.Ceiling((2 * Math.PI * curRadius) / (2 * (double)posRadius));

                for (int i = 1; i < curCircleChecks; i++)
                {
                    posChecked++;
                    var cRadians = (2 * Math.PI / (curCircleChecks - 1)) * i; //check decimals
                    var pos = new Vector2((float)Math.Floor(heroPoint.X + curRadius * Math.Cos(cRadians)), (float)Math.Floor(heroPoint.Y + curRadius * Math.Sin(cRadians)));

                    posTable.Add(pos);
                }
            }

            List<Vector2> finalPosTable = new List<Vector2>();
            foreach (Vector2 pos in posTable.Where(x => IsPointSafe(x) && IsPathSafeEx(x) && !Utils.Utils.IsWall(x)))
            {
                bool validPos = true;
                foreach (EvadeSkillshot skillshot in SpellDetector.ActiveSkillshots)
                {
                    int time = skillshot.GetAvailableTime(pos);
                    int maxTime = Math.Max(0, time - (Game.Ping + ServerTimeBuffer));

                    if (Player.Instance.WalkingTime(pos) < maxTime)
                        validPos = false;
                }

                if (validPos)
                    finalPosTable.Add(pos);
            }

            return finalPosTable.ToArray();
        }

        public Vector2[] GetEvadePoints(Vector2 from, float moveRadius)
        {
            var playerPos = Player.Instance.Position.To2D();

            var mode = EvadeMenu.MainMenu["evadeMode"].Cast<ComboBox>().CurrentValue;
            if (mode == 1)
            {
                var polygons = ClippedPolygons.Where(p => p.IsInside(from)).ToArray();
                var segments = new List<Vector2[]>();

                foreach (var pol in polygons)
                {
                    for (var i = 0; i < pol.Points.Count; i++)
                    {
                        var start = pol.Points[i];
                        var end = i == pol.Points.Count - 1 ? pol.Points[0] : pol.Points[i + 1];

                        var intersections =
                            Utils.Utils.GetLineCircleIntersectionPoints(from, moveRadius, start, end)
                                .Where(p => p.IsInLineSegment(start, end))
                                .ToList();

                        if (intersections.Count == 0)
                        {
                            if (start.Distance(from, true) < moveRadius.Pow() &&
                                end.Distance(from, true) < moveRadius.Pow())
                            {
                                intersections = new[] { start, end }.ToList();
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (intersections.Count == 1)
                        {
                            intersections.Add(from.Distance(start, true) > from.Distance(end, true) ? end : start);
                        }

                        segments.Add(intersections.ToArray());
                    }
                }

                if (!segments.Any()) //not enough time
                {
                    return new Vector2[] { };
                }

                const int maxdist = 3000;
                const int division = 10;
                var points = new List<Vector2>();

                foreach (var segment in segments)
                {
                    var dist = segment[0].Distance(segment[1]);
                    if (dist > maxdist)
                    {
                        segment[0] = segment[0].Extend(segment[1], dist / 2 - maxdist / 2f);
                        segment[1] = segment[1].Extend(segment[1], dist / 2 - maxdist / 2f);
                        dist = maxdist;
                    }

                    var step = maxdist / division;
                    var count = dist / step;

                    for (var i = 0; i < count; i++)
                    {
                        var point = segment[0].Extend(segment[1], i * step);

                        if (!Utils.Utils.IsWall(point) && IsPathSafeEx(point) &&
                            Player.Instance.GetPath(point.To3DWorld(), true).Length <= 2)
                        {
                            points.Add(point);
                        }
                    }
                }

                var orderedPoints = points.Where(IsPointSafe).Where(
                    p => DoesntCrossVeigarE(p, playerPos)).Where(x => !Utils.Utils.IsWall(x));

                return orderedPoints.ToArray();
            }

            var evadePoints = GetSmoothEvadePoints(playerPos).Where(IsPointSafe).Where(
                p => DoesntCrossVeigarE(p, playerPos)).Where(x => !Utils.Utils.IsWall(x));

            return evadePoints.ToArray();
        }

        private bool DoesntCrossVeigarE(Vector2 p, Vector2 playerPos)
        {
            var veigarSkill = _skillshotPolygonCache.Keys.FirstOrDefault(x => x.OwnSpellData.IsVeigarE);
            if (veigarSkill == null)
                return true;

            var pol1 = veigarSkill.ToInnerPolygon();
            var pol2 = veigarSkill.ToOuterPolygon();

            var inters1 = pol1.GetIntersectionPointsWithLineSegment(playerPos, p);
            var inters2 = pol2.GetIntersectionPointsWithLineSegment(playerPos, p);

            if (inters1.Any())
            {
                var nearestInter = inters1.OrderBy(x => x.Distance(playerPos)).First();
                if (pol2.Points.Any(x => x.Distance(playerPos) < nearestInter.Distance(playerPos)))
                    return false;//not the closest point
            }

            if (inters2.Any())
            {
                var nearestInter = inters2.OrderBy(x => x.Distance(playerPos)).First();
                if (pol1.Points.Any(x => x.Distance(playerPos) < nearestInter.Distance(playerPos)))
                    return false;//not the closest point
            }

            return inters1.Length + inters2.Length < 2;
        }

        public Vector2 GetClosestEvadePoint(Vector2 from)
        {
            var polygons = ClippedPolygons.Where(p => p.IsInside(from)).ToArray();

            var polPoints =
                polygons.Select(pol => pol.ToDetailedPolygon())
                    .SelectMany(pol => pol.Points)
                    .OrderByDescending(p => p.Distance(from, true));

            return !polPoints.Any() ? Vector2.Zero : polPoints.Last();
        }

        int GetHeroesNearby(Vector2 p)
        {
            return EntityManager.Heroes.Enemies.Count(x => x.Distance(p) < MinComfortDistance && !x.IsDead && x.IsEnemy);
        }

        public EvadeResult CalculateEvade(Vector2 anchor, bool beginOutside = false)
        {
            var playerPos = Player.Instance.ServerPosition.To2D();
            var maxTime = GetTimeAvailable();
            var time = Math.Max(0, maxTime - (Game.Ping + ServerTimeBuffer));
            var moveRadius = time / 1000F * Player.Instance.MoveSpeed;

            var points = !beginOutside ? GetEvadePoints(playerPos, moveRadius) : GetJukePoints();

            if (!points.Any())
            {
                return new EvadeResult(this, GetClosestEvadePoint(playerPos), anchor, maxTime, time, true);
            }

            bool any = points.Any(x => GetHeroesNearby(x) > IgnoreAt) && points.Any(x => GetHeroesNearby(x) == 0);
            var evadePoint =
                any ?
                points.Where(x => GetHeroesNearby(x) == 0).OrderBy(x => IsPathSafeEx(x)).
                ThenBy(p => !p.IsUnderTurret()).ThenBy(p => p.Distance(Game.CursorPos)).FirstOrDefault()
                :
                points.OrderBy(x => IsPathSafeEx(x)).ThenBy(p => !p.IsUnderTurret()).ThenBy(p => p.Distance(Game.CursorPos))
                    .FirstOrDefault();

            return new EvadeResult(this, evadePoint, anchor, maxTime, time,
                !IsHeroInDanger() || GetTimeUnitlOutOfDangerArea(evadePoint) < time);
        }

        public bool IsHeroPathSafe(Vector3[] desiredPath, AIHeroClient hero = null)
        {
            hero = hero ?? Player.Instance;

            var path = (desiredPath ?? hero.RealPath()).ToVector2();
            return IsPathSafeEx(path, hero);
        }

        public bool MoveTo(Vector2 point, bool limit = true)
        {
            if (limit && EvadeIssurOrderTime + IssueOrderTickLimit >= Environment.TickCount)
            {
                return false;
            }

            EvadeIssurOrderTime = Environment.TickCount;
            Player.IssueOrder(GameObjectOrder.MoveTo, point.To3DWorld(), false);

            return true;
        }

        public bool MoveTo(Vector3 point, bool limit = true)
        {
            return MoveTo(point.To2D(), limit);
        }

        int GetTimeUnitlOutOfDangerArea(Vector2 evadePoint)
        {
            IEnumerable<Vector2> inters =
                (from polygon in SpellDetector.ActiveSkillshots.Select(x => x.ToRealPolygon())
                 let intersections = polygon.GetIntersectionPointsWithLineSegment(Player.Instance.Position.To2D(), evadePoint)
                 .OrderBy(x => x.Distance(Player.Instance))
                 where intersections.Any()
                 select intersections.Last()).ToList();

            if (inters.Any())
            {
                var farest = inters.OrderBy(x => x.Distance(Player.Instance)).Last();
                return Player.Instance.WalkingTime(farest);
            }

            return int.MaxValue;
        }

        Vector2 GetExtendedEvade(Vector2 p)
        {
            float minExtension = 225;
            float maxExtension = 300;
            for (float i = minExtension; i <= maxExtension; i++)
            {
                var newP = Player.Instance.Position.Extend(p, Player.Instance.Distance(p) + i);
                if (IsPointSafe(newP) && IsPathSafe(new[] { Player.Instance.Position.To2D(), newP }))
                    return newP;
            }

            return p;
        }

        public bool DoEvade(Vector3[] desiredPath = null, PlayerIssueOrderEventArgs args = null)
        {
            #region pre
            if (!EvadeEnabled || Player.Instance.IsDead || Player.Instance.IsDashing())
            {
                LastEvadeResult = null;
                AutoPathing.StopPath();
                return false;
            }

            var hero = Player.Instance;

            if (args != null && args.Order == GameObjectOrder.AttackUnit)
            {
                if (!hero.IsInAutoAttackRange((AttackableUnit)args.Target))
                {
                    desiredPath = hero.GetPath(args.Target.Position, true);
                }
            }
            #endregion pre

            #region execute evade point movement
            if (LastEvadeResult != null)
            {
                var isPathSafe = IsHeroPathSafe(desiredPath);
                if (!IsHeroInDanger(hero) && isPathSafe)
                {
                    LastEvadeResult = null;
                    AutoPathing.StopPath();
                    return false;
                }

                if (!hero.IsMovingTowards(LastEvadeResult.WalkPoint) || !isPathSafe)
                {
                    AutoPathing.StopPath();
                    MoveTo(GetExtendedEvade(LastEvadeResult.WalkPoint.To2D()), false);
                }

                return true;
            }
            #endregion execute evade point movement

            #region check evade
            if (IsHeroInDanger(hero))
            {
                var evade = CalculateEvade(LastIssueOrderPos);
                if (evade.IsValid && evade.EnoughTime)
                {
                    if (LastEvadeResult == null ||
                        (LastEvadeResult.EvadePoint.Distance(evade.EvadePoint, true) > 500.Pow() &&
                         AllowRecalculateEvade))
                    {
                        LastEvadeResult = evade;
                    }
                }
                else if (!evade.EnoughTime)
                {
                    return EvadeSpellManager.TryEvadeSpell(evade, this);
                }
            }
            else if (!IsPathSafe(hero.RealPath()) || (desiredPath != null && !IsPathSafe(desiredPath)))
            {
                var evade = CalculateEvade(LastIssueOrderPos, true);

                if (evade.IsValid)
                {
                    LastEvadeResult = evade;
                    return true;
                }
                //LastEvadeResult = null;
                return desiredPath != null;
            }
            #endregion check evade
            else
            {
                AutoPathing.StopPath();
                LastEvadeResult = null;
            }


            return false;
        }

        public class EvadeResult
        {
            private MoonWalkEvade _moonWalkEvade;
            private int ExtraRange { get; set; }

            public int Time { get; set; }
            public Vector2 PlayerPos { get; set; }
            public Vector2 EvadePoint { get; set; }
            public Vector2 AnchorPoint { get; set; }
            public int TimeAvailable { get; set; }
            public int TotalTimeAvailable { get; set; }
            public bool EnoughTime { get; set; }

            public bool OutsideEvade => Environment.TickCount - OutsideEvadeTime <= 500;

            public int OutsideEvadeTime { get; set; }

            public bool IsValid => !EvadePoint.IsZero;

            public Vector3 WalkPoint
            {
                get
                {
                    var walkPoint = EvadePoint.Extend(PlayerPos, -80);
                    var newPoint = walkPoint.Extend(PlayerPos, -ExtraRange);

                    if (_moonWalkEvade.IsPointSafe(newPoint))
                    {
                        return newPoint.To3DWorld();
                    }

                    return walkPoint.To3DWorld();
                }
            }

            public EvadeResult(MoonWalkEvade moonWalkEvade, Vector2 evadePoint, Vector2 anchorPoint, int totalTimeAvailable,
                int timeAvailable,
                bool enoughTime)
            {
                _moonWalkEvade = moonWalkEvade;
                PlayerPos = Player.Instance.Position.To2D();
                Time = Environment.TickCount;

                EvadePoint = evadePoint;
                AnchorPoint = anchorPoint;
                TotalTimeAvailable = totalTimeAvailable;
                TimeAvailable = timeAvailable;
                EnoughTime = enoughTime;

                // extra _moonWalkEvade range
                if (_moonWalkEvade.ExtraEvadeRange > 0)
                {
                    ExtraRange = (_moonWalkEvade.RandomizeExtraEvadeRange
                        ? Utils.Utils.Random.Next(_moonWalkEvade.ExtraEvadeRange / 3, _moonWalkEvade.ExtraEvadeRange)
                        : _moonWalkEvade.ExtraEvadeRange);
                }
            }

            public bool Expired(int time = 4000)
            {
                return Elapsed(time);
            }

            public bool Elapsed(int time)
            {
                return Elapsed() > time;
            }

            public int Elapsed()
            {
                return Environment.TickCount - Time;
            }
        }
    }
}