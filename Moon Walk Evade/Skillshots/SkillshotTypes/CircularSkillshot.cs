using System;
using System.Text.RegularExpressions;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using Moon_Walk_Evade.Utils;
using SharpDX;
using Color = System.Drawing.Color;

namespace Moon_Walk_Evade.Skillshots.SkillshotTypes
{
    public class CircularSkillshot : EvadeSkillshot
    {
        public CircularSkillshot()
        {
            Caster = null;
            SpawnObject = null;
            SData = null;
            OwnSpellData = null;
            Team = GameObjectTeam.Unknown;
            IsValid = true;
            TimeDetected = Environment.TickCount;
        }

        public Vector3 StartPosition { get; set; }

        public Vector3 EndPosition { get; set; }

        public MissileClient Missile => SpawnObject as MissileClient;

        private bool _missileDeleted;
        

        public override Vector3 GetPosition()
        {
            return EndPosition;
        }

        /// <summary>
        /// Creates an existing Class Object unlike the DataBase contains
        /// </summary>
        /// <returns></returns>
        public override EvadeSkillshot NewInstance(bool debug = false)
        {
            var newInstance = new CircularSkillshot { OwnSpellData = OwnSpellData };
            if (debug)
            {
                bool isProjectile = EvadeMenu.HotkeysMenu["isProjectile"].Cast<CheckBox>().CurrentValue;
                var newDebugInst = new CircularSkillshot
                {
                    OwnSpellData = OwnSpellData,
                    StartPosition = Debug.GlobalStartPos,
                    EndPosition = Debug.GlobalEndPos,
                    IsValid = true,
                    IsActive = true,
                    TimeDetected = Environment.TickCount,
                    SpawnObject = isProjectile ? new MissileClient() : null
                };
                return newDebugInst;
            }
            return newInstance;
        }

        public override void OnCreate(GameObject obj)
        {
            if (Missile == null)
            {
                EndPosition = CastArgs.End;
            }
            else
            {
                EndPosition = Missile.EndPosition;
            }
        }

        public override void OnCreateObject(GameObject obj)
        {
            var missile = obj as MissileClient;

            if (SpawnObject == null && missile != null)
            {
                if (missile.SData.Name == OwnSpellData.ObjectCreationName && missile.SpellCaster.Index == Caster.Index)
                {
                    // Force skillshot to be removed
                        IsValid = false;
                }
            }
        }

        public override bool OnDeleteMissile(GameObject obj)
        {
            if (Missile != null && obj.Index == Missile.Index && !string.IsNullOrEmpty(OwnSpellData.ToggleParticleName))
            {
                _missileDeleted = true;
                return false;
            }

            return true;
        }

        public override void OnDeleteObject(GameObject obj)
        {
            if (Missile != null && _missileDeleted && !string.IsNullOrEmpty(OwnSpellData.ToggleParticleName))
            {
                var r = new Regex(OwnSpellData.ToggleParticleName);
                if (r.Match(obj.Name).Success && obj.Distance(EndPosition, true) <= 100 * 100)
                {
                    IsValid = false;
                }
            }
        }

        /// <summary>
        /// check if still valid
        /// </summary>
        public override void OnTick()
        {
            if (Missile == null)
            {
                if (Environment.TickCount > TimeDetected + OwnSpellData.Delay + 250)
                    IsValid = false;
            }
            else if (Missile != null)
            {
                if (Environment.TickCount > TimeDetected + 6000)
                    IsValid = false;
            }
        }

        public override void OnDraw()
        {
            if (!IsValid)
            {
                return;
            }

            if (Missile != null && !_missileDeleted)
                new Geometry.Polygon.Circle(EndPosition,
                    StartPosition.To2D().Distance(Missile.Position.To2D()) / (StartPosition.To2D().Distance(EndPosition.To2D())) * OwnSpellData.Radius).DrawPolygon(
                        Color.DodgerBlue);

            ToPolygon().DrawPolygon(Color.White);
        }

        public override Geometry.Polygon ToRealPolygon()
        {
            return ToPolygon();
        }

        public override Geometry.Polygon ToPolygon(float extrawidth = 0)
        {
            extrawidth = 20;
            if (OwnSpellData.AddHitbox)
            {
                extrawidth += Player.Instance.HitBoxRadius();
            }

            return new Geometry.Polygon.Circle(EndPosition, OwnSpellData.Radius + extrawidth);
        }

        public override int GetAvailableTime(Vector2 pos)
        {
            if (Missile == null)
            {
                return Math.Max(0, OwnSpellData.Delay - (Environment.TickCount - TimeDetected));
            }

            if (!_missileDeleted)
            {
                return (int) (Missile.Position.To2D().Distance(EndPosition.To2D()) / OwnSpellData.MissileSpeed * 1000);
            }

            return -1;
        }

        public override bool IsFromFow()
        {
            return Missile != null && !Missile.SpellCaster.IsVisible;
        }
    }
}