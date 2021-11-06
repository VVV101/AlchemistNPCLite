using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCLite.Items.Placeable
{
    public class PreHMPenny : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Simple Crafting Penny");
            Tooltip.SetDefault("Makes you look like a master of carpentry"
			+"\nCan be placed as crafting station");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Простой Крафтовый Пенни");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Вы теперь мастер-слесарь\nМожет быть размещён как станция крафта");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "简易手工便士");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "这让你看起来像是个制造大湿\n可代替工作台");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
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
			Item.createTile = ModContent.TileType<Tiles.PreHMPenny>();
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            	.AddIngredient(ItemID.WorkBench)
                .AddRecipeGroup("AlchemistNPCLite:AnyPreHMAnvil")
            	.AddIngredient(ItemID.Hellforge)
            	.AddIngredient(ItemID.Loom)
            	.AddIngredient(ItemID.AlchemyTable)
            	.AddIngredient(ItemID.DyeVat)
            	.AddIngredient(ItemID.WoodenTable)
            	.AddIngredient(ItemID.WoodenChair)
            	.AddIngredient(ItemID.CookingPot)
            	.AddIngredient(ItemID.TinkerersWorkshop)
            	.AddIngredient(ItemID.HeavyWorkBench)
            	.AddIngredient(ItemID.Sawmill)
            	.Register();
        }
    }
}
