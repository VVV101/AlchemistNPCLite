using AlchemistNPCLite.Interface;
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
    public class Brewer : ModNPC
    {
        public static bool Shop1 = true;
        public static bool Shop2 = false;
        public static bool Shop3 = false;
        public static bool Shop4 = false;
        public static bool Shop5 = false;
        public static bool Shop6 = false;

        public const string SHOP_1 = "VanillaPotions";
        public const string SHOP_2 = "Mod/Calamity";
        public const string SHOP_3 = "Thorium/RG/Redemption";
        public const string SHOP_4 = "MorePotions/Atheria";
        public const string SHOP_5 = "UnuBattleRods/Tacklebox/Tremor";
        public const string SHOP_6 = "Wildlife/Sacred/Spirit/Cristilium/ExpSentr";

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 23;
            NPCID.Sets.AttackFrameCount[NPC.type] = 4;
            NPCID.Sets.DangerDetectRange[NPC.type] = 500;
            NPCID.Sets.AttackType[NPC.type] = 0;
            NPCID.Sets.AttackTime[NPC.type] = 45;
            NPCID.Sets.AttackAverageChance[NPC.type] = 30;
            NPCID.Sets.HatOffsetY[NPC.type] = -4;

            NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            {
                Velocity = -1f,
                Direction = -1
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);

            NPC.Happiness.SetBiomeAffection<JungleBiome>(AffectionLevel.Like);
            NPC.Happiness.SetBiomeAffection<ForestBiome>(AffectionLevel.Love);
            NPC.Happiness.SetBiomeAffection<SnowBiome>(AffectionLevel.Dislike);

            NPC.Happiness.SetNPCAffection<YoungBrewer>(AffectionLevel.Love);
            NPC.Happiness.SetNPCAffection<Alchemist>(AffectionLevel.Like);
            NPC.Happiness.SetNPCAffection(NPCID.WitchDoctor, AffectionLevel.Dislike);
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
                new FlavorTextBestiaryInfoElement("Mods.AlchemistNPCLite.Bestiary.Brewer")
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
            AnimationType = NPCID.Mechanic;
        }

        public override bool CanTownNPCSpawn(int numTownNPCs)/* tModPorter Suggestion: Copy the implementation of NPC.SpawnAllowed_Merchant in vanilla if you to count money, and be sure to set a flag when unlocked, so you don't count every tick. */
        {
            if (NPC.downedBoss1 && AlchemistNPCLite.modConfiguration.BrewerSpawn)
            {
                return true;
            }
            return false;
        }

        public override List<string> SetNPCNameList()
        {                                       //NPC names
            string Lillian = Language.GetTextValue("Mods.AlchemistNPCLite.Lillian");
            string Lucy = Language.GetTextValue("Mods.AlchemistNPCLite.Lucy");
            string Alice = Language.GetTextValue("Mods.AlchemistNPCLite.Alice");
            string Agness = Language.GetTextValue("Mods.AlchemistNPCLite.Agness");
            string Rocksahn = Language.GetTextValue("Mods.AlchemistNPCLite.Rocksahn");
            string Mary = Language.GetTextValue("Mods.AlchemistNPCLite.Mary");

            return new List<string>() {
                Lillian,
                Lucy,
                Alice,
                Rocksahn,
                Agness,
                Mary
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
            randomOffset = 1f;
        }


        public override string GetChat()
        {                                           //npc chat
            string EntryB1 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryB1");
            string EntryB2 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryB2");
            string EntryB3 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryB3");
            string EntryB4 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryB4");
            string EntryB5 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryB5");
            string EntryB6 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryB6");
            string EntryB7 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryB7");
            string EntryB8 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryB8");
            string EntryB9 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryB9");
            string EntryB10 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryB10");
            string EntryB11 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryB11");
            string EntryB12 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryB12");
            string EntryB13 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryB13");
            string EntryB14 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryB14");
            string EntryB15 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryB15");
            string EntryB16 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryB16");
            string EntryB17 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryB17");
            string EntryB18 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryB18");
            string EntryB19 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryB19");
            int Alchemist = NPC.FindFirstNPC(ModContent.NPCType<Alchemist>());
            int partyGirl = NPC.FindFirstNPC(NPCID.PartyGirl);
            if (Main.bloodMoon && partyGirl >= 0 && Alchemist >= 0 && Main.rand.Next(4) == 0)
            {
                return EntryB17 + Main.npc[partyGirl].GivenName + EntryB18 + Main.npc[Alchemist].GivenName + ".";
            }
            if (Main.bloodMoon)
            {
                switch (Main.rand.Next(4))
                {
                    case 0:
                        return EntryB13;
                    case 1:
                        return EntryB14;
                    case 2:
                        return EntryB15;
                    case 3:
                        return EntryB16;
                }
            }
            if (Main.invasionType == 1)
            {
                return EntryB10;
            }
            if (Main.invasionType == 3)
            {
                return EntryB11;
            }
            if (Main.invasionType == 4)
            {
                return EntryB12;
            }
            if (Alchemist >= 0 && Main.rand.Next(4) == 0)
            {
                return EntryB8 + Main.npc[Alchemist].GivenName + EntryB9;
            }
            switch (Main.rand.Next(8))
            {
                case 0:
                    return EntryB1;
                case 1:
                    return EntryB2;
                case 2:
                    return EntryB3;
                case 3:
                    return EntryB4;
                case 4:
                    return EntryB5;
                case 5:
                    return EntryB6;
                case 6:
                    return EntryB19;
                default:
                    return EntryB7;
            }
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            string ShopB1 = Language.GetTextValue("Mods.AlchemistNPCLite.ShopB1");
            string ShopB2 = Language.GetTextValue("Mods.AlchemistNPCLite.ShopB2");
            string ShopB3 = Language.GetTextValue("Mods.AlchemistNPCLite.ShopB3");
            string ShopB4 = Language.GetTextValue("Mods.AlchemistNPCLite.ShopB4");
            string ShopB5 = Language.GetTextValue("Mods.AlchemistNPCLite.ShopB5");
            string ShopB6 = Language.GetTextValue("Mods.AlchemistNPCLite.ShopB6");
            string ShopsChanger = Language.GetTextValue("Mods.AlchemistNPCLite.ShopsChanger");
            if (Shop1)
            {
                button = ShopB1;
            }
            if (Shop2)
            {
                button = ShopB2;
            }
            if (Shop3)
            {
                button = ShopB3;
            }
            if (Shop4)
            {
                button = ShopB4;
            }
            if (Shop5)
            {
                button = ShopB5;
            }
            if (Shop6)
            {
                button = ShopB6;
            }
            if (NPC.FindBuffIndex(119) >= 0 && NPC.AnyNPCs(ModContent.NPCType<Alchemist>()) && !NPC.AnyNPCs(ModContent.NPCType<YoungBrewer>()))
            {
                button2 = "???";
            }
            else
            {
                button2 = ShopsChanger;
            }
        }

        public override void OnChatButtonClicked(bool firstButton, ref string shopName)
        {
            if (firstButton)
            {
                shopName = ShopChangeUI.Shop;
                ShopChangeUI.visible = false;
            }
            else
            {
                if (NPC.HasBuff(BuffID.Lovestruck) && NPC.AnyNPCs(ModContent.NPCType<Alchemist>()) && !NPC.AnyNPCs(ModContent.NPCType<YoungBrewer>()))
                {
                    for (int k = 0; k < 255; k++)
                    {
                        Player player = Main.player[k];
                        if (player.active)
                        {
                            NPC.SpawnOnPlayer(k, ModContent.NPCType<YoungBrewer>());
                            return;
                        }
                    }
                }
                if (!ShopChangeUI.visible) ShopChangeUI.timeStart = Main.GameUpdateCount;
                ShopChangeUI.visible = true;
            }
        }

        //      // IMPLEMENT WHEN WEAKREFERENCES FIXED
        //      /*
        //      public bool SacredToolsDownedAbaddon
        //      {
        //      	get { return SacredTools.ModdedWorld.OblivionSpawns; }
        //      }

        //      public bool SacredToolsDownedSerpent
        //      {
        //      	get { return SacredTools.ModdedWorld.FlariumSpawns; }
        //      }

        //      public bool SacredToolsDownedLunarians
        //      {
        //      	get { return SacredTools.ModdedWorld.downedLunarians; }
        //      }
        //*/
        public bool CalamityModRevengeance
        {
            get
            {
                if (ModLoader.TryGetMod("CalamityMod", out Mod Calamity))
                {
                    return (bool)Calamity.Call("GetDifficultyActive", "revengeance");
                }
                return false;
            }
        }

        public override void AddShops()
        {
            ModLoader.TryGetMod("CalamityMod", out Mod Calamity);
            ModLoader.TryGetMod("ThoriumMod", out Mod ThoriumMod);
            ModLoader.TryGetMod("Redemption", out Mod Redemption);
			//ModLoader.TryGetMod("ShardsOfAtheria", out Mod Atheria);

            var shop = new NPCShop(Type, SHOP_1)
                .Add(new Item(ItemID.SwiftnessPotion) { shopCustomPrice = 5000 })
                .Add(new Item(ItemID.IronskinPotion) { shopCustomPrice = 10000 })
                .Add(new Item(ItemID.RegenerationPotion) { shopCustomPrice = 10000 })
                .Add(new Item(ItemID.MiningPotion) { shopCustomPrice = 7500 })
                .Add(new Item(ItemID.BuilderPotion) { shopCustomPrice = 5000 })
                .Add(new Item(ItemID.ArcheryPotion) { shopCustomPrice = 15000 })
                .Add(new Item(ItemID.SummoningPotion) { shopCustomPrice = 7500 })
                .Add(new Item(ItemID.EndurancePotion) { shopCustomPrice = 10000 })
                .Add(new Item(ItemID.HeartreachPotion) { shopCustomPrice = 10000 })
                .Add(new Item(ItemID.AmmoReservationPotion) { shopCustomPrice = 7500 })
                .Add(new Item(ItemID.ThornsPotion) { shopCustomPrice = 5000 })
                .Add(new Item(ItemID.ShinePotion) { shopCustomPrice = 5000 })
                .Add(new Item(ItemID.NightOwlPotion) { shopCustomPrice = 5000 })
                .Add(new Item(ItemID.WarmthPotion) { shopCustomPrice = 5000 })
                .Add(new Item(ItemID.SpelunkerPotion) { shopCustomPrice = 20000 })
                .Add(new Item(ItemID.HunterPotion) { shopCustomPrice = 10000 })
                .Add(new Item(ItemID.TrapsightPotion) { shopCustomPrice = 10000 })
                .Add(new Item(ItemID.FlipperPotion) { shopCustomPrice = 5000 })
                .Add(new Item(ItemID.GillsPotion) { shopCustomPrice = 5000 })
                .Add(new Item(ItemID.InvisibilityPotion) { shopCustomPrice = 5000 })
                .Add(new Item(ItemID.WaterWalkingPotion) { shopCustomPrice = 5000 })
                .Add(new Item(ItemID.ObsidianSkinPotion) { shopCustomPrice = 10000 })
                .Add(new Item(ItemID.FeatherfallPotion) { shopCustomPrice = 7500 })
                .Add(new Item(ItemID.GravitationPotion) { shopCustomPrice = 20000 })
                .Add(new Item(ItemID.MagicPowerPotion) { shopCustomPrice = 15000 })
                .Add(new Item(ItemID.ManaRegenerationPotion) { shopCustomPrice = 5000 })
                .Add(new Item(ItemID.TitanPotion) { shopCustomPrice = 7500 })
                .Add(new Item(ItemID.BattlePotion) { shopCustomPrice = 10000 })
                .Add(new Item(ItemID.CalmingPotion) { shopCustomPrice = 10000 })
                .Add(new Item(ItemID.BiomeSightPotion) { shopCustomPrice = 10000 })
                .Add(new Item(ItemID.WrathPotion) { shopCustomPrice = 25000 },
                    Condition.DownedEowOrBoc)
                .Add(new Item(ItemID.RagePotion) { shopCustomPrice = 25000 },
                    Condition.DownedEowOrBoc)
                .Add(new Item(ItemID.LifeforcePotion) { shopCustomPrice = 25000 },
                    Condition.Hardmode)
                .Add(new Item(ItemID.InfernoPotion) { shopCustomPrice = 15000 },
                    Condition.DownedSkeletron)
                .Add(new Item(ItemID.StinkPotion) { shopCustomPrice = 7500 })
                .Add(new Item(ItemID.LovePotion) { shopCustomPrice = 7500 },
                    Condition.Hardmode)
                .Add(new Item(ItemID.FishingPotion) { shopCustomPrice = 10000 },
                    new Condition("", () => Main.player[Main.myPlayer].anglerQuestsFinished >= 1))
                .Add(new Item(ItemID.SonarPotion) { shopCustomPrice = 10000 },
                    new Condition("", () => Main.player[Main.myPlayer].anglerQuestsFinished >= 1))
                .Add(new Item(ItemID.CratePotion) { shopCustomPrice = 10000 },
                    new Condition("", () => Main.player[Main.myPlayer].anglerQuestsFinished >= 1))
                .Add(new Item(ItemID.GenderChangePotion) { shopCustomPrice = 100000 });
            shop.Register();

            shop = new NPCShop(Type, SHOP_2)
                .AddModItemToShop<SunshinePotion>(15000)
                .AddModItemToShop<Dopamine>(15000)
                .AddModItemToShop<GreaterDangersensePotion>(25000)
                .AddModItemToShop<NatureBlessingPotion>(25000)
                .AddModItemToShop<BewitchingPotion>(10000, () => NPC.downedBoss3)
                .AddModItemToShop<FortitudePotion>(15000, () => NPC.downedBoss3)
                .AddModItemToShop<InvincibilityPotion>(15000, () => Main.hardMode)
                .AddModItemToShop<TitanSkinPotion>(15000, () => Main.hardMode)
                .AddModItemToShop<DiscordPotion>(200000, () => NPC.downedMechBossAny && !NPC.downedMoonlord)
                .AddModItemToShop<PerfectDiscordPotion>(330000, () => NPC.downedMoonlord)
                .AddModItemToShop<BlurringPotion>(150000, () => NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
                .AddModItemToShop<NinjaPotion>(75000, () => NPC.downedPlantBoss)
                .AddModItemToShop<TrapsPotion>(50000, () => NPC.downedGolemBoss)
                .AddModItemToShop(Calamity, "BoundingPotion", 20000)
                .AddModItemToShop(Calamity, "CalciumPotion", 35000)
                .AddModItemToShop(Calamity, "TriumphPotion", 30000)
                .AddModItemToShop(Calamity, "TeslaPotion", 25000)
                .AddModItemToShop(Calamity, "SulphurskinPotion", 15000)
                .AddModItemToShop(Calamity, "ShadowPotion", 15000)
                .AddModItemToShop(Calamity, "PotionofOmniscience", 20000, () => NPC.downedBoss3)
                .AddModItemToShop(Calamity, "ZergPotion", 30000, () => (bool)Calamity.Call("Downed", "slime god"))
                .AddModItemToShop(Calamity, "ZenPotion", 30000, () => (bool)Calamity.Call("Downed", "slime god"))
                .AddModItemToShop(Calamity, "PhotosynthesisPotion", 50000, () => Main.hardMode)
                .AddModItemToShop(Calamity, "SoaringPotion", 40000, () => Main.hardMode)
                .AddModItemToShop(Calamity, "AstralInjection", 10000, () => (bool)Calamity.Call("Downed", "astrum aureus"))
                .AddModItemToShop(Calamity, "GravityNormalizerPotion", 30000, () => (bool)Calamity.Call("Downed", "astrum aureus"))
                .AddModItemToShop(Calamity, "CeaselessHungerPotion", 50000, () => (bool)Calamity.Call("Downed", "ceaselessvoid"));
            shop.Register();

            shop = new NPCShop(Type, SHOP_3)
                .AddModItemToShop(ThoriumMod, "WarmongerPotion", 10000, Condition.DownedSkeletron)
                .AddModItemToShop(ThoriumMod, "ArtilleryPotion", 10000, Condition.DownedSkeletron)
                .AddModItemToShop(ThoriumMod, "BouncingFlamePotion", 10000, Condition.DownedSkeletron)
                .AddModItemToShop(ThoriumMod, "CreativityPotion", 10000, Condition.DownedSkeletron)
                .AddModItemToShop(ThoriumMod, "EarwormPotion", 10000, Condition.DownedSkeletron)
                .AddModItemToShop(ThoriumMod, "AssassinPotion", 10000, Condition.DownedSkeletron)
                .AddModItemToShop(ThoriumMod, "InspirationReachPotion", 20000, Condition.Hardmode)
                .AddModItemToShop(ThoriumMod, "GlowingPotion", 20000)
                .AddModItemToShop(ThoriumMod, "HolyPotion", 20000, Condition.Hardmode)
                .AddModItemToShop(ThoriumMod, "ArcanePotion", 20000, Condition.Hardmode)
                .AddModItemToShop(ThoriumMod, "KineticPotion", 20000, Condition.Hardmode)
                .AddModItemToShop(ThoriumMod, "HydrationPotion", 10000)
                .AddModItemToShop(ThoriumMod, "BloodPotion", 10000)
                .AddModItemToShop(ThoriumMod, "ConflagrationPotion", 10000)
                .AddModItemToShop(ThoriumMod, "AquaPotion", 10000)
                .AddModItemToShop(ThoriumMod, "FrenzyPotion", 10000)
                .AddModItemToShop(Redemption, "CharismaPotion", 5000)
                .AddModItemToShop(Redemption, "VendettaPotion", 6000)
                .AddModItemToShop(Redemption, "VigourousPotion", 250000, () => Operator.RedemptionDowned.Nebuleus);
            shop.Register();

            shop = new NPCShop(Type, SHOP_4);
				/*.AddModItemToShop(Atheria, "SoulInjection", 7500)
				.AddModItemToShop(Atheria, "BoneMarrowInjection", 7500, Condition.DownedSkeletron)
				.AddModItemToShop(Atheria, "ConductivityPotion", 7500, Condition.DownedEowOrBoc)
				.AddModItemToShop(Atheria, "ChargedFlightPotion", 7500, () => Operator.ShardsConditions.DownedNova);*/
            shop.Register();

            shop = new NPCShop(Type, SHOP_5);
            shop.Register();
        }
    }
}