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
using Terraria.World.Generation;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using AlchemistNPCLite;
using AlchemistNPCLite.Items;

namespace AlchemistNPCLite
{
	public class AlchemistNPCLitePlayer : ModPlayer
	{
		public bool DistantPotionsUse = false;
		public bool Voodoo = false;
		public bool Luck = false;
		public bool AlchemistCharmTier1 = false;
		public bool AlchemistCharmTier2 = false;
		public bool AlchemistCharmTier3 = false;
		public bool AlchemistCharmTier4 = false;
		public bool Traps = false;
		public bool ModPlayer = true;
		
		public override void ResetEffects()
		{
			DistantPotionsUse = false;
			Luck = false;
			AlchemistGlobalItem.Luck = false;
			AlchemistGlobalItem.Luck2 = false;
			AlchemistCharmTier1 = false;
			AlchemistCharmTier2 = false;
			AlchemistCharmTier3 = false;
			AlchemistCharmTier4 = false;
			Traps = false;
		}
	
	
		public override void clientClone(ModPlayer clientClone)
		{
			AlchemistNPCLitePlayer clone = clientClone as AlchemistNPCLitePlayer;
		}
	
		public override void SendClientChanges(ModPlayer clientPlayer)
		{
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
						player.AddBuff(type2, time1, true);
						if (player.bank.item[index1].consumable)
						{
						  --player.bank.item[index1].stack;
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
				if (Main.myPlayer == player.whoAmI && player.FindBuffIndex(mod.BuffType("DiscordBuff")) > -1)
				{
				Vector2 vector2 = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
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
				if (Main.myPlayer == player.whoAmI && player.FindBuffIndex(mod.BuffType("TrueDiscordBuff")) > -1)
				{
				Vector2 vector2 = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
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
}