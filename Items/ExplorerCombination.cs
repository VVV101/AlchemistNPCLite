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
     public class ExplorerCombination : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Explorer Combination");
			Tooltip.SetDefault("Grants buffs, which are necessary for exploring (Dangersense, Hunter, Spelunker, Night Owl, Shine, Mining, Gills, Flippers, Water Walking)");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Комбинация Исследователя");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Даёт баффы, важные для Исследователя\nПредчувствие, Охотник, Шахтёр, Ночное Зрение, Сияние, Добыча, Жабры, Ласты, Хождение по воде");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "探索者药剂包");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "获得你在探索时所需的Buff(危险感知, 狩猎, 洞穴探险, 夜猫子, 光芒, 挖矿, 鱼鳃, 脚蹼, 水上行走)");
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
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.rare = 10;
            Item.buffType = ModContent.BuffType<Buffs.ExplorerComb>();           //this is where you put your Buff
            Item.buffTime = 52000;    //this is the buff duration        10 = 10 Second
            return;
        }
		
		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.TrapsightPotion, 1)
				.AddIngredient(ItemID.HunterPotion, 1)
				.AddIngredient(ItemID.SpelunkerPotion, 1)
				.AddIngredient(ItemID.NightOwlPotion, 1)
				.AddIngredient(ItemID.ShinePotion, 1)
				.AddIngredient(ItemID.MiningPotion, 1)
				.AddTile(TileID.AlchemyTable)
				.Register();
		}
    }
}
