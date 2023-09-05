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
    public class Jeweler : ModNPC
    {
        public static bool OH = false;
        public static bool SN = false;
        public static bool SN2 = false;
        public static bool SN3 = false;
        public static bool AS = false;
        public static bool TN1 = false;
        public static bool TN2 = false;
        public static bool TN3 = false;
        public static bool TN4 = false;
        public static bool TN5 = false;
        public static bool TN6 = false;
        public static bool TN7 = false;
        public static bool TN8 = false;
        public static bool TN9 = false;
        public static string Other = "Other";
        public static string Arena = "Arena";

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 25;
            NPCID.Sets.AttackFrameCount[NPC.type] = 4;
            NPCID.Sets.DangerDetectRange[NPC.type] = 500;
            NPCID.Sets.AttackType[NPC.type] = 0;
            NPCID.Sets.AttackTime[NPC.type] = 45;
            NPCID.Sets.AttackAverageChance[NPC.type] = 30;
            NPCID.Sets.HatOffsetY[NPC.type] = -2;

            NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            {
                Velocity = -1f,
                Direction = -1
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);

            NPC.Happiness.SetBiomeAffection<JungleBiome>(AffectionLevel.Like);
            NPC.Happiness.SetBiomeAffection<ForestBiome>(AffectionLevel.Love);
            NPC.Happiness.SetBiomeAffection<SnowBiome>(AffectionLevel.Dislike);

            NPC.Happiness.SetNPCAffection(NPCID.Merchant, AffectionLevel.Love);
            NPC.Happiness.SetNPCAffection(NPCID.TaxCollector, AffectionLevel.Like);
            NPC.Happiness.SetNPCAffection(NPCID.PartyGirl, AffectionLevel.Dislike);
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
                new FlavorTextBestiaryInfoElement("Mods.AlchemistNPCLite.Bestiary.Jeweler")
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
            NPC.defense = 50;
            NPC.lifeMax = 250;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.5f;
            AnimationType = NPCID.Merchant;
        }

        public override bool CanTownNPCSpawn(int numTownNPCs)/* tModPorter Suggestion: Copy the implementation of NPC.SpawnAllowed_Merchant in vanilla if you to count money, and be sure to set a flag when unlocked, so you don't count every tick. */
        {
            if (NPC.downedBoss1 && AlchemistNPCLite.modConfiguration.JewelerSpawn)
            {
                return true;
            }
            return false;
        }

        public override List<string> SetNPCNameList()
        {                                       //NPC names
            string Carl = Language.GetTextValue("Mods.AlchemistNPCLite.Carl");
            string John = Language.GetTextValue("Mods.AlchemistNPCLite.John");
            string JanMare = Language.GetTextValue("Mods.AlchemistNPCLite.JanMare");
            string LuiFransua = Language.GetTextValue("Mods.AlchemistNPCLite.LuiFransua");
            string Daniel = Language.GetTextValue("Mods.AlchemistNPCLite.Daniel");
            string Charley = Language.GetTextValue("Mods.AlchemistNPCLite.Charley");

            return new List<string>() {
                Carl,
                John,
                JanMare,
                LuiFransua,
                Daniel,
                Charley
            };
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            if (!Main.hardMode)
            {
                damage = 20;
            }
            if (Main.hardMode && !NPC.downedMoonlord)
            {
                damage = 100;
            }
            if (NPC.downedMoonlord)
            {
                damage = 1000;
            }
            knockback = 4f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 10;
            randExtraCooldown = 5;
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            projType = ModContent.ProjectileType<Projectiles.Gemstone>();
            attackDelay = 3;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 12f;
            randomOffset = 0f;
        }


        public override string GetChat()
        {                                           //npc chat
            string EntryJ1 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryJ1");
            string EntryJ2 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryJ2");
            string EntryJ3 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryJ3");
            string EntryJ4 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryJ4");
            string EntryJ5 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryJ5");
            string EntryJ6 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryJ6");
            string EntryJ7 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryJ7");
            string EntryJ8 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryJ8");
            string EntryJ9 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryJ9");
            string EntryJ10 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryJ10");
            int Merchant = NPC.FindFirstNPC(NPCID.Merchant);
            if (Merchant >= 0 && Main.rand.Next(5) == 0)
            {
                return EntryJ8 + Main.npc[Merchant].GivenName + EntryJ9;
            }
            if (ModLoader.TryGetMod("ThoriumMod", out Mod _))
            {
                switch (Main.rand.Next(2))
                {
                    case 0:
                        return EntryJ2;
                    case 1:
                        return EntryJ6;
                }
            }
            switch (Main.rand.Next(6))
            {
                case 0:
                    return EntryJ1;
                case 1:
                    return EntryJ3;
                case 2:
                    return EntryJ4;
                case 3:
                    return EntryJ5;
                case 4:
                    return EntryJ10;
                default:
                    return EntryJ7;
            }
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            string ArenaShop = Language.GetTextValue("Mods.AlchemistNPCLite.ArenaShop");
            button = Language.GetTextValue("LegacyInterface.28");
            button2 = ArenaShop;
        }

        public override void OnChatButtonClicked(bool firstButton, ref string shopName)
        {
            if (firstButton)
            {
                OH = true;
                AS = false;
                shopName = Other;
            }
            else
            {
                OH = false;
                AS = true;
                shopName = Arena;
            }
        }

        public override void AddShops()
        {
            ModLoader.TryGetMod("ThoriumMod", out Mod ThoriumMod);
            //ModLoader.TryGetMod("Tremor", out Mod Tremor);
            ModLoader.TryGetMod("SpiritMod", out Mod SpiritMod);
            ModLoader.TryGetMod("CalamityMod", out Mod Calamity);
            //ModLoader.TryGetMod("ShardsOfAtheria", out Mod Atheria);

            var shop = new NPCShop(Type, Other)
                .Add(new Item(ItemID.Amethyst) { shopCustomPrice = 1000 })
                .Add(new Item(ItemID.Topaz) { shopCustomPrice = 1000 })
                .Add(new Item(ItemID.Sapphire) { shopCustomPrice = 3000 }, Condition.DownedEowOrBoc)
                .Add(new Item(ItemID.Emerald) { shopCustomPrice = 3000 }, Condition.DownedEowOrBoc)
                .Add(new Item(ItemID.Amber) { shopCustomPrice = 5000 }, Condition.DownedEowOrBoc)
                .Add(new Item(ItemID.FossilOre) { shopCustomPrice = 5000 }, Condition.DownedEowOrBoc)
                .AddModItemToShop(ThoriumMod, "Opal", 5000, Condition.DownedEowOrBoc)
                .AddModItemToShop(ThoriumMod, "Aquamarine", 5000, Condition.DownedEowOrBoc)
                //.AddModItemToShop(Atheria, "Jade", 4500, Condition.DownedEowOrBoc)
                .Add(new Item(ItemID.BandofStarpower) { shopCustomPrice = 30000 }, Condition.DownedEowOrBoc)
                .Add(new Item(ItemID.BandofRegeneration) { shopCustomPrice = 50000 }, Condition.DownedEowOrBoc)
                .Add(new Item(ItemID.LifeCrystal) { shopCustomPrice = 100000 }, Condition.DownedEowOrBoc, new Condition("", () => Main.netMode == NetmodeID.MultiplayerClient || Main.netMode == NetmodeID.Server))
                .Add(new Item(ItemID.LifeFruit) { shopCustomPrice = 100000 }, Condition.DownedEowOrBoc, new Condition("", () => Main.netMode == NetmodeID.MultiplayerClient || Main.netMode == NetmodeID.Server), Condition.DownedPlantera)
                .Add(new Item(ItemID.Ruby) { shopCustomPrice = 7500 }, Condition.DownedSkeletron)
                .Add(new Item(ItemID.Diamond) { shopCustomPrice = 7500 }, Condition.DownedSkeletron)
                .Add(new Item(ItemID.DiamondRing) { shopCustomPrice = 2000000 }, Condition.DownedSkeletron)
                .AddModItemToShop<Items.Summoning.HorrifyingSkull>(250000, Condition.DownedSkeletron)
                //.AddModItemToShop(Tremor, "Rupicide", 5000, Condition.DownedSkeletron)
                //.AddModItemToShop(Tremor, "Opal", 30000, Condition.DownedSkeletron)
                //.AddModItemToShop(Tremor, "MagiumShard", 7500, Condition.DownedSkeletron, Condition.Hardmode)
                //.AddModItemToShop(Tremor, "RuneBar", 7500, Condition.DownedSkeletron, Condition.Hardmode)
                //.AddModItemToShop(Tremor, "LapisLazuli", 150000, Condition.DownedSkeletron, Condition.DownedMoonLord)
                .AddModItemToShop(ThoriumMod, "GraniteEnergyCore", 10000, Condition.DownedSkeletron)
                .AddModItemToShop(ThoriumMod, "BronzeFragments", 10000, Condition.DownedSkeletron)
                .AddModItemToShop(SpiritMod, "GraniteChunk", 10000, Condition.DownedSkeletron)
                .AddModItemToShop(SpiritMod, "MarbleChunk", 10000, Condition.DownedSkeletron)
                .AddModItemToShop<Items.Summoning.AlchemistHorcrux>(150000, Condition.Hardmode)
                .AddModItemToShop<Items.Summoning.BrewerHorcrux>(150000, Condition.Hardmode)
                .AddModItemToShop<Items.Summoning.JewelerHorcrux>(150000, Condition.Hardmode)
                .AddModItemToShop<Items.Summoning.ArchitectHorcrux>(150000, Condition.Hardmode)
                .AddModItemToShop<Items.Summoning.TinkererHorcrux>(150000, Condition.Hardmode)
                .AddModItemToShop<Items.Summoning.MusicianHorcrux>(150000, Condition.Hardmode);
            shop.Register();
            shop = new NPCShop(Type, Arena)
                .Add(new Item(ItemID.Campfire) { shopCustomPrice = 5000 })
                .AddModItemToShop(ThoriumMod, "Mistletoe", 50000, Condition.DownedEowOrBoc)
                .Add(new Item(ItemID.SliceOfCake) { shopCustomPrice = 100000 }, Condition.DownedEowOrBoc)
                .Add(new Item(ItemID.WaterBucket) { shopCustomPrice = 15000 }, Condition.DownedSkeletron)
                .Add(new Item(ItemID.HoneyBucket) { shopCustomPrice = 30000 }, Condition.DownedSkeletron)
                .Add(new Item(ItemID.LavaBucket) { shopCustomPrice = 50000 }, Condition.DownedSkeletron)
                .Add(new Item(ItemID.HeartLantern) { shopCustomPrice = 30000 }, Condition.DownedSkeletron)
                .Add(new Item(ItemID.StarinaBottle) { shopCustomPrice = 10000 }, Condition.DownedSkeletron)
                .Add(new Item(ItemID.WaterCandle) { shopCustomPrice = 30000 }, Condition.DownedSkeletron)
                .Add(new Item(ItemID.PeaceCandle) { shopCustomPrice = 30000 }, Condition.DownedSkeletron)
                .AddModItemToShop(Calamity, "TranquilityCandle", 100000, Condition.DownedSkeletron, Condition.DownedPlantera)
                .AddModItemToShop(Calamity, "ChaosCandle", 150000, Condition.DownedSkeletron, Condition.DownedPlantera)
                .Add(new Item(ItemID.Spike) { shopCustomPrice = 10000 }, Condition.DownedSkeletron)
                .Add(new Item(ItemID.DartTrap) { shopCustomPrice = 30000 }, Condition.DownedSkeletron)
                .Add(new Item(ItemID.GeyserTrap) { shopCustomPrice = 100000 }, Condition.DownedSkeletron)
                .Add(new Item(ItemID.CatBast) { shopCustomPrice = 100000 }, Condition.DownedSkeletron)
                .Add(new Item(ItemID.WarTable) { shopCustomPrice = 150000 }, Condition.DownedOldOnesArmyAny)
                .Add(new Item(ItemID.SharpeningStation) { shopCustomPrice = 150000 }, Condition.DownedSkeletron)
                .Add(new Item(ItemID.BewitchingTable) { shopCustomPrice = 150000 }, Condition.DownedSkeletron)
                .Add(new Item(ItemID.AmmoBox) { shopCustomPrice = 250000 }, Condition.DownedSkeletron)
                .Add(new Item(ItemID.CrystalBall) { shopCustomPrice = 150000 }, Condition.Hardmode)
                .AddModItemToShop<Items.UltimaCake>(5000000, Condition.Hardmode)
                .Add(new Item(ItemID.HeartStatue) { shopCustomPrice = 500000 }, Condition.Hardmode)
                .Add(new Item(ItemID.StarStatue) { shopCustomPrice = 100000 }, Condition.Hardmode)
                .Add(new Item(ItemID.WoodenSpike) { shopCustomPrice = 20000 }, Condition.DownedGolem)
                .Add(new Item(ItemID.SpearTrap) { shopCustomPrice = 50000 }, Condition.DownedGolem)
                .Add(new Item(ItemID.SpikyBallTrap) { shopCustomPrice = 50000 }, Condition.DownedGolem)
                .Add(new Item(ItemID.SuperDartTrap) { shopCustomPrice = 750000 }, Condition.DownedGolem)
                .Add(new Item(ItemID.FlameTrap) { shopCustomPrice = 100000 }, Condition.DownedGolem);
            shop.Register();
        }
    }
}
