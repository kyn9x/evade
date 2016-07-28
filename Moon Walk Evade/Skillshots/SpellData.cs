using EloBuddy;
using SharpDX;

namespace Moon_Walk_Evade.Skillshots
{
    public class SpellData
    {
        public string DisplayName { get; set; }
        public string SpellName { get; set; }
        public string ObjectCreationName { get; set; }
        public SpellSlot Slot { get; set; }
        public int Delay { get; set; }
        public int Range { get; set; }
        public int Radius { get; set; }
        public float MissileSpeed { get; set; }
        public int DangerValue { get; set; }
        public bool IsDangerous { get; set; }
        public string ChampionName { get; set; }
        public string ToggleParticleName { get; set; }
        public bool AddHitbox { get; set; }
        public int ExtraMissiles { get; set; }

        public bool EnabledByDefault { get; set; } = true;

        public bool MinionCollision { get; set; } = false;

        public bool IsGlobal => Range > 10000;

        public float ConeAngle { get; set; }


        public int RingRadius { get; set; } = 0;
        public bool IsVeigarE => RingRadius > 0;
        public bool IsPerpendicular { get; set; }
        public int SecondaryRadius { get; set; }
        public Vector2 Direction { get; set; }
        public bool ForbidCrossing { get; set; }

        public SpellData()
        {
            AddHitbox = true;
        }
    }
}