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
     public class UltimaCake : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ultima Cake");
			Tooltip.SetDefault("Grants special effects of almost all stations simultaniosly"
			+"\nThis includes Campfires, Lamps, Bast's Statue, Sharpening Station, Ammo Box, Crystal Ball, Slice of Cake and Bewitching Table."
			+"\nBy some unimageneable magic, it will never be consumed"
			+"\nNON-CALAMITY BUFF ITEM");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Кусок ультима торта");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Даёт эффекты практически всех станций одновременно\nЭто включает костры, различные лампы, статую Баст и различные используемые станции\nБлагодаря неведомой магии, он никогда не закончится\nБафф не из Каламити мода");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 20;
        }    
		public override void SetDefaults()
        {
            Item.UseSound = SoundID.Item2;                 //this is the sound that plays when you use the item
            Item.useStyle = 2;                 //this is how the item is holded when used
            Item.useTurn = true;
            Item.useAnimation = 17;
            Item.useTime = 17;
            Item.maxStack = 1;                 //this is where you set the max stack of item
            Item.consumable = false;           //this make that the item is consumable when used
            Item.width = 18;
            Item.height = 28;
            Item.value = Item.sellPrice(1, 0, 0, 0);
            Item.rare = 7;
            Item.buffType = ModContent.BuffType<Buffs.StationUltimaBuff>();           //this is where you put your Buff
            Item.buffTime = 108000;    //this is the buff duration        10 = 10 Second
            return;
        }
    }
}
