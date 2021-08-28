using System;
using System.Linq;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCLite.Items.Placeable
{
	public class MateriaTransmutator : ModItem
	{
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Same functionality as most of crafting stations in one"
            +"\nAll crafting stations included :)"
            +"\nAlso works as Water/Honey/Lava source");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Преобразователь Материи");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Выполняет функции большей части станций крафта в одной\nВсе станции крафта включены :)\nРаботает в качестве источника Воды/Мёда/Лавы");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "物质嬗变器");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "非常多制造环境的集合\n包含了所有的原版制作环境 :)\n同样可作为水/蜂蜜/岩浆环境");
        }

		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.maxStack = 99;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = 1;
			Item.consumable = true;
			Item.rare = 11;
			Item.value = 1000000;
			Item.createTile = ModContent.TileType<Tiles.MateriaTransmutator>();
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(null, "PreHMPenny")
				.AddIngredient(null, "HMCraftPound")
				.AddIngredient(null, "SpecCraftPoint")
				.AddIngredient(ItemID.ManaCrystal)
				.AddIngredient(ItemID.DD2ElderCrystalStand)

				.AddIngredient(ItemID.FragmentSolar, 10)
				.AddIngredient(ItemID.FragmentNebula, 10)
				.AddIngredient(ItemID.FragmentVortex, 10)
				.AddIngredient(ItemID.FragmentStardust, 10)
				.Register();
			// Moved out of blank space
			// if (ModLoader.GetMod("ThoriumMod") != null)
			// {
			// 	// IMPLEMENT LATER
			// 	// recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("ThoriumAnvil")));
			// 	// recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("ArcaneArmorFabricator")));
			// 	// recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("SoulForge")));
			// }
		}
	}
}