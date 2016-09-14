using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using SharpDX;

namespace Evade.Benchmarking
{
    public static class Benchmark
    {
        private static Vector2 startPoint;
        private static Vector2 endPoint;

        public static void Initialize()
        {
            Game.OnWndProc += Game_OnWndProc;
        }

        private static void Game_OnWndProc(WndEventArgs args)
        {
            if (args.Msg == (uint)WindowMessages.LeftButtonDown)
            {
                startPoint = Game.CursorPos.To2D();
            }

            if (args.Msg == (uint)WindowMessages.LeftButtonUp)
            {
                endPoint = Game.CursorPos.To2D();
            }
        }
    }
}
