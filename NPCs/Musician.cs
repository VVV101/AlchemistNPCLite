using System.Linq;
using System;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Events;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using Terraria.WorldBuilding;
using AlchemistNPCLite.Interface;
using System.Collections.Generic;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.Personalities;

namespace AlchemistNPCLite.NPCs
{
    [AutoloadHead]
    public class Musician : ModNPC
    {
        public static bool S1 = true;
        public static bool S2 = false;
        public static bool S3 = false;
        public override string Texture
        {
            get
            {
                return "AlchemistNPCLite/NPCs/Musician";
            }
        }
        //Probably removed
        // public override bool Autoload(ref string name)
        // {
        // 	name = "Musician";
        // 	return true;
        // }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Musician");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Музыкант");
            Main.npcFrameCount[NPC.type] = 25;
            NPCID.Sets.AttackFrameCount[NPC.type] = 4;
            NPCID.Sets.DangerDetectRange[NPC.type] = 500;
            NPCID.Sets.AttackType[NPC.type] = 0;
            NPCID.Sets.AttackTime[NPC.type] = 45;
            NPCID.Sets.AttackAverageChance[NPC.type] = 30;
            NPCID.Sets.HatOffsetY[NPC.type] = -2;

            ModTranslation text = LocalizationLoader.CreateTranslation(Mod, "Shop2");
            text.SetDefault("2nd shop");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "2-ой магазин");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "Shop3");
            text.SetDefault("3rd shop");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "3-ий магазин");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "ShopChanger");
            text.SetDefault("Shop Changer");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сменить магазин");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "切换商店");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "Beethoven");
            text.SetDefault("Beethoven");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Бетховен");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "Bach");
            text.SetDefault("Bach");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Бах");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "Johan");
            text.SetDefault("Johan");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Иоганн");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "Edison");
            text.SetDefault("Edison");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Эдисон");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "Scott");
            text.SetDefault("Scott");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Скотт");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "Lloyd");
            text.SetDefault("Lloyd");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Ллойд");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "Gamma");
            text.SetDefault("Gamma");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Гамма");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryM1");
            text.SetDefault("I would wear headphones, but I'm not sure if Terrarians even have ears...");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Я бы носил наушники, но я не уверен, что обитатели Террарии вообще имеют уши...");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryM2");
            text.SetDefault("I have to wonder why Boss 1 and Boss 2 didn't get better names in the OST. Those names are soooo bland.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Интересно, почему Босс 1 и Босс 2 не имеют имён получше в саундтреке. Эти имена слишком обычные.");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryM3");
            text.SetDefault("Look, the Cyborg may have my name, but I've still got the better job here.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Хотя у Киборга может быть моё имя, но у меня здесь всё равно работа получше.");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryM4");
            text.SetDefault("Shhhhh! You'll ruin my recording!");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Шшш! Ты испортишь мою запись!");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryM5");
            text.SetDefault("I swear, if one more person asks me to sell them a ''Megalovania'' music box....");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Не дай бог ещё кто-нибудь попросит меня продать ему музыкальную шкатулку с Мегалованией...");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryM6");
            text.SetDefault("Look, your enthusiasm is awesome, but could you maybe record the next boss track yourself? I don't really want to risk my life for some tunes.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Послушай, твой энтузиазм просто потрясающий, но может ты запишешь мелодию следующего босса сам? Мне не очень хочется рисковать жизнью из-за некоторых мелодий.");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryM7");
            text.SetDefault("Ah, I see you were able to save the Explorer! Well done! Perhaps my next song is going to be about your triumph.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Я вижу ты спас Исследовательницу! Отличная работа! Может быть моя следующая песня будет о твоём триумфе.");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryM8");
            text.SetDefault("You know, ");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Ты знаешь, ");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryM9");
            text.SetDefault(" has been really helpful while I've been setting up this sound system. Wires are key!");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), " была очень полезна, когда я устанавливал здесь звуковую систему. Провода рулят!");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryM10");
            text.SetDefault("If you run into ");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Если как-нибудь зайдёшь к ");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryM11");
            text.SetDefault(", let him know he still owes me for those music boxes I sold him.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), ", то передай ему, что он всё ещё должен мне за те музыкальные шкатулки, что я продал ему.");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryM12");
            text.SetDefault("I'll be honest, I'm not sure if I trust ");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Буду честен, я не уверен, что я доверяю ");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryM13");
            text.SetDefault(". He claims to not be possessed, and yet he still is using skulls to fight... I'm getting mixed messages here.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), ". Он вроде бы больше не одержим, но все еще использует черепа для битвы... У меня смешанные чувства.");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryM14");
            text.SetDefault("Man, my mixtape is so much better than this, but I can't sell you that due to copyright.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Чувак, мои записи значительно лучше всего этого, но я не могу продать их тебе из-за авторских прав.");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryM15");
            text.SetDefault("No, I don't have an ''All Star'' music box. Code it in yourself.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Нет, я меня нет музыкальной шкатулки ''Со Всеми''. Закодируй её сам.");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryM16");
            text.SetDefault("Wait, NPC? I thought I was the protagonist!");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Погоди-ка, НИП? Я думал, что я протагонист!");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryM17");
            text.SetDefault("Never thought I'd be selling a music box with lyrics... DM DOKURO, you're a madman and I love it!");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Никогда не думал, что я буду продавать музыкальные шкатулки с песнями... DM DOKURO, ты безумец и мне это нравится!");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryM18");
            text.SetDefault("A whole music based class? That sounds amazing! Too bad I don't have any gear for that, huh?");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Целый класс, основанный на музыке? Звучит потрясающе! Жаль, что у меня нет ничего подходящего для него...");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryM19");
            text.SetDefault("This is your fault. GET. OUT.");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Это твоя вина. УБИРАЙСЯ. ОТСЮДА.");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryM20");
            text.SetDefault("Ah, this takes me back! I remember when this song used to play in the dungeon and the underworld... good times!");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Эх, ностальгия! Я помню, когда эта мелодия играла в Подземелье и в Преисподней... хорошие времена!");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryM21");
            text.SetDefault("Is there a name for the fear of being spied by a cake?");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Если ли имя у страха того, что за тобой шпионят с помощью торта?");
            LocalizationLoader.AddTranslation(text);
            text = LocalizationLoader.CreateTranslation(Mod, "EntryM22");
            text.SetDefault("You are hurting my ears! Turn it down!");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "У меня уже болят уши! Сделай потише!");
            LocalizationLoader.AddTranslation(text);
			NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            {
                Velocity = -1f,
                Direction = -1
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);

            NPC.Happiness.SetBiomeAffection<UndergroundBiome>(AffectionLevel.Like);
            NPC.Happiness.SetBiomeAffection<HallowBiome>(AffectionLevel.Love);
            NPC.Happiness.SetBiomeAffection<SnowBiome>(AffectionLevel.Dislike);

            NPC.Happiness.SetNPCAffection(NPCID.PartyGirl,AffectionLevel.Love);
            NPC.Happiness.SetNPCAffection(NPCID.Wizard,AffectionLevel.Like);
            NPC.Happiness.SetNPCAffection(NPCID.GoblinTinkerer,AffectionLevel.Dislike);
        }
		
		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
                new FlavorTextBestiaryInfoElement("Mods.AlchemistNPCLite.Bestiary.Musician")
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
            if (NPC.downedBoss3 && AlchemistNPCLite.modConfiguration.MusicianSpawn)
            {
                return true;
            }
            return false;
        }



        public override List<string> SetNPCNameList()
        {                                       //NPC names
            string Beethoven = Language.GetTextValue("Mods.AlchemistNPCLite.Beethoven");
            string Bach = Language.GetTextValue("Mods.AlchemistNPCLite.Bach");
            string Johan = Language.GetTextValue("Mods.AlchemistNPCLite.Johan");
            string Edison = Language.GetTextValue("Mods.AlchemistNPCLite.Edison");
            string Scott = Language.GetTextValue("Mods.AlchemistNPCLite.Scott");
            string Lloyd = Language.GetTextValue("Mods.AlchemistNPCLite.Lloyd");
            string Gamma = Language.GetTextValue("Mods.AlchemistNPCLite.Gamma");

            return new List<string>() {
				Beethoven,
				Bach,
				Johan,
				Edison,
                Scott,
                Lloyd,
                Gamma
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
            cooldown = 5;
            randExtraCooldown = 5;
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            attackDelay = 3;
            switch (Main.rand.Next(3))
            {
                case 0:
                    projType = 76;
                    break;
                case 1:
                    projType = 77;
                    break;
                case 2:
                    projType = 78;
                    break;
            }


        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 6f;
            randomOffset = 0f;
        }


        public override string GetChat()
        {
            string EntryM1 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryM1");
            string EntryM2 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryM2");
            string EntryM3 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryM3");
            string EntryM4 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryM4");
            string EntryM5 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryM5");
            string EntryM6 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryM6");
            string EntryM7 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryM7");
            string EntryM8 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryM8");
            string EntryM9 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryM9");
            string EntryM10 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryM10");
            string EntryM11 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryM11");
            string EntryM12 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryM12");
            string EntryM13 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryM13");
            string EntryM14 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryM14");
            string EntryM15 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryM15");
            string EntryM16 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryM16");
            string EntryM17 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryM17");
            string EntryM18 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryM18");
            string EntryM19 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryM19");
            string EntryM20 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryM20");
            string EntryM21 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryM21");
            string EntryM22 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryM22");
            string Gamma = Language.GetTextValue("Mods.AlchemistNPCLite.Gamma");
            int Cyborg = NPC.FindFirstNPC(NPCID.Cyborg);
            int Mechanic = NPC.FindFirstNPC(NPCID.Mechanic);
            int Clothier = NPC.FindFirstNPC(NPCID.Clothier);
            int Wizard = NPC.FindFirstNPC(NPCID.Wizard);
            int Musician = NPC.FindFirstNPC(ModContent.NPCType<Musician>());
            if (Main.musicVolume == 0)
            {
                return EntryM19;
            }
            if (Main.musicVolume == 100)
            {
                return EntryM22;
            }
            if (Main.bloodMoon)
            {
                return EntryM20;
            }
            if (Cyborg >= 0 && Main.npc[Cyborg].GivenName == "Gamma" && Main.npc[Musician].GivenName == Gamma && Main.rand.Next(15) == 0)
            {
                return EntryM3;
            }
            if (Mechanic >= 0 && Main.rand.Next(20) == 0)
            {
                return EntryM8 + Main.npc[Mechanic].GivenName + EntryM9;
            }
            if (Wizard >= 0 && Main.rand.Next(20) == 0)
            {
                return EntryM10 + Main.npc[Wizard].GivenName + EntryM11;
            }
            if (Clothier >= 0 && Main.rand.Next(20) == 0)
            {
                return EntryM12 + Main.npc[Clothier].GivenName + EntryM13;
            }
            // IMPLEMENT WHEN WEAKREFERENCES FIXED
            /*
            if (ModLoader.GetMod("ThoriumMod") != null)
            {
            	if (Main.rand.Next(15) == 0)
            	{
            	    return EntryM18;
            	}
            }
            */
            if (ModLoader.TryGetMod("CalamityModMusic", out Mod CalamityMusic))
            {
            	if (Main.rand.Next(15) == 0)
            	{
            	    return EntryM17;
            	}
            }
            switch (Main.rand.Next(9))
            {
                case 0:
                    return EntryM1;
                case 1:
                    return EntryM2;
                case 2:
                    return EntryM4;
                case 3:
                    return EntryM5;
                case 4:
                    return EntryM6;
                case 5:
                    return EntryM14;
                case 6:
                    return EntryM15;
                case 7:
                    return EntryM16;
                case 8:
                    return EntryM21;
                default:
                    return EntryM1;
            }
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            string Shop2 = Language.GetTextValue("Mods.AlchemistNPCLite.Shop2");
            string Shop3 = Language.GetTextValue("Mods.AlchemistNPCLite.Shop3");
            string ShopChanger = Language.GetTextValue("Mods.AlchemistNPCLite.ShopChanger");
            if (S1)
            {
                button = Language.GetTextValue("LegacyInterface.28");
            }
            if (S2)
            {
                button = Shop2;
            }
            if (S3)
            {
                button = Shop3;
            }
            button2 = ShopChanger;
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (firstButton)
            {
                shop = true;
                ShopChangeUIM.visible = false;
            }
            else
            {
                if(!ShopChangeUIM.visible) ShopChangeUIM.timeStart = Main.GameUpdateCount;
                ShopChangeUIM.visible = true;
            }
        }

        // IMPLEMENT WHEN WEAKREFERENCES FIXED
        /*
        public bool ThoriumModDownedGTBird
        {
            get { return ThoriumMod.ThoriumWorld.downedThunderBird; }
        }
        public bool ThoriumModDownedViscount
        {
            get { return ThoriumMod.ThoriumWorld.downedBat; }
        }
        public bool ThoriumModDownedBoreanStrider
        {
            get { return ThoriumMod.ThoriumWorld.downedStrider; }
        }
        public bool ThoriumModDownedFallenBeholder
        {
            get { return ThoriumMod.ThoriumWorld.downedFallenBeholder; }
        }
        public bool ThoriumModDownedAbyssion
        {
            get { return ThoriumMod.ThoriumWorld.downedDepthBoss; }
        }
        */

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            if (S1)
            {
                if (!NPC.downedMechBossAny)
                {
                    shop.item[nextSlot].SetDefaults(576);
                    nextSlot++;
                }
                if (NPC.downedMechBossAny)
                {
                    shop.item[nextSlot].SetDefaults(562);
                    shop.item[nextSlot].shopCustomPrice = 100000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(563);
                    shop.item[nextSlot].shopCustomPrice = 100000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(564);
                    shop.item[nextSlot].shopCustomPrice = 100000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(565);
                    shop.item[nextSlot].shopCustomPrice = 100000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(566);
                    shop.item[nextSlot].shopCustomPrice = 100000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(568);
                    shop.item[nextSlot].shopCustomPrice = 100000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(569);
                    shop.item[nextSlot].shopCustomPrice = 100000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(570);
                    shop.item[nextSlot].shopCustomPrice = 100000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(571);
                    shop.item[nextSlot].shopCustomPrice = 100000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(573);
                    shop.item[nextSlot].shopCustomPrice = 100000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(1596);
                    shop.item[nextSlot].shopCustomPrice = 100000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(1597);
                    shop.item[nextSlot].shopCustomPrice = 100000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(1598);
                    shop.item[nextSlot].shopCustomPrice = 100000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(1600);
                    shop.item[nextSlot].shopCustomPrice = 100000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(1601);
                    shop.item[nextSlot].shopCustomPrice = 100000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(1602);
                    shop.item[nextSlot].shopCustomPrice = 100000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(1603);
                    shop.item[nextSlot].shopCustomPrice = 100000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(1604);
                    shop.item[nextSlot].shopCustomPrice = 100000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(1605);
                    shop.item[nextSlot].shopCustomPrice = 100000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(1608);
                    shop.item[nextSlot].shopCustomPrice = 100000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(1610);
                    shop.item[nextSlot].shopCustomPrice = 100000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(1964);
                    shop.item[nextSlot].shopCustomPrice = 100000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(2742);
                    shop.item[nextSlot].shopCustomPrice = 100000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(3237);
                    shop.item[nextSlot].shopCustomPrice = 100000;
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(3796);
                    shop.item[nextSlot].shopCustomPrice = 100000;
                    nextSlot++;
                    if (NPC.downedPlantBoss)
                    {
                        shop.item[nextSlot].SetDefaults(567);
                        shop.item[nextSlot].shopCustomPrice = 100000;
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(572);
                        shop.item[nextSlot].shopCustomPrice = 100000;
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(574);
                        shop.item[nextSlot].shopCustomPrice = 100000;
                        nextSlot++;
                        if (NPC.downedQueenBee)
                        {
                            shop.item[nextSlot].SetDefaults(1599);
                            shop.item[nextSlot].shopCustomPrice = 100000;
                            nextSlot++;
                        }
                        if (NPC.downedGolemBoss)
                        {
                            shop.item[nextSlot].SetDefaults(1607);
                            shop.item[nextSlot].shopCustomPrice = 100000;
                            nextSlot++;
                        }
                        shop.item[nextSlot].SetDefaults(1606);
                        shop.item[nextSlot].shopCustomPrice = 100000;
                        nextSlot++;
                        if (NPC.downedMoonlord)
                        {
                            shop.item[nextSlot].SetDefaults(3044);
                            shop.item[nextSlot].shopCustomPrice = 100000;
                            nextSlot++;
                        }
                        if (NPC.downedGoblins)
                        {
                            shop.item[nextSlot].SetDefaults(3371);
                            shop.item[nextSlot].shopCustomPrice = 100000;
                            nextSlot++;
                        }
                        if (NPC.downedPirates)
                        {
                            shop.item[nextSlot].SetDefaults(3236);
                            shop.item[nextSlot].shopCustomPrice = 100000;
                            nextSlot++;
                        }
                        if (DD2Event.DownedInvasionT1)
                        {
                            shop.item[nextSlot].SetDefaults(3869);
                            shop.item[nextSlot].shopCustomPrice = 100000;
                            nextSlot++;
                        }
                        shop.item[nextSlot].SetDefaults(1609);
                        shop.item[nextSlot].shopCustomPrice = 100000;
                        nextSlot++;
                        if (NPC.downedHalloweenKing)
                        {
                            shop.item[nextSlot].SetDefaults(1963);
                            shop.item[nextSlot].shopCustomPrice = 100000;
                            nextSlot++;
                        }
                        if (NPC.downedChristmasIceQueen)
                        {
                            shop.item[nextSlot].SetDefaults(1965);
                            shop.item[nextSlot].shopCustomPrice = 100000;
                            nextSlot++;
                        }
                        if (NPC.downedMartians)
                        {
                            shop.item[nextSlot].SetDefaults(3235);
                            shop.item[nextSlot].shopCustomPrice = 100000;
                            nextSlot++;
                        }
                        if (NPC.downedMoonlord)
                        {
                            shop.item[nextSlot].SetDefaults(3370);
                            shop.item[nextSlot].shopCustomPrice = 100000;
                            nextSlot++;
                        }
                    }
                }
            }
            if (S2)
            {
                ModLoader.TryGetMod("CalamityMod", out Mod Calamity);
                ModLoader.TryGetMod("CalamityModMusic", out Mod CalamityMusic);
                if (Calamity != null && CalamityMusic != null)
                {
                    if ((bool)Calamity.Call("Downed", "desert scourge"))
                    {
                        addModItemToShop(CalamityMusic, "DesertScourgeMusicbox", 150000, ref shop, ref nextSlot);
                        addModItemToShop(CalamityMusic, "SunkenSeaMusicbox", 150000, ref shop, ref nextSlot);
                    }
                    if ((bool)Calamity.Call("Downed", "crabulon"))
                    {
                        addModItemToShop(CalamityMusic, "CrabulonMusicbox", 150000, ref shop, ref nextSlot);
                    }
                    if ((bool)Calamity.Call("Downed", "hive mind"))
                    {
                        addModItemToShop(CalamityMusic, "HiveMindMusicbox", 150000, ref shop, ref nextSlot);
                    }
                    if ((bool)Calamity.Call("Downed", "perforators"))
                    {
                        addModItemToShop(CalamityMusic, "PerforatorMusicbox", 150000, ref shop, ref nextSlot);
                    }
                    if ((bool)Calamity.Call("Downed", "slime god"))
                    {
                        addModItemToShop(CalamityMusic, "SlimeGodMusicbox", 150000, ref shop, ref nextSlot);
                        addModItemToShop(CalamityMusic, "CragMusicbox", 150000, ref shop, ref nextSlot);
                    }
                    addModItemToShop(CalamityMusic, "SirenIdleMusicbox", 150000, ref shop, ref nextSlot);
                    addModItemToShop(CalamityMusic, "SulphurousMusicbox", 150000, ref shop, ref nextSlot);
                    addModItemToShop(CalamityMusic, "HigherAbyssMusicbox", 150000, ref shop, ref nextSlot);
                    addModItemToShop(CalamityMusic, "AbyssLowerMusicbox", 150000, ref shop, ref nextSlot);
                    addModItemToShop(CalamityMusic, "VoidMusicbox", 150000, ref shop, ref nextSlot);
                    if ((bool)Calamity.Call("Downed", "cryogen"))
                    {
                        addModItemToShop(CalamityMusic, "CryogenMusicbox", 150000, ref shop, ref nextSlot);
                    }
                    if ((bool)Calamity.Call("Downed", "aquatic scourge"))
                    {
                        addModItemToShop(CalamityMusic, "AquaticScourgeMusicbox", 150000, ref shop, ref nextSlot);
                    }
                    if ((bool)Calamity.Call("Downed", "brimstone elemental"))
                    {
                        addModItemToShop(CalamityMusic, "BrimmyMusicbox", 150000, ref shop, ref nextSlot);
                    }
                    if ((bool)Calamity.Call("Downed", "calamitas doppelganger"))
                    {
                        addModItemToShop(CalamityMusic, "CalamitasMusicbox", 150000, ref shop, ref nextSlot);
                        addModItemToShop(CalamityMusic, "CalamityMusicbox", 150000, ref shop, ref nextSlot);
                    }
                    if ((bool)Calamity.Call("Downed", "leviathan"))
                    {
                        addModItemToShop(CalamityMusic, "SirenMusicbox", 150000, ref shop, ref nextSlot);
                        addModItemToShop(CalamityMusic, "LeviathanMusicbox", 150000, ref shop, ref nextSlot);
                    }
                    if ((bool)Calamity.Call("Downed", "astrum aureus"))
                    {
                        addModItemToShop(CalamityMusic, "AstralMusicbox", 150000, ref shop, ref nextSlot);
                        addModItemToShop(CalamityMusic, "AstrageldonMusicbox", 150000, ref shop, ref nextSlot);
                    }
                    if ((bool)Calamity.Call("Downed", "astrum deus"))
                    {
                        addModItemToShop(CalamityMusic, "AstrumDeusMusicbox", 150000, ref shop, ref nextSlot);
                    }
                    if ((bool)Calamity.Call("Downed", "plaguebringer goliath"))
                    {
                        addModItemToShop(CalamityMusic, "PlaguebringerMusicbox", 150000, ref shop, ref nextSlot);
                    }
                    if ((bool)Calamity.Call("Downed", "ravager"))
                    {
                        addModItemToShop(CalamityMusic, "RavagerMusicbox", 150000, ref shop, ref nextSlot);
                    }
                    if ((bool)Calamity.Call("Downed", "profaned guardians"))
                    {
                        addModItemToShop(CalamityMusic, "ProfanedGuardianMusicbox", 150000, ref shop, ref nextSlot);
                    }
                    if ((bool)Calamity.Call("Downed", "providence"))
                    {
                        addModItemToShop(CalamityMusic, "ProvidenceMusicbox", 250000, ref shop, ref nextSlot);
                    }
                    if ((bool)Calamity.Call("Downed", "stormweaver"))
                    {
                        addModItemToShop(CalamityMusic, "StormWeaverMusicbox", 150000, ref shop, ref nextSlot);
                    }
                    if ((bool)Calamity.Call("Downed", "ceaselessvoid"))
                    {
                        addModItemToShop(CalamityMusic, "CeaselessVoidMusicbox", 150000, ref shop, ref nextSlot);
                    }
                    if ((bool)Calamity.Call("Downed", "signus"))
                    {
                        addModItemToShop(CalamityMusic, "SignusMusicbox", 150000, ref shop, ref nextSlot);
                    }
                    if ((bool)Calamity.Call("Downed", "polterghast"))
                    {
                        addModItemToShop(CalamityMusic, "PolterghastMusicbox", 300000, ref shop, ref nextSlot);
                    }
                    if ((bool)Calamity.Call("Downed", "dog"))
                    {
                        addModItemToShop(CalamityMusic, "DoGMusicbox", 500000, ref shop, ref nextSlot);
                        addModItemToShop(CalamityMusic, "DoGP2Musicbox", 500000, ref shop, ref nextSlot);
                    }
                    if ((bool)Calamity.Call("Downed", "yharon"))
                    {
                        addModItemToShop(CalamityMusic, "Yharon1Musicbox", 500000, ref shop, ref nextSlot);
                        addModItemToShop(CalamityMusic, "Yharon2Musicbox", 500000, ref shop, ref nextSlot);
                        addModItemToShop(CalamityMusic, "Yharon3Musicbox", 500000, ref shop, ref nextSlot);
                    }
                    if ((bool)Calamity.Call("Downed", "supreme calamitas"))
                    {
                        addModItemToShop(CalamityMusic, "SCalGMusicbox", 500000, ref shop, ref nextSlot);
                        addModItemToShop(CalamityMusic, "SCalLMusicbox", 500000, ref shop, ref nextSlot);
                        addModItemToShop(CalamityMusic, "SCalEMusicbox", 500000, ref shop, ref nextSlot);
                        addModItemToShop(CalamityMusic, "SCalAMusicbox", 500000, ref shop, ref nextSlot);
                    }
                }
            }
            if (S3)
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Misc.BoomBox>());
                shop.item[nextSlot].shopCustomPrice = 250000;
                nextSlot++;
                // IMPLEMENT WHEN WEAKREFERENCES FIXED
                /*
                if (ModLoader.GetMod("ThoriumMod") != null)
                {
                    if (ThoriumModDownedGTBird)
                    {
                        addModItemToShop(ThoriumMod, "ThunderBirdMusicBox", 150000, ref shop, ref nextSlot);
                    }
                    if (ThoriumModDownedViscount)
                    {
                        addModItemToShop(ThoriumMod, "ViscountMusicBox", 150000, ref shop, ref nextSlot);
                    }
                    if (ThoriumModDownedBoreanStrider)
                    {
                        addModItemToShop(ThoriumMod, "BoreanStriderMusicBox", 150000, ref shop, ref nextSlot);
                    }
                    if (ThoriumModDownedFallenBeholder)
                    {
                        addModItemToShop(ThoriumMod, "FallenBeholderMusicBox", 150000, ref shop, ref nextSlot);
                    }
                    if (ThoriumModDownedAbyssion)
                    {
                        addModItemToShop(ThoriumMod, "DepthsMusicBox", 150000, ref shop, ref nextSlot);
                    }
                }
				*/
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
