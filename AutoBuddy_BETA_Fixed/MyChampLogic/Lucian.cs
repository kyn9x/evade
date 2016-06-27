﻿using AutoBuddy.MainLogics;
using EloBuddy;
using EloBuddy.SDK;

namespace AutoBuddy.MyChampLogic
{
    internal class Lucian : IChampLogic
    {
        public float MaxDistanceForAA { get { return int.MaxValue; } }
        public float OptimalMaxComboDistance { get { return AutoWalker.p.AttackRange; } }
        public float HarassDistance { get { return AutoWalker.p.AttackRange; } }

        public Spell.Active Q;
        public Spell.Skillshot W, E, R;

        public Lucian()
        {
            skillSequence = new[] { 1, 3, 2, 1, 1, 4, 1, 3, 1, 3, 4, 3, 3, 2, 2, 4, 2, 2 };
            ShopSequence =
                "3340:Buy,1055:Buy,2003:StartHpPot,1038:Buy,3133:Buy,1018:Buy,3508:Buy,3086:Buy,2015:Buy,3087:Buy,1001:Buy,3158:Buy,1038:Buy,3072:Buy,1038:Buy,3031:Buy,3140:Buy,3139:Buy";
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