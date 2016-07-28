using System.Collections.Generic;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using Moon_Walk_Evade.Utils;
using SharpDX;

namespace Moon_Walk_Evade.EvadeSpells
{
    public static class EvadeSpellManager
    {
        public static bool ProcessFlash(Evading.MoonWalkEvade evade)
        {
            var castPos = GetBlinkCastPos(evade, Player.Instance.ServerPosition.To2D(), 425);
            var slot = GetFlashSpellSlot();
            if (!castPos.IsZero && slot != SpellSlot.Unknown && Player.Instance.Spellbook.GetSpell(slot).IsReady)
            {
                Player.Instance.Spellbook.CastSpell(slot, castPos.To3D());
                return true;
            }

            return false;
        }

        public static SpellSlot GetFlashSpellSlot()
        {
            return Player.Instance.GetSpellSlotFromName("summonerflash");
        }


        public static Vector2 GetBlinkCastPos(Evading.MoonWalkEvade moonWalkEvade, Vector2 center, float maxRange)
        {
            var polygons = moonWalkEvade.ClippedPolygons.Where(p => p.IsInside(center)).ToArray();
            var segments = new List<Vector2[]>();

            foreach (var pol in polygons)
            {
                for (var i = 0; i < pol.Points.Count; i++)
                {
                    var start = pol.Points[i];
                    var end = i == pol.Points.Count - 1 ? pol.Points[0] : pol.Points[i + 1];

                    var intersections =
                        Utils.Utils.GetLineCircleIntersectionPoints(center, maxRange, start, end)
                            .Where(p => p.IsInLineSegment(start, end))
                            .ToList();

                    if (intersections.Count == 0)
                    {
                        if (start.Distance(center, true) < maxRange.Pow() &&
                            end.Distance(center, true) < maxRange.Pow())
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
                        intersections.Add(center.Distance(start, true) > center.Distance(end, true)
                            ? end
                            : start);
                    }

                    segments.Add(intersections.ToArray());
                }
            }

            if (!segments.Any())
            {
                return Vector2.Zero;
            }

            const int maxdist = 2000;
            const int division = 30;
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
                    if (!Extensions.IsWall(point))
                    {
                        points.Add(point);
                    }
                }
            }

            if (!points.Any())
            {
                return Vector2.Zero;
            }

            var evadePoint =
                points.Where
                (x => moonWalkEvade.IsPointSafe(x) && !Utils.Utils.IsWall(x)).OrderBy(x => x.Distance(Game.CursorPos)).
                FirstOrDefault();
            return evadePoint;
        }

        public static bool TryEvadeSpell(Evading.MoonWalkEvade.EvadeResult evadeResult,
            Evading.MoonWalkEvade moonWalkEvadeInstance)
        {
            IEnumerable<EvadeSpellData> evadeSpells = EvadeMenu.MenuEvadeSpells.Where(evadeSpell =>
                EvadeMenu.SpellMenu[evadeSpell.SpellName + "/enable"].Cast<CheckBox>().CurrentValue);

            foreach (EvadeSpellData evadeSpell in evadeSpells.OrderBy(x => 
                x.SpellName.ToLower().Contains("flash")).ThenBy(x => x.DangerValue))
            {
                int dangerValue =
                        EvadeMenu.MenuEvadeSpells.First(x => x.SpellName == evadeSpell.SpellName).DangerValue;
                if (moonWalkEvadeInstance.GetDangerValue() < dangerValue)
                    continue;

                if (evadeSpell.SpellName.ToLower().Contains("flash"))
                {
                    return ProcessFlash(moonWalkEvadeInstance);
                }

                //dash
                if (evadeSpell.Range != 0)
                {
                    var evadePos = GetBlinkCastPos(moonWalkEvadeInstance, Player.Instance.Position.To2D(), evadeSpell.Range);
                    float castTime = evadeSpell.Delay;
                    if (evadeResult.TimeAvailable >= castTime && !evadePos.IsZero && moonWalkEvadeInstance.IsPointSafe(evadePos))
                    {
                        CastEvadeSpell(evadeSpell, evadePos);
                        return true;
                    }
                }

                //speed buff (spell or item)
                if (evadeSpell.EvadeType == EvadeType.MovementSpeedBuff)
                {
                    var playerPos = Player.Instance.Position.To2D();

                    float speed = Player.Instance.MoveSpeed;
                    speed += speed * evadeSpell.speedArray[Player.Instance.Spellbook.GetSpell(evadeSpell.Slot).Level - 1] / 100;
                    float maxTime = evadeResult.TimeAvailable - evadeSpell.Delay;
                    float maxTravelDist = speed * (maxTime / 1000);

                    var evadePoints = moonWalkEvadeInstance.GetEvadePoints(playerPos, maxTravelDist);

                    var evadePoint = evadePoints.OrderBy(x => !x.IsUnderTurret()).ThenBy(p => p.Distance(Game.CursorPos)).FirstOrDefault();
                    if (evadePoint != default(Vector2))
                    {
                        CastEvadeSpell(evadeSpell, evadeSpell.isItem ? Vector2.Zero : evadePoint);
                        return true;
                    }
                }

                //items
                if (evadeSpell.isItem && evadeSpell.EvadeType != EvadeType.MovementSpeedBuff)
                {
                    if (evadeResult.TimeAvailable >= evadeSpell.Delay)
                        CastEvadeSpell(evadeSpell, Vector2.Zero);
                    return true;
                }
            }

            return false;
        }

        private static void CastEvadeSpell(EvadeSpellData evadeSpell, Vector2 evadePos)
        {
            bool isItem = evadePos.IsZero;

            if (isItem)
            {
                Item.UseItem(evadeSpell.itemID);
                return;
            }


            switch (evadeSpell.CastType)
            {
                case CastType.Position:
                    if (!evadeSpell.isReversed)
                        Player.Instance.Spellbook.CastSpell(evadeSpell.Slot, evadePos.To3D());
                    else
                        Player.Instance.Spellbook.CastSpell(evadeSpell.Slot,
                            evadePos.Extend(Player.Instance, evadePos.Distance(Player.Instance) + evadeSpell.Range).To3D());
                    break;
                case CastType.Self:
                    Player.Instance.Spellbook.CastSpell(evadeSpell.Slot, Player.Instance);
                    break;
            }
        }
    }
}