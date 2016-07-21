using EloBuddy.SDK.Events;
using MoonWalkEvade.Skillshots;
using MoonWalkEvade.Utils;
using Collision = MoonWalkEvade.Evading.Collision;

namespace MoonWalkEvade
{
    internal static class Program
    {
        public static bool DeveloperMode = false;

        private static SpellDetector _spellDetector;

        private static void Main(string[] args)
        {
            Loading.OnLoadingComplete += delegate
            {
                _spellDetector = new SpellDetector(DeveloperMode ? DetectionTeam.AnyTeam : DetectionTeam.EnemyTeam);
                new Evading.MoonWalkEvade(_spellDetector);
                EvadeMenu.CreateMenu();

                Collision.Init();
                Debug.Init(ref _spellDetector);
            };
        }
    }
}
