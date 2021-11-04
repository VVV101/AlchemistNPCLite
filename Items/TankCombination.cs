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
     public class TankCombination : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tank Combination (w/Modded)");
			Tooltip.SetDefault("Grants buffs, which are necessary for Tanks (Endurance, Lifeforce, Ironskin, Obsidian Skin, Thorns, Regeneration, Titan Skin, Invincibility)");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Комбинация Танка (с модовыми)");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Включает в себя следующие баффы: Выносливость, Жизненные Силы, Железную Кожу\nОбсидиановую Кожу, Шипы, Регенерацию, Кожу Титана и Неуязвимость");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "坦克药剂包 (模组)");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "获得一些坦克Buff (耐力, 生命力, 铁皮, 黑曜石皮肤, 荆棘, 恢复, 抵抗, 泰坦皮肤, 无敌)");
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
            Item.value = Item.sellPrice(0, 3, 0, 0);
            Item.rare = 10;
            Item.buffType = ModContent.BuffType<Buffs.TankComb>();           //this is where you put your Buff
            Item.buffTime = 52000;    //this is the buff duration        10 = 10 Second
            return;
        }
		
		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.EndurancePotion, 1)
				.AddIngredient(ItemID.LifeforcePotion, 1)
				.AddIngredient(ItemID.IronskinPotion, 1)
				.AddIngredient(ItemID.RestorationPotion, 1)
				.AddIngredient(ItemID.ObsidianSkinPotion, 1)
				.AddIngredient(ItemID.ThornsPotion, 1)
			    .AddIngredient(null, "TitanSkinPotion", 1)
			    .AddIngredient(null, "InvincibilityPotion", 1)
				.AddTile(TileID.AlchemyTable)
				.Register();
		}
    }
}
