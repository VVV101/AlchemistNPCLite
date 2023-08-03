using AlchemistNPCLite.Items;
using AlchemistNPCLite.Utilities;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.Personalities;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace AlchemistNPCLite.NPCs
{
    [AutoloadHead]
    public class Alchemist : ModNPC
    {
        public static string BaseShop = "BaseShop";
        public static string PlantShop = "PlantShop";
        public override string Texture
        {
            get
            {
                return "AlchemistNPCLite/NPCs/Alchemist";
            }
        }
        // Probably Removed
        // public override bool Autoload(ref string name)
        // {
        // 	name = "Alchemist";
        // 	return true;
        // }

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 23;
            NPCID.Sets.AttackFrameCount[NPC.type] = 2;
            NPCID.Sets.DangerDetectRange[NPC.type] = 500;
            NPCID.Sets.AttackType[NPC.type] = 0;
            NPCID.Sets.AttackTime[NPC.type] = 22;
            NPCID.Sets.AttackAverageChance[NPC.type] = 30;
            NPCID.Sets.HatOffsetY[NPC.type] = -4;

            NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            {
                Velocity = -1f,
                Direction = -1
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);

            NPC.Happiness.SetBiomeAffection<ForestBiome>(AffectionLevel.Like);
            NPC.Happiness.SetBiomeAffection<UndergroundBiome>(AffectionLevel.Love);
            NPC.Happiness.SetBiomeAffection<SnowBiome>(AffectionLevel.Dislike);

            NPC.Happiness.SetNPCAffection<YoungBrewer>(AffectionLevel.Love);
            NPC.Happiness.SetNPCAffection(NPCID.Mechanic, AffectionLevel.Like);
            NPC.Happiness.SetNPCAffection<Brewer>(AffectionLevel.Dislike);
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Underground,
                new FlavorTextBestiaryInfoElement("Mods.AlchemistNPCLite.Bestiary.Alchemist")
            });
        }

        public override void SetDefaults()
        {
            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.width = 18;
            NPC.height = 40;
            NPC.aiStyle = 7;
            NPC.damage = 10;
            NPC.defense = 100;
            NPC.lifeMax = 250;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.5f;
            AnimationType = NPCID.Clothier;
        }

        public override bool CanTownNPCSpawn(int numTownNPCs)/* tModPorter Suggestion: Copy the implementation of NPC.SpawnAllowed_Merchant in vanilla if you to count money, and be sure to set a flag when unlocked, so you don't count every tick. */
        {
            if (NPC.downedBoss1 && AlchemistNPCLite.modConfiguration.AlchemistSpawn)
            {
                return true;
            }
            return false;
        }

        public override List<string> SetNPCNameList()
        {                                       //NPC names
            string Edward = Language.GetTextValue("Mods.AlchemistNPCLite.Edward");
            string Severus = Language.GetTextValue("Mods.AlchemistNPCLite.Severus");
            string Horace = Language.GetTextValue("Mods.AlchemistNPCLite.Horace");
            string Tilyorn = Language.GetTextValue("Mods.AlchemistNPCLite.Tilyorn");
            string Nicolas = Language.GetTextValue("Mods.AlchemistNPCLite.Nicolas");
            string Gregg = Language.GetTextValue("Mods.AlchemistNPCLite.Gregg");

            return new List<string>() {
                Edward,
                Severus,
                Horace,
                Tilyorn,
                Nicolas,
                Gregg
            };
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            if (!Main.hardMode)
            {
                damage = 10;
            }
            if (!NPC.downedMoonlord && Main.hardMode)
            {
                damage = 25;
            }
            if (NPC.downedMoonlord)
            {
                damage = 100;
            }
            knockback = 8f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 15;
            randExtraCooldown = 5;
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            if (NPC.downedMoonlord)
            {
                projType = ModContent.ProjectileType<Projectiles.CorrosiveFlask>();
            }
            else
            {
                projType = ProjectileID.ToxicFlask;
            }
            attackDelay = 1;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 12f;
            randomOffset = 2f;
        }

        public override string GetChat()
        {                                           //npc chat
            string EntryA1 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryA1");
            string EntryA2 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryA2");
            string EntryA3 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryA3");
            string EntryA4 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryA4");
            string EntryA5 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryA5");
            string EntryA6 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryA6");
            string EntryA7 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryA7");
            string EntryA8 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryA8");
            string EntryA9 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryA9");
            string EntryA10 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryA10");
            string EntryA11 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryA11");
            string EntryA12 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryA12");
            string EntryA13 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryA13");
            string EntryA14 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryA14");
            string EntryA15 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryA15");
            string EntryA16 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryA16");
            string EntryA17 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryA17");
            string EntryA18 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryA18");
            string EntryA19 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryA19");
            string EntryA20 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryA20");
            string EntryA21 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryA21");
            string EntryA22 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryA22");
            string EntryA23 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryA23");
            string EntryA24 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryA24");
            string EntryA25 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryA25");
            string EntryA26 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryA26");
            string EntryA27 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryA27");
            int Brewer = NPC.FindFirstNPC(ModContent.NPCType<Brewer>());
            int partyGirl = NPC.FindFirstNPC(NPCID.PartyGirl);
            int witchDoctor = NPC.FindFirstNPC(NPCID.WitchDoctor);
            if (Main.bloodMoon && partyGirl >= 0 && Main.rand.NextBool(4))
            {
                return EntryA23 + Main.npc[partyGirl].GivenName + EntryA24;
            }
            if (Main.bloodMoon)
            {
                switch (Main.rand.Next(3))
                {
                    case 0:
                        return EntryA20;
                    case 1:
                        return EntryA21;
                    case 2:
                        return EntryA22;
                }
            }
            if (Main.invasionType == 1)
            {
                return EntryA17;
            }
            if (Main.invasionType == 3)
            {
                return EntryA18;
            }
            if (Main.invasionType == 4)
            {
                return EntryA19;
            }
            if (witchDoctor >= 0 && Main.rand.NextBool(7))
            {
                return EntryA25 + Main.npc[Brewer].GivenName + EntryA26 + Main.npc[Brewer].GivenName + EntryA27;
            }
            if (Brewer >= 0 && Main.rand.NextBool(5))
            {
                return EntryA15 + Main.npc[Brewer].GivenName + EntryA16;
            }
            // IMPLEMENT WHEN WEAKREFERENCES FIXED
            /*
            if (ModLoader.GetMod("Tremor") != null)
            {
                int Alch = NPC.FindFirstNPC(ModLoader.GetMod("Tremor").NPCType("Alchemist"));
                if (Alch >= 0 && Main.rand.Next(4) == 0)
                {
                    return EntryA12 + Main.npc[Alch].GivenName + EntryA13;
                }
            }
            if (ModLoader.GetMod("Tremor") != null)
            {
                if (NPC.downedBoss3 && Main.rand.Next(6) == 0)
                {
                    return EntryA14;
                }
            }
            if (ModLoader.GetMod("ThoriumMod") != null)
            {
                int DA = NPC.FindFirstNPC(ModLoader.GetMod("ThoriumMod").NPCType("DesertTraveler"));
                if (DA >= 0 && Main.rand.Next(7) == 0)
                {
                    return EntryA9 + Main.npc[DA].GivenName + EntryA10;
                }
            }
            if (ModLoader.GetMod("ThoriumMod") != null)
            {
                int DA = NPC.FindFirstNPC(ModLoader.GetMod("ThoriumMod").NPCType("DesertTraveler"));
                if (DA >= 0 && Brewer >= 0 && Main.rand.Next(8) == 0)
                {
                    return EntryA11;
                }
            }
            if (ModLoader.GetMod("ThoriumMod") != null && Main.rand.Next(5) == 0)
            {
                return EntryA8;
            }
			*/
            switch (Main.rand.Next(7))
            {
                case 0:
                    return EntryA1;
                case 1:
                    return EntryA2;
                case 2:
                    return EntryA3;
                case 3:
                    return EntryA4;
                case 4:
                    return EntryA5;
                case 5:
                    return EntryA6;
                default:
                    return EntryA7;
            }
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            string PlantsShop = Language.GetTextValue("Mods.AlchemistNPCLite.PlantsShop");
            string GetCharm = Language.GetTextValue("Mods.AlchemistNPCLite.GetCharm");
            button = Language.GetTextValue("LegacyInterface.28");
            button2 = PlantsShop;

            Player player = Main.player[Main.myPlayer];
            if ((player.GetModPlayer<AlchemistNPCLitePlayer>()).AlchemistCharmTier1 == false && (player.GetModPlayer<AlchemistNPCLitePlayer>()).AlchemistCharmTier2 == false && (player.GetModPlayer<AlchemistNPCLitePlayer>()).AlchemistCharmTier3 == false && (player.GetModPlayer<AlchemistNPCLitePlayer>()).AlchemistCharmTier4 == false)
            {
                button2 = GetCharm;
            }
        }

        public override void OnChatButtonClicked(bool firstButton, ref string shopName)
        {
            if (firstButton)
            {
                shopName = BaseShop;
            }
            else
            {
                Player player = Main.player[Main.myPlayer];
                if ((player.GetModPlayer<AlchemistNPCLitePlayer>()).AlchemistCharmTier1 == false && (player.GetModPlayer<AlchemistNPCLitePlayer>()).AlchemistCharmTier2 == false && (player.GetModPlayer<AlchemistNPCLitePlayer>()).AlchemistCharmTier3 == false && (player.GetModPlayer<AlchemistNPCLitePlayer>()).AlchemistCharmTier4 == false)
                {
                    var source = NPC.GetSource_FromAI();
                    player.QuickSpawnItem(source, ModContent.ItemType<Items.Misc.AlchemistCharmTier1>());
                }
                shopName = PlantShop;
            }
        }

        public override void AddShops()
        {
            ModLoader.TryGetMod("CalamityMod", out Mod Calamity);
            ModLoader.TryGetMod("Redemption", out Mod Redemption);
            var shop = new NPCShop(Type, BaseShop)
                .Add(new Item(ItemID.LesserHealingPotion) { shopCustomPrice = 1000 })
                .Add(new Item(ItemID.HealingPotion) { shopCustomPrice = 5000 },
                    Condition.DownedEowOrBoc)
                .Add(new Item(ItemID.GreaterHealingPotion) { shopCustomPrice = 10000 },
                    Condition.Hardmode)
                .Add(new Item(ItemID.SuperHealingPotion) { shopCustomPrice = 25000 },
                    Condition.DownedMoonLord)
                .AddModItemToShop(Calamity, "SupremeHealingPotion", 500000, () => (bool)Calamity.Call("Downed", "profaned guardians") && !(bool)Calamity.Call("Downed", "polterghast"))
                .AddModItemToShop(Calamity, "OmegaHealingPotion", 1000000, () => (bool)Calamity.Call("Downed", "polterghast"))
                .Add(new Item(ItemID.LesserManaPotion) { shopCustomPrice = 500 })
                .Add(new Item(ItemID.ManaPotion) { shopCustomPrice = 1000 },
                    Condition.DownedEowOrBoc)
                .Add(new Item(ItemID.GreaterManaPotion) { shopCustomPrice = 5000 },
                    Condition.Hardmode)
                .Add(new Item(ItemID.SuperManaPotion) { shopCustomPrice = 10000 },
                    Condition.DownedMechBossAll)
                .Add(new Item(ItemID.StrangeBrew) { shopCustomPrice = 10000 },
                    Condition.DownedEowOrBoc)
                .Add(ItemID.RecallPotion)
                .Add(ItemID.WormholePotion)
                .Add(new Item(ItemID.LuckPotionLesser) { shopCustomPrice = 20000 })
                .Add(new Item(ItemID.LuckPotion) { shopCustomPrice = 100000 })
                .Add(new Item(ItemID.LuckPotionGreater) { shopCustomPrice = 500000 })
                .Add(new Item(ItemID.TeleportationPotion) { shopCustomPrice = 7500 },
                    Condition.Hardmode)
            // IMPLEMENT WHEN WEAKREFERENCES FIXED
            /*
            if (ModLoader.GetMod("imkSushisMod") != null)
            {
                addModItemToShop(imkSushisMod, "BaseSummoningPotion", 2500, ref shop, ref nextSlot);
                addModItemToShop(imkSushisMod, "AnglerAmnesiaPotion", 10000, ref shop, ref nextSlot);
                addModItemToShop(imkSushisMod, "MeteoritePotion", 50000, ref shop, ref nextSlot);
                addModItemToShop(imkSushisMod, "ResurrectionPotion", 25000, ref shop, ref nextSlot);
            }
            */
                .AddModItemToShop<BeachTeleporterPotion>(20000, () => NPC.downedBoss2)
                .AddModItemToShop<JungleTeleporterPotion>(50000, () => NPC.downedBoss2)
                .AddModItemToShop<OceanTeleporterPotion>(20000, () => NPC.downedBoss3)
                .AddModItemToShop<DungeonTeleportationPotion>(25000, () => NPC.downedBoss3)
                .AddModItemToShop<UnderworldTeleportationPotion>(50000, () => Main.hardMode)
                .AddModItemToShop<TempleTeleportationPotion>(100000, () => NPC.downedPlantBoss)
                .Add(new Item(ItemID.Bottle) { shopCustomPrice = 100 })
                .Add(new Item(ItemID.BottledWater) { shopCustomPrice = 500 })
                .Add(ItemID.FallenStar, Condition.DownedEowOrBoc)
                .Add(new Item(ItemID.Gel) { shopCustomPrice = 100 })
                .Add(new Item(ItemID.PinkGel) { shopCustomPrice = 1000 },
                    Condition.DownedEowOrBoc)
            // IMPLEMENT WHEN WEAKREFERENCES FIXED
            /*
            if (ModLoader.GetMod("ThoriumMod") != null)
            {
                if (NPC.downedBoss2)
                {
                    addModItemToShop(ThoriumMod, "WaterChestnut", 3500, ref shop, ref nextSlot);
                }
                if (NPC.downedBoss3)
                {
                    addModItemToShop(ThoriumMod, "Jelly", 7500, ref shop, ref nextSlot);
                }
            }
            */
                .Add(new Item(ItemID.PixieDust) { shopCustomPrice = 5000 },
                    Condition.Hardmode)
                .Add(new Item(ItemID.CrystalShard) { shopCustomPrice = 7500 },
                    Condition.Hardmode)
                .Add(new Item(ItemID.UnicornHorn) { shopCustomPrice = 15000 },
                    Condition.Hardmode)
                .Add(new Item(ItemID.CursedFlame) { shopCustomPrice = 7500 },
                    Condition.Hardmode)
                .Add(new Item(ItemID.Ichor) { shopCustomPrice = 7500 },
                    Condition.Hardmode)
                .Add(new Item(678) { shopCustomPrice = 150000 }, Condition.ForTheWorthyWorld);
            shop.Register();

            shop = new NPCShop(Type, PlantShop)
                .Add(new Item(ItemID.Daybloom) { shopCustomPrice = 1000 })
                .Add(new Item(ItemID.Waterleaf) { shopCustomPrice = 1000 })
                .Add(new Item(ItemID.Shiverthorn) { shopCustomPrice = 1000 })
                .Add(new Item(ItemID.Blinkroot) { shopCustomPrice = 2000 })
                .Add(new Item(ItemID.Moonglow) { shopCustomPrice = 2000 })
                .Add(new Item(ItemID.Fireblossom) { shopCustomPrice = 2500 })
                .Add(new Item(ItemID.Deathweed) { shopCustomPrice = 2500 })
                .Add(new Item(ItemID.Mushroom) { shopCustomPrice = 500 })
                .Add(new Item(ItemID.GlowingMushroom) { shopCustomPrice = 1000 })
                .Add(new Item(ItemID.VileMushroom) { shopCustomPrice = 1000 },
                    Condition.DownedEowOrBoc)
                .Add(new Item(ItemID.ViciousMushroom) { shopCustomPrice = 1000 },
                    Condition.DownedEowOrBoc)
                .AddModItemToShop(Redemption, "Nightshade", 1000, () => NPC.downedBoss3);
            /*
            if (ModLoader.GetMod("Tremor") != null)
            {
                if (NPC.downedBoss3)
                {
                    addModItemToShop(Tremor, "Gloomstone", 100, ref shop, ref nextSlot);
                    addModItemToShop(Tremor, "UntreatedFlesh", 100, ref shop, ref nextSlot);
                    addModItemToShop(Tremor, "LightBulb", 500, ref shop, ref nextSlot);
                    addModItemToShop(Tremor, "AtisBlood", 2500, ref shop, ref nextSlot);
                    addModItemToShop(Tremor, "TearsofDeath", 2500, ref shop, ref nextSlot);
                    addModItemToShop(Tremor, "TornPapyrus", 5000, ref shop, ref nextSlot);
                    addModItemToShop(Tremor, "PhantomSoul", 5000, ref shop, ref nextSlot);
                    addModItemToShop(Tremor, "TheRib", 7500, ref shop, ref nextSlot);
                }	
            }
            */
            shop.Register();
        }
    }
}
