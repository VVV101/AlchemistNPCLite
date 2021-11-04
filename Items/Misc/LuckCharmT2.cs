using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using AlchemistNPCLite;

namespace AlchemistNPCLite.Items.Misc
{
	public class LuckCharmT2 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Charm of Absolute Luck");
			Tooltip.SetDefault("While this is in your inventory, you have better chance of getting better reforges"
			+"\nAlso affects accessories (Menacing->Lucky->Warding)");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Талисман Абсолютной Удачи");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Если находится в инвентаре, вы имеете более высокий шанс получить лучшую перековку\nРаботает и с аксессуарами (Грозный->Удачливый->Оберегающий)");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.value = 2000000;
			Item.rare = 10;
		}
		
		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(null, "LuckCharm")
				.AddIngredient(ItemID.ShroomiteBar, 10)
				.AddIngredient(ItemID.SoulofFright, 10)
				.AddIngredient(ItemID.SoulofSight, 10)
				.AddIngredient(ItemID.SoulofMight, 10)
				.AddTile(TileID.MythrilAnvil)
				.Register();
		}
	}
}
