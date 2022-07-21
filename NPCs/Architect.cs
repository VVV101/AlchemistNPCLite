using System.Linq;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Terraria.Localization;
using Terraria.GameContent;
using AlchemistNPCLite.NPCs;
using AlchemistNPCLite.Interface;
using ReLogic.Content;
using System.Collections.Generic;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.Personalities;

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
            DisplayName.SetDefault("Architect");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "建筑师");
            Main.npcFrameCount[NPC.type] = 26;
            NPCID.Sets.AttackFrameCount[NPC.type] = 5;
            NPCID.Sets.DangerDetectRange[NPC.type] = 100;
            NPCID.Sets.AttackType[NPC.type] = 3;
            NPCID.Sets.AttackTime[NPC.type] = 35;
            NPCID.Sets.AttackAverageChance[NPC.type] = 50;
            NPCID.Sets.HatOffsetY[NPC.type] = -4;

            ModTranslation text = LocalizationLoader.CreateTranslation(Mod, "Joe");
            text.SetDefault("Joe");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Джо");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "Mark");
            text.SetDefault("Mark");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Марк");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "Walter");
            text.SetDefault("Walter");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Вальтер");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "Archer");
            text.SetDefault("Archer");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Арчер");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "Frido");
            text.SetDefault("Frido");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Фридо");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "Li");
            text.SetDefault("Li");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Ли");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "A1");
            text.SetDefault("If this dastardly ");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Если эта трусливая ");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "如果这个卑鄙的 ");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "A2");
            text.SetDefault(" isn't going to shut up, I'm letting ");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), " не замолчит, я позволю ");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), " 再不住口的话, 我会让 ");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "A3");
            text.SetDefault(" bite her.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), " укусить её.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), " 咬她.");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "A4");
            text.SetDefault("KILL THE ZOMBIES! KILL THE BUNNIES! IN THE NAME OF THE BLOO- oh sorry I didn't notice you here.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "УБИВАЙ ЗОМБИ! УБИВАЙ КРОЛИКОВ! ВО ИМЯ КРОВ-- Ой прости, я не заметил, что ты здесь.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "杀掉那个僵尸! 杀掉那个兔子! 那个名字是血- 哦, 抱歉, 我没注意到你在这里.");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "A5");
            text.SetDefault("Why hello there I'm just getting some blood buckets for a lake I'm making pleasedontaskanymorequestions");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Привет. Я просто собираю несколько вёдер крови для озера. Пожалуйста, большеничегонеспрашивай.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "哦嗨你好我正在为一个湖收集一些装满血的水桶我很开心所以别问我更多问题了再见.");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "A6");
            text.SetDefault("I like it when there is a gigantic horde of zombies behind our doors. But I HATE WHEN THEY BREAK MY DOORS!");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Я люблю, когда за нашими дверями огромная орда зомби. Но Я НЕНАВИЖУ КОГДА ОНИ ИХ ЛОМАЮТ!");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "当有一大堆僵尸在我的门后面时我很喜欢它，但是当它们打破我的门时我恨它!");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "A7");
            text.SetDefault("Ah, the feeling that I'm not safe, the paranoia is embraced the moment the bloodmoon rises up in the sky.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Ах, это чувство отсутствия безопасности, паранойя, которая подчёркивается моментом, когда кровавая луна восходит на небосводе.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "啊哈, 这种不安全的感觉, 偏执狂热爱这种血月在空中的感觉.");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "A8");
            text.SetDefault("Are you interested in my religion? It invloves sacrifices to the bloody moon.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Ты заинтересован в моей религии? У нас есть жертвы Кровавой Луне.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "你对我的信仰感兴趣吗? 它涉及对血月的牺牲.");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "A9");
            text.SetDefault("Do you know why I hate these goblins? They are mildly annoying.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Знаешь, почему я ненавижу этих гоблинов? Они ужасно раздражающие.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "你知道为毛我恨这些哥布林嘛? 他们太鸡儿吵了.");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "A10");
            text.SetDefault("Hooray to pirates! They supply me with my golden furniture!");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Ура пиратам! Они привозят мне золотую мебель!");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "海盗万岁! 他们给我供应金家具!");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "A11");
            text.SetDefault("Ah! Finally some proper plating to have my roof done!");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Ах! Наконец-то хорошое покрытие для моей крыши готово!");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "啊哈! 最后进行一些适当的电镀来完成我的屋顶!");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "A12");
            text.SetDefault("No explosives please, ");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Никакой взрывчатки, пожалуйста, ");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "请不要乱炸OK? ");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "A13");
            text.SetDefault(" is already annoying me enough.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), " и так достаточно раздражает меня.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), " 已经够烦了.");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "A14");
            text.SetDefault("BUILDER POTIONS FREE FOR EVERYONE but you.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "БЕСПЛАТНЫЕ ЗЕЛЬЯ СТРОИТЕЛЯ ДЛЯ ВСЕХ кроме тебя.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "建筑药水对所有人免费, 除了你.");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "A15");
            text.SetDefault("What? Where I got my architect degree? There's an architect degree?");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Что? Где я получил диплом архитектора? Такие вообще существуют?");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "什么玩意儿? 我去哪里搞到我的建筑师学位? 有建筑师学位吗?");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "A16");
            text.SetDefault("Did'ja know that wood somehow doesn't burn? Though under certain circumstances it does. Weird...");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Ты знаешь, что дерево каким-то образом не горит? Хотя при некоторых условиях оно может. Странно...");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "你知道木头怎么才不会烧着吗? 经过一系列操作之后的确不会. 真的怪...");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "A17");
            text.SetDefault("No, I am not the guy. I'm the dude.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Нет, я не парень. Я чувак.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "不, 我不是家伙(guy). 我是老兄(dude).");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "A18");
            text.SetDefault("Well, the one you recently made was ALMOST impressive. (not really)");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Ну, то, что ты недавно построил было почти впечатляющим. (на самом деле НЕТ)");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "嗯, 你最近做的一件事情几乎让人印象深刻. (不存在的)");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "A19");
            text.SetDefault("So, you say that chests are furniture too. I reply: Screw you.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Так ты утверждаешь, что сундуки - это тоже мебель. Я тебе отвечу: Пошёл ты.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "所以, 你说箱子也是家具. 我表示: 去你丫的.");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "A20");
            text.SetDefault("I saw your buildings but I am still not impressed");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Я видел твои постройки, но я всё ещё не впечатлён.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "我看了你的建筑, 但是我仍然觉得不怎么样.");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "A21");
            text.SetDefault("Have you heard 'bout that FuryForged guy? I taught him all he knows!");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Ты слышал об этом FuryForged? Я научил его всему, что он знает!");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "A22");
            text.SetDefault("I was once hired by a certain company to build a supermassive hi-tech, hi-security installation. Lemme tell ya its my magnum opus in terms of security and containment.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Как-то раз я был нанят одной компанией, чтобы построить огромный высокотехнологичный комплекс с высочайщей степенью безопасности. Это была моя самая лучшая работа в плане сдерживания и безопасности.");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "AS1");
            text.SetDefault("1st shop (Filler Blocks)       ");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "1-ый магазин (Заполняющие Блоки)");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "第一商店 (填充方块)");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "AS2");
            text.SetDefault("2nd shop (Building Blocks)     ");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "2-ой магазин (Строительные Блоки)");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "第二商店 (建筑方块)");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "AS3");
            text.SetDefault("3rd shop (Basic Furniture)     ");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "3-ий магазин (Базовая мебель)");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "第三商店 (基础家具)");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "AS4");
            text.SetDefault("4th shop (Advanced Furniture)  ");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "4-ый магазин (Продвинутая мебель)");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "第四商店 (高级家具)");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "AS5");
            text.SetDefault("5th shop (Torches)             ");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "5-ый магазин (Факелы)");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "第五商店 (火把)");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "AS6");
            text.SetDefault("6th shop (Candles)             ");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "6-ый магазин (Свечи)");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "第六商店 (蜡烛)");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "AS7");
            text.SetDefault("7th shop (Lamps)               ");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "7-ой магазин (Лампы)");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "第七商店 (台灯)");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "AS8");
            text.SetDefault("8th shop (Lanterns)            ");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "8-ой магазин (Фонари)");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "第八商店 (灯笼)");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "AS9");
            text.SetDefault("9th shop (Chandeliers)         ");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "9-ый магазин (Люстры)");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "第九商店 (吊灯)");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "AS10");
            text.SetDefault("10th shop (Candelabras)        ");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "10-ый магазин (Канделябры)");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "第十商店 (烛台)");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "ShopsChanger");
            text.SetDefault("Shops Changer");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Смена магазина");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "切换商店");
            LocalizationLoader.AddTranslation(text);
			NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            {
                Velocity = -1f,
                Direction = -1
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);

            NPC.Happiness.SetBiomeAffection<OceanBiome>(AffectionLevel.Like);
            NPC.Happiness.SetBiomeAffection<JungleBiome>(AffectionLevel.Love);
            NPC.Happiness.SetBiomeAffection<SnowBiome>(AffectionLevel.Dislike);

            NPC.Happiness.SetNPCAffection(NPCID.Painter,AffectionLevel.Love);
            NPC.Happiness.SetNPCAffection(NPCID.GoblinTinkerer,AffectionLevel.Like);
            NPC.Happiness.SetNPCAffection(NPCID.TaxCollector,AffectionLevel.Dislike);
        }
		
		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
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

        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
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

        public override void DrawTownAttackSwing(ref Texture2D item, ref int itemSize, ref float scale, ref Vector2 offset)//Allows you to customize how this town NPC's weapon is drawn when this NPC is swinging it (this NPC must have an attack type of 3). ItemType is the Texture2D instance of the item to be drawn (use Main.PopupTexture[id of item]), itemSize is the width and height of the item's hitbox
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

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (firstButton)
            {
                shop = true;
                ShopChangeUIA.visible = false;
            }
            else
            {
                if(!ShopChangeUIA.visible) ShopChangeUIA.timeStart = Main.GameUpdateCount;
                ShopChangeUIA.visible = true;
            }
        }

        // IMPLEMENT WHEN WEAKREFERENCES FIXED
        /*
        Mod chadsfurniture = ModLoader.GetMod("chadsfurni");
        */

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            if (Shop1)
            {
                shop.item[nextSlot].SetDefaults(ItemID.DirtBlock);
                shop.item[nextSlot].shopCustomPrice = 1;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.ClayBlock);
                shop.item[nextSlot].shopCustomPrice = 1;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.StoneBlock);
                shop.item[nextSlot].shopCustomPrice = 1;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.EbonstoneBlock);
                shop.item[nextSlot].shopCustomPrice = 2;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.CrimstoneBlock);
                shop.item[nextSlot].shopCustomPrice = 2;
                nextSlot++;
                if (NPC.downedQueenBee)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.Hive);
                    shop.item[nextSlot].shopCustomPrice = 10;
                    nextSlot++;
                }
                shop.item[nextSlot].SetDefaults(ItemID.SandBlock);
                shop.item[nextSlot].shopCustomPrice = 1;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.EbonsandBlock);
                shop.item[nextSlot].shopCustomPrice = 2;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.CrimsandBlock);
                shop.item[nextSlot].shopCustomPrice = 2;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.Sandstone);
                shop.item[nextSlot].shopCustomPrice = 1;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.HardenedSand);
                shop.item[nextSlot].shopCustomPrice = 1;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.MudBlock);
                shop.item[nextSlot].shopCustomPrice = 1;
                nextSlot++;
                if (NPC.downedBoss2)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.DesertFossil);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.Obsidian);
                    shop.item[nextSlot].shopCustomPrice = 2500;
                    nextSlot++;
                }
                shop.item[nextSlot].SetDefaults(ItemID.AshBlock);
                shop.item[nextSlot].shopCustomPrice = 1;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.SiltBlock);
                nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.SlushBlock);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.SnowBlock);
                shop.item[nextSlot].shopCustomPrice = 1;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.IceBlock);
                shop.item[nextSlot].shopCustomPrice = 1;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.Marble);
                shop.item[nextSlot].shopCustomPrice = 50;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.Granite);
                shop.item[nextSlot].shopCustomPrice = 50;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.Cloud);
                shop.item[nextSlot].shopCustomPrice = 100;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.RainCloud);
                shop.item[nextSlot].shopCustomPrice = 100;
                nextSlot++;
                if (Main.hardMode)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.PearlstoneBlock);
                    shop.item[nextSlot].shopCustomPrice = 25;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.PearlsandBlock);
                    shop.item[nextSlot].shopCustomPrice = 25;
                    nextSlot++;
                }
            }
            if (Shop2)
            {
                shop.item[nextSlot].SetDefaults(ItemID.RedBrick);
                shop.item[nextSlot].shopCustomPrice = 2;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.Wood);
                shop.item[nextSlot].shopCustomPrice = 5;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.Ebonwood);
                shop.item[nextSlot].shopCustomPrice = 10;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.Shadewood);
                shop.item[nextSlot].shopCustomPrice = 10;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.BorealWood);
                shop.item[nextSlot].shopCustomPrice = 10;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.PalmWood);
                shop.item[nextSlot].shopCustomPrice = 15;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.RichMahogany);
                shop.item[nextSlot].shopCustomPrice = 15;
                nextSlot++;
                // IMPLEMENT WHEN WEAKREFERENCES FIXED
				/*
                if (ModLoader.GetMod("ThoriumMod") != null)
                {
                    if (NPC.downedGoblins)
                    {
                    	addModItemToShop(ThoriumMod, "YewWood", 500, ref shop, ref nextSlot);
                    }
                }
				*/
                shop.item[nextSlot].SetDefaults(ItemID.DynastyWood);
                shop.item[nextSlot].shopCustomPrice = 100;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.RedDynastyShingles);
                shop.item[nextSlot].shopCustomPrice = 100;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.BlueDynastyShingles);
                shop.item[nextSlot].shopCustomPrice = 100;
                nextSlot++;
                if (Main.hardMode)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.Pearlwood);
                    shop.item[nextSlot].shopCustomPrice = 25;
                    nextSlot++;
                }
                shop.item[nextSlot].SetDefaults(ItemID.GrayBrick);
                shop.item[nextSlot].shopCustomPrice = 2;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.Glass);
                shop.item[nextSlot].shopCustomPrice = 2;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.MeteoriteBrick);
                shop.item[nextSlot].shopCustomPrice = 4;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.ObsidianBrick);
                shop.item[nextSlot].shopCustomPrice = 5;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.IridescentBrick);
                shop.item[nextSlot].shopCustomPrice = 2;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.SnowBrick);
                shop.item[nextSlot].shopCustomPrice = 2;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.SandstoneBrick);
                shop.item[nextSlot].shopCustomPrice = 2;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.EbonstoneBrick);
                shop.item[nextSlot].shopCustomPrice = 10;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.IceBrick);
                shop.item[nextSlot].shopCustomPrice = 2;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.FleshBlock);
                shop.item[nextSlot].shopCustomPrice = 10;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.StoneSlab);
                shop.item[nextSlot].shopCustomPrice = 2;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.SandstoneSlab);
                shop.item[nextSlot].shopCustomPrice = 2;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.MarbleBlock);
                shop.item[nextSlot].shopCustomPrice = 75;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.GraniteBlock);
                shop.item[nextSlot].shopCustomPrice = 75;
                nextSlot++;
                if (NPC.downedQueenBee)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.HoneyBlock);
                    shop.item[nextSlot].shopCustomPrice = 5;
                    nextSlot++;
                }
                if (Main.hardMode)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.CrystalBlock);
                    shop.item[nextSlot].shopCustomPrice = 100;
                    nextSlot++;
                }
                shop.item[nextSlot].SetDefaults(ItemID.SunplateBlock);
                shop.item[nextSlot].shopCustomPrice = 25;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.Pumpkin);
                shop.item[nextSlot].shopCustomPrice = 125;
                nextSlot++;
                if (NPC.downedBoss3)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.PinkBrick);
                    shop.item[nextSlot].shopCustomPrice = 50;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.GreenBrick);
                    shop.item[nextSlot].shopCustomPrice = 50;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.BlueBrick);
                    shop.item[nextSlot].shopCustomPrice = 50;
                    nextSlot++;
                }
                if (NPC.downedMechBossAny)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.AsphaltBlock);
                    shop.item[nextSlot].shopCustomPrice = 2;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.FleshBlock);
                    shop.item[nextSlot].shopCustomPrice = 10;
                    nextSlot++;
                }
                if (Main.hardMode)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.PearlstoneBrick);
                    shop.item[nextSlot].shopCustomPrice = 10;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.RainbowBrick);
                    shop.item[nextSlot].shopCustomPrice = 100;
                    nextSlot++;
                }
                if (NPC.downedGolemBoss)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.LihzahrdBrick);
                    shop.item[nextSlot].shopCustomPrice = 100;
                    nextSlot++;
                }
                if (NPC.downedMartians)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.MartianConduitPlating);
                    shop.item[nextSlot].shopCustomPrice = 25;
                    nextSlot++;
                }
            }
            if (Shop3)
            {
                shop.item[nextSlot].SetDefaults(ItemID.Candle);
                shop.item[nextSlot].shopCustomPrice = 100;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.GoldChandelier);
                shop.item[nextSlot].shopCustomPrice = 25000;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.ChainLantern);
                shop.item[nextSlot].shopCustomPrice = 200;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.Mannequin);
                shop.item[nextSlot].shopCustomPrice = 100;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.Womannquin);
                shop.item[nextSlot].shopCustomPrice = 100;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.Cobweb);
                shop.item[nextSlot].shopCustomPrice = 20;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.WorkBench);
                shop.item[nextSlot].shopCustomPrice = 2000;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.WoodenTable);
                shop.item[nextSlot].shopCustomPrice = 2000;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.WoodenChair);
                shop.item[nextSlot].shopCustomPrice = 2000;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.WoodenDoor);
                shop.item[nextSlot].shopCustomPrice = 2000;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.WoodenBeam);
                shop.item[nextSlot].shopCustomPrice = 100;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.Book);
                shop.item[nextSlot].shopCustomPrice = 250;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.Fireplace);
                shop.item[nextSlot].shopCustomPrice = 3000;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.Chimney);
                shop.item[nextSlot].shopCustomPrice = 3000;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.Furnace);
                shop.item[nextSlot].shopCustomPrice = 3000;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.BanquetTable);
                shop.item[nextSlot].shopCustomPrice = 3000;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.HeavyWorkBench);
                shop.item[nextSlot].shopCustomPrice = 3000;
                nextSlot++;

                if (Main.hardMode)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.BrickLayer);
                    shop.item[nextSlot].shopCustomPrice = 150000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.PortableCementMixer);
                    shop.item[nextSlot].shopCustomPrice = 150000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.PaintSprayer);
                    shop.item[nextSlot].shopCustomPrice = 150000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.ExtendoGrip);
                    shop.item[nextSlot].shopCustomPrice = 150000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(3624);
                    shop.item[nextSlot].shopCustomPrice = 150000;
                    nextSlot++;
                }
                if (NPC.downedBoss3)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.Ruler);
                    shop.item[nextSlot].shopCustomPrice = 25000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.EngineeringHelmet);
                    shop.item[nextSlot].shopCustomPrice = 50000;
                    nextSlot++;
                }
            }
            if (Shop4)
            {
                shop.item[nextSlot].SetDefaults(ItemID.LivingLoom);
                shop.item[nextSlot].shopCustomPrice = 20000;
                nextSlot++;
                if (NPC.downedBoss3)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.AlchemyTable);
                    shop.item[nextSlot].shopCustomPrice = 33000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.BoneWelder);
                    shop.item[nextSlot].shopCustomPrice = 20000;
                    nextSlot++;
					// IMPLEMENT WHEN WEAKREFERENCES FIXED
					/*
                    if (chadsfurniture != null)
                    {
                    	shop.item[nextSlot].SetDefaults(chadsfurniture.ItemType("printer"));
                    	shop.item[nextSlot].shopCustomPrice = 20000;
                    	nextSlot++;
                    	shop.item[nextSlot].SetDefaults(chadsfurniture.ItemType("printer3"));
                    	shop.item[nextSlot].shopCustomPrice = 20000;
                    	nextSlot++;
                    	shop.item[nextSlot].SetDefaults(chadsfurniture.ItemType("wallomatic"));
                    	shop.item[nextSlot].shopCustomPrice = 20000;
                    	nextSlot++;
                    }
					*/

                }
                shop.item[nextSlot].SetDefaults(ItemID.GlassKiln);
                shop.item[nextSlot].shopCustomPrice = 20000;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.SkyMill);
                shop.item[nextSlot].shopCustomPrice = 20000;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.IceMachine);
                shop.item[nextSlot].shopCustomPrice = 20000;
                nextSlot++;
                if (NPC.downedQueenBee)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.HoneyDispenser);
                    shop.item[nextSlot].shopCustomPrice = 20000;
                    nextSlot++;
                }
                shop.item[nextSlot].SetDefaults(ItemID.Sawmill);
                shop.item[nextSlot].shopCustomPrice = 2000;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.Loom);
                shop.item[nextSlot].shopCustomPrice = 2000;
                nextSlot++;
                if (Main.hardMode)
                {
					// IMPLEMENT WHEN WEAKREFERENCES FIXED
					/*
                    if (chadsfurniture != null)
                    {
                        shop.item[nextSlot].SetDefaults(chadsfurniture.ItemType("RimpelstiltskinsLoom"));
                        shop.item[nextSlot].shopCustomPrice = 200000;
                        nextSlot++;
                    }
					*/
                    shop.item[nextSlot].SetDefaults(ItemID.MeatGrinder);
                    shop.item[nextSlot].shopCustomPrice = 15000;
                    nextSlot++;
                }
                if (NPC.downedMechBossAny)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.FleshCloningVaat);
                    shop.item[nextSlot].shopCustomPrice = 20000;
                    nextSlot++;
                }
                if (NPC.downedPlantBoss)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.LihzahrdFurnace);
                    shop.item[nextSlot].shopCustomPrice = 20000;
                    nextSlot++;
                }
            }
            if (Shop5)
            {
                shop.item[nextSlot].SetDefaults(ItemID.Torch);
                shop.item[nextSlot].shopCustomPrice = 50;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.TikiTorch);
                shop.item[nextSlot].shopCustomPrice = 250;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(974);
                shop.item[nextSlot].shopCustomPrice = 300;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(427);
                shop.item[nextSlot].shopCustomPrice = 300;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(428);
                shop.item[nextSlot].shopCustomPrice = 300;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(1245);
                shop.item[nextSlot].shopCustomPrice = 300;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(429);
                shop.item[nextSlot].shopCustomPrice = 300;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(430);
                shop.item[nextSlot].shopCustomPrice = 300;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(431);
                shop.item[nextSlot].shopCustomPrice = 300;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(432);
                shop.item[nextSlot].shopCustomPrice = 300;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(433);
                shop.item[nextSlot].shopCustomPrice = 300;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(523);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(1333);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2274);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(3004);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(3045);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(3114);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
            }
            if (Shop6)
            {
                shop.item[nextSlot].SetDefaults(105);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(713);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(1405);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(1406);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(1407);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2045);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2046);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2047);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2048);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2049);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2050);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                if (Main.hardMode)
                {
                    shop.item[nextSlot].SetDefaults(2051);
                    shop.item[nextSlot].shopCustomPrice = 500;
                    nextSlot++;
                }
                shop.item[nextSlot].SetDefaults(2052);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2153);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2154);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2155);
                shop.item[nextSlot].shopCustomPrice = 30000;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2236);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2523);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2542);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2556);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2571);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2648);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2649);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2650);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2651);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                if (NPC.downedMartians)
                {
                    shop.item[nextSlot].SetDefaults(2818);
                    shop.item[nextSlot].shopCustomPrice = 500;
                    nextSlot++;
                }
                shop.item[nextSlot].SetDefaults(3171);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(3172);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(3173);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                if (Main.hardMode)
                {
                    shop.item[nextSlot].SetDefaults(3890);
                    shop.item[nextSlot].shopCustomPrice = 500;
                    nextSlot++;
                }
            }
            if (Shop7)
            {
                shop.item[nextSlot].SetDefaults(341);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2082);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2083);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2084);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2085);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2086);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2087);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                if (Main.hardMode)
                {
                    shop.item[nextSlot].SetDefaults(2088);
                    shop.item[nextSlot].shopCustomPrice = 500;
                    nextSlot++;
                }
                shop.item[nextSlot].SetDefaults(2089);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2090);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2091);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2129);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2130);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2131);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2132);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2133);
                shop.item[nextSlot].shopCustomPrice = 30000;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2134);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2225);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2533);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2547);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2563);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2578);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2643);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2644);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2645);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2646);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2647);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                if (NPC.downedMartians)
                {
                    shop.item[nextSlot].SetDefaults(2819);
                    shop.item[nextSlot].shopCustomPrice = 500;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(2820);
                    shop.item[nextSlot].shopCustomPrice = 500;
                    nextSlot++;
                }
                shop.item[nextSlot].SetDefaults(3135);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(3136);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(3137);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                if (Main.hardMode)
                {
                    shop.item[nextSlot].SetDefaults(3892);
                    shop.item[nextSlot].shopCustomPrice = 500;
                    nextSlot++;
                }
            }
            if (Shop8)
            {
                shop.item[nextSlot].SetDefaults(136);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(344);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(347);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(1390);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(1391);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(1392);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(1393);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(1394);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(1808);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2032);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2033);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2034);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2035);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2036);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2037);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2038);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                if (Main.hardMode)
                {
                    shop.item[nextSlot].SetDefaults(2039);
                    shop.item[nextSlot].shopCustomPrice = 500;
                    nextSlot++;
                }
                shop.item[nextSlot].SetDefaults(2040);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2041);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2042);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2043);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2145);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2146);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2147);
                shop.item[nextSlot].shopCustomPrice = 30000;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2148);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2226);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2530);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2546);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2564);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2579);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2641);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2642);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2820);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(3138);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(3139);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(3140);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                if (Main.hardMode)
                {
                    shop.item[nextSlot].SetDefaults(3891);
                    shop.item[nextSlot].shopCustomPrice = 500;
                    nextSlot++;
                }
            }
            if (Shop9)
            {
                shop.item[nextSlot].SetDefaults(106);
                shop.item[nextSlot].shopCustomPrice = 25000;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(107);
                shop.item[nextSlot].shopCustomPrice = 25000;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(108);
                shop.item[nextSlot].shopCustomPrice = 25000;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(710);
                shop.item[nextSlot].shopCustomPrice = 25000;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(711);
                shop.item[nextSlot].shopCustomPrice = 25000;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(712);
                shop.item[nextSlot].shopCustomPrice = 25000;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2055);
                shop.item[nextSlot].shopCustomPrice = 1200;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2056);
                shop.item[nextSlot].shopCustomPrice = 1200;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2057);
                shop.item[nextSlot].shopCustomPrice = 1200;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2058);
                shop.item[nextSlot].shopCustomPrice = 1200;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2059);
                shop.item[nextSlot].shopCustomPrice = 1200;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2060);
                shop.item[nextSlot].shopCustomPrice = 1200;
                nextSlot++;
                if (Main.hardMode)
                {
                    shop.item[nextSlot].SetDefaults(2061);
                    shop.item[nextSlot].shopCustomPrice = 1200;
                    nextSlot++;
                }
                shop.item[nextSlot].SetDefaults(2062);
                shop.item[nextSlot].shopCustomPrice = 1200;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2063);
                shop.item[nextSlot].shopCustomPrice = 1200;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2064);
                shop.item[nextSlot].shopCustomPrice = 1200;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2065);
                shop.item[nextSlot].shopCustomPrice = 1200;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2141);
                shop.item[nextSlot].shopCustomPrice = 1200;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2142);
                shop.item[nextSlot].shopCustomPrice = 1200;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2143);
                shop.item[nextSlot].shopCustomPrice = 30000;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2144);
                shop.item[nextSlot].shopCustomPrice = 1200;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2224);
                shop.item[nextSlot].shopCustomPrice = 1200;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2525);
                shop.item[nextSlot].shopCustomPrice = 1200;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2543);
                shop.item[nextSlot].shopCustomPrice = 1200;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2558);
                shop.item[nextSlot].shopCustomPrice = 1200;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2573);
                shop.item[nextSlot].shopCustomPrice = 1200;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2652);
                shop.item[nextSlot].shopCustomPrice = 1200;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2653);
                shop.item[nextSlot].shopCustomPrice = 1200;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2654);
                shop.item[nextSlot].shopCustomPrice = 1200;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2655);
                shop.item[nextSlot].shopCustomPrice = 1200;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2656);
                shop.item[nextSlot].shopCustomPrice = 1200;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2657);
                shop.item[nextSlot].shopCustomPrice = 1200;
                nextSlot++;
                if (NPC.downedMartians)
                {
                    shop.item[nextSlot].SetDefaults(2813);
                    shop.item[nextSlot].shopCustomPrice = 1200;
                    nextSlot++;
                }
                shop.item[nextSlot].SetDefaults(3177);
                shop.item[nextSlot].shopCustomPrice = 1200;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(3178);
                shop.item[nextSlot].shopCustomPrice = 1200;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(3179);
                shop.item[nextSlot].shopCustomPrice = 1200;
                nextSlot++;
                if (Main.hardMode)
                {
                    shop.item[nextSlot].SetDefaults(3894);
                    shop.item[nextSlot].shopCustomPrice = 1200;
                    nextSlot++;
                }
            }
            if (Shop10)
            {
                shop.item[nextSlot].SetDefaults(349);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(714);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2092);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2093);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2094);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2095);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2096);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2097);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2098);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                if (Main.hardMode)
                {
                    shop.item[nextSlot].SetDefaults(2099);
                    shop.item[nextSlot].shopCustomPrice = 500;
                    nextSlot++;
                }
                shop.item[nextSlot].SetDefaults(2100);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2101);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2102);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2103);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2149);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2150);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2151);
                shop.item[nextSlot].shopCustomPrice = 30000;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2152);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2227);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2522);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2541);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2555);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2570);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2664);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2665);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2666);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2667);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(2668);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                if (NPC.downedMartians)
                {
                    shop.item[nextSlot].SetDefaults(2825);
                    shop.item[nextSlot].shopCustomPrice = 500;
                    nextSlot++;
                }
                shop.item[nextSlot].SetDefaults(3168);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(3169);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(3170);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                if (Main.hardMode)
                {
                    shop.item[nextSlot].SetDefaults(3893);
                    shop.item[nextSlot].shopCustomPrice = 500;
                    nextSlot++;
                }
            }
        }
    }
}
