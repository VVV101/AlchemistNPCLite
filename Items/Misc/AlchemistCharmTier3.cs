using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using AlchemistNPCLite;

namespace AlchemistNPCLite.Items.Misc
{
	public class AlchemistCharmTier3 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Alchemist Charm Tier 3");
			Tooltip.SetDefault("While this is in your inventory, you have a high chance not to consume potion"
			+"\nAllows to use potions from Piggy Bank by Quick Buff"
			+"\nAlchemist, Brewer and Young Brewer are providing 35% discount");
			DisplayName.AddTranslation(GameCulture.Russian, "Талисман Алхимика Третьего Уровня");
            Tooltip.AddTranslation(GameCulture.Russian, "Если находится в инвентаре, вы имеет большой шанс не потратить зелье\nПозволяет использовать зелья из Свиньи-Копилки с помощью клавиши Быстрого Баффа\nАлхимик, Зельеварщица и Юный Зельевар предоставляют скидку в 35%");
        }

		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.value = 3000000;
			item.rare = 10;
		}
		
		public override void UpdateInventory(Player player)
		{
		((AlchemistNPCLitePlayer)player.GetModPlayer(mod, "AlchemistNPCLitePlayer")).AlchemistCharmTier3 = true;
		((AlchemistNPCLitePlayer)player.GetModPlayer(mod, "AlchemistNPCLitePlayer")).DistantPotionsUse = true;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "AlchemistCharmTier2");
			recipe.AddRecipeGroup("AlchemistNPCLite:Tier3Bar", 15);
			recipe.AddRecipeGroup("AlchemistNPCLite:HardmodeComponent", 20);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
