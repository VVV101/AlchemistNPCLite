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
     public class InvincibilityPotion : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Invincibility Potion");
			Tooltip.SetDefault("Increases length of invincibility after taking damage"
			+"\nNON-CALAMITY BUFF POTION");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Зелье Неуязвимости");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Увеличивает период неуязвимости после получения урона");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "无敌药剂");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "延长受伤后的无敌时间\n非灾厄BUFF药剂");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 20;
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
            Item.width = 20;
            Item.height = 30;
            Item.value = Item.sellPrice(0, 0, 5, 0);
            Item.rare = 7;
            Item.buffType = ModContent.BuffType<Buffs.LongInvincible>();           //this is where you put your Buff
            Item.buffTime = 52000;    //this is the buff duration        10 = 10 Second
            return;
        }
		
		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.Fireblossom, 1)
				.AddIngredient(ItemID.Daybloom, 1)
				.AddIngredient(ItemID.Moonglow, 1)
				.AddIngredient(ItemID.Deathweed, 1)
				.AddIngredient(ItemID.Obsidian, 1)
				.AddIngredient(ItemID.SoulofLight, 1)
				.AddIngredient(ItemID.SoulofNight, 1)
				.AddIngredient(ItemID.BottledWater, 1)
				.AddTile(TileID.Bottles)
				.Register();
		}
    }
}
