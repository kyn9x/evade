using System.Collections.Generic;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using MoonWalkEvade.EvadeSpells;
using MoonWalkEvade.Skillshots;

namespace MoonWalkEvade
{
    internal static class MenuExtension
    {
        public static void AddStringList(this Menu m, string uniqueId, string displayName, string[] values, int defaultValue)
        {
            var mode = m.Add(uniqueId, new Slider(displayName, defaultValue, 0, values.Length - 1));
            mode.DisplayName = displayName + ": " + values[mode.CurrentValue];
            mode.OnValueChange += delegate (ValueBase<int> sender, ValueBase<int>.ValueChangeArgs args)
            {
                sender.DisplayName = displayName + ": " + values[args.NewValue];
            };
        }
    }
    internal class EvadeMenu
    {
        public static Menu MainMenu { get; private set; }
        public static Menu SkillshotMenu { get; private set; }
        public static Menu SpellMenu { get; private set; }
        public static Menu DrawMenu { get; private set; }
        public static Menu HotkeysMenu { get; private set; }

        public static Menu CollisionMenu { get; private set; }

        public static readonly Dictionary<string, EvadeSkillshot> MenuSkillshots = new Dictionary<string, EvadeSkillshot>();
        public static readonly List<EvadeSpellData> MenuEvadeSpells = new List<EvadeSpellData>();

        public static void CreateMenu()
        {
            if (MainMenu != null)
            {
                return;
            }

            MainMenu = EloBuddy.SDK.Menu.MainMenu.AddMenu("MoonWalkEvade", "MoonWalkEvade");

            // Set up main menu
            MainMenu.AddGroupLabel("General Settings");
            MainMenu.Add("evadeMode", new ComboBox("Evade Mode", 0, "Smooth - Moon Walk Style", "Fast - EvadePlus Style"));
            MainMenu.AddSeparator();

            MainMenu.Add("fowDetection", new CheckBox("Enable FOW Detection"));
            MainMenu.Add("processSpellDetection", new CheckBox("Enable Fast Spell Detection"));
            MainMenu.Add("limitDetectionRange", new CheckBox("Limit Spell Detection Range"));
            MainMenu.Add("recalculatePosition", new CheckBox("Allow Recalculation Of Evade Position", false));
            MainMenu.Add("moveToInitialPosition", new CheckBox("Move To Desired Position After Evade", false));
            MainMenu.AddSeparator();

            MainMenu.Add("minComfortDist", new Slider("Minimum Comfort Distance To Enemies", 550, 0, 1000));
            MainMenu.AddLabel("If possible");
            MainMenu.AddSeparator(10);
            MainMenu.Add("ignoreComfort", new Slider("Ignore Comfort Distance For X Enemies", 1, 1, 5));
            MainMenu.AddSeparator();

            MainMenu.AddGroupLabel("Humanizer");
            MainMenu.Add("skillshotActivationDelay", new Slider("Reaction Delay", 0, 0, 400));
            MainMenu.AddSeparator();

            MainMenu.Add("extraEvadeRange", new Slider("Extra Evade Range", 0, 0, 300));
            MainMenu.Add("randomizeExtraEvadeRange", new CheckBox("Randomize Extra Range", false));

            var heroes = Program.DeveloperMode ? EntityManager.Heroes.AllHeroes : EntityManager.Heroes.Enemies;
            var heroNames = heroes.Select(obj => obj.ChampionName).ToArray();
            var skillshots =
                SkillshotDatabase.Database.Where(s => heroNames.Contains(s.OwnSpellData.ChampionName)).ToList();
            skillshots.AddRange(
                SkillshotDatabase.Database.Where(
                    s =>
                        s.OwnSpellData.ChampionName == "AllChampions" &&
                        heroes.Any(obj => obj.Spellbook.Spells.Select(c => c.Name).Contains(s.OwnSpellData.SpellName))));
            var evadeSpells =
                EvadeSpellDatabase.Spells.Where(s => Player.Instance.ChampionName.Contains(s.ChampionName)).ToList();
            evadeSpells.AddRange(EvadeSpellDatabase.Spells.Where(s => s.ChampionName == "AllChampions"));


            SkillshotMenu = MainMenu.AddSubMenu("Skillshots");

            foreach (var c in skillshots)
            {
                var skillshotString = c.ToString().ToLower();

                if (MenuSkillshots.ContainsKey(skillshotString))
                    continue;

                MenuSkillshots.Add(skillshotString, c);

                SkillshotMenu.AddGroupLabel(c.DisplayText);
                SkillshotMenu.Add(skillshotString + "/enable", new CheckBox("Dodge", c.OwnSpellData.EnabledByDefault));
                SkillshotMenu.Add(skillshotString + "/draw", new CheckBox("Draw"));

                var dangerous = new CheckBox("Dangerous", c.OwnSpellData.IsDangerous);
                dangerous.OnValueChange += delegate (ValueBase<bool> sender, ValueBase<bool>.ValueChangeArgs args)
                {
                    GetSkillshot(sender.SerializationId).OwnSpellData.IsDangerous = args.NewValue;
                };
                SkillshotMenu.Add(skillshotString + "/dangerous", dangerous);

                var dangerValue = new Slider("Danger Value", c.OwnSpellData.DangerValue, 1, 5);
                dangerValue.OnValueChange += delegate (ValueBase<int> sender, ValueBase<int>.ValueChangeArgs args)
                {
                    GetSkillshot(sender.SerializationId).OwnSpellData.DangerValue = args.NewValue;
                };
                SkillshotMenu.Add(skillshotString + "/dangervalue", dangerValue);

                SkillshotMenu.AddSeparator();
            }

            // Set up spell menu
            SpellMenu = MainMenu.AddSubMenu("Evading Spells");

            foreach (var e in evadeSpells)
            {
                var evadeSpellString = e.SpellName;

                if (MenuEvadeSpells.Any(x => x.SpellName == evadeSpellString))
                    continue;

                MenuEvadeSpells.Add(e);

                SpellMenu.AddGroupLabel(evadeSpellString);
                SpellMenu.Add(evadeSpellString + "/enable", new CheckBox("Use " + (!e.isItem ? e.Slot.ToString() : "")));

                var dangerValueSlider = new Slider("Danger Value", e.DangerValue, 1, 5);
                dangerValueSlider.OnValueChange += delegate (ValueBase<int> sender, ValueBase<int>.ValueChangeArgs args)
                {
                    MenuEvadeSpells.First(x =>
                        x.SpellName.Contains(sender.SerializationId.Split('/')[0])).DangerValue = args.NewValue;
                };
                SpellMenu.Add(evadeSpellString + "/dangervalue", dangerValueSlider);

                SpellMenu.AddSeparator();
            }


            DrawMenu = MainMenu.AddSubMenu("Drawings");
            DrawMenu.Add("disableAllDrawings", new CheckBox("Disable All Drawings", false));
            DrawMenu.Add("drawEvadePoint", new CheckBox("Draw Evade Point"));
            DrawMenu.Add("drawEvadeStatus", new CheckBox("Draw Evade Status"));
            DrawMenu.Add("drawSkillshots", new CheckBox("Draw Skillshots"));
            DrawMenu.Add("drawDangerPolygon", new CheckBox("Draw Danger Polygon"));


            HotkeysMenu = MainMenu.AddSubMenu("KeyBinds");
            HotkeysMenu.Add("enableEvade", new KeyBind("Enable Evade", true, KeyBind.BindTypes.PressToggle, 'M'));
            HotkeysMenu.Add("dodgeOnlyDangerousH", new KeyBind("Dodge Only Dangerous (Hold)", false, KeyBind.BindTypes.HoldActive));
            HotkeysMenu.Add("dodgeOnlyDangerousT", new KeyBind("Dodge Only Dangerous (Toggle)", false, KeyBind.BindTypes.PressToggle));
            HotkeysMenu.AddSeparator();
            HotkeysMenu.Add("debugMode", new KeyBind("Debug Mode", false, KeyBind.BindTypes.PressToggle));
            HotkeysMenu.Add("debugModeIntervall", new Slider("Debug Skillshot Creation Intervall", 1000, 0, 5000));
            HotkeysMenu.AddStringList("debugMissile", "Selected Skillshot", SkillshotDatabase.Database.Select(x => x.OwnSpellData.SpellName).ToArray(), 0);
            HotkeysMenu.Add("isProjectile", new CheckBox("Is Projectile?"));

            CollisionMenu = MainMenu.AddSubMenu("Collision");
            CollisionMenu.Add("minion", new CheckBox("Attend Minion Collision"));
            CollisionMenu.Add("yasuoWall", new CheckBox("Attend Yasuo Wall"));
            CollisionMenu.Add("useProj", new CheckBox("Use Spell Projection", false));
        }

        private static EvadeSkillshot GetSkillshot(string s)
        {
            return MenuSkillshots[s.ToLower().Split('/')[0]];
        }

        public static bool IsSkillshotEnabled(EvadeSkillshot skillshot)
        {
            var valueBase = SkillshotMenu[skillshot + "/enable"];
            return (valueBase != null && valueBase.Cast<CheckBox>().CurrentValue) ||
                HotkeysMenu["debugMode"].Cast<KeyBind>().CurrentValue;
        }

        public static bool IsSkillshotDrawingEnabled(EvadeSkillshot skillshot)
        {
            var valueBase = SkillshotMenu[skillshot + "/draw"];
            return (valueBase != null && valueBase.Cast<CheckBox>().CurrentValue) ||
                HotkeysMenu["debugMode"].Cast<KeyBind>().CurrentValue;
        }
    }
}