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
        public static bool baseShop = false;
        public static bool plantShop = false;
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
            DisplayName.SetDefault("Alchemist");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Алхимик");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "炼金师");
            Main.npcFrameCount[NPC.type] = 23;
            NPCID.Sets.AttackFrameCount[NPC.type] = 2;
            NPCID.Sets.DangerDetectRange[NPC.type] = 500;
            NPCID.Sets.AttackType[NPC.type] = 0;
            NPCID.Sets.AttackTime[NPC.type] = 22;
            NPCID.Sets.AttackAverageChance[NPC.type] = 30;
            NPCID.Sets.HatOffsetY[NPC.type] = -4;

            ModTranslation text = LocalizationLoader.CreateTranslation(Mod, "PlantsShop");
            text.SetDefault("Plants shop");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Магазин растений");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "GetCharm");
            text.SetDefault("Get Charm");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Получить талисман");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "Edward");
            text.SetDefault("Edward");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Эдвард");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "Severus");
            text.SetDefault("Severus");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Северус");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "Horace");
            text.SetDefault("Horace");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Гораций");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "Tilyorn");
            text.SetDefault("Tilyorn");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Тильорн");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "Nicolas");
            text.SetDefault("Nicolas");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Николас");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "Gregg");
            text.SetDefault("Gregg");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Грег");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryA1");
            text.SetDefault("My Healing potions will cure your deepest wounds.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Мои лечебные зелья излечат твои глубочайшие раны.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "我的生命药水可以治疗你的伤口.");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryA2");
            text.SetDefault("My Mana potions will restore your magic power.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Мои зелья маны восстановят твою магическую силу.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "我的魔法药水可以回复你的魔力.");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryA3");
            text.SetDefault("Restoration potions... I'm not sure if I trust them...");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Зелья Восстановления... Не уверен, могу ли я доверять им...");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "再生药剂...不知道它们是好是坏...");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryA4");
            text.SetDefault("There's a legendary yoyo known as the Sasscade.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Существует Легендарное Йо-йо, известное как Сасскад.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "有一个传说中的溜溜球被称为Sasscade.");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryA5");
            text.SetDefault("The Strange Brew I bought from the Skeleton Merchant smells awful, but its Mana Restoration effect is awesome!");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Странное Варево, что я купил у Скелета-торговца пахнет просто ужасно, но его эффект восстановления маны потрясает.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "来自骷髅商人的奇异啤酒气味真的很糟糕,但法力恢复效果非常棒!");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryA6");
            text.SetDefault("Hi, *cough*... That definitely wasn't a Teleporation potion.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Привет, *кашель*... Это определённо было не зелье Телепортации.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "嗨, *咳咳*.. 那绝对不是柠檬茶.");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryA7");
            text.SetDefault("Have you seen any Mechanical Skulls around?");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Ты не видел Механических Черепов поблизости?");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "你有在周围看到一个机械骷髅王吗?");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryA8");
            text.SetDefault("Have you ever heard of Ultra Mushroom? If you find one, I do believe I got some stuff to aid you in boosting that thing.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Ты слышал об Ультра Грибах? Если ты найдёшь такой, я уверен что я смогу помочь тебе его усилить.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "你有听说过极限蘑菇吗？如果你找到了一个，我相信我能研究出一种可以帮助你的材料.");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryA9");
            text.SetDefault("I asked ");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Я попросил у ");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "我向 ");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryA10");
            text.SetDefault(" if I could buy the recipe for the Potent Extract. He said no because, and I quote, ''Even an idiot would figure it out.''");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), " рецепт Кактусового Экстракта. Он ответил нет, поскольку, я процитирую ''Даже идиот догадается.''");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), " 购买高效萃取配方，因为他说不，然后我就说‘即使是傻子也能研究出那个配方’.");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryA11");
            text.SetDefault("And to think, she's getting the potions and not me... but I can't argue there.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "И только подумать... Она выбрала зелья, а не меня. Хотя тут и не поспоришь.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "想想看, 她正在得到那些药水而我没有...但我对此却又无法反驳.");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryA12");
            text.SetDefault("What is his name? ");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Как его зовут? ");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "他叫什么来着? ");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryA13");
            text.SetDefault("? So... Teacher's here? Better step up my game!");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "? Так... Учитель здесь? Лучше отойди с дороги!");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "? 所以... 老师在这儿? 我最好加快脚步!");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryA14");
            text.SetDefault("Thank goodness I got those pieces from Skeletron. Want to check it out?");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Слава богу, что я добыл эти кусочки из Скелетрона? Не желаешь посмотреть?");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "感谢上帝，我从骷髅王那里拿到了这些碎片，想要看看吗？");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryA15");
            text.SetDefault("Can you please ask ");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Можешь попросить ");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "你能不能拜托 ");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryA16");
            text.SetDefault(" to stop mocking me? I know my potions can't make you stronger, but at least they aren't as dangerous to drink.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), " перестать дразнить меня? Я знаю, что мои зелья не сделают тебя сильнее, но их хотя бы не столь опасно пить.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), " 别再嘲笑我?我知道我的药剂不能让你变强,但是至少他们喝起来不危险.");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryA17");
            text.SetDefault("These goblins are so annoying... Thankfully, they cannot stay here for too long.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Эти гоблины такие раздражающие... Хорошо, что они не останутся здесь надолго.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "这些哥布林是如此的愤怒...幸好，他们在这里的时间不会很久.");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryA18");
            text.SetDefault("You better deal with Pirates as fast, as you can. I can't wait to talk with Captain! Haven't seen him for years!");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Постарайся справиться с Пиратами как можно быстрее. Не могу дождаться возвращения Капитана! Я не видел его уже много лет!");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "你最好以最快的速度解决这些海盗先，我忍不住想和船长说几句话，好些年没见到过他咯!");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryA19");
            text.SetDefault("I hope that you will not let them into my house, will you?");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Я надеюсь, ты не пустишь их в мой дом, правда?");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "我觉得你不会让他们进我的屋子的，是吧?");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryA20");
            text.SetDefault("Perhaps there are better things for you to do, rather than talking to me, at the moment. I don't know... maybe defend us?!");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Может у тебя найдётся занятие получше, чем говорить со мной сейчас? Ну например... Охранять нас?!");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "也许在这个时候你有比和我说话更重要的事情要做? 有个血红色的月亮挂在天上哎!");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryA21");
            text.SetDefault("...My friend, the best thing to do in this case is not bother me during this time.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "...Мой друг, лучшее, что ты можешь сделать - это не беспокоить меня сейчас.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "...我的朋友，在这个时刻最好的事情就是别来打扰我!");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryA22");
            text.SetDefault("I have an explosive flask. You do NOT want to know what it tastes like.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "У меня есть взрывная колба. Ты точно НЕ хочешь узнать, какова она на вкус.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "我有一个爆炸烧瓶，你不会想知道它尝起来是什么味道的.");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryA23");
            text.SetDefault("How can ");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Как ");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "所以 ");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryA24");
            text.SetDefault(" stay calm in a time like this? I want to know, NOW.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "может оставаться спокойной в такое время? Я ХОЧУ это узнать.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), " 是怎么在这种时候保持冷静的? 我现在就想知道, 现在!");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryA25");
            text.SetDefault("Don't let the dark one that came from the Jungle fool you with charming wisdom. Me and ");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Не позволяй тёмному, пришедшему из Джунглей, одурачить тебя чарующей мудростью. Я и ");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryA26");
            text.SetDefault(" were once his apprentices. I quit when his lessons turned too dark but ");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), " однажды были его ассистентами. Я ушёл, когда его уроки стали слишком тёмными, но интерес ");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryA27");
            text.SetDefault(" interest in occult Alchemy did nothing but grow.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), " к оккультной алхимии только вырос.");
            LocalizationLoader.AddTranslation(text);
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

        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
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

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (firstButton)
            {
                baseShop = true;
                plantShop = false;
                shop = true;
            }
            else
            {
                Player player = Main.player[Main.myPlayer];
                if ((player.GetModPlayer<AlchemistNPCLitePlayer>()).AlchemistCharmTier1 == false && (player.GetModPlayer<AlchemistNPCLitePlayer>()).AlchemistCharmTier2 == false && (player.GetModPlayer<AlchemistNPCLitePlayer>()).AlchemistCharmTier3 == false && (player.GetModPlayer<AlchemistNPCLitePlayer>()).AlchemistCharmTier4 == false)
                {
                    var source = NPC.GetSource_FromAI();
                    player.QuickSpawnItem(source, ModContent.ItemType<Items.Misc.AlchemistCharmTier1>());
                }
                baseShop = false;
                plantShop = true;
                shop = true;
            }
        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            if (baseShop)
            {
                shop.item[nextSlot].SetDefaults(ItemID.LesserHealingPotion);
                shop.item[nextSlot].shopCustomPrice = 1000;
                nextSlot++;
                if (NPC.downedBoss2)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.HealingPotion);
                    shop.item[nextSlot].shopCustomPrice = 5000;
                    nextSlot++;
                }
                if (Main.hardMode)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.GreaterHealingPotion);
                    shop.item[nextSlot].shopCustomPrice = 10000;
                    nextSlot++;
                }
                if (NPC.downedMoonlord)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.SuperHealingPotion);
                    shop.item[nextSlot].shopCustomPrice = 25000;
                    nextSlot++;
                }
                ModLoader.TryGetMod("CalamityMod", out Mod Calamity);
                if (Calamity != null)
                {
                    if ((bool)Calamity.Call("Downed", "profaned guardians") && !(bool)Calamity.Call("Downed", "polterghast"))
                    {
                        if (Calamity.TryFind<ModItem>("SupremeHealingPotion", out ModItem currItem))
                        {
                            shop.item[nextSlot].SetDefaults(currItem.Type);
                            shop.item[nextSlot].shopCustomPrice = 500000;
                            nextSlot++;
                        }
                    }
                    if ((bool)Calamity.Call("Downed", "polterghast"))
                    {
                        if (Calamity.TryFind<ModItem>("OmegaHealingPotion", out ModItem currItem))
                        {
                            shop.item[nextSlot].SetDefaults(currItem.Type);
                            shop.item[nextSlot].shopCustomPrice = 1000000;
                            nextSlot++;
                        }
                    }
                }
                shop.item[nextSlot].SetDefaults(ItemID.LesserManaPotion);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                if (NPC.downedBoss2)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.ManaPotion);
                    shop.item[nextSlot].shopCustomPrice = 1000;
                    nextSlot++;
                }
                if (Main.hardMode)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.GreaterManaPotion);
                    shop.item[nextSlot].shopCustomPrice = 5000;
                    nextSlot++;
                }
                if (Main.hardMode && NPC.downedMechBoss1 && (NPC.downedMechBoss2 && NPC.downedMechBoss3))
                {
                    shop.item[nextSlot].SetDefaults(ItemID.SuperManaPotion);
                    shop.item[nextSlot].shopCustomPrice = 10000;
                    nextSlot++;
                }
                if (NPC.downedBoss2)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.StrangeBrew);
                    shop.item[nextSlot].shopCustomPrice = 10000;
                    nextSlot++;
                }
                shop.item[nextSlot].SetDefaults(ItemID.RecallPotion);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.WormholePotion);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.LuckPotionLesser);
                shop.item[nextSlot].shopCustomPrice = 20000;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.LuckPotion);
                shop.item[nextSlot].shopCustomPrice = 100000;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.LuckPotionGreater);
                shop.item[nextSlot].shopCustomPrice = 500000;
                nextSlot++;

                if (Main.hardMode)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.TeleportationPotion);
                    shop.item[nextSlot].shopCustomPrice = 7500;
                    nextSlot++;
                }
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
                if (NPC.downedBoss2)
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.BeachTeleporterPotion>());
                    shop.item[nextSlot].shopCustomPrice = 20000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.JungleTeleporterPotion>());
                    shop.item[nextSlot].shopCustomPrice = 50000;
                    nextSlot++;
                }
                if (NPC.downedBoss3)
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.OceanTeleporterPotion>());
                    shop.item[nextSlot].shopCustomPrice = 20000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.DungeonTeleportationPotion>());
                    shop.item[nextSlot].shopCustomPrice = 25000;
                    nextSlot++;
                }
                if (Main.hardMode)
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.UnderworldTeleportationPotion>());
                    shop.item[nextSlot].shopCustomPrice = 50000;
                    nextSlot++;
                }
                if (NPC.downedPlantBoss)
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.TempleTeleportationPotion>());
                    shop.item[nextSlot].shopCustomPrice = 100000;
                    nextSlot++;
                }
                shop.item[nextSlot].SetDefaults(ItemID.Bottle);
                shop.item[nextSlot].shopCustomPrice = 100;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.BottledWater);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                if (NPC.downedBoss2)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.FallenStar);
                    nextSlot++;
                }
                shop.item[nextSlot].SetDefaults(ItemID.Gel);
                shop.item[nextSlot].shopCustomPrice = 100;
                nextSlot++;
                if (NPC.downedBoss2)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.PinkGel);
                    shop.item[nextSlot].shopCustomPrice = 1000;
                    nextSlot++;
                }
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
                if (Main.hardMode)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.PixieDust);
                    shop.item[nextSlot].shopCustomPrice = 5000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.CrystalShard);
                    shop.item[nextSlot].shopCustomPrice = 7500;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.UnicornHorn);
                    shop.item[nextSlot].shopCustomPrice = 15000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.CursedFlame);
                    shop.item[nextSlot].shopCustomPrice = 7500;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.Ichor);
                    shop.item[nextSlot].shopCustomPrice = 7500;
                    nextSlot++;
                }
            }
            if (plantShop)
            {
                shop.item[nextSlot].SetDefaults(ItemID.Daybloom);
                shop.item[nextSlot].shopCustomPrice = 1000;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.Waterleaf);
                shop.item[nextSlot].shopCustomPrice = 1000;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.Shiverthorn);
                shop.item[nextSlot].shopCustomPrice = 1000;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.Blinkroot);
                shop.item[nextSlot].shopCustomPrice = 2000;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.Moonglow);
                shop.item[nextSlot].shopCustomPrice = 2000;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.Fireblossom);
                shop.item[nextSlot].shopCustomPrice = 2500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.Deathweed);
                shop.item[nextSlot].shopCustomPrice = 2500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.Mushroom);
                shop.item[nextSlot].shopCustomPrice = 500;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.GlowingMushroom);
                shop.item[nextSlot].shopCustomPrice = 1000;
                nextSlot++;
                if (NPC.downedBoss2)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.VileMushroom);
                    shop.item[nextSlot].shopCustomPrice = 1000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.ViciousMushroom);
                    shop.item[nextSlot].shopCustomPrice = 1000;
                    nextSlot++;
                }
                // IMPLEMENT WHEN WEAKREFERENCES FIXED
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
            }
        }
    }
}
