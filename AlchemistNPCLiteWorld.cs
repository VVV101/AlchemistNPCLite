using System.IO;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;
using static Terraria.ModLoader.ModContent;
using Terraria.WorldBuilding;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using Terraria.ModLoader.IO;
using Terraria.DataStructures;
using Microsoft.Xna.Framework.Graphics;
using AlchemistNPCLite.Interface;
using Terraria.GameContent;
using System;
using Terraria.ModLoader.Config;

namespace AlchemistNPCLite
{
    public class AlchemistNPCLiteWorld : ModSystem
    {
        private const int saveVersion = 0;
        public static bool downedDOGPumpking;
        public static bool downedDOGIceQueen;
        public static bool downedDOGMothron;
        public static bool downedSandElemental;
        private UserInterface alchemistUserInterface;
        internal ShopChangeUI alchemistUI;
        private UserInterface alchemistUserInterfaceA;
        internal ShopChangeUIA alchemistUIA;
        private UserInterface alchemistUserInterfaceO;
        internal ShopChangeUIO alchemistUIO;
        private UserInterface alchemistUserInterfaceM;
        internal ShopChangeUIM alchemistUIM;
		public static RecipeGroup AlchemistNPCLiteRecipes;

        public override void OnWorldLoad()
        {
            downedDOGIceQueen = false;
            downedDOGPumpking = false;
            downedDOGMothron = false;
            downedSandElemental = false;
            if (!Main.dedServ)
            {
                alchemistUI = new ShopChangeUI();
                alchemistUI.Activate();
                alchemistUserInterface = new UserInterface();
                alchemistUserInterface.SetState(alchemistUI);

                alchemistUIA = new ShopChangeUIA();
                alchemistUIA.Activate();
                alchemistUserInterfaceA = new UserInterface();
                alchemistUserInterfaceA.SetState(alchemistUIA);

                alchemistUIO = new ShopChangeUIO();
                alchemistUIO.Activate();
                alchemistUserInterfaceO = new UserInterface();
                alchemistUserInterfaceO.SetState(alchemistUIO);

                alchemistUIM = new ShopChangeUIM();
                alchemistUIM.Activate();
                alchemistUserInterfaceM = new UserInterface();
                alchemistUserInterfaceM.SetState(alchemistUIM);
            }
        }

        public override void SaveWorldData(TagCompound tag)
        {
            var downed = new List<string>();
            if (downedDOGPumpking) downed.Add("DOGPumpking");
            if (downedDOGIceQueen) downed.Add("DOGIceQueen");
            if (downedDOGMothron) downed.Add("DOGMothron");
            if (downedSandElemental) downed.Add("SandElemental");

            tag["downed"] = downed;
        }

        public override void NetSend(BinaryWriter writer)
        {
            BitsByte flags = new BitsByte();
            flags[0] = downedDOGPumpking;
            flags[1] = downedDOGIceQueen;
            flags[2] = downedDOGMothron;
            flags[3] = downedSandElemental;
            writer.Write(flags);
        }

        public override void NetReceive(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
            downedDOGPumpking = flags[0];
            downedDOGIceQueen = flags[1];
            downedDOGMothron = flags[2];
            downedSandElemental = flags[3];
            // As mentioned in NetSend, BitBytes can contain 8 values. If you have more, be sure to read the additional data:
            // BitsByte flags2 = reader.ReadByte();
            // downed9thBoss = flags[0];
        }

        public override void LoadWorldData(TagCompound tag)
        {
            var downed = tag.GetList<string>("downed");
            downedDOGPumpking = downed.Contains("DOGPumpking");
            downedDOGIceQueen = downed.Contains("DOGIceQueen");
            downedDOGMothron = downed.Contains("DOGMothron");
            downedSandElemental = downed.Contains("SandElemental");
        }

        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int MouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
            if (MouseTextIndex != -1)
            {
                layers.Insert(MouseTextIndex, new LegacyGameInterfaceLayer(
                    "AlchemistNPCLite: Shop Selector",
                    delegate
                    {
                        if (ShopChangeUI.visible)
                        {
                            alchemistUI.Draw(Main.spriteBatch);
                        }
                        return true;
                    },
                    InterfaceScaleType.UI)
                );
            }
            int MouseTextIndexA = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
            if (MouseTextIndexA != -1)
            {
                layers.Insert(MouseTextIndexA, new LegacyGameInterfaceLayer(
                    "AlchemistNPCLite: Shop Selector A",
                    delegate
                    {
                        if (ShopChangeUIA.visible)
                        {
                            alchemistUIA.Draw(Main.spriteBatch);
                        }
                        return true;
                    },
                    InterfaceScaleType.UI)
                );
            }
            int MouseTextIndexO = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
            if (MouseTextIndexO != -1)
            {
                layers.Insert(MouseTextIndexO, new LegacyGameInterfaceLayer(
                    "AlchemistNPCLite: Shop Selector O",
                    delegate
                    {
                        if (ShopChangeUIO.visible)
                        {
                            alchemistUIO.Draw(Main.spriteBatch);
                        }
                        return true;
                    },
                    InterfaceScaleType.UI)
                );
            }
            int MouseTextIndexM = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
            if (MouseTextIndexM != -1)
            {
                layers.Insert(MouseTextIndexM, new LegacyGameInterfaceLayer(
                    "AlchemistNPCLite: Shop Selector M",
                    delegate
                    {
                        if (ShopChangeUIM.visible)
                        {
                            alchemistUIM.Draw(Main.spriteBatch);
                        }
                        return true;
                    },
                    InterfaceScaleType.UI)
                );
            }

            int LocatorArrowIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
            if (LocatorArrowIndex != -1)
            {
                layers.Insert(LocatorArrowIndex, new LegacyGameInterfaceLayer(
                    "AlchemistNPCLite: Locator Arrow",
                    delegate
                    {
                        Player player = Main.LocalPlayer;
                        if (player.accCritterGuide && AlchemistNPCLite.modConfiguration.LifeformAnalyzer)
                        {
                            for (int v = 0; v < 200; ++v)
                            {
                                NPC npc = Main.npc[v];
                                if (npc.active && npc.rarity >= 1 && !AlchemistNPCLite.modConfiguration.DisabledLocatorNpcs.Contains(new NPCDefinition(npc.type)))
                                {
                                    // Adapted from Census mod
                                    Vector2 playerCenter = Main.LocalPlayer.Center + new Vector2(0, Main.LocalPlayer.gfxOffY);
                                    var vector = npc.Center - playerCenter;
                                    var distance = vector.Length();
                                    if (distance > 40 && distance <= AlchemistNPCLite.modConfiguration.LocatorRange)
                                    {
                                        var offset = Vector2.Normalize(vector) * Math.Min(70, distance - 20);
                                        float rotation = vector.ToRotation() + (float)(Math.PI / 2);
                                        var drawPosition = playerCenter - Main.screenPosition + offset;
                                        float fade = Math.Min(1f, (distance - 20) / 70);
										if (!AlchemistNPCLite.modConfiguration.LifeformAnalyzerAlt)
											Main.spriteBatch.Draw(ModContent.Request<Texture2D>("AlchemistNPCLite/Projectiles/LocatorProjectile").Value, drawPosition,
                                                                null, Color.White * fade, rotation, TextureAssets.Cursors[1].Size() / 2, Vector2.One, SpriteEffects.None, 0);
                                        else Main.spriteBatch.Draw(ModContent.Request<Texture2D>("AlchemistNPCLite/Projectiles/LocatorProjectileAlt").Value, drawPosition,
                                                                null, Color.White * fade, rotation, TextureAssets.Cursors[1].Size() / 2, Vector2.One, SpriteEffects.None, 0);
                                    }
                                }
                            }
                        }
                        return true;
                    }, InterfaceScaleType.Game)
                );
            }
        }
        public override void UpdateUI(GameTime gameTime)
        {
            if (alchemistUserInterface != null && ShopChangeUI.visible)
            {
                alchemistUserInterface.Update(gameTime);
            }

            if (alchemistUserInterfaceA != null && ShopChangeUIA.visible)
            {
                alchemistUserInterfaceA.Update(gameTime);
            }

            if (alchemistUserInterfaceO != null && ShopChangeUIO.visible)
            {
                alchemistUserInterfaceO.Update(gameTime);
            }

            if (alchemistUserInterfaceM != null && ShopChangeUIM.visible)
            {
                alchemistUserInterfaceM.Update(gameTime);
            }
        }
		
		public override void AddRecipeGroups()
        {
            //SBMW:Add translation to RecipeGroups, also requires to reload mod
            string evilBossMask = Language.GetTextValue("Mods.AlchemistNPCLite.evilBossMask");
            string cultist = Language.GetTextValue("Mods.AlchemistNPCLite.cultist");
            string tier3HardmodeBar = Language.GetTextValue("Mods.AlchemistNPCLite.tier3HardmodeBar");
            string hardmodeComponent = Language.GetTextValue("Mods.AlchemistNPCLite.hardmodeComponent");
            string evilBar = Language.GetTextValue("Mods.AlchemistNPCLite.evilBar");
            string evilMushroom = Language.GetTextValue("Mods.AlchemistNPCLite.evilMushroom");
            string evilComponent = Language.GetTextValue("Mods.AlchemistNPCLite.evilComponent");
            string evilDrop = Language.GetTextValue("Mods.AlchemistNPCLite.evilDrop");
            string tier2anvil = Language.GetTextValue("Mods.AlchemistNPCLite.tier2anvil");
            string tier2forge = Language.GetTextValue("Mods.AlchemistNPCLite.tier2forge");
            string tier1anvil = Language.GetTextValue("Mods.AlchemistNPCLite.tier1anvil");
            string celestialWings = Language.GetTextValue("Mods.AlchemistNPCLite.CelestialWings");
            string LunarHamaxe = Language.GetTextValue("Mods.AlchemistNPCLite.LunarHamaxe");
            string tier3Watch = Language.GetTextValue("Mods.AlchemistNPCLite.tier3Watch");
            string tier3PreHmOre = Language.GetTextValue("Mods.AlchemistNPCLite.tier3PreHmOre");

            AlchemistNPCLiteRecipes = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + evilBossMask, new int[]
         {
                 ItemID.EaterMask, ItemID.BrainMask
         });
            RecipeGroup.RegisterGroup("AlchemistNPCLite:EvilMask", AlchemistNPCLiteRecipes);
            AlchemistNPCLiteRecipes = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + cultist, new int[]
         {
                 ItemID.BossMaskCultist, ItemID.WhiteLunaticHood, ItemID.BlueLunaticHood
         });
            RecipeGroup.RegisterGroup("AlchemistNPCLite:CultistMask", AlchemistNPCLiteRecipes);
            AlchemistNPCLiteRecipes = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + tier3HardmodeBar, new int[]
         {
                 ItemID.AdamantiteBar, ItemID.TitaniumBar
         });
            RecipeGroup.RegisterGroup("AlchemistNPCLite:Tier3Bar", AlchemistNPCLiteRecipes);
            AlchemistNPCLiteRecipes = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + hardmodeComponent, new int[]
         {
                 ItemID.CursedFlame, ItemID.Ichor
         });
            RecipeGroup.RegisterGroup("AlchemistNPCLite:HardmodeComponent", AlchemistNPCLiteRecipes);
            AlchemistNPCLiteRecipes = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + evilBar, new int[]
         {
                 ItemID.DemoniteBar, ItemID.CrimtaneBar
         });
            RecipeGroup.RegisterGroup("AlchemistNPCLite:EvilBar", AlchemistNPCLiteRecipes);
            AlchemistNPCLiteRecipes = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + evilMushroom, new int[]
             {
                 ItemID.VileMushroom, ItemID.ViciousMushroom
             });
            RecipeGroup.RegisterGroup("AlchemistNPCLite:EvilMush", AlchemistNPCLiteRecipes);
            AlchemistNPCLiteRecipes = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + evilComponent, new int[]
             {
                 ItemID.ShadowScale, ItemID.TissueSample
             });
            RecipeGroup.RegisterGroup("AlchemistNPCLite:EvilComponent", AlchemistNPCLiteRecipes);
            AlchemistNPCLiteRecipes = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + evilDrop, new int[]
             {
                 ItemID.RottenChunk, ItemID.Vertebrae
             });
            RecipeGroup.RegisterGroup("AlchemistNPCLite:EvilDrop", AlchemistNPCLiteRecipes);
            AlchemistNPCLiteRecipes = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + tier2anvil, new int[]
             {
                 ItemID.MythrilAnvil, ItemID.OrichalcumAnvil
             });
            RecipeGroup.RegisterGroup("AlchemistNPCLite:AnyAnvil", AlchemistNPCLiteRecipes);
            AlchemistNPCLiteRecipes = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + tier2forge, new int[]
             {
                 ItemID.AdamantiteForge, ItemID.TitaniumForge
             });
            RecipeGroup.RegisterGroup("AlchemistNPCLite:AnyForge", AlchemistNPCLiteRecipes);
            AlchemistNPCLiteRecipes = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + tier1anvil, new int[]
             {
                 ItemID.IronAnvil, ItemID.LeadAnvil
             });
            RecipeGroup.RegisterGroup("AlchemistNPCLite:AnyPreHMAnvil", AlchemistNPCLiteRecipes);
            AlchemistNPCLiteRecipes = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + celestialWings, new int[]
             {
                 ItemID.WingsSolar, ItemID.WingsNebula, ItemID.WingsStardust, ItemID.WingsVortex
             });
            RecipeGroup.RegisterGroup("AlchemistNPCLite:AnyCelestialWings", AlchemistNPCLiteRecipes);
            AlchemistNPCLiteRecipes = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + LunarHamaxe, new int[]
             {
                 ItemID.LunarHamaxeSolar, ItemID.LunarHamaxeNebula, ItemID.LunarHamaxeStardust, ItemID.LunarHamaxeVortex
             });
            RecipeGroup.RegisterGroup("AlchemistNPCLite:AnyLunarHamaxe", AlchemistNPCLiteRecipes);
            AlchemistNPCLiteRecipes = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + tier3Watch, new int[]
             {
                 ItemID.GoldWatch, ItemID.PlatinumWatch
             });
            RecipeGroup.RegisterGroup("AlchemistNPCLite:AnyWatch", AlchemistNPCLiteRecipes);
            AlchemistNPCLiteRecipes = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + tier3PreHmOre, new int[]
             {
            	 ItemID.SilverOre, ItemID.TungstenOre
             });
            RecipeGroup.RegisterGroup("AlchemistNPCLite:AnyTier3PreHmOre", AlchemistNPCLiteRecipes);
        }
		
		public override void AddRecipes()
        {
            Recipe.Create(ItemID.Sundial)
                .AddIngredient(ItemID.CelestialStone)
                .AddIngredient(ItemID.GoldBar, 10)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();

            Recipe.Create(ItemID.Obsidian, 5)
                .AddIngredient(ItemID.StoneBlock, 10)
                .AddCondition(Condition.NearWater)
                .AddCondition(Condition.NearLava)
                .Register();

            Recipe.Create(ItemID.HoneyBlock, 5)
                .AddIngredient(ItemID.BottledHoney, 10)
                .AddCondition(Condition.NearWater)
                .AddCondition(Condition.NearHoney)
                .Register();

            Recipe.Create(ItemID.CrispyHoneyBlock, 5)
                .AddIngredient(ItemID.BottledHoney, 10)
                .AddCondition(Condition.NearLava)
                .AddCondition(Condition.NearHoney)
                .Register();

            Recipe.Create(ItemID.Stopwatch)
                .AddRecipeGroup("AlchemistNPCLite:AnyWatch")
                .AddIngredient(ItemID.HermesBoots)
                .AddIngredient(ItemID.Wire, 15)
                .AddIngredient(ItemID.Wood, 5)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();

            Recipe.Create(ItemID.DPSMeter)
                .AddRecipeGroup("AlchemistNPCLite:EvilBar", 10)
                .AddRecipeGroup("AlchemistNPCLite:AnyWatch")
                .AddIngredient(ItemID.Wire, 25)
                .AddIngredient(ItemID.Chain)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();

            Recipe.Create(ItemID.LifeformAnalyzer)
                .AddIngredient(ItemID.TallyCounter)
                .AddIngredient(ItemID.BlackLens)
                .AddIngredient(ItemID.AntlionMandible)
                .AddRecipeGroup("AlchemistNPCLite:EvilDrop")
                .AddRecipeGroup("AlchemistNPCLite:EvilComponent")
                .AddIngredient(ItemID.Feather)
                .AddIngredient(ItemID.TatteredCloth)
                .AddIngredient(ItemID.Bone)
                .AddIngredient(ItemID.Wire, 25)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();

            Recipe.Create(ItemID.PurificationPowder, 5)
                .AddIngredient(ItemID.Mushroom)
                .AddIngredient(ItemID.Daybloom)
                .AddTile(TileID.Bottles)
                .Register();

            Recipe.Create(ItemID.HallowedSeeds)
                .AddIngredient(ItemID.CorruptSeeds)
                .AddIngredient(ItemID.PurificationPowder)
                .AddIngredient(ItemID.PixieDust)
                .AddTile(TileID.Bottles)
                .Register();

            Recipe.Create(ItemID.HallowedSeeds)
                .AddIngredient(ItemID.CrimsonSeeds)
                .AddIngredient(ItemID.PurificationPowder)
                .AddIngredient(ItemID.PixieDust)
                .AddTile(TileID.Bottles)
                .Register();
        }
    }
}
