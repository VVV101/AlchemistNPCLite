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
			Properties = new ModProperties()
			{
				Autoload = true,
				AutoloadGores = true,
				AutoloadSounds = true,
			};
		}

		public static Mod Instance;
		internal static AlchemistNPCLite instance;
		internal TeleportClass TeleportClass;
		public static ModHotKey DiscordBuff;
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
		private UserInterface alchemistUserInterfaceP;
		internal ShopChangeUIM alchemistUIM;
		private UserInterface alchemistUserInterfaceM;
		
		public override void Load()
		{
			Config.Load();
			Instance = this;
            string DiscordBuffTeleportation = Language.GetTextValue("Discord Buff Teleportation");
            DiscordBuff = RegisterHotKey(DiscordBuffTeleportation, "Q");
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
		
		public override void PostSetupContent()
		{
			Mod censusMod = ModLoader.GetMod("Census");
			if(censusMod != null)
			{
				censusMod.Call("TownNPCCondition", NPCType("Alchemist"), "Defeat Eye of Cthulhu");
				censusMod.Call("TownNPCCondition", NPCType("Brewer"), "Defeat Eye of Cthulhu");
				censusMod.Call("TownNPCCondition", NPCType("Jeweler"), "Defeat Eye of Cthulhu");
				censusMod.Call("TownNPCCondition", NPCType("Jeweler"), "Defeat Eater of Worlds/Brain of Cthulhu and have at least 5 NPCs alive");
				censusMod.Call("TownNPCCondition", NPCType("Operator"), "Defeat Eater of Worlds/Brain of Cthulhu");
				censusMod.Call("TownNPCCondition", NPCType("Musician"), "Defeat Skeletron");
				censusMod.Call("TownNPCCondition", NPCType("Young Brewer"), "World state is Hardmode and both Alchemist and Operator are alive");
			}
		}
		
		public override void Unload()
		{
			instance = null;
		}
		
		public static string ConfigFileRelativePath 
		{
		get { return "Mod Configs/AlchemistLitev14.json"; }
		}

		public static void ReloadConfigFromFile() 
		{
		Config.Load();
		}
		
		public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
		{
			int MouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
			if (MouseTextIndex != -1)
			{
				layers.Insert(MouseTextIndex, new LegacyGameInterfaceLayer(
					"AlchemistNPC: Shop Selector",
					delegate
					{
						if (ShopChangeUI.visible)
						{
							alchemistUI.Draw(Main.spriteBatch);
						}
						return true;
					},
					InterfaceScaleType.UI)
				);
			}
			int MouseTextIndexA = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
			if (MouseTextIndexA != -1)
			{
				layers.Insert(MouseTextIndexA, new LegacyGameInterfaceLayer(
					"AlchemistNPC: Shop Selector A",
					delegate
					{
						if (ShopChangeUIA.visible)
						{
							alchemistUIA.Draw(Main.spriteBatch);
						}
						return true;
					},
					InterfaceScaleType.UI)
				);
			}
			int MouseTextIndexO = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
			if (MouseTextIndexO != -1)
			{
				layers.Insert(MouseTextIndexO, new LegacyGameInterfaceLayer(
					"AlchemistNPC: Shop Selector O",
					delegate
					{
						if (ShopChangeUIO.visible)
						{
							alchemistUIO.Draw(Main.spriteBatch);
						}
						return true;
					},
					InterfaceScaleType.UI)
				);
			}
			int MouseTextIndexM = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
			if (MouseTextIndexM != -1)
			{
				layers.Insert(MouseTextIndexM, new LegacyGameInterfaceLayer(
					"AlchemistNPC: Shop Selector M",
					delegate
					{
						if (ShopChangeUIM.visible)
						{
							alchemistUIM.Draw(Main.spriteBatch);
						}
						return true;
					},
					InterfaceScaleType.UI)
				);
			}
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
					ErrorLogger.Log("AlchemistNPCLite: Unknown Message type: " + msgType);
					break;
			}
		}
		
		public enum AlchemistNPCLiteMessageType : byte
		{
		TeleportPlayer
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.CelestialStone);
			recipe.AddIngredient(ItemID.GoldBar, 10);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(ItemID.Sundial);
			recipe.AddRecipe();
			recipe = new ModRecipe(this);
			recipe.AddRecipeGroup("AlchemistNPCLite:AnyWatch");
			recipe.AddIngredient(ItemID.HermesBoots);
			recipe.AddIngredient(ItemID.Wire, 15);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(ItemID.Stopwatch);
			recipe.AddRecipe();
			recipe = new ModRecipe(this);
			recipe.AddRecipeGroup("AlchemistNPCLite:EvilBar", 10);
			recipe.AddRecipeGroup("AlchemistNPCLite:AnyWatch");
			recipe.AddIngredient(ItemID.Wire, 25);
			recipe.AddIngredient(ItemID.Chain);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(ItemID.DPSMeter);
			recipe.AddRecipe();
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.TallyCounter);
			recipe.AddIngredient(ItemID.BlackLens);
			recipe.AddIngredient(ItemID.AntlionMandible);
			recipe.AddRecipeGroup("AlchemistNPCLite:EvilDrop");
			recipe.AddRecipeGroup("AlchemistNPCLite:EvilComponent");
			recipe.AddIngredient(ItemID.Feather);
			recipe.AddIngredient(ItemID.TatteredCloth);
			recipe.AddIngredient(ItemID.Bone);
			recipe.AddIngredient(ItemID.Wire, 25);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(ItemID.LifeformAnalyzer);
			recipe.AddRecipe();
		}
		
        //SBMW:Transtation method
        public void SetTranslation()
        {
            ModTranslation text = CreateTranslation("DiscordBuffTeleportation");
            text.SetDefault("Discord Buff Teleportation");
            text.AddTranslation(GameCulture.Chinese, "混乱药剂传送");
            AddTranslation(text);

            //SBMW:RecipeGroups
            text = CreateTranslation("evilBossMask");
            text.SetDefault("Corruption/Crimson boss mask");
            text.AddTranslation(GameCulture.Chinese, "腐化/血腥Boss面具");
            AddTranslation(text);

            text = CreateTranslation("cultist");
            text.SetDefault("Cultist mask/hood");
            text.AddTranslation(GameCulture.Chinese, "邪教徒面具/兜帽");
            AddTranslation(text);

            text = CreateTranslation("tier3HardmodeBar");
            text.SetDefault("tier 3 Hardmode Bar");
            text.AddTranslation(GameCulture.Chinese, "三级肉后锭(精金/钛金)");
            AddTranslation(text);
			
			text = CreateTranslation("hardmodeComponent");
            text.SetDefault("Hardmode component");
            AddTranslation(text);

            text = CreateTranslation("evilBar");
            text.SetDefault("Crimson/Corruption bar");
            text.AddTranslation(GameCulture.Chinese, "魔金/血腥锭");
            AddTranslation(text);

            text = CreateTranslation("evilMushroom");
            text.SetDefault("evil mushroom");
            text.AddTranslation(GameCulture.Chinese, "邪恶蘑菇");
            AddTranslation(text);

            text = CreateTranslation("evilComponent");
            text.SetDefault("evil component");
            text.AddTranslation(GameCulture.Chinese, "邪恶材料(暗影鳞片/组织样本)");
            AddTranslation(text);

            text = CreateTranslation("evilDrop");
            text.SetDefault("evil drop");
            text.AddTranslation(GameCulture.Chinese, "邪恶掉落物(腐肉/椎骨)");
            AddTranslation(text);

            text = CreateTranslation("tier2anvil");
            text.SetDefault("tier 2 anvil");
            text.AddTranslation(GameCulture.Chinese, "二级砧(秘银/山铜砧)");
            AddTranslation(text);

            text = CreateTranslation("tier2forge");
            text.SetDefault("tier 2 forge");
            text.AddTranslation(GameCulture.Chinese, "二级熔炉(精金/钛金熔炉)");
            AddTranslation(text);

            text = CreateTranslation("tier1anvil");
            text.SetDefault("tier 1 anvil");
            text.AddTranslation(GameCulture.Chinese, "一级砧(铁/铅砧)");
            AddTranslation(text);

            text = CreateTranslation("CelestialWings");
            text.SetDefault("Celestial Wings");
            text.AddTranslation(GameCulture.Chinese, "四柱翅膀");
            AddTranslation(text);
			
			text = CreateTranslation("LunarHamaxe");
            text.SetDefault("Lunar Hamaxe");
            AddTranslation(text);

            text = CreateTranslation("tier3Watch");
            text.SetDefault("tier 3 Watch");
            text.AddTranslation(GameCulture.Chinese, "三级表(金表/铂金表)");
            AddTranslation(text);

            //SBMW:Vanilla
            text = CreateTranslation("KingSlime");
            text.SetDefault("King Slime Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "史莱姆之王宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("EyeofCthulhu");
            text.SetDefault("Eye of Cthulhu Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "克苏鲁之眼宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("EaterOfWorlds");
            text.SetDefault("Eater Of Worlds Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "世界吞噬者宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("BrainOfCthulhu");
            text.SetDefault("Brain Of Cthulhu Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "克苏鲁之脑宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("QueenBee");
            text.SetDefault("Queen Bee Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "蜂后宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("Skeletron");
            text.SetDefault("Skeletron Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "骷髅王宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("WallOfFlesh");
            text.SetDefault("Wall Of Flesh Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "血肉之墙宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("Destroyer");
            text.SetDefault("Destroyer Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "机械蠕虫宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("Twins");
            text.SetDefault("Twins Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "双子魔眼宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("SkeletronPrime");
            text.SetDefault("Skeletron Prime Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "机械骷髅王宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("Plantera");
            text.SetDefault("Plantera Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "世纪之花宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("Golem");
            text.SetDefault("Golem Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "石巨人宝藏袋");
            AddTranslation(text);

			text = CreateTranslation("Betsy");
            text.SetDefault("Betsy Treasure Bag");
            AddTranslation(text);
			
            text = CreateTranslation("DukeFishron");
            text.SetDefault("Duke Fishron Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "猪鲨公爵宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("MoonLord");
            text.SetDefault("Moon Lord Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "月亮领主宝藏袋");
            AddTranslation(text);

            //SBMW:CalamityMod
            text = CreateTranslation("DesertScourge");
            text.SetDefault("Desert Scourge Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "荒漠灾虫宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("Crabulon");
            text.SetDefault("Crabulon Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "蘑菇螃蟹宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("HiveMind");
            text.SetDefault("The Hive Mind Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "腐巢意志宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("Perforator");
            text.SetDefault("The Perforators Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "血肉宿主宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("SlimeGod");
            text.SetDefault("The Slime God Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "史莱姆之神宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("Cryogen");
            text.SetDefault("Cryogen Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "极地之灵宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("BrimstoneElemental");
            text.SetDefault("Brimstone Elemental Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "硫磺火元素宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("AquaticScourge");
            text.SetDefault("Aquatic Scourge Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "渊海灾虫宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("Calamitas");
            text.SetDefault("Calamitas Doppelganger Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "灾厄之眼宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("AstrageldonSlime");
            text.SetDefault("Astrageldon Slime Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "大彗星史莱姆宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("AstrumDeus");
            text.SetDefault("Astrum Deus Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "星神吞噬者宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("Leviathan");
            text.SetDefault("The Leviathan Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "利维坦宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("PlaguebringerGoliath");
            text.SetDefault("The Plaguebringer Goliath Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "瘟疫使者歌莉娅宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("Ravager");
            text.SetDefault("Ravager Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "毁灭魔像宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("Providence");
            text.SetDefault("Providence Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "亵渎天神宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("Polterghast");
            text.SetDefault("Polterghast Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "噬魂幽花宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("DevourerofGods");
            text.SetDefault("The Devourer of Gods Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "神明吞噬者宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("Bumblebirb");
            text.SetDefault("Bumblebirb Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "癫痫鸟宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("Yharon");
            text.SetDefault("Jungle Dragon, Yharon Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "犽戎宝藏袋");
            AddTranslation(text);

            //SBMW:ThoriumMod
			text = CreateTranslation("DarkMage");
            text.SetDefault("Dark Mage Treasure Bag");
            AddTranslation(text);
			
			text = CreateTranslation("Ogre");
            text.SetDefault("Ogre Treasure Bag");
            AddTranslation(text);
			
            text = CreateTranslation("ThunderBird");
            text.SetDefault("The Great Thunder Bird Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "惊雷王鹰宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("QueenJellyfish");
            text.SetDefault("The Queen Jellyfish Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "水母皇后宝藏袋");
            AddTranslation(text);
			
			text = CreateTranslation("CountEcho");
            text.SetDefault("Count Echo Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "水母皇后宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("GraniteEnergyStorm");
            text.SetDefault("Granite Energy Storm Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "花岗岩流能风暴宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("TheBuriedChampion");
            text.SetDefault("The Buried Champion Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "英灵遗骸宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("TheStarScouter");
            text.SetDefault("The Star Scouter Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "星际监察者宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("BoreanStrider");
            text.SetDefault("Borean Strider Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "极地遁蛛宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("CoznixTheFallenBeholder");
            text.SetDefault("Coznix, The Fallen Beholder Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "堕落注视者·克兹尼格斯宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("TheLich");
            text.SetDefault("The Lich Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "巫妖宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("AbyssionTheForgottenOne");
            text.SetDefault("Abyssion, The Forgotten One Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "被遗忘者-深渊之主宝藏袋");
            AddTranslation(text);

            text = CreateTranslation("TheRagnarok");
            text.SetDefault("The Ragnarok Treasure Bag");
            text.AddTranslation(GameCulture.Chinese, "灾难之灵宝藏袋");
            AddTranslation(text);

			 //SacredTools
            text = CreateTranslation("FlamingPumpkin");
            text.SetDefault("The Flaming Pumpkin Treasure Bag");
            AddTranslation(text);
			
			text = CreateTranslation("Jensen");
            text.SetDefault("Jansen, the Grand Harpy Treasure Bag");
            AddTranslation(text);
			
			text = CreateTranslation("Raynare");
            text.SetDefault("Harpy Queen, Raynare Treasure Bag");
            AddTranslation(text);
			
			text = CreateTranslation("Abaddon");
            text.SetDefault("Abaddon, the Emissary of Nightmares Treasure Bag");
            AddTranslation(text);
			
			text = CreateTranslation("Araghur");
            text.SetDefault("Araghur, the Flare Serpent Treasure Bag");
            AddTranslation(text);
			
			text = CreateTranslation("Lunarians");
            text.SetDefault("The Lunarians Treasure Bag");
            AddTranslation(text);
			
			text = CreateTranslation("Challenger");
            text.SetDefault("The Challenger Treasure Bag");
            AddTranslation(text);
			
			//SpiritMod
            text = CreateTranslation("Scarabeus");
            text.SetDefault("Scarabeus Treasure Bag");
            AddTranslation(text);
			
			text = CreateTranslation("Bane");
            text.SetDefault("Vinewrath Bane Treasure Bag");
            AddTranslation(text);
			
			text = CreateTranslation("Flier");
            text.SetDefault("Ancient Flier Treasure Bag");
            AddTranslation(text);
			
			text = CreateTranslation("Raider");
            text.SetDefault("Starplate Raider Treasure Bag");
            AddTranslation(text);
			
			text = CreateTranslation("Infernon");
            text.SetDefault("Infernon Treasure Bag");
            AddTranslation(text);
			
			text = CreateTranslation("Dusking");
            text.SetDefault("Dusking Treasure Bag");
            AddTranslation(text);
			
			text = CreateTranslation("EtherialUmbra");
            text.SetDefault("Etherial Umbra Treasure Bag");
            AddTranslation(text);
			
			text = CreateTranslation("IlluminantMaster");
            text.SetDefault("Illuminant Master Treasure Bag");
            AddTranslation(text);
			
			text = CreateTranslation("Atlas");
            text.SetDefault("Atlas Treasure Bag");
            AddTranslation(text);
			
			text = CreateTranslation("Overseer");
            text.SetDefault("Overseer Treasure Bag");
            AddTranslation(text);
			
			//SpiritMod
            text = CreateTranslation("Sharkron");
            text.SetDefault("Dune Sharkron Treasure Bag");
            AddTranslation(text);
			
			text = CreateTranslation("Hypothema");
            text.SetDefault("Hypothema Treasure Bag");
            AddTranslation(text);
			
			text = CreateTranslation("Ragnar");
            text.SetDefault("Ragnar Treasure Bag");
            AddTranslation(text);
			
			text = CreateTranslation("AnDio");
            text.SetDefault("Andesia & Dioritus Treasure Bag");
            AddTranslation(text);
			
			text = CreateTranslation("Annihilator");
            text.SetDefault("The Annihilator Treasure Bag");
            AddTranslation(text);
			
			text = CreateTranslation("Slybertron");
            text.SetDefault("Slybertron Treasure Bag");
            AddTranslation(text);
			
			text = CreateTranslation("SteamTrain");
            text.SetDefault("Steam Train Treasure Bag");
            AddTranslation(text);
			
			//Pinky
            text = CreateTranslation("SunlightTrader");
            text.SetDefault("Sunlight Trader Treasure Bag");
            AddTranslation(text);
			
			text = CreateTranslation("THOFC");
            text.SetDefault("The Heart of the Cavern Treasure Bag");
            AddTranslation(text);
			
			text = CreateTranslation("MythrilSlime");
            text.SetDefault("Mythril Slime Treasure Bag");
            AddTranslation(text);
			
			text = CreateTranslation("Valdaris");
            text.SetDefault("Valdaris Treasure Bag");
            AddTranslation(text);
			
			text = CreateTranslation("Gatekeeper");
            text.SetDefault("The Gatekeeper Treasure Bag");
            AddTranslation(text);
			
			//AAMod
            text = CreateTranslation("Monarch");
            text.SetDefault("Mushroom Monarch Treasure Bag");
            AddTranslation(text);
			
			text = CreateTranslation("Grips");
            text.SetDefault("Grips of Chaos Treasure Bag");
            AddTranslation(text);
			
			text = CreateTranslation("Broodmother");
            text.SetDefault("Broodmother Treasure Bag");
            AddTranslation(text);

			text = CreateTranslation("Hydra");
            text.SetDefault("Hydra Treasure Bag");
            AddTranslation(text);
			
			text = CreateTranslation("Serpent");
            text.SetDefault("Subzero Serpent Treasure Bag");
            AddTranslation(text);
			
			text = CreateTranslation("Djinn");
            text.SetDefault("Desert Djinn Treasure Bag");
            AddTranslation(text);
			
			text = CreateTranslation("Retriever");
            text.SetDefault("Retriever Treasure Bag");
            AddTranslation(text);
			
			text = CreateTranslation("RaiderU");
            text.SetDefault("Raider Ultima Treasure Bag");
            AddTranslation(text);
			
			text = CreateTranslation("Orthrus");
            text.SetDefault("Orthrus X Treasure Bag");
            AddTranslation(text);
			
			text = CreateTranslation("EFish");
            text.SetDefault("Emperor Fishron Treasure Bag");
            AddTranslation(text);
			
			text = CreateTranslation("Nightcrawler");
            text.SetDefault("Nightcrawler Treasure Bag");
            AddTranslation(text);
			
			text = CreateTranslation("Daybringer");
            text.SetDefault("Daybringer Treasure Bag");
            AddTranslation(text);
			
			text = CreateTranslation("Yamata");
            text.SetDefault("Yamata Treasure Bag");
            AddTranslation(text);
			
			text = CreateTranslation("Akuma");
            text.SetDefault("Akuma Treasure Bag");
            AddTranslation(text);
			
			text = CreateTranslation("Zero");
            text.SetDefault("Zero Treasure Bag");
            AddTranslation(text);
			
			text = CreateTranslation("Shen");
            text.SetDefault("Shen Doragon Treasure Cache");
            AddTranslation(text);
			
			text = CreateTranslation("ShenGrips");
            text.SetDefault("Shen Doragon Grips Treasure Bag");
            AddTranslation(text);

        }
		
		public override void UpdateUI(GameTime gameTime)
		{
			if (alchemistUserInterface != null && ShopChangeUI.visible)
			{
				alchemistUserInterface.Update(gameTime);
			}
			
			if (alchemistUserInterfaceA != null && ShopChangeUIA.visible)
			{
				alchemistUserInterfaceA.Update(gameTime);
			}
			
			if (alchemistUserInterfaceO != null && ShopChangeUIO.visible)
			{
				alchemistUserInterfaceO.Update(gameTime);
			}
			
			if (alchemistUserInterfaceM != null && ShopChangeUIM.visible)
			{
				alchemistUserInterfaceM.Update(gameTime);
			}
		}
    }
	
}

