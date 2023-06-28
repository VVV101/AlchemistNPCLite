using System;
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
        public static bool Shop1 = true;
        public static bool Shop2 = false;
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
            DisplayName.SetDefault("Young Brewer");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Юный зельевар");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "年轻药剂师");
            Main.npcFrameCount[NPC.type] = 23;
            NPCID.Sets.AttackFrameCount[NPC.type] = 4;
            NPCID.Sets.DangerDetectRange[NPC.type] = 500;
            NPCID.Sets.AttackType[NPC.type] = 0;
            NPCID.Sets.AttackTime[NPC.type] = 20;
            NPCID.Sets.AttackAverageChance[NPC.type] = 30;
            NPCID.Sets.HatOffsetY[NPC.type] = 2;

            ModTranslation text = LocalizationLoader.CreateTranslation(Mod, "Harold");
            text.SetDefault("Harold");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Гарольд");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "Charles");
            text.SetDefault("Charles");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Чарльз");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "Monty");
            text.SetDefault("Monty");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Монти");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "Lucas");
            text.SetDefault("Lucas");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Лукас");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "Porky");
            text.SetDefault("Porky");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Порки");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "Leeland");
            text.SetDefault("Leeland");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Леланд");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "Atreus");
            text.SetDefault("Atreus");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Атреус");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "Entry1");
            text.SetDefault("I'm trading potions which were made by my parents.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Я продаю зелья, сделанные моими родителями.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "我出售我父母做的药剂.");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "Entry2");
            text.SetDefault("I have some potions I can sell to you.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "У есть несколько зелий, которые я могу продать тебе.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "我有一些药水可以卖给你");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "Entry3");
            text.SetDefault("Although, the Battle Combination was my idea.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Так или иначе, это я придумал Боевую Комбинацию.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "战斗药剂包是我的主意.");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "Entry4");
            text.SetDefault("There's a legendary yoyo known as the Sasscade.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Существует Легендарное Йо-йо, известное как Сасскад.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "有一个传说中的溜溜球被称为Sasscadee.");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "Entry5");
            text.SetDefault("Strange Brew from Skeleton Merchant smells really terrible, but Mana Restoration effect is awesome.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Странное варево от Торговца-Скелета пахнет просто ужасно, но оно потрясающе восстанавливает ману.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "来自骷髅商人的奇异啤酒气味真的很糟糕，但法力恢复效果是可怕的.");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "Entry6");
            text.SetDefault("Hi, *cough*.. That definetly wasn't a lemonade.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Привет, *кашель*.. Это определённо был не лимонад.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "嗨, *咳咳*.. 那绝对不是柠檬茶.");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "Entry7");
            text.SetDefault("Have you seen a Mechanical Worm around?");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Ты не видел Механического Червя поблизости?");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "你有在附近见到钢铁破坏者吗?");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "Entry8");
            text.SetDefault("My mom, ");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Разве моя мама, ");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "我妈妈, ");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "Entry9");
            text.SetDefault(", is the coolest brewer ever, isn't she? She can brew the hardest potions with ease.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), ", не самая лучшая Зельеварщица на свете? Она может сварить любые сложнейшие зелья с лёгкостью!");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), " , 是最酷的药剂师, 不是吗? 她可以轻松酿造出难做的药剂.");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "Entry10");
            text.SetDefault("Certain combinations can only be brewed if certain types of magic are present in the world.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Некоторые комбинации могут быть изготовлены только если в мире присутсвуют особенные виды магии.");
            LocalizationLoader.AddTranslation(text);
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

        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
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

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (firstButton)
            {
                Shop1 = true;
                Shop2 = false;
                shop = true;
            }
            else
            {
                Shop2 = true;
                Shop1 = false;
                shop = true;
            }
        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            if (Shop1)
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.VanTankCombination>());
                shop.item[nextSlot].shopCustomPrice = 90000;
                nextSlot++;
                if (Main.hardMode)
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.TankCombination>());
                    shop.item[nextSlot].shopCustomPrice = 160000;
                    nextSlot++;
                }
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.BattleCombination>());
                shop.item[nextSlot].shopCustomPrice = 120000;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.RangerCombination>());
                shop.item[nextSlot].shopCustomPrice = 75000;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.MageCombination>());
                shop.item[nextSlot].shopCustomPrice = 90000;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.BuilderCombination>());
                shop.item[nextSlot].shopCustomPrice = 35000;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.ExplorerCombination>());
                shop.item[nextSlot].shopCustomPrice = 80000;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.SummonerCombination>());
                shop.item[nextSlot].shopCustomPrice = 30000;
                nextSlot++;
                if (Main.player[Main.myPlayer].anglerQuestsFinished >= 5)
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.FishingCombination>());
                    shop.item[nextSlot].shopCustomPrice = 100000;
                    nextSlot++;
                }
                if (ModLoader.GetMod("ThoriumMod") != null)
                {
                    if (NPC.downedMechBossAny)
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.ThoriumCombination>());
                        shop.item[nextSlot].shopCustomPrice = 250000;
                        nextSlot++;
                    }
                }
                if (ModLoader.TryGetMod("CalamityMod", out Mod Calamity))
                {
                    if (NPC.downedGolemBoss)
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.CalamityCombination>());
                        shop.item[nextSlot].shopCustomPrice = 200000;
                        nextSlot++;
                    }
                }
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
                if (ModLoader.GetMod("SpiritMod") != null)
                {
                    if (NPC.downedMechBossAny)
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.SpiritCombination>());
                        shop.item[nextSlot].shopCustomPrice = 250000;
                        nextSlot++;
                    }
                }
				*/
                if (NPC.downedMoonlord)
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.UniversalCombination>());
                    shop.item[nextSlot].shopCustomPrice = 500000;
                    nextSlot++;
                }

                // IMPLEMENT WHEN WEAKREFERENCES FIXED
                /*
                if (ModLoader.GetMod("ThoriumMod") != null)
                {
                    if (NPC.downedBoss3)
                    {
                        addModItemToShop(ThoriumMod, "FrostCoatingItem", 5000, ref shop, ref nextSlot);addModItemToShop(ThoriumMod, "FrostCoatingItem", 5000, ref shop, ref nextSlot);extSlot].shopCustomPrice =addModItemToShop(ThoriumMod, "FrostCoatingItem", 5000, ref shop, ref nextSlot);extSlot].SetDefaults(ModLoaddModItemToShop(ThoriumMod, "FrostCoatingItem", 5000, ref shop, ref nextSlot);addModItemToShop(ThoriumMod, "FrostCoatingItem", 5000, ref shop, ref nextSlot);extSlot].shopCustomPrice = 2500;
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(ModLoader.GetMod("ThoriumMod").ItemType("ToxicCoatingItem"));
                        shop.item[nextSlot].shopCustomPrice = 2500;
                        nextSlot++;
                    }
                    if (Main.hardMode)
                    {
                        addModItemToShop(ThoriumMod, "GasContainer", 200, ref shop, ref nextSlot);addModItemToShop(ThoriumMod, "GasContainer", 200, ref shop, ref nextSlot);extSlot].shopCustomPrice =addModItemToShop(ThoriumMod, "GasContainer", 200, ref shop, ref nextSlot);extSlot].SetDefaults(ModLoaddModItemToShop(ThoriumMod, "GasContainer", 200, ref shop, ref nextSlot);addModItemToShop(ThoriumMod, "GasContainer", 200, ref shop, ref nextSlot);extSlot].shopCustomPrice = 250;
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(ModLoader.GetMod("ThoriumMod").ItemType("AphrodisiacVial"));
                        shop.item[nextSlot].shopCustomPrice = 250;
                        nextSlot++;
                        if (NPC.downedPlantBoss)
                        {
                            addModItemToShop(ThoriumMod, "PlasmaVial", 350, ref shop, ref nextSlot);
                        }
                    }
                }
				*/
            }
            if (Shop2)
            {
                if (NPC.downedQueenBee)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.FlaskofPoison);
                    shop.item[nextSlot].shopCustomPrice = 10000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.FlaskofFire);
                    shop.item[nextSlot].shopCustomPrice = 10000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.FlaskofParty);
                    shop.item[nextSlot].shopCustomPrice = 10000;
                    nextSlot++;
                }
                if (Main.hardMode)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.FlaskofGold);
                    shop.item[nextSlot].shopCustomPrice = 15000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.FlaskofIchor);
                    shop.item[nextSlot].shopCustomPrice = 25000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.FlaskofCursedFlames);
                    shop.item[nextSlot].shopCustomPrice = 25000;
                    nextSlot++;
                }
                if (NPC.downedPlantBoss)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.FlaskofVenom);
                    shop.item[nextSlot].shopCustomPrice = 30000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.FlaskofNanites);
                    shop.item[nextSlot].shopCustomPrice = 30000;
                    nextSlot++;
                }
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
                if (ModLoader.GetMod("SpiritMod") != null)
                {
                	if (Main.hardMode)
                	{
                		addModItemToShop(SpiritMod, "AcidVial", 30000, ref shop, ref nextSlot);
                	}
                }
				*/
				ModLoader.TryGetMod("CalamityMod", out Mod Calamity);
                if (Calamity != null)
                {
					if ((bool)Calamity.Call("Downed", "calamitas doppelganger"))
                    {
						addModItemToShop(Calamity, "FlaskOfBrimstone", 40000, ref shop, ref nextSlot);
					}
					if (NPC.downedMoonlord)
					{
						addModItemToShop(Calamity, "FlaskOfHolyFlames", 50000, ref shop, ref nextSlot);
					}
				}
            }
        }
        private void addModItemToShop(Mod mod, String itemName, int price, ref Chest shop, ref int nextSlot)
        {
            if (mod.TryFind<ModItem>(itemName, out ModItem currItem))
            {
                shop.item[nextSlot].SetDefaults(currItem.Type);
                shop.item[nextSlot].shopCustomPrice = price;
                nextSlot++;
            }
        }
    }
}
