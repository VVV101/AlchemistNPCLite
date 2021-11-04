using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCLite.Items.Misc
{
	public class BoomBox : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Boom Box");
			Tooltip.SetDefault("While this is in your inventory, your last inventory slot plays music boxes passively");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Бумбокс");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Если находится в инвентаре, ваш последний слот инвентаря позволяет пассивно играть музыкальным шкатулкам");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.value = 250000;
			Item.rare = 4;
		}
		
		public override void UpdateInventory(Player player)
		{
			(player.GetModPlayer<AlchemistNPCLitePlayer>()).BoomBox = true;
		}
	}
}
