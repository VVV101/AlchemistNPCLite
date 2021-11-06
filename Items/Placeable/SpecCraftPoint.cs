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
    public class SpecCraftPoint : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Special Crafting Point");
            Tooltip.SetDefault("You've proven that you can do anything with any material"
			+"\nCan be placed as crafting station");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "СпецКрафтовый Поинт");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Вы доказали, что можете сделать что угодно с любым материалом\nМожет быть размещён как станция крафта");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "特殊手工位点");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "你已经证明了你可以用任何材料做出任何东西\n可代替工作台");
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
			Item.value = 10000;
			Item.createTile = ModContent.TileType<Tiles.SpecCraftPoint>();
        }

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.HoneyDispenser)
				.AddIngredient(ItemID.SteampunkBoiler)
				.AddIngredient(ItemID.FleshCloningVaat)
				.AddIngredient(ItemID.SkyMill)
				.AddIngredient(ItemID.Solidifier)
				.AddIngredient(ItemID.Keg)
				.AddIngredient(ItemID.IceMachine)
				.AddIngredient(ItemID.GlassKiln)
				.AddIngredient(ItemID.LivingLoom)
				.AddIngredient(ItemID.BoneWelder)
				.AddIngredient(ItemID.WaterBucket)
				.AddIngredient(ItemID.LavaBucket)
				.AddIngredient(ItemID.HoneyBucket)
				.AddTile(TileID.CrystalBall)
				.Register();
        }
    }
}
