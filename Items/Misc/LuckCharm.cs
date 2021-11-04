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
	public class LuckCharm : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Charm of Luck");
			Tooltip.SetDefault("While this is in your inventory, you have better chance of getting better reforges"
			+"\nDoes not affect accessories");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Талисман Удачи");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Если находится в инвентаре, вы имеете более высокий шанс получить лучшую перековку\nНе работает с аксессуарами");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.value = 1000000;
			Item.rare = 8;
		}
	}
}
