using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using AlchemistNPCLite.Items;
 
namespace AlchemistNPCLite.Items
{
     public class JungleTeleporterPotion : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Jungle Teleporter Potion");
			Tooltip.SetDefault("Teleports you to the Jungle"
			+"\nLeft click teleports to jungle plant"
			+"\nRight click teleports to living mahogany leaves");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Телепортёр к Джунглям");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Телепортирует вас в джунгли\nЛевая кнопка телепортирует к джунглевому растению\nПравая кнопка телепортирует к листьям живой махогани");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 20;
		}    
		public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.RecallPotion);
            Item.maxStack = 99;
            Item.consumable = true;
            return;
        }
		
		public override bool? UseItem(Player player)
		{
			if (Main.myPlayer == player.whoAmI)
			{
			return true;
			}
			return false;
		}
		
		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				if (Main.myPlayer == player.whoAmI)
				{
				TeleportClass.HandleTeleport(10);
				return true;
				}
			}
			if (player.altFunctionUse != 2)
			{
				if (Main.myPlayer == player.whoAmI)
				{
				TeleportClass.HandleTeleport(9);
				return true;
				}
			}
			return false;
		}
		
		public override bool CanRightClick()
        {            
            return true;
        }

        public override void RightClick(Player player)
        {
            TeleportClass.HandleTeleport(10);
        }
    }
}
