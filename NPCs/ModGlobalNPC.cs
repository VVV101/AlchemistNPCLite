using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ReLogic.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent;
using Terraria.GameContent.Achievements;
using Terraria.GameContent.Events;
using Terraria.GameContent.Tile_Entities;
using Terraria.GameContent.UI;
using Terraria.GameInput;
using Terraria.Graphics.Capture;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.IO;
using Terraria.Localization;
using Terraria.ObjectData;
using Terraria.Social;
using Terraria.UI;
using Terraria.UI.Chat;
using Terraria.UI.Gamepad;
using Terraria.Utilities;
using Terraria.WorldBuilding;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader.IO;
using Terraria.GameContent.ItemDropRules;

namespace AlchemistNPCLite.NPCs
{
    public class ModGlobalNPC : GlobalNPC
    {
        public bool corrosion = false;
        public override bool InstancePerEntity
        {
            get
            {
                return true;
            }
        }

        public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
            for (int k = 0; k < 255; k++)
            {
                Player player = Main.player[k];
                if (player.active)
                {
                    if (type == ModContent.NPCType<Tinkerer>())
                    {
                        for (nextSlot = 0; nextSlot < 40; ++nextSlot)
                        {
                            shop.item[nextSlot].shopCustomPrice *= 2;
                        }
                    }
                    if (type == ModContent.NPCType<Brewer>() || type == ModContent.NPCType<Alchemist>() || type == ModContent.NPCType<YoungBrewer>())
                    {
                        for (nextSlot = 0; nextSlot < 40; ++nextSlot)
                        {
                            shop.item[nextSlot].shopCustomPrice *= AlchemistNPCLite.modConfiguration.PotsPriceMulti;
                            // IMPLEMENT WHEN WEAKREFERENCES FIXED
                            /*
							if (ModLoader.GetMod("CalamityMod") != null)
                            {
                                if (AlchemistNPCLite.modConfiguration.RevPrices && CalamityModRevengeance)
                                {
                                    shop.item[nextSlot].shopCustomPrice += shop.item[nextSlot].shopCustomPrice;
                                }
                            }
							*/
                            if ((player.GetModPlayer<AlchemistNPCLitePlayer>()).AlchemistCharmTier4)
                            {
                                shop.item[nextSlot].shopCustomPrice -= shop.item[nextSlot].shopCustomPrice / 2;
                            }
                            else if ((player.GetModPlayer<AlchemistNPCLitePlayer>()).AlchemistCharmTier3)
                            {
                                shop.item[nextSlot].shopCustomPrice -= ((shop.item[nextSlot].shopCustomPrice / 20) * 7);
                            }
                            else if ((player.GetModPlayer<AlchemistNPCLitePlayer>()).AlchemistCharmTier2)
                            {
                                shop.item[nextSlot].shopCustomPrice -= shop.item[nextSlot].shopCustomPrice / 4;
                            }
                            else if ((player.GetModPlayer<AlchemistNPCLitePlayer>()).AlchemistCharmTier1)
                            {
                                shop.item[nextSlot].shopCustomPrice -= shop.item[nextSlot].shopCustomPrice / 10;
                            }
                        }
                    }
                }
            }
            // IMPLEMENT WHEN WEAKREFERENCES FIXED
			/*
            if (ModLoader.GetMod("Tremor") != null)
            {
                if (type == ModLoader.GetMod("Tremor").NPCType("Lady Moon"))
                {
                    shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("DarkMass"));
                    shop.item[nextSlot].shopCustomPrice = 7500;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("CarbonSteel"));
                    shop.item[nextSlot].shopCustomPrice = 10000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("Doomstone"));
                    shop.item[nextSlot].shopCustomPrice = 25000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("NightmareBar"));
                    shop.item[nextSlot].shopCustomPrice = 25000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("VoidBar"));
                    shop.item[nextSlot].shopCustomPrice = 50000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("AngryShard"));
                    shop.item[nextSlot].shopCustomPrice = 50000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("Phantaplasm"));
                    shop.item[nextSlot].shopCustomPrice = 50000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("ClusterShard"));
                    shop.item[nextSlot].shopCustomPrice = 50000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("DragonCapsule"));
                    shop.item[nextSlot].shopCustomPrice = 50000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("HuskofDusk"));
                    shop.item[nextSlot].shopCustomPrice = 100000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("NightCore"));
                    shop.item[nextSlot].shopCustomPrice = 100000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("GoldenClaw"));
                    shop.item[nextSlot].shopCustomPrice = 100000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("StoneDice"));
                    shop.item[nextSlot].shopCustomPrice = 100000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("ConcentratedEther"));
                    shop.item[nextSlot].shopCustomPrice = 100000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("Squorb"));
                    shop.item[nextSlot].shopCustomPrice = 250000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("ToothofAbraxas"));
                    shop.item[nextSlot].shopCustomPrice = 250000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("CosmicFuel"));
                    shop.item[nextSlot].shopCustomPrice = 1000000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Tremor").ItemType("EyeofOblivion"));
                    shop.item[nextSlot].shopCustomPrice = 3000000;
                    nextSlot++;
                }
            }
			*/
        }

        public override void SetDefaults(NPC npc)
        {
            if (npc.type == NPCID.Steampunker || npc.type == NPCID.Wizard || npc.type == NPCID.Guide || npc.type == NPCID.Nurse || npc.type == NPCID.Demolitionist || npc.type == NPCID.Merchant || npc.type == NPCID.DyeTrader || npc.type == NPCID.Dryad || npc.type == NPCID.DD2Bartender || npc.type == NPCID.ArmsDealer || npc.type == NPCID.Stylist || npc.type == NPCID.Painter || npc.type == NPCID.Angler || npc.type == NPCID.GoblinTinkerer || npc.type == NPCID.WitchDoctor || npc.type == NPCID.Clothier || npc.type == NPCID.Mechanic || npc.type == NPCID.PartyGirl || npc.type == NPCID.TaxCollector || npc.type == NPCID.Truffle || npc.type == NPCID.Pirate || npc.type == NPCID.Cyborg || npc.type == NPCID.SantaClaus)
            {
                if (NPC.downedMoonlord)
                {
                    npc.lifeMax = 500;
                }
            }
            if (npc.type == ModContent.NPCType<Alchemist>() || npc.type == ModContent.NPCType<Brewer>() || npc.type == ModContent.NPCType<YoungBrewer>() || npc.type == ModContent.NPCType<Jeweler>() || npc.type == ModContent.NPCType<Architect>() || npc.type == ModContent.NPCType<Musician>() || npc.type == ModContent.NPCType<Tinkerer>())
            {
                if (NPC.downedMoonlord)
                {
                    npc.lifeMax = 500;
                }
            }
            // IMPLEMENT WHEN WEAKREFERENCES FIXED
            /*
			if (ModLoader.GetMod("MaterialTraderNpc") != null)
			{
				if (npc.type == (ModLoader.GetMod("MaterialTraderNpc").NPCType("Jungle Trader")) || npc.type == (ModLoader.GetMod("MaterialTraderNpc").NPCType("Cavern Trader")) || npc.type == (ModLoader.GetMod("MaterialTraderNpc").NPCType("Cool Guy")) || npc.type == (ModLoader.GetMod("MaterialTraderNpc").NPCType("Desert Trader")) || npc.type == (ModLoader.GetMod("MaterialTraderNpc").NPCType("Dungeon Trader")) || npc.type == (ModLoader.GetMod("MaterialTraderNpc").NPCType("Evil Trader")) || npc.type == (ModLoader.GetMod("MaterialTraderNpc").NPCType("Hell Trader")) || npc.type == (ModLoader.GetMod("MaterialTraderNpc").NPCType("Holy Trader")) || npc.type == (ModLoader.GetMod("MaterialTraderNpc").NPCType("Ocean Trader")) || npc.type == (ModLoader.GetMod("MaterialTraderNpc").NPCType("Sky Trader")) || npc.type == (ModLoader.GetMod("MaterialTraderNpc").NPCType("Winter Trader")))
				{
					if (NPC.downedMoonlord)
					{
						npc.lifeMax = 500;
					}
				}
			}
			*/
            if (npc.type == ModContent.NPCType<Alchemist>())
            {
                Main.npcCatchable[npc.type] = true;
                npc.catchItem = (short)ModContent.ItemType<Items.Summoning.AlchemistHorcrux>();
            }
            if (npc.type == ModContent.NPCType<Brewer>())
            {
                Main.npcCatchable[npc.type] = true;
                npc.catchItem = (short)ModContent.ItemType<Items.Summoning.BrewerHorcrux>();
            }
            if (npc.type == ModContent.NPCType<Architect>())
            {
                Main.npcCatchable[npc.type] = true;
                npc.catchItem = (short)ModContent.ItemType<Items.Summoning.ArchitectHorcrux>();
            }
            if (npc.type == ModContent.NPCType<Jeweler>())
            {
                Main.npcCatchable[npc.type] = true;
                npc.catchItem = (short)ModContent.ItemType<Items.Summoning.JewelerHorcrux>();
            }
            if (npc.type == ModContent.NPCType<Operator>())
            {
                Main.npcCatchable[npc.type] = true;
                npc.catchItem = (short)ModContent.ItemType<Items.Summoning.APMC>();
            }
            if (npc.type == ModContent.NPCType<Musician>())
            {
                Main.npcCatchable[npc.type] = true;
                npc.catchItem = (short)ModContent.ItemType<Items.Summoning.MusicianHorcrux>();
            }
            if (npc.type == ModContent.NPCType<Tinkerer>())
            {
                Main.npcCatchable[npc.type] = true;
                npc.catchItem = (short)ModContent.ItemType<Items.Summoning.TinkererHorcrux>();
            }
        }

        public override void TownNPCAttackStrength(NPC npc, ref int damage, ref float knockback)
        {
            if (npc.type == NPCID.Steampunker || npc.type == NPCID.Wizard || npc.type == NPCID.Guide || npc.type == NPCID.Nurse || npc.type == NPCID.Demolitionist || npc.type == NPCID.Merchant || npc.type == NPCID.DyeTrader || npc.type == NPCID.Dryad || npc.type == NPCID.DD2Bartender || npc.type == NPCID.ArmsDealer || npc.type == NPCID.Stylist || npc.type == NPCID.Painter || npc.type == NPCID.Angler || npc.type == NPCID.GoblinTinkerer || npc.type == NPCID.WitchDoctor || npc.type == NPCID.Clothier || npc.type == NPCID.Mechanic || npc.type == NPCID.PartyGirl || npc.type == NPCID.TaxCollector || npc.type == NPCID.Truffle || npc.type == NPCID.Pirate || npc.type == NPCID.Cyborg || npc.type == NPCID.SantaClaus)
            {
                if (Main.hardMode && !NPC.downedMoonlord)
                {
                    damage += 20;
                }
                if (NPC.downedMoonlord)
                {
                    damage = 100;
                }
            }
        }

        public override void TownNPCAttackCooldown(NPC npc, ref int cooldown, ref int randExtraCooldown)
        {
            if (npc.type == NPCID.Steampunker)
            {
                if (NPC.downedMoonlord)
                {
                    cooldown = 4;
                    randExtraCooldown = 4;
                }
            }
            if (npc.type == NPCID.Steampunker)
            {
                if (NPC.downedMoonlord)
                {
                    cooldown = 3;
                    randExtraCooldown = 3;
                }
            }
            if (npc.type == NPCID.Guide)
            {
                if (NPC.downedMoonlord)
                {
                    cooldown = 3;
                }
            }
        }

        public override void TownNPCAttackProj(NPC npc, ref int projType, ref int attackDelay)
        {
            if (npc.type == NPCID.ArmsDealer)
            {
                if (NPC.downedMoonlord)
                {
                    attackDelay = 4;
                    projType = ProjectileID.MoonlordBullet;
                }
            }
            if (npc.type == NPCID.Steampunker)
            {
                if (NPC.downedMoonlord)
                {
                    attackDelay = 3;
                    projType = ProjectileID.MoonlordBullet;
                }
            }
            if (npc.type == NPCID.Cyborg)
            {
                if (NPC.downedMoonlord)
                {
                    attackDelay = 3;
                    projType = ProjectileID.RocketSnowmanI;
                }
            }
            if (npc.type == NPCID.Wizard)
            {
                if (NPC.downedMoonlord)
                {
                    projType = ProjectileID.CursedFlameFriendly;
                }
            }
            if (npc.type == NPCID.Guide)
            {
                if (NPC.downedMoonlord)
                {
                    projType = ProjectileID.MoonlordArrow;
                }
            }
        }

        public override void DrawTownAttackGun(NPC npc, ref float scale, ref int item, ref int closeness)
        {
            if (npc.type == NPCID.ArmsDealer)
            {
                if (NPC.downedMoonlord)
                {
                    item = ItemID.Megashark;
                }
            }
            if (npc.type == NPCID.Steampunker)
            {
                if (NPC.downedMoonlord)
                {
                    scale = 1f;
                    closeness = 4;
                    item = ItemID.SDMG;
                }
            }
        }

        public override void BuffTownNPC(ref float damageMult, ref int defense)
        {
            if (Main.hardMode && !NPC.downedMoonlord)
            {
                defense += 30;
            }
            if (NPC.downedMoonlord)
            {
                defense += 80;
            }
        }

        public override void DrawEffects(NPC npc, ref Color drawColor)
        {
            for (int k = 0; k < 255; k++)
            {
                Player player = Main.player[k];
                if (player.active && player.HasBuff(ModContent.BuffType<Buffs.GreaterDangersense>()))
                {
                    if (npc.type == 112)
                    {
                        npc.color = new Color(255, 255, 0, 100);
                        Lighting.AddLight(npc.position, 1f, 1f, 0f);
                    }
                }
            }
        }
        public override void OnKill(NPC npc)
        {
            base.OnKill(npc);

            if (npc.type == NPCID.SandElemental)
            {
                if (!AlchemistNPCLiteWorld.downedSandElemental)
                {
                    AlchemistNPCLiteWorld.downedSandElemental = true;
                    if (Main.netMode == NetmodeID.Server)
                    {
                        NetMessage.SendData(MessageID.WorldData);
                    }
                }
            }
        }
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            base.ModifyNPCLoot(npc, npcLoot);

        	if (npc.type == NPCID.EyeofCthulhu)
        	{
        		if (!NPC.downedBoss1)
        		{
				    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.AlchemistCharmTier1>(), 1));
        		}
        	}
            if (npc.type == NPCID.WallofFlesh)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Misc.LuckCharm>(), 1));
            }
            if (npc.type == ModContent.NPCType<Operator>())
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Summoning.APMC>(), 1));
            }
        }

        // IMPLEMENT WHEN WEAKREFERENCES FIXED
        /*
        public override void NPCLoot(NPC npc)
        {
            Mod Calamity = ModLoader.GetMod("CalamityMod");
            if (Calamity != null)
            {
                if ((bool)Calamity.Call("Downed", "dog") && npc.type == 327)
                {
                    if (!AlchemistNPCLiteWorld.downedDOGPumpking)
                    {
                        AlchemistNPCLiteWorld.downedDOGPumpking = true;
                        if (Main.netMode == NetmodeID.Server)
                        {
                            NetMessage.SendData(MessageID.WorldData); // Immediately inform clients of new world state.
                        }
                    }
                }

                if ((bool)Calamity.Call("Downed", "dog") && npc.type == 345)
                {
                    if (!AlchemistNPCLiteWorld.downedDOGIceQueen)
                    {
                        AlchemistNPCLiteWorld.downedDOGIceQueen = true;
                        if (Main.netMode == NetmodeID.Server)
                        {
                            NetMessage.SendData(MessageID.WorldData); // Immediately inform clients of new world state.
                        }
                    }
                }
            }
        }

		public bool CalamityModRevengeance
		{
        	get { return CalamityMod.World.CalamityWorld.revenge; }
        }
		
		private readonly Mod Calamity = ModLoader.GetMod("CalamityMod");
		*/
    }
}
