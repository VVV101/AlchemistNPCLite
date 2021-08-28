using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ReLogic.Utilities;
using System;
using System.Linq;
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
using Terraria.WorldBuilding;	//Changed
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader.IO;
using AlchemistNPCLite.Interface;
using AlchemistNPCLite;
using AlchemistNPCLite.Items;

namespace AlchemistNPCLite
{
	public class AlchemistNPCLitePlayer : ModPlayer
	{
		public bool BoomBox = false;
		public bool DistantPotionsUse = false;
		public bool Voodoo = false;
		public bool Luck = false;
		public bool AlchemistCharmTier1 = false;
		public bool AlchemistCharmTier2 = false;
		public bool AlchemistCharmTier3 = false;
		public bool AlchemistCharmTier4 = false;
		public bool Traps = false;
		public bool ModPlayer = true;
		
		public bool AllDamage10 = false;
		public bool AllCrit10 = false;
		public bool Defense8 = false;
		public bool DR10 = false;
		public bool Regeneration = false;
		public bool Lifeforce = false;
		public bool MS = false;
		
		public override void ResetEffects()
		{
			BoomBox = false;
			DistantPotionsUse = false;
			Luck = false;
			AlchemistGlobalItem.Luck = false;
			AlchemistGlobalItem.Luck2 = false;
			AlchemistNPCLite.GreaterDangersense = false;
			AlchemistCharmTier1 = false;
			AlchemistCharmTier2 = false;
			AlchemistCharmTier3 = false;
			AlchemistCharmTier4 = false;
			Traps = false;
			
			AllDamage10 = false;
			AllCrit10 = false;
			Defense8 = false;
			DR10 = false;
			Regeneration = false;
			Lifeforce = false;
			MS = false;
			
			if (Main.netMode == 0)
			{
				if (Player.talkNPC == -1)
				{
					ShopChangeUI.visible = false;
					ShopChangeUIA.visible = false;
					ShopChangeUIO.visible = false;
					ShopChangeUIM.visible = false;
				}
			}
		}
	
	
		public override void clientClone(ModPlayer clientClone)
		{
			AlchemistNPCLitePlayer clone = clientClone as AlchemistNPCLitePlayer;
		}
	
		public override void SendClientChanges(ModPlayer clientPlayer)
		{
		}
		
		//public override void UpdateEquips(ref bool wallSpeedBuff, ref bool tileSpeedBuff, ref bool tileRangeBuff)
		public override void UpdateEquips()
		{
		// Mod Calamity = ModLoader.GetMod("CalamityMod");
			/*
			//IMPLEMENT ANOTHER TIME
			if(Calamity != null)
			{
				//if (!Player.HasBuff(ModLoader.GetMod("CalamityMod").BuffType("HolyWrathBuff")) && AllDamage10) Player.GetDamage(DamageClass.Generic)+= 0.1f;
				if (!Player.HasBuff(ModLoader.GetMod("CalamityMod").GetContent<>()) && AllDamage10) Player.GetDamage(DamageClass.Generic)+= 0.1f;
				if (!Player.HasBuff(ModLoader.GetMod("CalamityMod").BuffType("ProfanedRageBuff")) && AllCrit10)
				{
					Player.GetCritChance(DamageClass.Melee) += 10;
					Player.GetCritChance(DamageClass.Ranged) += 10;
					Player.GetCritChance(DamageClass.Magic) += 10;
					Player.GetCritChance(DamageClass.Throwing) += 10;
					if (ModLoader.GetMod("ThoriumMod") != null)
					{
						ThoriumBoosts(Player);
					}
					if (ModLoader.GetMod("Redemption") != null)
					{
						RedemptionBoost(Player);
					}
					Calamity.Call("AddRogueCrit", Player, 10);
				}
				//if (!Player.HasBuff(ModContent.BuffType<Buffs.CalamityComb>()) && !Player.HasBuff(ModLoader.GetMod("CalamityMod").BuffType("Cadence")) && Regeneration) Player.lifeRegen += 4;
				if (!Player.HasBuff(ModContent.BuffType<Buffs.CalamityComb>()) && !Player.HasBuff(ModLoader.GetMod("CalamityMod").BuffType("Cadence")) && Regeneration) Player.lifeRegen += 4;
				if (!Player.HasBuff(ModContent.BuffType<Buffs.CalamityComb>()) && !Player.HasBuff(ModLoader.GetMod("CalamityMod").BuffType("Cadence")) && Lifeforce)
				{
					Player.lifeForce = true;
					Player.statLifeMax2 += Player.statLifeMax / 5 / 20 * 20;
				}
			}*/
			// if (ModLoader.GetMod("CalamityMod") == null)
			// {
			// 	if (AllDamage10) Player.GetDamage(DamageClass.Generic) += 0.1f;
			// 	if (AllCrit10)
			// 	{
			// 		Player.GetCritChance(DamageClass.Melee) += 10;
			// 		Player.GetCritChance(DamageClass.Ranged) += 10;
			// 		Player.GetCritChance(DamageClass.Magic) += 10;
			// 		Player.GetCritChance(DamageClass.Throwing) += 10;
			// 		if (ModLoader.GetMod("ThoriumMod") != null)
			// 		{
			// 			ThoriumBoosts(Player);
			// 		}
			// 		if (ModLoader.GetMod("Redemption") != null)
			// 		{
			// 			RedemptionBoost(Player);
			// 		}
			// 	}
			// 	if (Regeneration) Player.lifeRegen += 4;
			// 	if (Lifeforce)
			// 	{
			// 		Player.lifeForce = true;
			// 		Player.statLifeMax2 += Player.statLifeMax / 5 / 20 * 20;
			// 	}
			// }
			if (MS) Player.moveSpeed += 0.25f;
			if (Defense8) Player.statDefense += 8;
			if (DR10) Player.endurance += 0.1f;
		}
		
		private void CalamityBoost(Player player)
        {
			//IMPLEMENT LATER
			// CalamityMod.CalPlayer.CalamityPlayer CalamityPlayer = Player.GetModPlayer<CalamityMod.CalPlayer.CalamityPlayer>();
			// CalamityPlayer.throwingCrit += 10;
        }
		private void RedemptionBoost(Player player)
        {
			//IMPLEMENT LATER
			// Redemption.Items.DruidDamageClass.DruidDamagePlayer RedemptionPlayer = Player.GetModPlayer<Redemption.Items.DruidDamageClass.DruidDamagePlayer>();
			// RedemptionPlayer.druidCrit += 10;
        }
		private void ThoriumBoosts(Player player)
        {
			//IMPLEMENT LATER
            // ThoriumMod.ThoriumPlayer ThoriumPlayer = Player.GetModPlayer<ThoriumMod.ThoriumPlayer>();
            // ThoriumPlayer.symphonicCrit += 10;
			// ThoriumPlayer.radiantCrit += 10;
        }
		
		public override void ProcessTriggers(TriggersSet triggersSet)
		{
			if (DistantPotionsUse && PlayerInput.Triggers.Current.QuickBuff)
			{
				LegacySoundStyle type1 = (LegacySoundStyle) null;
				for (int index1 = 0; index1 < 40; ++index1)
				  {
					if (Player.CountBuffs() == 22)
					  return;
					if (Player.bank.item[index1].stack > 0 && Player.bank.item[index1].type > 0 && (Player.bank.item[index1].buffType > 0 && !Player.bank.item[index1].CountsAsClass(DamageClass.Summon)) && Player.bank.item[index1].buffType != 90)
					{
						// if (ModLoader.GetMod("CalamityMod") != null)
						// {
						// 	//IMPLEMENT LATER
						// 	// if (Player.bank.item[index1].buffType == ModLoader.GetMod("CalamityMod").BuffType("AbsoluteRage"))
						// 	// {
						// 	// 	for (int v = 0; v < 200; ++v)
						// 	// 	{
						// 	// 		NPC npc = Main.npc[v];
						// 	// 		if (NPC.active && NPC.boss)
						// 	// 		{
						// 	// 			return;
						// 	// 		}
						// 	// 	}
						// 	// 	CalamityRage(Player);
						// 	// }
						// }
					  int type2 = Player.bank.item[index1].buffType;
					  bool flag = true;
					  for (int index2 = 0; index2 < 22; ++index2)
					  {
						if (type2 == 27 && (Player.buffType[index2] == type2 || Player.buffType[index2] == 101 || Player.buffType[index2] == 102))
						{
						  flag = false;
						  break;
						}
						if (Player.buffType[index2] == type2)
						{
						  flag = false;
						  break;
						}
						if (Main.meleeBuff[type2] && Main.meleeBuff[Player.buffType[index2]])
						{
						  flag = false;
						  break;
						}
					  }
					  if (Main.lightPet[Player.bank.item[index1].buffType] || Main.vanityPet[Player.bank.item[index1].buffType])
					  {
						for (int index2 = 0; index2 < 22; ++index2)
						{
						  if (Main.lightPet[Player.buffType[index2]] && Main.lightPet[Player.bank.item[index1].buffType])
							flag = false;
						  if (Main.vanityPet[Player.buffType[index2]] && Main.vanityPet[Player.bank.item[index1].buffType])
							flag = false;
						}
					  }
					  if (Player.bank.item[index1].mana > 0 & flag)
					  {
						if (Player.statMana >= (int) ((double) Player.bank.item[index1].mana * (double) Player.manaCost))
						{
						  Player.manaRegenDelay = (int) Player.maxRegenDelay;
						  Player.statMana = Player.statMana - (int) ((double) Player.bank.item[index1].mana * (double) Player.manaCost);
						}
						else
						  flag = false;
					  }
					  if (Player.whoAmI == Main.myPlayer && Player.bank.item[index1].type == 603 && !Main.runningCollectorsEdition)
						flag = false;
					  if (type2 == 27)
					  {
						type2 = Main.rand.Next(3);
						if (type2 == 0)
						  type2 = 27;
						if (type2 == 1)
						  type2 = 101;
						if (type2 == 2)
						  type2 = 102;
					  }
					  if (flag)
					  {
						type1 = Player.bank.item[index1].UseSound;
						int time1 = Player.bank.item[index1].buffTime;
						if (time1 == 0)
						  time1 = 3600;
					  
					  if (AlchemistCharmTier4)
					  {
						time1 += time1/2;
					  }
					  else if (AlchemistCharmTier3)
					  {
						time1 += (time1/20)*7;
					  }
					  else if (AlchemistCharmTier2)
					  {
						time1 += time1/4;
					  }
					  else if (AlchemistCharmTier1)
					  {
						time1 += time1/10;
					  }
					  
						Player.AddBuff(type2, time1, true);
						
						if (Player.bank.item[index1].consumable)
						{
							if (AlchemistCharmTier4 == true)
							{
							// Mod Calamity = ModLoader.GetMod("CalamityMod");
								// if (Calamity != null)
								// {
								// 	if ((bool)Calamity.Call("Downed", "supreme calamitas"))
								// 	{
								// 	}
								// 	else if (Main.rand.NextFloat() >= .25f)
								// 	{
								// 	}
								// 	else
								// 	{
								// 		--Player.bank.item[index1].stack;
								// 	}
								// }
								if (Main.rand.NextFloat() >= .25f)	//Replaced else if	
								{
								}
								else
								{
									--Player.bank.item[index1].stack;
								}
							}
							
							else if (AlchemistCharmTier3 == true)
							{
								if (Main.rand.Next(2) == 0)
								{
								}
								else
								{
									--Player.bank.item[index1].stack;
								}
							}
							
							else if (AlchemistCharmTier2 == true)
							{
								if (Main.rand.Next(4) == 0)
								{
								}
								else
								{
									--Player.bank.item[index1].stack;
								}
							}
							
							else if (AlchemistCharmTier1 == true)
							{
								if (Main.rand.Next(10) == 0)
								{
								}
								else
								{
									--Player.bank.item[index1].stack;
								}
							}
							else
							{
								--Player.bank.item[index1].stack;
							}
						  if (Player.bank.item[index1].stack <= 0)
							Player.bank.item[index1].TurnToAir();
						}
					  }
					}
				  }
				if (type1 == null)
				return;
				SoundEngine.PlaySound(type1, Player.position);	//Changed
				Recipe.FindRecipes();
			}
			if (AlchemistNPCLite.DiscordBuff.JustPressed)
			{
				if (Main.myPlayer == Player.whoAmI && Player.HasBuff(ModContent.BuffType<Buffs.DiscordBuff>()))
				{
				Vector2 vector2 = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
					if (!Collision.SolidCollision(vector2, Player.width, Player.height))
					{
						Player.Teleport(vector2, 1, 0);
						NetMessage.SendData(65, -1, -1, (NetworkText) null, 0, (float) Player.whoAmI, (float) vector2.X, (float) vector2.Y, 1, 0, 0);
						if (Player.chaosState)
						{
							Player.statLife = Player.statLife - Player.statLifeMax2 / 3;
							PlayerDeathReason damageSource = PlayerDeathReason.ByOther(13);
							if (Main.rand.Next(2) == 0)
							damageSource = PlayerDeathReason.ByOther(Player.Male ? 14 : 15);
							if (Player.statLife <= 0)
							Player.KillMe(damageSource, 1.0, 0, false);
							Player.lifeRegenCount = 0;
							Player.lifeRegenTime = 0;
						}
						Player.AddBuff(88, 600, true);
						Player.AddBuff(164, 60, true);
					}
				}
				if (Main.myPlayer == Player.whoAmI && Player.HasBuff(ModContent.BuffType<Buffs.TrueDiscordBuff>()))
				{
				Vector2 vector2 = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
				if (!Collision.SolidCollision(vector2, Player.width, Player.height))
				{
					Player.Teleport(vector2, 1, 0);
					NetMessage.SendData(65, -1, -1, (NetworkText) null, 0, (float) Player.whoAmI, (float) vector2.X, (float) vector2.Y, 1, 0, 0);
						if (Player.chaosState)
						{
							Player.statLife = Player.statLife - Player.statLifeMax2 / 7;
							PlayerDeathReason damageSource = PlayerDeathReason.ByOther(13);
							if (Main.rand.Next(2) == 0)
							damageSource = PlayerDeathReason.ByOther(Player.Male ? 14 : 15);
							if (Player.statLife <= 0)
							Player.KillMe(damageSource, 1.0, 0, false);
							Player.lifeRegenCount = 0;
							Player.lifeRegenTime = 0;
						}
					Player.AddBuff(88, 360, true);
					}
				}
			}
		}
		
		private void CalamityRage(Player player)
        {
			//IMPLEMENT LATER
			// CalamityMod.CalPlayer.CalamityPlayer CalamityPlayer = Player.GetModPlayer<CalamityMod.CalPlayer.CalamityPlayer>();
			// CalamityPlayer.rage = CalamityPlayer.rageMax;
        }
	}
}