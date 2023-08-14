using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace AlchemistNPCLite.Items
{
    public class AlchemistGlobalItem : GlobalItem
    {
        public static bool on = false;
        public static bool Luck = false;
        public static bool Luck2 = false;

        public override void UpdateInventory(Item item, Player player)
        {
            if (item.type == ItemType<Items.Misc.LuckCharm>())
            {
                Luck = true;
            }
            if (item.type == ItemType<Items.Misc.LuckCharmT2>())
            {
                Luck = true;
                Luck2 = true;
            }
        }

        public override int ChoosePrefix(Item item, UnifiedRandom rand)
        {
            if (Luck == true)
            {
                if (item.CountsAsClass(DamageClass.Melee))
                {
                    if (Main.rand.Next(10) == 0)
                        return 59;

                    if (Main.rand.Next(20) == 0)
                        return 81;
                }
                if (item.CountsAsClass(DamageClass.Ranged) && !item.consumable)
                {
                    if (Main.rand.Next(10) == 0)
                        return 20;

                    if (Main.rand.Next(20) == 0)
                        return 82;
                }
                if (item.CountsAsClass(DamageClass.Magic))
                {
                    if (Main.rand.Next(10) == 0)
                        return 28;

                    if (Main.rand.Next(20) == 0)
                        return 83;
                }
                if (item.CountsAsClass(DamageClass.Summon))
                {
                    if (Main.rand.Next(10) == 0)
                        return 57;

                    if (Main.rand.Next(20) == 0)
                        return 83;
                }
                if (item.CountsAsClass(DamageClass.Throwing) && !item.consumable)
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
            if ((player.GetModPlayer<AlchemistNPCLitePlayer>()).AlchemistCharmTier4 == true && (item.buffTime > 0 || item.healLife > 0 || item.healMana > 0 || item.UseSound == SoundID.Item3))
            {
                ModLoader.TryGetMod("CalamityMod", out Mod Calamity);
                if (Calamity != null)
                {
                    if ((bool)Calamity.Call("Downed", "supreme calamitas"))
                    {
                        return false;
                    }
                }
                if (Main.rand.NextFloat() >= .25f)
                {
                    return false;
                }
            }

            else if ((player.GetModPlayer<AlchemistNPCLitePlayer>()).AlchemistCharmTier3 == true && (item.buffTime > 0 || item.healLife > 0 || item.healMana > 0 || item.UseSound == SoundID.Item3))
            {
                if (Main.rand.Next(2) == 0)
                    return false;
            }

            else if ((player.GetModPlayer<AlchemistNPCLitePlayer>()).AlchemistCharmTier2 == true && (item.buffTime > 0 || item.healLife > 0 || item.healMana > 0 || item.UseSound == SoundID.Item3))
            {
                if (Main.rand.Next(4) == 0)
                    return false;
            }

            else if ((player.GetModPlayer<AlchemistNPCLitePlayer>()).AlchemistCharmTier1 == true && (item.buffTime > 0 || item.healLife > 0 || item.healMana > 0 || item.UseSound == SoundID.Item3))
            {
                if (Main.rand.Next(10) == 0)
                    return false;
            }
            return true;
        }
		
		public override void UseAnimation(Item item, Player player)
		{
			if (item.pick > 0 && player.HasBuff(ModContent.BuffType<Buffs.Excavation>()))
			{
				AlchemistNPCLitePlayer modPlayer = player.GetModPlayer<AlchemistNPCLitePlayer>();
				if (modPlayer.ExcavationPower == 3)
				{
					int i = Terraria.Player.tileTargetX;
					int j = Terraria.Player.tileTargetY;
					player.PickTile(i-1, j-1, item.pick);
					player.PickTile(i-1, j, item.pick);
					player.PickTile(i, j-1, item.pick);
					player.PickTile(i+1, j+1, item.pick);
					player.PickTile(i+1, j, item.pick);
					player.PickTile(i, j+1, item.pick);
					player.PickTile(i+1, j-1, item.pick);
					player.PickTile(i-1, j+1, item.pick);
				}
			}
		}

        public override bool? UseItem(Item item, Player player)
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
                            if (npc.type == ModContent.NPCType<NPCs.Alchemist>())
                            {
                                Main.npcCatchable[npc.type] = true;
                                npc.catchItem = (short)ModContent.ItemType<Items.Summoning.AlchemistHorcrux>();
                            }
                            if (npc.type == ModContent.NPCType<NPCs.Brewer>())
                            {
                                Main.npcCatchable[npc.type] = true;
                                npc.catchItem = (short)ModContent.ItemType<Items.Summoning.BrewerHorcrux>();
                            }
                            if (npc.type == ModContent.NPCType<NPCs.Architect>())
                            {
                                Main.npcCatchable[npc.type] = true;
                                npc.catchItem = (short)ModContent.ItemType<Items.Summoning.ArchitectHorcrux>();
                            }
                            if (npc.type == ModContent.NPCType<NPCs.Jeweler>())
                            {
                                Main.npcCatchable[npc.type] = true;
                                npc.catchItem = (short)ModContent.ItemType<Items.Summoning.JewelerHorcrux>();
                            }
                            if (npc.type == ModContent.NPCType<NPCs.Operator>())
                            {
                                Main.npcCatchable[npc.type] = true;
                                npc.catchItem = (short)ModContent.ItemType<Items.Summoning.APMC>();
                            }
                            if (npc.type == ModContent.NPCType<NPCs.Musician>())
                            {
                                Main.npcCatchable[npc.type] = true;
                                npc.catchItem = (short)ModContent.ItemType<Items.Summoning.MusicianHorcrux>();
                            }
                            if (npc.type == ModContent.NPCType<NPCs.Tinkerer>())
                            {
                                Main.npcCatchable[npc.type] = true;
                                npc.catchItem = (short)ModContent.ItemType<Items.Summoning.TinkererHorcrux>();
                            }
                        }
                        if (!AlchemistNPCLite.modConfiguration.CatchNPC)
                        {
                            if (npc.type == ModContent.NPCType<NPCs.Alchemist>())
                            {
                                Main.npcCatchable[npc.type] = false;
                                npc.catchItem = -1;
                            }
                            if (npc.type == ModContent.NPCType<NPCs.Brewer>())
                            {
                                Main.npcCatchable[npc.type] = false;
                                npc.catchItem = -1;
                            }
                            if (npc.type == ModContent.NPCType<NPCs.Architect>())
                            {
                                Main.npcCatchable[npc.type] = false;
                                npc.catchItem = -1;
                            }
                            if (npc.type == ModContent.NPCType<NPCs.Jeweler>())
                            {
                                Main.npcCatchable[npc.type] = false;
                                npc.catchItem = -1;
                            }
                            if (npc.type == ModContent.NPCType<NPCs.Operator>())
                            {
                                Main.npcCatchable[npc.type] = false;
                                npc.catchItem = -1;
                            }
                            if (npc.type == ModContent.NPCType<NPCs.Musician>())
                            {
                                Main.npcCatchable[npc.type] = false;
                                npc.catchItem = -1;
                            }
                            if (npc.type == ModContent.NPCType<NPCs.Tinkerer>())
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
                player.AddBuff(item.buffType, item.buffTime + (item.buffTime / 2), true);
            }
            else if (modPlayer.AlchemistCharmTier3)
            {
                player.AddBuff(item.buffType, item.buffTime + ((item.buffTime / 20) * 7), true);
            }
            else if (modPlayer.AlchemistCharmTier2)
            {
                player.AddBuff(item.buffType, item.buffTime + (item.buffTime / 4), true);
            }
            else if (modPlayer.AlchemistCharmTier1)
            {
                player.AddBuff(item.buffType, item.buffTime + (item.buffTime / 10), true);
            }
            return base.UseItem(item, player);
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
