using System;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using Terraria.GameContent.Creative;

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
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
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
			Recipe recipe = Recipe.Create(Item.type);
			recipe.AddIngredient(null, "PreHMPenny");
			recipe.AddIngredient(null, "HMCraftPound");
			recipe.AddIngredient(null, "SpecCraftPoint");
			recipe.AddIngredient(ItemID.ManaCrystal);
			recipe.AddIngredient(ItemID.DD2ElderCrystalStand);
			recipe.AddIngredient(ItemID.FragmentSolar, 10);
			recipe.AddIngredient(ItemID.FragmentNebula, 10);
			recipe.AddIngredient(ItemID.FragmentVortex, 10);
			recipe.AddIngredient(ItemID.FragmentStardust, 10);
            // IMPLEMENT WHEN WEAKREFERENCES FIXED
            /*
			if (ModLoader.GetMod("ThoriumMod") != null)
			{
				recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("ThoriumAnvil")));
				recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("ArcaneArmorFabricator")));
				recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("SoulForge")));
			}
			*/
			recipe.Register();
		}
	}
}