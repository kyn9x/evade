using EloBuddy;
using EloBuddy.SDK;
using SharpDX;

namespace Moon_Walk_Evade.Skillshots
{
    public abstract class EvadeSkillshot
    {
        public SpellDetector SpellDetector { get; set; }
        public GameObject SpawnObject { get; set; }
        public Obj_AI_Base Caster { get; set; }
        public GameObjectProcessSpellCastEventArgs CastArgs { get; set; }
        public EloBuddy.SpellData SData { get; set; }
        public SpellData OwnSpellData { get; set; }
        public GameObjectTeam Team { get; set; }
        public bool IsActive { get; set; }
        public bool IsValid { get; set; }
        public bool CastComplete { get; set; }
        public int TimeDetected { get; set; }

        public bool IsProcessSpellCast => Caster != null;

        public string DisplayText => $"{OwnSpellData.ChampionName} {OwnSpellData.Slot} - {OwnSpellData.DisplayName}";

        public abstract Vector3 GetPosition();

        /// <summary>
        /// with missile
        /// </summary>
        public abstract void OnCreateObject(GameObject obj);

        /// <summary>
        /// with missile
        /// </summary>
        public virtual void OnDeleteObject(GameObject obj) { }

        /// <summary>
        /// obj == null ? procspellcast / no missile : objectcreate / missile
        /// </summary>
        public virtual void OnCreate(GameObject obj) { }

        public virtual bool OnDeleteMissile(GameObject obj)
        {
            return true;
        }

        public virtual void OnDispose() { }

        public abstract void OnDraw();

        public abstract void OnTick();

        /// <summary>
        /// without missile
        /// </summary>
        /// <param name="sender"></param>
        public virtual void OnSpellDetection(Obj_AI_Base sender) { }

        public abstract Geometry.Polygon ToRealPolygon();

        public abstract Geometry.Polygon ToPolygon(float extrawidth = 0);

        /// <summary>
        /// For Veigar E
        /// </summary>
        public virtual Geometry.Polygon ToInnerPolygon(float extrawidth = 0)
        {
            return new Geometry.Polygon();
        }

        /// <summary>
        /// For Veigar E
        /// </summary>
        public virtual Geometry.Polygon ToOuterPolygon(float extrawidth = 0)
        {
            return new Geometry.Polygon();
        }

        public abstract int GetAvailableTime(Vector2 pos);

        public abstract bool IsFromFow();

        public abstract EvadeSkillshot NewInstance(bool debug = false);

        public override string ToString()
        {
            return $"{OwnSpellData.ChampionName}_{OwnSpellData.Slot}_{OwnSpellData.DisplayName}";
        }
    }
}