using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using AutoBuddy.Humanizers;
using AutoBuddy.MainLogics;
using AutoBuddy.MyChampLogic;
using AutoBuddy.Utilities;
using AutoBuddy.Utilities.AutoLvl;
using AutoBuddy.Utilities.AutoShop;
using EloBuddy;
using EloBuddy.Sandbox;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using SharpDX;
using Version = System.Version;

namespace AutoBuddy
{
    internal static class Program
    {
        private static AIHeroClient myHero
        {
            get { return Player.Instance; }
        }
        private static Menu menu;
        private static string loadTextureDir = SandboxConfig.DataDirectory + "AutoBuddy\\";
        private static IChampLogic myChamp;
        private static LogicSelector Logic { get; set; }
        public static Item BlackSpear;
        public static int hpvaluePot;
        public static void Main()
        {
            Hacks.RenderWatermark = false;
            if (File.Exists(loadTextureDir + "loadTexture"))
            {
                Hacks.DisableTextures = true;
                ManagedTexture.OnLoad += (args) => { args.Process = false; };
            }
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }

        private static void Loading_OnLoadingComplete(EventArgs args)
        {
            //AutoBlack Spear
            if (myHero.Hero == Champion.Kalista)
            {
                BlackSpear = new Item(ItemId.The_Black_Spear);
                Chat.Print("Auto Black Spear loaded! Thanks @Enelx");
                Game.OnUpdate += On_Update;
            }
            //Causes freeze
            //Telemetry.Init(Path.Combine(SandboxConfig.DataDirectory
            //, "AutoBuddy"));
            
            //STILL BROKEN ;(
            //createFS();
            Version v = Assembly.GetExecutingAssembly().GetName().Version;
            string ABVersion = v.Major + "." + v.MajorRevision + "." + v.Minor + "." + v.MinorRevision;

            Chat.Print("AutoBuddy:", System.Drawing.Color.White);
            Chat.Print("Loaded Version: " + ABVersion, System.Drawing.Color.LimeGreen);
            Chat.Print("AutoBuddy: Starting in 5 seconds.");
            Core.DelayAction(Start, 5000);
            menu = MainMenu.AddMenu("AUTOBUDDY", "AB");
            menu.Add("sep1", new Separator(1));
            CheckBox c =
                new CheckBox("Call mid, will leave if other player stays on mid(only auto lane)", true);
            PropertyInfo property2 = typeof(CheckBox).GetProperty("Size");
            property2.GetSetMethod(true).Invoke(c, new object[] { new Vector2(500, 20) });
            menu.Add("mid", c);
            Slider s = menu.Add("lane", new Slider(" ", 1, 1, 4));
            string[] lanes =
            {
                "", "Selected lane: Auto", "Selected lane: Top", "Selected lane: Mid",
                "Selected lane: Bot"
            };
            s.DisplayName = lanes[s.CurrentValue];
            s.OnValueChange +=
                delegate(ValueBase<int> sender, ValueBase<int>.ValueChangeArgs changeArgs)
                {
                    sender.DisplayName = lanes[changeArgs.NewValue];
                };
            menu.Add("reselectlane", new CheckBox("Reselect lane", false));
            menu.Add("disablepings", new CheckBox("Disable pings", false));
            menu.Add("disablechat", new CheckBox("Disable chat", false));
            CheckBox newpf = new CheckBox("Use smart pathfinder", true);
            menu.Add("newPF", newpf);
            Slider hpValue = menu.Add("HPPot", new Slider("Minimum HP% to use Health Pot?", 43, 1, 100));
            hpvaluePot = hpValue.CurrentValue;
            hpValue.OnValueChange +=
                delegate(ValueBase<int> sender, ValueBase<int>.ValueChangeArgs changeArgs)
                {
                    hpvaluePot = hpValue.CurrentValue;
                };
            newpf.OnValueChange += newpf_OnValueChange;
            menu.AddSeparator(10);
            menu.AddLabel("Turn on to improve RAM usage.");
            CheckBox noTextures = new CheckBox("Don't load textures. Restart LoL to apply.");
            menu.Add("noTextures", noTextures);
            noTextures.OnValueChange += noTextures_OnValueChange;
            menu.Add("sep2", new Separator(10));
            menu.AddLabel("Champ will follow cursor. DON'T turn on if you are botting!");
            menu.Add("disableAutoBuddy", new CheckBox("Disable AutoBuddy Movement. F5 to apply.", false));
            menu.AddSeparator(5);
            CheckBox autoclose = new CheckBox("Auto close lol when the game ends. F5 to apply", false);
            property2.GetSetMethod(true).Invoke(autoclose, new object[] { new Vector2(500, 20) });
            menu.Add("autoclose", autoclose);
            menu.AddSeparator(5);
            menu.Add("oldWalk", new CheckBox("Use old orbwalking. F5 to apply", false));
            menu.Add("debuginfo", new CheckBox("Draw debug info. F5 to apply", true));
            menu.Add("l1", new Label("By Christian Brutal Sniper - Maintained by TheYasuoMain"));
            menu.Add("l2", new Label("Version: " + ABVersion));
        }

        static void newpf_OnValueChange(ValueBase<bool> sender, ValueBase<bool>.ValueChangeArgs args)
        {
            AutoWalker.newPF = args.NewValue;
        }
        static void noTextures_OnValueChange(ValueBase<bool> sender, ValueBase<bool>.ValueChangeArgs args)
        {
            //Creates a file so that AutoBuddy can check on load if the user doesn't want textures.. :) Thanks @Finndev!
            try
            {
                if (!Directory.Exists(loadTextureDir))
                {
                    Directory.CreateDirectory(loadTextureDir);
                }
                if (MainMenu.GetMenu("AB").Get<CheckBox>("noTextures").CurrentValue == true)
                {
                    if (!File.Exists(loadTextureDir + "loadTexture"))
                    {
                        File.Create(loadTextureDir + "loadTexture");
                    }
                }
                if (MainMenu.GetMenu("AB").Get<CheckBox>("noTextures").CurrentValue == false)
                {
                    if (File.Exists(loadTextureDir + "loadTexture"))
                    {
                        File.Delete(loadTextureDir + "loadTexture");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Load Texture Error: '{0}'", e);
            }
        }

        //For Kalista
        private static void On_Update(EventArgs args)
        {

            if (BlackSpear.IsOwned())
            {
                foreach (AIHeroClient ally in EntityManager.Heroes.Allies)
                {
                    if (ally != null)
                    {
                        Console.Write("Searching for target");
                        BlackSpear.Cast(ally);
                    }
                }
            }
        }
        //For Kalista

        private static void Start()
        {
            RandGen.Start();
            bool generic = false;
            switch (ObjectManager.Player.Hero)
            {
                case Champion.Ashe:
                    myChamp = new Ashe();
                    break;
                case Champion.Caitlyn:
                    myChamp = new Caitlyn();
                    break;
                default:
                    generic = true;
                    myChamp = new Generic();
                    break;
                case Champion.Ezreal:
                    myChamp = new Ezreal();
                    break;
                case Champion.Cassiopeia:
                    myChamp = new Cassiopeia();
                    break;
                case Champion.Ryze:
                    myChamp = new Ryze();
                    break;
                case Champion.Soraka:
                    myChamp = new Soraka();
                    break;
                case Champion.Kayle:
                    myChamp = new Kayle();
                    break;
                case Champion.Tristana:
                    myChamp = new Tristana();
                    break;
                case Champion.Sivir:
                    myChamp = new Sivir();
                    break;
                case Champion.Ahri:
                    myChamp = new Ahri();
                    break;
                case Champion.Anivia:
                    myChamp = new Anivia();
                    break;
                case Champion.Annie:
                    myChamp = new Annie();
                    break;
                case Champion.Corki:
                    myChamp = new Corki();
                    break;
                case Champion.Brand:
                    myChamp = new Brand();
                    break;
                case Champion.Azir:
                    myChamp = new Azir();
                    break;
                case Champion.Xerath:
                    myChamp = new Xerath();
                    break;
                case Champion.Morgana:
                    myChamp = new Morgana();
                    break;
                case Champion.Draven:
                    myChamp = new Draven();
                    break;
                case Champion.Twitch:
                    myChamp = new Twitch();
                    break;
                case Champion.Kalista:
                    myChamp = new Kalista();
                    break;
                case Champion.Velkoz:
                    myChamp = new Velkoz();
                    break;
                case Champion.Leblanc:
                    myChamp = new Leblanc();
                    break;
                case Champion.Jinx:
                    myChamp = new Jinx();
                    break;
                case Champion.Katarina:
                    myChamp = new Katarina();
                    break;
                case Champion.Nidalee:
                    myChamp = new Nidalee();
                    break;
            }
            CustomLvlSeq cl = new CustomLvlSeq(menu, AutoWalker.p, Path.Combine(SandboxConfig.DataDirectory
            , "AutoBuddy\\Skills"));
            if (!generic)
            {
                BuildCreator bc = new BuildCreator(menu, Path.Combine(SandboxConfig.DataDirectory
                    , "AutoBuddy\\Builds"), myChamp.ShopSequence);
            }


            else
            {
                myChamp = new Generic();
                if (MainMenu.GetMenu("AB_" + ObjectManager.Player.ChampionName) != null &&
                    MainMenu.GetMenu("AB_" + ObjectManager.Player.ChampionName).Get<Label>("shopSequence") != null)
                {
                    Chat.Print("Autobuddy: Loaded shop plugin for " + ObjectManager.Player.ChampionName);
                    BuildCreator bc = new BuildCreator(menu, Path.Combine(SandboxConfig.DataDirectory
                        , "AutoBuddy\\Builds"),
                        MainMenu.GetMenu("AB_" + ObjectManager.Player.ChampionName)
                            .Get<Label>("shopSequence")
                            .DisplayName);
                }
                else
                {
                    BuildCreator bc = new BuildCreator(menu, Path.Combine(SandboxConfig.DataDirectory
                        , "AutoBuddy\\Builds"), myChamp.ShopSequence);
                }
            }
            Logic = new LogicSelector(myChamp, menu);
            new Disrespekt();
            Telemetry.SendEvent("GameStart", new Dictionary<string, string>()
            {
                {"GameChamp", AutoWalker.p.ChampionName},
                {"GameType", BrutalExtensions.GetGameType()},
                {"GameRegion", Game.Region},
                {"GameID", ""+AutoWalker.GameID},
            });
        }

        private static void createFS()
        {
            try
            {
                if (!Directory.Exists(SandboxConfig.DataDirectory + "\\AutoBuddy"))
                {
                    System.IO.Directory.CreateDirectory(SandboxConfig.DataDirectory + "\\AutoBuddy");

                }
                if (!Directory.Exists(SandboxConfig.DataDirectory + "\\AutoBuddy\\Builds"))
                {
                    System.IO.Directory.CreateDirectory(SandboxConfig.DataDirectory + "\\AutoBuddy\\Builds");
                }
                if (!Directory.Exists(SandboxConfig.DataDirectory + "\\AutoBuddy\\Skills"))
                {
                    System.IO.Directory.CreateDirectory(SandboxConfig.DataDirectory + "\\AutoBuddy\\Skills");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("CreateFS Error: '{0}'", e);
            }
        }
    }
}
