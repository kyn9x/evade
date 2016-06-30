using System.Linq;
using AutoBuddy.MainLogics;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;

namespace AutoBuddy.MyChampLogic
{
    internal class Jinx : IChampLogic
    {

        public float MaxDistanceForAA { get { return int.MaxValue; } }
        public float OptimalMaxComboDistance { get { return AutoWalker.p.AttackRange; } }
        public float HarassDistance { get { return AutoWalker.p.AttackRange; } }

        public static Spell.Active Q;
        public static Spell.Skillshot W, E, R;

        public Jinx()
        {
            skillSequence = new[] { 1, 3, 2, 1, 1, 4, 1, 2, 1, 2, 4, 2, 2, 3, 3, 4, 3, 3 };
            ShopSequence =
                "3340:Buy,1055:Buy,2003:StartHpPot,1038:Buy,3133:Buy,3508:Buy,3086:Buy,3085:Buy,1001:Buy,3006:Buy,1038:Buy,3072:Buy,2003:StopHpPot,1038:Buy,3031:Buy,1055:Sell,3035:Buy,3036:Buy";
        }

        public int[] skillSequence { get; private set; }
        public LogicSelector Logic { get; set; }


        public string ShopSequence { get; private set; }

        public void Harass(AIHeroClient target)
        {
        }

        public void Survi()
        {
        }

        public void Combo(AIHeroClient target)
        {
        }
    }
}
