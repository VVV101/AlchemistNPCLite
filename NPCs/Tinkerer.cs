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
    public class Tinkerer : ModNPC
    {
        public static string Shop1 = "MovementMisc";
        public static string Shop2 = "Combat";
        public override string Texture
        {
            get
            {
                return "AlchemistNPCLite/NPCs/Tinkerer";
            }
        }
        //Possibly Removed
        // public override bool Autoload(ref string name)
        // {
        // 	name = "Tinkerer";
        // 	return AlchemistNPCLite.modConfiguration.TinkererSpawn;
        // }

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 25;
            NPCID.Sets.AttackFrameCount[NPC.type] = 4;
            NPCID.Sets.DangerDetectRange[NPC.type] = 500;
            NPCID.Sets.AttackType[NPC.type] = 1;
            NPCID.Sets.AttackTime[NPC.type] = 20;
            NPCID.Sets.AttackAverageChance[NPC.type] = 30;
            NPCID.Sets.HatOffsetY[NPC.type] = -4;

            NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            {
                Velocity = -1f,
                Direction = -1
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);

            NPC.Happiness.SetBiomeAffection<UndergroundBiome>(AffectionLevel.Like);
            NPC.Happiness.SetBiomeAffection<SnowBiome>(AffectionLevel.Love);
            NPC.Happiness.SetBiomeAffection<DesertBiome>(AffectionLevel.Dislike);

            NPC.Happiness.SetNPCAffection(NPCID.Steampunker, AffectionLevel.Love);
            NPC.Happiness.SetNPCAffection(NPCID.Mechanic, AffectionLevel.Like);
            NPC.Happiness.SetNPCAffection(NPCID.DyeTrader, AffectionLevel.Dislike);
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Snow,
                new FlavorTextBestiaryInfoElement("Mods.AlchemistNPCLite.Bestiary.Tinkerer")
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
            NPC.defense = 40;
            NPC.lifeMax = 250;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.5f;
            AnimationType = NPCID.Merchant;
        }

        public override bool CanTownNPCSpawn(int numTownNPCs)/* tModPorter Suggestion: Copy the implementation of NPC.SpawnAllowed_Merchant in vanilla if you to count money, and be sure to set a flag when unlocked, so you don't count every tick. */
        {
            if (NPC.downedBoss1) { return AlchemistNPCLite.modConfiguration.TinkererSpawn; }
            return false;
        }


        public override List<string> SetNPCNameList()
        {
            string Alexander = Language.GetTextValue("Mods.AlchemistNPCLite.Alexander");
            string Peter = Language.GetTextValue("Mods.AlchemistNPCLite.Peter");

            return new List<string>() {
                Alexander,
                Peter
            };
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = 20;
            knockback = 4f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 10;
            randExtraCooldown = 5;
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            projType = 14;
            attackDelay = 5;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 16f;
        }

        public override void DrawTownAttackGun(ref Texture2D item, ref Rectangle itemFrame, ref float scale, ref int horizontalHoldoutOffset)/* tModPorter Note: closeness is now horizontalHoldoutOffset, use 'horizontalHoldoutOffset = Main.DrawPlayerItemPos(1f, itemtype) - originalClosenessValue' to adjust to the change. See docs for how to use hook with an item type. */ //Allows you to customize how this town NPC's weapon is drawn when this NPC is shooting (this NPC must have an attack type of 1). Scale is a multiplier for the item's drawing size, item is the ID of the item to be drawn, and closeness is how close the item should be drawn to the NPC.
        {
            scale = 1f;
            horizontalHoldoutOffset = 2;
            item = TextureAssets.Item[95].Value;
        }


        public override string GetChat()
        {                                           //npc chat
            string EntryT1 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryT1");
            string EntryT2 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryT2");
            string EntryT3 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryT3");
            string EntryT4 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryT4");
            string EntryT5 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryT5");
            switch (Main.rand.Next(5))
            {
                case 0:
                    return EntryT1;
                case 1:
                    return EntryT2;
                case 2:
                    return EntryT3;
                case 3:
                    return EntryT4;
                default:
                    return EntryT5;
            }
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = Language.GetTextValue("Mods.AlchemistNPCLite.TinkererButton1");
            button2 = Language.GetTextValue("Mods.AlchemistNPCLite.TinkererButton2");
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
            var shop = new NPCShop(Type, Shop1)
                .Add(new Item(ItemID.Aglet) { shopCustomPrice = 20000 })
                .Add(new Item(ItemID.AnkletoftheWind) { shopCustomPrice = 50000 },
                    Condition.DownedQueenBee)
                .Add(new Item(ItemID.ClimbingClaws) { shopCustomPrice = 20000 })
                .Add(new Item(ItemID.ShoeSpikes) { shopCustomPrice = 30000 })
                .Add(new Item(ItemID.HermesBoots) { shopCustomPrice = 50000 })
                .Add(new Item(ItemID.WaterWalkingBoots) { shopCustomPrice = 50000 })
                .Add(new Item(ItemID.FlowerBoots) { shopCustomPrice = 50000 },
                    Condition.DownedQueenBee)
                .Add(new Item(ItemID.IceSkates) { shopCustomPrice = 50000 })
                .Add(new Item(ItemID.FlyingCarpet) { shopCustomPrice = 150000 },
                    Condition.DownedSkeletron)
                .Add(new Item(ItemID.Tabi) { shopCustomPrice = 250000 },
                    Condition.DownedGolem)
                .Add(new Item(ItemID.FrogLeg) { shopCustomPrice = 50000 },
                    Condition.DownedSkeletron)
                .Add(new Item(ItemID.JellyfishNecklace) { shopCustomPrice = 30000 },
                    Condition.DownedEowOrBoc)
                .Add(new Item(ItemID.Flipper) { shopCustomPrice = 50000 })
                .Add(new Item(ItemID.DivingHelmet) { shopCustomPrice = 250000 })
                .Add(new Item(ItemID.NeptunesShell) { shopCustomPrice = 250000 },
                    new Condition("", () => NPC.downedPlantBoss))
                .Add(new Item(ItemID.LuckyHorseshoe) { shopCustomPrice = 50000 })
                .Add(new Item(ItemID.ShinyRedBalloon) { shopCustomPrice = 50000 })
                .Add(new Item(ItemID.CloudinaBottle) { shopCustomPrice = 30000 })
                .Add(new Item(ItemID.BlizzardinaBottle) { shopCustomPrice = 40000 },
                    Condition.DownedEowOrBoc)
                .Add(new Item(ItemID.SandstorminaBottle) { shopCustomPrice = 50000 },
                    Condition.DownedSkeletron)
                .Add(new Item(ItemID.BalloonPufferfish) { shopCustomPrice = 50000 },
                    Condition.DownedEowOrBoc)
                .Add(new Item(ItemID.TsunamiInABottle) { shopCustomPrice = 50000 },
                    Condition.DownedEowOrBoc)
                .Add(new Item(ItemID.LavaCharm) { shopCustomPrice = 50000 },
                    Condition.DownedSkeletron)
                .Add(new Item(ItemID.FlameWakerBoots) { shopCustomPrice = 50000 },
                    Condition.DownedSkeletron)
                .Add(new Item(ItemID.CelestialMagnet) { shopCustomPrice = 200000 },
                    Condition.Hardmode)
                .Add(new Item(ItemID.PhilosophersStone) { shopCustomPrice = 250000 },
                    Condition.DownedMechBossAny)
                .Add(new Item(ItemID.HighTestFishingLine) { shopCustomPrice = 100000 },
                    Condition.DownedEowOrBoc)
                .Add(new Item(ItemID.AnglerEarring) { shopCustomPrice = 100000 },
                    Condition.DownedEowOrBoc)
                .Add(new Item(ItemID.TackleBox) { shopCustomPrice = 100000 },
                    Condition.DownedEowOrBoc)
                .Add(new Item(ItemID.GoldRing) { shopCustomPrice = 330000 },
                    Condition.DownedMechBossAny)
                .Add(new Item(ItemID.LuckyCoin) { shopCustomPrice = 330000 },
                    Condition.DownedMechBossAny)
                .Add(new Item(ItemID.DiscountCard) { shopCustomPrice = 330000 },
                    Condition.DownedMechBossAny);
            shop.Register();

            shop = new NPCShop(Type, Shop2)
                .Add(new Item(ItemID.WhiteString) { shopCustomPrice = 30000 })
                .Add(new Item(ItemID.GreenCounterweight) { shopCustomPrice = 50000 }, Condition.DownedEowOrBoc)
                .Add(new Item(ItemID.YoYoGlove) { shopCustomPrice = 500000 }, Condition.Hardmode)
                .Add(new Item(ItemID.Blindfold) { shopCustomPrice = 50000 }, Condition.DownedMechBossAll)
                .Add(new Item(ItemID.PocketMirror) { shopCustomPrice = 50000 }, Condition.DownedMechBossAll)
                .Add(new Item(ItemID.ArmorPolish) { shopCustomPrice = 50000 }, Condition.DownedMechBossAll)
                .Add(new Item(ItemID.Vitamins) { shopCustomPrice = 50000 }, Condition.DownedMechBossAll)
                .Add(new Item(ItemID.Bezoar) { shopCustomPrice = 50000 }, Condition.DownedMechBossAll)
                .Add(new Item(ItemID.AdhesiveBandage) { shopCustomPrice = 50000 }, Condition.DownedMechBossAll)
                .Add(new Item(ItemID.FastClock) { shopCustomPrice = 50000 }, Condition.DownedMechBossAll)
                .Add(new Item(ItemID.TrifoldMap) { shopCustomPrice = 50000 }, Condition.DownedMechBossAll)
                .Add(new Item(ItemID.Megaphone) { shopCustomPrice = 50000 }, Condition.DownedMechBossAll)
                .Add(new Item(ItemID.Nazar) { shopCustomPrice = 50000 }, Condition.DownedMechBossAll)
                .Add(new Item(ItemID.SorcererEmblem) { shopCustomPrice = 250000 }, Condition.DownedMechBossAll)
                .Add(new Item(ItemID.WarriorEmblem) { shopCustomPrice = 250000 }, Condition.DownedMechBossAll)
                .Add(new Item(ItemID.RangerEmblem) { shopCustomPrice = 250000 }, Condition.DownedMechBossAll)
                .Add(new Item(ItemID.SummonerEmblem) { shopCustomPrice = 250000 }, Condition.DownedMechBossAll)
                .Add(new Item(ItemID.FeralClaws) { shopCustomPrice = 150000 }, Condition.DownedQueenBee)
                .Add(new Item(ItemID.TitanGlove) { shopCustomPrice = 250000 }, Condition.Hardmode)
                .Add(new Item(ItemID.MagmaStone) { shopCustomPrice = 150000 }, Condition.Hardmode)
                .Add(new Item(ItemID.SharkToothNecklace) { shopCustomPrice = 100000 }, Condition.DownedEowOrBoc)
                .Add(new Item(ItemID.BlackBelt) { shopCustomPrice = 250000 }, Condition.DownedGolem)
                .Add(new Item(ItemID.MoonCharm) { shopCustomPrice = 300000 }, Condition.DownedMechBossAny)
                .Add(new Item(ItemID.SunStone) { shopCustomPrice = 350000 }, Condition.DownedGolem)
                .Add(new Item(ItemID.MoonStone) { shopCustomPrice = 350000 }, Condition.DownedGolem)
                .Add(new Item(ItemID.RifleScope) { shopCustomPrice = 250000 }, Condition.DownedGolem)
                .Add(new Item(ItemID.CobaltShield) { shopCustomPrice = 100000 }, Condition.Hardmode)
                .Add(new Item(ItemID.PaladinsShield) { shopCustomPrice = 150000 }, Condition.DownedGolem)
                .Add(new Item(ItemID.PaladinsShield) { shopCustomPrice = 150000 }, Condition.DownedGolem)
                .Add(new Item(ItemID.FrozenTurtleShell) { shopCustomPrice = 350000 }, Condition.DownedMechBossAny)
                .Add(new Item(ItemID.PutridScent) { shopCustomPrice = 250000 }, Condition.DownedMechBossAny)
                .Add(new Item(ItemID.FleshKnuckles) { shopCustomPrice = 250000 }, Condition.DownedMechBossAny)
                .Add(new Item(ItemID.MagicQuiver) { shopCustomPrice = 200000 }, Condition.DownedMechBossAny)
                .Add(new Item(ItemID.PanicNecklace) { shopCustomPrice = 50000 }, Condition.DownedEowOrBoc)
                .Add(new Item(ItemID.CrossNecklace) { shopCustomPrice = 100000 }, Condition.DownedMechBossAny)
                .Add(new Item(ItemID.StarCloak) { shopCustomPrice = 150000 }, Condition.DownedMechBossAny)
                .Add(new Item(ItemID.ObsidianRose) { shopCustomPrice = 150000 }, Condition.DownedSkeletron)
                .Add(new Item(ItemID.Shackle) { shopCustomPrice = 30000 })
                .Add(new Item(ItemID.HerculesBeetle) { shopCustomPrice = 330000 }, Condition.DownedGolem)
                .Add(new Item(ItemID.PygmyNecklace) { shopCustomPrice = 330000 }, Condition.DownedGolem)
                .Add(new Item(ItemID.NecromanticScroll) { shopCustomPrice = 330000 }, Condition.DownedGolem);
            shop.Register();
        }
    }
}
