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
	public class GlobalTeleporterUp : ModItem
	{
		public override bool IsLoadingEnabled(Mod mod) {
			return ModContent.GetInstance<ModConfiguration>().ModItems;
		}
		
		public override void SetStaticDefaults()
		{
			Item.ResearchUnlockCount = 1;
        }

		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.maxStack = 99;
			Item.value = 33333333;
			Item.rare = 11;
		}
		
		public override void UpdateInventory(Player player)
		{
			(player.GetModPlayer<AlchemistNPCLitePlayer>()).GlobalTeleporterUp = true;
		}
	}
}
