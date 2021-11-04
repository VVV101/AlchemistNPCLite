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
    public class PerfectDiscordPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Perfect Discord Potion");
			Tooltip.SetDefault("[c/00FF00:Unique Explorer's potion]"
            + "\nAllows to teleport on cursor position by hotkey"
            + "\nBehaves exactly like Rod of Discord"
            + "\nNON-CALAMITY BUFF POTION");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Превосходное Зелье Раздора");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "[c/00FF00:Уникальное Зелье Исследовательницы]\nПозволяет телепортироваться на курсор при нажатии горячей клавиши\nПри применении ведёт себя аналогично Жезлу Раздора\nЗелье не из Каламити мода");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "真·混乱药剂");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "[c/00FF00:特调探险者药剂]\n允许使用快捷键传送到鼠标位置"
            + "\n效果等同于混乱法杖"
            + "\n非灾厄Buff药剂");
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
            Item.width = 18;
            Item.height = 28;
            Item.value = Item.sellPrice(0, 4, 0, 0);
            Item.rare = 7;
            Item.buffType = ModContent.BuffType<Buffs.TrueDiscordBuff>();           //this is where you put your Buff
            Item.buffTime = 36000;    //this is the buff duration        10 = 10 Second
            return;
        }
    }
}
