using AlchemistNPCLite.Interface;
using AlchemistNPCLite.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.Events;
using Terraria.GameContent.ItemDropRules;
using Terraria.GameContent.Personalities;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace AlchemistNPCLite.NPCs
{
    [AutoloadHead]
    public class Operator : ModNPC
    {
        public static int Shops = 1;
        public const string MaterialShop = "Materials";
        public const string ModMaterialShop = "ModMaterials";
        public const string VanillaBagsShop = "VanillaBags";
        public const string Bags1Shop = "ModBags1";
        public const string Bags2Shop = "ModBags2";
        public const string Bags3Shop = "ModBags3";
        public override string Texture
        {
            get
            {
                return "AlchemistNPCLite/NPCs/Operator";
            }
        }
        //Possibly Removed
        // public override bool Autoload(ref string name)
        // {
        // 	name = "Operator";
        // 	return true;
        // }

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 23;
            NPCID.Sets.AttackFrameCount[NPC.type] = 4;
            NPCID.Sets.DangerDetectRange[NPC.type] = 500;
            NPCID.Sets.AttackType[NPC.type] = 1;
            NPCID.Sets.AttackTime[NPC.type] = 45;
            NPCID.Sets.AttackAverageChance[NPC.type] = 30;
            NPCID.Sets.HatOffsetY[NPC.type] = -6;

            NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            {
                Velocity = -1f,
                Direction = -1
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);

            NPC.Happiness.SetBiomeAffection<OceanBiome>(AffectionLevel.Like);
            NPC.Happiness.SetBiomeAffection<SnowBiome>(AffectionLevel.Love);
            NPC.Happiness.SetBiomeAffection<UndergroundBiome>(AffectionLevel.Dislike);

            NPC.Happiness.SetNPCAffection(NPCID.Cyborg, AffectionLevel.Love);
            NPC.Happiness.SetNPCAffection(NPCID.Steampunker, AffectionLevel.Like);
            NPC.Happiness.SetNPCAffection(NPCID.Clothier, AffectionLevel.Dislike);
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Snow,
                new FlavorTextBestiaryInfoElement("Mods.AlchemistNPCLite.Bestiary.Operator")
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
            NPC.lifeMax = 1000;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.5f;
            AnimationType = NPCID.Steampunker;
        }

        public override bool CanTownNPCSpawn(int numTownNPCs)/* tModPorter Suggestion: Copy the implementation of NPC.SpawnAllowed_Merchant in vanilla if you to count money, and be sure to set a flag when unlocked, so you don't count every tick. */
        {
            if (NPC.downedBoss2 && AlchemistNPCLite.modConfiguration.OperatorSpawn)
            {
                return true;
            }
            return false;
        }

        public override List<string> SetNPCNameList()
        {
            string Angela = Language.GetTextValue("Mods.AlchemistNPCLite.Angela");
            string Carmen = Language.GetTextValue("Mods.AlchemistNPCLite.Carmen");

            return new List<string>() {
                Angela,
                Carmen
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
                damage = 75;
            }
            if (NPC.downedMoonlord)
            {
                damage = 500;
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
            attackDelay = 10;
            if (!Main.hardMode)
            {
                projType = 14;
            }
            if (Main.hardMode && !NPC.downedMoonlord)
            {
                attackDelay = 10;
                projType = 279;
            }
            if (NPC.downedMoonlord)
            {
                attackDelay = 4;
                projType = 638;
            }
        }

        public override void DrawTownAttackGun(ref Texture2D item, ref Rectangle itemFrame, ref float scale, ref int horizontalHoldoutOffset)/* tModPorter Note: closeness is now horizontalHoldoutOffset, use 'horizontalHoldoutOffset = Main.DrawPlayerItemPos(1f, itemtype) - originalClosenessValue' to adjust to the change. See docs for how to use hook with an item type. */ //Allows you to customize how this town NPC's weapon is drawn when this NPC is shooting (this NPC must have an attack type of 1). Scale is a multiplier for the item's drawing size, item is the ID of the item to be drawn, and closeness is how close the item should be drawn to the NPC.
        {
            scale = 1f;
            horizontalHoldoutOffset = 20;
            if (!Main.hardMode)
            {
                item = TextureAssets.Item[ItemID.FlintlockPistol].Value;
            }
            if (Main.hardMode && !NPC.downedMoonlord)
            {
                item = TextureAssets.Item[ItemID.Shotgun].Value;
            }
            if (NPC.downedMoonlord)
            {
                item = TextureAssets.Item[ItemID.VortexBeater].Value;
            }
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 12f;
        }


        public override string GetChat()
        {                                           //npc chat
            string EntryO1 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryO1");
            string EntryO2 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryO2");
            string EntryO3 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryO3");
            string EntryO4 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryO4");
            string EntryO5 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryO5");
            string EntryO6 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryO6");
            string EntryO7 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryO7");
            string EntryO8 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryO8");
            string EntryO9 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryO9");
            string EntryO10 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryO10");
            string EntryO11 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryO11");
            string EntryO12 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryO12");
            string EntryO13 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryO13");
            string EntryO14 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryO14");
            string EntryO15 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryO15");
            string EntryO16 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryO16");
            string EntryO17 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryO17");
            string EntryO18 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryO18");
            string EntryO19 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryO19");
            string EntryO20 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryO20");
            string EntryO21 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryO21");
            string EntryO22 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryO22");
            string EntryO23 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryO23");
            string EntryO24 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryO24");
            string EntryO25 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryO25");
            string EntryO26 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryO26");
            string EntryO27 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryO27");
            string EntryO28 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryO28");
            string EntryO29 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryO29");
            string EntryO30 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryO30");
            string EntryO31 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryO31");
            string EntryO32 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryO32");
            string EntryO33 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryO33");
            string EntryO34 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryO34");
            string EntryO35 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryO35");
            string EntryO36 = Language.GetTextValue("Mods.AlchemistNPCLite.EntryO36");

            ModLoader.TryGetMod("CalamityMod", out Mod Calamity);

            if (Main.bloodMoon)
            {
                switch (Main.rand.Next(3))
                {
                    case 0:
                        return EntryO14;
                    case 1:
                        return EntryO15;
                    case 2:
                        return EntryO16;
                }
            }
            if (Main.invasionType == 1)
            {
                return EntryO11;
            }
            if (Main.invasionType == 3)
            {
                return EntryO12;
            }
            if (Main.invasionType == 4)
            {
                return EntryO13;
            }
            if (Main.rand.NextBool(5))
            {
                if (!WorldGen.crimson)
                {
                    return EntryO5;
                }
                if (WorldGen.crimson)
                {
                    return EntryO8;
                }
            }
            if (Calamity != null && NPC.downedBoss3)
            {
                if (Main.rand.Next(7) == 0)
                {
                    return EntryO17;
                }
            }
            if (NPC.downedPlantBoss)
            {
                if (Main.rand.Next(7) == 0)
                {
                    return EntryO19;
                }
            }
            if (NPC.downedGolemBoss)
            {
                if (Main.rand.Next(7) == 0)
                {
                    return EntryO20;
                }
            }
            if (Calamity != null && NPC.downedMoonlord)
            {
                if (Main.rand.Next(7) == 0)
                {
                    return EntryO18;
                }
            }
            // IMPLEMENT WHEN WEAKREFERENCES FIXED
            /*
            if (ThoriumMod != null)
            {
            	if (Main.rand.Next(6) == 0)
            	{
            		return EntryO2;

            	} 
            }
            if (ThoriumMod != null && Main.hardMode)
            {
            	if (Main.rand.Next(6) == 0)
            	{
            	return EntryO6;
            	}
            }
            */
            if (Main.rand.NextBool(5) && Main.hardMode)
            {
                switch (Main.rand.Next(2))
                {
                    case 0:
                        return EntryO9;
                    case 1:
                        return EntryO10;
                }
            }
            if (Main.rand.NextBool(5) && NPC.downedQueenBee)
            {
                return EntryO21;
            }
            if (Calamity != null && Main.hardMode)
            {
                if (Main.rand.NextBool(5) && (bool)Calamity.Call("Downed", "plaguebringer goliath"))
                {
                    return EntryO22;
                }
                if (Main.rand.NextBool(5) && (bool)Calamity.Call("Downed", "cryogen"))
                {
                    return EntryO25;
                }
                if (Main.rand.NextBool(5) && (bool)Calamity.Call("Downed", "providence"))
                {
                    return EntryO28;
                }
                if (Main.rand.NextBool(5) && (bool)Calamity.Call("Downed", "ravager"))
                {
                    return EntryO29;
                }
                if (Main.rand.NextBool(5) && (bool)Calamity.Call("Downed", "bumblebirb"))
                {
                    return EntryO30;
                }
                if (Main.rand.NextBool(5) && (bool)Calamity.Call("Downed", "dog"))
                {
                    return EntryO31;
                }
                if (Main.rand.NextBool(5) && (bool)Calamity.Call("Downed", "supreme calamitas"))
                {
                    return EntryO33;
                }
            }
            if (ModLoader.TryGetMod("ThoriumMod", out Mod ThoriumMod) && Main.hardMode)
            {
                if (Main.rand.NextBool(5) && (bool)ThoriumMod.Call("GetDownedBoss", "FallenBeholder"))
                {
                    return EntryO23;
                }
                if (Main.rand.NextBool(5) && (bool)ThoriumMod.Call("GetDownedBoss", "StarScouter"))
                {
                    return EntryO24;
                }
            }

            // IMPLEMENT WHEN WEAKREFERENCES FIXED
            /*
            if (ModLoader.GetMod("SacredTools") != null && Main.hardMode)
            {
                if (Main.rand.NextBool(5) && SacredToolsDownedAbbadon)
                {
                    return EntryO32;
                }
            }

            if (ModLoader.GetMod("SpiritMod") != null && Main.hardMode)
            {
                if (Main.rand.NextBool(5) && SpiritModDownedStarplateRaider)
                {
                    return EntryO26;
                }
                if (Main.rand.NextBool(5) && SpiritModDownedOverseer)
                {
                    return EntryO27;
                }
            }
			*/
            switch (Main.rand.Next(6))
            {
                case 0:
                    return EntryO1;
                case 1:
                    return EntryO3;
                case 2:
                    return EntryO4;
                case 3:
                    return EntryO34;
                case 4:
                    return EntryO35;
                default:
                    return EntryO7;
            }
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            string BossDropsShop = Language.GetTextValue("Mods.AlchemistNPCLite.BossDropsShop");
            string BossDropsModsShop = Language.GetTextValue("Mods.AlchemistNPCLite.BossDropsModsShop");
            string VanillaTreasureBagsShop = Language.GetTextValue("Mods.AlchemistNPCLite.VanillaTreasureBagsShop");
            string ModdedTreasureBagsShop = Language.GetTextValue("Mods.AlchemistNPCLite.ModdedTreasureBagsShop");
            string ModdedTreasureBagsShop2 = Language.GetTextValue("Mods.AlchemistNPCLite.ModdedTreasureBagsShop2");
            string ModdedTreasureBagsShop3 = Language.GetTextValue("Mods.AlchemistNPCLite.ModdedTreasureBagsShop3");
            string ShopChanger = Language.GetTextValue("Mods.AlchemistNPCLite.ShopChanger");
            button = BossDropsShop;
            if (!Main.expertMode)
            {
                button2 = BossDropsModsShop;
            }
            if (Main.expertMode)
            {
                button2 = ShopChanger;
            }
            if (Shops == 1)
            {
                button = BossDropsShop;
            }
            if (Shops == 2)
            {
                button = BossDropsModsShop;
            }
            if (Shops == 3)
            {
                button = VanillaTreasureBagsShop;
            }
            if (Shops == 4)
            {
                button = ModdedTreasureBagsShop;
            }
            if (Shops == 5)
            {
                button = ModdedTreasureBagsShop2;
            }
            if (Shops == 6)
            {
                button = ModdedTreasureBagsShop3;
            }
        }

        public override void OnChatButtonClicked(bool firstButton, ref string shopName)
        {
            if (firstButton)
            {
                if (!Main.expertMode)
                {
                    Shops = 1;
                    shopName = MaterialShop;
                }
                if (Main.expertMode)
                {
                    shopName = ShopChangeUIO.Shop;
                    ShopChangeUIO.visible = false;
                }
            }
            else
            {
                if (!Main.expertMode)
                {
                    Shops = 2;
                    shopName = ModMaterialShop;
                }
                if (Main.expertMode)
                {
                    if (!ShopChangeUIO.visible) ShopChangeUIO.timeStart = Main.GameUpdateCount;
                    ShopChangeUIO.visible = true;
                }
            }
        }
        // IMPLEMENT WHEN WEAKREFERENCES FIXED
        /*
        public bool ThoriumModDownedGTBird
        {
            get { return ThoriumMod.ThoriumWorld.downedThunderBird; }
        }
        public bool ThoriumModDownedQueenJelly
        {
            get { return ThoriumMod.ThoriumWorld.downedJelly; }
        }
        public bool ThoriumModDownedViscount
        {
            get { return ThoriumMod.ThoriumWorld.downedBat; }
        }
        public bool ThoriumModDownedStorm
        {
            get { return ThoriumMod.ThoriumWorld.downedStorm; }
        }
        public bool ThoriumModDownedChampion
        {
            get { return ThoriumMod.ThoriumWorld.downedChampion; }
        }
        public bool ThoriumModDownedStarScout
        {
            get { return ThoriumMod.ThoriumWorld.downedScout; }
        }
        public bool ThoriumModDownedBoreanStrider
        {
            get { return ThoriumMod.ThoriumWorld.downedStrider; }
        }
        public bool ThoriumModDownedFallenBeholder
        {
            get { return ThoriumMod.ThoriumWorld.downedFallenBeholder; }
        }
        public bool ThoriumModDownedLich
        {
            get { return ThoriumMod.ThoriumWorld.downedLich; }
        }
        public bool ThoriumModDownedAbyssion
        {
            get { return ThoriumMod.ThoriumWorld.downedDepthBoss; }
        }
        public bool ThoriumModDownedRagnarok
        {
            get { return ThoriumMod.ThoriumWorld.downedRealityBreaker; }
        }

        public bool SacredToolsDownedDecree
        {
            get { return SacredTools.ModdedWorld.downedDecree; }
        }
        public bool SacredToolsDownedPumpkin
        {
            get { return SacredTools.ModdedWorld.downedPumpboi; }
        }
        public bool SacredToolsDownedHarpyPreHM
        {
            get { return SacredTools.ModdedWorld.downedHarpy; }
        }
        public bool SacredToolsDownedAraneas
        {
            get { return SacredTools.ModdedWorld.downedAraneas; }
        }
        public bool SacredToolsDownedHarpyHM
        {
            get { return SacredTools.ModdedWorld.downedRaynare; }
        }
        public bool SacredToolsDownedPrimordia
        {
            get { return SacredTools.ModdedWorld.downedPrimordia; }
        }
        public bool SacredToolsDownedAbbadon
        {
            get { return SacredTools.ModdedWorld.OblivionSpawns; }
        }
        public bool SacredToolsDownedAraghur
        {
            get { return SacredTools.ModdedWorld.FlariumSpawns; }
        }
        public bool SacredToolsDownedLunarians
        {
            get { return SacredTools.ModdedWorld.downedLunarians; }
        }
        public bool SacredToolsDownedChallenger
        {
            get { return SacredTools.ModdedWorld.downedChallenger; }
        }

        public bool SpiritModDownedScarabeus
        {
            get { return SpiritMod.MyWorld.downedScarabeus; }
        }
        public bool SpiritModDownedBane
        {
            get { return SpiritMod.MyWorld.downedReachBoss; }
        }
        public bool SpiritModDownedFlier
        {
            get { return SpiritMod.MyWorld.downedAncientFlier; }
        }
        public bool SpiritModDownedStarplateRaider
        {
            get { return SpiritMod.MyWorld.downedRaider; }
        }
        public bool SpiritModDownedInfernon
        {
            get { return SpiritMod.MyWorld.downedInfernon; }
        }
        public bool SpiritModDownedDusking
        {
            get { return SpiritMod.MyWorld.downedDusking; }
        }
        public bool SpiritModDownedEtherialUmbra
        {
            get { return SpiritMod.MyWorld.downedSpiritCore; }
        }
        public bool SpiritModDownedIlluminantMaster
        {
            get { return SpiritMod.MyWorld.downedIlluminantMaster; }
        }
        public bool SpiritModDownedAtlas
        {
            get { return SpiritMod.MyWorld.downedAtlas; }
        }
        public bool SpiritModDownedOverseer
        {
            get { return SpiritMod.MyWorld.downedOverseer; }
        }

        public bool EnigmaDownedSharkron
        {
            get { return Laugicality.LaugicalityWorld.downedDuneSharkron; }
        }
        public bool EnigmaDownedHypothema
        {
            get { return Laugicality.LaugicalityWorld.downedHypothema; }
        }
        public bool EnigmaDownedRagnar
        {
            get { return Laugicality.LaugicalityWorld.downedRagnar; }
        }
        public bool EnigmaDownedAnDio
        {
            get { return Laugicality.LaugicalityWorld.downedAnDio; }
        }
        public bool EnigmaDownedAnnihilator
        {
            get { return Laugicality.LaugicalityWorld.downedAnnihilator; }
        }
        public bool EnigmaDownedSlybertron
        {
            get { return Laugicality.LaugicalityWorld.downedSlybertron; }
        }
        public bool EnigmaDownedSteamTrain
        {
            get { return Laugicality.LaugicalityWorld.downedSteamTrain; }
        }
        public bool EnigmaDownedEtheria
        {
            get { return Laugicality.LaugicalityWorld.downedTrueEtheria; }
        }

        public bool PinkymodDownedST
        {
            get { return pinkymod.Global.Pinkyworld.downedSunlightTrader; }
        }
        public bool PinkymodDownedMS
        {
            get { return pinkymod.Global.Pinkyworld.downedMythrilSlime; }
        }
        public bool PinkymodDownedVD
        {
            get { return pinkymod.Global.Pinkyworld.downedValdaris; }
        }
        public bool PinkymodDownedAD
        {
            get { return pinkymod.Global.Pinkyworld.downedAbyssmalDuo; }
        }

        public bool AAModDownedMonarch
        {
            get { return AAMod.AAWorld.downedMonarch; }
        }
        public bool AAModDownedGrips
        {
            get { return AAMod.AAWorld.downedGrips; }
        }
        public bool AAModDownedTruffleToad
        {
            get { return AAMod.AAWorld.downedToad; }
        }
        public bool AAModDownedBrood
        {
            get { return AAMod.AAWorld.downedBrood; }
        }
        public bool AAModDownedHydra
        {
            get { return AAMod.AAWorld.downedHydra; }
        }
        public bool AAModDownedSerpent
        {
            get { return AAMod.AAWorld.downedSerpent; }
        }
        public bool AAModDownedDjinn
        {
            get { return AAMod.AAWorld.downedDjinn; }
        }
        public bool AAModDownedEquinox
        {
            get { return AAMod.AAWorld.downedEquinox; }
        }
        public bool AAModDownedSisters
        {
            get { return AAMod.AAWorld.downedSisters; }
        }
        public bool AAModDownedYamata
        {
            get { return AAMod.AAWorld.downedYamata; }
        }
        public bool AAModDownedAkuma
        {
            get { return AAMod.AAWorld.downedAkuma; }
        }
        public bool AAModDownedZero
        {
            get { return AAMod.AAWorld.downedZero; }
        }
        public bool AAModDownedShen
        {
            get { return AAMod.AAWorld.downedZero; }
        }

        public bool EADownedWasteland
        {
            get { return ElementsAwoken.MyWorld.downedWasteland; }
        }
        public bool EADownedWyrm
        {
            get { return ElementsAwoken.MyWorld.downedAncientWyrm; }
        }
        public bool EADownedInfernace
        {
            get { return ElementsAwoken.MyWorld.downedInfernace; }
        }
        public bool EADownedScourgeFighter
        {
            get { return ElementsAwoken.MyWorld.downedScourgeFighter; }
        }
        public bool EADownedRegaroth
        {
            get { return ElementsAwoken.MyWorld.downedRegaroth; }
        }
        public bool EADownedObsidious
        {
            get { return ElementsAwoken.MyWorld.downedObsidious; }
        }
        public bool EADownedPermafrost
        {
            get { return ElementsAwoken.MyWorld.downedPermafrost; }
        }
        public bool EADownedAqueous
        {
            get { return ElementsAwoken.MyWorld.downedAqueous; }
        }
        public bool EADownedGuardian
        {
            get { return ElementsAwoken.MyWorld.downedGuardian; }
        }
        public bool EADownedVolcanox
        {
            get { return ElementsAwoken.MyWorld.downedVolcanox; }
        }
        public bool EADownedVoidLevi
        {
            get { return ElementsAwoken.MyWorld.downedVoidLeviathan; }
        }
        public bool EADownedAzana
        {
            get { return ElementsAwoken.MyWorld.downedAzana; }
        }
        public bool EADownedAncients
        {
            get { return ElementsAwoken.MyWorld.downedAncients; }
        }
		*/

        //[]
        //public bool ReDownedChicken
        //{
        //    get { return Redemption.Globals.RedeBossDowned.downedKingChicken; }
        //}
        [JITWhenModsEnabled("Redemption")]
        public static class RedemptionDowned
        {
            public static bool Thorn
            {
                get { return Redemption.Globals.RedeBossDowned.downedThorn; }
            }
            public static bool Keeper
            {
                get { return Redemption.Globals.RedeBossDowned.downedKeeper; }
            }
            public static bool ReDownedSkullDigger
            {
                get { return Redemption.Globals.RedeBossDowned.downedSkullDigger; }
            }
            public static bool SeedOfInfection
            {
                get { return Redemption.Globals.RedeBossDowned.downedSeed; }
            }
            //public static bool ReDownedIEye
            //{
            //    get { return Redemption.Globals.RedeBossDowned.downedInfectedEye; }
            //}
            public static bool KingSlayer
            {
                get { return Redemption.Globals.RedeBossDowned.downedSlayer; }
            }
            public static bool OmegaCleaver
            {
                get { return Redemption.Globals.RedeBossDowned.downedOmega1; }
            }
            public static bool OmegaGigapora
            {
                get { return Redemption.Globals.RedeBossDowned.downedOmega2; }
            }
            public static bool Obliterator
            {
                get { return Redemption.Globals.RedeBossDowned.downedOmega3; }
            }
            public static bool PatientZero
            {
                get { return Redemption.Globals.RedeBossDowned.downedPZ; }
            }
            public static bool ReDownedThornRe
            {
                get { return Redemption.Globals.RedeBossDowned.downedThorn; }
            }
            public static bool ReDownedGolemRe
            {
                get { return Redemption.Globals.RedeBossDowned.downedEaglecrestGolem; }
            }
            public static bool DeityDuo
            {
                get { return Redemption.Globals.RedeBossDowned.downedADD; }
            }
            public static bool Nebuleus
            {
                get { return Redemption.Globals.RedeBossDowned.downedNebuleus; }
            }
        }

        [JITWhenModsEnabled("ShardsOfAtheria")]
        public static class ShardsConditions
        {
            public static bool DownedNova
            {
                get { return ShardsOfAtheria.Systems.ShardsDownedSystem.downedValkyrie; }
            }
        }

        [JITWhenModsEnabled("FargowiltasSouls")]
        public static class FargoDowned
        {
            public static bool Trojan
            {
                get { return FargowiltasSouls.Core.Systems.WorldSavingSystem.DownedBoss[(int)FargowiltasSouls.Core.Systems.WorldSavingSystem.Downed.TrojanSquirrel]; }
            }
            public static bool Cursed
            {
                get { return FargowiltasSouls.Core.Systems.WorldSavingSystem.DownedBoss[(int)FargowiltasSouls.Core.Systems.WorldSavingSystem.Downed.CursedCoffin]; }
            }
            public static bool Devi
            {
                get { return FargowiltasSouls.Core.Systems.WorldSavingSystem.DownedDevi; }
            }
            public static bool Banished
            {
                get { return FargowiltasSouls.Core.Systems.WorldSavingSystem.DownedBoss[(int)FargowiltasSouls.Core.Systems.WorldSavingSystem.Downed.BanishedBaron]; }
            }
            public static bool LifeLight
            {
                get { return FargowiltasSouls.Core.Systems.WorldSavingSystem.DownedBoss[(int)FargowiltasSouls.Core.Systems.WorldSavingSystem.Downed.Lifelight]; }
            }
            public static bool Cosmos
            {
                get { return FargowiltasSouls.Core.Systems.WorldSavingSystem.DownedBoss[(int)FargowiltasSouls.Core.Systems.WorldSavingSystem.Downed.CosmosChampion]; }
            }
            public static bool Abom
            {
                get { return FargowiltasSouls.Core.Systems.WorldSavingSystem.DownedAbom; }
            }
            public static bool Mutant
            {
                get { return FargowiltasSouls.Core.Systems.WorldSavingSystem.DownedMutant; }
            }
        }
            // Possibly redundant with ModGlobalNPC
            public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            base.ModifyNPCLoot(npcLoot);

            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Summoning.APMC>(), 1));
        }

        public override void AddShops()
        {
            ModLoader.TryGetMod("CalamityMod", out Mod Calamity);
            ModLoader.TryGetMod("ThoriumMod", out Mod ThoriumMod);
            ModLoader.TryGetMod("Redemption", out Mod Redemption);
            ModLoader.TryGetMod("ShardsOfAtheria", out Mod Atheria);
            ModLoader.TryGetMod("FargowiltasSouls", out Mod FargoSouls);

            #region Vaillan MaterialShop
            var shop = new NPCShop(Type, MaterialShop)
                .Add(new Item(ItemID.Lens) { shopCustomPrice = 5000 })
                .Add(new Item(ItemID.DemoniteOre) { shopCustomPrice = 1500 })
                .Add(new Item(ItemID.ShadowScale) { shopCustomPrice = 5000 })
                .Add(new Item(ItemID.RottenChunk) { shopCustomPrice = 1000 })
                .Add(new Item(ItemID.CrimtaneOre) { shopCustomPrice = 1500 })
                .Add(new Item(ItemID.TissueSample) { shopCustomPrice = 5000 })
                .Add(new Item(ItemID.Vertebrae) { shopCustomPrice = 1000 })
                .Add(new Item(ItemID.BeeWax) { shopCustomPrice = 10000 }, Condition.DownedQueenBee)
                .Add(new Item(ItemID.Stinger) { shopCustomPrice = 75000 }, Condition.DownedQueenBee)
                .Add(new Item(ItemID.JungleSpores) { shopCustomPrice = 10000 }, Condition.DownedQueenBee)
                .Add(new Item(ItemID.Vine) { shopCustomPrice = 15000 }, Condition.DownedQueenBee)
                .Add(new Item(ItemID.Feather) { shopCustomPrice = 10000 }, Condition.DownedSkeletron)
                .Add(new Item(ItemID.SharkFin) { shopCustomPrice = 10000 }, Condition.DownedSkeletron)
                .Add(new Item(ItemID.Bone) { shopCustomPrice = 500 }, Condition.DownedSkeletron)
				.Add(new Item(ItemID.FrostCore) { shopCustomPrice = 200000 }, new Condition("", () => AlchemistNPCLiteWorld.downedIceGolem))
                .Add(new Item(ItemID.AncientBattleArmorMaterial) { shopCustomPrice = 200000 }, new Condition("", () => AlchemistNPCLiteWorld.downedSandElemental))
                .Add(new Item(ItemID.SoulofLight) { shopCustomPrice = 10000 }, Condition.DownedMechBossAny)
                .Add(new Item(ItemID.SoulofNight) { shopCustomPrice = 10000 }, Condition.DownedMechBossAny)
                .Add(new Item(ItemID.SoulofFlight) { shopCustomPrice = 15000 }, Condition.DownedMechBossAny)
                .Add(new Item(ItemID.SoulofMight) { shopCustomPrice = 20000 }, new Condition("", () => NPC.downedMechBoss1))
                .Add(new Item(ItemID.SoulofSight) { shopCustomPrice = 20000 }, new Condition("", () => NPC.downedMechBoss2))
                .Add(new Item(ItemID.BlackLens) { shopCustomPrice = 200000 }, new Condition("", () => NPC.downedMechBoss2))
                .Add(new Item(ItemID.SoulofFright) { shopCustomPrice = 20000 }, new Condition("", () => NPC.downedMechBoss3))
                .Add(new Item(ItemID.HallowedBar) { shopCustomPrice = 15000 }, Condition.DownedMechBossAll)
                .Add(new Item(ItemID.Ectoplasm) { shopCustomPrice = 20000 }, new Condition("", () => NPC.downedPlantBoss))
                .Add(new Item(ItemID.FragmentSolar) { shopCustomPrice = 50000 }, new Condition("", () => NPC.downedMoonlord))
                .Add(new Item(ItemID.FragmentNebula) { shopCustomPrice = 50000 }, new Condition("", () => NPC.downedMoonlord))
                .Add(new Item(ItemID.FragmentVortex) { shopCustomPrice = 50000 }, new Condition("", () => NPC.downedMoonlord))
                .Add(new Item(ItemID.FragmentStardust) { shopCustomPrice = 50000 }, new Condition("", () => NPC.downedMoonlord));
            shop.Register();
            #endregion

            #region Mod Material Shop
            shop = new NPCShop(Type, ModMaterialShop)
            #region Alchemist
                .Add(new Item(ModContent.ItemType<Items.Misc.GlobalTeleporter>()), new Condition("", () => Main.hardMode))
                .Add(new Item(ModContent.ItemType<Items.Misc.WorldControlUnit>()) { shopCustomPrice = 3000000 }, new Condition("", () => Main.hardMode))
                .Add(new Item(ModContent.ItemType<Items.Misc.GlobalTeleporterUp>()), new Condition("", () => NPC.downedMoonlord))
            #endregion
            #region Thorium
                .AddModItemToShop(ThoriumMod, "Petal", 5000)
                .AddModItemToShop(ThoriumMod, "BrokenHeroFragment", 250000, () => NPC.downedGolemBoss)
                .AddModItemToShop(ThoriumMod, "WhiteDwarfFragment", 50000, () => NPC.downedMoonlord)
                .AddModItemToShop(ThoriumMod, "CometFragment", 50000, () => NPC.downedMoonlord)
                .AddModItemToShop(ThoriumMod, "CelestialFragment", 50000, () => NPC.downedMoonlord)
            #endregion
            #region Calamity
                .AddModItemToShop(Calamity, "TrueShadowScale", 20000, () => (bool)Calamity.Call("Downed", "hive mind"))
                .AddModItemToShop(Calamity, "BloodSample", 20000, () => (bool)Calamity.Call("Downed", "perforators"))
                .AddModItemToShop(Calamity, "EbonianGel", 25000, () => (bool)Calamity.Call("Downed", "slime god"))
                .AddModItemToShop(Calamity, "PurifiedGel", 30000, () => (bool)Calamity.Call("Downed", "slime god"))
                .AddModItemToShop(Calamity, "UnholyCore", 100000, () => (bool)Calamity.Call("Downed", "calamitas doppelganger"))
                .AddModItemToShop(Calamity, "EssenceofEleum", 25000, () => NPC.downedPlantBoss || (bool)Calamity.Call("Downed", "cryogen"))
                .AddModItemToShop(Calamity, "EssenceofCinder", 25000, () => NPC.downedPlantBoss || (bool)Calamity.Call("Downed", "aquatic scourge"))
                .AddModItemToShop(Calamity, "EssenceofChaos", 25000, () => NPC.downedPlantBoss || (bool)Calamity.Call("Downed", "brimstone elemental"))
                //.addModItemToShop(Calamity, "Tenebris", 30000, () => NPC.downedPlantBoss)
                .AddModItemToShop(Calamity, "Lumenite", 50000, () => NPC.downedPlantBoss)
                .AddModItemToShop(Calamity, "DepthCells", 30000, () => NPC.downedPlantBoss)
                .AddModItemToShop(Calamity, "AstralJelly", 50000, () => (bool)Calamity.Call("Downed", "astrum aureus"))
                .AddModItemToShop(Calamity, "Stardust", 10000, () => (bool)Calamity.Call("Downed", "astrum aureus"))
                .AddModItemToShop(Calamity, "LivingShard", 30000, () => (bool)Calamity.Call("Downed", "leviathan"))
                .AddModItemToShop(Calamity, "SolarVeil", 50000, () => NPC.downedPlantBoss)
                .AddModItemToShop(Calamity, "BarofLife", 100000, () => (bool)Calamity.Call("Downed", "ravager"))
                .AddModItemToShop(Calamity, "MeldBlob", 10000, () => (bool)Calamity.Call("Downed", "astrum deus"))
                .AddModItemToShop(Calamity, "UnholyEssence", 50000, () => (bool)Calamity.Call("Downed", "profaned guardians"))
                .AddModItemToShop(Calamity, "BloodOrb", 50000, () => (bool)Calamity.Call("Downed", "polterghast"))
                .AddModItemToShop(Calamity, "Phantoplasm", 100000, () => (bool)Calamity.Call("Downed", "polterghast"))
                .AddModItemToShop(Calamity, "NightmareFuel", 120000, () => (bool)Calamity.Call("Downed", "dog") && AlchemistNPCLiteWorld.downedDOGPumpking)
                .AddModItemToShop(Calamity, "EndothermicEnergy", 120000, () => (bool)Calamity.Call("Downed", "dog") && AlchemistNPCLiteWorld.downedDOGIceQueen)
                .AddModItemToShop(Calamity, "DarksunFragment", 150000, () => (bool)Calamity.Call("Downed", "dog") && AlchemistNPCLiteWorld.downedDOGMothron)
            #endregion
            #region Fargo
                .AddModItemToShop(FargoSouls, "DeviatingEnergy", Item.sellPrice(0, 1,50,0),() => FargoDowned.Devi)
                .AddModItemToShop(FargoSouls, "Eridanium", Item.sellPrice(0, 8, 50, 0), () => FargoDowned.Cosmos)
                .AddModItemToShop(FargoSouls, "AbomEnergy", Item.sellPrice(0, 6, 50, 0), () => FargoDowned.Abom)
                .AddModItemToShop(FargoSouls, "EternalEnergy", Item.sellPrice(0, 9, 50, 0), () => FargoDowned.Mutant)
            #endregion
            #region Spirit
                //if (ModLoader.GetMod("SpiritMod") != null)
                //{
                //    .addModItemToShop(SpiritMod, "BrokenParts", 500000, NPC.downedGolemBoss);
                //    .addModItemToShop(SpiritMod, "BrokenStaff", 500000, NPC.downedGolemBoss);
                //}
                //if (ModLoader.GetMod("LithosArmory") != null)
                //{
                //    .addModItemToShop(LithosArmory, "BrokenHeroFlail", 500000, NPC.downedGolemBoss);
                //    .addModItemToShop(LithosArmory, "BrokenHeroGreatbow", 500000, NPC.downedGolemBoss);
                //    .addModItemToShop(LithosArmory, "BrokenHeroShotgun", 500000, NPC.downedGolemBoss);
                //    .addModItemToShop(LithosArmory, "BrokenHeroSling", 500000, NPC.downedGolemBoss);
                //    .addModItemToShop(LithosArmory, "BrokenHeroSpear", 500000, NPC.downedGolemBoss);
                //    .addModItemToShop(LithosArmory, "BrokenHeroWand", 500000, NPC.downedGolemBoss);
                //}
            #endregion
            #region Atheria
                .AddModItemToShop(Atheria, "EmptyNeedle", 500)
                .AddModItemToShop(Atheria, "SoulOfDaylight", 1000)
                .AddModItemToShop(Atheria, "SoulOfTwilight", 1000)
                .AddModItemToShop(Atheria, "SoulOfSpite", 1000)
                .AddModItemToShop(Atheria, "AreusShard", 10000, Condition.DownedEowOrBoc)
                .AddModItemToShop(Atheria, "HardlightPrism", 15000, () => ShardsConditions.DownedNova)
                .AddModItemToShop(Atheria, "BrokenHeroGun", 45000, Condition.DownedGolem)
                .AddModItemToShop(Atheria, "FragmentEntropy", 180000, Condition.DownedMoonLord)
                .AddModItemToShop(Atheria, "MemoryFragment", 10000, Condition.DownedMoonLord);
            #endregion
            shop.Register();
            #endregion

            #region VanillaBagsShop
            shop = new NPCShop(Type, VanillaBagsShop)
                .Add(new Item(ModContent.ItemType<Items.Notes.InformatingNote>()) { shopCustomPrice = 30000 },
                    new Condition("", () => !NPC.downedBoss3))
                .Add(new Item(ItemID.KingSlimeBossBag) { shopCustomPrice = 500000 },
                    new Condition("", () => NPC.downedBoss3 && Main.expertMode))
                .Add(new Item(ItemID.EyeOfCthulhuBossBag) { shopCustomPrice = 700000 },
                    new Condition("", () => NPC.downedBoss3 && Main.expertMode))
                .Add(new Item(ItemID.EaterOfWorldsBossBag) { shopCustomPrice = 1000000 },
                    new Condition("", () => NPC.downedBoss3 && Main.expertMode))
                .Add(new Item(ItemID.BrainOfCthulhuBossBag) { shopCustomPrice = 1000000 },
                    new Condition("", () => NPC.downedBoss3 && Main.expertMode))
                .Add(new Item(ItemID.QueenBeeBossBag) { shopCustomPrice = 1250000 },
                    new Condition("", () => NPC.downedBoss3 && Main.expertMode))
                .Add(new Item(ItemID.SkeletronBossBag) { shopCustomPrice = 1000000 },
                    new Condition("", () => NPC.downedBoss3 && Main.expertMode))
                .Add(new Item(ItemID.DeerclopsBossBag) { shopCustomPrice = 1500000 },
                    new Condition("", () => NPC.downedBoss3 && Main.expertMode && NPC.downedDeerclops))
                .AddModItemToShop(ThoriumMod, "DarkMageBag", 1000000, () => NPC.downedBoss3 && Main.expertMode && DD2Event.DownedInvasionT1)
                .Add(new Item(ItemID.WallOfFleshBossBag) { shopCustomPrice = 2750000 },
                    new Condition("", () => NPC.downedBoss3 && Main.expertMode && Main.hardMode))
                .Add(new Item(ItemID.QueenSlimeBossBag) { shopCustomPrice = 3000000 },
                    new Condition("", () => NPC.downedBoss3 && Main.expertMode && NPC.downedQueenSlime))
                .Add(new Item(ItemID.DestroyerBossBag) { shopCustomPrice = 4000000 },
                    new Condition("", () => NPC.downedBoss3 && Main.expertMode && NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3))
                .Add(new Item(ItemID.TwinsBossBag) { shopCustomPrice = 4000000 },
                    new Condition("", () => NPC.downedBoss3 && Main.expertMode && NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3))
                .Add(new Item(ItemID.SkeletronPrimeBossBag) { shopCustomPrice = 4000000 },
                    new Condition("", () => NPC.downedBoss3 && Main.expertMode && NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3))
                .AddModItemToShop(ThoriumMod, "OgreBag", 1000000, () => NPC.downedBoss3 && Main.expertMode && DD2Event.DownedInvasionT2 && NPC.downedMechBossAny)
                .Add(new Item(ItemID.PlanteraBossBag) { shopCustomPrice = 5000000 },
                    new Condition("", () => NPC.downedBoss3 && Main.expertMode && NPC.downedPlantBoss))
                .Add(new Item(ItemID.FairyQueenBossBag) { shopCustomPrice = 5000000 },
                    new Condition("", () => NPC.downedBoss3 && Main.expertMode && NPC.downedEmpressOfLight))
                .Add(new Item(ItemID.GolemBossBag) { shopCustomPrice = 6000000 },
                    new Condition("", () => NPC.downedBoss3 && Main.expertMode && NPC.downedGolemBoss))
                .Add(new Item(ItemID.BossBagBetsy) { shopCustomPrice = 7000000 },
                    new Condition("", () => NPC.downedBoss3 && Main.expertMode && DD2Event.DownedInvasionT3 && NPC.downedGolemBoss))
                .Add(new Item(ItemID.FishronBossBag) { shopCustomPrice = 7000000 },
                    new Condition("", () => NPC.downedBoss3 && Main.expertMode && NPC.downedFishron))
                .Add(new Item(ItemID.MoonLordBossBag) { shopCustomPrice = 12000000 },
                    new Condition("", () => NPC.downedBoss3 && Main.expertMode && NPC.downedMoonlord));
            shop.Register();
            #endregion

            #region Bags 1 Shop - Calamity & Thorium
            shop = new NPCShop(Type, Bags1Shop)
            #region Calamaity Part
                .AddModItemToShop(Calamity, "DesertScourgeBag", 375000, () => (bool)Calamity.Call("Downed", "desert scourge"))
                .AddModItemToShop(Calamity, "CrabulonBag", 700000, () => (bool)Calamity.Call("Downed", "crabulon"))
                .AddModItemToShop(Calamity, "HiveMindBag", 1000000, () => (bool)Calamity.Call("Downed", "hive mind") || (bool)Calamity.Call("Downed", "perforators"))
                .AddModItemToShop(Calamity, "PerforatorBag", 1000000, () => (bool)Calamity.Call("Downed", "hive mind") || (bool)Calamity.Call("Downed", "perforators"))
                .AddModItemToShop(Calamity, "SlimeGodBag", 1000000, () => (bool)Calamity.Call("Downed", "slime god"))
                .AddModItemToShop(Calamity, "CryogenBag", 2000000, () => (bool)Calamity.Call("Downed", "cryogen"))
                .AddModItemToShop(Calamity, "AquaticScourgeBag", 2000000, () => (bool)Calamity.Call("Downed", "aquatic scourge"))
                .AddModItemToShop(Calamity, "BrimstoneWaifuBag", 5000000, () => (bool)Calamity.Call("Downed", "brimstone elemental"))
                .AddModItemToShop(Calamity, "CalamitasBag", 5000000, () => (bool)Calamity.Call("Downed", "calamitas doppelganger"))
                .AddModItemToShop(Calamity, "LeviathanBag", 4250000, () => (bool)Calamity.Call("Downed", "leviathan"))
                .AddModItemToShop(Calamity, "AstrageldonBag", 5000000, () => (bool)Calamity.Call("Downed", "astrum aureus"))
                .AddModItemToShop(Calamity, "PlaguebringerGoliathBag", 5750000, () => (bool)Calamity.Call("Downed", "plaguebringer goliath"))
                .AddModItemToShop(Calamity, "RavagerBag", 5500000, () => (bool)Calamity.Call("Downed", "ravager"))
                .AddModItemToShop(Calamity, "AstrumDeusBag", 6500000, () => (bool)Calamity.Call("Downed", "astrum deus"))
                .AddModItemToShop(Calamity, "BumblebirbBag", 8500000, () => (bool)Calamity.Call("Downed", "dragonfolly"))
                .AddModItemToShop(Calamity, "ProvidenceBag", 22000000, () => (bool)Calamity.Call("Downed", "providence"))
                .AddModItemToShop(Calamity, "StormWeaverBag", 12500000, () => (bool)Calamity.Call("Downed", "stormweaver"))
                .AddModItemToShop(Calamity, "CeaselessVoidBag", 12500000, () => (bool)Calamity.Call("Downed", "ceaselessvoid"))
                .AddModItemToShop(Calamity, "SignusBag", 12500000, () => (bool)Calamity.Call("Downed", "signus"))
                .AddModItemToShop(Calamity, "PolterghastBag", 22500000, () => (bool)Calamity.Call("Downed", "polterghast"))
                .AddModItemToShop(Calamity, "OldDukeBag", 25000000, () => (bool)Calamity.Call("Downed", "old duke"))
                .AddModItemToShop(Calamity, "DevourerofGodsBag", 25000000, () => (bool)Calamity.Call("Downed", "dog"))
                .AddModItemToShop(Calamity, "YharonBag", 75000000, () => (bool)Calamity.Call("Downed", "yharon"))
                .AddModItemToShop(Calamity, "DraedonTreasureBag", 115000000, () => (bool)Calamity.Call("Downed", "exomechs"))
                .AddModItemToShop(Calamity, "SCalBag", 200000000, () => (bool)Calamity.Call("Downed", "supremecalamitas"))
            #endregion

            #region Thorium Part
                .AddModItemToShop(ThoriumMod, "ThunderBirdBag", 500000, () => (bool)ThoriumMod.Call("GetDownedBoss", "TheGrandThunderBird"))
                .AddModItemToShop(ThoriumMod, "JellyFishBag", 750000, () => (bool)ThoriumMod.Call("GetDownedBoss", "QueenJellyfish"))
                .AddModItemToShop(ThoriumMod, "CountBag", 850000, () => (bool)ThoriumMod.Call("GetDownedBoss", "Viscount"))
                .AddModItemToShop(ThoriumMod, "GraniteBag", 1000000, () => (bool)ThoriumMod.Call("GetDownedBoss", "GraniteEnergyStorm"))
                .AddModItemToShop(ThoriumMod, "HeroBag", 1000000, () => (bool)ThoriumMod.Call("GetDownedBoss", "BuriedChampion"))
                .AddModItemToShop(ThoriumMod, "ScouterBag", 1250000, () => (bool)ThoriumMod.Call("GetDownedBoss", "StarScouter"))
                .AddModItemToShop(ThoriumMod, "BoreanBag", 1500000, () => (bool)ThoriumMod.Call("GetDownedBoss", "BoreanStrider"))
                .AddModItemToShop(ThoriumMod, "BeholderBag", 2000000, () => (bool)ThoriumMod.Call("GetDownedBoss", "FallenBeholder"))
                .AddModItemToShop(ThoriumMod, "LichBag", 3000000, () => (bool)ThoriumMod.Call("GetDownedBoss", "Lich"))
                .AddModItemToShop(ThoriumMod, "AbyssionBag", 3500000, () => (bool)ThoriumMod.Call("GetDownedBoss", "ForgottenOne"))
                .AddModItemToShop(ThoriumMod, "RagBag", 5000000, () => (bool)ThoriumMod.Call("GetDownedBoss", "ThePrimordials"))
            #endregion
                ;
            shop.Register();
            #endregion

            #region Bags 2 Shop - Fargo
            shop = new NPCShop(Type, Bags2Shop)
                 .AddModItemToShop(FargoSouls, "TrojanSquirrelBag", Item.buyPrice(0,20,0,0), () => FargoDowned.Trojan)
                 .AddModItemToShop(FargoSouls, "CursedCoffinBag", Item.buyPrice(0, 29, 0, 0), () => FargoDowned.Cursed)
                 .AddModItemToShop(FargoSouls, "DeviBag", Item.buyPrice(1, 0, 0, 0), () => FargoDowned.Devi)
                 .AddModItemToShop(FargoSouls, "BanishedBaronBag", Item.buyPrice(1, 25, 0, 0), () => FargoDowned.Banished)
                 .AddModItemToShop(FargoSouls, "LifelightBag", Item.buyPrice(1, 60, 0, 0), () => FargoDowned.LifeLight)
                 .AddModItemToShop(FargoSouls, "CosmosBag", Item.buyPrice(20, 60, 0, 0), () => FargoDowned.Cosmos)
                 .AddModItemToShop(FargoSouls, "AbomBag", Item.buyPrice(30, 60, 0, 0), () => FargoDowned.Abom)
                 .AddModItemToShop(FargoSouls, "MutantBag", Item.buyPrice(40, 60, 0, 0), () => FargoDowned.Mutant)
                ;

            //.AddModItemToShop(Atheria, "NovaBossBag", 1500000, () => FargoDowned.Trojan);
            shop.Register();
            #endregion

            #region Bags 3 Shop - Redemption
            shop = new NPCShop(Type, Bags3Shop)
                //.addModItemToShop(Redemption, "KingChickenBag", 150000, () => Operator.RedemptionDowned.ReDownedChicken)
                .AddModItemToShop(Redemption, "ThornBag", 250000, () => RedemptionDowned.Thorn)
                .AddModItemToShop(Redemption, "KeeperBag", 350000, () => RedemptionDowned.Keeper)
                //.addModItemToShop(Redemption, "XenomiteCrystalBag", 500000, () => RedemptionDowned.ReDownedCrystal)
                //.addModItemToShop(Redemption, "InfectedEyeBag", 1000000, () => RedemptionDowned.ReDownedIEye)
                .AddModItemToShop(Redemption, "SoIBag", 1000000, () => RedemptionDowned.SeedOfInfection)
                .AddModItemToShop(Redemption, "SlayerBag", 1500000, () => RedemptionDowned.KingSlayer)
                .AddModItemToShop(Redemption, "OmegaGigaporaBag", 3000000, () => RedemptionDowned.OmegaGigapora)
                .AddModItemToShop(Redemption, "OmegaOblitBag", 5000000, () => RedemptionDowned.Obliterator)
                .AddModItemToShop(Redemption, "PZBag", 6000000, () => RedemptionDowned.PatientZero)
                .AddModItemToShop(Redemption, "UkkoBag", 6000000, () => RedemptionDowned.DeityDuo)
                .AddModItemToShop(Redemption, "AkkaBag", 6000000, () => RedemptionDowned.DeityDuo)
                .AddModItemToShop(Redemption, "NebBag", 10000000, () => RedemptionDowned.Nebuleus)
                ;
            shop.Register();
            #endregion
        }
    }
}