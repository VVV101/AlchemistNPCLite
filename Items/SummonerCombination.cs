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
     public class SummonerCombination : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Summoner Combination");
			Tooltip.SetDefault("Grants buffs, which are necessary for Summoners (Summoning, Bewitched, Wrath)");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Комбинация Призывателя");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "аёт баффы, необходимые для Призывателя(Призыв, Колдовство, Гнев)");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "召唤师药剂包");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "获得一些召唤Buff (召唤, 战斗, 迷人, 怒气)");
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
            Item.height = 34;
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.rare = 10;
            Item.buffType = ModContent.BuffType<Buffs.SummonerComb>();           //this is where you put your Buff
            Item.buffTime = 52000;    //this is the buff duration        10 = 10 Second
            return;
        }
		
		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.SummoningPotion, 1)
			    .AddIngredient(null, "BewitchingPotion", 1)
				.AddIngredient(ItemID.WrathPotion, 1)
				.AddTile(TileID.AlchemyTable)
				.Register();
		}
		
    }
}
