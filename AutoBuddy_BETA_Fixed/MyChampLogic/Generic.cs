﻿using AutoBuddy.MainLogics;
using EloBuddy;
using EloBuddy.SDK;

namespace AutoBuddy.MyChampLogic
{
    internal class Generic : IChampLogic
    {

        public float MaxDistanceForAA { get { return int.MaxValue; } }
        public float OptimalMaxComboDistance { get { return AutoWalker.p.AttackRange; } }
        public float HarassDistance { get { return AutoWalker.p.AttackRange; } }

        public Spell.Active Q;
        public Spell.Skillshot W, E, R;

        public Generic()
        {
            skillSequence = new[] {2, 1, 3, 2, 2, 4, 2, 1, 2, 1, 4, 1, 1, 3, 3, 4, 3, 3};
            ShopSequence =
                "1027:Buy,3340:Buy,2003:StartHpPot,3070:Buy,1058:Buy,1011:Buy,3116:Buy,3020:Buy,1058:Buy,1026:Buy,3089:Buy,2003:StopHpPot,3136:Buy,3151:Buy,1058:Buy,3003:Buy,3108:Buy,3001:Buy";
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
