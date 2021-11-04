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
     public class FortitudePotion : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fortitude Potion");
			Tooltip.SetDefault("Grants immunity to knockback"
			+"\nNON-CALAMITY BUFF POTION");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Зелье Стойкости");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Даёт иммунитет к отбрасыванию");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "刚毅药剂");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "极大地免疫击退\n非灾厄BUFF药剂");
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
            Item.buffType = ModContent.BuffType<Buffs.Fortitude>();           //this is where you put your Buff
            Item.buffTime = 52000;    //this is the buff duration        10 = 10 Second
            return;
        }
		
		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.Waterleaf, 1)
				.AddIngredient(ItemID.Moonglow, 1)
				.AddIngredient(ItemID.Deathweed, 1)
				.AddIngredient(ItemID.IronOre, 1)
				.AddIngredient(ItemID.StoneBlock, 1)
				.AddIngredient(ItemID.BottledWater, 1)
				.AddTile(TileID.Bottles)
				.Register();
			CreateRecipe()
				.AddIngredient(ItemID.Waterleaf, 1)
				.AddIngredient(ItemID.Moonglow, 1)
				.AddIngredient(ItemID.Deathweed, 1)
				.AddIngredient(ItemID.LeadOre, 1)
				.AddIngredient(ItemID.StoneBlock, 1)
				.AddIngredient(ItemID.BottledWater, 1)
				.AddTile(TileID.Bottles)
				.Register();
		}
    }
}
