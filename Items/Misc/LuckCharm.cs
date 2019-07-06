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
	public class LuckCharm : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Charm of Luck");
			Tooltip.SetDefault("While this is in your inventory, you have better chance of getting better reforges"
			+"\nDoes not affect accessories");
			DisplayName.AddTranslation(GameCulture.Russian, "Талисман Удачи");
            		Tooltip.AddTranslation(GameCulture.Russian, "Если находится в инвентаре, вы имеете более высокий шанс получить лучшую перековку\nНе работает с аксессуарами");
        		DisplayName.AddTranslation(GameCulture.Chinese, "幸运符咒");
			Tooltip.AddTranslation(GameCulture.Chinese, "放置于物品栏时, 重铸时有更高概率获得更好的词缀\n不能影响饰品");
	}

		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.value = 1000000;
			item.rare = 8;
		}
	}
}
