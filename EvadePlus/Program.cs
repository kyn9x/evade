﻿using EloBuddy.SDK.Events;

namespace EvadePlus
{
    internal static class Program
    {
        public static bool DeveloperMode = true;
        public static bool SdkDrawings = false;

        private static SkillshotDetector _skillshotDetector;
        private static EvadePlus _evade;

        private static void Main(string[] args)
        {
            Loading.OnLoadingComplete += delegate
            {
                _skillshotDetector = new SkillshotDetector(DeveloperMode ? DetectionTeam.AnyTeam : DetectionTeam.EnemyTeam);
                _evade = new EvadePlus(_skillshotDetector);
                EvadeMenu.CreateMenu();
            };
        }
    }
}

