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
     public class NinjaPotion : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ninja Potion");
			Tooltip.SetDefault("Increases damage and critical chance by 5%\nGives a chance to dodge attacks and allows the ability to climb walls"
			+"\nNON-CALAMITY BUFF POTION");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Зелье Ниндзя");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Увеличивает урон и шанс критического удара любым типом на 5%\nДаёт шанс увернуться от атаки и позволяет цепляться за стены");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "忍者药剂");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "增加5%的伤害和暴击几率, 并获得忍者大师的能力");
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
            Item.value = Item.sellPrice(0, 5, 0, 0);
            Item.rare = 7;
            Item.buffType = ModContent.BuffType<Buffs.NinjaSkill>();           //this is where you put your Buff
            Item.buffTime = 36000;    //this is the buff duration        10 = 10 Second
            return;
        }
		
		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.Daybloom, 1)
				.AddIngredient(ItemID.Waterleaf, 1)
				.AddIngredient(ItemID.Fireblossom, 1)
				.AddIngredient(ItemID.Deathweed, 1)
				.AddIngredient(ItemID.HellstoneBar, 1)
				.AddIngredient(ItemID.RottenChunk, 2)
				.AddIngredient(ItemID.CursedFlame, 1)
				.AddIngredient(ItemID.SoulofNight, 3)
				.AddIngredient(ItemID.BottledWater, 1)
				.AddIngredient(ItemID.ChlorophyteOre, 1)
				.AddIngredient(ItemID.Ectoplasm, 1)
				.AddTile(TileID.Bottles)
				.Register();
			CreateRecipe()
				.AddIngredient(ItemID.Daybloom, 1)
				.AddIngredient(ItemID.Waterleaf, 1)
				.AddIngredient(ItemID.Fireblossom, 1)
				.AddIngredient(ItemID.Deathweed, 1)
				.AddIngredient(ItemID.HellstoneBar, 1)
				.AddIngredient(ItemID.Vertebrae, 2)
				.AddIngredient(ItemID.Ichor, 1)
				.AddIngredient(ItemID.SoulofNight, 3)
				.AddIngredient(ItemID.BottledWater, 1)
				.AddIngredient(ItemID.ChlorophyteOre, 1)
				.AddIngredient(ItemID.Ectoplasm, 1)
				.AddTile(TileID.Bottles)
				.Register();
		}
    }
}
