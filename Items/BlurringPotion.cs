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
     public class BlurringPotion : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blurring Potion");
			Tooltip.SetDefault("Grants Blurring buff (activates Shadow Dodge for 10 sec after 30 sec CD)"
			+"\nNON-CALAMITY BUFF POTION");
			DisplayName.AddTranslation(GameCulture.Russian, "Зелье Размытия");
            Tooltip.AddTranslation(GameCulture.Russian, "Даёт бафф Размытие (включает Теневое Уклонение с 30-ти секундным откатом)");

            DisplayName.AddTranslation(GameCulture.Chinese, "模糊药水");
            Tooltip.AddTranslation(GameCulture.Chinese, "获得模糊Buff (30秒冷却结束10秒后激活暗影躲避)\n非灾厄BUFF药剂");
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
            item.width = 18;
            item.height = 28;
            item.value = Item.sellPrice(0, 3, 0, 0);
            item.rare = 7;
            item.buffType = mod.BuffType("Blurring");           //this is where you put your Buff
            item.buffTime = 52000;    //this is the buff duration        10 = 10 Second
            return;
        }
    }
}
