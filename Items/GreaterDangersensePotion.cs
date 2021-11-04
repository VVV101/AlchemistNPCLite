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
     public class GreaterDangersensePotion : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Greater Dangersense Potion");
			Tooltip.SetDefault("Grants Greater Dangersense buff (light up enemy projectiles)"
			+"\nThis effect is global for all players");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Зелье Великого Чувства Опасности");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Даёт бафф Великого Чувства Опасности (подсвечивает вражеские снаряды)\nЭффект действует для всех игроков");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 20;
        }    
		public override void SetDefaults()
        {
            Item.UseSound = SoundID.Item3;
            Item.useStyle = 2;
            Item.useTurn = true;
            Item.useAnimation = 17;
            Item.useTime = 17;
            Item.maxStack = 99;
            Item.consumable = true;
            Item.width = 20;
            Item.height = 30;
            Item.value = Item.sellPrice(0, 0, 2, 0);
            Item.rare = 7;
            Item.buffType = ModContent.BuffType<Buffs.GreaterDangersense>();
            Item.buffTime = 36000;
            return;
        }
    }
}
