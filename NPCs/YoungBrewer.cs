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
    public class YoungBrewer : ModNPC
    {
        public static string Shop1 = "Combinations";
        public static string Shop2 = "Flasks";
        public override string Texture
        {
            get
            {
                return "AlchemistNPCLite/NPCs/YoungBrewer";
            }
        }

        //Possibly removed
        // public override bool Autoload(ref string name)
        // {
        // 	name = "Young Brewer";
        // 	return true;
        // }

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 23;
            NPCID.Sets.AttackFrameCount[NPC.type] = 4;
            NPCID.Sets.DangerDetectRange[NPC.type] = 500;
            NPCID.Sets.AttackType[NPC.type] = 0;
            NPCID.Sets.AttackTime[NPC.type] = 20;
            NPCID.Sets.AttackAverageChance[NPC.type] = 30;
            NPCID.Sets.HatOffsetY[NPC.type] = 2;

            NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            {
                Velocity = -1f,
                Direction = -1
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);

            NPC.Happiness.SetBiomeAffection<DesertBiome>(AffectionLevel.Like);
            NPC.Happiness.SetBiomeAffection<ForestBiome>(AffectionLevel.Love);
            NPC.Happiness.SetBiomeAffection<SnowBiome>(AffectionLevel.Dislike);

            NPC.Happiness.SetNPCAffection<Brewer>(AffectionLevel.Love);
            NPC.Happiness.SetNPCAffection<Alchemist>(AffectionLevel.Like);
            NPC.Happiness.SetNPCAffection(NPCID.GoblinTinkerer, AffectionLevel.Dislike);
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
                new FlavorTextBestiaryInfoElement("Mods.AlchemistNPCLite.Bestiary.YoungBrewer")
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
            AnimationType = NPCID.Angler;
        }

        public override bool CanTownNPCSpawn(int numTownNPCs)/* tModPorter Suggestion: Copy the implementation of NPC.SpawnAllowed_Merchant in vanilla if you to count money, and be sure to set a flag when unlocked, so you don't count every tick. */
        {
            if (Main.hardMode && AlchemistNPCLite.modConfiguration.YoungBrewerSpawn)
            {
                if (NPC.AnyNPCs(ModContent.NPCType<Brewer>()))
                {
                    if (NPC.AnyNPCs(ModContent.NPCType<Alchemist>()))
                    {
                        return true;
                    }
                }
            }
            return false;
        }


        public override List<string> SetNPCNameList()
        {                                       //NPC names
            string Harold = Language.GetTextValue("Mods.AlchemistNPCLite.Harold");
            string Charles = Language.GetTextValue("Mods.AlchemistNPCLite.Charles");
            string Monty = Language.GetTextValue("Mods.AlchemistNPCLite.Monty");
            string Lucas = Language.GetTextValue("Mods.AlchemistNPCLite.Lucas");
            string Porky = Language.GetTextValue("Mods.AlchemistNPCLite.Porky");
            string Leeland = Language.GetTextValue("Mods.AlchemistNPCLite.Leeland");
            string Atreus = Language.GetTextValue("Mods.AlchemistNPCLite.Atreus");

            return new List<string>() {
                Harold,
                Charles,
                Monty,
                Lucas,
                Porky,
                Atreus,
                Leeland
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
            projType = ProjectileID.ToxicFlask;
            attackDelay = 5;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 12f;
            randomOffset = 2f;
        }


        public override string GetChat()
        {                                           //npc chat
            string Entry1 = Language.GetTextValue("Mods.AlchemistNPCLite.Entry1");
            string Entry2 = Language.GetTextValue("Mods.AlchemistNPCLite.Entry2");
            string Entry3 = Language.GetTextValue("Mods.AlchemistNPCLite.Entry3");
            string Entry4 = Language.GetTextValue("Mods.AlchemistNPCLite.Entry4");
            string Entry5 = Language.GetTextValue("Mods.AlchemistNPCLite.Entry5");
            string Entry6 = Language.GetTextValue("Mods.AlchemistNPCLite.Entry6");
            string Entry7 = Language.GetTextValue("Mods.AlchemistNPCLite.Entry7");
            string Entry8 = Language.GetTextValue("Mods.AlchemistNPCLite.Entry8");
            string Entry9 = Language.GetTextValue("Mods.AlchemistNPCLite.Entry9");
            string Entry10 = Language.GetTextValue("Mods.AlchemistNPCLite.Entry10");
            int Brewer = NPC.FindFirstNPC(ModContent.NPCType<Brewer>());
            if (Brewer >= 0 && Main.rand.NextBool(4))
            {
                return Entry8 + Main.npc[Brewer].GivenName + Entry9;
            }
            switch (Main.rand.Next(8))
            {
                case 0:
                    return Entry1;
                case 1:
                    return Entry2;
                case 2:
                    return Entry3;
                case 3:
                    return Entry4;
                case 4:
                    return Entry5;
                case 5:
                    return Entry6;
                case 6:
                    return Entry10;
                default:
                    return Entry7;
            }
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = "Combinations";
            button2 = "Flasks";
        }

        public override void OnChatButtonClicked(bool firstButton, ref string shopName)
        {
            if (firstButton)
            {
                shopName = Shop1;
            }
            else
            {
                shopName = Shop2;
            }
        }

        public override void AddShops()
        {
            ModLoader.TryGetMod("CalamityMod", out Mod Calamity);
            ModLoader.TryGetMod("ThoriumMod", out Mod ThoriumMod);
            ModLoader.TryGetMod("SpiritMod", out Mod SpiritMod);

            var shop = new NPCShop(Type, Shop1)
                .AddModItemToShop<VanTankCombination>(90000)
                .AddModItemToShop<TankCombination>(160000, () => Main.hardMode)
                .AddModItemToShop<BattleCombination>(120000)
                .AddModItemToShop<RangerCombination>(75000)
                .AddModItemToShop<MageCombination>(90000)
                .AddModItemToShop<BuilderCombination>(35000)
                .AddModItemToShop<ExplorerCombination>(80000)
                .AddModItemToShop<SummonerCombination>(30000)
                .AddModItemToShop<FishingCombination>(100000, () => Main.player[Main.myPlayer].anglerQuestsFinished >= 5)
                .AddModItemToShop<ThoriumCombination>(250000, () => NPC.downedMechBossAny && ThoriumMod != null)
                .AddModItemToShop<CalamityCombination>(350000, () => NPC.downedGolemBoss && Calamity != null)
            // IMPLEMENT WHEN WEAKREFERENCES FIXED
            /*
            if (ModLoader.GetMod("MorePotions") != null)
            {
                if (Main.hardMode)
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.MorePotionsCombination>());
                    shop.item[nextSlot].shopCustomPrice = 500000;
                    nextSlot++;
                }
            }
            */
                .AddModItemToShop<SpiritCombination>(250000, () => NPC.downedMechBossAny)
                .AddModItemToShop<UniversalCombination>(500000, () => NPC.downedMoonlord)
                .AddModItemToShop(ThoriumMod, "FrostCoatingItem", 5000, () => NPC.downedBoss3)
                .AddModItemToShop(ThoriumMod, "ToxicCoatingItem", 2500, () => NPC.downedBoss3)
                .AddModItemToShop(ThoriumMod, "GasContainer", 200, () => Main.hardMode)
                .AddModItemToShop(ThoriumMod, "AphrodisiacVial", 250, () => Main.hardMode)
                .AddModItemToShop(ThoriumMod, "PlasmaVial", 350, () => Main.hardMode && NPC.downedPlantBoss);
            shop.Register();

            shop = new NPCShop(Type, Shop2)
                .Add(new Item(ItemID.FlaskofPoison) { shopCustomPrice = 10000 },
                    Condition.DownedQueenBee)
                .Add(new Item(ItemID.FlaskofFire) { shopCustomPrice = 10000 },
                    Condition.DownedQueenBee)
                .Add(new Item(ItemID.FlaskofParty) { shopCustomPrice = 10000 },
                    Condition.DownedQueenBee)

                .Add(new Item(ItemID.FlaskofGold) { shopCustomPrice = 15000 },
                    Condition.Hardmode)
                .Add(new Item(ItemID.FlaskofIchor) { shopCustomPrice = 25000 },
                    Condition.Hardmode)
                .Add(new Item(ItemID.FlaskofCursedFlames) { shopCustomPrice = 25000 },
                    Condition.Hardmode)

                .Add(new Item(ItemID.FlaskofVenom) { shopCustomPrice = 30000 },
                    new Condition("", () => NPC.downedPlantBoss))
                .Add(new Item(ItemID.FlaskofNanites) { shopCustomPrice = 30000 },
                    new Condition("", () => NPC.downedPlantBoss))
            // IMPLEMENT WHEN WEAKREFERENCES FIXED
            /*
            if (ModLoader.GetMod("AAMod") != null)
            {
                if (Main.hardMode)
                {
                    addModItemToShop(AAMod, "DragonfireFlask", 20000, ref shop, ref nextSlot);
                    addModItemToShop(AAMod, "HydratoxinFlask", 20000, ref shop, ref nextSlot);
                }
            }
            */
                .AddModItemToShop(SpiritMod, "AcidVial", 30000, () => Main.hardMode)
				.AddModItemToShop(Calamity, "FlaskOfBrimstone", 40000, () => (bool)Calamity.Call("Downed", "calamitas doppelganger"))
				.AddModItemToShop(Calamity, "FlaskOfHolyFlames", 50000, () => NPC.downedMoonlord);
            shop.Register();
        }
    }
}
