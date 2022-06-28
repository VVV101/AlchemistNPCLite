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
     public class MageCombination : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mage Combination");
			Tooltip.SetDefault("Grants buffs, which are necesary for Mages (Magic Power, Mana Regeneration, Сlairvoyance Wrath, Rage)");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Комбинация Мага");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Даёт баффы, важные для Магов (Магическая Сила, Регенерация Маны, Ясновидение, Гнев, Ярость)");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "魔法药剂包");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "获得一些魔法buff(魔能, 法力再生, 暴怒, 怒气)");
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
            Item.buffType = ModContent.BuffType<Buffs.MageComb>();           //this is where you put your Buff
            Item.buffTime = 52000;    //this is the buff duration        10 = 10 Second
            return;
        }
		
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(Item.type);
			recipe.AddIngredient(ItemID.MagicPowerPotion, 1);
			recipe.AddIngredient(ItemID.ManaRegenerationPotion, 1);
			recipe.AddIngredient(ItemID.WrathPotion, 1);
			recipe.AddIngredient(ItemID.RagePotion, 1);
			recipe.AddIngredient(ItemID.FallenStar, 5);
			recipe.AddTile(TileID.AlchemyTable);
			recipe.Register();
		}
    }
}
