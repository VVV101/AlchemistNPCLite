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
 
namespace AlchemistNPCLite.Items
{
     public class TempleTeleportationPotion : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Temple Teleportation Potion");
			Tooltip.SetDefault("Teleports you to Temple");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Зелье телепортации в Храм Джунглей");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Телепортирует вас в Храм Джунглей");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "神庙传送药剂");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "将你传送至神庙");
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
			TeleportClass.HandleTeleport(7);
			return true;
			}
			return false;
		}
    }
}
