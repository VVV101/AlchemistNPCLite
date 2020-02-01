using Terraria.Utilities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader.IO;
using Terraria.Localization;

namespace AlchemistNPCLite.Items
{
	public class AlchemistGlobalItem : GlobalItem
	{	
		public static bool on = false;
		public static bool Luck = false;
		public static bool Luck2 = false;
		
		public bool CalamityModDownedSCal
		{
		get { return CalamityMod.World.CalamityWorld.downedSCal; }
		}
		
		public override void UpdateInventory(Item item, Player player)
		{
			if (player.accCritterGuide && AlchemistNPCLite.modConfiguration.LifeformAnalyzer)
			{
				if(Main.GameUpdateCount % 60 == 0) 
				{
					for (int v = 0; v < 200; ++v)
					{
						NPC npc = Main.npc[v];
						if (npc.active && npc.rarity >= 1)
						{
							float num102 = 6f;
							float num103 = npc.Center.X + npc.width * 0.5f - player.Center.X;
							float num104 = npc.Center.Y + npc.height * 0.5f - player.Center.Y;
							float num105 = (float)Math.Sqrt((double)(num103 * num103 + num104 * num104));
							num105 = num102 / num105;
							num103 *= num105;
							num104 *= num105;
							Projectile.NewProjectile(player.Center.X, player.Center.Y, num103, num104, mod.ProjectileType("LocatorProjectile"), 0, 0f, player.whoAmI, v, 0f);
						}
					}
				}
			}
			if (item.type == mod.ItemType("LuckCharm"))
			{
				Luck = true;
			}
			if (item.type == mod.ItemType("LuckCharmT2"))
			{
				Luck = true;
				Luck2 = true;
			}
		}
		
		public override int ChoosePrefix(Item item, UnifiedRandom rand)
		{
			if (Luck == true)
			{
				if (item.melee)
				{
					if (Main.rand.Next(10) == 0)
					return 59;
				
					if (Main.rand.Next(20) == 0)
					return 81;
				}
				if (item.ranged && !item.consumable)
				{
					if (Main.rand.Next(10) == 0)
					return 20;
				
					if (Main.rand.Next(20) == 0)
					return 82;
				}
				if (item.magic)
				{
					if (Main.rand.Next(10) == 0)
					return 28;
				
					if (Main.rand.Next(20) == 0)
					return 83;
				}
				if (item.summon)
				{
					if (Main.rand.Next(10) == 0)
					return 57;
				
					if (Main.rand.Next(20) == 0)
					return 83;
				}
				if (item.thrown && !item.consumable)
				{
					if (Main.rand.Next(10) == 0)
					return 20;
				
					if (Main.rand.Next(20) == 0)
					return 82;
				}
			}
			if (Luck2 == true)
			{
				if (item.accessory)
				{
					if (Main.rand.Next(10) == 0)
					return 72;
				
					else if (Main.rand.Next(10) == 0)
					return 68;
				
					else if (Main.rand.Next(10) == 0)
					return 65;
				}
			}
		return -1;
		}
		
		public override bool ConsumeItem(Item item, Player player)	
		{
			if (((AlchemistNPCLitePlayer)player.GetModPlayer(mod, "AlchemistNPCLitePlayer")).AlchemistCharmTier4 == true && (item.buffTime > 0 || item.healLife > 0 || item.healMana > 0 || item.UseSound == SoundID.Item3))
			{
				if (ModLoader.GetMod("CalamityMod") != null)
				{
					if (CalamityModDownedSCal)
					{
					return false;
					}
				}
				if (Main.rand.NextFloat() >= .25f)
				{
				return false;
				}
			}
			
			else if (((AlchemistNPCLitePlayer)player.GetModPlayer(mod, "AlchemistNPCLitePlayer")).AlchemistCharmTier3 == true && (item.buffTime > 0 || item.healLife > 0 || item.healMana > 0 || item.UseSound == SoundID.Item3))
			{
				if (Main.rand.Next(2) == 0)
				return false;
			}
			
			else if (((AlchemistNPCLitePlayer)player.GetModPlayer(mod, "AlchemistNPCLitePlayer")).AlchemistCharmTier2 == true && (item.buffTime > 0 || item.healLife > 0 || item.healMana > 0 || item.UseSound == SoundID.Item3))
			{
				if (Main.rand.Next(4) == 0)
				return false;
			}
			
			else if (((AlchemistNPCLitePlayer)player.GetModPlayer(mod, "AlchemistNPCLitePlayer")).AlchemistCharmTier1 == true && (item.buffTime > 0 || item.healLife > 0 || item.healMana > 0 || item.UseSound == SoundID.Item3))
			{
				if (Main.rand.Next(10) == 0)
				return false;
			}
			return true;
		}

		public override bool UseItem(Item item, Player player)
		{
			AlchemistNPCLitePlayer modPlayer = player.GetModPlayer<AlchemistNPCLitePlayer>();
			if (item.type == 1991 || item.type == 3183)
			{
				for (int v = 0; v < 200; ++v)
				{
					NPC npc = Main.npc[v];
					if (npc.active && npc.townNPC)
					{
						if (AlchemistNPCLite.modConfiguration.CatchNPC)
						{
							if (npc.type == mod.NPCType("Alchemist"))
							{
								Main.npcCatchable[npc.type] = true;
								npc.catchItem = (short)mod.ItemType("AlchemistHorcrux");
							}
							if (npc.type == mod.NPCType("Brewer"))
							{
								Main.npcCatchable[npc.type] = true;
								npc.catchItem = (short)mod.ItemType("BrewerHorcrux");
							}
							if (npc.type == mod.NPCType("Architect"))
							{
								Main.npcCatchable[npc.type] = true;
								npc.catchItem = (short)mod.ItemType("ArchitectHorcrux");
							}
							if (npc.type == mod.NPCType("Jeweler"))
							{
								Main.npcCatchable[npc.type] = true;
								npc.catchItem = (short)mod.ItemType("JewelerHorcrux");
							}
							if (npc.type == mod.NPCType("Operator"))
							{
								Main.npcCatchable[npc.type] = true;
								npc.catchItem = (short)mod.ItemType("APMC");
							}
							if (npc.type == mod.NPCType("Musician"))
							{
								Main.npcCatchable[npc.type] = true;
								npc.catchItem = (short)mod.ItemType("MusicianHorcrux");
							}
							if (npc.type == mod.NPCType("Tinkerer"))
							{
								Main.npcCatchable[npc.type] = true;
								npc.catchItem = (short)mod.ItemType("TinkererHorcrux");
							}
						}
						if (!AlchemistNPCLite.modConfiguration.CatchNPC)
						{
							if (npc.type == mod.NPCType("Alchemist"))
							{
								Main.npcCatchable[npc.type] = false;
								npc.catchItem = -1;
							}
							if (npc.type == mod.NPCType("Brewer"))
							{
								Main.npcCatchable[npc.type] = false;
								npc.catchItem = -1;
							}
							if (npc.type == mod.NPCType("Architect"))
							{
								Main.npcCatchable[npc.type] = false;
								npc.catchItem = -1;
							}
							if (npc.type == mod.NPCType("Jeweler"))
							{
								Main.npcCatchable[npc.type] = false;
								npc.catchItem = -1;
							}
							if (npc.type == mod.NPCType("Operator"))
							{
								Main.npcCatchable[npc.type] = false;
								npc.catchItem = -1;
							}
							if (npc.type == mod.NPCType("Musician"))
							{
								Main.npcCatchable[npc.type] = false;
								npc.catchItem = -1;
							}
							if (npc.type == mod.NPCType("Tinkerer"))
							{
								Main.npcCatchable[npc.type] = false;
								npc.catchItem = -1;
							}
						}
					}
				}
			}
			if (modPlayer.AlchemistCharmTier4)
			{
				player.AddBuff(item.buffType, item.buffTime + (item.buffTime/2), true);
			}
			else if (modPlayer.AlchemistCharmTier3)
			{
				player.AddBuff(item.buffType, item.buffTime + ((item.buffTime/20)*7), true);
			}
			else if (modPlayer.AlchemistCharmTier2)
			{
				player.AddBuff(item.buffType, item.buffTime + (item.buffTime/4), true);
			}
			else if (modPlayer.AlchemistCharmTier1)
			{
				player.AddBuff(item.buffType, item.buffTime + (item.buffTime/10), true);
			}
			return base.UseItem(item, player);
		}
		
		public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
		{
            //SBMW:Vanilla
            string KingSlime = Language.GetTextValue("Mods.AlchemistNPCLite.KingSlime");
            string EyeofCthulhu = Language.GetTextValue("Mods.AlchemistNPCLite.EyeofCthulhu");
            string EaterOfWorlds = Language.GetTextValue("Mods.AlchemistNPCLite.EaterOfWorlds");
            string BrainOfCthulhu = Language.GetTextValue("Mods.AlchemistNPCLite.BrainOfCthulhu");
            string QueenBee = Language.GetTextValue("Mods.AlchemistNPCLite.QueenBee");
            string Skeletron = Language.GetTextValue("Mods.AlchemistNPCLite.Skeletron");
            string WallOfFlesh = Language.GetTextValue("Mods.AlchemistNPCLite.WallOfFlesh");
            string Destroyer = Language.GetTextValue("Mods.AlchemistNPCLite.Destroyer");
            string Twins = Language.GetTextValue("Mods.AlchemistNPCLite.Twins");
            string SkeletronPrime = Language.GetTextValue("Mods.AlchemistNPCLite.SkeletronPrime");
            string Plantera = Language.GetTextValue("Mods.AlchemistNPCLite.Plantera");
            string Golem = Language.GetTextValue("Mods.AlchemistNPCLite.Golem");
			string Betsy = Language.GetTextValue("Mods.AlchemistNPCLite.Betsy");
            string DukeFishron = Language.GetTextValue("Mods.AlchemistNPCLite.DukeFishron");
            string MoonLord = Language.GetTextValue("Mods.AlchemistNPCLite.MoonLord");

            //SBMW:CalamityMod
            string DesertScourge = Language.GetTextValue("Mods.AlchemistNPCLite.DesertScourge");
            string Crabulon = Language.GetTextValue("Mods.AlchemistNPCLite.Crabulon");
            string HiveMind = Language.GetTextValue("Mods.AlchemistNPCLite.HiveMind");
            string Perforator = Language.GetTextValue("Mods.AlchemistNPCLite.Perforator");
            string SlimeGod = Language.GetTextValue("Mods.AlchemistNPCLite.SlimeGod");
            string Cryogen = Language.GetTextValue("Mods.AlchemistNPCLite.Cryogen");
            string BrimstoneElemental = Language.GetTextValue("Mods.AlchemistNPCLite.BrimstoneElemental");
            string AquaticScourge = Language.GetTextValue("Mods.AlchemistNPCLite.AquaticScourge");
            string Calamitas = Language.GetTextValue("Mods.AlchemistNPCLite.Calamitas");
            string AstrageldonSlime = Language.GetTextValue("Mods.AlchemistNPCLite.AstrageldonSlime");
            string AstrumDeus = Language.GetTextValue("Mods.AlchemistNPCLite.AstrumDeus");
            string Leviathan = Language.GetTextValue("Mods.AlchemistNPCLite.Leviathan");
            string PlaguebringerGoliath = Language.GetTextValue("Mods.AlchemistNPCLite.PlaguebringerGoliath");
            string Ravager = Language.GetTextValue("Mods.AlchemistNPCLite.Ravager");
            string Providence = Language.GetTextValue("Mods.AlchemistNPCLite.Providence");
            string Polterghast = Language.GetTextValue("Mods.AlchemistNPCLite.Polterghast");
            string DevourerofGods = Language.GetTextValue("Mods.AlchemistNPCLite.DevourerofGods");
            string Bumblebirb = Language.GetTextValue("Mods.AlchemistNPCLite.Bumblebirb");
            string Yharon = Language.GetTextValue("Mods.AlchemistNPCLite.Yharon");

            //SBMW:ThoriumMod
			string DarkMage = Language.GetTextValue("Mods.AlchemistNPCLite.DarkMage");
			string Ogre = Language.GetTextValue("Mods.AlchemistNPCLite.Ogre");
            string ThunderBird = Language.GetTextValue("Mods.AlchemistNPCLite.ThunderBird");
            string QueenJellyfish = Language.GetTextValue("Mods.AlchemistNPCLite.QueenJellyfish");
			string CountEcho = Language.GetTextValue("Mods.AlchemistNPCLite.CountEcho");
            string GraniteEnergyStorm = Language.GetTextValue("Mods.AlchemistNPCLite.GraniteEnergyStorm");
            string TheBuriedChampion = Language.GetTextValue("Mods.AlchemistNPCLite.TheBuriedChampion");
            string TheStarScouter = Language.GetTextValue("Mods.AlchemistNPCLite.TheStarScouter");
            string BoreanStrider = Language.GetTextValue("Mods.AlchemistNPCLite.BoreanStrider");
            string CoznixTheFallenBeholder = Language.GetTextValue("Mods.AlchemistNPCLite.CoznixTheFallenBeholder");
            string TheLich = Language.GetTextValue("Mods.AlchemistNPCLite.TheLich");
            string AbyssionTheForgottenOne = Language.GetTextValue("Mods.AlchemistNPCLite.AbyssionTheForgottenOne");
            string TheRagnarok = Language.GetTextValue("Mods.AlchemistNPCLite.TheRagnarok");
			
			//SacredTools
			string FlamingPumpkin = Language.GetTextValue("Mods.AlchemistNPCLite.FlamingPumpkin");
            string Jensen = Language.GetTextValue("Mods.AlchemistNPCLite.Jensen");
			string Raynare = Language.GetTextValue("Mods.AlchemistNPCLite.Raynare");
            string Abaddon = Language.GetTextValue("Mods.AlchemistNPCLite.Abaddon");
            string Araghur = Language.GetTextValue("Mods.AlchemistNPCLite.Araghur");
            string Lunarians = Language.GetTextValue("Mods.AlchemistNPCLite.Lunarians");
            string Challenger = Language.GetTextValue("Mods.AlchemistNPCLite.Challenger");
			
			//SpiritMod
			string Scarabeus = Language.GetTextValue("Mods.AlchemistNPCLite.Scarabeus");
            string Bane = Language.GetTextValue("Mods.AlchemistNPCLite.Bane");
			string Flier = Language.GetTextValue("Mods.AlchemistNPCLite.Flier");
            string Raider = Language.GetTextValue("Mods.AlchemistNPCLite.Raider");
            string Infernon = Language.GetTextValue("Mods.AlchemistNPCLite.Infernon");
            string Dusking = Language.GetTextValue("Mods.AlchemistNPCLite.Dusking");
            string EtherialUmbra = Language.GetTextValue("Mods.AlchemistNPCLite.EtherialUmbra");
			string IlluminantMaster = Language.GetTextValue("Mods.AlchemistNPCLite.IlluminantMaster");
			string Atlas = Language.GetTextValue("Mods.AlchemistNPCLite.Atlas");
			string Overseer = Language.GetTextValue("Mods.AlchemistNPCLite.Overseer");
			
			//Enigma
			string Sharkron = Language.GetTextValue("Mods.AlchemistNPCLite.Sharkron");
            string Hypothema = Language.GetTextValue("Mods.AlchemistNPCLite.Hypothema");
			string Ragnar = Language.GetTextValue("Mods.AlchemistNPCLite.Ragnar");
            string AnDio = Language.GetTextValue("Mods.AlchemistNPCLite.AnDio");
            string Annihilator = Language.GetTextValue("Mods.AlchemistNPCLite.Annihilator");
            string Slybertron = Language.GetTextValue("Mods.AlchemistNPCLite.Slybertron");
            string SteamTrain = Language.GetTextValue("Mods.AlchemistNPCLite.SteamTrain");
			
			//pinky
			string SunlightTrader = Language.GetTextValue("Mods.AlchemistNPCLite.SunlightTrader");
            string THOFC = Language.GetTextValue("Mods.AlchemistNPCLite.THOFC");
			string MythrilSlime = Language.GetTextValue("Mods.AlchemistNPCLite.MythrilSlime");
            string Valdaris = Language.GetTextValue("Mods.AlchemistNPCLite.Valdaris");
            string Gatekeeper = Language.GetTextValue("Mods.AlchemistNPCLite.Gatekeeper");
			
			//AAMod
			string Monarch = Language.GetTextValue("Mods.AlchemistNPCLite.Monarch");
            string Grips = Language.GetTextValue("Mods.AlchemistNPCLite.Grips");
			string Broodmother = Language.GetTextValue("Mods.AlchemistNPCLite.Broodmother");
            string Hydra = Language.GetTextValue("Mods.AlchemistNPCLite.Hydra");
			string Serpent = Language.GetTextValue("Mods.AlchemistNPCLite.Serpent");
            string Djinn = Language.GetTextValue("Mods.AlchemistNPCLite.Djinn");
			string Retriever = Language.GetTextValue("Mods.AlchemistNPCLite.Retriever");
			string RaiderU = Language.GetTextValue("Mods.AlchemistNPCLite.RaiderU");
			string Orthrus = Language.GetTextValue("Mods.AlchemistNPCLite.Orthrus");
			string EFish = Language.GetTextValue("Mods.AlchemistNPCLite.EFish");
			string Nightcrawler = Language.GetTextValue("Mods.AlchemistNPCLite.Nightcrawler");
			string Daybringer = Language.GetTextValue("Mods.AlchemistNPCLite.Daybringer");
			string Yamata = Language.GetTextValue("Mods.AlchemistNPCLite.Yamata");
			string Akuma = Language.GetTextValue("Mods.AlchemistNPCLite.Akuma");
			string Zero = Language.GetTextValue("Mods.AlchemistNPCLite.Zero");
			string Shen = Language.GetTextValue("Mods.AlchemistNPCLite.Shen");
			string ShenGrips = Language.GetTextValue("Mods.AlchemistNPCLite.ShenGrips");

            if (item.type == ItemID.KingSlimeBossBag)
			{
				TooltipLine line = new TooltipLine(mod, "KingSlime", KingSlime);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
			}
			if (item.type == ItemID.EyeOfCthulhuBossBag)
			{
				TooltipLine line = new TooltipLine(mod, "EyeofCthulhu", EyeofCthulhu);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
			}
			if (item.type == ItemID.EaterOfWorldsBossBag)
			{
				TooltipLine line = new TooltipLine(mod, "EaterOfWorlds", EaterOfWorlds);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
			}
			if (item.type == ItemID.BrainOfCthulhuBossBag)
			{
				TooltipLine line = new TooltipLine(mod, "BrainOfCthulhu", BrainOfCthulhu);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
			}
			if (item.type == ItemID.QueenBeeBossBag)
			{
				TooltipLine line = new TooltipLine(mod, "QueenBeeBossBag", QueenBee);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
			}
			if (item.type == ItemID.SkeletronBossBag)
			{
				TooltipLine line = new TooltipLine(mod, "Skeletron", Skeletron);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
			}
			if (item.type == ItemID.WallOfFleshBossBag)
			{
				TooltipLine line = new TooltipLine(mod, "WallOfFleshBoss", WallOfFlesh);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
			}
			if (item.type == ItemID.DestroyerBossBag)
			{
				TooltipLine line = new TooltipLine(mod, "Destroyer", Destroyer);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
			}
			if (item.type == ItemID.TwinsBossBag)
			{
				TooltipLine line = new TooltipLine(mod, "Twins", Twins);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
			}
			if (item.type == ItemID.SkeletronPrimeBossBag)
			{
				TooltipLine line = new TooltipLine(mod, "SkeletronPrime", SkeletronPrime);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
			}
			if (item.type == ItemID.PlanteraBossBag)
			{
				TooltipLine line = new TooltipLine(mod, "Plantera", Plantera);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
			}
			if (item.type == ItemID.GolemBossBag)
			{
				TooltipLine line = new TooltipLine(mod, "Golem", Golem);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
			}
			if (item.type == ItemID.BossBagBetsy)
			{
				TooltipLine line = new TooltipLine(mod, "Betsy", Betsy);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
			}
			if (item.type == ItemID.FishronBossBag)
			{
				TooltipLine line = new TooltipLine(mod, "DukeFishron", DukeFishron);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
			}
			if (item.type == ItemID.MoonLordBossBag)
			{
				TooltipLine line = new TooltipLine(mod, "MoonLord", MoonLord);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
			}
			if (ModLoader.GetMod("CalamityMod") != null)
			{
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("DesertScourgeBag")))
				{
				TooltipLine line = new TooltipLine(mod, "DesertScourge", DesertScourge);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("CrabulonBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Crabulon", Crabulon);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("HiveMindBag")))
				{
				TooltipLine line = new TooltipLine(mod, "HiveMind", HiveMind);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("PerforatorBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Perforator", Perforator);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("SlimeGodBag")))
				{
				TooltipLine line = new TooltipLine(mod, "SlimeGod", SlimeGod);

                line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("CryogenBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Cryogen", Cryogen);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("BrimstoneWaifuBag")))
				{
				TooltipLine line = new TooltipLine(mod, "BrimstoneElemental", BrimstoneElemental);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("AquaticScourgeBag")))
				{
				TooltipLine line = new TooltipLine(mod, "AquaticScourge", AquaticScourge);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("CalamitasBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Calamitas", Calamitas);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("AstrageldonBag")))
				{
				TooltipLine line = new TooltipLine(mod, "AstrageldonSlime", AstrageldonSlime);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("AstrumDeusBag")))
				{
				TooltipLine line = new TooltipLine(mod, "AstrumDeus", AstrumDeus);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("LeviathanBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Leviathan", Leviathan);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("PlaguebringerGoliathBag")))
				{
				TooltipLine line = new TooltipLine(mod, "PlaguebringerGoliath", PlaguebringerGoliath);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("RavagerBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Ravager", Ravager);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("ProvidenceBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Providence", Providence);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("PolterghastBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Polterghast", Polterghast);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("DevourerofGodsBag")))
				{
				TooltipLine line = new TooltipLine(mod, "DevourerofGods", DevourerofGods);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("BumblebirbBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Bumblebirb", Bumblebirb);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("YharonBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Yharon", Yharon);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
			}
			if (ModLoader.GetMod("ThoriumMod") != null)
			{
				if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("DarkMageBag")))
				{
				TooltipLine line = new TooltipLine(mod, "DarkMage", DarkMage);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("OgreBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Ogre", Ogre);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("ThunderBirdBag")))
				{
				TooltipLine line = new TooltipLine(mod, "ThunderBird", ThunderBird);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("JellyFishBag")))
				{
				TooltipLine line = new TooltipLine(mod, "QueenJellyfish", QueenJellyfish);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("CountBag")))
				{
				TooltipLine line = new TooltipLine(mod, "CountEcho", CountEcho);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("GraniteBag")))
				{
				TooltipLine line = new TooltipLine(mod, "GraniteEnergyStorm", GraniteEnergyStorm);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("HeroBag")))
				{
				TooltipLine line = new TooltipLine(mod, "TheBuriedChampion", TheBuriedChampion);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("ScouterBag")))
				{
				TooltipLine line = new TooltipLine(mod, "TheStarScouter", TheStarScouter);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("BoreanBag")))
				{
				TooltipLine line = new TooltipLine(mod, "BoreanStrider", BoreanStrider);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("BeholderBag")))
				{
				TooltipLine line = new TooltipLine(mod, "CoznixTheFallenBeholder", CoznixTheFallenBeholder);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("LichBag")))
				{
				TooltipLine line = new TooltipLine(mod, "TheLich", TheLich);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("AbyssionBag")))
				{
				TooltipLine line = new TooltipLine(mod, "AbyssionTheForgottenOne", AbyssionTheForgottenOne);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("RagBag")))
				{
				TooltipLine line = new TooltipLine(mod, "TheRagnarok", TheRagnarok);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
			}
			if (ModLoader.GetMod("AAMod") != null)
			{
				if (item.type == (ModLoader.GetMod("AAMod").ItemType("MonarchBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Monarch", Monarch);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("AAMod").ItemType("GripBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Grips", Grips);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("AAMod").ItemType("BroodBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Broodmother", Broodmother);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("AAMod").ItemType("HydraBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Hydra", Hydra);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("AAMod").ItemType("SerpentBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Serpent", Serpent);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("AAMod").ItemType("DjinnBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Djinn", Djinn);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("AAMod").ItemType("RetrieverBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Retriever", Retriever);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("AAMod").ItemType("RaiderBag")))
				{
				TooltipLine line = new TooltipLine(mod, "RaiderU", RaiderU);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("AAMod").ItemType("OrthrusBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Orthrus", Orthrus);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("AAMod").ItemType("EFishBag")))
				{
				TooltipLine line = new TooltipLine(mod, "EFish", EFish);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("AAMod").ItemType("DBBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Daybringer", Daybringer);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("AAMod").ItemType("NCBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Nightcrawler", Nightcrawler);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("AAMod").ItemType("YamataBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Yamata", Yamata);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("AAMod").ItemType("AkumaBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Akuma", Akuma);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("AAMod").ItemType("ZeroBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Zero", Zero);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("AAMod").ItemType("ShenCache")))
				{
				TooltipLine line = new TooltipLine(mod, "Shen", Shen);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("AAMod").ItemType("GripSBag")))
				{
				TooltipLine line = new TooltipLine(mod, "ShenGrips", ShenGrips);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
			}
			if (ModLoader.GetMod("SacredTools") != null)
			{
				if (item.type == (ModLoader.GetMod("SacredTools").ItemType("PumpkinBag")))
				{
				TooltipLine line = new TooltipLine(mod, "FlamingPumpkin", FlamingPumpkin);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("SacredTools").ItemType("HarpyBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Jensen", Jensen);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("SacredTools").ItemType("HarpyBag2")))
				{
				TooltipLine line = new TooltipLine(mod, "Raynare", Raynare);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("SacredTools").ItemType("OblivionBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Abaddon", Abaddon);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("SacredTools").ItemType("SerpentBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Araghur", Araghur);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("SacredTools").ItemType("LunarBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Lunarians", Lunarians);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("SacredTools").ItemType("ChallengerBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Challenger", Challenger);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
			}
			if (ModLoader.GetMod("SpiritMod") != null)
			{
				if (item.type == (ModLoader.GetMod("SpiritMod").ItemType("BagOScarabs")))
				{
				TooltipLine line = new TooltipLine(mod, "Scarabeus", Scarabeus);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("SpiritMod").ItemType("ReachBossBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Bane", Bane);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("SpiritMod").ItemType("FlyerBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Flier", Flier);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("SpiritMod").ItemType("SteamRaiderBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Raider", Raider);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("SpiritMod").ItemType("InfernonBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Infernon", Infernon);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("SpiritMod").ItemType("DuskingBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Dusking", Dusking);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("SpiritMod").ItemType("SpiritCoreBag")))
				{
				TooltipLine line = new TooltipLine(mod, "EqualityComparer", EtherialUmbra);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("SpiritMod").ItemType("IlluminantBag")))
				{
				TooltipLine line = new TooltipLine(mod, "IlluminantMaster", IlluminantMaster);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("SpiritMod").ItemType("AtlasBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Atlas", Atlas);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("SpiritMod").ItemType("OverseerBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Overseer", Overseer);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
			}
			if (ModLoader.GetMod("Laugicality") != null)
			{
				if (item.type == (ModLoader.GetMod("Laugicality").ItemType("DuneSharkronTreasureBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Sharkron", Sharkron);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("Laugicality").ItemType("HypothemaTreasureBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Hypothema", Hypothema);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("Laugicality").ItemType("RagnarTreasureBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Ragnar", Ragnar);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("Laugicality").ItemType("AnDioTreasureBag")))
				{
				TooltipLine line = new TooltipLine(mod, "AnDio", AnDio);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("Laugicality").ItemType("AnnihilatorTreasureBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Annihilator", Annihilator);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("Laugicality").ItemType("SlybertronTreasureBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Slybertron", Slybertron);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("Laugicality").ItemType("SteamTrainTreasureBag")))
				{
				TooltipLine line = new TooltipLine(mod, "SteamTrain", SteamTrain);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
			}
			if (ModLoader.GetMod("pinkymod") != null)
			{
				if (item.type == (ModLoader.GetMod("pinkymod").ItemType("STBag")))
				{
				TooltipLine line = new TooltipLine(mod, "SunlightTrader", SunlightTrader);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("pinkymod").ItemType("HOTCTreasureBag")))
				{
				TooltipLine line = new TooltipLine(mod, "THOFC", THOFC);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("pinkymod").ItemType("MythrilBag")))
				{
				TooltipLine line = new TooltipLine(mod, "MythrilSlime", MythrilSlime);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("pinkymod").ItemType("Valdabag")))
				{
				TooltipLine line = new TooltipLine(mod, "Valdaris", Valdaris);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
				if (item.type == (ModLoader.GetMod("pinkymod").ItemType("GatekeeperTreasureBag")))
				{
				TooltipLine line = new TooltipLine(mod, "Gatekeeper", Gatekeeper);
				line.overrideColor = Color.LimeGreen;
				tooltips.Insert(1,line);
				}
			}
		}
		
		public override bool CloneNewInstances
		{
			get
			{
				return true;
			}
		}
		
		public override bool InstancePerEntity
		{
			get
			{
				return true;
			}
		}
	}
}
