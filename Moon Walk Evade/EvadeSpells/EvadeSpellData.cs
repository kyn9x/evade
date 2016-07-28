using EloBuddy;

namespace Moon_Walk_Evade.EvadeSpells
{
    public delegate bool UseSpellFunc(EvadeSpellData evadeSpell, bool process = true);

    public enum CastType
    {
        Position,
        Target,
        Self
    }

    public enum SpellTargets
    {
        AllyMinions,
        EnemyMinions,

        AllyChampions,
        EnemyChampions,

        Targetables
    }

    public enum EvadeType
    {
        Blink,
        Dash,
        Invulnerability,
        MovementSpeedBuff,
        Shield,
        SpellShield,
        WindWall
    }

    public class EvadeSpellData
    {
        public string ChampionName;
        public SpellSlot Slot = SpellSlot.Q;
        public int DangerValue = 1;
        public string SpellName;
        public bool checkSpellName = false;
        public float Delay = 250;
        public float Range;
        public float Speed = 0;
        public float[] speedArray = { 0f, 0f, 0f, 0f, 0f };
        public bool fixedRange = false;
        public EvadeType EvadeType;
        public bool isReversed = false;
        public bool behindTarget = false;
        public bool infrontTarget = false;
        public bool isSummonerSpell = false;
        public bool isItem = false;
        public ItemId itemID = 0;
        public CastType CastType = CastType.Position;
        public SpellTargets[] spellTargets = { };
        public UseSpellFunc useSpellFunc = null;
        public bool isSpecial = false;
        public bool untargetable = false;

        public EvadeSpellData()
        {

        }

        public EvadeSpellData(
            string championName,
            string displayName,
            SpellSlot slot,
            EvadeType evadeType,
            int dangerValue
            )
        {
            this.ChampionName = championName;
            this.Slot = slot;
            this.EvadeType = evadeType;
            this.DangerValue = dangerValue;
        }
    }
}
