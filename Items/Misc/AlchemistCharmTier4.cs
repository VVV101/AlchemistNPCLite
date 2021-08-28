using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using AlchemistNPCLite;

namespace AlchemistNPCLite.Items.Misc
{
	public class AlchemistCharmTier4 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Alchemist Charm Tier 4");
			Tooltip.SetDefault("While this is in your inventory, you have a very high chance not to consume potion"
			+"\nAllows to use potions from Piggy Bank by Quick Buff"
			+"\nAlchemist, Brewer and Young Brewer are providing 50% discount"
			+"\nMakes potions non-consumable if Supreme Calamitas is defeated"
			+"\nBuffs duration is 50% longer");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Талисман Алхимика Четвертого Уровня");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Если находится в инвентаре, вы имеет очень большой шанс не потратить зелье\nПозволяет использовать зелья из Свиньи-Копилки с помощью клавиши Быстрого Баффа\nАлхимик, Зельеварщица и Юный Зельевар предоставляют скидку в 50%\nЗелья не будут тратиться, если побеждена Supreme Calamitas\nДлительность баффов увеличена на 50%");
        }

		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.value = 4000000;
			Item.rare = 12;
		}
		
		public override void UpdateInventory(Player player)
		{
		(player.GetModPlayer<AlchemistNPCLitePlayer>()).AlchemistCharmTier4 = true;
		(player.GetModPlayer<AlchemistNPCLitePlayer>()).DistantPotionsUse = true;
		}
		
		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(null, "AlchemistCharmTier3")
				.AddIngredient(ItemID.LunarBar, 10)
				.AddIngredient(ItemID.FragmentSolar, 5)
				.AddIngredient(ItemID.FragmentNebula, 5)
				.AddIngredient(ItemID.FragmentVortex, 5)
				.AddIngredient(ItemID.FragmentStardust, 5)
				.AddTile(TileID.LunarCraftingStation)
				.Register();
		}
	}
}
