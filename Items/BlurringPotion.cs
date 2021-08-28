using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
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
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Зелье Размытия");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Даёт бафф Размытие (включает Теневое Уклонение с 30-ти секундным откатом)");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "模糊药水");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "获得模糊Buff (30秒冷却结束10秒后激活暗影躲避)\n非灾厄BUFF药剂");
        }    
		public override void SetDefaults()
        {
            Item.UseSound = SoundID.Item3;                 //this is the sound that plays when you use the item
            Item.useStyle = 2;                 //this is how the item is holded when used
            Item.useTurn = true;
            Item.useAnimation = 17;
            Item.useTime = 17;
            Item.maxStack = 99;                 //this is where you set the max stack of item
            Item.consumable = true;           //this make that the item is consumable when used
            Item.width = 18;
            Item.height = 28;
            Item.value = Item.sellPrice(0, 3, 0, 0);
            Item.rare = 7;
            Item.buffType = ModContent.BuffType<Buffs.Blurring>();           //this is where you put your Buff
            Item.buffTime = 52000;    //this is the buff duration        10 = 10 Second
            return;
        }
		
		public override void AddRecipes()
		{
            CreateRecipe()
                .AddIngredient(ItemID.Blinkroot, 1)
                .AddIngredient(ItemID.Moonglow, 1)
                .AddIngredient(ItemID.TitaniumOre, 10)
                .AddIngredient(ItemID.SoulofNight, 3)
                .AddIngredient(ItemID.SoulofSight, 1)
                .AddIngredient(ItemID.SoulofMight, 1)
                .AddIngredient(ItemID.SoulofFright, 1)
                .AddIngredient(ItemID.BottledWater, 1)
			    .AddTile(TileID.Bottles)
                .Register();
		}
    }
}
