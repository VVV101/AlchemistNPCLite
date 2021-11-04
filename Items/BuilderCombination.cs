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
     public class BuilderCombination : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Builder Combination");
			Tooltip.SetDefault("Grants buffs, which are necessary for building (Calm, Builder, Mining)");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Комбинация Строителя");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Даёт баффы, важные для строительства (Добыча, Строитель и Покой)");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "建筑师药剂包");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "获得你在建筑时需要的Buff(镇静, 建筑工, 挖矿)");
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
            Item.width = 32;
            Item.height = 32;
            Item.value = Item.sellPrice(0, 0, 5, 0);
            Item.rare = 10;
            Item.buffType = ModContent.BuffType<Buffs.BuilderComb>();           //this is where you put your Buff
            Item.buffTime = 52000;    //this is the buff duration        10 = 10 Second
            return;
        }
		
		public override void AddRecipes()
		{
            CreateRecipe()
			    .AddIngredient(ItemID.BuilderPotion, 1)
			    .AddIngredient(ItemID.CalmingPotion, 1)
			    .AddIngredient(ItemID.MiningPotion, 1)
			    .AddTile(TileID.AlchemyTable)
			    .Register();
		}
    }
}
