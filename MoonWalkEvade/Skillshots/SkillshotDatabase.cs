using System.Collections.Generic;
using EloBuddy;
using MoonWalkEvade.Skillshots.SkillshotTypes;

namespace MoonWalkEvade.Skillshots
{
    internal static class SkillshotDatabase
    {
        public static readonly List<EvadeSkillshot> Database;

        static SkillshotDatabase()
        {
            Database = new List<EvadeSkillshot>
            {
                new SummonerMark
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Mark",
                        ChampionName = "AllChampions",
                        SpellName = "summonersnowball",
                        Slot = SpellSlot.Summoner1,
                        Delay = 0,
                        Range = 1600,
                        Radius = 60,
                        MissileSpeed = 1300,
                        DangerValue = 1,
                        IsDangerous = true,
                        ObjectCreationName = "disabled/TestCubeRender",
                        ToggleParticleName = "Summoner_Snowball_Explosion_Sound.troy"
                    }
                },
                new CircularSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Dark Flight",
                        ChampionName = "Aatrox",
                        SpellName = "AatroxQ",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 650,
                        Radius = 285,
                        MissileSpeed = 450,
                        DangerValue = 3,
                        IsDangerous = true,
                        ObjectCreationName = "AatroxQ"
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Blades of Torment",
                        ChampionName = "Aatrox",
                        SpellName = "AatroxE",
                        Slot = SpellSlot.E,
                        Delay = 250,
                        Range = 1075,
                        Radius = 100,
                        MissileSpeed = 1200,
                        DangerValue = 3,
                        IsDangerous = false,
                        ObjectCreationName = "AatroxE"
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Orb of Deception",
                        ChampionName = "Ahri",
                        SpellName = "AhriOrbofDeception",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 925,
                        Radius = 100,
                        MissileSpeed = 1750,
                        DangerValue = 2,
                        IsDangerous = false,
                        ObjectCreationName = "AhriOrbMissile"
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Charm",
                        ChampionName = "Ahri",
                        SpellName = "AhriSeduce",
                        Slot = SpellSlot.E,
                        Delay = 250,
                        Range = 1000,
                        Radius = 60,
                        MissileSpeed = 1550,
                        DangerValue = 3,
                        IsDangerous = true,
                        ObjectCreationName = "AhriSeduceMissile"
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Orb of Deception - Back",
                        ChampionName = "Ahri",
                        SpellName = "AhriOrbofDeception2",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 925,
                        Radius = 100,
                        MissileSpeed = 915,
                        DangerValue = 2,
                        IsDangerous = false,
                        ObjectCreationName = "AhriOrbofDeception2"
                    }
                },
                new CircularSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Pulverize",
                        ChampionName = "Alistar",
                        SpellName = "Pulverize",
                        Slot = SpellSlot.Q,
                        Delay = 0,
                        Range = 365,
                        Radius = 365,
                        MissileSpeed = 0,
                        DangerValue = 2,
                        IsDangerous = true,
                        ObjectCreationName = "Pulverize"
                    }
                },
                new CircularSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Curse of the Sad Mummy",
                        ChampionName = "Amumu",
                        SpellName = "CurseoftheSadMummy",
                        Slot = SpellSlot.R,
                        Delay = 250,
                        Range = 560,
                        Radius = 560,
                        MissileSpeed = 0,
                        DangerValue = 5,
                        ObjectCreationName = "CurseoftheSadMummy",
                        IsDangerous = true
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Bandage Toss",
                        ChampionName = "Amumu",
                        SpellName = "BandageToss",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 1100,
                        Radius = 80,
                        MissileSpeed = 2000,
                        DangerValue = 3,
                        IsDangerous = true,
                        ObjectCreationName = "SadMummyBandageToss",
                        MinionCollision = true
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Flash Frost",
                        ChampionName = "Anivia",
                        SpellName = "FlashFrostSpell",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 1250,
                        Radius = 110,
                        MissileSpeed = 850,
                        DangerValue = 3,
                        IsDangerous = true,
                        ObjectCreationName = "FlashFrostSpell"
                    }
                },
                //new CircularSkillshot
                //{
                //    OwnSpellData = new OwnSpellData
                //    {
                //        ChampionName = "Annie",
                //        SpellName = "Incinerate",
                //        Slot = SpellSlot.W,
                //        Delay = 250,
                //        Range = 625,
                //        Radius = 80,
                //        MissileSpeed = 0,
                //        DangerValue = 2,
                //        IsDangerous = false,
                //        ObjectCreationName = "Incinerate"
                //    }
                //},
                new CircularSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Summon: Tibbers",
                        ChampionName = "Annie",
                        SpellName = "InfernalGuardian",
                        Slot = SpellSlot.R,
                        Delay = 250,
                        Range = 600,
                        Radius = 290,
                        MissileSpeed = 0,
                        DangerValue = 5,
                        IsDangerous = true,
                        ObjectCreationName = "InfernalGuardian"
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Enchanted Crystal Arrow",
                        ChampionName = "Ashe",
                        SpellName = "EnchantedCrystalArrow",
                        Slot = SpellSlot.R,
                        Delay = 250,
                        Range = 12500,
                        Radius = 130,
                        MissileSpeed = 1600,
                        DangerValue = 5,
                        IsDangerous = true,
                        ObjectCreationName = "EnchantedCrystalArrow"
                    }
                },
                new AsheW
                {
                    OwnSpellData = new SpellData
                    {
                        ChampionName = "Ashe",
                        SpellName = "Volley",
                        Slot = SpellSlot.W,
                        Delay = 250,
                        Range = 1400,
                        Radius = 20,
                        MissileSpeed = 1500,
                        DangerValue = 1,
                        ObjectCreationName = "",
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Conquering Sands",
                        ChampionName = "Azir",
                        SpellName = "AzirQ",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 850,
                        Radius = 80,
                        MissileSpeed = 1000,
                        DangerValue = 2,
                        IsDangerous = false,
                        ObjectCreationName = "AzirSoldierMissile",
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Cosmic Binding",
                        ChampionName = "Bard",
                        SpellName = "BardQ",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 950,
                        Radius = 60,
                        MissileSpeed = 1600,
                        DangerValue = 3,
                        IsDangerous = true,
                        ObjectCreationName = "BardQMissile"
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Rocket Grab",
                        ChampionName = "Blitzcrank",
                        SpellName = "RocketGrab",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 1050,
                        Radius = 70,
                        MissileSpeed = 1800,
                        DangerValue = 4,
                        IsDangerous = true,
                        ObjectCreationName = "RocketGrabMissile",
                        MinionCollision = true
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Sear",
                        ChampionName = "Brand",
                        SpellName = "BrandQ",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 1100,
                        Radius = 60,
                        MissileSpeed = 1600,
                        DangerValue = 3,
                        IsDangerous = true,
                        ObjectCreationName = "BrandQMissile",
                        MinionCollision = true
                    }
                },
                new CircularSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Pillar of Flame",
                        ChampionName = "Brand",
                        SpellName = "BrandW",
                        Slot = SpellSlot.W,
                        Delay = 850,
                        Range = 1100,
                        Radius = 250,
                        MissileSpeed = 0,
                        DangerValue = 2,
                        IsDangerous = false,
                        ObjectCreationName = "BrandFissure"
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Glacial Fissure",
                        ChampionName = "Braum",
                        SpellName = "BraumRWrapper",
                        Slot = SpellSlot.R,
                        Delay = 500,
                        Range = 1250,
                        Radius = 100,
                        MissileSpeed = 1125,
                        DangerValue = 4,
                        IsDangerous = true,
                        ObjectCreationName = "braumrmissile"
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Winter's Bite",
                        ChampionName = "Braum",
                        SpellName = "BraumQ",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 1000,
                        Radius = 100,
                        MissileSpeed = 1200,
                        DangerValue = 3,
                        IsDangerous = true,
                        ObjectCreationName = "BraumQMissile",
                        MinionCollision = true
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Piltover Peacemaker",
                        ChampionName = "Caitlyn",
                        SpellName = "CaitlynPiltoverPeacemaker",
                        Slot = SpellSlot.Q,
                        Delay = 625,
                        Range = 1300,
                        Radius = 90,
                        MissileSpeed = 2200,
                        DangerValue = 2,
                        IsDangerous = false,
                        ObjectCreationName = "CaitlynPiltoverPeacemaker"
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "90 Caliber Net",
                        ChampionName = "Caitlyn",
                        SpellName = "CaitlynEntrapment",
                        Slot = SpellSlot.E,
                        Delay = 125,
                        Range = 950,
                        Radius = 80,
                        MissileSpeed = 2000,
                        DangerValue = 1,
                        IsDangerous = false,
                        ObjectCreationName = "CaitlynEntrapmentMissile",
                        MinionCollision = true
                    }
                },
                new CaitlynTrap
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Yordle Trap",
                        ChampionName = "Caitlyn",
                        SpellName = "CaitlynYordleTrap",
                        Slot = SpellSlot.W,
                        Delay = 1500,
                        Range = 800,
                        Radius = 70,
                        MissileSpeed = 0,
                        DangerValue = 2,
                        IsDangerous = false,
                        ObjectCreationName = "CaitlynTrap",
                    }
                },
                new ConeSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        ChampionName = "Cassiopeia",
                        SpellName = "CassiopeiaPetrifyingGaze",
                        Slot = SpellSlot.R,
                        Delay = 500,
                        Range = 825,
                        Radius = 20,
                        MissileSpeed = 0,
                        DangerValue = 5,
                        ObjectCreationName = "CassiopeiaPetrifyingGaze",
                        ConeAngle = 60
                    }
                },
                new CircularSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Noxious Blast",
                        ChampionName = "Cassiopeia",
                        SpellName = "CassiopeiaQ",
                        Slot = SpellSlot.Q,
                        Delay = 400,
                        Range = 600,
                        Radius = 200,
                        MissileSpeed = 0,
                        DangerValue = 2,
                        IsDangerous = false,
                        ObjectCreationName = "CassiopeiaQ"
                    }
                },
                new MultiCircleSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Miasma",
                        ChampionName = "Cassiopeia",
                        SpellName = "CassiopeiaW",
                        Slot = SpellSlot.W,
                        Delay = 350,
                        Range = 800,
                        Radius = 170,
                        MissileSpeed = 0,
                        DangerValue = 3,
                        ObjectCreationName = "CassiopeiaWMissile",
                    }
                },
                //new CircularSkillshot
                //{
                //    OwnSpellData = new OwnSpellData
                //    {
                //        ChampionName = "Chogath",
                //        SpellName = "FeralScream",
                //        Slot = SpellSlot.W,
                //        Delay = 250,
                //        Range = 650,
                //        Radius = 20,
                //        MissileSpeed = 0,
                //        DangerValue = 3,
                //        ObjectCreationName = "FeralScream"
                //    }
                //},
                new CircularSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Rupture",
                        ChampionName = "Chogath",
                        SpellName = "Rupture",
                        Slot = SpellSlot.Q,
                        Delay = 1200,
                        Range = 950,
                        Radius = 250,
                        MissileSpeed = 0,
                        DangerValue = 3,
                        IsDangerous = false,
                        ObjectCreationName = "Rupture"
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Missile Barrage Big",
                        ChampionName = "Corki",
                        SpellName = "MissileBarrage2",
                        Slot = SpellSlot.R,
                        Delay = 175,
                        Range = 1500,
                        Radius = 40,
                        MissileSpeed = 2000,
                        DangerValue = 3,
                        IsDangerous = false,
                        ObjectCreationName = "MissileBarrageMissile2",
                        MinionCollision = true
                    }
                },
                new CircularSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Phosphorus Bomb",
                        ChampionName = "Corki",
                        SpellName = "PhosphorusBomb",
                        Slot = SpellSlot.Q,
                        Delay = 500,
                        Range = 825,
                        Radius = 270,
                        MissileSpeed = 1125,
                        DangerValue = 2,
                        IsDangerous = false,
                        ObjectCreationName = "PhosphorusBombMissile"
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        ChampionName = "Corki",
                        SpellName = "MissileBarrage",
                        Slot = SpellSlot.R,
                        Delay = 175,
                        Range = 1300,
                        Radius = 40,
                        MissileSpeed = 2000,
                        DangerValue = 2,
                        IsDangerous = false,
                        ObjectCreationName = "MissileBarrageMissile",
                        MinionCollision = true
                    }
                },
                new ConeSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        ChampionName = "Darius",
                        DisplayName = "Axe Cone Grab",
                        SpellName = "DariusAxeGrabCone",
                        Range = 570,
                        Delay = 320,
                        Slot = SpellSlot.E,
                        ObjectCreationName = "DariusAxeGrabCone",
                        ConeAngle = 50
                    }
                },
                //new CircularSkillshot //Unknown:SpellType.Arc
                //{
                //    OwnSpellData = new OwnSpellData
                //    {
                //        ChampionName = "Diana",
                //        SpellName = "DianaArc",
                //        Slot = SpellSlot.Q,
                //        Delay = 250,
                //        Range = 850,
                //        Radius = 50,
                //        MissileSpeed = 1400,
                //        DangerValue = 3,
                //        ObjectCreationName = "DianaArc"
                //    }
                //},
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Infected Cleaver",
                        ChampionName = "DrMundo",
                        SpellName = "InfectedCleaverMissileCast",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 1050,
                        Radius = 60,
                        MissileSpeed = 2000,
                        DangerValue = 3,
                        IsDangerous = false,
                        ObjectCreationName = "InfectedCleaverMissile",
                        MinionCollision = true
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Whirling Death",
                        ChampionName = "Draven",
                        SpellName = "DravenRCast",
                        Slot = SpellSlot.R,
                        Delay = 500,
                        Range = 12500,
                        Radius = 160,
                        MissileSpeed = 2000,
                        DangerValue = 5,
                        IsDangerous = true,
                        ObjectCreationName = "DravenR"
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Stand Aside",
                        ChampionName = "Draven",
                        SpellName = "DravenDoubleShot",
                        Slot = SpellSlot.E,
                        Delay = 250,
                        Range = 1100,
                        Radius = 130,
                        MissileSpeed = 1400,
                        DangerValue = 3,
                        IsDangerous = true,
                        ObjectCreationName = "DravenDoubleShotMissile"
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Timewinder",
                        ChampionName = "Ekko",
                        SpellName = "EkkoQ",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 950,
                        Radius = 60,
                        MissileSpeed = 1650,
                        DangerValue = 4,
                        IsDangerous = true,
                        ObjectCreationName = "ekkoqmis"
                    }
                },
                new CircularSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Parallel Convergence",
                        ChampionName = "Ekko",
                        SpellName = "EkkoW",
                        Slot = SpellSlot.W,
                        Delay = 3750,
                        Range = 1600,
                        Radius = 375,
                        MissileSpeed = 1650,
                        DangerValue = 3,
                        IsDangerous = false,
                        AddHitbox = false,
                        ObjectCreationName = "EkkoW"
                    }
                },
                new CircularSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Chronobreak",
                        ChampionName = "Ekko",
                        SpellName = "EkkoR",
                        Slot = SpellSlot.R,
                        Delay = 250,
                        Range = 1600,
                        Radius = 375,
                        MissileSpeed = 1650,
                        DangerValue = 3,
                        IsDangerous = false,
                        ObjectCreationName = "EkkoR"
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Cocoon",
                        ChampionName = "Elise",
                        SpellName = "EliseHumanE",
                        Slot = SpellSlot.E,
                        Delay = 250,
                        Range = 1100,
                        Radius = 70,
                        MissileSpeed = 1600,
                        DangerValue = 4,
                        IsDangerous = true,
                        ObjectCreationName = "EliseHumanE",
                        MinionCollision = true
                    }
                },
                new CircularSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Agony's Embrace",
                        ChampionName = "Evelynn",
                        SpellName = "EvelynnR",
                        Slot = SpellSlot.R,
                        Delay = 250,
                        Range = 650,
                        Radius = 350,
                        MissileSpeed = 0,
                        DangerValue = 5,
                        IsDangerous = true,
                        ObjectCreationName = "EvelynnR"
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Mystic Shot",
                        ChampionName = "Ezreal",
                        SpellName = "EzrealMysticShot",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 1200,
                        Radius = 60,
                        MissileSpeed = 2000,
                        DangerValue = 2,
                        IsDangerous = false,
                        ObjectCreationName = "EzrealMysticShotMissile",
                        MinionCollision = true
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Trueshot Barrage",
                        ChampionName = "Ezreal",
                        SpellName = "EzrealTrueshotBarrage",
                        Slot = SpellSlot.R,
                        Delay = 1000,
                        Range = 20000,
                        Radius = 160,
                        MissileSpeed = 2000,
                        DangerValue = 3,
                        IsDangerous = true,
                        ObjectCreationName = "EzrealTrueshotBarrage"
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Essence Flux",
                        ChampionName = "Ezreal",
                        SpellName = "EzrealEssenceFlux",
                        Slot = SpellSlot.W,
                        Delay = 250,
                        Range = 1050,
                        Radius = 80,
                        MissileSpeed = 1600,
                        DangerValue = 2,
                        IsDangerous = false,
                        ObjectCreationName = "EzrealEssenceFluxMissile"
                    }
                },
                /*
                 * TODO: Fiora W
                */
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Chum the Waters",
                        ChampionName = "Fizz",
                        SpellName = "FizzMarinerDoom",
                        Slot = SpellSlot.R,
                        Delay = 250,
                        Range = 1275,
                        Radius = 120,
                        MissileSpeed = 1350,
                        DangerValue = 5,
                        IsDangerous = true,
                        ObjectCreationName = "FizzMarinerDoomMissile"
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Righteous Gust",
                        ChampionName = "Galio",
                        SpellName = "GalioRighteousGust",
                        Slot = SpellSlot.E,
                        Delay = 250,
                        Range = 1280,
                        Radius = 120,
                        MissileSpeed = 1300,
                        DangerValue = 2,
                        IsDangerous = false,
                        ObjectCreationName = "GalioRighteousGust"
                    }
                },
                new CircularSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Resolute Smite",
                        ChampionName = "Galio",
                        SpellName = "GalioResoluteSmite",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 1040,
                        Radius = 235,
                        MissileSpeed = 1200,
                        DangerValue = 2,
                        IsDangerous = false,
                        ObjectCreationName = "GalioResoluteSmite"
                    }
                },
                new CircularSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Idol of Durand",
                        ChampionName = "Galio",
                        SpellName = "GalioIdolOfDurand",
                        Slot = SpellSlot.R,
                        Delay = 250,
                        Range = 600,
                        Radius = 600,
                        MissileSpeed = 0,
                        DangerValue = 3,
                        AddHitbox = false,
                        ObjectCreationName = ""
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Boulder Toss",
                        ChampionName = "Gnar",
                        SpellName = "gnarbigq",
                        Slot = SpellSlot.Q,
                        Delay = 500,
                        Range = 1150,
                        Radius = 90,
                        MissileSpeed = 2100,
                        DangerValue = 2,
                        IsDangerous = false,
                        ObjectCreationName = "gnarbigq"
                    }
                },
                new CircularSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "GNAR!",
                        ChampionName = "Gnar",
                        SpellName = "GnarR",
                        Slot = SpellSlot.R,
                        Delay = 250,
                        Range = 500,
                        Radius = 500,
                        MissileSpeed = 0,
                        DangerValue = 5,
                        IsDangerous = true,
                        AddHitbox = false,
                        ObjectCreationName = "GnarR"
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Wallop",
                        ChampionName = "Gnar",
                        SpellName = "gnarbigw",
                        Slot = SpellSlot.W,
                        Delay = 600,
                        Range = 600,
                        Radius = 100,
                        MissileSpeed = 0,
                        DangerValue = 2,
                        IsDangerous = false,
                        ObjectCreationName = "gnarbigw"
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Boomerang Throw",
                        ChampionName = "Gnar",
                        SpellName = "GnarQ",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 1185,
                        Radius = 60,
                        MissileSpeed = 2400,
                        DangerValue = 2,
                        IsDangerous = false,
                        ObjectCreationName = "GnarQ"
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Boomerang Throw Return",
                        ChampionName = "Gnar",
                        SpellName = "GnarQReturn",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 1185,
                        Radius = 60,
                        MissileSpeed = 2400,
                        DangerValue = 2,
                        IsDangerous = false,
                        ObjectCreationName = "GnarQMissileReturn"
                    }
                },
                new CircularSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Hop",
                        ChampionName = "Gnar",
                        SpellName = "GnarE",
                        Slot = SpellSlot.E,
                        Delay = 0,
                        Range = 475,
                        Radius = 150,
                        MissileSpeed = 900,
                        DangerValue = 2,
                        IsDangerous = false,
                        ObjectCreationName = "GnarE"
                    }
                },
                new CircularSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Crunch",
                        ChampionName = "Gnar",
                        SpellName = "gnarbige",
                        Slot = SpellSlot.E,
                        Delay = 0,
                        Range = 475,
                        Radius = 100,
                        MissileSpeed = 800,
                        DangerValue = 2,
                        IsDangerous = false,
                        ObjectCreationName = "gnarbige"
                    }
                },
                new CircularSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Barrel Roll",
                        ChampionName = "Gragas",
                        SpellName = "GragasQ",
                        Slot = SpellSlot.Q,
                        Delay = 500,
                        Range = 975,
                        Radius = 250,
                        MissileSpeed = 1000,
                        DangerValue = 2,
                        IsDangerous = false,
                        ObjectCreationName = "GragasQ",
                        ToggleParticleName = "Gragas_.+_Q_(Enemy|Ally)"
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Body Slam",
                        ChampionName = "Gragas",
                        SpellName = "GragasE",
                        Slot = SpellSlot.E,
                        Delay = 0,
                        Range = 950,
                        Radius = 200,
                        MissileSpeed = 1200,
                        DangerValue = 2,
                        IsDangerous = false,
                        ObjectCreationName = "GragasE"
                    }
                },
                new CircularSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Explosive Cask",
                        ChampionName = "Gragas",
                        SpellName = "GragasR",
                        Slot = SpellSlot.R,
                        Delay = 250,
                        Range = 1050,
                        Radius = 350,
                        MissileSpeed = 1750,
                        DangerValue = 5,
                        IsDangerous = true,
                        ObjectCreationName = "GragasR"
                    }
                },
                //new LinearSkillshot
                //{
                //    OwnSpellData = new OwnSpellData
                //    {
                //        ChampionName = "Graves",
                //        SpellName = "GravesClusterShot",
                //        Slot = SpellSlot.Q,
                //        Delay = 250,
                //        Range = 1025,
                //        Radius = 60,
                //        MissileSpeed = 2000,
                //        DangerValue = 3,
                //        ObjectCreationName = "GravesClusterShotAttack",
                //        ExtraMissiles = 2
                //    }
                //},
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Collateral Damage",
                        ChampionName = "Graves",
                        SpellName = "GravesChargeShot",
                        Slot = SpellSlot.R,
                        Delay = 250,
                        Range = 1000,
                        Radius = 100,
                        MissileSpeed = 2100,
                        DangerValue = 5,
                        IsDangerous = true,
                        ObjectCreationName = "GravesChargeShotShot"
                    }
                },
                new CircularSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Onslaught of Shadows",
                        ChampionName = "Hecarim",
                        SpellName = "HecarimUlt",
                        Slot = SpellSlot.R,
                        Delay = 10,
                        Range = 1500,
                        Radius = 300,
                        MissileSpeed = 1100,
                        DangerValue = 5,
                        IsDangerous = true,
                        ObjectCreationName = "HecarimUlt"
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Hextech Micro-Rockets",
                        ChampionName = "Heimerdinger",
                        SpellName = "disabled/HeimerdingerW",
                        Slot = SpellSlot.W,
                        Delay = 250,
                        Range = 1500,
                        Radius = 70,
                        MissileSpeed = 1800,
                        DangerValue = 2,
                        IsDangerous = false,
                        ObjectCreationName = "HeimerdingerWAttack2"
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Hextech Micro-Rockets Ult",
                        ChampionName = "Heimerdinger",
                        SpellName = "disabled/HeimerdingerW",
                        Slot = SpellSlot.W,
                        Delay = 250,
                        Range = 1500,
                        Radius = 70,
                        MissileSpeed = 1800,
                        DangerValue = 2,
                        IsDangerous = false,
                        ObjectCreationName = "HeimerdingerWAttack2Ult"
                    }
                },
                new CircularSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "CH-2 Electron Storm Grenade",
                        ChampionName = "Heimerdinger",
                        SpellName = "HeimerdingerE",
                        Slot = SpellSlot.E,
                        Delay = 325,
                        Range = 925,
                        Radius = 135,
                        MissileSpeed = 1750,
                        DangerValue = 2,
                        IsDangerous = false,
                        ObjectCreationName = "HeimerdingerESpell"
                    }
                },
                new CircularSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "CH-2 Electron Storm Grenade Ult",
                        ChampionName = "Heimerdinger",
                        SpellName = "disabled/HeimerdingerE",
                        Slot = SpellSlot.E,
                        Delay = 325,
                        Range = 925,
                        Radius = 135,
                        MissileSpeed = 1750,
                        DangerValue = 2,
                        IsDangerous = false,
                        ObjectCreationName = "heimerdingerespell_ult"
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "ranscendent Blades",
                        ChampionName = "Irelia",
                        SpellName = "IreliaTranscendentBlades",
                        Slot = SpellSlot.R,
                        Delay = 0,
                        Range = 1200,
                        Radius = 65,
                        MissileSpeed = 1600,
                        DangerValue = 2,
                        IsDangerous = false,
                        ObjectCreationName = "ireliatranscendentbladesspell"
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Howling Gale",
                        ChampionName = "Janna",
                        SpellName = "//HowlingGale",
                        Slot = SpellSlot.Q,
                        Delay = 0,
                        Range = 1700,
                        Radius = 120,
                        MissileSpeed = 900,
                        DangerValue = 2,
                        IsDangerous = false,
                        ObjectCreationName = "HowlingGaleSpell"
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Dragon Strike",
                        ChampionName = "JarvanIV",
                        SpellName = "JarvanIVDragonStrike",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 845,
                        Radius = 80,
                        MissileSpeed = 2000,
                        DangerValue = 3,
                        IsDangerous = true,
                        ObjectCreationName = "JarvanIVDragonStrike"
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Dragon Strike EQ",
                        ChampionName = "JarvanIVEQ",
                        SpellName = "JarvanIVDragonStrike2",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 845,
                        Radius = 120,
                        MissileSpeed = 1800,
                        DangerValue = 3,
                        IsDangerous = false,
                        ObjectCreationName = "JarvanIVDragonStrike2"
                    }
                },
                //new CircularSkillshot
                //{
                //    OwnSpellData = new OwnSpellData
                //    {
                //        ChampionName = "JarvanIV",
                //        SpellName = "JarvanIVCataclysm",
                //        Slot = SpellSlot.R,
                //        Delay = 0,
                //        Range = 825,
                //        Radius = 350,
                //        MissileSpeed = 1900,
                //        DangerValue = 3,
                //        ObjectCreationName = "JarvanIVCataclysm"
                //    }
                //},
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Shock Blast Fast",
                        ChampionName = "Jayce",
                        SpellName = "JayceQAccel",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 1170,
                        Radius = 70,
                        MissileSpeed = 2350,
                        DangerValue = 2,
                        IsDangerous = false,
                        ObjectCreationName = "JayceShockBlastWallMis",
                        MinionCollision = true
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Shock Blast",
                        ChampionName = "Jayce",
                        SpellName = "jayceshockblast",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 1050,
                        Radius = 70,
                        MissileSpeed = 1450,
                        DangerValue = 2,
                        IsDangerous = false,
                        ObjectCreationName = "JayceShockBlastMis",
                        MinionCollision = true
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Super Mega Death Rocket!",
                        ChampionName = "Jinx",
                        SpellName = "JinxR",
                        Slot = SpellSlot.R,
                        Delay = 600,
                        Range = 25000,
                        Radius = 120,
                        MissileSpeed = 1700,
                        DangerValue = 5,
                        IsDangerous = true,
                        ObjectCreationName = "JinxR"
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Zap!",
                        ChampionName = "Jinx",
                        SpellName = "JinxWMissile",
                        Slot = SpellSlot.W,
                        Delay = 600,
                        Range = 1500,
                        Radius = 60,
                        MissileSpeed = 3300,
                        DangerValue = 3,
                        IsDangerous = true,
                        ObjectCreationName = "JinxWMissile",
                        MinionCollision = true
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Pierce",
                        ChampionName = "Kalista",
                        SpellName = "KalistaMysticShot",
                        Slot = SpellSlot.Q,
                        Delay = 350,
                        Range = 1200,
                        Radius = 70,
                        MissileSpeed = 2000,
                        DangerValue = 2,
                        IsDangerous = false,
                        ObjectCreationName = "kalistamysticshotmistrue"
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Inner Flame",
                        ChampionName = "Karma",
                        SpellName = "KarmaQ",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 1050,
                        Radius = 90,
                        MissileSpeed = 1700,
                        DangerValue = 2,
                        IsDangerous = false,
                        ObjectCreationName = "KarmaQMissile",
                        MinionCollision = true
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Soulflare (Mantra)",
                        ChampionName = "Karma",
                        SpellName = "KarmaQMissileMantra",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 1050,
                        Radius = 90,
                        MissileSpeed = 1700,
                        DangerValue = 2,
                        IsDangerous = false,
                        ObjectCreationName = "KarmaQMissileMantra",
                        MinionCollision = true
                    }
                },
                new CircularSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Lay Waste",
                        ChampionName = "Karthus",
                        SpellName = "KarthusLayWasteA1",
                        Slot = SpellSlot.Q,
                        Delay = 625,
                        Range = 875,
                        Radius = 190,
                        MissileSpeed = 0,
                        DangerValue = 2,
                        IsDangerous = false,
                        ObjectCreationName = "KarthusLayWasteA1"
                    }
                },
                new CircularSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Riftwalk",
                        ChampionName = "Kassadin",
                        SpellName = "RiftWalk",
                        Slot = SpellSlot.R,
                        Delay = 250,
                        Range = 700,
                        Radius = 270,
                        MissileSpeed = 0,
                        DangerValue = 2,
                        IsDangerous = false,
                        ObjectCreationName = "RiftWalk"
                    }
                },
                //new CircularSkillshot
                //{
                //    OwnSpellData = new OwnSpellData
                //    {
                //        ChampionName = "Kassadin",
                //        SpellName = "ForcePulse",
                //        Slot = SpellSlot.E,
                //        Delay = 250,
                //        Range = 700,
                //        Radius = 20,
                //        MissileSpeed = 0,
                //        DangerValue = 3,
                //        ObjectCreationName = "ForcePulse"
                //    }
                //},
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Thundering Shuriken",
                        ChampionName = "Kennen",
                        SpellName = "KennenShurikenHurlMissile1",
                        Slot = SpellSlot.Q,
                        Delay = 125,
                        Range = 1175,
                        Radius = 50,
                        MissileSpeed = 1700,
                        DangerValue = 2,
                        IsDangerous = false,
                        ObjectCreationName = "KennenShurikenHurlMissile1",
                        MinionCollision = true
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Void Spike",
                        ChampionName = "Khazix",
                        SpellName = "KhazixW",
                        Slot = SpellSlot.W,
                        Delay = 250,
                        Range = 1100,
                        Radius = 70,
                        MissileSpeed = 1700,
                        DangerValue = 2,
                        IsDangerous = false,
                        ObjectCreationName = "KhazixWMissile",
                        MinionCollision = true
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Void Spike Evolved",
                        ChampionName = "Khazix",
                        SpellName = "khazixwlong",
                        Slot = SpellSlot.W,
                        Delay = 250,
                        Range = 1025,
                        Radius = 70,
                        MissileSpeed = 1700,
                        DangerValue = 2,
                        IsDangerous = false,
                        ExtraMissiles = 2,
                        ObjectCreationName = "khazixwlong",
                        MinionCollision = true
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Caustic Spittle",
                        ChampionName = "KogMaw",
                        SpellName = "KogMawQ",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 1125,
                        Radius = 70,
                        MissileSpeed = 1650,
                        DangerValue = 2,
                        IsDangerous = false,
                        ObjectCreationName = "KogMawQMis",
                        MinionCollision = true
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Void Ooze",
                        ChampionName = "KogMaw",
                        SpellName = "KogMawVoidOoze",
                        Slot = SpellSlot.E,
                        Delay = 250,
                        Range = 1360,
                        Radius = 120,
                        MissileSpeed = 1400,
                        DangerValue = 2,
                        IsDangerous = false,
                        ObjectCreationName = "KogMawVoidOozeMissile"
                    }
                },
                new CircularSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Living Artillery",
                        ChampionName = "KogMaw",
                        SpellName = "KogMawLivingArtillery",
                        Slot = SpellSlot.R,
                        Delay = 1100,
                        Range = 2200,
                        Radius = 235,
                        MissileSpeed = 0,
                        DangerValue = 2,
                        IsDangerous = false,
                        ObjectCreationName = "KogMawLivingArtillery"
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Ethereal Chains (Mimic)",
                        ChampionName = "Leblanc",
                        SpellName = "LeblancSoulShackleM",
                        Slot = SpellSlot.R,
                        Delay = 250,
                        Range = 960,
                        Radius = 70,
                        MissileSpeed = 1600,
                        DangerValue = 3,
                        IsDangerous = true,
                        ObjectCreationName = "LeblancSoulShackleM",
                        MinionCollision = true
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Ethereal Chains",
                        ChampionName = "Leblanc",
                        SpellName = "LeblancSoulShackle",
                        Slot = SpellSlot.E,
                        Delay = 250,
                        Range = 960,
                        Radius = 70,
                        MissileSpeed = 1600,
                        DangerValue = 3,
                        IsDangerous = true,
                        ObjectCreationName = "LeblancSoulShackle",
                        MinionCollision = true
                    }
                },
                new CircularSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Distortion (Mimic)",
                        ChampionName = "Leblanc",
                        SpellName = "LeblancSlideM",
                        Slot = SpellSlot.R,
                        Delay = 250,
                        Range = 725,
                        Radius = 250,
                        MissileSpeed = 1600,
                        DangerValue = 2,
                        IsDangerous = false,
                        ObjectCreationName = "LeblancSlideM"
                    }
                },
                new CircularSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Distortion",
                        ChampionName = "Leblanc",
                        SpellName = "LeblancSlide",
                        Slot = SpellSlot.W,
                        Delay = 250,
                        Range = 725,
                        Radius = 250,
                        MissileSpeed = 1600,
                        DangerValue = 2,
                        IsDangerous = false,
                        ObjectCreationName = "LeblancSlide"
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Sonic Wave",
                        ChampionName = "LeeSin",
                        SpellName = "BlindMonkQOne",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 1100,
                        Radius = 60,
                        MissileSpeed = 1800,
                        DangerValue = 3,
                        IsDangerous = true,
                        ObjectCreationName = "BlindMonkQOne",
                        MinionCollision = true
                    }
                },
                new CircularSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Solar Flare",
                        ChampionName = "Leona",
                        SpellName = "LeonaSolarFlare",
                        Slot = SpellSlot.R,
                        Delay = 625,
                        Range = 1200,
                        Radius = 250,
                        MissileSpeed = 0,
                        DangerValue = 5,
                        IsDangerous = true,
                        ObjectCreationName = "LeonaSolarFlare"
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Zenith Blade",
                        ChampionName = "Leona",
                        SpellName = "LeonaZenithBlade",
                        Slot = SpellSlot.E,
                        Delay = 350,
                        Range = 975,
                        Radius = 70,
                        MissileSpeed = 2000,
                        DangerValue = 3,
                        IsDangerous = true,
                        ObjectCreationName = "FlashFrostSpell"
                    }
                },
                //new CircularSkillshot
                //{
                //    OwnSpellData = new OwnSpellData
                //    {
                //        ChampionName = "Lissandra",
                //        SpellName = "LissandraW",
                //        Slot = SpellSlot.W,
                //        Delay = 250,
                //        Range = 725,
                //        Radius = 450,
                //        MissileSpeed = 0,
                //        DangerValue = 3,
                //        ObjectCreationName = "LissandraW"
                //    }
                //},
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Ice Shard",
                        ChampionName = "Lissandra",
                        SpellName = "LissandraQ",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 825,
                        Radius = 75,
                        MissileSpeed = 2200,
                        DangerValue = 2,
                        IsDangerous = false,
                        ObjectCreationName = "LissandraQ"
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Ardent Blaze",
                        ChampionName = "Lucian",
                        SpellName = "LucianW",
                        Slot = SpellSlot.W,
                        Delay = 250,
                        Range = 1000,
                        Radius = 80,
                        MissileSpeed = 1600,
                        DangerValue = 2,
                        IsDangerous = false,
                        ObjectCreationName = "LucianW",
                        MinionCollision = true,
                        EnabledByDefault = false
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Piercing Light",
                        ChampionName = "Lucian",
                        SpellName = "LucianQ",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 1140,
                        Radius = 65,
                        MissileSpeed = 0,
                        DangerValue = 2,
                        IsDangerous = false,
                        ObjectCreationName = "LucianQ",
                        AddHitbox = false
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Glitterlance",
                        ChampionName = "Lulu",
                        SpellName = "LuluQ",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 925,
                        Radius = 80,
                        MissileSpeed = 1450,
                        DangerValue = 2,
                        IsDangerous = false,
                        ObjectCreationName = "LuluQMissile"
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Glitterlance Pix",
                        ChampionName = "Lulu",
                        SpellName = "LuluQPix",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 925,
                        Radius = 80,
                        MissileSpeed = 1450,
                        DangerValue = 2,
                        IsDangerous = false,
                        ObjectCreationName = "LuluQMissileTwo"
                    }
                },
                new CircularSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Lucent Singularity",
                        ChampionName = "Lux",
                        SpellName = "LuxLightStrikeKugel",
                        Slot = SpellSlot.E,
                        Delay = 250,
                        Range = 1100,
                        Radius = 340,
                        MissileSpeed = 1400,
                        DangerValue = 2,
                        IsDangerous = false,
                        ObjectCreationName = "LuxLightStrikeKugel",
                        ToggleParticleName = "Lux_.+_E_tar_aoe_",
                        EnabledByDefault = false
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Final Spark",
                        ChampionName = "Lux",
                        SpellName = "LuxMaliceCannon",
                        Slot = SpellSlot.R,
                        Delay = 1000,
                        Range = 3500,
                        Radius = 110,
                        MissileSpeed = 0,
                        DangerValue = 5,
                        IsDangerous = true,
                        ObjectCreationName = "LuxRVfxMis"
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Light Binding",
                        ChampionName = "Lux",
                        SpellName = "LuxLightBinding",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 1300,
                        Radius = 70,
                        MissileSpeed = 1200,
                        DangerValue = 3,
                        IsDangerous = true,
                        ObjectCreationName = "LuxLightBindingMis"
                    }
                },
                new CircularSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Unstoppable Force",
                        ChampionName = "Malphite",
                        SpellName = "UFSlash",
                        Slot = SpellSlot.R,
                        Delay = 0,
                        Range = 1000,
                        Radius = 270,
                        MissileSpeed = 1500,
                        DangerValue = 5,
                        IsDangerous = true,
                        ObjectCreationName = "UFSlash"
                    }
                },
                //new LinearSkillshot
                //{
                //    OwnSpellData = new OwnSpellData
                //    {
                //        ChampionName = "Malzahar",
                //        SpellName = "AlZaharCalloftheVoid",
                //        Slot = SpellSlot.Q,
                //        Delay = 1000,
                //        Range = 900,
                //        Radius = 85,
                //        MissileSpeed = 1600,
                //        DangerValue = 3,
                //        ObjectCreationName = "AlZaharCalloftheVoidMissile"
                //    }
                //},
                //new CircularSkillshot
                //{
                //    OwnSpellData = new OwnSpellData
                //    {
                //        ChampionName = "MonkeyKing",
                //        SpellName = "MonkeyKingSpinToWin",
                //        Slot = SpellSlot.R,
                //        Delay = 250,
                //        Range = 300,
                //        Radius = 225,
                //        MissileSpeed = 0,
                //        DangerValue = 3,
                //        ObjectCreationName = "MonkeyKingSpinToWin"
                //    }
                //},
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Dark Binding",
                        ChampionName = "Morgana",
                        SpellName = "DarkBindingMissile",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 1300,
                        Radius = 80,
                        MissileSpeed = 1200,
                        DangerValue = 3,
                        IsDangerous = true,
                        ObjectCreationName = "DarkBindingMissile",
                        MinionCollision = true
                    }
                },
                new CircularSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Aqua Prison",
                        ChampionName = "Nami",
                        SpellName = "NamiQ",
                        Slot = SpellSlot.Q,
                        Delay = 500,
                        Range = 875,
                        Radius = 200,
                        MissileSpeed = 0,
                        DangerValue = 3,
                        IsDangerous = true,
                        ObjectCreationName = "NamiQ"
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Tidal Wave",
                        ChampionName = "Nami",
                        SpellName = "NamiR",
                        Slot = SpellSlot.R,
                        Delay = 500,
                        Range = 2750,
                        Radius = 250,
                        MissileSpeed = 850,
                        DangerValue = 2,
                        IsDangerous = false,
                        ObjectCreationName = "NamiRMissile"
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Dredge Line",
                        ChampionName = "Nautilus",
                        SpellName = "NautilusAnchorDrag",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 1080,
                        Radius = 90,
                        MissileSpeed = 2000,
                        DangerValue = 3,
                        IsDangerous = true,
                        ObjectCreationName = "NautilusAnchorDragMissile",
                        MinionCollision = true
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Javelin Toss",
                        ChampionName = "Nidalee",
                        SpellName = "JavelinToss",
                        Slot = SpellSlot.Q,
                        Delay = 125,
                        Range = 1500,
                        Radius = 40,
                        MissileSpeed = 1300,
                        DangerValue = 3,
                        IsDangerous = true,
                        ObjectCreationName = "JavelinToss"
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Duskbringer",
                        ChampionName = "Nocturne",
                        SpellName = "NocturneDuskbringer",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 1125,
                        Radius = 60,
                        MissileSpeed = 1400,
                        DangerValue = 2,
                        IsDangerous = false,
                        ObjectCreationName = "NocturneDuskbringer"
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Axe Throw",
                        ChampionName = "Olaf",
                        SpellName = "OlafAxeThrowCast",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 1000,
                        Radius = 90,
                        MissileSpeed = 1600,
                        DangerValue = 2,
                        ObjectCreationName = "olafaxethrow"
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Commnad: Attack",
                        ChampionName = "Orianna",
                        SpellName = "OrianaIzunaCommand",
                        Slot = SpellSlot.Q,
                        Delay = 0,
                        Range = 2000,
                        Radius = 80,
                        MissileSpeed = 1200,
                        DangerValue = 2,
                        IsDangerous = false,
                        ObjectCreationName = "OrianaIzunaCommand"
                    }
                },
                new CircularSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Command: Shockwave",
                        ChampionName = "Orianna",
                        SpellName = "OrianaDetonateCommand",
                        Slot = SpellSlot.R,
                        Delay = 500,
                        Range = 410,
                        Radius = 410,
                        MissileSpeed = 0,
                        DangerValue = 5,
                        IsDangerous = true,
                        ObjectCreationName = "OrianaDetonateCommand"
                    }
                },
                new CircularSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Command: Dissonance",
                        ChampionName = "Orianna",
                        SpellName = "OrianaDissonanceCommand",
                        Slot = SpellSlot.W,
                        Delay = 250,
                        Range = 1825,
                        Radius = 250,
                        MissileSpeed = 0,
                        DangerValue = 2,
                        IsDangerous = false,
                        ObjectCreationName = "OrianaDissonanceCommand"
                    }
                },
                //new CircularSkillshot
                //{
                //    OwnSpellData = new OwnSpellData
                //    {
                //        ChampionName = "Pantheon",
                //        SpellName = "PantheonE",
                //        Slot = SpellSlot.E,
                //        Delay = 1000,
                //        Range = 650,
                //        Radius = 100,
                //        MissileSpeed = 0,
                //        DangerValue = 3,
                //        ObjectCreationName = "PantheonE"
                //    }
                //},
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Blinding Assault",
                        ChampionName = "Quinn",
                        SpellName = "QuinnQ",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 1050,
                        Radius = 80,
                        MissileSpeed = 1550,
                        DangerValue = 2,
                        IsDangerous = false,
                        ObjectCreationName = "QuinnQMissile",
                        MinionCollision = true
                    }
                },
                //new LinearSkillshot
                //{
                //    OwnSpellData = new OwnSpellData
                //    {
                //        ChampionName = "RekSai",
                //        SpellName = "reksaiqburrowed",
                //        Slot = SpellSlot.E,
                //        Delay = 125,
                //        Range = 1500,
                //        Radius = 65,
                //        MissileSpeed = 1950,
                //        DangerValue = 3,
                //        ObjectCreationName = "RekSaiQBurrowedMis"
                //    }
                //},
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Bola Strike",
                        ChampionName = "Rengar",
                        SpellName = "RengarE",
                        Slot = SpellSlot.E,
                        Delay = 250,
                        Range = 1000,
                        Radius = 70,
                        MissileSpeed = 1500,
                        DangerValue = 3,
                        IsDangerous = true,
                        ObjectCreationName = "RengarEFinal",
                        MinionCollision = true
                    }
                },
                new ConeSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        ChampionName = "Riven",
                        SpellName = "RivenIzunaBlade",
                        Slot = SpellSlot.R,
                        Delay = 250,
                        Range = 1100,
                        Radius = 100,
                        MissileSpeed = 1800,
                        DangerValue = 3,
                        ObjectCreationName = "RivenWindslashMissileCenter",
                        ConeAngle = 40
                    }
                },
                new CircularSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Ki Burst",
                        ChampionName = "Riven",
                        SpellName = "RivenMartyr",
                        Slot = SpellSlot.W,
                        Delay = 267,
                        Range = 650,
                        Radius = 280,
                        MissileSpeed = 1500,
                        DangerValue = 3,
                        IsDangerous = true,
                        ObjectCreationName = "RivenMartyr"
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Electro-Harpoon",
                        ChampionName = "Rumble",
                        SpellName = "RumbleGrenade",
                        Slot = SpellSlot.E,
                        Delay = 250,
                        Range = 950,
                        Radius = 90,
                        MissileSpeed = 2000,
                        DangerValue = 2,
                        IsDangerous = false,
                        ObjectCreationName = "RumbleGrenade",
                        MinionCollision = true
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Overload",
                        ChampionName = "Ryze",
                        SpellName = "RyzeQ",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 900,
                        Radius = 60,
                        MissileSpeed = 1700,
                        DangerValue = 2,
                        IsDangerous = false,
                        ObjectCreationName = "RyzeQ",
                        MinionCollision = true
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Arctic Assault",
                        ChampionName = "Sejuani",
                        SpellName = "SejuaniArcticAssault",
                        Slot = SpellSlot.Q,
                        Delay = 0,
                        Range = 900,
                        Radius = 70,
                        MissileSpeed = 1600,
                        DangerValue = 3,
                        IsDangerous = true,
                        ObjectCreationName = "",
                        MinionCollision = true
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Glacial Prison",
                        ChampionName = "Sejuani",
                        SpellName = "SejuaniGlacialPrisonCast",
                        Slot = SpellSlot.R,
                        Delay = 250,
                        Range = 1200,
                        Radius = 110,
                        MissileSpeed = 1600,
                        DangerValue = 3,
                        IsDangerous = true,
                        ObjectCreationName = "SejuaniGlacialPrison"
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Shadow Dash",
                        ChampionName = "Shen",
                        SpellName = "ShenShadowDash",
                        Slot = SpellSlot.E,
                        Delay = 0,
                        Range = 1600,
                        Radius = 75,
                        MissileSpeed = 1250,
                        DangerValue = 3,
                        IsDangerous = true,
                        ObjectCreationName = "ShenShadowDash"
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Flame Breath",
                        ChampionName = "Shyvana",
                        SpellName = "ShyvanaFireball",
                        Slot = SpellSlot.E,
                        Delay = 0,
                        Range = 950,
                        Radius = 60,
                        MissileSpeed = 1700,
                        DangerValue = 2,
                        IsDangerous = false,
                        ObjectCreationName = "ShyvanaFireball"
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Dragon's Descent",
                        ChampionName = "Shyvana",
                        SpellName = "ShyvanaTransformCast",
                        Slot = SpellSlot.R,
                        Delay = 250,
                        Range = 1000,
                        Radius = 160,
                        MissileSpeed = 1500,
                        DangerValue = 3,
                        IsDangerous = true,
                        ObjectCreationName = "ShyvanaTransformCast"
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Roar of the Slayer",
                        ChampionName = "Sion",
                        SpellName = "SionE",
                        Slot = SpellSlot.E,
                        Delay = 250,
                        Range = 800,
                        Radius = 80,
                        MissileSpeed = 1800,
                        DangerValue = 3,
                        IsDangerous = true,
                        ObjectCreationName = "SionEMissile"
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Boomerang Blade",
                        ChampionName = "Sivir",
                        SpellName = "SivirQ",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 1275,
                        Radius = 100,
                        MissileSpeed = 1350,
                        DangerValue = 2,
                        IsDangerous = false,
                        ObjectCreationName = "SivirQMissile"
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Boomerang Blade (return)",
                        ChampionName = "Sivir",
                        SpellName = "SivirQReturn",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 1275,
                        Radius = 100,
                        MissileSpeed = 1350,
                        DangerValue = 2,
                        IsDangerous = false,
                        ObjectCreationName = "SivirQMissileReturn"
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Fracture",
                        ChampionName = "Skarner",
                        SpellName = "SkarnerFracture",
                        Slot = SpellSlot.E,
                        Delay = 250,
                        Range = 1000,
                        Radius = 60,
                        MissileSpeed = 1400,
                        DangerValue = 2,
                        IsDangerous = false,
                        ObjectCreationName = "SkarnerFractureMissile",
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Crescendo",
                        ChampionName = "Sona",
                        SpellName = "SonaR",
                        Slot = SpellSlot.R,
                        Delay = 250,
                        Range = 1000,
                        Radius = 150,
                        MissileSpeed = 2400,
                        DangerValue = 5,
                        IsDangerous = true,
                        ObjectCreationName = "SonaR"
                    }
                },
                new CircularSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Starcall",
                        ChampionName = "Soraka",
                        SpellName = "SorakaQ",
                        Slot = SpellSlot.Q,
                        Delay = 500,
                        Range = 970,
                        Radius = 260,
                        MissileSpeed = 5,//1100,
                        DangerValue = 2,
                        IsDangerous = false,
                        ObjectCreationName = "SorakaQ"
                    }
                },
                //new CircularSkillshot
                //{
                //    OwnSpellData = new OwnSpellData
                //    {
                //        ChampionName = "Soraka",
                //        SpellName = "SorakaE",
                //        Slot = SpellSlot.E,
                //        Delay = 1750,
                //        Range = 925,
                //        Radius = 275,
                //        MissileSpeed = 0,
                //        DangerValue = 3,
                //        ObjectCreationName = "SorakaE"
                //    }
                //},
                new CircularSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Nevermove",
                        ChampionName = "Swain",
                        SpellName = "SwainShadowGrasp",
                        Slot = SpellSlot.W,
                        Delay = 1100,
                        Range = 900,
                        Radius = 200,
                        MissileSpeed = 0,
                        DangerValue = 3,
                        IsDangerous = true,
                        ObjectCreationName = "SwainShadowGrasp"
                    }
                },
                //new LinearSkillshot
                //{
                //    OwnSpellData = new OwnSpellData
                //    {
                //        ChampionName = "Syndra",
                //        SpellName = "SyndraE",
                //        Slot = SpellSlot.E,
                //        Delay = 250,
                //        Range = 800,
                //        Radius = 140,
                //        MissileSpeed = 1500,
                //        DangerValue = 3,
                //        ObjectCreationName = "SyndraE"
                //    }
                //},
                new CircularSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Force of Will",
                        ChampionName = "Syndra",
                        SpellName = "syndrawcast",
                        Slot = SpellSlot.W,
                        Delay = 0,
                        Range = 925,
                        Radius = 220,
                        MissileSpeed = 1450,
                        DangerValue = 2,
                        IsDangerous = false,
                        ObjectCreationName = "syndrawcast"
                    }
                },
                new CircularSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Dark Sphere",
                        ChampionName = "Syndra",
                        SpellName = "SyndraQ",
                        Slot = SpellSlot.Q,
                        Delay = 600,
                        Range = 800,
                        Radius = 210,
                        MissileSpeed = 0,
                        DangerValue = 2,
                        IsDangerous = false,
                        ObjectCreationName = "SyndraQ"
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Tongue Lash",
                        ChampionName = "TahmKench",
                        SpellName = "TahmKenchQ",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 951,
                        Radius = 90,
                        MissileSpeed = 2000,
                        DangerValue = 3,
                        IsDangerous = true,
                        ObjectCreationName = "tahmkenchqmissile",
                        MinionCollision = true
                    }
                },
                //new LinearSkillshot
                //{
                //    OwnSpellData = new OwnSpellData
                //    {
                //        ChampionName = "Talon",
                //        SpellName = "TalonRake",
                //        Slot = SpellSlot.W,
                //        Delay = 0,
                //        Range = 780,
                //        Radius = 75,
                //        MissileSpeed = 2300,
                //        DangerValue = 3,
                //        ObjectCreationName = "TalonRake"
                //    }
                //},
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Death Sentence",
                        ChampionName = "Thresh",
                        SpellName = "ThreshQ",
                        Slot = SpellSlot.Q,
                        Delay = 500,
                        Range = 1200,
                        Radius = 70,
                        MissileSpeed = 1900,
                        DangerValue = 3,
                        IsDangerous = true,
                        ObjectCreationName = "ThreshQMissile",
                        MinionCollision = true
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Flay",
                        ChampionName = "Thresh",
                        SpellName = "ThreshE",
                        Slot = SpellSlot.E,
                        Delay = 125,
                        Range = 1075,
                        Radius = 110,
                        MissileSpeed = 2000,
                        DangerValue = 3,
                        IsDangerous = true,
                        ObjectCreationName = "ThreshEMissile1"
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Wild Cards",
                        ChampionName = "TwistedFate",
                        SpellName = "disabled/WildCards",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 1450,
                        Radius = 40,
                        MissileSpeed = 1000,
                        DangerValue = 2,
                        IsDangerous = false,
                        ObjectCreationName = "SealFateMissile"
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Acid Hunter",
                        ChampionName = "Urgot",
                        SpellName = "UrgotHeatseekingLineMissile",
                        Slot = SpellSlot.Q,
                        Delay = 125,
                        Range = 1000,
                        Radius = 60,
                        MissileSpeed = 1600,
                        DangerValue = 2,
                        IsDangerous = false,
                        ObjectCreationName = "UrgotHeatseekingLineMissile",
                        MinionCollision = true
                    }
                },
                new CircularSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Noxian Corrosive Charge",
                        ChampionName = "Urgot",
                        SpellName = "UrgotPlasmaGrenade",
                        Slot = SpellSlot.E,
                        Delay = 250,
                        Range = 900,
                        Radius = 250,
                        MissileSpeed = 1500,
                        DangerValue = 2,
                        IsDangerous = false,
                        ObjectCreationName = "UrgotPlasmaGrenadeBoom"
                    }
                },
                new CircularSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Hail of Arrows",
                        ChampionName = "Varus",
                        SpellName = "VarusE",
                        Slot = SpellSlot.E,
                        Delay = 1000,
                        Range = 925,
                        Radius = 235,
                        MissileSpeed = 1500,
                        DangerValue = 2,
                        IsDangerous = false,
                        ObjectCreationName = "VarusE"
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Piercing Arrow",
                        ChampionName = "Varus",
                        SpellName = "varusq",
                        Slot = SpellSlot.Q,
                        Delay = 0,
                        Range = 1600,
                        Radius = 75,
                        MissileSpeed = 1900,
                        DangerValue = 2,
                        IsDangerous = false,
                        ObjectCreationName = "VarusQMissile"
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Chain of Corruption",
                        ChampionName = "Varus",
                        SpellName = "VarusR",
                        Slot = SpellSlot.R,
                        Delay = 250,
                        Range = 1200,
                        Radius = 100,
                        MissileSpeed = 1950,
                        DangerValue = 3,
                        IsDangerous = true,
                        ObjectCreationName = "VarusRMissile"
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Baleful Strike",
                        ChampionName = "Veigar",
                        SpellName = "VeigarBalefulStrike",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 950,
                        Radius = 70,
                        MissileSpeed = 2000,
                        DangerValue = 2,
                        IsDangerous = false,
                        ObjectCreationName = "VeigarBalefulStrikeMis",
                        MinionCollision = true
                    }
                },
                new CircularSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Dark Matter",
                        ChampionName = "Veigar",
                        SpellName = "VeigarDarkMatter",
                        Slot = SpellSlot.W,
                        Delay = 1350,
                        Range = 900,
                        Radius = 225,
                        MissileSpeed = 0,
                        DangerValue = 2,
                        IsDangerous = false,
                        ObjectCreationName = "VeigarDarkMatter"
                    }
                },
                new VeigarE
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Event Horizon",
                        ChampionName = "Veigar",
                        SpellName = "VeigarEventHorizon",
                        Slot = SpellSlot.E,
                        Delay = 250,
                        Range = 700,
                        Radius = 320,
                        RingRadius = 150,
                        MissileSpeed = 0,
                        DangerValue = 4,
                        IsDangerous = true,
                        ObjectCreationName = "",
                        ForbidCrossing = true
                    }
                },
                //new CircularSkillshot
                //{
                //    OwnSpellData = new OwnSpellData
                //    {
                //        ChampionName = "Veigar",
                //        SpellName = "VeigarEventHorizon",
                //        Slot = SpellSlot.E,
                //        Delay = 500,
                //        Range = 700,
                //        Radius = 425,
                //        MissileSpeed = 0,
                //        DangerValue = 3,
                //        ObjectCreationName = "VeigarEventHorizon"
                //    }
                //},
                new CircularSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Tectonic Disruption",
                        ChampionName = "Velkoz",
                        SpellName = "VelkozE",
                        Slot = SpellSlot.E,
                        Delay = 500,
                        Range = 950,
                        Radius = 225,
                        MissileSpeed = 1500,
                        DangerValue = 2,
                        IsDangerous = false,
                        ObjectCreationName = "VelkozEMissile"
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Void Rift",
                        ChampionName = "Velkoz",
                        SpellName = "VelkozW",
                        Slot = SpellSlot.W,
                        Delay = 250,
                        Range = 1100,
                        Radius = 90,
                        MissileSpeed = 1700,
                        DangerValue = 2,
                        IsDangerous = false,
                        ObjectCreationName = "VelkozW"
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Plasma Fission (split)",
                        ChampionName = "Velkoz",
                        SpellName = "VelkozQMissileSplit",
                        Slot = SpellSlot.Q,
                        Delay = 0,
                        Range = 900,
                        Radius = 90,
                        MissileSpeed = 2100,
                        DangerValue = 2,
                        IsDangerous = false,
                        ObjectCreationName = "VelkozQMissileSplit",
                        MinionCollision = true
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Plasma Fission",
                        ChampionName = "Velkoz",
                        SpellName = "VelkozQ",
                        Slot = SpellSlot.Q,
                        Delay = 0,
                        Range = 1200,
                        Radius = 90,
                        MissileSpeed = 1300,
                        DangerValue = 2,
                        IsDangerous = false,
                        ObjectCreationName = "VelkozQMissile",
                        MinionCollision = true
                    }
                },
                //new LinearSkillshot
                //{
                //    OwnSpellData = new OwnSpellData
                //    {
                //        ChampionName = "Vi",
                //        SpellName = "ViQMissile",
                //        Slot = SpellSlot.Q,
                //        Delay = 250,
                //        Range = 725,
                //        Radius = 90,
                //        MissileSpeed = 1500,
                //        DangerValue = 3,
                //        ObjectCreationName = "ViQMissile"
                //    }
                //},
                //new LinearSkillshot //Unknown:
                //{
                //    OwnSpellData = new OwnSpellData
                //    {
                //        ChampionName = "Viktor",
                //        SpellName = "ViktorDeathRay",
                //        Slot = SpellSlot.E,
                //        Delay = 0,
                //        Range = 800,
                //        Radius = 80,
                //        MissileSpeed = 780,
                //        DangerValue = 3,
                //        ObjectCreationName = "ViktorDeathRayMissile"
                //    }
                //},
                //new LinearSkillshot
                //{
                //    OwnSpellData = new OwnSpellData
                //    {
                //        ChampionName = "Viktor",
                //        SpellName = "ViktorDeathRay3",
                //        Slot = SpellSlot.E,
                //        Delay = 500,
                //        Range = 800,
                //        Radius = 80,
                //        MissileSpeed = 0,
                //        DangerValue = 3,
                //        ObjectCreationName = "ViktorDeathRay3"
                //    }
                //},
                //new LinearSkillshot
                //{
                //    OwnSpellData = new OwnSpellData
                //    {
                //        ChampionName = "Viktor",
                //        SpellName = "ViktorDeathRay2",
                //        Slot = SpellSlot.E,
                //        Delay = 0,
                //        Range = 800,
                //        Radius = 80,
                //        MissileSpeed = 1500,
                //        DangerValue = 3,
                //        ObjectCreationName = "ViktorDeathRayMissile2"
                //    }
                //},
                //new CircularSkillshot
                //{
                //    OwnSpellData = new OwnSpellData
                //    {
                //        ChampionName = "Viktor",
                //        SpellName = "ViktorGravitonField",
                //        Slot = SpellSlot.W,
                //        Delay = 1500,
                //        Range = 625,
                //        Radius = 300,
                //        MissileSpeed = 0,
                //        DangerValue = 3,
                //        ObjectCreationName = "ViktorGravitonField"
                //    }
                //},
                new CircularSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Hemoplague",
                        ChampionName = "Vladimir",
                        SpellName = "VladimirHemoplague",
                        Slot = SpellSlot.R,
                        Delay = 389,
                        Range = 700,
                        Radius = 375,
                        MissileSpeed = 0,
                        DangerValue = 3,
                        IsDangerous = false,
                        ObjectCreationName = "VladimirHemoplague"
                    }
                },
                new CircularSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Eye of Destruction",
                        ChampionName = "Xerath",
                        SpellName = "XerathArcaneBarrage2",
                        Slot = SpellSlot.W,
                        Delay = 700,
                        Range = 1100,
                        Radius = 270,
                        MissileSpeed = 0,
                        DangerValue = 2,
                        IsDangerous = false,
                        ObjectCreationName = "XerathArcaneBarrage2"
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Arcanopulse",
                        ChampionName = "Xerath",
                        SpellName = "xeratharcanopulse2",
                        Slot = SpellSlot.Q,
                        Delay = 500,
                        Range = 1525,
                        Radius = 80,
                        MissileSpeed = 0,
                        DangerValue = 2,
                        IsDangerous = false,
                        ObjectCreationName = "xeratharcanopulse2"
                    }
                },
                new CircularSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Rite of the Arcane",
                        ChampionName = "Xerath",
                        SpellName = "xerathrmissilewrapper",
                        Slot = SpellSlot.R,
                        Delay = 700,
                        Range = 5600,
                        Radius = 200,
                        MissileSpeed = 0,
                        DangerValue = 2,
                        IsDangerous = false,
                        ObjectCreationName = "xerathrmissilewrapper"
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Shocking Orb",
                        ChampionName = "Xerath",
                        SpellName = "XerathMageSpear",
                        Slot = SpellSlot.E,
                        Delay = 200,
                        Range = 1125,
                        Radius = 60,
                        MissileSpeed = 1400,
                        DangerValue = 2,
                        IsDangerous = true,
                        ObjectCreationName = "XerathMageSpearMissile"
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Steel Tempest (tornado)",
                        ChampionName = "Yasuo",
                        SpellName = "YasuoQ3/disabled",
                        Slot = SpellSlot.Q,
                        Delay = 400,
                        Range = 1150,
                        Radius = 90,
                        MissileSpeed = 1500,
                        DangerValue = 3,
                        ObjectCreationName = "YasuoQ3Mis"
                    }
                },             
                new YasuoQ
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Steel Tempest (tornado)",
                        ChampionName = "Yasuo",
                        SpellName = "YasuoQ3",
                        Slot = SpellSlot.Q,
                        Delay = 100,
                        Range = 1150,
                        Radius = 90,
                        MissileSpeed = 1500,
                        DangerValue = 3,
                        ObjectCreationName = "YasuoQ3Mis/disabled"
                    }
                },
                new YasuoQ
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Steel Tempest 1",
                        ChampionName = "Yasuo",
                        SpellName = "YasuoQ",
                        Slot = SpellSlot.Q,
                        Delay = 400,
                        Range = 550,
                        Radius = 40,
                        MissileSpeed = 0,
                        DangerValue = 2,
                        IsDangerous = true,
                        ObjectCreationName = "yasuoq"
                    }
                },
                new YasuoQ
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Steel Tempest 2",
                        ChampionName = "Yasuo",
                        SpellName = "YasuoQ2",
                        Slot = SpellSlot.Q,
                        Delay = 400,
                        Range = 550,
                        Radius = 40,
                        MissileSpeed = 0,
                        DangerValue = 2,
                        IsDangerous = true,
                        ObjectCreationName = "yasuoq2"
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Razor Shuriken",
                        ChampionName = "Zed",
                        SpellName = "ZedQ",
                        Slot = SpellSlot.Q,
                        Delay = 300,
                        Range = 925,
                        Radius = 50,
                        MissileSpeed = 1700,
                        DangerValue = 2,
                        IsDangerous = false,
                        ObjectCreationName = "ZedQMissile"
                    }
                },
                //new CircularSkillshot
                //{
                //    OwnSpellData = new OwnSpellData
                //    {
                //        ChampionName = "Zed",
                //        SpellName = "ZedPBAOEDummy",
                //        Slot = SpellSlot.E,
                //        Delay = 0,
                //        Range = 290,
                //        Radius = 290,
                //        MissileSpeed = 0,
                //        DangerValue = 3,
                //        ObjectCreationName = "ZedPBAOEDummy"
                //    }
                //},
                new CircularSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        ChampionName = "Ziggs",
                        SpellName = "ZiggsE",
                        Slot = SpellSlot.E,
                        Delay = 250,
                        Range = 2000,
                        Radius = 235,
                        MissileSpeed = 3000,
                        DangerValue = 3,
                        ObjectCreationName = "ZiggsE"
                    }
                },
                new CircularSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        ChampionName = "Ziggs",
                        SpellName = "ZiggsW",
                        Slot = SpellSlot.W,
                        Delay = 250,
                        Range = 2000,
                        Radius = 275,
                        MissileSpeed = 3000,
                        DangerValue = 3,
                        ObjectCreationName = "ZiggsW"
                    }
                },
                new CircularSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Bouncing Bomb",
                        ChampionName = "Ziggs",
                        SpellName = "ZiggsQ",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 850,
                        Radius = 150,
                        MissileSpeed = 1700,
                        DangerValue = 2,
                        IsDangerous = false,
                        ObjectCreationName = "ZiggsQSpell"
                    }
                },
                new CircularSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Bouncing Bomb 2",
                        ChampionName = "Ziggs",
                        SpellName = "ZiggsQ",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 850,
                        Radius = 150,
                        MissileSpeed = 1700,
                        DangerValue = 2,
                        IsDangerous = false,
                        ObjectCreationName = "ZiggsQSpell2"
                    }
                },
                new CircularSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Bouncing Bomb 3",
                        ChampionName = "Ziggs",
                        SpellName = "ZiggsQ",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 850,
                        Radius = 150,
                        MissileSpeed = 1700,
                        DangerValue = 2,
                        IsDangerous = false,
                        ObjectCreationName = "ZiggsQSpell3"
                    }
                },
                new CircularSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Mega Inferno Bomb",
                        ChampionName = "Ziggs",
                        SpellName = "ZiggsR",
                        Slot = SpellSlot.R,
                        Delay = 1500,
                        Range = 5300,
                        Radius = 550,
                        MissileSpeed = 1500,
                        DangerValue = 3,
                        ObjectCreationName = "ZiggsR"
                    }
                },
                new CircularSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Time Bomb",
                        ChampionName = "Zilean",
                        SpellName = "ZileanQ",
                        Slot = SpellSlot.Q,
                        Delay = 300,
                        Range = 900,
                        Radius = 250,
                        MissileSpeed = 2000,
                        DangerValue = 2,
                        IsDangerous = false,
                        ObjectCreationName = "ZileanQ"
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Grasping Roots",
                        ChampionName = "Zyra",
                        SpellName = "ZyraE",
                        Slot = SpellSlot.E,
                        Delay = 250,
                        Range = 1150,
                        Radius = 90,
                        MissileSpeed = 1150,
                        DangerValue = 3,
                        IsDangerous = true,
                        ObjectCreationName = "ZyraEMissile",
                    }
                },
                new LinearSkillshot
                {
                        OwnSpellData = new SpellData
                        {
                            DisplayName = "Deadly Bloom",
                            ChampionName = "Zyra",
                            SpellName = "ZyraQ",
                            Slot = SpellSlot.Q,
                            Delay = 850,
                            Range = 800,
                            Radius = 140,
                            MissileSpeed = 0,
                            DangerValue = 2,
                            IsDangerous = false,
                            IsPerpendicular = true,
                            SecondaryRadius = 400,
                        }
                },
                new CircularSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Stranglethorns",
                        ChampionName = "Zyra",
                        SpellName = "ZyraBrambleZone",
                        Slot = SpellSlot.R,
                        Delay = 500,
                        Range = 700,
                        Radius = 525,
                        MissileSpeed = 0,
                        DangerValue = 5,
                        IsDangerous = true,
                        ObjectCreationName = "ZyraBrambleZone"
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Tentacle Smash",
                        ChampionName = "Illaoi",
                        SpellName = "IllaoiQ",
                        Slot = SpellSlot.Q,
                        Delay = 750,
                        Range = 850,
                        Radius = 100,
                        MissileSpeed = 0,
                        DangerValue = 3,
                        IsDangerous = true,
                        ObjectCreationName = "illaoiemis"
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Test of Spirit",
                        ChampionName = "Illaoi",
                        SpellName = "IllaoiE",
                        Slot = SpellSlot.E,
                        Delay = 250,
                        Range = 950,
                        Radius = 50,
                        MissileSpeed = 1900,
                        DangerValue = 3,
                        IsDangerous = true,
                        ObjectCreationName = "illaoiemis"
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "End of the Line",
                        ChampionName = "Graves",
                        SpellName = "GravesQLineSpell",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 808,
                        Radius = 40,
                        MissileSpeed = 3000,
                        DangerValue = 2,
                        IsDangerous = false,
                        ObjectCreationName = "GravesQLineMis"
                    }
                },
                //new ConeSkillshot
                //{
                //    OwnSpellData = new SpellData
                //    {
                //        DisplayName = "Heartseeker",
                //        ChampionName = "Pantheon",
                //        SpellName = "PantheonE",
                //        Slot = SpellSlot.W,
                //        Delay = 500,
                //        Range = 430,
                //        Radius = 100,
                //        MissileSpeed = 0,
                //        DangerValue = 2,
                //        IsDangerous = false,
                //        ObjectCreationName = "Heartseeker",
                //        ConeAngle = 35
                //    }
                //},
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Hammer Shock",
                        ChampionName = "Poppy",
                        SpellName = "PoppyQ",
                        Slot = SpellSlot.Q,
                        Delay = 500,
                        Range = 430,
                        Radius = 100,
                        MissileSpeed = 0,
                        DangerValue = 2,
                        IsDangerous = false,
                        ObjectCreationName = "PoppyQ"
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Deadly Flourish",
                        ChampionName = "Jhin",
                        SpellName = "JhinW",
                        Slot = SpellSlot.W,
                        Delay = 250,
                        Range = 3000,
                        Radius = 40,
                        MissileSpeed = 5000,
                        DangerValue = 2,
                        IsDangerous = false,
                        ObjectCreationName = "JhinWMissile"
                    }
                },
                new LinearSkillshot
                {
                    OwnSpellData = new SpellData
                    {
                        DisplayName = "Curtain Call",
                        ChampionName = "Jhin",
                        SpellName = "JhinRShot",
                        Slot = SpellSlot.R,
                        Delay = 250,
                        Range = 3500,
                        Radius = 80,
                        MissileSpeed = 5000,
                        DangerValue = 2,
                        IsDangerous = false,
                        ObjectCreationName = "JhinRShotMis"
                    }
                }
            };
        }
    }
}
