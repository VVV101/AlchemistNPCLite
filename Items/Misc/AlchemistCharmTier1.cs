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
	public class AlchemistCharmTier1 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Alchemist Charm Tier 1");
			Tooltip.SetDefault("While this is in your inventory, you have a low chance not to consume potion"
			+"\nAlchemist, Brewer and Young Brewer are providing 10% discount");
			DisplayName.AddTranslation(GameCulture.Russian, "Талисман Алхимика Первого Уровня");
            		Tooltip.AddTranslation(GameCulture.Russian, "Если находится в инвентаре, вы имеет малый шанс не потратить зелье\nАлхимик, Зельеварщица и Юный Зельевар предоставляют скидку в 10%");
	    		DisplayName.AddTranslation(GameCulture.Chinese, "炼金师符咒 T-1");
			Tooltip.AddTranslation(GameCulture.Chinese, "放置物品栏中时, 小概率不消耗药剂"
			+"\n炼金师, 药剂师和年轻药剂师提供10%折扣");
        }

		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.value = 0;
			item.rare = 6;
		}
		
		public override void UpdateInventory(Player player)
		{
		((AlchemistNPCLitePlayer)player.GetModPlayer(mod, "AlchemistNPCLitePlayer")).AlchemistCharmTier1 = true;
		}
	}
}
