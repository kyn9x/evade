using System;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using EloBuddy.SDK.Rendering;
using Moon_Walk_Evade.Skillshots;
using Moon_Walk_Evade.Skillshots.SkillshotTypes;
using SharpDX;

namespace Moon_Walk_Evade.Utils
{
    static class Debug
    {
        public static Vector3 GlobalEndPos = Vector3.Zero, GlobalStartPos = Vector3.Zero;
        private static SpellDetector spellDetector;
        public static int LastCreationTick;

        public static void Init(ref SpellDetector detector)
        {
            spellDetector = detector;

            Game.OnWndProc += GameOnOnWndProc;
            Drawing.OnDraw += args =>
            {
                if (!GlobalEndPos.IsZero)
                    new Circle { Color = System.Drawing.Color.DodgerBlue, Radius = 100 }.Draw(GlobalEndPos);
                if (!GlobalStartPos.IsZero)
                    new Circle { Color = System.Drawing.Color.Red, Radius = 100 }.Draw(GlobalStartPos);
            };
            Game.OnUpdate += GameOnOnUpdate;
        }

        private static EvadeSkillshot lastKSkillshot;
        private static void GameOnOnUpdate(EventArgs args)
        {
            if (lastKSkillshot != null)
            {
                if (!lastKSkillshot.IsValid || !lastKSkillshot.IsActive)
                {
                    lastKSkillshot = null;
                    return;
                }

                if (lastKSkillshot.GetType() == typeof(LinearSkillshot))
                {
                    var skill = (LinearSkillshot)lastKSkillshot;
                    if (skill.StartPosition.Distance(Player.Instance) <= Player.Instance.BoundingRadius && 
                        Player.Instance.Position.To2D().ProjectOn(skill.StartPosition.To2D(), skill.EndPosition.To2D()).IsOnSegment && skill.Missile != null)
                    {
                        Chat.Print(Game.Time + "  Hit");
                        lastKSkillshot = null;
                    }
                }
            }

            if (!EvadeMenu.HotkeysMenu["debugMode"].Cast<KeyBind>().CurrentValue)
                return;

            if (GlobalStartPos.IsZero || GlobalEndPos.IsZero)
                return;

            if (Environment.TickCount - LastCreationTick < EvadeMenu.HotkeysMenu["debugModeIntervall"].Cast<Slider>().CurrentValue)
                return;

            LastCreationTick = Environment.TickCount;
            var skillshot =
                SkillshotDatabase.Database[EvadeMenu.HotkeysMenu["debugMissile"].Cast<Slider>().CurrentValue];
            if (skillshot.GetType() == typeof(CircularSkillshot) ||
                skillshot.GetType() == typeof(MultiCircleSkillshot))
                EvadeMenu.HotkeysMenu["isProjectile"].Cast<CheckBox>().CurrentValue = false;


            var nSkillshot = skillshot.NewInstance(true);
            spellDetector.AddSkillshot(nSkillshot);
            lastKSkillshot = nSkillshot;


        }

        private static void GameOnOnWndProc(WndEventArgs args)
        {
            if (!EvadeMenu.HotkeysMenu["debugMode"].Cast<KeyBind>().CurrentValue)
                return;

            if (args.Msg == 0x0201)//mouse down
            {
                GlobalEndPos = Game.CursorPos;
            }

            if (args.Msg == 0x0202)
            {
                GlobalStartPos = Game.CursorPos;
            }
        }
        
    }
}
