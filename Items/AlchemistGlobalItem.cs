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

        public override void UpdateInventory(Item item, Player player)
        {
            if ((player.GetModPlayer<AlchemistNPCLitePlayer>()).BoomBox)
            {
                if (player.inventory[49].createTile != -1 && player.inventory[49].accessory)
                {
                    bool r = false;
                    // MUST BE UPDATED FOR 1.4
                    // player.VanillaUpdateAccessory(player.whoAmI, player.inventory[49], false, ref r, ref r, ref r);
                }
            }
            if (player.accCritterGuide && AlchemistNPCLite.modConfiguration.LifeformAnalyzer)
            {
                if (Main.GameUpdateCount % 60 == 0)
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
                            // MUST BE UPDATED FOR 1.4
                            // Projectile.NewProjectile(source, player.Center.X, player.Center.Y, num103, num104, ModContent.ProjectileType<Projectiles.LocatorProjectile>(), 0, 0f, player.whoAmI, v, 0f);
                        }
                    }
                }
            }
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
                // IMPLEMENT WHEN WEAKREFERENCES FIXED
                /*
                Mod Calamity = ModLoader.GetMod("CalamityMod");
                if (Calamity != null)
                {
                	if ((bool)Calamity.Call("Downed", "supreme calamitas"))
                	{
                		return false;
                	}
                }
                */
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
            string OldDuke = Language.GetTextValue("Mods.AlchemistNPCLite.OldDuke");
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

            //ElementsAwoken
            string Wasteland = Language.GetTextValue("Mods.AlchemistNPCLite.Wasteland");
            string Infernace = Language.GetTextValue("Mods.AlchemistNPCLite.Infernace");
            string ScourgeFighter = Language.GetTextValue("Mods.AlchemistNPCLite.ScourgeFighter");
            string Regaroth = Language.GetTextValue("Mods.AlchemistNPCLite.Regaroth");
            string TheCelestials = Language.GetTextValue("Mods.AlchemistNPCLite.TheCelestials");
            string Permafrost = Language.GetTextValue("Mods.AlchemistNPCLite.Permafrost");
            string Obsidious = Language.GetTextValue("Mods.AlchemistNPCLite.Obsidious");
            string Aqueous = Language.GetTextValue("Mods.AlchemistNPCLite.Aqueous");
            string TempleKeepers = Language.GetTextValue("Mods.AlchemistNPCLite.TempleKeepers");
            string Guardian = Language.GetTextValue("Mods.AlchemistNPCLite.Guardian");
            string Volcanox = Language.GetTextValue("Mods.AlchemistNPCLite.Volcanox");
            string VoidLevi = Language.GetTextValue("Mods.AlchemistNPCLite.VoidLevi");
            string Azana = Language.GetTextValue("Mods.AlchemistNPCLite.Azana");
            string Ancients = Language.GetTextValue("Mods.AlchemistNPCLite.Ancients");

            //Redemption
            string KingChicken = Language.GetTextValue("Mods.AlchemistNPCLite.KingChicken");
            string ThornBane = Language.GetTextValue("Mods.AlchemistNPCLite.ThornBane");
            string TheKeeper = Language.GetTextValue("Mods.AlchemistNPCLite.TheKeeper");
            string XenoCrystal = Language.GetTextValue("Mods.AlchemistNPCLite.XenoCrystal");
            string IEye = Language.GetTextValue("Mods.AlchemistNPCLite.IEye");
            string KingSlayer = Language.GetTextValue("Mods.AlchemistNPCLite.KingSlayer");
            string V1 = Language.GetTextValue("Mods.AlchemistNPCLite.V1");
            string V2 = Language.GetTextValue("Mods.AlchemistNPCLite.V2");
            string V3 = Language.GetTextValue("Mods.AlchemistNPCLite.V3");
            string PZ = Language.GetTextValue("Mods.AlchemistNPCLite.PZ");
            string ThornRematch = Language.GetTextValue("Mods.AlchemistNPCLite.ThornRematch");
            string Nebuleus = Language.GetTextValue("Mods.AlchemistNPCLite.Nebuleus");

            //SacredTools
            string Decree = Language.GetTextValue("Mods.AlchemistNPCLite.Decree");
            string FlamingPumpkin = Language.GetTextValue("Mods.AlchemistNPCLite.FlamingPumpkin");
            string Jensen = Language.GetTextValue("Mods.AlchemistNPCLite.Jensen");
            string Araneas = Language.GetTextValue("Mods.AlchemistNPCLite.Araneas");
            string Raynare = Language.GetTextValue("Mods.AlchemistNPCLite.Raynare");
            string Primordia = Language.GetTextValue("Mods.AlchemistNPCLite.Primordia");
            string Abaddon = Language.GetTextValue("Mods.AlchemistNPCLite.Abaddon");
            string Araghur = Language.GetTextValue("Mods.AlchemistNPCLite.Araghur");
            string Lunarians = Language.GetTextValue("Mods.AlchemistNPCLite.Lunarians");
            string Challenger = Language.GetTextValue("Mods.AlchemistNPCLite.Challenger");
            string Spookboi = Language.GetTextValue("Mods.AlchemistNPCLite.Spookboi");

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
                TooltipLine line = new TooltipLine(Mod, "KingSlime", KingSlime);
                line.overrideColor = Color.LimeGreen;
                tooltips.Insert(1, line);
            }
            if (item.type == ItemID.EyeOfCthulhuBossBag)
            {
                TooltipLine line = new TooltipLine(Mod, "EyeofCthulhu", EyeofCthulhu);
                line.overrideColor = Color.LimeGreen;
                tooltips.Insert(1, line);
            }
            if (item.type == ItemID.EaterOfWorldsBossBag)
            {
                TooltipLine line = new TooltipLine(Mod, "EaterOfWorlds", EaterOfWorlds);
                line.overrideColor = Color.LimeGreen;
                tooltips.Insert(1, line);
            }
            if (item.type == ItemID.BrainOfCthulhuBossBag)
            {
                TooltipLine line = new TooltipLine(Mod, "BrainOfCthulhu", BrainOfCthulhu);
                line.overrideColor = Color.LimeGreen;
                tooltips.Insert(1, line);
            }
            if (item.type == ItemID.QueenBeeBossBag)
            {
                TooltipLine line = new TooltipLine(Mod, "QueenBeeBossBag", QueenBee);
                line.overrideColor = Color.LimeGreen;
                tooltips.Insert(1, line);
            }
            if (item.type == ItemID.SkeletronBossBag)
            {
                TooltipLine line = new TooltipLine(Mod, "Skeletron", Skeletron);
                line.overrideColor = Color.LimeGreen;
                tooltips.Insert(1, line);
            }
            if (item.type == ItemID.WallOfFleshBossBag)
            {
                TooltipLine line = new TooltipLine(Mod, "WallOfFleshBoss", WallOfFlesh);
                line.overrideColor = Color.LimeGreen;
                tooltips.Insert(1, line);
            }
            if (item.type == ItemID.DestroyerBossBag)
            {
                TooltipLine line = new TooltipLine(Mod, "Destroyer", Destroyer);
                line.overrideColor = Color.LimeGreen;
                tooltips.Insert(1, line);
            }
            if (item.type == ItemID.TwinsBossBag)
            {
                TooltipLine line = new TooltipLine(Mod, "Twins", Twins);
                line.overrideColor = Color.LimeGreen;
                tooltips.Insert(1, line);
            }
            if (item.type == ItemID.SkeletronPrimeBossBag)
            {
                TooltipLine line = new TooltipLine(Mod, "SkeletronPrime", SkeletronPrime);
                line.overrideColor = Color.LimeGreen;
                tooltips.Insert(1, line);
            }
            if (item.type == ItemID.PlanteraBossBag)
            {
                TooltipLine line = new TooltipLine(Mod, "Plantera", Plantera);
                line.overrideColor = Color.LimeGreen;
                tooltips.Insert(1, line);
            }
            if (item.type == ItemID.GolemBossBag)
            {
                TooltipLine line = new TooltipLine(Mod, "Golem", Golem);
                line.overrideColor = Color.LimeGreen;
                tooltips.Insert(1, line);
            }
            if (item.type == ItemID.BossBagBetsy)
            {
                TooltipLine line = new TooltipLine(Mod, "Betsy", Betsy);
                line.overrideColor = Color.LimeGreen;
                tooltips.Insert(1, line);
            }
            if (item.type == ItemID.FishronBossBag)
            {
                TooltipLine line = new TooltipLine(Mod, "DukeFishron", DukeFishron);
                line.overrideColor = Color.LimeGreen;
                tooltips.Insert(1, line);
            }
            if (item.type == ItemID.MoonLordBossBag)
            {
                TooltipLine line = new TooltipLine(Mod, "MoonLord", MoonLord);
                line.overrideColor = Color.LimeGreen;
                tooltips.Insert(1, line);
            }

            // IMPLEMENT WHEN WEAKREFERENCES FIXED
			/*
            if (ModLoader.GetMod("CalamityMod") != null)
            {

                if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("DesertScourgeBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "DesertScourge", DesertScourge);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("CrabulonBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Crabulon", Crabulon);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("HiveMindBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "HiveMind", HiveMind);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("PerforatorBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Perforator", Perforator);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("SlimeGodBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "SlimeGod", SlimeGod);

                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("CryogenBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Cryogen", Cryogen);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("BrimstoneWaifuBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "BrimstoneElemental", BrimstoneElemental);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("AquaticScourgeBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "AquaticScourge", AquaticScourge);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("CalamitasBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Calamitas", Calamitas);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("AstrageldonBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "AstrageldonSlime", AstrageldonSlime);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("AstrumDeusBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "AstrumDeus", AstrumDeus);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("LeviathanBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Leviathan", Leviathan);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("PlaguebringerGoliathBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "PlaguebringerGoliath", PlaguebringerGoliath);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("RavagerBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Ravager", Ravager);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("ProvidenceBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Providence", Providence);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("PolterghastBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Polterghast", Polterghast);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("OldDukeBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "OldDuke", OldDuke);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("DevourerofGodsBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "DevourerofGods", DevourerofGods);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("BumblebirbBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Bumblebirb", Bumblebirb);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("CalamityMod").ItemType("YharonBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Yharon", Yharon);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
            }
            if (ModLoader.GetMod("ThoriumMod") != null)
            {
                if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("DarkMageBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "DarkMage", DarkMage);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("OgreBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Ogre", Ogre);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("ThunderBirdBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "ThunderBird", ThunderBird);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("JellyFishBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "QueenJellyfish", QueenJellyfish);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("CountBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "CountEcho", CountEcho);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("GraniteBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "GraniteEnergyStorm", GraniteEnergyStorm);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("HeroBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "TheBuriedChampion", TheBuriedChampion);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("ScouterBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "TheStarScouter", TheStarScouter);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("BoreanBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "BoreanStrider", BoreanStrider);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("BeholderBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "CoznixTheFallenBeholder", CoznixTheFallenBeholder);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("LichBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "TheLich", TheLich);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("AbyssionBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "AbyssionTheForgottenOne", AbyssionTheForgottenOne);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("ThoriumMod").ItemType("RagBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "TheRagnarok", TheRagnarok);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
            }
            if (ModLoader.GetMod("AAMod") != null)
            {
                if (item.type == (ModLoader.GetMod("AAMod").ItemType("MonarchBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Monarch", Monarch);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("AAMod").ItemType("GripBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Grips", Grips);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("AAMod").ItemType("BroodBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Broodmother", Broodmother);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("AAMod").ItemType("HydraBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Hydra", Hydra);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("AAMod").ItemType("SerpentBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Serpent", Serpent);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("AAMod").ItemType("DjinnBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Djinn", Djinn);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("AAMod").ItemType("RetrieverBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Retriever", Retriever);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("AAMod").ItemType("RaiderBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "RaiderU", RaiderU);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("AAMod").ItemType("OrthrusBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Orthrus", Orthrus);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("AAMod").ItemType("EFishBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "EFish", EFish);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("AAMod").ItemType("DBBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Daybringer", Daybringer);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("AAMod").ItemType("NCBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Nightcrawler", Nightcrawler);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("AAMod").ItemType("YamataBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Yamata", Yamata);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("AAMod").ItemType("AkumaBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Akuma", Akuma);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("AAMod").ItemType("ZeroBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Zero", Zero);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("AAMod").ItemType("ShenCache")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Shen", Shen);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("AAMod").ItemType("GripSBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "ShenGrips", ShenGrips);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
            }
            if (ModLoader.GetMod("ElementsAwoken") != null)
            {
                if (item.type == (ModLoader.GetMod("ElementsAwoken").ItemType("WastelandBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Wasteland", Wasteland);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("ElementsAwoken").ItemType("InfernaceBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Infernace", Infernace);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("ElementsAwoken").ItemType("ScourgeFighterBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "ScourgeFighter", ScourgeFighter);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("ElementsAwoken").ItemType("RegarothBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Regaroth", Regaroth);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("ElementsAwoken").ItemType("TheCelestialBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "TheCelestials", TheCelestials);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("ElementsAwoken").ItemType("PermafrostBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Permafrost", Permafrost);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("ElementsAwoken").ItemType("ObsidiousBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Obsidious", Obsidious);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("ElementsAwoken").ItemType("AqueousBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Aqueous", Aqueous);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("ElementsAwoken").ItemType("TempleKeepersBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "TempleKeepers", TempleKeepers);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("ElementsAwoken").ItemType("GuardianBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Guardian", Guardian);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("ElementsAwoken").ItemType("VolcanoxBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Volcanox", Volcanox);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("ElementsAwoken").ItemType("VoidLeviathanBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "VoidLevi", VoidLevi);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("ElementsAwoken").ItemType("AzanaBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Azana", Azana);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("ElementsAwoken").ItemType("AncientsBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Ancients", Ancients);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
            }
            if (ModLoader.GetMod("Redemption") != null)
            {
                if (item.type == (ModLoader.GetMod("Redemption").ItemType("KingChickenBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "KingChicken", KingChicken);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("Redemption").ItemType("ThornBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "ThornBane", ThornBane);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("Redemption").ItemType("TheKeeperBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "TheKeeper", TheKeeper);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("Redemption").ItemType("XenomiteCrystalBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "XenoCrystal", XenoCrystal);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("Redemption").ItemType("InfectedEyeBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "IEye", IEye);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("Redemption").ItemType("SlayerBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "KingSlayer", KingSlayer);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("Redemption").ItemType("VlitchCleaverBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "V1", V1);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("Redemption").ItemType("VlitchGigipedeBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "V2", V2);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("Redemption").ItemType("OmegaOblitBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "V3", V3);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("Redemption").ItemType("PZBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "PZ", PZ);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("Redemption").ItemType("ThornPZBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "ThornRematch", ThornRematch);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("Redemption").ItemType("NebBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Nebuleus", Nebuleus);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
            }
            if (ModLoader.GetMod("SacredTools") != null)
            {
                if (item.type == (ModLoader.GetMod("SacredTools").ItemType("DecreeBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Decree", Decree);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("SacredTools").ItemType("PumpkinBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "FlamingPumpkin", FlamingPumpkin);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("SacredTools").ItemType("HarpyBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Jensen", Jensen);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("SacredTools").ItemType("AraneasBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Araneas", Araneas);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("SacredTools").ItemType("HarpyBag2")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Raynare", Raynare);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("SacredTools").ItemType("PrimordiaBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Primordia", Primordia);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("SacredTools").ItemType("OblivionBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Abaddon", Abaddon);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("SacredTools").ItemType("SerpentBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Araghur", Araghur);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("SacredTools").ItemType("LunarBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Lunarians", Lunarians);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("SacredTools").ItemType("ChallengerBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Challenger", Challenger);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("SacredTools").ItemType("SpookboiBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Spookboi", Spookboi);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
            }
            if (ModLoader.GetMod("SpiritMod") != null)
            {
                if (item.type == (ModLoader.GetMod("SpiritMod").ItemType("BagOScarabs")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Scarabeus", Scarabeus);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("SpiritMod").ItemType("ReachBossBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Bane", Bane);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("SpiritMod").ItemType("FlyerBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Flier", Flier);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("SpiritMod").ItemType("SteamRaiderBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Raider", Raider);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("SpiritMod").ItemType("InfernonBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Infernon", Infernon);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("SpiritMod").ItemType("DuskingBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Dusking", Dusking);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("SpiritMod").ItemType("SpiritCoreBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "EqualityComparer", EtherialUmbra);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("SpiritMod").ItemType("IlluminantBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "IlluminantMaster", IlluminantMaster);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("SpiritMod").ItemType("AtlasBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Atlas", Atlas);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("SpiritMod").ItemType("OverseerBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Overseer", Overseer);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
            }
            if (ModLoader.GetMod("Laugicality") != null)
            {
                if (item.type == (ModLoader.GetMod("Laugicality").ItemType("DuneSharkronTreasureBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Sharkron", Sharkron);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("Laugicality").ItemType("HypothemaTreasureBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Hypothema", Hypothema);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("Laugicality").ItemType("RagnarTreasureBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Ragnar", Ragnar);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("Laugicality").ItemType("AnDioTreasureBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "AnDio", AnDio);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("Laugicality").ItemType("AnnihilatorTreasureBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Annihilator", Annihilator);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("Laugicality").ItemType("SlybertronTreasureBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Slybertron", Slybertron);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("Laugicality").ItemType("SteamTrainTreasureBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "SteamTrain", SteamTrain);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
            }
            if (ModLoader.GetMod("pinkymod") != null)
            {
                if (item.type == (ModLoader.GetMod("pinkymod").ItemType("STBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "SunlightTrader", SunlightTrader);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("pinkymod").ItemType("HOTCTreasureBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "THOFC", THOFC);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("pinkymod").ItemType("MythrilBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "MythrilSlime", MythrilSlime);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("pinkymod").ItemType("Valdabag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Valdaris", Valdaris);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
                if (item.type == (ModLoader.GetMod("pinkymod").ItemType("GatekeeperTreasureBag")))
                {
                    TooltipLine line = new TooltipLine(Mod, "Gatekeeper", Gatekeeper);
                    line.overrideColor = Color.LimeGreen;
                    tooltips.Insert(1, line);
                }
            }
			*/
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
