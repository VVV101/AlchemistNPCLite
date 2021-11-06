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
     public class RangerCombination : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ranger Combination");
			Tooltip.SetDefault("Grants buffs, which are necesary for Rangers (Archery, Ammo Reservation, Wrath, Rage)");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Комбинация Стрелка");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Даёт баффы, необходимые стрелку (Лучник, Экономия Боеприпасов, Гнев, Ярость)");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "射手药剂包");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "获得一些远程Buff (箭术, 弹药储备, 暴怒, 怒气)");
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
            Item.buffType = ModContent.BuffType<Buffs.RangerComb>();           //this is where you put your Buff
            Item.buffTime = 52000;    //this is the buff duration        10 = 10 Second
            return;
        }
		
		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.ArcheryPotion, 1)
				.AddIngredient(ItemID.AmmoReservationPotion, 1)
				.AddIngredient(ItemID.WrathPotion, 1)
				.AddIngredient(ItemID.RagePotion, 1)
				.AddTile(TileID.AlchemyTable)
				.Register();
		}
    }
}
