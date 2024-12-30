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
	public class GlobalTeleporter : ModItem
	{
		public override bool IsLoadingEnabled(Mod mod) {
			return ModContent.GetInstance<ModConfiguration>().ModItems;
		}
		
		public override void SetStaticDefaults()
		{
			Item.ResearchUnlockCount = 30;
			ItemID.Sets.WorksInVoidBag[Type] = false;
        }

		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.maxStack = 99;
			Item.value = 333333;
			Item.rare = 6;
		}
		
		public override void UpdateInventory(Player player)
		{
			(player.GetModPlayer<AlchemistNPCLitePlayer>()).GlobalTeleporter = true;
		}
	}
}
