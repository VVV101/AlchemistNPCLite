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
using Terraria.World.Generation;
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
				if (player.talkNPC == -1)
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
		
		public override void UpdateEquips(ref bool wallSpeedBuff, ref bool tileSpeedBuff, ref bool tileRangeBuff)
		{
			Mod Calamity = ModLoader.GetMod("CalamityMod");
			if(Calamity != null)
			{
				if (!player.HasBuff(ModLoader.GetMod("CalamityMod").BuffType("HolyWrathBuff")) && AllDamage10) player.allDamage += 0.1f;
				if (!player.HasBuff(ModLoader.GetMod("CalamityMod").BuffType("ProfanedRageBuff")) && AllCrit10)
				{
					player.meleeCrit += 10;
					player.rangedCrit += 10;
					player.magicCrit += 10;
					player.thrownCrit += 10;
					if (ModLoader.GetMod("ThoriumMod") != null)
					{
						ThoriumBoosts(player);
					}
					if (ModLoader.GetMod("Redemption") != null)
					{
						RedemptionBoost(player);
					}
					Calamity.Call("AddRogueCrit", player, 10);
				}
				if (!player.HasBuff(mod.BuffType("CalamityComb")) && !player.HasBuff(ModLoader.GetMod("CalamityMod").BuffType("Cadence")) && Regeneration) player.lifeRegen += 4;
				if (!player.HasBuff(mod.BuffType("CalamityComb")) && !player.HasBuff(ModLoader.GetMod("CalamityMod").BuffType("Cadence")) && Lifeforce)
				{
					player.lifeForce = true;
					player.statLifeMax2 += player.statLifeMax / 5 / 20 * 20;
				}
			}
			if (ModLoader.GetMod("CalamityMod") == null)
			{
				if (AllDamage10) player.allDamage += 0.1f;
				if (AllCrit10)
				{
					player.meleeCrit += 10;
					player.rangedCrit += 10;
					player.magicCrit += 10;
					player.thrownCrit += 10;
					if (ModLoader.GetMod("ThoriumMod") != null)
					{
						ThoriumBoosts(player);
					}
					if (ModLoader.GetMod("Redemption") != null)
					{
						RedemptionBoost(player);
					}
				}
				if (Regeneration) player.lifeRegen += 4;
				if (Lifeforce)
				{
					player.lifeForce = true;
					player.statLifeMax2 += player.statLifeMax / 5 / 20 * 20;
				}
			}
			if (MS) player.moveSpeed += 0.25f;
			if (Defense8) player.statDefense += 8;
			if (DR10) player.endurance += 0.1f;
		}
		
		private void CalamityBoost(Player player)
        {
			CalamityMod.CalPlayer.CalamityPlayer CalamityPlayer = player.GetModPlayer<CalamityMod.CalPlayer.CalamityPlayer>();
			CalamityPlayer.throwingCrit += 10;
        }
		private void RedemptionBoost(Player player)
        {
			Redemption.Items.DruidDamageClass.DruidDamagePlayer RedemptionPlayer = player.GetModPlayer<Redemption.Items.DruidDamageClass.DruidDamagePlayer>();
			RedemptionPlayer.druidCrit += 10;
        }
		private void ThoriumBoosts(Player player)
        {
            ThoriumMod.ThoriumPlayer ThoriumPlayer = player.GetModPlayer<ThoriumMod.ThoriumPlayer>();
            ThoriumPlayer.symphonicCrit += 10;
			ThoriumPlayer.radiantCrit += 10;
        }
		
		public override void ProcessTriggers(TriggersSet triggersSet)
		{
			if (DistantPotionsUse && PlayerInput.Triggers.Current.QuickBuff)
			{
				LegacySoundStyle type1 = (LegacySoundStyle) null;
				for (int index1 = 0; index1 < 40; ++index1)
				  {
					if (player.CountBuffs() == 22)
					  return;
					if (player.bank.item[index1].stack > 0 && player.bank.item[index1].type > 0 && (player.bank.item[index1].buffType > 0 && !player.bank.item[index1].summon) && player.bank.item[index1].buffType != 90)
					{
						if (ModLoader.GetMod("CalamityMod") != null)
						{
							if (player.bank.item[index1].buffType == ModLoader.GetMod("CalamityMod").BuffType("AbsoluteRage"))
							{
								for (int v = 0; v < 200; ++v)
								{
									NPC npc = Main.npc[v];
									if (npc.active && npc.boss)
									{
										return;
									}
								}
								CalamityRage(player);
							}
						}
					  int type2 = player.bank.item[index1].buffType;
					  bool flag = true;
					  for (int index2 = 0; index2 < 22; ++index2)
					  {
						if (type2 == 27 && (player.buffType[index2] == type2 || player.buffType[index2] == 101 || player.buffType[index2] == 102))
						{
						  flag = false;
						  break;
						}
						if (player.buffType[index2] == type2)
						{
						  flag = false;
						  break;
						}
						if (Main.meleeBuff[type2] && Main.meleeBuff[player.buffType[index2]])
						{
						  flag = false;
						  break;
						}
					  }
					  if (Main.lightPet[player.bank.item[index1].buffType] || Main.vanityPet[player.bank.item[index1].buffType])
					  {
						for (int index2 = 0; index2 < 22; ++index2)
						{
						  if (Main.lightPet[player.buffType[index2]] && Main.lightPet[player.bank.item[index1].buffType])
							flag = false;
						  if (Main.vanityPet[player.buffType[index2]] && Main.vanityPet[player.bank.item[index1].buffType])
							flag = false;
						}
					  }
					  if (player.bank.item[index1].mana > 0 & flag)
					  {
						if (player.statMana >= (int) ((double) player.bank.item[index1].mana * (double) player.manaCost))
						{
						  player.manaRegenDelay = (int) player.maxRegenDelay;
						  player.statMana = player.statMana - (int) ((double) player.bank.item[index1].mana * (double) player.manaCost);
						}
						else
						  flag = false;
					  }
					  if (player.whoAmI == Main.myPlayer && player.bank.item[index1].type == 603 && !Main.cEd)
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
						type1 = player.bank.item[index1].UseSound;
						int time1 = player.bank.item[index1].buffTime;
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
					  
						player.AddBuff(type2, time1, true);
						
						if (player.bank.item[index1].consumable)
						{
							if (AlchemistCharmTier4 == true)
							{
								Mod Calamity = ModLoader.GetMod("CalamityMod");
								if (Calamity != null)
								{
									if ((bool)Calamity.Call("Downed", "supreme calamitas"))
									{
									}
									else if (Main.rand.NextFloat() >= .25f)
									{
									}
									else
									{
										--player.bank.item[index1].stack;
									}
								}
								else if (Main.rand.NextFloat() >= .25f)
								{
								}
								else
								{
									--player.bank.item[index1].stack;
								}
							}
							
							else if (AlchemistCharmTier3 == true)
							{
								if (Main.rand.Next(2) == 0)
								{
								}
								else
								{
									--player.bank.item[index1].stack;
								}
							}
							
							else if (AlchemistCharmTier2 == true)
							{
								if (Main.rand.Next(4) == 0)
								{
								}
								else
								{
									--player.bank.item[index1].stack;
								}
							}
							
							else if (AlchemistCharmTier1 == true)
							{
								if (Main.rand.Next(10) == 0)
								{
								}
								else
								{
									--player.bank.item[index1].stack;
								}
							}
							else
							{
								--player.bank.item[index1].stack;
							}
						  if (player.bank.item[index1].stack <= 0)
							player.bank.item[index1].TurnToAir();
						}
					  }
					}
				  }
				if (type1 == null)
				return;
				Main.PlaySound(type1, player.position);
				Recipe.FindRecipes();
			}
			if (AlchemistNPCLite.DiscordBuff.JustPressed)
			{
				if (Main.myPlayer == player.whoAmI && player.HasBuff(mod.BuffType("DiscordBuff")))
				{
				Vector2 vector2 = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
					if (!Collision.SolidCollision(vector2, player.width, player.height))
					{
						player.Teleport(vector2, 1, 0);
						NetMessage.SendData(65, -1, -1, (NetworkText) null, 0, (float) player.whoAmI, (float) vector2.X, (float) vector2.Y, 1, 0, 0);
						if (player.chaosState)
						{
							player.statLife = player.statLife - player.statLifeMax2 / 3;
							PlayerDeathReason damageSource = PlayerDeathReason.ByOther(13);
							if (Main.rand.Next(2) == 0)
							damageSource = PlayerDeathReason.ByOther(player.Male ? 14 : 15);
							if (player.statLife <= 0)
							player.KillMe(damageSource, 1.0, 0, false);
							player.lifeRegenCount = 0;
							player.lifeRegenTime = 0;
						}
						player.AddBuff(88, 600, true);
						player.AddBuff(164, 60, true);
					}
				}
				if (Main.myPlayer == player.whoAmI && player.HasBuff(mod.BuffType("TrueDiscordBuff")))
				{
				Vector2 vector2 = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
				if (!Collision.SolidCollision(vector2, player.width, player.height))
				{
					player.Teleport(vector2, 1, 0);
					NetMessage.SendData(65, -1, -1, (NetworkText) null, 0, (float) player.whoAmI, (float) vector2.X, (float) vector2.Y, 1, 0, 0);
						if (player.chaosState)
						{
							player.statLife = player.statLife - player.statLifeMax2 / 7;
							PlayerDeathReason damageSource = PlayerDeathReason.ByOther(13);
							if (Main.rand.Next(2) == 0)
							damageSource = PlayerDeathReason.ByOther(player.Male ? 14 : 15);
							if (player.statLife <= 0)
							player.KillMe(damageSource, 1.0, 0, false);
							player.lifeRegenCount = 0;
							player.lifeRegenTime = 0;
						}
					player.AddBuff(88, 360, true);
					}
				}
			}
		}
		
		private void CalamityRage(Player player)
        {
			CalamityMod.CalPlayer.CalamityPlayer CalamityPlayer = player.GetModPlayer<CalamityMod.CalPlayer.CalamityPlayer>();
			CalamityPlayer.rage = CalamityPlayer.rageMax;
        }
	}
}