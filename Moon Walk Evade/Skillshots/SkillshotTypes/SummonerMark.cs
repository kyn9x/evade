using System;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using Moon_Walk_Evade.Utils;
using SharpDX;
using Color = System.Drawing.Color;

namespace Moon_Walk_Evade.Skillshots.SkillshotTypes
{
    public class SummonerMark : EvadeSkillshot
    {
        public SummonerMark()
        {
            Caster = null;
            SpawnObject = null;
            SData = null;
            OwnSpellData = null;
            Team = GameObjectTeam.Unknown;
            IsValid = true;
            TimeDetected = Environment.TickCount;
        }

        private Vector3 _castStartPos;
        private Vector3 _castEndPos;
        private Vector3 _endPos;

        public Vector3 StartPosition
        {
            get
            {
                if (SpawnObject == null)
                {
                    return _castStartPos;
                }
                return SpawnObject.Position;
            }
        }

        public Vector3 EndPosition
        {
            get
            {
                if (SpawnObject == null)
                {
                    return _castEndPos;
                }
                return _endPos;
            }
        }

        public override Vector3 GetPosition()
        {
            return StartPosition;
        }

        public override EvadeSkillshot NewInstance(bool debug = false)
        {
            var newInstance = new SummonerMark {OwnSpellData = OwnSpellData};
            return newInstance;
        }

        public override void OnCreate(GameObject obj)
        {
            if (obj == null)
            {
                _castStartPos = Caster.Position;
                _castEndPos = _castStartPos.ExtendVector3(CastArgs.End, OwnSpellData.Range);
            }
        }

        public override void OnCreateObject(GameObject obj)
        {
            var minion = obj as Obj_AI_Minion;

            if (SpawnObject == null && minion != null)
            {
                if (minion.BaseSkinName == OwnSpellData.ObjectCreationName)
                {
                    // Force skillshot to be removed
                    IsValid = false;
                }
            }

            if (SpawnObject != null)
            {
                if (Utils.Utils.GetGameObjectName(obj) == OwnSpellData.ToggleParticleName &&
                    obj.Distance(SpawnObject, true) <= 300.Pow())
                {
                    IsValid = false;
                }
            }
        }

        public override void OnTick()
        {
            if (SpawnObject == null)
            {
                if (Environment.TickCount > TimeDetected + OwnSpellData.Delay + 50)
                    IsValid = false;
            }
            else
            {
                //_endPos = (SpawnObject as Obj_AI_Minion).Path.LastOrDefault();

                if (Environment.TickCount > TimeDetected + 9000)
                    IsValid = false;
            }
        }

        public override void OnDraw()
        {
            if (!IsValid)
            {
                return;
            }

            Utils.Utils.Draw3DRect(StartPosition, EndPosition, OwnSpellData.Radius*2, Color.White);
        }

        public override Geometry.Polygon ToRealPolygon()
        {
            var halfWidth = OwnSpellData.Radius * 2 / 2;
            var d1 = StartPosition.To2D();
            var d2 = EndPosition.To2D();
            var direction = (d1 - d2).Perpendicular().Normalized();

            Vector3[] points =
            {
                (d1 + direction*halfWidth).To3DPlayer(),
                (d1 - direction*halfWidth).To3DPlayer(),
                (d2 - direction*halfWidth).To3DPlayer(),
                (d2 + direction*halfWidth).To3DPlayer()
            };
            var p = new Geometry.Polygon();
            p.Points.AddRange(points.Select(x => x.To2D()).ToList());

            return p;
        }

        public override Geometry.Polygon ToPolygon(float extrawidth = 0)
        {
            if (OwnSpellData.AddHitbox)
                extrawidth += Player.Instance.BoundingRadius;

            return new Geometry.Polygon.Rectangle(StartPosition, EndPosition.ExtendVector3(StartPosition, -extrawidth),
                OwnSpellData.Radius*2 + extrawidth);
        }

        public override int GetAvailableTime(Vector2 pos)
        {
            var dist1 =
                Math.Abs((EndPosition.Y - StartPosition.Y) * pos.X - (EndPosition.X - StartPosition.X) * pos.Y +
                         EndPosition.X * StartPosition.Y - EndPosition.Y * StartPosition.X) / (StartPosition.Distance(EndPosition));

            var actualDist = Math.Sqrt(StartPosition.Distance(pos).Pow() - dist1.Pow());

            var time = OwnSpellData.MissileSpeed > 0 ? (int)((actualDist / OwnSpellData.MissileSpeed) * 1000) : 0;

            if (SpawnObject == null)
            {
                time += Math.Max(0, OwnSpellData.Delay - (Environment.TickCount - TimeDetected));
            }

            return time;
        }

        public override bool IsFromFow()
        {
            return SpawnObject != null && !SpawnObject.IsVisible;
        }
    }
}