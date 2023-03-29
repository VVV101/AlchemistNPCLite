using AlchemistNPCLite.Interface;
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
    public class Brewer : ModNPC
    {
        public static bool Shop1 = true;
        public static bool Shop2 = false;
        public static bool Shop21 = false;
        public static bool Shop3 = false;
        public static bool Shop4 = false;
        public static bool Shop5 = false;
        public override string Texture
        {
            get
            {
                return "AlchemistNPCLite/NPCs/Brewer";
            }
        }
        // Probably removed
        // public override bool Autoload(ref string name)
        // {
        // 	name = "Brewer";
        // 	return true;
        // }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Brewer");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Варщица Зелий");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "药剂师");
            Main.npcFrameCount[NPC.type] = 23;
            NPCID.Sets.AttackFrameCount[NPC.type] = 4;
            NPCID.Sets.DangerDetectRange[NPC.type] = 500;
            NPCID.Sets.AttackType[NPC.type] = 0;
            NPCID.Sets.AttackTime[NPC.type] = 45;
            NPCID.Sets.AttackAverageChance[NPC.type] = 30;
            NPCID.Sets.HatOffsetY[NPC.type] = -4;

            ModTranslation text = LocalizationLoader.CreateTranslation(Mod, "ShopB1");
            text.SetDefault("1st shop (Vanilla)");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "1-ый магазин (без модовых)");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "第一商店 (原版)              ");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "ShopB2");
            text.SetDefault("2nd shop (Mod/Calamity)");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "2-ой магазин (Mod/Calamity)");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "第二商店 (模组/灾厄)");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "ShopB21");
            text.SetDefault("3rd shop (Thorium/RG)");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "3-ий магазин (Thorium/RG)");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "第二商店 (瑟银/RG)");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "ShopB3");
            text.SetDefault("4th shop (MorePotions)              ");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "4-ый магазин (MorePotions)");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "第三商店 (更多药剂)         ");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "ShopB4");
            text.SetDefault("5th shop (UnuBattleRods/Tacklebox/Tremor) ");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "5-ый магазин (UnuBattleRods/Tacklebox/Tremor)");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "第四商店 (震颤/钓杆/钓具箱)");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "ShopB5");
            text.SetDefault("6th shop (Wildlife/Sacred/Spirit/Cristilium/ExpSentr)");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "6-ой магазин (Wildlife/Sacred/Spirit/Cristilium/ExpSentr)");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "第五商店 (Wildlife/圣域/魂灵/水晶之地/ExpSentr)");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "ShopsChanger");
            text.SetDefault("Shops Changer");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Смена магазина");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "切换商店");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "Lillian");
            text.SetDefault("Lillian");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Лилиан");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "Lucy");
            text.SetDefault("Lucy");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Люси");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "Alice");
            text.SetDefault("Alice");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Алиса");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "Rocksahn");
            text.SetDefault("Rocksahn");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Роксанна");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "Agness");
            text.SetDefault("Agness");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Агнесс");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "Mary");
            text.SetDefault("Mary");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Мария");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryB1");
            text.SetDefault("Care to try this potion? It's supposed to grant wings.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Хочешь попробовать это зелье? Оно должно дать тебе крылья.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "要试试这药水吗?它应该会强化翅膀.");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryB2");
            text.SetDefault("I don't think that was a Spelunker potion...");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Не думаю, что это было зелье Шахтера...");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "我不认为那是洞穴探险药水.");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryB3");
            text.SetDefault("I got my degrees in Riddle University.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Я получила своё образование в Университете Загадок.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "我得到了来自谜语大学的学位");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryB4");
            text.SetDefault("There's a legendary yoyo known as the Sasscade.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Существует Легендарное Йо-йо, известное как Сасскад.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "有一个传说中的溜溜球被称为Sasscadee.");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryB5");
            text.SetDefault("Aww, bread crumbs and beaver spit!");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Ох, хлебные крошки и слюни бобра!");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "哇哦，面包屑和海狸唾液!");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryB6");
            text.SetDefault("Hi, *cough* that wasn't an Inferno potion!");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Привет, *кашель* это точно не было зельем Инферно!");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "嗨, *咳咳* 那不是地狱降临药剂!");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryB7");
            text.SetDefault("Have you seen two mechanical eyes around?");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Ты не видел пару Механических Глаз поблизости?");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "你在周围看到双子魔眼了吗?");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryB8");
            text.SetDefault("That silly goose ");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Этот трусливый гусь ");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "那个愚蠢的 ");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryB9");
            text.SetDefault(" is too afraid of using occult powers in Alchemy. And so his potions are just some useless water.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), " слишком сильно боится использовать оккультизм в алхимии. И поэтому его зелья лишь бесполезная водичка.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), " 过于害怕在炼金术中使用神秘力量，所以他的药水只是一种没用的水.");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryB10");
            text.SetDefault("*sneezes* Eww... I always sneeze while these Goblins are around!");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "*чихает* Фуу... Я всегда чихаю, когда эти Гоблины поблизости!");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "*啊嚏* 噫... 那些哥布林在附近时我总是打喷嚏.");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryB11");
            text.SetDefault("Just don't let them in my house... There are so many needed supplies and instruments.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Просто не пускай их в мой дом. Там очень много нужных материалов и инструментов.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "别让他们进入我的房子...我这儿有那么多的物资和设备.");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryB12");
            text.SetDefault("Is this a Martians Invasion? Are they going to enslave us all? Or they want to destroy us all? No one knows the answer...");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Это вторжение Марсиан? Она пришли чтобы поработить нас всех? Или они хотят нас уничтожить? Никто не знает ответа...");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "这是一场外星入侵吗？他们会奴役我们所有人吗？亦或者毁灭我们？没人知道答案...");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryB13");
            text.SetDefault("Is it Blood Moon in the sky? I love it! It is so beautiful!");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Это Кровавая Луна в небесах? Восхитительно! Она так красива!");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "天上的那个是血月吗？我喜欢！它看起来好漂亮！");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryB14");
            text.SetDefault("I was born under the light of Blood Moon. I am always so excited when IT appears!");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Я была рождена под светом Кровавой Луны. Я всегда так взволнована когда ОНА восходит на небе!");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "我出生的时候正好是血月，每当它升起时我都会变得很兴奋！");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryB15");
            text.SetDefault("Yeah, I can understand why the other girls are annoyed, but that's not stopping me!");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Да, я понимаю, почему другие девушки раздражены, но это меня не остановит!");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "是的，我能理解为什么女孩们会生气，但这并不能阻止我的快乐!");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryB16");
            text.SetDefault("As happy as I am, I'm not giving discounts - I'm not dumb.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Насколько бы счастлива я не была, я не даю скидок - я ведь не глупая.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "和我一样开心, 我也不会给你打折的 - 我又不傻.");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryB17");
            text.SetDefault("Normally I'm confused with how ");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Обычно я бываю озадачена тем, как.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "通常我会很困惑为什么 ");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryB18");
            text.SetDefault(" is just as calm as I am, but then I remember ");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), " может быть так же спокойна, как я, но потом я вспоминаю ");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), " 和我一样从容冷静, 但是后来我想到了 ");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryB19");
            text.SetDefault("I once traveled far away from Terraria to learn more about Alchemy. In my travels I met a ''scientist of magic'' called Azanor. He showed me the secrets of something called ''thaumaturgy''.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Я однажды выбралась из мира Террарии чтобы узнать больше об Алхимии. В своих путешествиях я встретила ''учёного магии'' по имени Азанор. Он показал мне тайны чего-то, названного ''тауматургия''.");
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

        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
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
            string ShopB21 = Language.GetTextValue("Mods.AlchemistNPCLite.ShopB21");
            string ShopB3 = Language.GetTextValue("Mods.AlchemistNPCLite.ShopB3");
            string ShopB4 = Language.GetTextValue("Mods.AlchemistNPCLite.ShopB4");
            string ShopB5 = Language.GetTextValue("Mods.AlchemistNPCLite.ShopB5");
            string ShopsChanger = Language.GetTextValue("Mods.AlchemistNPCLite.ShopsChanger");
            if (Shop1)
            {
                button = ShopB1;
            }
            if (Shop2)
            {
                button = ShopB2;
            }
            if (Shop21)
            {
                button = ShopB21;
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
            if (NPC.FindBuffIndex(119) >= 0 && NPC.AnyNPCs(ModContent.NPCType<Alchemist>()) && !NPC.AnyNPCs(ModContent.NPCType<YoungBrewer>()))
            {
                button2 = "???";
            }
            else
            {
                button2 = ShopsChanger;
            }
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (firstButton)
            {
                shop = true;
                ShopChangeUI.visible = false;
            }
            else
            {
                if (NPC.HasBuff(119) && NPC.AnyNPCs(ModContent.NPCType<Alchemist>()) && !NPC.AnyNPCs(ModContent.NPCType<YoungBrewer>()))
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

        // IMPLEMENT WHEN WEAKREFERENCES FIXED
        /*
        public bool SacredToolsDownedAbaddon
        {
        	get { return SacredTools.ModdedWorld.OblivionSpawns; }
        }

        public bool SacredToolsDownedSerpent
        {
        	get { return SacredTools.ModdedWorld.FlariumSpawns; }
        }

        public bool SacredToolsDownedLunarians
        {
        	get { return SacredTools.ModdedWorld.downedLunarians; }
        }
		*/
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

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            if (Shop1)
            {
                shop.item[nextSlot].SetDefaults(ItemID.SwiftnessPotion);
                shop.item[nextSlot].shopCustomPrice = 5000;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.IronskinPotion);
                shop.item[nextSlot].shopCustomPrice = 10000;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.RegenerationPotion);
                shop.item[nextSlot].shopCustomPrice = 10000;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.MiningPotion);
                shop.item[nextSlot].shopCustomPrice = 7500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.BuilderPotion);
                shop.item[nextSlot].shopCustomPrice = 5000;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.ArcheryPotion);
                shop.item[nextSlot].shopCustomPrice = 15000;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.SummoningPotion);
                shop.item[nextSlot].shopCustomPrice = 7500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.EndurancePotion);
                shop.item[nextSlot].shopCustomPrice = 10000;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.HeartreachPotion);
                shop.item[nextSlot].shopCustomPrice = 10000;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.AmmoReservationPotion);
                shop.item[nextSlot].shopCustomPrice = 7500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.ThornsPotion);
                shop.item[nextSlot].shopCustomPrice = 5000;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.ShinePotion);
                shop.item[nextSlot].shopCustomPrice = 5000;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.NightOwlPotion);
                shop.item[nextSlot].shopCustomPrice = 5000;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.WarmthPotion);
                shop.item[nextSlot].shopCustomPrice = 20000;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.SpelunkerPotion);
                shop.item[nextSlot].shopCustomPrice = 20000;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.HunterPotion);
                shop.item[nextSlot].shopCustomPrice = 10000;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.TrapsightPotion);
                shop.item[nextSlot].shopCustomPrice = 10000;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.FlipperPotion);
                shop.item[nextSlot].shopCustomPrice = 5000;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.GillsPotion);
                shop.item[nextSlot].shopCustomPrice = 5000;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.InvisibilityPotion);
                shop.item[nextSlot].shopCustomPrice = 5000;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.WaterWalkingPotion);
                shop.item[nextSlot].shopCustomPrice = 5000;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.ObsidianSkinPotion);
                shop.item[nextSlot].shopCustomPrice = 10000;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.FeatherfallPotion);
                shop.item[nextSlot].shopCustomPrice = 7500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.GravitationPotion);
                shop.item[nextSlot].shopCustomPrice = 20000;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.MagicPowerPotion);
                shop.item[nextSlot].shopCustomPrice = 15000;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.ManaRegenerationPotion);
                shop.item[nextSlot].shopCustomPrice = 5000;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.TitanPotion);
                shop.item[nextSlot].shopCustomPrice = 7500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.BattlePotion);
                shop.item[nextSlot].shopCustomPrice = 10000;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.CalmingPotion);
                shop.item[nextSlot].shopCustomPrice = 10000;
                nextSlot++;
                if (Main.hardMode)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.LifeforcePotion);
                    shop.item[nextSlot].shopCustomPrice = 25000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.InfernoPotion);
                    shop.item[nextSlot].shopCustomPrice = 15000;
                    nextSlot++;
                }
                if (NPC.downedBoss3)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.WrathPotion);
                    shop.item[nextSlot].shopCustomPrice = 25000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.RagePotion);
                    shop.item[nextSlot].shopCustomPrice = 25000;
                    nextSlot++;
                }
                shop.item[nextSlot].SetDefaults(ItemID.StinkPotion);
                shop.item[nextSlot].shopCustomPrice = 7500;
                nextSlot++;
                if (Main.hardMode)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.LovePotion);
                    shop.item[nextSlot].shopCustomPrice = 7500;
                    nextSlot++;
                }
                if (Main.player[Main.myPlayer].anglerQuestsFinished >= 5)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.FishingPotion);
                    shop.item[nextSlot].shopCustomPrice = 10000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.SonarPotion);
                    shop.item[nextSlot].shopCustomPrice = 10000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.CratePotion);
                    shop.item[nextSlot].shopCustomPrice = 10000;
                    nextSlot++;
                }
                shop.item[nextSlot].SetDefaults(ItemID.GenderChangePotion);
                shop.item[nextSlot].shopCustomPrice = 100000;
                nextSlot++;
            }
            if (Shop2)
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.SunshinePotion>());
                shop.item[nextSlot].shopCustomPrice = 15000;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Dopamine>());
                shop.item[nextSlot].shopCustomPrice = 15000;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.GreaterDangersensePotion>());
                shop.item[nextSlot].shopCustomPrice = 25000;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.NatureBlessingPotion>());
                shop.item[nextSlot].shopCustomPrice = 25000;
                nextSlot++;
                if (NPC.downedBoss3)
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.BewitchingPotion>());
                    shop.item[nextSlot].shopCustomPrice = 10000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.FortitudePotion>());
                    shop.item[nextSlot].shopCustomPrice = 15000;
                    nextSlot++;
                    if (Main.hardMode)
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.InvincibilityPotion>());
                        shop.item[nextSlot].shopCustomPrice = 30000;
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.TitanSkinPotion>());
                        shop.item[nextSlot].shopCustomPrice = 50000;
                        nextSlot++;
                        if (ModLoader.GetMod("CalamityMod") != null)
                        {
                            if (CalamityModRevengeance)
                            {
                                shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.HeartAttackPotion>());
                                shop.item[nextSlot].shopCustomPrice = 250000;
                                nextSlot++;
                            }
                        }
                        if (NPC.downedMechBossAny && !NPC.downedMoonlord)
                        {
                            shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.DiscordPotion>());
                            shop.item[nextSlot].shopCustomPrice = 200000;
                            nextSlot++;
                        }
                        if (NPC.downedMoonlord)
                        {
                            shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.PerfectDiscordPotion>());
                            shop.item[nextSlot].shopCustomPrice = 330000;
                            nextSlot++;
                        }
                        if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
                        {
                            shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.BlurringPotion>());
                            shop.item[nextSlot].shopCustomPrice = 150000;
                            nextSlot++;
                            if (NPC.downedPlantBoss)
                            {
                                shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.NinjaPotion>());
                                shop.item[nextSlot].shopCustomPrice = 75000;
                                nextSlot++;
                            }
                            if (NPC.downedGolemBoss)
                            {
                                shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.TrapsPotion>());
                                shop.item[nextSlot].shopCustomPrice = 50000;
                                nextSlot++;
                            }
                        }
                    }
                }
                ModLoader.TryGetMod("CalamityMod", out Mod Calamity);
                if (Calamity != null)
                {
                    addModItemToShop(Calamity, "BoundingPotion", 20000, ref shop, ref nextSlot);
                    addModItemToShop(Calamity, "CalciumPotion", 35000, ref shop, ref nextSlot);
                    addModItemToShop(Calamity, "TriumphPotion", 30000, ref shop, ref nextSlot);
                    addModItemToShop(Calamity, "TeslaPotion", 25000, ref shop, ref nextSlot);
                    addModItemToShop(Calamity, "SulphurskinPotion", 15000, ref shop, ref nextSlot);
                    if (NPC.downedBoss3)
                    {
                        addModItemToShop(Calamity, "PotionofOmniscience", 20000, ref shop, ref nextSlot);
                        if (NPC.downedPlantBoss)
                        {
                            addModItemToShop(Calamity, "ZergPotion", 30000, ref shop, ref nextSlot);
                            addModItemToShop(Calamity, "ZenPotion", 30000, ref shop, ref nextSlot);
                        }
                        addModItemToShop(Calamity, "YharimsStimulants", 100000, ref shop, ref nextSlot);
                        if (Main.hardMode)
                        {
                            addModItemToShop(Calamity, "CrumblingPotion", 50000, ref shop, ref nextSlot);
                            addModItemToShop(Calamity, "PhotosynthesisPotion", 50000, ref shop, ref nextSlot);
                            addModItemToShop(Calamity, "SoaringPotion", 40000, ref shop, ref nextSlot);
                            addModItemToShop(Calamity, "CadancePotion", 40000, ref shop, ref nextSlot);
                            addModItemToShop(Calamity, "FabsolsVodka", 100000, ref shop, ref nextSlot);
                            addModItemToShop(Calamity, "RevivifyPotion", 50000, ref shop, ref nextSlot);
                            if ((bool)Calamity.Call("Downed", "astrum aureus"))
                            {
                                addModItemToShop(Calamity, "AstralInjection", 10000, ref shop, ref nextSlot);
                                addModItemToShop(Calamity, "GravityNormalizerPotion", 30000, ref shop, ref nextSlot);
                            }
                            if (NPC.downedPlantBoss)
                            {
                                addModItemToShop(Calamity, "PenumbraPotion", 100000, ref shop, ref nextSlot);
                            }
                            if (NPC.downedGolemBoss)
                            {
                                addModItemToShop(Calamity, "TitanScalePotion", 40000, ref shop, ref nextSlot);
                                addModItemToShop(Calamity, "ShatteringPotion", 100000, ref shop, ref nextSlot);
                            }
                            if (NPC.downedMoonlord)
                            {
                                addModItemToShop(Calamity, "HolyWrathPotion", 100000, ref shop, ref nextSlot);
                                addModItemToShop(Calamity, "ProfanedRagePotion", 100000, ref shop, ref nextSlot);
                            }
                            if ((bool)Calamity.Call("Downed", "polterghast"))
                            {
                                addModItemToShop(Calamity, "CeaselessHungerPotion", 25000, ref shop, ref nextSlot);
                            }
                            if ((bool)Calamity.Call("Downed", "yharon"))
                            {
                                addModItemToShop(Calamity, "DraconicElixir", 250000, ref shop, ref nextSlot);
                            }
                        }
                    }
                }
            }
            if (Shop21)
            {
                if (ModLoader.TryGetMod("ThoriumMod", out Mod ThoriumMod))
                {
                    if (NPC.downedBoss3)
                    {
                        addModItemToShop(ThoriumMod, "WarmongerPotion", 10000, ref shop, ref nextSlot);
                        addModItemToShop(ThoriumMod, "ArtilleryPotion", 10000, ref shop, ref nextSlot);
                        addModItemToShop(ThoriumMod, "BouncingFlamePotion", 10000, ref shop, ref nextSlot);
                        addModItemToShop(ThoriumMod, "CreativityPotion", 10000, ref shop, ref nextSlot);
                        addModItemToShop(ThoriumMod, "EarwormPotion", 10000, ref shop, ref nextSlot);
                        addModItemToShop(ThoriumMod, "AssassinPotion", 10000, ref shop, ref nextSlot);
                    }
                    if (Main.hardMode)
                    {
                        addModItemToShop(ThoriumMod, "InspirationReachPotion", 20000, ref shop, ref nextSlot);
                    }
                    addModItemToShop(ThoriumMod, "GlowingPotion", 20000, ref shop, ref nextSlot);
                    if (Main.hardMode)
                    {
                        addModItemToShop(ThoriumMod, "HolyPotion", 20000, ref shop, ref nextSlot);
                        addModItemToShop(ThoriumMod, "ArcanePotion", 20000, ref shop, ref nextSlot);
                    }
                    addModItemToShop(ThoriumMod, "HydrationPotion", 10000, ref shop, ref nextSlot);
                    addModItemToShop(ThoriumMod, "BloodPotion", 10000, ref shop, ref nextSlot);
                    addModItemToShop(ThoriumMod, "ConflagrationPotion", 10000, ref shop, ref nextSlot);
                    addModItemToShop(ThoriumMod, "AquaPotion", 10000, ref shop, ref nextSlot);
                    addModItemToShop(ThoriumMod, "FrenzyPotion", 20000, ref shop, ref nextSlot);
                    addModItemToShop(ThoriumMod, "KineticPotion", 20000, ref shop, ref nextSlot);
                }
                /*
                if (ModLoader.GetMod("ReducedGrinding") != null)
                {
                	addModItemToShop(ReducedGrinding, "War_Potion", 15000, ref shop, ref nextSlot);
                	addModItemToShop(ReducedGrinding, "Time_Potion", 15000, ref shop, ref nextSlot);
                	addModItemToShop(ReducedGrinding, "Expert_Change_Potion", 15000, ref shop, ref nextSlot);
                	addModItemToShop(ReducedGrinding, "Rain_Potion", 15000, ref shop, ref nextSlot);
                	addModItemToShop(ReducedGrinding, "Slime_Rain_Potion", 15000, ref shop, ref nextSlot);
                }
				*/
            }
            if (Shop3)
            {
                // IMPLEMENT WHEN WEAKREFERENCES FIXED
                /*
                if (ModLoader.GetMod("MorePotions") != null)
                {
                    addModItemToShop(MorePotions, "HeavyRootsPotion", 7500, ref shop, ref nextSlot);
                    addModItemToShop(MorePotions, "NaturesBlessingPotion", 15000, ref shop, ref nextSlot);
                    addModItemToShop(MorePotions, "HoneyPotion", 10000, ref shop, ref nextSlot);
                    addModItemToShop(MorePotions, "JellySolesPotion", 10000, ref shop, ref nextSlot);
                    addModItemToShop(MorePotions, "JumpPotion", 7500, ref shop, ref nextSlot);
                    addModItemToShop(MorePotions, "PenetrationPotion", 10000, ref shop, ref nextSlot);
                    addModItemToShop(MorePotions, "WarriorsDroughtPotion", 15000, ref shop, ref nextSlot);
                    addModItemToShop(MorePotions, "RangersDroughtPotion", 15000, ref shop, ref nextSlot);
                    addModItemToShop(MorePotions, "SummonersDroughtPotion", 15000, ref shop, ref nextSlot);
                    addModItemToShop(MorePotions, "GladiatorsPotion", 15000, ref shop, ref nextSlot);
                    addModItemToShop(MorePotions, "OlympiansPotion", 10000, ref shop, ref nextSlot);
                    addModItemToShop(MorePotions, "SwiftHandsPotion", 10000, ref shop, ref nextSlot);
                    addModItemToShop(MorePotions, "SpeedPotion", 7500, ref shop, ref nextSlot);
                    addModItemToShop(MorePotions, "StarlightPotion", 7500, ref shop, ref nextSlot);
                    addModItemToShop(MorePotions, "GoldenPotion", 20000, ref shop, ref nextSlot);
                    if (Main.hardMode)
                    {
                        addModItemToShop(MorePotions, "DiamondSkinPotion", 20000, ref shop, ref nextSlot);
                        addModItemToShop(MorePotions, "ManashieldPotion", 30000, ref shop, ref nextSlot);
                        addModItemToShop(MorePotions, "ReactiveArmorPotion", 30000, ref shop, ref nextSlot);
                        addModItemToShop(MorePotions, "VengeancePotion", 30000, ref shop, ref nextSlot);
                        addModItemToShop(MorePotions, "EnhancedRegenerationPotion", 15000, ref shop, ref nextSlot);
                        addModItemToShop(MorePotions, "HolyElixerPotion", 20000, ref shop, ref nextSlot);
                        addModItemToShop(MorePotions, "SoulbindingElixerPotion", 20000, ref shop, ref nextSlot);
                        addModItemToShop(MorePotions, "ManaforcePotion", 30000, ref shop, ref nextSlot);
                        addModItemToShop(MorePotions, "CouragePotion", 30000, ref shop, ref nextSlot);
                        addModItemToShop(MorePotions, "DelvingPotion", 20000, ref shop, ref nextSlot);
                        addModItemToShop(MorePotions, "ForbiddenPotion", 50000, ref shop, ref nextSlot);
                        addModItemToShop(MorePotions, "VenomousCoatingPotion", 30000, ref shop, ref nextSlot);
                        addModItemToShop(MorePotions, "GoldCoatingPotion", 30000, ref shop, ref nextSlot);
                        addModItemToShop(MorePotions, "IchorousCoatingPotion", 30000, ref shop, ref nextSlot);
                        addModItemToShop(MorePotions, "CursedCoatingPotion", 30000, ref shop, ref nextSlot);
                        if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
                        {
                            addModItemToShop(MorePotions, "LeafCrystalPotion", 20000, ref shop, ref nextSlot);
                        }
                        if (NPC.downedPlantBoss)
                        {
                            addModItemToShop(MorePotions, "LifestealPotion", 75000, ref shop, ref nextSlot);
                        }
                        if (NPC.downedGolemBoss)
                        {
                            addModItemToShop(MorePotions, "SuperRegenerationPotion", 30000, ref shop, ref nextSlot);
                        }
                        if (NPC.downedMoonlord)
                        {
                            addModItemToShop(MorePotions, "SolarPotion", 100000, ref shop, ref nextSlot);
                            addModItemToShop(MorePotions, "NebulaPotion", 100000, ref shop, ref nextSlot);
                            addModItemToShop(MorePotions, "VortexPotion", 100000, ref shop, ref nextSlot);
                            addModItemToShop(MorePotions, "StardustPotion", 100000, ref shop, ref nextSlot);
                            addModItemToShop(MorePotions, "TerrariansWrathPotion", 250000, ref shop, ref nextSlot);
                        }
                    }
                }
				*/
            }
            if (Shop4)
            {
                // IMPLEMENT WHEN WEAKREFERENCES FIXED
                /*
                if (ModLoader.GetMod("UnuBattleRods") != null)
                {
                	addModItemToShop(UnuBattleRods, "BobEscalationPotion", 10000, ref shop, ref nextSlot);
                	addModItemToShop(UnuBattleRods, "BobSpeedingPotion", 10000, ref shop, ref nextSlot);
                	addModItemToShop(UnuBattleRods, "FasterEscalationPotion", 25000, ref shop, ref nextSlot);
                	addModItemToShop(UnuBattleRods, "FurtherEscalationPotion", 35000, ref shop, ref nextSlot);
                	if (NPC.downedBoss3)
                		{
                	addModItemToShop(UnuBattleRods, "MaximumEscalationPotion", 110000, ref shop, ref nextSlot);
                		}
                }
                if (ModLoader.GetMod("Tacklebox") != null)
                {
                	addModItemToShop(Tacklebox, "FrogPotion", 10000, ref shop, ref nextSlot);
                	addModItemToShop(Tacklebox, "DivingPotion", 30000, ref shop, ref nextSlot);
                	addModItemToShop(Tacklebox, "UltrabrightPotion", 30000, ref shop, ref nextSlot);
                	if (Main.player[Main.myPlayer].anglerQuestsFinished >= 5)
                	{
                	if (NPC.downedBoss3)
                		{
                	addModItemToShop(Tacklebox, "AnglerPotion", 30000, ref shop, ref nextSlot);
                	addModItemToShop(Tacklebox, "SuperAngler", 100000, ref shop, ref nextSlot);
                	addModItemToShop(Tacklebox, "SuperCrate", 30000, ref shop, ref nextSlot);
                	addModItemToShop(Tacklebox, "SuperFishing", 30000, ref shop, ref nextSlot);
                		}
                	}
                }
                if (ModLoader.GetMod("Tremor") != null)
                {
                	addModItemToShop(Tremor, "InspirationPotion", 20000, ref shop, ref nextSlot);
                	addModItemToShop(Tremor, "RockClimberPotion", 10000, ref shop, ref nextSlot);
                		if (Main.hardMode)
                			{
                			addModItemToShop(Tremor, "BloodmoonPotion", 20000, ref shop, ref nextSlot);
                			}
                			if (NPC.downedMoonlord)
                			{
                			addModItemToShop(Tremor, "ParadoxPotion", 30000, ref shop, ref nextSlot);
                			addModItemToShop(Tremor, "SunfuryPotion", 50000, ref shop, ref nextSlot);
                			addModItemToShop(Tremor, "MidnightPotion", 50000, ref shop, ref nextSlot);
                			addModItemToShop(Tremor, "ScamperPotion", 50000, ref shop, ref nextSlot);
                			addModItemToShop(Tremor, "SavingPotion", 50000, ref shop, ref nextSlot);
                			addModItemToShop(Tremor, "GlassPotion", 30000, ref shop, ref nextSlot);
                			}						
                		}
					}
				}
				*/
            }
            if (Shop5)
            {
                // IMPLEMENT WHEN WEAKREFERENCES FIXED
                /*
                if (ModLoader.GetMod("Wildlife") != null)
                {
                    addModItemToShop(Wildlife, "BouncePotion", 10000, ref shop, ref nextSlot);
                    addModItemToShop(Wildlife, "FluxglowPotion", 15000, ref shop, ref nextSlot);
                    addModItemToShop(Wildlife, "DeerBlood", 5000, ref shop, ref nextSlot);
                    addModItemToShop(Wildlife, "TortoisePotion", 10000, ref shop, ref nextSlot);
                    if (NPC.downedBoss3)
                    {
                        addModItemToShop(Wildlife, "MoltenPotion", 20000, ref shop, ref nextSlot);
                    }
                    if (Main.hardMode)
                    {
                        addModItemToShop(Wildlife, "FairyBottleB", 10000, ref shop, ref nextSlot);
                        addModItemToShop(Wildlife, "FairyBottleG", 10000, ref shop, ref nextSlot);
                        addModItemToShop(Wildlife, "FairyBottleP", 10000, ref shop, ref nextSlot);
                        addModItemToShop(Wildlife, "AscensionPotion", 20000, ref shop, ref nextSlot);
                        addModItemToShop(Wildlife, "GlitchhopPotion", 30000, ref shop, ref nextSlot);
                        addModItemToShop(Wildlife, "SparkPotion", 15000, ref shop, ref nextSlot);
                    }
                }
                if (ModLoader.GetMod("SacredTools") != null)
                {
                    if (NPC.downedBoss1)
                    {
                        shop.item[nextSlot].SetDefaults(ModLoader.GetMod("SacredTools").ItemType("ThrownPotion"));
                        shop.item[nextSlot].value = 30000;
                        nextSlot++;
                    }
                    if (Main.hardMode)
                    {
                        shop.item[nextSlot].SetDefaults(ModLoader.GetMod("SacredTools").ItemType("SandPotion"));
                        shop.item[nextSlot].value = 30000;
                        nextSlot++;
                    }
                    if (SacredToolsDownedAbaddon)
                    {
                        shop.item[nextSlot].SetDefaults(ModLoader.GetMod("SacredTools").ItemType("NightmarePotion"));
                        shop.item[nextSlot].value = 250000;
                        nextSlot++;
                    }
                    if (SacredToolsDownedSerpent)
                    {
                        shop.item[nextSlot].SetDefaults(ModLoader.GetMod("SacredTools").ItemType("BurnCure"));
                        shop.item[nextSlot].value = 250000;
                        nextSlot++;
                    }
                    if (SacredToolsDownedLunarians)
                    {
                        shop.item[nextSlot].SetDefaults(ModLoader.GetMod("SacredTools").ItemType("MoonlightPotion"));
                        shop.item[nextSlot].value = 250000;
                        nextSlot++;
                    }
                }
                if (ModLoader.GetMod("SpiritMod") != null)
                {
                    shop.item[nextSlot].SetDefaults(ModLoader.GetMod("SpiritMod").ItemType("BismitePotion"));
                    shop.item[nextSlot].value = 10000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ModLoader.GetMod("SpiritMod").ItemType("PinkPotion"));
                    shop.item[nextSlot].value = 10000;
                    nextSlot++;
                    if (NPC.downedMechBossAny)
                    {
                        shop.item[nextSlot].SetDefaults(ModLoader.GetMod("SpiritMod").ItemType("SoulPotion"));
                        shop.item[nextSlot].value = 30000;
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(ModLoader.GetMod("SpiritMod").ItemType("RunePotion"));
                        shop.item[nextSlot].value = 30000;
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(ModLoader.GetMod("SpiritMod").ItemType("SpiritPotion"));
                        shop.item[nextSlot].value = 30000;
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(ModLoader.GetMod("SpiritMod").ItemType("StarPotion"));
                        shop.item[nextSlot].value = 30000;
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(ModLoader.GetMod("SpiritMod").ItemType("TurtlePotion"));
                        shop.item[nextSlot].value = 100000;
                        nextSlot++;
                    }
                    if (NPC.downedPlantBoss)
                    {
                        shop.item[nextSlot].SetDefaults(ModLoader.GetMod("SpiritMod").ItemType("DungeonSpirit"));
                        shop.item[nextSlot].value = 30000;
                        nextSlot++;
                    }
                }
                if (ModLoader.GetMod("CrystiliumMod") != null)
                {
                    if (Main.hardMode)
                    {
                        shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CrystiliumMod").ItemType("CrystalPotion"));
                        shop.item[nextSlot].value = 20000;
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CrystiliumMod").ItemType("DragonWine"));
                        shop.item[nextSlot].value = 20000;
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CrystiliumMod").ItemType("DustbreakPotion"));
                        shop.item[nextSlot].value = 20000;
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CrystiliumMod").ItemType("GranitePotion"));
                        shop.item[nextSlot].value = 20000;
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CrystiliumMod").ItemType("MarblePotion"));
                        shop.item[nextSlot].value = 20000;
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CrystiliumMod").ItemType("ThrowingBoostPotion"));
                        shop.item[nextSlot].value = 20000;
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(ModLoader.GetMod("CrystiliumMod").ItemType("TwilightPotion"));
                        shop.item[nextSlot].value = 20000;
                        nextSlot++;
                    }
                }
                if (ModLoader.GetMod("ExpandedSentries") != null)
                {
                    shop.item[nextSlot].SetDefaults(ModLoader.GetMod("ExpandedSentries").ItemType("SentryPotion"));
                    shop.item[nextSlot].value = 30000;
                    nextSlot++;
                    if (NPC.downedBoss3)
                    {
                        shop.item[nextSlot].SetDefaults(ModLoader.GetMod("ExpandedSentries").ItemType("DefenderPotion"));
                        shop.item[nextSlot].value = 20000;
                        nextSlot++;
                    }
                }
                if (ModLoader.GetMod("Desiccation") != null)
                {
                    if (NPC.downedBoss3 && Main.player[Main.myPlayer].anglerQuestsFinished >= 10)
                    {
                        shop.item[nextSlot].SetDefaults(ModLoader.GetMod("Desiccation").ItemType("QuestSkipPotion"));
                        shop.item[nextSlot].value = 30000;
                        nextSlot++;
                    }
                }
				*/
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