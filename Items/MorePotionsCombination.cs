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
    public class MorePotionsCombination : ModItem
    {
		//Probably removed
		// public override bool Autoload(ref string name)
		// {
		// return ModLoader.GetMod("MorePotions") != null;
		// }
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("More Potions Combination");
			Tooltip.SetDefault("Grants most buffs from More Potions *potions"
			+"\nDroughts, Enchanced Regeneration, Courage, Soulbinding, Diamond Skin, Dusk, Dawn, Swift Hands, Speed");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Комбинация More Potioins");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Даёт большинство баффов от зелий мода More Potions"
			+"\nDroughts, Enchanced Regeneration, Courage, Soulbinding, Diamond Skin, Dusk, Dawn, Swift Hands, Speed");
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
            Item.value = Item.sellPrice(0, 20, 0, 0);
            Item.rare = 10;
            Item.buffType = ModContent.BuffType<Buffs.MorePotionsComb>();           //this is where you put your Buff
            Item.buffTime = 52000;    //this is the buff duration        10 = 10 Second
        }
		
		// IMPLEMENT WHEN WEAKREFERENCES FIXED
		/*
		public override void AddRecipes()
		{
			CreateRecipe()
			recipe.AddIngredient((ModLoader.GetMod("MorePotions").ItemType("CouragePotion")), 1);
			recipe.AddIngredient((ModLoader.GetMod("MorePotions").ItemType("DawnPotion")), 1);
			recipe.AddIngredient((ModLoader.GetMod("MorePotions").ItemType("DuskPotion")), 1);
			recipe.AddIngredient((ModLoader.GetMod("MorePotions").ItemType("DiamondSkinPotion")), 1);
			recipe.AddIngredient((ModLoader.GetMod("MorePotions").ItemType("EnhancedRegenerationPotion")), 1);
			recipe.AddIngredient((ModLoader.GetMod("MorePotions").ItemType("GladiatorsPotion")), 1);
			recipe.AddIngredient((ModLoader.GetMod("MorePotions").ItemType("RangersDroughtPotion")), 1);
			recipe.AddIngredient((ModLoader.GetMod("MorePotions").ItemType("SoulbindingElixerPotion")), 1);
			recipe.AddIngredient((ModLoader.GetMod("MorePotions").ItemType("SpeedPotion")), 1);
			recipe.AddIngredient((ModLoader.GetMod("MorePotions").ItemType("SummonersDroughtPotion")), 1);
			recipe.AddIngredient((ModLoader.GetMod("MorePotions").ItemType("SwiftHandsPotion")), 1);
			recipe.AddIngredient((ModLoader.GetMod("MorePotions").ItemType("WarriorsDroughtPotion")), 1);
				.AddTile(TileID.AlchemyTable)
				.Register();
		}
		*/
    }
}
