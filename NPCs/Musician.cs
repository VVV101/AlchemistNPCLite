using AlchemistNPCLite.Interface;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.Events;
using Terraria.GameContent.Personalities;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace AlchemistNPCLite.NPCs
{
    [AutoloadHead]
    public class Musician : ModNPC
    {
        public static bool S1 = true;
        public static bool S2 = false;
        public static bool S3 = false;
		public static bool S4 = false;
		public static bool S5 = false;
		
		public static string Sh1 = "Sh1";
        public static string Sh2 = "Sh2";
        public static string Sh3 = "Sh3";
		public static string Sh4 = "Sh4";
		public static string Sh5 = "Sh5";
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

            NPC.Happiness.SetBiomeAffection<UndergroundBiome>(AffectionLevel.Like);
            NPC.Happiness.SetBiomeAffection<HallowBiome>(AffectionLevel.Love);
            NPC.Happiness.SetBiomeAffection<SnowBiome>(AffectionLevel.Dislike);

            NPC.Happiness.SetNPCAffection(NPCID.PartyGirl, AffectionLevel.Love);
            NPC.Happiness.SetNPCAffection(NPCID.Wizard, AffectionLevel.Like);
            NPC.Happiness.SetNPCAffection(NPCID.GoblinTinkerer, AffectionLevel.Dislike);
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheHallow,
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

        public override bool CanTownNPCSpawn(int numTownNPCs)/* tModPorter Suggestion: Copy the implementation of NPC.SpawnAllowed_Merchant in vanilla if you to count money, and be sure to set a flag when unlocked, so you don't count every tick. */
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
            if (Mechanic >= 0 && Main.rand.NextBool(20))
            {
                return EntryM8 + Main.npc[Mechanic].GivenName + EntryM9;
            }
            if (Wizard >= 0 && Main.rand.NextBool(20))
            {
                return EntryM10 + Main.npc[Wizard].GivenName + EntryM11;
            }
            if (Clothier >= 0 && Main.rand.NextBool(20))
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
			string Shop4 = Language.GetTextValue("Mods.AlchemistNPCLite.Shop4");
			string Shop5 = Language.GetTextValue("Mods.AlchemistNPCLite.Shop5");
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
			if (S4)
            {
                button = Shop4;
            }
			if (S5)
            {
                button = Shop5;
            }
            button2 = ShopChanger;
        }

        public override void OnChatButtonClicked(bool firstButton, ref string shopName)
        {
            if (firstButton)
            {
                shopName = ShopChangeUIM.Shop;
                ShopChangeUIM.visible = false;
            }
            else
            {
                if (!ShopChangeUIM.visible) ShopChangeUIM.timeStart = Main.GameUpdateCount;
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
		
		public override void AddShops()
        {
			var shop = new NPCShop(Type, Sh1)
				.Add(new Item(576), new Condition("", () => !NPC.downedMechBossAny))
				.Add(new Item(562) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(1600) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(564) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(1601) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(1596) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(1602) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(1603) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(1604) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(4077) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(4079) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(1597) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(566) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(1964) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(1610) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(568) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(569) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(570) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(1598) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(2742) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(571) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(573) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(3237) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(1605) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(1608) { shopCustomPrice = 100000 }, Condition.DownedPlantera)
				.Add(new Item(567) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(572) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(574) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(1599) { shopCustomPrice = 100000 }, Condition.DownedGolem)
				.Add(new Item(1607) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(5112) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(4979) { shopCustomPrice = 100000 }, Condition.DownedQueenSlime)
				.Add(new Item(1606) { shopCustomPrice = 100000 }, Condition.DownedPlantera)
				.Add(new Item(4985) { shopCustomPrice = 100000 }, Condition.DownedEmpressOfLight)
				.Add(new Item(4990) { shopCustomPrice = 100000 }, Condition.DownedDukeFishron)
				.Add(new Item(563) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(1609) { shopCustomPrice = 100000 }, Condition.DownedMechBossAny);
			shop.Register();
			shop = new NPCShop(Type, Sh2)
				.Add(new Item(3371) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(3236) { shopCustomPrice = 100000 }, Condition.DownedPirates)
				.Add(new Item(1963) { shopCustomPrice = 100000 }, Condition.DownedPumpking)
				.Add(new Item(1965) { shopCustomPrice = 100000 }, Condition.DownedIceQueen)
				.Add(new Item(3235) { shopCustomPrice = 100000 }, Condition.DownedMartians)
				.Add(new Item(3370) { shopCustomPrice = 100000 }, Condition.DownedCultist)
				.Add(new Item(3044) { shopCustomPrice = 100000 }, Condition.DownedMoonLord)
				.Add(new Item(3796) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(3869) { shopCustomPrice = 100000 }, Condition.DownedOldOnesArmyT1)
				.Add(new Item(4078) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(4080) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(4081) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(4082) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(4237) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(4356) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(4357) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(4358) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(4421) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(4606) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(4991) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(565) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(4992) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(5006) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(5362) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(5044) { shopCustomPrice = 100000 }, Condition.DownedPlantera);
			shop.Register();
			shop = new NPCShop(Type, Sh3)
				.Add(new Item(5015) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(5016) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(5014) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(5017) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(5018) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(5019) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(5020) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(5021) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(5016) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(5017) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(5018) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(5019) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(5020) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(5021) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(5022) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(5023) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(5024) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(5025) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(5026) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(5027) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(5028) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(5038) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(5040) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(5029) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(5030) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(5031) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(5033) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(5032) { shopCustomPrice = 100000 }, Condition.DownedMechBossAny)
				.Add(new Item(5034) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(5039) { shopCustomPrice = 100000 }, Condition.Hardmode)
				.Add(new Item(5037) { shopCustomPrice = 100000 }, Condition.DownedPlantera)
				.Add(new Item(5035) { shopCustomPrice = 100000 }, Condition.DownedCultist)
				.Add(new Item(5036) { shopCustomPrice = 100000 }, Condition.DownedMoonLord)
				.Add(new Item(5037) { shopCustomPrice = 100000 }, Condition.Hardmode);
			shop.Register();
			
			ModLoader.TryGetMod("CalamityMod", out Mod CalamityMod);
            ModLoader.TryGetMod("ThoriumMod", out Mod ThoriumMod);
			
			shop = new NPCShop(Type, Sh4);
			shop.Register();
			
			shop = new NPCShop(Type, Sh5);
			shop.Register();
		}

        //public override void ModifyActiveShop(string shopName, Item[] items)
        //{
        //    if (S1)
        //    {
        //        if (!NPC.downedMechBossAny)
        //        {
        //            shop.item[nextSlot].SetDefaults(576);
        //            nextSlot++;
        //        }
        //        if (NPC.downedMechBossAny)
        //        {
        //            shop.item[nextSlot].SetDefaults(562);
        //            shop.item[nextSlot].shopCustomPrice = 100000;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(563);
        //            shop.item[nextSlot].shopCustomPrice = 100000;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(564);
        //            shop.item[nextSlot].shopCustomPrice = 100000;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(565);
        //            shop.item[nextSlot].shopCustomPrice = 100000;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(566);
        //            shop.item[nextSlot].shopCustomPrice = 100000;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(568);
        //            shop.item[nextSlot].shopCustomPrice = 100000;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(569);
        //            shop.item[nextSlot].shopCustomPrice = 100000;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(570);
        //            shop.item[nextSlot].shopCustomPrice = 100000;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(571);
        //            shop.item[nextSlot].shopCustomPrice = 100000;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(573);
        //            shop.item[nextSlot].shopCustomPrice = 100000;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(1596);
        //            shop.item[nextSlot].shopCustomPrice = 100000;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(1597);
        //            shop.item[nextSlot].shopCustomPrice = 100000;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(1598);
        //            shop.item[nextSlot].shopCustomPrice = 100000;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(1600);
        //            shop.item[nextSlot].shopCustomPrice = 100000;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(1601);
        //            shop.item[nextSlot].shopCustomPrice = 100000;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(1602);
        //            shop.item[nextSlot].shopCustomPrice = 100000;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(1603);
        //            shop.item[nextSlot].shopCustomPrice = 100000;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(1604);
        //            shop.item[nextSlot].shopCustomPrice = 100000;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(1605);
        //            shop.item[nextSlot].shopCustomPrice = 100000;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(1608);
        //            shop.item[nextSlot].shopCustomPrice = 100000;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(1610);
        //            shop.item[nextSlot].shopCustomPrice = 100000;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(1964);
        //            shop.item[nextSlot].shopCustomPrice = 100000;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(2742);
        //            shop.item[nextSlot].shopCustomPrice = 100000;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(3237);
        //            shop.item[nextSlot].shopCustomPrice = 100000;
        //            nextSlot++;
        //            shop.item[nextSlot].SetDefaults(3796);
        //            shop.item[nextSlot].shopCustomPrice = 100000;
        //            nextSlot++;
        //            if (NPC.downedPlantBoss)
        //            {
        //                shop.item[nextSlot].SetDefaults(567);
        //                shop.item[nextSlot].shopCustomPrice = 100000;
        //                nextSlot++;
        //                shop.item[nextSlot].SetDefaults(572);
        //                shop.item[nextSlot].shopCustomPrice = 100000;
        //                nextSlot++;
        //                shop.item[nextSlot].SetDefaults(574);
        //                shop.item[nextSlot].shopCustomPrice = 100000;
        //                nextSlot++;
        //                if (NPC.downedQueenBee)
        //                {
        //                    shop.item[nextSlot].SetDefaults(1599);
        //                    shop.item[nextSlot].shopCustomPrice = 100000;
        //                    nextSlot++;
        //                }
        //                if (NPC.downedGolemBoss)
        //                {
        //                    shop.item[nextSlot].SetDefaults(1607);
        //                    shop.item[nextSlot].shopCustomPrice = 100000;
        //                    nextSlot++;
        //                }
        //                shop.item[nextSlot].SetDefaults(1606);
        //                shop.item[nextSlot].shopCustomPrice = 100000;
        //                nextSlot++;
        //                if (NPC.downedMoonlord)
        //                {
        //                    shop.item[nextSlot].SetDefaults(3044);
        //                    shop.item[nextSlot].shopCustomPrice = 100000;
        //                    nextSlot++;
        //                }
        //                if (NPC.downedGoblins)
        //                {
        //                    shop.item[nextSlot].SetDefaults(3371);
        //                    shop.item[nextSlot].shopCustomPrice = 100000;
        //                    nextSlot++;
        //                }
        //                if (NPC.downedPirates)
        //                {
        //                    shop.item[nextSlot].SetDefaults(3236);
        //                    shop.item[nextSlot].shopCustomPrice = 100000;
        //                    nextSlot++;
        //                }
        //                if (DD2Event.DownedInvasionT1)
        //                {
        //                    shop.item[nextSlot].SetDefaults(3869);
        //                    shop.item[nextSlot].shopCustomPrice = 100000;
        //                    nextSlot++;
        //                }
        //                shop.item[nextSlot].SetDefaults(1609);
        //                shop.item[nextSlot].shopCustomPrice = 100000;
        //                nextSlot++;
        //                if (NPC.downedHalloweenKing)
        //                {
        //                    shop.item[nextSlot].SetDefaults(1963);
        //                    shop.item[nextSlot].shopCustomPrice = 100000;
        //                    nextSlot++;
        //                }
        //                if (NPC.downedChristmasIceQueen)
        //                {
        //                    shop.item[nextSlot].SetDefaults(1965);
        //                    shop.item[nextSlot].shopCustomPrice = 100000;
        //                    nextSlot++;
        //                }
        //                if (NPC.downedMartians)
        //                {
        //                    shop.item[nextSlot].SetDefaults(3235);
        //                    shop.item[nextSlot].shopCustomPrice = 100000;
        //                    nextSlot++;
        //                }
        //                if (NPC.downedMoonlord)
        //                {
        //                    shop.item[nextSlot].SetDefaults(3370);
        //                    shop.item[nextSlot].shopCustomPrice = 100000;
        //                    nextSlot++;
        //                }
        //            }
        //        }
        //    }
        //    if (S2)
        //    {
        //        ModLoader.TryGetMod("CalamityMod", out Mod Calamity);
        //        ModLoader.TryGetMod("CalamityModMusic", out Mod CalamityMusic);
        //        if (Calamity != null && CalamityMusic != null)
        //        {
        //            if ((bool)Calamity.Call("Downed", "desert scourge"))
        //            {
        //                addModItemToShop(CalamityMusic, "DesertScourgeMusicbox", 150000, ref shop, ref nextSlot);
        //                addModItemToShop(CalamityMusic, "SunkenSeaMusicbox", 150000, ref shop, ref nextSlot);
        //            }
        //            if ((bool)Calamity.Call("Downed", "crabulon"))
        //            {
        //                addModItemToShop(CalamityMusic, "CrabulonMusicbox", 150000, ref shop, ref nextSlot);
        //            }
        //            if ((bool)Calamity.Call("Downed", "hive mind"))
        //            {
        //                addModItemToShop(CalamityMusic, "HiveMindMusicbox", 150000, ref shop, ref nextSlot);
        //            }
        //            if ((bool)Calamity.Call("Downed", "perforators"))
        //            {
        //                addModItemToShop(CalamityMusic, "PerforatorMusicbox", 150000, ref shop, ref nextSlot);
        //            }
        //            if ((bool)Calamity.Call("Downed", "slime god"))
        //            {
        //                addModItemToShop(CalamityMusic, "SlimeGodMusicbox", 150000, ref shop, ref nextSlot);
        //                addModItemToShop(CalamityMusic, "CragMusicbox", 150000, ref shop, ref nextSlot);
        //            }
        //            addModItemToShop(CalamityMusic, "SirenIdleMusicbox", 150000, ref shop, ref nextSlot);
        //            addModItemToShop(CalamityMusic, "SulphurousMusicbox", 150000, ref shop, ref nextSlot);
        //            addModItemToShop(CalamityMusic, "HigherAbyssMusicbox", 150000, ref shop, ref nextSlot);
        //            addModItemToShop(CalamityMusic, "AbyssLowerMusicbox", 150000, ref shop, ref nextSlot);
        //            addModItemToShop(CalamityMusic, "VoidMusicbox", 150000, ref shop, ref nextSlot);
        //            if ((bool)Calamity.Call("Downed", "cryogen"))
        //            {
        //                addModItemToShop(CalamityMusic, "CryogenMusicbox", 150000, ref shop, ref nextSlot);
        //            }
        //            if ((bool)Calamity.Call("Downed", "aquatic scourge"))
        //            {
        //                addModItemToShop(CalamityMusic, "AquaticScourgeMusicbox", 150000, ref shop, ref nextSlot);
        //            }
        //            if ((bool)Calamity.Call("Downed", "brimstone elemental"))
        //            {
        //                addModItemToShop(CalamityMusic, "BrimmyMusicbox", 150000, ref shop, ref nextSlot);
        //            }
        //            if ((bool)Calamity.Call("Downed", "calamitas doppelganger"))
        //            {
        //                addModItemToShop(CalamityMusic, "CalamitasMusicbox", 150000, ref shop, ref nextSlot);
        //                addModItemToShop(CalamityMusic, "CalamityMusicbox", 150000, ref shop, ref nextSlot);
        //            }
        //            if ((bool)Calamity.Call("Downed", "leviathan"))
        //            {
        //                addModItemToShop(CalamityMusic, "SirenMusicbox", 150000, ref shop, ref nextSlot);
        //                addModItemToShop(CalamityMusic, "LeviathanMusicbox", 150000, ref shop, ref nextSlot);
        //            }
        //            if ((bool)Calamity.Call("Downed", "astrum aureus"))
        //            {
        //                addModItemToShop(CalamityMusic, "AstralMusicbox", 150000, ref shop, ref nextSlot);
        //                addModItemToShop(CalamityMusic, "AstrageldonMusicbox", 150000, ref shop, ref nextSlot);
        //            }
        //            if ((bool)Calamity.Call("Downed", "astrum deus"))
        //            {
        //                addModItemToShop(CalamityMusic, "AstrumDeusMusicbox", 150000, ref shop, ref nextSlot);
        //            }
        //            if ((bool)Calamity.Call("Downed", "plaguebringer goliath"))
        //            {
        //                addModItemToShop(CalamityMusic, "PlaguebringerMusicbox", 150000, ref shop, ref nextSlot);
        //            }
        //            if ((bool)Calamity.Call("Downed", "ravager"))
        //            {
        //                addModItemToShop(CalamityMusic, "RavagerMusicbox", 150000, ref shop, ref nextSlot);
        //            }
        //            if ((bool)Calamity.Call("Downed", "profaned guardians"))
        //            {
        //                addModItemToShop(CalamityMusic, "ProfanedGuardianMusicbox", 150000, ref shop, ref nextSlot);
        //            }
        //            if ((bool)Calamity.Call("Downed", "providence"))
        //            {
        //                addModItemToShop(CalamityMusic, "ProvidenceMusicbox", 250000, ref shop, ref nextSlot);
        //            }
        //            if ((bool)Calamity.Call("Downed", "stormweaver"))
        //            {
        //                addModItemToShop(CalamityMusic, "StormWeaverMusicbox", 150000, ref shop, ref nextSlot);
        //            }
        //            if ((bool)Calamity.Call("Downed", "ceaselessvoid"))
        //            {
        //                addModItemToShop(CalamityMusic, "CeaselessVoidMusicbox", 150000, ref shop, ref nextSlot);
        //            }
        //            if ((bool)Calamity.Call("Downed", "signus"))
        //            {
        //                addModItemToShop(CalamityMusic, "SignusMusicbox", 150000, ref shop, ref nextSlot);
        //            }
        //            if ((bool)Calamity.Call("Downed", "polterghast"))
        //            {
        //                addModItemToShop(CalamityMusic, "PolterghastMusicbox", 300000, ref shop, ref nextSlot);
        //            }
        //            if ((bool)Calamity.Call("Downed", "dog"))
        //            {
        //                addModItemToShop(CalamityMusic, "DoGMusicbox", 500000, ref shop, ref nextSlot);
        //                addModItemToShop(CalamityMusic, "DoGP2Musicbox", 500000, ref shop, ref nextSlot);
        //            }
        //            if ((bool)Calamity.Call("Downed", "yharon"))
        //            {
        //                addModItemToShop(CalamityMusic, "Yharon1Musicbox", 500000, ref shop, ref nextSlot);
        //                addModItemToShop(CalamityMusic, "Yharon2Musicbox", 500000, ref shop, ref nextSlot);
        //                addModItemToShop(CalamityMusic, "Yharon3Musicbox", 500000, ref shop, ref nextSlot);
        //            }
        //            if ((bool)Calamity.Call("Downed", "supreme calamitas"))
        //            {
        //                addModItemToShop(CalamityMusic, "SCalGMusicbox", 500000, ref shop, ref nextSlot);
        //                addModItemToShop(CalamityMusic, "SCalLMusicbox", 500000, ref shop, ref nextSlot);
        //                addModItemToShop(CalamityMusic, "SCalEMusicbox", 500000, ref shop, ref nextSlot);
        //                addModItemToShop(CalamityMusic, "SCalAMusicbox", 500000, ref shop, ref nextSlot);
        //            }
        //        }
        //    }
        //    if (S3)
        //    {
        //        shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Misc.BoomBox>());
        //        shop.item[nextSlot].shopCustomPrice = 250000;
        //        nextSlot++;
        //        if (ModLoader.TryGetMod("ThoriumMod", out Mod ThoriumMod))
        //        {
        //            if ((bool)ThoriumMod.Call("GetDownedBoss", "TheGrandThunderBird"))
        //            {
        //                addModItemToShop(ThoriumMod, "ThunderBirdMusicBox", 150000, ref shop, ref nextSlot);
        //            }
        //            if ((bool)ThoriumMod.Call("GetDownedBoss", "QueenJellyfish"))
        //            {
        //                addModItemToShop(ThoriumMod, "QueenJellyfishMusicBox", 150000, ref shop, ref nextSlot);
        //            }
        //            if ((bool)ThoriumMod.Call("GetDownedBoss", "Viscount"))
        //            {
        //                addModItemToShop(ThoriumMod, "ViscountMusicBox", 150000, ref shop, ref nextSlot);
        //            }
        //            if ((bool)ThoriumMod.Call("GetDownedBoss", "GraniteEnergyStorm"))
        //            {
        //                addModItemToShop(ThoriumMod, "EnergyStormMusicBox", 150000, ref shop, ref nextSlot);
        //            }
        //            if ((bool)ThoriumMod.Call("GetDownedBoss", "BuriedChampion"))
        //            {
        //                addModItemToShop(ThoriumMod, "BuriedChampionMusicBox", 150000, ref shop, ref nextSlot);
        //            }
        //            if ((bool)ThoriumMod.Call("GetDownedBoss", "StarScouter"))
        //            {
        //                addModItemToShop(ThoriumMod, "StarScouterMusicBox", 150000, ref shop, ref nextSlot);
        //            }
        //            if ((bool)ThoriumMod.Call("GetDownedBoss", "BoreanStrider"))
        //            {
        //                addModItemToShop(ThoriumMod, "BoreanStriderMusicBox", 150000, ref shop, ref nextSlot);
        //            }
        //            if ((bool)ThoriumMod.Call("GetDownedBoss", "FallenBeholder"))
        //            {
        //                addModItemToShop(ThoriumMod, "FallenBeholderMusicBox", 150000, ref shop, ref nextSlot);
        //            }
        //            if ((bool)ThoriumMod.Call("GetDownedBoss", "Lich"))
        //            {
        //                addModItemToShop(ThoriumMod, "LichMusicBox", 150000, ref shop, ref nextSlot);
        //            }
        //            if ((bool)ThoriumMod.Call("GetDownedBoss", "ForgottenOne"))
        //            {
        //                addModItemToShop(ThoriumMod, "DepthsMusicBox", 150000, ref shop, ref nextSlot);
        //                addModItemToShop(ThoriumMod, "AbyssMusicBox", 150000, ref shop, ref nextSlot);
        //            }
        //            if ((bool)ThoriumMod.Call("GetDownedBoss", "ThePrimordials"))
        //            {
        //                addModItemToShop(ThoriumMod, "PrimordialsMusicBox", 150000, ref shop, ref nextSlot);
        //            }
        //            if ((bool)ThoriumMod.Call("GetDownedBoss", "PatchWerk") ||
        //                (bool)ThoriumMod.Call("GetDownedBoss", "CorpseBloom") ||
        //                (bool)ThoriumMod.Call("GetDownedBoss", "Illusionist"))
        //            {
        //                addModItemToShop(ThoriumMod, "MiniBossMusicBox", 150000, ref shop, ref nextSlot);
        //            }
        //        }
        //    }
        //}
    }
}
