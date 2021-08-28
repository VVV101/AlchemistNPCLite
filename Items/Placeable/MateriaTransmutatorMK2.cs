using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCLite.Items.Placeable
{
	public class MateriaTransmutatorMK2 : ModItem
	{
		//Probably removed
		// public override bool Autoload(ref string name)
		// {
		// 	return ModLoader.GetMod("CalamityMod") != null;
		// }
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Materia Transmutator MK2");
			Tooltip.SetDefault("Same functionality as most of crafting stations in one"
			+"\nAdded functionality of Draedon's Forge"
			+"\nAll crafting stations included :)"
			+"\nAlso works as Water/Honey/Lava source");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Преобразователь Материи MK2");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Выполняет функции большей части станций крафта в одной\nВсе станции крафта включены :)\nДобавлена функциональность Дредоновой Печи\nРаботает в качестве источника Воды/Мёда/Лавы"); 
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "物质嬗变器 MK2");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "非常多制造环境的集合\n增加嘉登熔炉的功能\n包含了所有的制作环境 :)\n同样可作为水/蜂蜜/岩浆环境");
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
			Item.createTile = ModContent.TileType<Tiles.MateriaTransmutatorMK2>();
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(null, "MateriaTransmutator")
				// IMPLEMENT LATER
				// .AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("DraedonsForge")), 1)
				.Register();
		}
	}
}