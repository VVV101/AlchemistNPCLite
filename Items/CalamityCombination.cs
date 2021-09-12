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
    public class CalamityCombination : ModItem
    {
        // Probably removed
		// public override bool Autoload(ref string name)
		// {
		// return ModLoader.GetMod("CalamityMod") != null;
		// }
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Calamity Combination");
			Tooltip.SetDefault("Grants most buffs from Calamity Mod potions (Yharim's Stimulants, Cadence, Titan Scale, Soaring, Bounding and Fabsol's Vodka)");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Комбинация Calamity");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Даёт большинство баффов от зелий мода Calamity (Стимулянты Ярима, Каденции, Титановой Чешуи, Полёта, Связующее и Водки Фабсола)");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "灾厄药剂包");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "给予大部分灾厄药剂的增益效果 (Yharim之力, 舒畅, 泰坦鳞片, 节奏大师, 全知)");
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
            Item.value = Item.sellPrice(0, 10, 0, 0);
            Item.rare = 10;
            Item.buffType = Item.buffType = ModContent.BuffType<Buffs.CalamityComb>();           //this is where you put your Buff
            Item.buffTime = 52000;    //this is the buff duration        10 = 10 Second
        }
		// IMPLEMENT WHEN WEAKREFERENCES FIXED
        /*
		public override void AddRecipes()
		{
			CreateRecipe()
			recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("YharimsStimulants")), 1);
			recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("FabsolsVodka")), 1);
			recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("CadencePotion")), 1);
			recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("TitanScalePotion")), 1);
			recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("SoaringPotion")), 1);
			recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("BoundingPotion")), 1);
                .AddTile(TileID.AlchemyTable)
				.Register();
		}
        */
    }
}
