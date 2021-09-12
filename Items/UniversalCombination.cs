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
     public class UniversalCombination : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Universal Combination");
			Tooltip.SetDefault("Gives combined effects of Tank, Ranger, Mage and Summoner Combinations in a single buff.");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Комбинация Универсала");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Идеальное сочетание Комбинаций Танка, Мага, Стрелка и Призывателя в одном баффе");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "万能药剂包");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "完美结合了以下药剂包的buff：\n坦克药剂包、魔法药剂包、射手药剂包以及召唤师药剂包.");
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
            Item.width = 38;
            Item.height = 42;
            Item.value = Item.sellPrice(0, 10, 0, 0);
            Item.rare = 10;
            Item.buffType = ModContent.BuffType<Buffs.UniversalComb>();           //this is where you put your Buff
            Item.buffTime = 52000;    //this is the buff duration        10 = 10 Second
            return;
        }
    }
}
