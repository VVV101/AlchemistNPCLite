using Microsoft.Xna.Framework;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using Terraria.UI;
using Terraria.DataStructures;
using Terraria.GameContent.UI;
using AlchemistNPCLite.Items;
using AlchemistNPCLite.Interface;

namespace AlchemistNPCLite
{
    public class AlchemistNPCLite : Mod
    {
        public AlchemistNPCLite()
        {
            ;
        }

        public static Mod Instance;
        internal static AlchemistNPCLite instance;
        internal static ModConfiguration modConfiguration;
        public static ModKeybind DiscordBuff;
        public static bool SF = false;
        public static bool GreaterDangersense = false;
        public static int DTH = 0;
        public static float ppx = 0f;
        public static float ppy = 0f;
        public static string GithubUserName { get { return "VVV101"; } }
        public static string GithubProjectName { get { return "AlchemistNPCLite"; } }
        public static int ReversivityCoinTier1ID;
        public static int ReversivityCoinTier2ID;
        public static int ReversivityCoinTier3ID;
        public static int ReversivityCoinTier4ID;
        public static int ReversivityCoinTier5ID;
        public static int ReversivityCoinTier6ID;
        private UserInterface alchemistUserInterface;
        internal ShopChangeUI alchemistUI;
        private UserInterface alchemistUserInterfaceA;
        internal ShopChangeUIA alchemistUIA;
        private UserInterface alchemistUserInterfaceO;
        internal ShopChangeUIO alchemistUIO;
        private UserInterface alchemistUserInterfaceM;
        internal ShopChangeUIM alchemistUIM;

        public override void Load()
        {
            Instance = this;
            string DiscordBuffTeleportation = Language.GetTextValue("Discord Buff Teleportation");
            DiscordBuff = KeybindLoader.RegisterKeybind(this, DiscordBuffTeleportation, "Q");
            SetTranslation();
            instance = this;
            if (!Main.dedServ)
            {
                alchemistUI = new ShopChangeUI();
                alchemistUI.Activate();
                alchemistUserInterface = new UserInterface();
                alchemistUserInterface.SetState(alchemistUI);

                alchemistUIA = new ShopChangeUIA();
                alchemistUIA.Activate();
                alchemistUserInterfaceA = new UserInterface();
                alchemistUserInterfaceA.SetState(alchemistUIA);

                alchemistUIO = new ShopChangeUIO();
                alchemistUIO.Activate();
                alchemistUserInterfaceO = new UserInterface();
                alchemistUserInterfaceO.SetState(alchemistUIO);

                alchemistUIM = new ShopChangeUIM();
                alchemistUIM.Activate();
                alchemistUserInterfaceM = new UserInterface();
                alchemistUserInterfaceM.SetState(alchemistUIM);
            }
        }

        // IMPLEMENT WHEN WEAKREFERENCES FIXED
        /*
		public override void PostSetupContent()
		{
		    Mod censusMod = ModLoader.GetMod("Census");
			if(censusMod != null)
			{
				censusMod.Call("TownNPCCondition", NPCType("Alchemist"), "Defeat Eye of Cthulhu");
				censusMod.Call("TownNPCCondition", NPCType<NPCs.Alchemist>(), "Defeat Eye of Cthulhu");
				censusMod.Call("TownNPCCondition", NPCType<NPCs.Brewer>(), "Defeat Eye of Cthulhu");
				censusMod.Call("TownNPCCondition", NPCType<NPCs.Jeweler>(), "Defeat Eye of Cthulhu");
				censusMod.Call("TownNPCCondition", NPCType<NPCs.Architect>(), "Have any 3 other NPC present");
				censusMod.Call("TownNPCCondition", NPCType<NPCs.Operator>(), "Defeat Eater of Worlds/Brain of Cthulhu");
				censusMod.Call("TownNPCCondition", NPCType<NPCs.Musician>(), "Defeat Skeletron");
				censusMod.Call("TownNPCCondition", NPCType<NPCs.YoungBrewer>(), "World state is Hardmode and both Alchemist and Operator are alive");
			}
		}
        */

        public override void Unload()
        {
            Instance = null;
            instance = null;
            DiscordBuff = null;
            modConfiguration = null;
        }

        public override void AddRecipeGroups()
        {
            //SBMW:Add translation to RecipeGroups, also requires to reload mod
            string evilBossMask = Language.GetTextValue("Mods.AlchemistNPCLite.evilBossMask");
            string cultist = Language.GetTextValue("Mods.AlchemistNPCLite.cultist");
            string tier3HardmodeBar = Language.GetTextValue("Mods.AlchemistNPCLite.tier3HardmodeBar");
            string hardmodeComponent = Language.GetTextValue("Mods.AlchemistNPCLite.hardmodeComponent");
            string evilBar = Language.GetTextValue("Mods.AlchemistNPCLite.evilBar");
            string evilMushroom = Language.GetTextValue("Mods.AlchemistNPCLite.evilMushroom");
            string evilComponent = Language.GetTextValue("Mods.AlchemistNPCLite.evilComponent");
            string evilDrop = Language.GetTextValue("Mods.AlchemistNPCLite.evilDrop");
            string tier2anvil = Language.GetTextValue("Mods.AlchemistNPCLite.tier2anvil");
            string tier2forge = Language.GetTextValue("Mods.AlchemistNPCLite.tier2forge");
            string tier1anvil = Language.GetTextValue("Mods.AlchemistNPCLite.tier1anvil");
            string celestialWings = Language.GetTextValue("Mods.AlchemistNPCLite.CelestialWings");
            string LunarHamaxe = Language.GetTextValue("Mods.AlchemistNPCLite.LunarHamaxe");
            string tier3Watch = Language.GetTextValue("Mods.AlchemistNPCLite.tier3Watch");

            RecipeGroup group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + evilBossMask, new int[]
         {
                 ItemID.EaterMask, ItemID.BrainMask
         });
            RecipeGroup.RegisterGroup("AlchemistNPCLite:EvilMask", group);
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + cultist, new int[]
         {
                 ItemID.BossMaskCultist, ItemID.WhiteLunaticHood, ItemID.BlueLunaticHood
         });
            RecipeGroup.RegisterGroup("AlchemistNPCLite:CultistMask", group);
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + tier3HardmodeBar, new int[]
         {
                 ItemID.AdamantiteBar, ItemID.TitaniumBar
         });
            RecipeGroup.RegisterGroup("AlchemistNPCLite:Tier3Bar", group);
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + hardmodeComponent, new int[]
         {
                 ItemID.CursedFlame, ItemID.Ichor
         });
            RecipeGroup.RegisterGroup("AlchemistNPCLite:HardmodeComponent", group);
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + evilBar, new int[]
         {
                 ItemID.DemoniteBar, ItemID.CrimtaneBar
         });
            RecipeGroup.RegisterGroup("AlchemistNPCLite:EvilBar", group);
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + evilMushroom, new int[]
             {
                 ItemID.VileMushroom, ItemID.ViciousMushroom
             });
            RecipeGroup.RegisterGroup("AlchemistNPCLite:EvilMush", group);
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + evilComponent, new int[]
             {
                 ItemID.ShadowScale, ItemID.TissueSample
             });
            RecipeGroup.RegisterGroup("AlchemistNPCLite:EvilComponent", group);
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + evilDrop, new int[]
             {
                 ItemID.RottenChunk, ItemID.Vertebrae
             });
            RecipeGroup.RegisterGroup("AlchemistNPCLite:EvilDrop", group);
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + tier2anvil, new int[]
             {
                 ItemID.MythrilAnvil, ItemID.OrichalcumAnvil
             });
            RecipeGroup.RegisterGroup("AlchemistNPCLite:AnyAnvil", group);
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + tier2forge, new int[]
             {
                 ItemID.AdamantiteForge, ItemID.TitaniumForge
             });
            RecipeGroup.RegisterGroup("AlchemistNPCLite:AnyForge", group);
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + tier1anvil, new int[]
             {
                 ItemID.IronAnvil, ItemID.LeadAnvil
             });
            RecipeGroup.RegisterGroup("AlchemistNPCLite:AnyPreHMAnvil", group);
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + celestialWings, new int[]
             {
                 ItemID.WingsSolar, ItemID.WingsNebula, ItemID.WingsStardust, ItemID.WingsVortex
             });
            RecipeGroup.RegisterGroup("AlchemistNPCLite:AnyCelestialWings", group);
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + LunarHamaxe, new int[]
             {
                 ItemID.LunarHamaxeSolar, ItemID.LunarHamaxeNebula, ItemID.LunarHamaxeStardust, ItemID.LunarHamaxeVortex
             });
            RecipeGroup.RegisterGroup("AlchemistNPCLite:AnyLunarHamaxe", group);
            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + tier3Watch, new int[]
             {
                 ItemID.GoldWatch, ItemID.PlatinumWatch
             });
            RecipeGroup.RegisterGroup("AlchemistNPCLite:AnyWatch", group);

        }

        public override void HandlePacket(BinaryReader reader, int whoAmI)
        {
            AlchemistNPCLiteMessageType msgType = (AlchemistNPCLiteMessageType)reader.ReadByte();
            switch (msgType)
            {
                case AlchemistNPCLiteMessageType.TeleportPlayer:
                    TeleportClass.HandleTeleport(reader.ReadInt32(), true, whoAmI);
                    break;
                default:
                    Logger.Error("AlchemistNPCLite: Unknown Message type: " + msgType);
                    break;
            }
        }

        public enum AlchemistNPCLiteMessageType : byte
        {
            TeleportPlayer
        }

        public override void AddRecipes()
        {
            CreateRecipe(ItemID.Sundial)
                .AddIngredient(ItemID.CelestialStone)
                .AddIngredient(ItemID.GoldBar, 10)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();

            CreateRecipe(ItemID.Obsidian, 5)
                .AddIngredient(ItemID.StoneBlock, 10)
                .AddCondition(Recipe.Condition.NearWater)
                .AddCondition(Recipe.Condition.NearLava)
                .Register();

            CreateRecipe(ItemID.HoneyBlock, 5)
                .AddIngredient(ItemID.BottledHoney, 10)
                .AddCondition(Recipe.Condition.NearWater)
                .AddCondition(Recipe.Condition.NearHoney)
                .Register();

            CreateRecipe(ItemID.CrispyHoneyBlock, 5)
                .AddIngredient(ItemID.BottledHoney, 10)
                .AddCondition(Recipe.Condition.NearLava)
                .AddCondition(Recipe.Condition.NearHoney)
                .Register();

            CreateRecipe(ItemID.Stopwatch)
                .AddRecipeGroup("AlchemistNPCLite:AnyWatch")
                .AddIngredient(ItemID.HermesBoots)
                .AddIngredient(ItemID.Wire, 15)
                .AddIngredient(ItemID.Wood, 5)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();

            CreateRecipe(ItemID.DPSMeter)
                .AddRecipeGroup("AlchemistNPCLite:EvilBar", 10)
                .AddRecipeGroup("AlchemistNPCLite:AnyWatch")
                .AddIngredient(ItemID.Wire, 25)
                .AddIngredient(ItemID.Chain)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();

            CreateRecipe(ItemID.LifeformAnalyzer)
                .AddIngredient(ItemID.TallyCounter)
                .AddIngredient(ItemID.BlackLens)
                .AddIngredient(ItemID.AntlionMandible)
                .AddRecipeGroup("AlchemistNPCLite:EvilDrop")
                .AddRecipeGroup("AlchemistNPCLite:EvilComponent")
                .AddIngredient(ItemID.Feather)
                .AddIngredient(ItemID.TatteredCloth)
                .AddIngredient(ItemID.Bone)
                .AddIngredient(ItemID.Wire, 25)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();

            CreateRecipe(ItemID.PurificationPowder, 5)
                .AddIngredient(ItemID.Mushroom)
                .AddIngredient(ItemID.Daybloom)
                .AddTile(TileID.Bottles)
                .Register();

            CreateRecipe(ItemID.HallowedSeeds)
                .AddIngredient(ItemID.CorruptSeeds)
                .AddIngredient(ItemID.PurificationPowder)
                .AddIngredient(ItemID.PixieDust)
                .AddTile(TileID.Bottles)
                .Register();

            CreateRecipe(ItemID.HallowedSeeds)
                .AddIngredient(ItemID.CrimsonSeeds)
                .AddIngredient(ItemID.PurificationPowder)
                .AddIngredient(ItemID.PixieDust)
                .AddTile(TileID.Bottles)
                .Register();
        }

        //SBMW:Transtation method
        public void SetTranslation()
        {
            ModTranslation text = LocalizationLoader.CreateTranslation(this, "DiscordBuffTeleportation");
            text.SetDefault("Discord Buff Teleportation");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "混乱药剂传送");
            LocalizationLoader.AddTranslation(text);

            //SBMW:RecipeGroups
            text = LocalizationLoader.CreateTranslation("evilBossMask");
            text.SetDefault("Corruption/Crimson boss mask");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "腐化/血腥Boss面具");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("cultist");
            text.SetDefault("Cultist mask/hood");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "邪教徒面具/兜帽");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("tier3HardmodeBar");
            text.SetDefault("tier 3 Hardmode Bar");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "三级肉后锭(精金/钛金)");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("hardmodeComponent");
            text.SetDefault("Hardmode component");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("evilBar");
            text.SetDefault("Crimson/Corruption bar");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "魔金/血腥锭");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("evilMushroom");
            text.SetDefault("evil mushroom");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "邪恶蘑菇");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("evilComponent");
            text.SetDefault("evil component");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "邪恶材料(暗影鳞片/组织样本)");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("evilDrop");
            text.SetDefault("evil drop");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "邪恶掉落物(腐肉/椎骨)");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("tier2anvil");
            text.SetDefault("tier 2 anvil");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "二级砧(秘银/山铜砧)");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("tier2forge");
            text.SetDefault("tier 2 forge");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "二级熔炉(精金/钛金熔炉)");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("tier1anvil");
            text.SetDefault("tier 1 anvil");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "一级砧(铁/铅砧)");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("CelestialWings");
            text.SetDefault("Celestial Wings");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "四柱翅膀");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("LunarHamaxe");
            text.SetDefault("Lunar Hamaxe");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("tier3Watch");
            text.SetDefault("tier 3 Watch");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "三级表(金表/铂金表)");
            LocalizationLoader.AddTranslation(text);

            //SBMW:Vanilla
            text = LocalizationLoader.CreateTranslation("KingSlime");
            text.SetDefault("King Slime Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "史莱姆之王宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("EyeofCthulhu");
            text.SetDefault("Eye of Cthulhu Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "克苏鲁之眼宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("EaterOfWorlds");
            text.SetDefault("Eater Of Worlds Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "世界吞噬者宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("BrainOfCthulhu");
            text.SetDefault("Brain Of Cthulhu Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "克苏鲁之脑宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("QueenBee");
            text.SetDefault("Queen Bee Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "蜂后宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Skeletron");
            text.SetDefault("Skeletron Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "骷髅王宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("WallOfFlesh");
            text.SetDefault("Wall Of Flesh Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "血肉之墙宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Destroyer");
            text.SetDefault("Destroyer Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "机械蠕虫宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Twins");
            text.SetDefault("Twins Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "双子魔眼宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("SkeletronPrime");
            text.SetDefault("Skeletron Prime Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "机械骷髅王宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Plantera");
            text.SetDefault("Plantera Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "世纪之花宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Golem");
            text.SetDefault("Golem Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "石巨人宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Betsy");
            text.SetDefault("Betsy Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("DukeFishron");
            text.SetDefault("Duke Fishron Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "猪鲨公爵宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("MoonLord");
            text.SetDefault("Moon Lord Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "月亮领主宝藏袋");
            LocalizationLoader.AddTranslation(text);

            //SBMW:CalamityMod
            text = LocalizationLoader.CreateTranslation("DesertScourge");
            text.SetDefault("Desert Scourge Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "荒漠灾虫宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Crabulon");
            text.SetDefault("Crabulon Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "蘑菇螃蟹宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("HiveMind");
            text.SetDefault("The Hive Mind Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "腐巢意志宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Perforator");
            text.SetDefault("The Perforators Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "血肉宿主宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("SlimeGod");
            text.SetDefault("The Slime God Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "史莱姆之神宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Cryogen");
            text.SetDefault("Cryogen Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "极地之灵宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("BrimstoneElemental");
            text.SetDefault("Brimstone Elemental Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "硫磺火元素宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("AquaticScourge");
            text.SetDefault("Aquatic Scourge Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "渊海灾虫宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Calamitas");
            text.SetDefault("Calamitas Doppelganger Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "灾厄之眼宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("AstrageldonSlime");
            text.SetDefault("Astrum Aureus Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Звёздного Заразителя");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "大彗星史莱姆宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("AstrumDeus");
            text.SetDefault("Astrum Deus Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "星神吞噬者宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Leviathan");
            text.SetDefault("The Leviathan Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "利维坦宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("PlaguebringerGoliath");
            text.SetDefault("The Plaguebringer Goliath Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "瘟疫使者歌莉娅宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Ravager");
            text.SetDefault("Ravager Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "毁灭魔像宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Providence");
            text.SetDefault("Providence Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "亵渎天神宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Polterghast");
            text.SetDefault("Polterghast Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "噬魂幽花宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("OldDuke");
            text.SetDefault("The Old Duke Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Старого Герцога");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("DevourerofGods");
            text.SetDefault("The Devourer of Gods Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "神明吞噬者宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Bumblebirb");
            text.SetDefault("Bumblebirb Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "癫痫鸟宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Yharon");
            text.SetDefault("Jungle Dragon, Yharon Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "犽戎宝藏袋");
            LocalizationLoader.AddTranslation(text);

            //SBMW:ThoriumMod
            text = LocalizationLoader.CreateTranslation("DarkMage");
            text.SetDefault("Dark Mage Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Ogre");
            text.SetDefault("Ogre Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("ThunderBird");
            text.SetDefault("The Great Thunder Bird Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "惊雷王鹰宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("QueenJellyfish");
            text.SetDefault("The Queen Jellyfish Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "水母皇后宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("CountEcho");
            text.SetDefault("Count Echo Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "水母皇后宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("GraniteEnergyStorm");
            text.SetDefault("Granite Energy Storm Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "花岗岩流能风暴宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("TheBuriedChampion");
            text.SetDefault("The Buried Champion Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "英灵遗骸宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("TheStarScouter");
            text.SetDefault("The Star Scouter Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "星际监察者宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("BoreanStrider");
            text.SetDefault("Borean Strider Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "极地遁蛛宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("CoznixTheFallenBeholder");
            text.SetDefault("Coznix, The Fallen Beholder Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "堕落注视者·克兹尼格斯宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("TheLich");
            text.SetDefault("The Lich Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "巫妖宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("AbyssionTheForgottenOne");
            text.SetDefault("Abyssion, The Forgotten One Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "被遗忘者-深渊之主宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("TheRagnarok");
            text.SetDefault("The Ragnarok Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "灾难之灵宝藏袋");
            LocalizationLoader.AddTranslation(text);

            //Redemption
            text = LocalizationLoader.CreateTranslation("KingChicken");
            text.SetDefault("The Mighty King Chicken Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("ThornBane");
            text.SetDefault("Thorn, Bane of the Forest Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("TheKeeper");
            text.SetDefault("The Keeper Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("XenoCrystal");
            text.SetDefault("Xenomite Crystal Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("IEye");
            text.SetDefault("Infected Eye Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("KingSlayer");
            text.SetDefault("King Slayer III Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("V1");
            text.SetDefault("Vlitch Cleaver Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("V2");
            text.SetDefault("Vlitch Gigipede Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("V3");
            text.SetDefault("Omega Obliterator Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("PZ");
            text.SetDefault("Patient Zero Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("ThornRematch");
            text.SetDefault("Thorn, Bane of the Forest Rematch Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Nebuleus");
            text.SetDefault("Nebuleus, Angel of the Cosmos Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            //ElementsAwoken
            text = LocalizationLoader.CreateTranslation("Wasteland");
            text.SetDefault("Wasteland Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Infernace");
            text.SetDefault("Infernace Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("ScourgeFighter");
            text.SetDefault("Scourge Fighter Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Regaroth");
            text.SetDefault("Regaroth Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("TheCelestials");
            text.SetDefault("The Celestials Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Permafrost");
            text.SetDefault("Permafrost Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Obsidious");
            text.SetDefault("Obsidious Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Aqueous");
            text.SetDefault("Aqueous Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("TempleKeepers");
            text.SetDefault("The Temple Keepers Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Guardian");
            text.SetDefault("The Guardian Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Volcanox");
            text.SetDefault("Volcanox Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("VoidLevi");
            text.SetDefault("Void Leviathan Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Azana");
            text.SetDefault("Azana Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Ancients");
            text.SetDefault("The Ancients Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            //SacredTools
            text = LocalizationLoader.CreateTranslation("Decree");
            text.SetDefault("The Decree Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Декри");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "焚炎南瓜宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("FlamingPumpkin");
            text.SetDefault("The Flaming Pumpkin Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Горящей Тыквы");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Jensen");
            text.SetDefault("Jensen, the Grand Harpy Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Дженсен, Великой Гарпии");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "巨型鸟妖詹森宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Araneas");
            text.SetDefault("Araneas Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Аранеи");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Raynare");
            text.SetDefault("Harpy Queen, Raynare Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Рейнейр, Королевы Гарпий");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "鸟妖女王雷纳宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Primordia");
            text.SetDefault("Primordia Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Примордии");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Abaddon");
            text.SetDefault("Abaddon, the Emissary of Nightmares Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Абаддона, Эмиссара Кошмаров");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "梦魇使者亚巴顿宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Araghur");
            text.SetDefault("Araghur, the Flare Serpent Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Арагура, Огненного Змия");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "熔火巨蟒宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Lunarians");
            text.SetDefault("The Lunarians Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Лунарианов");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "月军宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Challenger");
            text.SetDefault("Erazor Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Ирэйзора");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "堕落帝者宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Challenger");
            text.SetDefault("Erazor Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Ирэйзора");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "堕落帝者宝藏袋");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Spookboi");
            text.SetDefault("Nihilus Treasure Bag");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сумка Нигилюса");
            LocalizationLoader.AddTranslation(text);

            //SpiritMod
            text = LocalizationLoader.CreateTranslation("Scarabeus");
            text.SetDefault("Scarabeus Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Bane");
            text.SetDefault("Vinewrath Bane Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Flier");
            text.SetDefault("Ancient Flier Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Raider");
            text.SetDefault("Starplate Raider Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Infernon");
            text.SetDefault("Infernon Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Dusking");
            text.SetDefault("Dusking Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("EtherialUmbra");
            text.SetDefault("Etherial Umbra Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("IlluminantMaster");
            text.SetDefault("Illuminant Master Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Atlas");
            text.SetDefault("Atlas Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Overseer");
            text.SetDefault("Overseer Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            //SpiritMod
            text = LocalizationLoader.CreateTranslation("Sharkron");
            text.SetDefault("Dune Sharkron Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Hypothema");
            text.SetDefault("Hypothema Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Ragnar");
            text.SetDefault("Ragnar Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("AnDio");
            text.SetDefault("Andesia & Dioritus Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Annihilator");
            text.SetDefault("The Annihilator Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Slybertron");
            text.SetDefault("Slybertron Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("SteamTrain");
            text.SetDefault("Steam Train Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            //Pinky
            text = LocalizationLoader.CreateTranslation("SunlightTrader");
            text.SetDefault("Sunlight Trader Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("THOFC");
            text.SetDefault("The Heart of the Cavern Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("MythrilSlime");
            text.SetDefault("Mythril Slime Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Valdaris");
            text.SetDefault("Valdaris Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Gatekeeper");
            text.SetDefault("The Gatekeeper Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            //AAMod
            text = LocalizationLoader.CreateTranslation("Monarch");
            text.SetDefault("Mushroom Monarch Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Grips");
            text.SetDefault("Grips of Chaos Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Broodmother");
            text.SetDefault("Broodmother Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Hydra");
            text.SetDefault("Hydra Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Serpent");
            text.SetDefault("Subzero Serpent Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Djinn");
            text.SetDefault("Desert Djinn Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Retriever");
            text.SetDefault("Retriever Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("RaiderU");
            text.SetDefault("Raider Ultima Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Orthrus");
            text.SetDefault("Orthrus X Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("EFish");
            text.SetDefault("Emperor Fishron Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Nightcrawler");
            text.SetDefault("Nightcrawler Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Daybringer");
            text.SetDefault("Daybringer Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Yamata");
            text.SetDefault("Yamata Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Akuma");
            text.SetDefault("Akuma Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Zero");
            text.SetDefault("Zero Treasure Bag");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("Shen");
            text.SetDefault("Shen Doragon Treasure Cache");
            LocalizationLoader.AddTranslation(text);

            text = LocalizationLoader.CreateTranslation("ShenGrips");
            text.SetDefault("Shen Doragon Grips Treasure Bag");
            LocalizationLoader.AddTranslation(text);

        }
    }
}

