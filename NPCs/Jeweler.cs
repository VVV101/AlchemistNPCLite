using System;
using Microsoft.Xna.Framework;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using System.Collections.Generic;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.Personalities;

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
        public override string Texture
        {
            get
            {
                return "AlchemistNPCLite/NPCs/Jeweler";
            }
        }
        // Probably Removed
        // public override bool Autoload(ref string name)
        // {
        // 	name = "Jeweler";
        // 	return true;
        // }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Jeweler");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Ювелир");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "珠宝师");
            Main.npcFrameCount[NPC.type] = 25;
            NPCID.Sets.AttackFrameCount[NPC.type] = 4;
            NPCID.Sets.DangerDetectRange[NPC.type] = 500;
            NPCID.Sets.AttackType[NPC.type] = 0;
            NPCID.Sets.AttackTime[NPC.type] = 45;
            NPCID.Sets.AttackAverageChance[NPC.type] = 30;
            NPCID.Sets.HatOffsetY[NPC.type] = -2;

            ModTranslation text = LocalizationLoader.CreateTranslation(Mod, "ArenaShop");
            text.SetDefault("Arena Shop");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Магазин Арены");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "阿瑞娜商店");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "Carl");
            text.SetDefault("Carl");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Карл");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "John");
            text.SetDefault("John");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Джон");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "JanMare");
            text.SetDefault("JanMare");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Жан-Маре");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "LuiFransua");
            text.SetDefault("LuiFransua");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Луи-Франсуа");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "Daniel");
            text.SetDefault("Daniel");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Дэниел");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "Charley");
            text.SetDefault("Charley");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Чарли");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryJ1");
            text.SetDefault("I found some gems for selling. Would you check them?");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Я собрал немного драгоценных камней на продажу. Посмотришь?");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "我找到一些珠宝, 你想看看吗?");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryJ2");
            text.SetDefault("Magic rings are not as powerful as Legendary Emblems, but still can give you some advantage against powerful creatures.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Волшебные кольца не так могущественны, как Легендарные Эмблемы, но всё ещё могут дать преимущество против могущественных созданий.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "魔法戒指并不像传说中的那样强大,但它仍然能给你对抗强大生物的力量");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryJ3");
            text.SetDefault("Ouch... what do you want, my friend?");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Ай... Чего желаешь, мой друг?");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "呦... 你想要什么,我的朋友?");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryJ4");
            text.SetDefault("I can make a Diamond Ring for you.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Я могу сделать для тебя Бриллиантовое Кольцо.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "我可以为你做钻石戒指.");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryJ5");
            text.SetDefault("No, don't think that I somehow related to Skeleton Merchant.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Нет, я не думаю что хоть как-то связан со Скелетом-торговцем.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "不,不要认为我和骷髅商人有关系.");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryJ6");
            text.SetDefault("If you somehow find all Magic Rings,then you could make the Omniring.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Если ты каким-то образом соберёшь все Магические кольца, то ты сможешь сделать Единое Кольцо.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "如果你找到了所有的魔法戒指,你可以制造欧姆尼戒指.");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryJ7");
            text.SetDefault("Have you seen Mechanical Creatures?");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Ты видел где-нибудь Механических Созданий?");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "你在周围看到机械生物了吗?");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryJ8");
            text.SetDefault("Did you notice that ");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Ты замечал, что ");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "你有没有注意到到我和 ");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryJ9");
            text.SetDefault(" and I looks almost the same? It's because we're twin brothers.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), " и я очень похожи? Это потому что мы близнецы.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), " 长得几乎一毛一样?这是因为我们是兄弟.");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryJ10");
            text.SetDefault("Should you find enought of those torn notes, bring the to me and ill decipher them for you. Dont ask me why, just know that they hold a value for me.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Как только найдёшь достаточно изорванных записок, неси их мне и я расшифрую их для тебя. Не спрашивай зачем, просто знай, что они имеют значение для меня.");
            LocalizationLoader.AddTranslation(text);
			
			NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            {
                Velocity = -1f,
                Direction = -1
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);

            NPC.Happiness.SetBiomeAffection<JungleBiome>(AffectionLevel.Like);
            NPC.Happiness.SetBiomeAffection<ForestBiome>(AffectionLevel.Love);
            NPC.Happiness.SetBiomeAffection<SnowBiome>(AffectionLevel.Dislike);

            NPC.Happiness.SetNPCAffection(NPCID.Merchant,AffectionLevel.Love);
            NPC.Happiness.SetNPCAffection(NPCID.TaxCollector,AffectionLevel.Like);
            NPC.Happiness.SetNPCAffection(NPCID.PartyGirl,AffectionLevel.Dislike);
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

        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
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
			// IMPLEMENT WHEN WEAKREFERENCES FIXED
			/*
            if (ModLoader.GetMod("ThoriumMod") != null)
            {
            	switch (Main.rand.Next(2))
            	{
					case 0:
					return EntryJ2;
					case 1:
					return EntryJ6;
            	}
            } 
			*/
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

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (firstButton)
            {
                OH = true;
                AS = false;
                shop = true;
            }
            else
            {
                OH = false;
                AS = true;
                shop = true;
            }
        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            if (OH)
            {
                shop.item[nextSlot].SetDefaults(ItemID.Amethyst);
                shop.item[nextSlot].shopCustomPrice = 1000;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.Topaz);
                shop.item[nextSlot].shopCustomPrice = 1000;
                nextSlot++;
                if (NPC.downedBoss2)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.Sapphire);
                    shop.item[nextSlot].shopCustomPrice = 3000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.Emerald);
                    shop.item[nextSlot].shopCustomPrice = 3000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.Amber);
                    shop.item[nextSlot].shopCustomPrice = 5000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.FossilOre);
                    shop.item[nextSlot].shopCustomPrice = 5000;
                    nextSlot++;
					// IMPLEMENT WHEN WEAKREFERENCES FIXED
					/*
                    if (ModLoader.GetMod("ThoriumMod") != null)
                    {
                    	addModItemToShop(ThoriumMod, "Opal", 5000, ref shop, ref nextSlot);
                    	addModItemToShop(ThoriumMod, "Onyx", 5000, ref shop, ref nextSlot);	
                    }
					*/
                    shop.item[nextSlot].SetDefaults(ItemID.BandofStarpower);
                    shop.item[nextSlot].shopCustomPrice = 30000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.BandofRegeneration);
                    shop.item[nextSlot].shopCustomPrice = 50000;
                    nextSlot++;
                    if (Main.netMode == 1 || Main.netMode == 2)
                    {
                        shop.item[nextSlot].SetDefaults(ItemID.LifeCrystal);
                        shop.item[nextSlot].shopCustomPrice = 100000;
                        nextSlot++;
                        if (NPC.downedGolemBoss)
                        {
                            shop.item[nextSlot].SetDefaults(ItemID.LifeFruit);
                            shop.item[nextSlot].shopCustomPrice = 200000;
                            nextSlot++;
                        }
                    }
                }
                if (NPC.downedBoss3)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.Ruby);
                    shop.item[nextSlot].shopCustomPrice = 7500;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.Diamond);
                    shop.item[nextSlot].shopCustomPrice = 7500;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.DiamondRing);
                    shop.item[nextSlot].shopCustomPrice = 2000000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Summoning.HorrifyingSkull>());
                    shop.item[nextSlot].shopCustomPrice = 250000;
                    nextSlot++;
                    // IMPLEMENT WHEN WEAKREFERENCES FIXED
                    /*
                    if (ModLoader.GetMod("Tremor") != null)
                    {
                        addModItemToShop(Tremor, "Rupicide", 5000, ref shop, ref nextSlot);
                        addModItemToShop(Tremor, "Opal", 30000, ref shop, ref nextSlot);
                        if (Main.hardMode)
                        {
                            addModItemToShop(Tremor, "MagiumShard", 7500, ref shop, ref nextSlot);
                            addModItemToShop(Tremor, "RuneBar", 7500, ref shop, ref nextSlot);
                        }
                        if (NPC.downedMoonlord)
                        {
                            addModItemToShop(Tremor, "LapisLazuli", 150000, ref shop, ref nextSlot);
                        }
                    }
                    if (ModLoader.GetMod("ThoriumMod") != null)
                    {
                        addModItemToShop(ThoriumMod, "GraniteEnergyCore", 10000, ref shop, ref nextSlot);
                        addModItemToShop(ThoriumMod, "BronzeFragments", 10000, ref shop, ref nextSlot);
                    }
                    if (ModLoader.GetMod("SpiritMod") != null)
                    {
                        addModItemToShop(SpiritMod, "GraniteChunk", 10000, ref shop, ref nextSlot);
                        addModItemToShop(SpiritMod, "MarbleChunk", 10000, ref shop, ref nextSlot);
                    }
                    */
                    if (Main.hardMode)
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Summoning.AlchemistHorcrux>());
                        shop.item[nextSlot].shopCustomPrice = 150000;
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Summoning.BrewerHorcrux>());
                        shop.item[nextSlot].shopCustomPrice = 150000;
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Summoning.JewelerHorcrux>());
                        shop.item[nextSlot].shopCustomPrice = 150000;
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Summoning.ArchitectHorcrux>());
                        shop.item[nextSlot].shopCustomPrice = 150000;
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Summoning.TinkererHorcrux>());
                        shop.item[nextSlot].shopCustomPrice = 150000;
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Summoning.MusicianHorcrux>());
                        shop.item[nextSlot].shopCustomPrice = 150000;
                        nextSlot++;
                    }
                }
            }
            if (AS)
            {
                shop.item[nextSlot].SetDefaults(ItemID.Campfire);
                shop.item[nextSlot].shopCustomPrice = 5000;
                nextSlot++;
                if (NPC.downedBoss2)
                {
                    // IMPLEMENT WHEN WEAKREFERENCES FIXED
					/*
                    if (ModLoader.GetMod("ThoriumMod") != null)
                    {
                        addModItemToShop(ThoriumMod, "Mistletoe", 50000, ref shop, ref nextSlot);
                    }
					*/
					shop.item[nextSlot].SetDefaults(ItemID.SliceOfCake);
                    shop.item[nextSlot].shopCustomPrice = 100000;
                    nextSlot++;
                }
                if (NPC.downedBoss3)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.WaterBucket);
                    shop.item[nextSlot].shopCustomPrice = 15000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.HoneyBucket);
                    shop.item[nextSlot].shopCustomPrice = 30000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.LavaBucket);
                    shop.item[nextSlot].shopCustomPrice = 50000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.HeartLantern);
                    shop.item[nextSlot].shopCustomPrice = 30000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.StarinaBottle);
                    shop.item[nextSlot].shopCustomPrice = 10000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.WaterCandle);
                    shop.item[nextSlot].shopCustomPrice = 30000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.PeaceCandle);
                    shop.item[nextSlot].shopCustomPrice = 50000;
                    nextSlot++;
                    if (ModLoader.TryGetMod("CalamityMod", out Mod Calamity))
                    {
                    	if (NPC.downedPlantBoss)
                    	{
                            addModItemToShop(Calamity, "TranquilityCandle", 100000, ref shop, ref nextSlot);
                            addModItemToShop(Calamity, "ChaosCandle", 150000, ref shop, ref nextSlot);
                    	}
                    }
                    shop.item[nextSlot].SetDefaults(ItemID.Spike);
                    shop.item[nextSlot].shopCustomPrice = 10000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.DartTrap);
                    shop.item[nextSlot].shopCustomPrice = 30000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.GeyserTrap);
                    shop.item[nextSlot].shopCustomPrice = 100000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.CatBast);
                    shop.item[nextSlot].shopCustomPrice = 100000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.SharpeningStation);
                    shop.item[nextSlot].shopCustomPrice = 150000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.BewitchingTable);
                    shop.item[nextSlot].shopCustomPrice = 150000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.AmmoBox);
                    shop.item[nextSlot].shopCustomPrice = 250000;
                    nextSlot++;
                    if (Main.hardMode)
                    {
                        shop.item[nextSlot].SetDefaults(ItemID.CrystalBall);
                        shop.item[nextSlot].shopCustomPrice = 150000;
                        nextSlot++;
						shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.UltimaCake>());
                        shop.item[nextSlot].shopCustomPrice = 5000000;
                        nextSlot++;
                    }
                    if (NPC.downedGolemBoss)
                    {
                        shop.item[nextSlot].SetDefaults(ItemID.WoodenSpike);
                        shop.item[nextSlot].shopCustomPrice = 20000;
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(ItemID.SpearTrap);
                        shop.item[nextSlot].shopCustomPrice = 50000;
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(ItemID.SpikyBallTrap);
                        shop.item[nextSlot].shopCustomPrice = 50000;
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(ItemID.SuperDartTrap);
                        shop.item[nextSlot].shopCustomPrice = 750000;
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(ItemID.FlameTrap);
                        shop.item[nextSlot].shopCustomPrice = 100000;
                        nextSlot++;
                    }
                }
            }
        }
                private void addModItemToShop(Mod mod, String itemName, int price, ref Chest shop, ref int nextSlot) {
            if(mod.TryFind<ModItem>(itemName, out ModItem currItem)) {
                shop.item[nextSlot].SetDefaults(currItem.Type);
                shop.item[nextSlot].shopCustomPrice = price;
                nextSlot++;
            }
        }
    }
}
