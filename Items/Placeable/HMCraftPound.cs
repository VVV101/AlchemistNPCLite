using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCLite.Items.Placeable
{
    public class HMCraftPound : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Superb Crafting Pound");
            Tooltip.SetDefault("Now you can do best stuff"
			+"\nCan be placed as crafting station");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сложный Крафтовый Фунт");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Вы можете делать крутые штуки\nМожет быть размещён как станция крафта");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "豪华手工英镑");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "现在你可以做出最棒的东西了\n可代替工作台");
        }
        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.maxStack = 1;
            Item.value = 1000000;
            Item.rare = 7;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = 1;
			Item.consumable = true;
			Item.createTile = ModContent.TileType<Tiles.HMCraftPound>();
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            	.AddIngredient(ItemID.Bookcase)
                .AddRecipeGroup("AlchemistNPCLite:AnyAnvil")
                .AddRecipeGroup("AlchemistNPCLite:AnyForge")
				.AddIngredient(ItemID.ImbuingStation)
            	.AddIngredient(ItemID.CrystalBall)
            	.AddIngredient(ItemID.Autohammer)
				.AddIngredient(ItemID.BlendOMatic)
            	.AddIngredient(ItemID.MeatGrinder)
				.AddIngredient(ItemID.LihzahrdFurnace)
            	.AddIngredient(ItemID.LunarCraftingStation)
            	.Register();
        }
    }
}
