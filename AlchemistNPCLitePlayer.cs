using AlchemistNPCLite.Interface;
using AlchemistNPCLite.Items;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

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
		public bool Bewitched = false;
		public bool Sharpen = false;
		public bool Clairvoyance = false;
		public bool AmmoBox = false;
		public bool SugarRush = false;
		public bool Lamps = false;
		public bool GlobalTeleporter = false;
		public bool GlobalTeleporterUp = false;
		public int ExcavationPower = 3;
		
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
			GlobalTeleporter = false;
			GlobalTeleporterUp = false;
			
			AllDamage10 = false;
			AllCrit10 = false;
			Defense8 = false;
			DR10 = false;
			Regeneration = false;
			Lifeforce = false;
			MS = false;
			Bewitched = false;
			Sharpen = false;
			Clairvoyance = false;
			AmmoBox = false;
			SugarRush = false;
			Lamps = false;

			if (Main.netMode != NetmodeID.Server)
			{
				if (Main.player[Main.myPlayer].talkNPC == -1)
				{
					ShopChangeUI.visible = false;
					ShopChangeUIA.visible = false;
					ShopChangeUIO.visible = false;
					ShopChangeUIM.visible = false;
				}
			}
		}


		public override void CopyClientState(ModPlayer clientClone)/* tModPorter Suggestion: Replace Item.Clone usages with Item.CopyNetStateTo */
		{
			AlchemistNPCLitePlayer clone = clientClone as AlchemistNPCLitePlayer;
		}

		public override void SendClientChanges(ModPlayer clientPlayer)
		{
		}

		// replaced when ported
		// public override void UpdateEquips(ref bool wallSpeedBuff, ref bool tileSpeedBuff, ref bool tileRangeBuff)
		public override void UpdateEquips()
		{
			if (AllDamage10) Player.GetDamage(DamageClass.Generic) += 0.1f;
			if (AllCrit10)
			{
				Player.GetCritChance(DamageClass.Melee) += 10;
				Player.GetCritChance(DamageClass.Ranged) += 10;
				Player.GetCritChance(DamageClass.Magic) += 10;
				Player.GetCritChance(DamageClass.Throwing) += 10;
				if (ModLoader.TryGetMod("ThoriumMod", out Mod thoriumMod))
				{
					if (thoriumMod.TryFind("BardDamage", out DamageClass damageClass))
					{
						Player.GetCritChance(damageClass) += 10;
					}
					if (thoriumMod.TryFind("HealerDamage", out DamageClass damageClass1))
					{
						Player.GetCritChance(damageClass1) += 10;
					}
				}
					
			}
			if (Regeneration) Player.lifeRegen += 4;
			if (Lifeforce)
			{
				Player.lifeForce = true;
				Player.statLifeMax2 += Player.statLifeMax / 5 / 20 * 20;
			}
			if (MS) Player.moveSpeed += 0.25f;
			if (Defense8) 
			{
				Player.statDefense += 8;
				if (ModLoader.TryGetMod("CalamityMod", out Mod Calamity))
				{
					if (Main.hardMode) Player.statDefense += 4;
					else if (NPC.downedMoonlord) Player.statDefense += 8;
					else if ((bool)Calamity.Call("Downed", "dog")) Player.statDefense += 12;
				}
			}
			if (DR10) Player.endurance += 0.1f;
			if (Bewitched) ++Player.maxMinions;
			if (Sharpen)
			{
				Player.GetArmorPenetration(DamageClass.Melee) += 12;
				Player.GetArmorPenetration(DamageClass.Summon) += 12;
			}
			if (Clairvoyance)
			{
				Player.GetDamage(DamageClass.Magic) += 0.05f;
				Player.GetCritChance(DamageClass.Magic) += 2;
				Player.statManaMax2 += 20;
				Player.manaCost -= 0.02f;
			}
			if (AmmoBox) Player.ammoBox = true;
			if (SugarRush)
			{
				Player.pickSpeed -= 0.2f;
				Player.moveSpeed += 0.2f;
			}
			if (Lamps)
			{
				Player.manaRegenBonus += 2;
				Main.SceneMetrics.HasHeartLantern = true;
				Main.SceneMetrics.HasCampfire = true;
			}
		}

		private bool QuickBuff_ShouldBotherUsingThisBuff(int attemptedType)
		{
			bool result = true;
			for (int i = 0; i < 44; i++)
			{
				if (attemptedType == 27 && (Player.buffType[i] == 27 || Player.buffType[i] == 101 || Player.buffType[i] == 102))
				{
					result = false;
					break;
				}
				if (BuffID.Sets.IsWellFed[attemptedType] && BuffID.Sets.IsWellFed[Player.buffType[i]])
				{
					result = false;
					break;
				}
				if (Player.buffType[i] == attemptedType)
				{
					result = false;
					break;
				}
				if (Main.meleeBuff[attemptedType] && Main.meleeBuff[Player.buffType[i]])
				{
					result = false;
					break;
				}
			}
			if (Main.lightPet[attemptedType] || Main.vanityPet[attemptedType])
			{
				for (int j = 0; j < 44; j++)
				{
					if (Main.lightPet[Player.buffType[j]] && Main.lightPet[attemptedType])
					{
						result = false;
					}
					if (Main.vanityPet[Player.buffType[j]] && Main.vanityPet[attemptedType])
					{
						result = false;
					}
				}
			}
			return result;
		}

		public override void ProcessTriggers(TriggersSet triggersSet)
		{
			if (GlobalTeleporter || GlobalTeleporterUp)
			{
				bool allow = true;
				for (int v = 0; v < 200; ++v)
				{
					NPC npc = Main.npc[v];
					if (npc.active && npc.boss)
					{
						allow = false;
						break;
					}
				}
				if (GlobalTeleporterUp && allow && Main.mapFullscreen == true && Main.mouseRight && Main.keyState.IsKeyUp(Microsoft.Xna.Framework.Input.Keys.LeftControl))
				{
					int mapWidth = Main.maxTilesX * 16;
					int mapHeight = Main.maxTilesY * 16;
					Vector2 cursorPosition = new Vector2(Main.mouseX, Main.mouseY);

					cursorPosition.X -= Main.screenWidth / 2;
					cursorPosition.Y -= Main.screenHeight / 2;

					Vector2 mapPosition = Main.mapFullscreenPos;
					Vector2 cursorWorldPosition = mapPosition;

					cursorPosition /= 16;
					cursorPosition *= 16 / Main.mapFullscreenScale;
					cursorWorldPosition += cursorPosition;
					cursorWorldPosition *= 16;

					cursorWorldPosition.Y -= Player.height;
					if (cursorWorldPosition.X < 0) cursorWorldPosition.X = 0;
					else if (cursorWorldPosition.X + Player.width > mapWidth) cursorWorldPosition.X = mapWidth - Player.width;
					if (cursorWorldPosition.Y < 0) cursorWorldPosition.Y = 0;
					else if (cursorWorldPosition.Y + Player.height > mapHeight) cursorWorldPosition.Y = mapHeight - Player.height;

					Player.Teleport(cursorWorldPosition, 0, 0);
					NetMessage.SendData(65, -1, -1, (NetworkText)null, 0, (float)Player.whoAmI, (float)cursorWorldPosition.X, (float)cursorWorldPosition.Y, 1, 0, 0);
					Main.mapFullscreen = false;

					for (int index = 0; index < 120; ++index)
						Main.dust[Dust.NewDust(Player.position, Player.width, Player.height, 15, Main.rand.NextFloat(-10f, 10f), Main.rand.NextFloat(-10f, 10f), 150, Color.Cyan, 1.2f)].velocity *= 0.75f;
				}
				if (GlobalTeleporter && allow && Main.mapFullscreen == true && Main.mouseRight && Main.keyState.IsKeyUp(Microsoft.Xna.Framework.Input.Keys.LeftControl))
				{
					int mapWidth = Main.maxTilesX * 16;
					int mapHeight = Main.maxTilesY * 16;
					Vector2 cursorPosition = new Vector2(Main.mouseX, Main.mouseY);

					cursorPosition.X -= Main.screenWidth / 2;
					cursorPosition.Y -= Main.screenHeight / 2;

					Vector2 mapPosition = Main.mapFullscreenPos;
					Vector2 cursorWorldPosition = mapPosition;

					cursorPosition /= 16;
					cursorPosition *= 16 / Main.mapFullscreenScale;
					cursorWorldPosition += cursorPosition;
					cursorWorldPosition *= 16;

					cursorWorldPosition.Y -= Player.height;
					if (cursorWorldPosition.X < 0) cursorWorldPosition.X = 0;
					else if (cursorWorldPosition.X + Player.width > mapWidth) cursorWorldPosition.X = mapWidth - Player.width;
					if (cursorWorldPosition.Y < 0) cursorWorldPosition.Y = 0;
					else if (cursorWorldPosition.Y + Player.height > mapHeight) cursorWorldPosition.Y = mapHeight - Player.height;

					Player.Teleport(cursorWorldPosition, 0, 0);
					NetMessage.SendData(65, -1, -1, (NetworkText)null, 0, (float)Player.whoAmI, (float)cursorWorldPosition.X, (float)cursorWorldPosition.Y, 1, 0, 0);
					Main.mapFullscreen = false;
					Item[] inventory = Player.inventory;
					for (int k = 0; k < inventory.Length; k++)
					{
						if (inventory[k].type == ModContent.ItemType<Items.Misc.GlobalTeleporter>())
						{
							inventory[k].stack--;
							break;
						}
					}
					for (int index = 0; index < 120; ++index)
						Main.dust[Dust.NewDust(Player.position, Player.width, Player.height, 15, Main.rand.NextFloat(-10f, 10f), Main.rand.NextFloat(-10f, 10f), 150, Color.Cyan, 1.2f)].velocity *= 0.75f;
				}
			}
			if (DistantPotionsUse && PlayerInput.Triggers.Current.QuickBuff)
			{
				SoundStyle type1 = SoundID.Item3;
				bool flag = true;
				bool dosound = false;
				for (int index1 = 0; index1 < 40; ++index1)
				{
					flag = true;
					if (Player.CountBuffs() == 44) return;
					Item bankitem = Player.bank.item[index1];
					if (bankitem.stack <= 0 || bankitem.type <= 0 || bankitem.buffType <= 0 || bankitem.CountsAsClass(DamageClass.Summon))
					{
						continue;
					}
					//ModLoader.TryGetMod("CalamityMod", out Mod Calamity);
					/*if (Calamity != null)
					{
						Calamity.TryFind<ModBuff>("AbsoluteRage", out ModBuff buff);
						if (Player.bank.item[index1].buffType == buff.Type)
						{
							for (int v = 0; v < 200; ++v)
							{
								NPC npc = Main.npc[v];
								if (npc.active && npc.boss)
								{
									return;
								}
							}
							// IMPLEMENT
							// CalamityRage(Player);
						}
					}*/
					int num2 = bankitem.buffType;
					flag = QuickBuff_ShouldBotherUsingThisBuff(num2);
					if (bankitem.mana > 0 && flag)
					{
						if (Player.statMana >= (int)((float)bankitem.mana * Player.manaCost))
						{
							Player.manaRegenDelay = (int)Player.maxRegenDelay;
							Player.statMana -= (int)((float)bankitem.mana * Player.manaCost);
						}
						else
						{
							flag = false;
						}
					}
					if (Player.whoAmI == Main.myPlayer && bankitem.type == 603 && !Main.runningCollectorsEdition)
					{
						flag = false;
					}
					if (num2 == 27)
					{
						num2 = Main.rand.Next(3);
						if (num2 == 0)
						{
							num2 = 27;
						}
						if (num2 == 1)
						{
							num2 = 101;
						}
						if (num2 == 2)
						{
							num2 = 102;
						}
					}
					if (!flag)
					{
						continue;
					}
					int num3 = bankitem.buffTime;
					if (num3 == 0)
					{
						num3 = 3600;
					}
					if (Player.CountBuffs() == 44)
					{
						break;
					}
					dosound = true;

					if (bankitem.consumable)
					{
						if (AlchemistCharmTier4 == true)
						{
							num3 = (int)(num3 * 1.5);
							ModLoader.TryGetMod("CalamityMod", out Mod Calamity);
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
									--bankitem.stack;
								}
							}
							else if (Main.rand.NextFloat() >= .25f)
							{
							}
							else
							{
								--bankitem.stack;
							}
						}

						else if (AlchemistCharmTier3 == true)
						{
							num3 = (int)(num3 * 1.35);
							if (Main.rand.Next(2) == 0)
							{
							}
							else
							{
								--bankitem.stack;
							}
						}

						else if (AlchemistCharmTier2 == true)
						{
							num3 = (int)(num3 * 1.25);
							if (Main.rand.Next(4) == 0)
							{
							}
							else
							{
								--bankitem.stack;
							}
						}

						else if (AlchemistCharmTier1 == true)
						{
							num3 = (int)(num3 * 1.1);
							if (Main.rand.Next(10) == 0)
							{
							}
							else
							{
								--bankitem.stack;
							}
						}
						else
						{
							--bankitem.stack;
						}
						if (bankitem.stack <= 0)
							bankitem.TurnToAir();
					}
					Player.AddBuff(num2, num3);
				}
				//if (type1 == null)
				//return;
				if (dosound) SoundEngine.PlaySound(type1, Player.position);
				//Recipe.FindRecipes();
			}
			if (AlchemistNPCLite.DiscordBuff.JustPressed)
			{
				if (Main.myPlayer == Player.whoAmI && Player.HasBuff(ModContent.BuffType<Buffs.DiscordBuff>()))
				{
					Vector2 vector2 = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
					if (!Collision.SolidCollision(vector2, Player.width, Player.height))
					{
						Player.Teleport(vector2, 1, 0);
						NetMessage.SendData(65, -1, -1, (NetworkText)null, 0, (float)Player.whoAmI, (float)vector2.X, (float)vector2.Y, 1, 0, 0);
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
						NetMessage.SendData(65, -1, -1, (NetworkText)null, 0, (float)Player.whoAmI, (float)vector2.X, (float)vector2.Y, 1, 0, 0);
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
		// IMPLEMENT
		// private void CalamityRage(Player player)
		// {
		//     CalamityMod.CalPlayer.CalamityPlayer CalamityPlayer = Player.GetModPlayer<CalamityMod.CalPlayer.CalamityPlayer>();
		//     CalamityPlayer.rage = CalamityPlayer.rageMax;
		// }
	}
}