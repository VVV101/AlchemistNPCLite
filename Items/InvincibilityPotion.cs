using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
 
namespace AlchemistNPCLite.Items
{
     public class InvincibilityPotion : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Invincibility Potion");
			Tooltip.SetDefault("Increases length of invincibility after taking damage"
			+"\nNON-CALAMITY BUFF POTION");
			DisplayName.AddTranslation(GameCulture.Russian, "Зелье Неуязвимости");
			Tooltip.AddTranslation(GameCulture.Russian, "Увеличивает период неуязвимости после получения урона");

            DisplayName.AddTranslation(GameCulture.Chinese, "无敌药剂");
            Tooltip.AddTranslation(GameCulture.Chinese, "延长受伤后的无敌时间\n非灾厄BUFF药剂");
        }    
		public override void SetDefaults()
        {
            item.UseSound = SoundID.Item3;                 //this is the sound that plays when you use the item
            item.useStyle = 2;                 //this is how the item is holded when used
            item.useTurn = true;
            item.useAnimation = 17;
            item.useTime = 17;
            item.maxStack = 99;                 //this is where you set the max stack of item
            item.consumable = true;           //this make that the item is consumable when used
            item.width = 20;
            item.height = 30;
            item.value = Item.sellPrice(0, 0, 5, 0);
            item.rare = 7;
            item.buffType = mod.BuffType("LongInvincible");           //this is where you put your Buff
            item.buffTime = 52000;    //this is the buff duration        10 = 10 Second
            return;
        }
    }
}
