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
     public class DungeonTeleportationPotion : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dungeon Teleportation Potion");
			Tooltip.SetDefault("Teleports you to Dungeon entrance");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Зелье телепортации в Данж");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Телепортирует вас ко входу в Данж");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "地牢传送药剂");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "将你传送至地牢入口");
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
			TeleportClass.HandleTeleport(0);
			return true;
			}
			return false;
		}
    }
}
