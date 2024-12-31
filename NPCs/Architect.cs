using AlchemistNPCLite.Interface;
using AlchemistNPCLite.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.Personalities;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace AlchemistNPCLite.NPCs
{
    [AutoloadHead]
    public class Architect : ModNPC
    {
        public static bool Shop1 = true;
        public static bool Shop2 = false;
        public static bool Shop3 = false;
        public static bool Shop4 = false;
        public static bool Shop5 = false;
        public static bool Shop6 = false;
        public static bool Shop7 = false;
        public static bool Shop8 = false;
        public static bool Shop9 = false;
        public static bool Shop10 = false;
        public static string Filler = "Filler";
        public static string Building = "Building";
        public static string BasicFurn = "BasicFurn";
        public static string AdvFurn = "AdvFurn";
        public static string Torch = "Torch";
        public static string Candle = "Candle";
        public static string Lamp = "Lamp";
        public static string Lantern = "Lantern";
        public static string Chandelier = "Chandelier";
        public static string Candelabra = "Candelabra";

        public override string Texture
        {
            get
            {
                return "AlchemistNPCLite/NPCs/Architect";
            }
        }
        // Possibly removed
        // public override bool Autoload(ref string name)
        // {
        // 	name = "Architect";
        // 	return true;
        // }

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 26;
            NPCID.Sets.AttackFrameCount[NPC.type] = 5;
            NPCID.Sets.DangerDetectRange[NPC.type] = 100;
            NPCID.Sets.AttackType[NPC.type] = 3;
            NPCID.Sets.AttackTime[NPC.type] = 35;
            NPCID.Sets.AttackAverageChance[NPC.type] = 50;
            NPCID.Sets.HatOffsetY[NPC.type] = -4;

            NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            {
                Velocity = -1f,
                Direction = -1
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);

            NPC.Happiness.SetBiomeAffection<OceanBiome>(AffectionLevel.Like);
            NPC.Happiness.SetBiomeAffection<JungleBiome>(AffectionLevel.Love);
            NPC.Happiness.SetBiomeAffection<SnowBiome>(AffectionLevel.Dislike);

            NPC.Happiness.SetNPCAffection(NPCID.Painter, AffectionLevel.Love);
            NPC.Happiness.SetNPCAffection(NPCID.GoblinTinkerer, AffectionLevel.Like);
            NPC.Happiness.SetNPCAffection(NPCID.TaxCollector, AffectionLevel.Dislike);
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Jungle,
                new FlavorTextBestiaryInfoElement("Mods.AlchemistNPCLite.Bestiary.Architect")
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
            AnimationType = NPCID.Guide;
        }

        public override bool CanTownNPCSpawn(int numTownNPCs)/* tModPorter Suggestion: Copy the implementation of NPC.SpawnAllowed_Merchant in vanilla if you to count money, and be sure to set a flag when unlocked, so you don't count every tick. */
        {
            if (numTownNPCs >= 3 && AlchemistNPCLite.modConfiguration.ArchitectSpawn)
            {
                return true;
            }
            return false;
        }


        public override List<string> SetNPCNameList()
        {                                       //NPC names
            string Joe = Language.GetTextValue("Mods.AlchemistNPCLite.Joe");
            string Mark = Language.GetTextValue("Mods.AlchemistNPCLite.Mark");
            string Walter = Language.GetTextValue("Mods.AlchemistNPCLite.Walter");
            string Archer = Language.GetTextValue("Mods.AlchemistNPCLite.Archer");
            string Frido = Language.GetTextValue("Mods.AlchemistNPCLite.Frido");
            string Li = Language.GetTextValue("Mods.AlchemistNPCLite.Li");

            return new List<string>() {
                Joe,
                Mark,
                Walter,
                Archer,
                Frido,
                Li
            };
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = 10;
            knockback = 8f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 10;
            randExtraCooldown = 10;
        }

        public override void DrawTownAttackSwing(ref Texture2D item, ref Rectangle itemFrame, ref int itemSize, ref float scale, ref Vector2 offset)//Allows you to customize how this town NPC's weapon is drawn when this NPC is swinging it (this NPC must have an attack type of 3). ItemType is the Texture2D instance of the item to be drawn (use Main.PopupTexture[id of item]), itemSize is the width and height of the item's hitbox
        {
            scale = 1f;
            item = TextureAssets.Item[ItemID.IronHammer].Value; //this defines the item that this npc will use
            itemSize = 40;
        }

        public override void TownNPCAttackSwing(ref int itemWidth, ref int itemHeight) //  Allows you to determine the width and height of the item this town NPC swings when it attacks, which controls the range of this NPC's swung weapon.
        {
            itemWidth = 50;
            itemHeight = 50;
        }

        public override string GetChat()
        {                                          //npc chat
            string A1 = Language.GetTextValue("Mods.AlchemistNPCLite.A1");
            string A2 = Language.GetTextValue("Mods.AlchemistNPCLite.A2");
            string A3 = Language.GetTextValue("Mods.AlchemistNPCLite.A3");
            string A4 = Language.GetTextValue("Mods.AlchemistNPCLite.A4");
            string A5 = Language.GetTextValue("Mods.AlchemistNPCLite.A5");
            string A6 = Language.GetTextValue("Mods.AlchemistNPCLite.A6");
            string A7 = Language.GetTextValue("Mods.AlchemistNPCLite.A7");
            string A8 = Language.GetTextValue("Mods.AlchemistNPCLite.A8");
            string A9 = Language.GetTextValue("Mods.AlchemistNPCLite.A9");
            string A10 = Language.GetTextValue("Mods.AlchemistNPCLite.A10");
            string A11 = Language.GetTextValue("Mods.AlchemistNPCLite.A11");
            string A12 = Language.GetTextValue("Mods.AlchemistNPCLite.A12");
            string A13 = Language.GetTextValue("Mods.AlchemistNPCLite.A13");
            string A14 = Language.GetTextValue("Mods.AlchemistNPCLite.A14");
            string A15 = Language.GetTextValue("Mods.AlchemistNPCLite.A15");
            string A16 = Language.GetTextValue("Mods.AlchemistNPCLite.A16");
            string A17 = Language.GetTextValue("Mods.AlchemistNPCLite.A17");
            string A18 = Language.GetTextValue("Mods.AlchemistNPCLite.A18");
            string A19 = Language.GetTextValue("Mods.AlchemistNPCLite.A19");
            string A20 = Language.GetTextValue("Mods.AlchemistNPCLite.A20");
            string A21 = Language.GetTextValue("Mods.AlchemistNPCLite.A21");
            string A22 = Language.GetTextValue("Mods.AlchemistNPCLite.A22");

            int goblinTinkerer = NPC.FindFirstNPC(NPCID.GoblinTinkerer);
            int partyGirl = NPC.FindFirstNPC(NPCID.PartyGirl);
            int demolitionist = NPC.FindFirstNPC(NPCID.Demolitionist);
            int Operator = NPC.FindFirstNPC(ModContent.NPCType<Operator>());
            if (Main.bloodMoon && partyGirl >= 0 && goblinTinkerer >= 0 && Main.rand.Next(4) == 0)
            {
                return A1 + Main.npc[partyGirl].GivenName + A2 + Main.npc[goblinTinkerer].GivenName + A3;
            }
            if (Main.bloodMoon)
            {
                switch (Main.rand.Next(4))
                {
                    case 0:
                        return A4;
                    case 1:
                        return A5;
                    case 2:
                        return A6;
                    case 3:
                        return A7;
                    case 4:
                        return A8;
                }
            }
            if (Main.invasionType == 1)
            {
                return A9;
            }
            if (Main.invasionType == 3)
            {
                return A10;
            }
            if (Main.invasionType == 4)
            {
                return A11;
            }
            if (demolitionist >= 0 && Main.rand.Next(5) == 0)
            {
                return A12 + Main.npc[demolitionist].GivenName + A13;
            }
            if (Operator >= 0 && Main.rand.Next(7) == 0)
            {
                return A21;
            }
            switch (Main.rand.Next(8))
            {
                case 0:
                    return A14;
                case 1:
                    return A15;
                case 2:
                    return A16;
                case 3:
                    return A17;
                case 4:
                    return A18;
                case 5:
                    return A19;
                case 6:
                    return A21;
                default:
                    return A20;
            }
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            string AS1 = Language.GetTextValue("Mods.AlchemistNPCLite.AS1");
            string AS2 = Language.GetTextValue("Mods.AlchemistNPCLite.AS2");
            string AS3 = Language.GetTextValue("Mods.AlchemistNPCLite.AS3");
            string AS4 = Language.GetTextValue("Mods.AlchemistNPCLite.AS4");
            string AS5 = Language.GetTextValue("Mods.AlchemistNPCLite.AS5");
            string AS6 = Language.GetTextValue("Mods.AlchemistNPCLite.AS6");
            string AS7 = Language.GetTextValue("Mods.AlchemistNPCLite.AS7");
            string AS8 = Language.GetTextValue("Mods.AlchemistNPCLite.AS8");
            string AS9 = Language.GetTextValue("Mods.AlchemistNPCLite.AS9");
            string AS10 = Language.GetTextValue("Mods.AlchemistNPCLite.AS10");
            string ShopsChanger = Language.GetTextValue("Mods.AlchemistNPCLite.ShopsChanger");
            if (Shop1)
            {
                button = AS1;
            }
            if (Shop2)
            {
                button = AS2;
            }
            if (Shop3)
            {
                button = AS3;
            }
            if (Shop4)
            {
                button = AS4;
            }
            if (Shop5)
            {
                button = AS5;
            }
            if (Shop6)
            {
                button = AS6;
            }
            if (Shop7)
            {
                button = AS7;
            }
            if (Shop8)
            {
                button = AS8;
            }
            if (Shop9)
            {
                button = AS9;
            }
            if (Shop10)
            {
                button = AS10;
            }
            button2 = ShopsChanger;
        }

        public override void OnChatButtonClicked(bool firstButton, ref string shopName)
        {
            if (firstButton)
            {
                shopName = ShopChangeUIA.Shop;
                ShopChangeUIA.visible = false;
            }
            else
            {
                if (!ShopChangeUIA.visible) ShopChangeUIA.timeStart = Main.GameUpdateCount;
                ShopChangeUIA.visible = true;
            }
        }

        // IMPLEMENT WHEN WEAKREFERENCES FIXED
        /*
        Mod chadsfurniture = ModLoader.GetMod("chadsfurni");
        */

        public override void AddShops()
        {
            ModLoader.TryGetMod("ThoriumMod", out Mod ThoriumMod);

            var shop = new NPCShop(Type, Filler)
				.Add(new Item(ItemID.Wood) { shopCustomPrice = 10 })
                .Add(new Item(ItemID.Ebonwood) { shopCustomPrice = 10 })
                .Add(new Item(ItemID.Shadewood) { shopCustomPrice = 10 })
                .Add(new Item(ItemID.BorealWood) { shopCustomPrice = 10 })
                .Add(new Item(ItemID.PalmWood) { shopCustomPrice = 15 })
                .Add(new Item(ItemID.RichMahogany) { shopCustomPrice = 15 })
				.Add(new Item(ItemID.BambooBlock) { shopCustomPrice = 15 })
				.Add(new Item(ItemID.AshWood) { shopCustomPrice = 15 })
                .AddModItemToShop(ThoriumMod, "YewWood", 500, Condition.DownedGoblinArmy)
				.Add(new Item(ItemID.SpookyWood) { shopCustomPrice = 10000 }, Condition.DownedPumpking)
                .Add(new Item(ItemID.DynastyWood) { shopCustomPrice = 100 })
                .Add(new Item(ItemID.DirtBlock) { shopCustomPrice = 1 })
                .Add(new Item(ItemID.ClayBlock) { shopCustomPrice = 20 })
                .Add(new Item(ItemID.StoneBlock) { shopCustomPrice = 5 })
                .Add(new Item(ItemID.EbonstoneBlock) { shopCustomPrice = 5 })
                .Add(new Item(ItemID.CrimstoneBlock) { shopCustomPrice = 5 })
                .Add(new Item(ItemID.CrimstoneBlock) { shopCustomPrice = 5 },
                    Condition.DownedQueenBee)
                .Add(new Item(ItemID.Hive) { shopCustomPrice = 10 },
                    Condition.DownedQueenBee)
                .Add(new Item(ItemID.SandBlock) { shopCustomPrice = 5 })
                .Add(new Item(ItemID.EbonsandBlock) { shopCustomPrice = 5 })
                .Add(new Item(ItemID.CrimsandBlock) { shopCustomPrice = 5 })
                .Add(new Item(ItemID.Sandstone) { shopCustomPrice = 5 })
                .Add(new Item(ItemID.HardenedSand) { shopCustomPrice = 5 })
                .Add(new Item(ItemID.MudBlock) { shopCustomPrice = 1 })
                .Add(new Item(ItemID.DesertFossil),
                    Condition.DownedEowOrBoc)
                .Add(new Item(ItemID.Obsidian) { shopCustomPrice = 2500 },
                    Condition.DownedEowOrBoc)
                .Add(new Item(ItemID.AshBlock) { shopCustomPrice = 1 })
                .Add(new Item(ItemID.SiltBlock))
                .Add(new Item(ItemID.SlushBlock))
                .Add(new Item(ItemID.SnowBlock) { shopCustomPrice = 1 })
                .Add(new Item(ItemID.IceBlock) { shopCustomPrice = 1 })
                .Add(new Item(ItemID.Marble) { shopCustomPrice = 50 })
                .Add(new Item(ItemID.Granite) { shopCustomPrice = 50 })
                .Add(new Item(ItemID.Cloud) { shopCustomPrice = 100 })
                .Add(new Item(ItemID.RainCloud) { shopCustomPrice = 100 })
                .Add(new Item(ItemID.PearlstoneBlock) { shopCustomPrice = 25 },
                    Condition.Hardmode)
                .Add(new Item(ItemID.PearlsandBlock) { shopCustomPrice = 25 },
                    Condition.Hardmode);
            shop.Register();

            shop = new NPCShop(Type, Building)
                .Add(new Item(ItemID.RedBrick) { shopCustomPrice = 40 })
                .Add(new Item(ItemID.RedDynastyShingles) { shopCustomPrice = 100 })
                .Add(new Item(ItemID.BlueDynastyShingles) { shopCustomPrice = 100 })
                .Add(new Item(ItemID.Pearlwood) { shopCustomPrice = 25 }, Condition.Hardmode)
                .Add(new Item(ItemID.GrayBrick) { shopCustomPrice = 10 })
                .Add(new Item(ItemID.Glass) { shopCustomPrice = 10 })
				.Add(new Item(ItemID.Pumpkin) { shopCustomPrice = 125 })
				.Add(new Item(ItemID.Cactus) { shopCustomPrice = 25 })
                .Add(new Item(ItemID.MeteoriteBrick) { shopCustomPrice = 60 }, Condition.DownedEowOrBoc)
                .Add(new Item(ItemID.ObsidianBrick) { shopCustomPrice = 5 })
                .Add(new Item(ItemID.IridescentBrick) { shopCustomPrice = 5 })
                .Add(new Item(ItemID.SnowBrick) { shopCustomPrice = 2 })
                .Add(new Item(ItemID.SandstoneBrick) { shopCustomPrice = 5 })
                .Add(new Item(ItemID.EbonstoneBrick) { shopCustomPrice = 10 })
                .Add(new Item(ItemID.CrimstoneBrick) { shopCustomPrice = 10 })
                .Add(new Item(ItemID.IceBrick) { shopCustomPrice = 2 })
                .Add(new Item(ItemID.StoneSlab) { shopCustomPrice = 5 })
                .Add(new Item(ItemID.AccentSlab) { shopCustomPrice = 2 })
                .Add(new Item(ItemID.SandstoneSlab) { shopCustomPrice = 2 })
                .Add(new Item(ItemID.MarbleBlock) { shopCustomPrice = 75 })
                .Add(new Item(ItemID.GraniteBlock) { shopCustomPrice = 75 })
                .Add(new Item(ItemID.HoneyBlock) { shopCustomPrice = 5 }, Condition.DownedQueenBee)
                .Add(new Item(ItemID.CrystalBlock) { shopCustomPrice = 100 }, Condition.Hardmode)
                .Add(new Item(ItemID.SunplateBlock) { shopCustomPrice = 25 })
                .Add(new Item(ItemID.PinkBrick) { shopCustomPrice = 50 }, Condition.DownedSkeletron)
                .Add(new Item(ItemID.GreenBrick) { shopCustomPrice = 50 }, Condition.DownedSkeletron)
                .Add(new Item(ItemID.BlueBrick) { shopCustomPrice = 50 }, Condition.DownedSkeletron)
                .Add(new Item(ItemID.AsphaltBlock) { shopCustomPrice = 2 }, Condition.DownedMechBossAny)
                .Add(new Item(ItemID.FleshBlock) { shopCustomPrice = 10 }, Condition.DownedMechBossAny)
                .Add(new Item(ItemID.PearlstoneBrick) { shopCustomPrice = 10 }, Condition.Hardmode)
                .Add(new Item(ItemID.RainbowBrick) { shopCustomPrice = 100 }, Condition.Hardmode)
                .Add(new Item(ItemID.LihzahrdBrick) { shopCustomPrice = 100 }, Condition.DownedGolem)
                .Add(new Item(ItemID.MartianConduitPlating) { shopCustomPrice = 25 }, Condition.DownedMartians);
            shop.Register();

            shop = new NPCShop(Type, BasicFurn)
                .Add(new Item(ItemID.Candle) { shopCustomPrice = 100 })
                .Add(new Item(ItemID.GoldChandelier) { shopCustomPrice = 25000 })
                .Add(new Item(ItemID.ChainLantern) { shopCustomPrice = 200 })
                .Add(new Item(ItemID.Mannequin) { shopCustomPrice = 200 })
                .Add(new Item(ItemID.Womannquin) { shopCustomPrice = 200 })
                .Add(new Item(ItemID.Cobweb) { shopCustomPrice = 45 })
                .Add(new Item(ItemID.WorkBench) { shopCustomPrice = 200 })
                .Add(new Item(ItemID.WoodenTable) { shopCustomPrice = 160 })
                .Add(new Item(ItemID.WoodenChair) { shopCustomPrice = 80 })
                .Add(new Item(ItemID.WoodenDoor) { shopCustomPrice = 120 })
                .Add(new Item(ItemID.WoodenBeam) { shopCustomPrice = 10 })
                .Add(new Item(ItemID.Book) { shopCustomPrice = 250 })
                .Add(new Item(ItemID.Fireplace) { shopCustomPrice = 750 })
                .Add(new Item(ItemID.Chimney) { shopCustomPrice = 500 })
                .Add(new Item(ItemID.Furnace) { shopCustomPrice = 300 })
                .Add(new Item(ItemID.BanquetTable) { shopCustomPrice = 300 })
                .Add(new Item(ItemID.HeavyWorkBench) { shopCustomPrice = 5000 })
                .Add(new Item(ItemID.BrickLayer) { shopCustomPrice = 150000 }, Condition.Hardmode)
                .Add(new Item(ItemID.PortableCementMixer) { shopCustomPrice = 150000 }, Condition.Hardmode)
                .Add(new Item(ItemID.PaintSprayer) { shopCustomPrice = 150000 }, Condition.Hardmode)
                .Add(new Item(ItemID.ExtendoGrip) { shopCustomPrice = 150000 }, Condition.Hardmode)
                .Add(new Item(ItemID.PortableStool) { shopCustomPrice = 150000 }, Condition.Hardmode)
                .Add(new Item(ItemID.TreasureMagnet) { shopCustomPrice = 150000 }, Condition.Hardmode)
                .Add(new Item(ItemID.AncientChisel) { shopCustomPrice = 150000 }, Condition.Hardmode)
                .Add(new Item(ItemID.ActuationAccessory) { shopCustomPrice = 150000 }, Condition.Hardmode)
                .Add(new Item(ItemID.Ruler) { shopCustomPrice = 150000 }, Condition.DownedSkeletron)
                .Add(new Item(ItemID.EngineeringHelmet) { shopCustomPrice = 150000 }, Condition.DownedSkeletron);
            shop.Register();

            shop = new NPCShop(Type, AdvFurn)
                .Add(new Item(ItemID.LivingLoom) { shopCustomPrice = 20000 })
                .Add(new Item(ItemID.AlchemyTable) { shopCustomPrice = 33000 }, Condition.DownedSkeletron)
                .Add(new Item(ItemID.BoneWelder) { shopCustomPrice = 20000 }, Condition.DownedSkeletron);
            if (ModLoader.TryGetMod("chadsfurni", out Mod chadsfurniture))
            {
                shop.AddModItemToShop(chadsfurniture, "printer", 20000, Condition.DownedSkeletron);
                shop.AddModItemToShop(chadsfurniture, "printer3", 20000, Condition.DownedSkeletron);
                shop.AddModItemToShop(chadsfurniture, "wallomatic", 20000, Condition.DownedSkeletron);
            }
            shop.Add(new Item(ItemID.GlassKiln) { shopCustomPrice = 20000 })
                .Add(new Item(ItemID.SkyMill) { shopCustomPrice = 20000 })
                .Add(new Item(ItemID.IceMachine) { shopCustomPrice = 20000 })
                .Add(new Item(ItemID.HoneyDispenser) { shopCustomPrice = 20000 }, Condition.DownedQueenBee)
                .Add(new Item(ItemID.Sawmill) { shopCustomPrice = 2000 })
                .Add(new Item(ItemID.Loom) { shopCustomPrice = 2000 });
            if (chadsfurniture != null)
            {
                shop.AddModItemToShop(chadsfurniture, "RimpelstiltskinsLoom", 200000, Condition.Hardmode);
            }
            shop.Add(new Item(ItemID.MeatGrinder) { shopCustomPrice = 15000 }, Condition.Hardmode)
                .Add(new Item(ItemID.FleshCloningVaat) { shopCustomPrice = 20000 }, Condition.DownedMechBossAny)
                .Add(new Item(ItemID.LesionStation) { shopCustomPrice = 20000 }, Condition.DownedMechBossAny)
                .Add(new Item(ItemID.LihzahrdFurnace) { shopCustomPrice = 20000 }, Condition.DownedPlantera);
            shop.Register();
			
			shop = new NPCShop(Type, Torch)
				.Add(new Item(ItemID.Torch) { shopCustomPrice = 50 })
				.Add(new Item(ItemID.TikiTorch) { shopCustomPrice = 250 })
				.Add(new Item(974) { shopCustomPrice = 300 })
				.Add(new Item(427) { shopCustomPrice = 300 })
				.Add(new Item(428) { shopCustomPrice = 300 })
				.Add(new Item(1245) { shopCustomPrice = 300 })
				.Add(new Item(429) { shopCustomPrice = 300 })
				.Add(new Item(430) { shopCustomPrice = 300 })
				.Add(new Item(431) { shopCustomPrice = 300 })
				.Add(new Item(432) { shopCustomPrice = 300 })
				.Add(new Item(433) { shopCustomPrice = 300 })
				.Add(new Item(523) { shopCustomPrice = 300 })
				.Add(new Item(1333) { shopCustomPrice = 300 })
				.Add(new Item(2274) { shopCustomPrice = 300 })
				.Add(new Item(3004) { shopCustomPrice = 300 })
				.Add(new Item(3045) { shopCustomPrice = 300 })
				.Add(new Item(3114) { shopCustomPrice = 300 })
                .Add(new Item(4383) { shopCustomPrice = 300 })
                .Add(new Item(4384) { shopCustomPrice = 300 })
                .Add(new Item(4385) { shopCustomPrice = 300 })
                .Add(new Item(4386) { shopCustomPrice = 300 })
                .Add(new Item(4387) { shopCustomPrice = 300 })
                .Add(new Item(4388) { shopCustomPrice = 300 })
                .Add(new Item(5293) { shopCustomPrice = 300 })
                .Add(new Item(5353) { shopCustomPrice = 300 });
			shop.Register();
			
			shop = new NPCShop(Type, Candle)
				.Add(new Item(105) { shopCustomPrice = 500 })
				.Add(new Item(713) { shopCustomPrice = 500 })
				.Add(new Item(1405) { shopCustomPrice = 500 })
				.Add(new Item(1406) { shopCustomPrice = 500 })
				.Add(new Item(1407) { shopCustomPrice = 500 })
				.Add(new Item(2045) { shopCustomPrice = 500 })
				.Add(new Item(2046) { shopCustomPrice = 500 })
				.Add(new Item(2047) { shopCustomPrice = 500 })
				.Add(new Item(2048) { shopCustomPrice = 500 })
				.Add(new Item(2049) { shopCustomPrice = 500 })
				.Add(new Item(2050) { shopCustomPrice = 500 })
				.Add(new Item(2051) { shopCustomPrice = 500 }, Condition.Hardmode)
				.Add(new Item(2052) { shopCustomPrice = 500 })
				.Add(new Item(2153) { shopCustomPrice = 500 })
				.Add(new Item(2154) { shopCustomPrice = 500 })
				.Add(new Item(2155) { shopCustomPrice = 30000 })
				.Add(new Item(2236) { shopCustomPrice = 500 })
				.Add(new Item(2523) { shopCustomPrice = 500 })
				.Add(new Item(2542) { shopCustomPrice = 500 })
				.Add(new Item(2556) { shopCustomPrice = 500 })
				.Add(new Item(2571) { shopCustomPrice = 500 })
				.Add(new Item(2648) { shopCustomPrice = 500 })
				.Add(new Item(2649) { shopCustomPrice = 500 })
				.Add(new Item(2650) { shopCustomPrice = 500 }, Condition.DownedPumpking)
				.Add(new Item(2651) { shopCustomPrice = 500 })
				.Add(new Item(2818) { shopCustomPrice = 500 }, Condition.DownedMartians)
				.Add(new Item(3171) { shopCustomPrice = 500 }, Condition.DownedEowOrBoc)
				.Add(new Item(3172) { shopCustomPrice = 500 })
				.Add(new Item(3173) { shopCustomPrice = 500 })
				.Add(new Item(3890) { shopCustomPrice = 500 }, Condition.Hardmode);
			shop.Register();
			
			shop = new NPCShop(Type, Lamp)
				.Add(new Item(341) { shopCustomPrice = 500 })
				.Add(new Item(2082) { shopCustomPrice = 500 })
				.Add(new Item(2083) { shopCustomPrice = 500 })
				.Add(new Item(2084) { shopCustomPrice = 500 })
				.Add(new Item(2085) { shopCustomPrice = 500 })
				.Add(new Item(2086) { shopCustomPrice = 500 })
				.Add(new Item(2087) { shopCustomPrice = 500 })
				.Add(new Item(2088) { shopCustomPrice = 500 }, Condition.Hardmode)
				.Add(new Item(2089) { shopCustomPrice = 500 })
				.Add(new Item(2090) { shopCustomPrice = 500 })
				.Add(new Item(2091) { shopCustomPrice = 500 }, Condition.DownedPumpking)
				.Add(new Item(2129) { shopCustomPrice = 500 })
				.Add(new Item(2130) { shopCustomPrice = 500 })
				.Add(new Item(2131) { shopCustomPrice = 500 })
				.Add(new Item(2132) { shopCustomPrice = 500 })
				.Add(new Item(2133) { shopCustomPrice = 30000 })
				.Add(new Item(2134) { shopCustomPrice = 500 })
				.Add(new Item(2225) { shopCustomPrice = 500 })
				.Add(new Item(2533) { shopCustomPrice = 500 })
				.Add(new Item(2547) { shopCustomPrice = 500 })
				.Add(new Item(2563) { shopCustomPrice = 500 })
				.Add(new Item(2578) { shopCustomPrice = 500 })
				.Add(new Item(2643) { shopCustomPrice = 500 })
				.Add(new Item(2644) { shopCustomPrice = 500 })
				.Add(new Item(2645) { shopCustomPrice = 500 })
				.Add(new Item(2646) { shopCustomPrice = 500 })
				.Add(new Item(2647) { shopCustomPrice = 500 })
				.Add(new Item(2819) { shopCustomPrice = 500 }, Condition.DownedMartians)
				.Add(new Item(2820) { shopCustomPrice = 500 }, Condition.DownedMartians)
				.Add(new Item(3135) { shopCustomPrice = 500 }, Condition.DownedEowOrBoc)
				.Add(new Item(3136) { shopCustomPrice = 500 })
				.Add(new Item(3137) { shopCustomPrice = 500 })
				.Add(new Item(3892) { shopCustomPrice = 500 }, Condition.Hardmode);
			shop.Register();
			
			shop = new NPCShop(Type, Lantern)
				.Add(new Item(136) { shopCustomPrice = 500 })
				.Add(new Item(344) { shopCustomPrice = 500 })
				.Add(new Item(347) { shopCustomPrice = 500 })
				.Add(new Item(1390) { shopCustomPrice = 500 })
				.Add(new Item(1391) { shopCustomPrice = 500 })
				.Add(new Item(1392) { shopCustomPrice = 500 })
				.Add(new Item(1393) { shopCustomPrice = 500 })
				.Add(new Item(1394) { shopCustomPrice = 500 })
				.Add(new Item(1808) { shopCustomPrice = 500 })
				.Add(new Item(2032) { shopCustomPrice = 500 })
				.Add(new Item(2033) { shopCustomPrice = 500 })
				.Add(new Item(2034) { shopCustomPrice = 500 })
				.Add(new Item(2035) { shopCustomPrice = 500 })
				.Add(new Item(2036) { shopCustomPrice = 500 })
				.Add(new Item(2037) { shopCustomPrice = 500 })
				.Add(new Item(2038) { shopCustomPrice = 500 })
				.Add(new Item(2039) { shopCustomPrice = 500 }, Condition.Hardmode)
				.Add(new Item(2040) { shopCustomPrice = 500 })
				.Add(new Item(2041) { shopCustomPrice = 500 })
				.Add(new Item(2042) { shopCustomPrice = 500 })
				.Add(new Item(2043) { shopCustomPrice = 500 }, Condition.DownedPumpking)
				.Add(new Item(2145) { shopCustomPrice = 500 })
				.Add(new Item(2146) { shopCustomPrice = 500 })
				.Add(new Item(2147) { shopCustomPrice = 30000 })
				.Add(new Item(2148) { shopCustomPrice = 500 })
				.Add(new Item(2226) { shopCustomPrice = 500 })
				.Add(new Item(2530) { shopCustomPrice = 500 })
				.Add(new Item(2546) { shopCustomPrice = 500 })
				.Add(new Item(2564) { shopCustomPrice = 500 })
				.Add(new Item(2579) { shopCustomPrice = 500 })
				.Add(new Item(2641) { shopCustomPrice = 500 })
				.Add(new Item(2642) { shopCustomPrice = 500 })
				.Add(new Item(2820) { shopCustomPrice = 500 })
				.Add(new Item(3138) { shopCustomPrice = 500 }, Condition.DownedEowOrBoc)
				.Add(new Item(3139) { shopCustomPrice = 500 })
				.Add(new Item(3140) { shopCustomPrice = 500 })
				.Add(new Item(3891) { shopCustomPrice = 500 }, Condition.Hardmode);
			shop.Register();
			
			shop = new NPCShop(Type, Chandelier)
				.Add(new Item(106) { shopCustomPrice = 25000 })
				.Add(new Item(107) { shopCustomPrice = 25000 })
				.Add(new Item(108) { shopCustomPrice = 25000 })
				.Add(new Item(710) { shopCustomPrice = 25000 })
				.Add(new Item(711) { shopCustomPrice = 25000 })
				.Add(new Item(712) { shopCustomPrice = 25000 })
				.Add(new Item(2055) { shopCustomPrice = 1200 })
				.Add(new Item(2056) { shopCustomPrice = 1200 })
				.Add(new Item(2057) { shopCustomPrice = 1200 })
				.Add(new Item(2058) { shopCustomPrice = 1200 })
				.Add(new Item(2059) { shopCustomPrice = 1200 })
				.Add(new Item(2060) { shopCustomPrice = 1200 })
				.Add(new Item(2061) { shopCustomPrice = 1200 }, Condition.Hardmode)
				.Add(new Item(2062) { shopCustomPrice = 1200 })
				.Add(new Item(2063) { shopCustomPrice = 1200 })
				.Add(new Item(2064) { shopCustomPrice = 1200 }, Condition.DownedPumpking)
				.Add(new Item(2065) { shopCustomPrice = 1200 })
				.Add(new Item(2141) { shopCustomPrice = 1200 })
				.Add(new Item(2142) { shopCustomPrice = 1200 })
				.Add(new Item(2143) { shopCustomPrice = 30000 })
				.Add(new Item(2144) { shopCustomPrice = 1200 })
				.Add(new Item(2224) { shopCustomPrice = 1200 })
				.Add(new Item(2525) { shopCustomPrice = 1200 })
				.Add(new Item(2543) { shopCustomPrice = 1200 })
				.Add(new Item(2558) { shopCustomPrice = 1200 })
				.Add(new Item(2573) { shopCustomPrice = 1200 })
				.Add(new Item(2652) { shopCustomPrice = 1200 })
				.Add(new Item(2653) { shopCustomPrice = 1200 })
				.Add(new Item(2654) { shopCustomPrice = 1200 })
				.Add(new Item(2655) { shopCustomPrice = 1200 })
				.Add(new Item(2656) { shopCustomPrice = 1200 })
				.Add(new Item(2657) { shopCustomPrice = 1200 })
				.Add(new Item(2813) { shopCustomPrice = 1200 }, Condition.DownedMartians)
				.Add(new Item(3177) { shopCustomPrice = 1200 }, Condition.DownedEowOrBoc)
				.Add(new Item(3178) { shopCustomPrice = 1200 })
				.Add(new Item(3179) { shopCustomPrice = 1200 })
				.Add(new Item(3894) { shopCustomPrice = 1200 }, Condition.Hardmode);
			shop.Register();
			
			shop = new NPCShop(Type, Candelabra)
				.Add(new Item(349) { shopCustomPrice = 500 })
				.Add(new Item(714) { shopCustomPrice = 500 })
				.Add(new Item(2092) { shopCustomPrice = 500 })
				.Add(new Item(2093) { shopCustomPrice = 500 })
				.Add(new Item(2094) { shopCustomPrice = 500 })
				.Add(new Item(2095) { shopCustomPrice = 500 })
				.Add(new Item(2096) { shopCustomPrice = 500 })
				.Add(new Item(2097) { shopCustomPrice = 500 })
				.Add(new Item(2098) { shopCustomPrice = 500 })
				.Add(new Item(2099) { shopCustomPrice = 500 }, Condition.Hardmode)
				.Add(new Item(2100) { shopCustomPrice = 500 })
				.Add(new Item(2101) { shopCustomPrice = 500 })
				.Add(new Item(2102) { shopCustomPrice = 500 })
				.Add(new Item(2103) { shopCustomPrice = 500 }, Condition.DownedPumpking)
				.Add(new Item(2149) { shopCustomPrice = 500 })
				.Add(new Item(2150) { shopCustomPrice = 500 })
				.Add(new Item(2151) { shopCustomPrice = 30000 })
				.Add(new Item(2152) { shopCustomPrice = 500 })
				.Add(new Item(2227) { shopCustomPrice = 500 })
				.Add(new Item(2522) { shopCustomPrice = 500 })
				.Add(new Item(2541) { shopCustomPrice = 500 })
				.Add(new Item(2555) { shopCustomPrice = 500 })
				.Add(new Item(2570) { shopCustomPrice = 500 })
				.Add(new Item(2664) { shopCustomPrice = 500 })
				.Add(new Item(2665) { shopCustomPrice = 500 })
				.Add(new Item(2666) { shopCustomPrice = 500 })
				.Add(new Item(2667) { shopCustomPrice = 500 })
				.Add(new Item(2668) { shopCustomPrice = 500 })
				.Add(new Item(2825) { shopCustomPrice = 500 }, Condition.DownedMartians)
				.Add(new Item(3168) { shopCustomPrice = 500 }, Condition.DownedEowOrBoc)
				.Add(new Item(3169) { shopCustomPrice = 500 })
				.Add(new Item(3170) { shopCustomPrice = 500 })
				.Add(new Item(3893) { shopCustomPrice = 500 }, Condition.Hardmode);
			shop.Register();
        }

        //    public override void ModifyActiveShop(string shopName, Item[] items)
        //    {
        //        if (Shop5)
        //        {
        //            shop.item[nextSlot].SetDefaults(ItemID.Torch);
        //            shop.item[nextSlot].shopCustomPrice = 50;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(ItemID.TikiTorch);
        //            shop.item[nextSlot].shopCustomPrice = 250;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(974);
        //            shop.item[nextSlot].shopCustomPrice = 300;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(427);
        //            shop.item[nextSlot].shopCustomPrice = 300;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(428);
        //            shop.item[nextSlot].shopCustomPrice = 300;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(1245);
        //            shop.item[nextSlot].shopCustomPrice = 300;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(429);
        //            shop.item[nextSlot].shopCustomPrice = 300;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(430);
        //            shop.item[nextSlot].shopCustomPrice = 300;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(431);
        //            shop.item[nextSlot].shopCustomPrice = 300;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(432);
        //            shop.item[nextSlot].shopCustomPrice = 300;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(433);
        //            shop.item[nextSlot].shopCustomPrice = 300;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(523);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(1333);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2274);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(3004);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(3045);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(3114);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //        }
        //        if (Shop6)
        //        {
        //            shop.item[nextSlot].SetDefaults(105);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(713);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(1405);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(1406);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(1407);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2045);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2046);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2047);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2048);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2049);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2050);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            if (Main.hardMode)
        //            {
        //                shop.item[nextSlot].SetDefaults(2051);
        //                shop.item[nextSlot].shopCustomPrice = 500;
        //                nextSlot++;
        //            }
        //            shop.item[nextSlot].SetDefaults(2052);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2153);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2154);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2155);
        //            shop.item[nextSlot].shopCustomPrice = 30000;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2236);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2523);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2542);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2556);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2571);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2648);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2649);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2650);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2651);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            if (NPC.downedMartians)
        //            {
        //                shop.item[nextSlot].SetDefaults(2818);
        //                shop.item[nextSlot].shopCustomPrice = 500;
        //                nextSlot++;
        //            }
        //            shop.item[nextSlot].SetDefaults(3171);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(3172);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(3173);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            if (Main.hardMode)
        //            {
        //                shop.item[nextSlot].SetDefaults(3890);
        //                shop.item[nextSlot].shopCustomPrice = 500;
        //                nextSlot++;
        //            }
        //        }
        //        if (Shop7)
        //        {
        //            shop.item[nextSlot].SetDefaults(341);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2082);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2083);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2084);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2085);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2086);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2087);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            if (Main.hardMode)
        //            {
        //                shop.item[nextSlot].SetDefaults(2088);
        //                shop.item[nextSlot].shopCustomPrice = 500;
        //                nextSlot++;
        //            }
        //            shop.item[nextSlot].SetDefaults(2089);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2090);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2091);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2129);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2130);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2131);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2132);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2133);
        //            shop.item[nextSlot].shopCustomPrice = 30000;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2134);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2225);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2533);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2547);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2563);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2578);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2643);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2644);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2645);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2646);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2647);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            if (NPC.downedMartians)
        //            {
        //                shop.item[nextSlot].SetDefaults(2819);
        //                shop.item[nextSlot].shopCustomPrice = 500;
        //                nextSlot++;
        //                shop.item[nextSlot].SetDefaults(2820);
        //                shop.item[nextSlot].shopCustomPrice = 500;
        //                nextSlot++;
        //            }
        //            shop.item[nextSlot].SetDefaults(3135);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(3136);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(3137);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            if (Main.hardMode)
        //            {
        //                shop.item[nextSlot].SetDefaults(3892);
        //                shop.item[nextSlot].shopCustomPrice = 500;
        //                nextSlot++;
        //            }
        //        }
        //        if (Shop8)
        //        {
        //            shop.item[nextSlot].SetDefaults(136);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(344);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(347);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(1390);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(1391);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(1392);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(1393);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(1394);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(1808);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2032);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2033);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2034);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2035);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2036);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2037);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2038);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            if (Main.hardMode)
        //            {
        //                shop.item[nextSlot].SetDefaults(2039);
        //                shop.item[nextSlot].shopCustomPrice = 500;
        //                nextSlot++;
        //            }
        //            shop.item[nextSlot].SetDefaults(2040);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2041);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2042);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2043);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2145);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2146);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2147);
        //            shop.item[nextSlot].shopCustomPrice = 30000;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2148);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2226);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2530);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2546);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2564);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2579);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2641);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2642);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2820);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(3138);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(3139);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(3140);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            if (Main.hardMode)
        //            {
        //                shop.item[nextSlot].SetDefaults(3891);
        //                shop.item[nextSlot].shopCustomPrice = 500;
        //                nextSlot++;
        //            }
        //        }
        //        if (Shop9)
        //        {
        //            shop.item[nextSlot].SetDefaults(106);
        //            shop.item[nextSlot].shopCustomPrice = 25000;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(107);
        //            shop.item[nextSlot].shopCustomPrice = 25000;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(108);
        //            shop.item[nextSlot].shopCustomPrice = 25000;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(710);
        //            shop.item[nextSlot].shopCustomPrice = 25000;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(711);
        //            shop.item[nextSlot].shopCustomPrice = 25000;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(712);
        //            shop.item[nextSlot].shopCustomPrice = 25000;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2055);
        //            shop.item[nextSlot].shopCustomPrice = 1200;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2056);
        //            shop.item[nextSlot].shopCustomPrice = 1200;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2057);
        //            shop.item[nextSlot].shopCustomPrice = 1200;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2058);
        //            shop.item[nextSlot].shopCustomPrice = 1200;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2059);
        //            shop.item[nextSlot].shopCustomPrice = 1200;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2060);
        //            shop.item[nextSlot].shopCustomPrice = 1200;
        //            nextSlot++;
        //            if (Main.hardMode)
        //            {
        //                shop.item[nextSlot].SetDefaults(2061);
        //                shop.item[nextSlot].shopCustomPrice = 1200;
        //                nextSlot++;
        //            }
        //            shop.item[nextSlot].SetDefaults(2062);
        //            shop.item[nextSlot].shopCustomPrice = 1200;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2063);
        //            shop.item[nextSlot].shopCustomPrice = 1200;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2064);
        //            shop.item[nextSlot].shopCustomPrice = 1200;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2065);
        //            shop.item[nextSlot].shopCustomPrice = 1200;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2141);
        //            shop.item[nextSlot].shopCustomPrice = 1200;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2142);
        //            shop.item[nextSlot].shopCustomPrice = 1200;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2143);
        //            shop.item[nextSlot].shopCustomPrice = 30000;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2144);
        //            shop.item[nextSlot].shopCustomPrice = 1200;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2224);
        //            shop.item[nextSlot].shopCustomPrice = 1200;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2525);
        //            shop.item[nextSlot].shopCustomPrice = 1200;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2543);
        //            shop.item[nextSlot].shopCustomPrice = 1200;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2558);
        //            shop.item[nextSlot].shopCustomPrice = 1200;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2573);
        //            shop.item[nextSlot].shopCustomPrice = 1200;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2652);
        //            shop.item[nextSlot].shopCustomPrice = 1200;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2653);
        //            shop.item[nextSlot].shopCustomPrice = 1200;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2654);
        //            shop.item[nextSlot].shopCustomPrice = 1200;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2655);
        //            shop.item[nextSlot].shopCustomPrice = 1200;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2656);
        //            shop.item[nextSlot].shopCustomPrice = 1200;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2657);
        //            shop.item[nextSlot].shopCustomPrice = 1200;
        //            nextSlot++;
        //            if (NPC.downedMartians)
        //            {
        //                shop.item[nextSlot].SetDefaults(2813);
        //                shop.item[nextSlot].shopCustomPrice = 1200;
        //                nextSlot++;
        //            }
        //            shop.item[nextSlot].SetDefaults(3177);
        //            shop.item[nextSlot].shopCustomPrice = 1200;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(3178);
        //            shop.item[nextSlot].shopCustomPrice = 1200;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(3179);
        //            shop.item[nextSlot].shopCustomPrice = 1200;
        //            nextSlot++;
        //            if (Main.hardMode)
        //            {
        //                shop.item[nextSlot].SetDefaults(3894);
        //                shop.item[nextSlot].shopCustomPrice = 1200;
        //                nextSlot++;
        //            }
        //        }
        //        if (Shop10)
        //        {
        //            shop.item[nextSlot].SetDefaults(349);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(714);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2092);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2093);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2094);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2095);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2096);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2097);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2098);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            if (Main.hardMode)
        //            {
        //                shop.item[nextSlot].SetDefaults(2099);
        //                shop.item[nextSlot].shopCustomPrice = 500;
        //                nextSlot++;
        //            }
        //            shop.item[nextSlot].SetDefaults(2100);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2101);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2102);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2103);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2149);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2150);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2151);
        //            shop.item[nextSlot].shopCustomPrice = 30000;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2152);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2227);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2522);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2541);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2555);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2570);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2664);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2665);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2666);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2667);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2668);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            if (NPC.downedMartians)
        //            {
        //                shop.item[nextSlot].SetDefaults(2825);
        //                shop.item[nextSlot].shopCustomPrice = 500;
        //                nextSlot++;
        //            }
        //            shop.item[nextSlot].SetDefaults(3168);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(3169);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(3170);
        //            shop.item[nextSlot].shopCustomPrice = 500;
        //            nextSlot++;
        //            if (Main.hardMode)
        //            {
        //                shop.item[nextSlot].SetDefaults(3893);
        //                shop.item[nextSlot].shopCustomPrice = 500;
        //                nextSlot++;
        //            }
        //        }
        //    }
    }
}
