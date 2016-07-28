using System.Collections.Generic;
using EloBuddy;

namespace Moon_Walk_Evade.EvadeSpells
{
    class EvadeSpellDatabase
    {
        public static List<EvadeSpellData> Spells = new List<EvadeSpellData>();

        static EvadeSpellDatabase()
        {
            #region Ahri

            Spells.Add(
            new EvadeSpellData
            {
                ChampionName = "Ahri",
                DangerValue = 4,

                SpellName = "AhriTumble",
                Range = 500,
                Delay = 50,
                Speed = 1575,
                Slot = SpellSlot.R,
                EvadeType = EvadeType.Dash,
                CastType = CastType.Position
            });

            #endregion

            #region Akali

            //Spells.Add(
            //new EvadeSpellData
            //{
            //    ChampionName = "Akali",
            //    DangerValue = 4,

            //    SpellName = "AkaliSmokeBomb",
            //    Delay = 850,
            //    Slot = SpellSlot.W,
            //    speedArray = new[] { 20f, 40f, 60f, 80f, 100f },
            //    EvadeType = EvadeType.MovementSpeedBuff,
            //    CastType = CastType.EndPositionGetter
            //});

            #endregion

            #region Blitzcrank

            Spells.Add(
            new EvadeSpellData
            {
                ChampionName = "Blitzcrank",
                DangerValue = 3,

                SpellName = "Overdrive",
                Delay = 50,
                Slot = SpellSlot.W,
                speedArray = new[] { 70f, 75f, 80f, 85f, 90f },
                EvadeType = EvadeType.MovementSpeedBuff,
                CastType = CastType.Self
            });

            #endregion

            #region Caitlyn

            Spells.Add(
            new EvadeSpellData
            {
                ChampionName = "Caitlyn",
                DangerValue = 3,

                SpellName = "CaitlynEntrapment",
                Range = 490,
                Delay = 50,
                Speed = 1000,
                isReversed = true,
                fixedRange = true,
                Slot = SpellSlot.E,
                EvadeType = EvadeType.Dash,
                CastType = CastType.Position
            });

            #endregion

            #region Corki

            Spells.Add(
            new EvadeSpellData
            {
                ChampionName = "Corki",
                DangerValue = 3,

                SpellName = "CarpetBomb",
                Range = 790,
                Delay = 50,
                Speed = 975,
                Slot = SpellSlot.W,
                EvadeType = EvadeType.Dash,
                CastType = CastType.Position
            });

            #endregion

            #region Draven

            Spells.Add(
            new EvadeSpellData
            {
                ChampionName = "Draven",
                DangerValue = 3,

                SpellName = "DravenFury",
                Delay = 50,
                Slot = SpellSlot.W,
                speedArray = new[] { 40f, 45f, 50f, 55f, 60f },
                EvadeType = EvadeType.MovementSpeedBuff,
                CastType = CastType.Self
            });

            #endregion

            #region Ekko

            Spells.Add(
            new EvadeSpellData
            {
                ChampionName = "Ekko",
                DangerValue = 3,

                SpellName = "EkkoE",
                Range = 350,
                fixedRange = true,
                Delay = 50,
                Speed = 1150,
                Slot = SpellSlot.E,
                EvadeType = EvadeType.Dash,
                CastType = CastType.Position
            });

            Spells.Add(
            new EvadeSpellData
            {
                ChampionName = "Ekko",
                DangerValue = 3,

                SpellName = "EkkoEAttack",
                Range = 490,
                Delay = 250,
                infrontTarget = true,
                Slot = SpellSlot.Recall,
                EvadeType = EvadeType.Blink,
                CastType = CastType.Target,
                spellTargets = new[] { SpellTargets.EnemyChampions, SpellTargets.EnemyMinions },
                isSpecial = true
            });

            Spells.Add(
            new EvadeSpellData
            {
                ChampionName = "Ekko",
                DangerValue = 4,

                SpellName = "EkkoR",
                Range = 20000,
                Delay = 50,
                Slot = SpellSlot.R,
                EvadeType = EvadeType.Blink,
                CastType = CastType.Self,
                isSpecial = true
            });

            #endregion

            #region Evelynn

            Spells.Add(
            new EvadeSpellData
            {
                ChampionName = "Evelynn",
                DangerValue = 3,

                SpellName = "EvelynnW",
                Delay = 50,
                Slot = SpellSlot.W,
                speedArray = new[] { 30f, 45f, 50f, 60f, 70f },
                EvadeType = EvadeType.MovementSpeedBuff,
                CastType = CastType.Self
            });

            #endregion

            #region Ezreal

            Spells.Add(
            new EvadeSpellData
            {
                ChampionName = "Ezreal",
                DangerValue = 2,

                SpellName = "EzrealArcaneShift",
                Range = 450,
                Delay = 250,
                Slot = SpellSlot.E,
                EvadeType = EvadeType.Blink,
                CastType = CastType.Position
            });

            #endregion

            #region Fiora

            Spells.Add(
            new EvadeSpellData
            {
                ChampionName = "Fiora",
                DangerValue = 3,

                SpellName = "FioraW",
                Range = 750,
                Delay = 100,
                Slot = SpellSlot.W,
                EvadeType = EvadeType.WindWall,
                CastType = CastType.Position
            });

            Spells.Add(
            new EvadeSpellData
            {
                ChampionName = "Fiora",
                DangerValue = 3,

                SpellName = "FioraQ",
                Range = 340,
                fixedRange = true,
                Speed = 1100,
                Delay = 50,
                Slot = SpellSlot.Q,
                EvadeType = EvadeType.Dash,
                CastType = CastType.Position
            });

            #endregion

            #region Fizz

            Spells.Add(
            new EvadeSpellData
            {
                ChampionName = "Fizz",
                DangerValue = 3,

                SpellName = "FizzPiercingStrike",
                Range = 550,
                Speed = 1400,
                fixedRange = true,
                Delay = 50,
                Slot = SpellSlot.Q,
                EvadeType = EvadeType.Dash,
                CastType = CastType.Target,
                spellTargets = new[] { SpellTargets.EnemyMinions, SpellTargets.EnemyChampions }
            });

            Spells.Add(
            new EvadeSpellData
            {
                ChampionName = "Fizz",
                DangerValue = 3,

                SpellName = "FizzJump",
                Range = 400,
                Speed = 1400,
                fixedRange = true,
                Delay = 50,
                Slot = SpellSlot.E,
                EvadeType = EvadeType.Dash,
                CastType = CastType.Position,
                untargetable = true
            });

            #endregion

            #region Galio

            Spells.Add(
            new EvadeSpellData
            {
                ChampionName = "Galio",
                DangerValue = 4,

                SpellName = "GalioRighteousGust",
                Delay = 250,
                Slot = SpellSlot.E,
                speedArray = new[] { 30f, 35f, 40f, 45f, 50f },
                EvadeType = EvadeType.MovementSpeedBuff,
                CastType = CastType.Position
            });

            #endregion

            #region Garen

            Spells.Add(
            new EvadeSpellData
            {
                ChampionName = "Garen",
                DangerValue = 3,

                SpellName = "GarenQ",
                Delay = 50,
                Slot = SpellSlot.Q,
                speedArray = new[] { 35, 35f, 35f, 35f, 35f },
                EvadeType = EvadeType.MovementSpeedBuff,
                CastType = CastType.Self
            });

            #endregion

            #region Gragas

            Spells.Add(
            new EvadeSpellData
            {
                ChampionName = "Gragas",
                DangerValue = 2,

                SpellName = "GragasBodySlam",
                Range = 600,
                Delay = 50,
                Speed = 900,
                Slot = SpellSlot.E,
                EvadeType = EvadeType.Dash,
                CastType = CastType.Position
            });

            #endregion

            #region Gnar

            Spells.Add(
            new EvadeSpellData
            {
                ChampionName = "Gnar",
                DangerValue = 3,

                SpellName = "GnarE",
                Range = 475,
                Delay = 50,
                Speed = 900,
                checkSpellName = true,
                Slot = SpellSlot.E,
                EvadeType = EvadeType.Dash,
                CastType = CastType.Position
            });

            Spells.Add(
            new EvadeSpellData
            {
                ChampionName = "Gnar",
                DangerValue = 4,

                SpellName = "gnarbige",
                Range = 475,
                Delay = 50,
                Speed = 800,
                checkSpellName = true,
                Slot = SpellSlot.E,
                EvadeType = EvadeType.Dash,
                CastType = CastType.Position
            });

            #endregion

            #region Graves

            Spells.Add(
            new EvadeSpellData
            {
                ChampionName = "Graves",
                DangerValue = 2,

                SpellName = "GravesMove",
                Range = 425,
                Delay = 50,
                Speed = 1250,
                Slot = SpellSlot.E,
                EvadeType = EvadeType.Dash,
                CastType = CastType.Position
            });

            #endregion

            #region Karma

            Spells.Add(
            new EvadeSpellData
            {
                ChampionName = "Karma",
                DangerValue = 3,

                SpellName = "KarmaSolkimShield",
                Delay = 50,
                Slot = SpellSlot.E,
                speedArray = new[] { 40f, 45f, 50f, 55f, 60f },
                EvadeType = EvadeType.MovementSpeedBuff,
                CastType = CastType.Target
            });

            #endregion

            #region Kassadin

            Spells.Add(
            new EvadeSpellData
            {
                ChampionName = "Kassadin",
                DangerValue = 1,

                Range = 450,
                Delay = 250,
                Slot = SpellSlot.R,
                EvadeType = EvadeType.Blink,
                CastType = CastType.Position
            });

            #endregion

            #region Katarina

            Spells.Add(
            new EvadeSpellData
            {
                ChampionName = "Katarina",
                DangerValue = 3,

                SpellName = "KatarinaE",
                Range = 700,
                Speed = float.MaxValue,
                Delay = 50,
                Slot = SpellSlot.E,
                EvadeType = EvadeType.Blink, //behind target
                CastType = CastType.Target,
                spellTargets = new[] { SpellTargets.Targetables }
            });

            #endregion

            #region Kayle

            Spells.Add(
            new EvadeSpellData
            {
                ChampionName = "Kayle",
                DangerValue = 3,

                SpellName = "JudicatorDivineBlessing",
                Delay = 50,
                Slot = SpellSlot.W,
                speedArray = new[] { 18f, 21f, 24f, 27f, 30f },
                EvadeType = EvadeType.MovementSpeedBuff,
                CastType = CastType.Target
            });

            Spells.Add(
            new EvadeSpellData
            {
                ChampionName = "Kayle",
                DangerValue = 4,

                SpellName = "JudicatorIntervention",
                Delay = 250,
                Slot = SpellSlot.R,
                EvadeType = EvadeType.SpellShield, //Invulnerability
                CastType = CastType.Target,
                spellTargets = new[] { SpellTargets.AllyChampions }
            });

            #endregion

            #region Kennen

            Spells.Add(
            new EvadeSpellData
            {
                ChampionName = "Kennen",
                DangerValue = 4,

                SpellName = "KennenLightningRush",
                Delay = 50,
                Slot = SpellSlot.E,
                speedArray = new[] { 100f, 100f, 100f, 100f, 100f },
                EvadeType = EvadeType.MovementSpeedBuff,
                CastType = CastType.Self
            });

            #endregion

            #region Kindred

            Spells.Add(
            new EvadeSpellData
            {
                ChampionName = "Kindred",
                DangerValue = 1,

                SpellName = "KindredQ",
                Range = 300,
                fixedRange = true,
                Speed = 733,
                Delay = 50,
                Slot = SpellSlot.Q,
                EvadeType = EvadeType.Dash,
                CastType = CastType.Position
            });

            #endregion

            #region Leblanc

            Spells.Add(
            new EvadeSpellData
            {
                ChampionName = "Leblanc",
                DangerValue = 2,

                SpellName = "LeblancSlide",
                Range = 600,
                Delay = 50,
                Speed = 1600,
                Slot = SpellSlot.W,
                EvadeType = EvadeType.Dash,
                CastType = CastType.Position
            });

            Spells.Add(
            new EvadeSpellData
            {
                ChampionName = "Leblanc",
                DangerValue = 2,

                SpellName = "LeblancSlideM",
                checkSpellName = true,
                Range = 600,
                Delay = 50,
                Speed = 1600,
                Slot = SpellSlot.R,
                EvadeType = EvadeType.Dash,
                CastType = CastType.Position
            });

            #endregion

            #region LeeSin

            Spells.Add(
            new EvadeSpellData
            {
                ChampionName = "LeeSin",
                DangerValue = 3,

                SpellName = "BlindMonkWOne",
                Range = 700,
                Speed = 1400,
                Delay = 50,
                Slot = SpellSlot.W,
                EvadeType = EvadeType.Dash,
                CastType = CastType.Target,
                spellTargets = new[] { SpellTargets.AllyChampions, SpellTargets.AllyMinions }
            });

            #endregion

            #region Lucian

            Spells.Add(
            new EvadeSpellData
            {
                ChampionName = "Lucian",
                DangerValue = 1,

                SpellName = "LucianE",
                Range = 425,
                Delay = 50,
                Speed = 1350,
                Slot = SpellSlot.E,
                EvadeType = EvadeType.Dash,
                CastType = CastType.Position
            });

            #endregion

            #region Lulu

            Spells.Add(
            new EvadeSpellData
            {
                ChampionName = "Lulu",
                DangerValue = 3,

                SpellName = "LuluW",
                Delay = 50,
                Slot = SpellSlot.W,
                speedArray = new[] { 30f, 30f, 30f, 35f, 40f },
                EvadeType = EvadeType.MovementSpeedBuff,
                CastType = CastType.Target
            });

            #endregion

            #region MasterYi

            Spells.Add(
            new EvadeSpellData
            {
                ChampionName = "MasterYi",
                DangerValue = 3,

                SpellName = "AlphaStrike",
                Range = 600,
                Speed = float.MaxValue,
                Delay = 100,
                Slot = SpellSlot.Q,
                EvadeType = EvadeType.Blink,
                CastType = CastType.Target,
                spellTargets = new[] { SpellTargets.EnemyChampions, SpellTargets.EnemyMinions },
                untargetable = true
            });

            #endregion

            #region Morgana

            Spells.Add(
            new EvadeSpellData
            {
                ChampionName = "Morgana",
                DangerValue = 3,

                SpellName = "BlackShield",
                Delay = 50,
                Slot = SpellSlot.E,
                EvadeType = EvadeType.SpellShield,
                CastType = CastType.Target,
                spellTargets = new[] { SpellTargets.AllyChampions }
            });

            #endregion

            #region Nocturne

            Spells.Add(
            new EvadeSpellData
            {
                ChampionName = "Nocturne",
                DangerValue = 3,

                SpellName = "NocturneShroudofDarkness",
                Delay = 50,
                Slot = SpellSlot.W,
                EvadeType = EvadeType.SpellShield,
                CastType = CastType.Self
            });

            #endregion

            #region Nunu

            Spells.Add(
            new EvadeSpellData
            {
                ChampionName = "Nunu",
                DangerValue = 2,

                SpellName = "BloodBoil",
                Delay = 50,
                Slot = SpellSlot.W,
                speedArray = new[] { 8f, 9f, 10f, 11f, 12f },
                EvadeType = EvadeType.MovementSpeedBuff,
                CastType = CastType.Target
            });

            #endregion

            #region Nidalee

            Spells.Add(
            new EvadeSpellData
            {
                ChampionName = "Nidalee",
                DangerValue = 4,

                SpellName = "Pounce",
                Range = 375,
                Delay = 150,
                Speed = 1750,
                Slot = SpellSlot.W,
                EvadeType = EvadeType.Dash,
                CastType = CastType.Position,
                isSpecial = true
            });

            #endregion

            #region Poppy

            Spells.Add(
            new EvadeSpellData
            {
                ChampionName = "Poppy",
                DangerValue = 3,

                SpellName = "PoppyW",
                Delay = 50,
                Slot = SpellSlot.W,
                speedArray = new[] { 27f, 29f, 31f, 33f, 35f },
                EvadeType = EvadeType.MovementSpeedBuff,
                CastType = CastType.Self
            });

            #endregion

            #region Riven

            Spells.Add(
            new EvadeSpellData
            {
                ChampionName = "Riven",
                DangerValue = 1,

                SpellName = "RivenTriCleave",
                Range = 260,
                fixedRange = true,
                Delay = 50,
                Speed = 560,
                Slot = SpellSlot.Q,
                EvadeType = EvadeType.Dash,
                CastType = CastType.Position,
                isSpecial = true
            });

            Spells.Add(
            new EvadeSpellData
            {
                ChampionName = "Riven",
                DangerValue = 1,

                SpellName = "RivenFeint",
                Range = 325,
                fixedRange = true,
                Delay = 50,
                Speed = 1200,
                Slot = SpellSlot.E,
                EvadeType = EvadeType.Dash,
                CastType = CastType.Position
            });

            #endregion

            #region Rumble

            Spells.Add(
            new EvadeSpellData
            {
                ChampionName = "Rumble",
                DangerValue = 3,

                SpellName = "RumbleShield",
                Delay = 50,
                Slot = SpellSlot.W,
                speedArray = new[] { 10f, 15f, 20f, 25f, 30f },
                EvadeType = EvadeType.MovementSpeedBuff,
                CastType = CastType.Self
            });

            #endregion

            #region Sivir

            Spells.Add(
            new EvadeSpellData
            {
                ChampionName = "Sivir",
                DangerValue = 4,

                SpellName = "SivirR",
                Delay = 250,
                Slot = SpellSlot.R,
                speedArray = new[] { 60f, 60f, 60f, 60f, 60f },
                EvadeType = EvadeType.MovementSpeedBuff,
                CastType = CastType.Self
            });

            Spells.Add(
            new EvadeSpellData
            {
                ChampionName = "Sivir",
                DangerValue = 2,

                SpellName = "SivirE",
                Delay = 50,
                Slot = SpellSlot.E,
                EvadeType = EvadeType.SpellShield,
                CastType = CastType.Self
            });

            #endregion

            #region Skarner

            Spells.Add(
            new EvadeSpellData
            {
                ChampionName = "Skarner",
                DangerValue = 3,

                SpellName = "SkarnerExoskeleton",
                Delay = 50,
                Slot = SpellSlot.W,
                speedArray = new[] { 16f, 20f, 24f, 28f, 32f },
                EvadeType = EvadeType.MovementSpeedBuff,
                CastType = CastType.Self
            });

            #endregion

            #region Shyvana

            Spells.Add(
            new EvadeSpellData
            {
                ChampionName = "Shyvana",
                DangerValue = 3,

                SpellName = "ShyvanaImmolationAura",
                Delay = 50,
                Slot = SpellSlot.W,
                speedArray = new[] { 30f, 35f, 40f, 45f, 50f },
                EvadeType = EvadeType.MovementSpeedBuff,
                CastType = CastType.Self
            });

            #endregion

            #region Shaco

            Spells.Add(
            new EvadeSpellData
            {
                ChampionName = "Shaco",
                DangerValue = 3,

                SpellName = "Deceive",
                Range = 400,
                Delay = 250,
                Slot = SpellSlot.Q,
                EvadeType = EvadeType.Blink,
                CastType = CastType.Position
            });

            /*Spells.Add(
            new EvadeSpellData
            {
                ChampionName = "Shaco",
                DangerValue = 3,

                SpellName = "JackInTheBox",
                Range = 425,
                Delay = 250,
                Slot = SpellSlot.W,
                EvadeType = EvadeType.WindWall,
                CastType = CastType.EndPositionGetter,
            });*/

            #endregion

            #region Sona

            Spells.Add(
            new EvadeSpellData
            {
                ChampionName = "Sona",
                DangerValue = 3,

                SpellName = "SonaW",
                Delay = 50,
                Slot = SpellSlot.E,
                speedArray = new[] { 13f, 14f, 15f, 16f, 25f },
                EvadeType = EvadeType.MovementSpeedBuff,
                CastType = CastType.Self
            });

            #endregion

            #region Talon

            Spells.Add(
            new EvadeSpellData
            {
                ChampionName = "Talon",
                DangerValue = 3,

                SpellName = "TalonCutthroat",
                Range = 700,
                Speed = float.MaxValue,
                Delay = 50,
                Slot = SpellSlot.E,
                EvadeType = EvadeType.Blink, //behind target
                CastType = CastType.Target,
                spellTargets = new[] { SpellTargets.EnemyChampions, SpellTargets.EnemyMinions }
            });


            Spells.Add(
            new EvadeSpellData
            {
                ChampionName = "Talon",
                DangerValue = 4,

                SpellName = "TalonShadowAssault",
                Delay = 50,
                Slot = SpellSlot.R,
                speedArray = new[] { 40f, 40f, 40f, 40f, 40f },
                EvadeType = EvadeType.MovementSpeedBuff,
                CastType = CastType.Self
            });

            #endregion

            #region Teemo

            Spells.Add(
            new EvadeSpellData
            {
                ChampionName = "Teemo",
                DangerValue = 3,

                SpellName = "MoveQuick",
                Delay = 50,
                Slot = SpellSlot.W,
                speedArray = new[] { 10f, 14f, 18f, 22f, 26f },
                EvadeType = EvadeType.MovementSpeedBuff,
                CastType = CastType.Self
            });

            #endregion

            #region Trundle
            Spells.Add(
            new EvadeSpellData
            {
                ChampionName = "Trundle",
                DangerValue = 4,

                SpellName = "TrundleW",
                Delay = 50,
                Slot = SpellSlot.W,
                speedArray = new[] { 20f, 25f, 30f, 35f, 40f },
                EvadeType = EvadeType.MovementSpeedBuff,
                CastType = CastType.Position
            });

            #endregion

            #region Tristana

            Spells.Add(
            new EvadeSpellData
            {
                ChampionName = "Tristana",
                DangerValue = 3,

                SpellName = "RocketJump",
                Range = 900,
                Delay = 500,
                Speed = 1100,
                Slot = SpellSlot.W,
                EvadeType = EvadeType.Dash,
                CastType = CastType.Position
            });

            #endregion

            #region Tryndamare

            Spells.Add(
            new EvadeSpellData
            {
                ChampionName = "Tryndamare",
                DangerValue = 3,

                SpellName = "Slash",
                Range = 660,
                Delay = 50,
                Speed = 900,
                Slot = SpellSlot.E,
                EvadeType = EvadeType.Dash,
                CastType = CastType.Position
            });

            #endregion

            #region Udyr

            Spells.Add(
            new EvadeSpellData
            {
                ChampionName = "Udyr",
                DangerValue = 3,

                SpellName = "UdyrBearStance",
                Delay = 50,
                Slot = SpellSlot.E,
                speedArray = new[] { 15f, 20f, 25f, 30f, 35f },
                EvadeType = EvadeType.MovementSpeedBuff,
                CastType = CastType.Self
            });

            #endregion

            #region Vayne

            Spells.Add(
            new EvadeSpellData
            {
                ChampionName = "Vayne",
                DangerValue = 1,

                SpellName = "VayneTumble",
                Range = 300,
                fixedRange = true,
                Speed = 900,
                Delay = 50,
                Slot = SpellSlot.Q,
                EvadeType = EvadeType.Dash,
                CastType = CastType.Position
            });

            #endregion

            #region Yasuo

            Spells.Add(
            new EvadeSpellData
            {
                ChampionName = "Yasuo",
                DangerValue = 2,

                SpellName = "YasuoDashWrapper",
                Range = 475,
                fixedRange = true,
                Speed = 1000,
                Delay = 50,
                Slot = SpellSlot.E,
                EvadeType = EvadeType.Dash,
                CastType = CastType.Target,
                spellTargets = new[] { SpellTargets.EnemyChampions, SpellTargets.EnemyMinions }
            });

            //Spells.Add(
            //new EvadeSpellData
            //{
            //    ChampionName = "Yasuo",
            //    DangerValue = 3,

            //    SpellName = "YasuoWMovingWall",
            //    Range = 400,
            //    Delay = 250,
            //    Slot = SpellSlot.W,
            //    EvadeType = EvadeType.WindWall,
            //    CastType = CastType.Position
            //});

            #endregion

            #region Zillean

            Spells.Add(
            new EvadeSpellData
            {
                ChampionName = "Zilean",
                DangerValue = 3,

                SpellName = "ZileanE",
                Delay = 50,
                Slot = SpellSlot.E,
                speedArray = new[] { 40f, 55f, 70f, 85f, 99f },
                EvadeType = EvadeType.MovementSpeedBuff,
                CastType = CastType.Target
            });

            #endregion

            #region AllChampions

            Spells.Add(
            new EvadeSpellData
            {
                ChampionName = "AllChampions",
                DangerValue = 4,

                SpellName = "TalismanOfAscension",
                Delay = 250,
                Slot = SpellSlot.Q,
                EvadeType = EvadeType.MovementSpeedBuff,
                speedArray = new[] { 40f, 40f, 40f, 40f, 40f },
                CastType = CastType.Self,
                isItem = true,
                itemID = ItemId.Talisman_of_Ascension
            });

            Spells.Add(
            new EvadeSpellData
            {
                ChampionName = "AllChampions",
                DangerValue = 4,

                SpellName = "YoumuusGhostblade",
                Delay = 250,
                Slot = SpellSlot.Q,
                EvadeType = EvadeType.MovementSpeedBuff,
                speedArray = new[] { 20f, 20f, 20f, 20f, 20f },
                CastType = CastType.Self,
                isItem = true,
                itemID = ItemId.Youmuus_Ghostblade
            });

            Spells.Add(
            new EvadeSpellData
            {
                ChampionName = "AllChampions",
                DangerValue = 4,

                SpellName = "SummonerFlash",
                Range = 400,
                fixedRange = true, //test
                Delay = 50,
                isSummonerSpell = true,
                Slot = SpellSlot.R,
                EvadeType = EvadeType.Blink,
                CastType = CastType.Position
            });

            Spells.Add(
            new EvadeSpellData
            {
                ChampionName = "AllChampions",
                DangerValue = 4,

                SpellName = "ZhonyasHourglass",
                Delay = 50,
                Slot = SpellSlot.Q,
                EvadeType = EvadeType.SpellShield, //Invulnerability
                CastType = CastType.Self,
                isItem = true,
                itemID = ItemId.Zhonyas_Hourglass
            });

            Spells.Add(
            new EvadeSpellData
            {
                ChampionName = "AllChampions",
                DangerValue = 4,

                SpellName = "Witchcap",
                Delay = 50,
                Slot = SpellSlot.Q,
                EvadeType = EvadeType.SpellShield, //Invulnerability
                CastType = CastType.Self,
                isItem = true,
                itemID = ItemId.Wooglets_Witchcap
            });

            #endregion AllChampions
        }
    }
}
