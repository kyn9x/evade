﻿// Copyright 2014 - 2014 Esk0r
// Config.cs is part of Evade.
// 
// Evade is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// Evade is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with Evade. If not, see <http://www.gnu.org/licenses/>.

#region

using System;
using System.Drawing;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

#endregion

namespace Evade
{
    internal static class Config
    {
        public const bool PrintSpellData = false;
        public const bool TestOnAllies = false;
        public const int SkillShotsExtraRadius = 9;
        public const int SkillShotsExtraRange = 20;
        public const int GridSize = 10;
        public const int ExtraEvadeDistance = 15;
        public const int PathFindingDistance = 180;
        public const int PathFindingDistance2 = 35;

        public const int DiagonalEvadePointsCount = 7;
        public const int DiagonalEvadePointsStep = 20;

        public const int CrossingTimeOffset = 250;

        public const int EvadingFirstTimeOffset = 250;
        public const int EvadingSecondTimeOffset = 80;

        public const int EvadingRouteChangeTimeOffset = 250;

        public const int EvadePointChangeInterval = 300;
        public static int LastEvadePointChangeT = 0;

        public static Menu Menu, evadeSpells, skillShots, shielding, collision, drawings, misc;
        public static Color EnabledColor, DisabledColor, MissileColor;

        public static void CreateMenu()
        {
            Menu = MainMenu.AddMenu("Evade Việt hóa", "evade");

            if (Menu == null)
            {
                Chat.Print("LOAD FAILED", Color.Red);
                Console.WriteLine("Evade:: LOAD FAILED");
                throw new NullReferenceException("Menu NullReferenceException");
            }

            //Create the evade spells submenus.
            evadeSpells = Menu.AddSubMenu("Dùng phép để né", "evadeSpells");
            foreach (var spell in EvadeSpellDatabase.Spells)
            {
                evadeSpells.AddGroupLabel(spell.Name);

                try
                {
                    evadeSpells.Add("DangerLevel" + spell.Name, new Slider("Mức độ để né", spell._dangerLevel, 1, 5));
                }
                catch (Exception e)
                {
                    throw e;
                }

                if (spell.IsTargetted && spell.ValidTargets.Contains(SpellValidTargets.AllyWards))
                {
                    evadeSpells.Add("WardJump" + spell.Name, new CheckBox("WardJump"));
                }

                evadeSpells.Add("Enabled" + spell.Name, new CheckBox("Bật"));
            }

            //Create the skillshots submenus.
            skillShots = Menu.AddSubMenu("Kỹ năng định hướng", "Kỹ năng định hướng");

            foreach (var hero in ObjectManager.Get<AIHeroClient>())
            {
                if (hero.Team != ObjectManager.Player.Team || Config.TestOnAllies)
                {
                    foreach (var spell in SpellDatabase.Spells)
                    {
                        if (String.Equals(spell.ChampionName, hero.ChampionName, StringComparison.InvariantCultureIgnoreCase))
                        {
                            skillShots.AddGroupLabel(spell.SpellName);
                            skillShots.Add("DangerLevel" + spell.MenuItemName, new Slider("Mức độ kỹ năng", spell.DangerValue, 1, 5));

                            skillShots.Add("IsDangerous" + spell.MenuItemName, new CheckBox("Kỹ năng nguy hiểm", spell.IsDangerous));

                            skillShots.Add("Draw" + spell.MenuItemName, new CheckBox("Đường kẻ"));
                            skillShots.Add("Enabled" + spell.MenuItemName, new CheckBox("Bật", !spell.DisabledByDefault));
                        }
                    }
                }
            }

            shielding = Menu.AddSubMenu("Lá chắn từ đồng đội", "Shielding");

            foreach (var ally in ObjectManager.Get<AIHeroClient>())
            {
                if (ally.IsAlly && !ally.IsMe)
                {
                    shielding.Add("shield" + ally.ChampionName, new CheckBox("Lá chắn " + ally.ChampionName));
                }
            }

            collision = Menu.AddSubMenu("Ân nấp", "Collision");
            collision.Add("MinionCollision", new CheckBox("Đứng sau lính để né", false));
            collision.Add("HeroCollision", new CheckBox("Đứng sau tướng để né", false));
            collision.Add("YasuoCollision", new CheckBox("Đứng sau tường gió để né"));
            collision.Add("EnableCollision", new CheckBox("Bật"));
            //TODO add mode.

            drawings = Menu.AddSubMenu("Đường kẻ", "Drawings");
            
            drawings.Add("Border", new Slider("Độ dày đường kẻ kỹ năng", 2, 5, 1));

            drawings.Add("EnableDrawings", new CheckBox("Bật"));
            drawings.Add("ShowEvadeStatus", new CheckBox("Hiển thị trạng thái Evade dưới chân nhân vật"));
            
            misc = Menu.AddSubMenu("Linh tinh", "Misc");
            misc.AddStringList("BlockSpells", "Chặn phép khi đang né", new[] { "Không", "Chỉ kỹ năng nguy hiểm", "Luôn luôn" }, 0);
            //misc.Add("BlockSpells", "Block spells while evading").SetValue(new StringList(new []{"No", "Only dangerous", "Always"}, 1)));
            misc.Add("DisableFow", new CheckBox("Loại bỏ né khi không có tầm nhìn", false));
            misc.Add("ShowEvadeStatus", new CheckBox("Hiển thị trạng thái Evade"));
            if (ObjectManager.Player.BaseSkinName == "Olaf")
            {
                misc.Add("DisableEvadeForOlafR", new CheckBox("Automatic disable Evade when Olaf's ulti is active!"));
            }

            Menu.Add("Enabled", new KeyBind("Bật", true, KeyBind.BindTypes.PressToggle, "K".ToCharArray()[0]));

            Menu.Add("OnlyDangerous", new KeyBind("Chỉ né những kỹ năng nguy hiểm", false, KeyBind.BindTypes.HoldActive)); //
        }
    }
}