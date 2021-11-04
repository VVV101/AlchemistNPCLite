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
     public class DiscordPotion : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Discord Potion");
			Tooltip.SetDefault("Allows to teleport on cursor position by hotkey"
			+"\nDistorts player for 1 second after teleport"
			+"\nInflicts heavy damage while you have Chaos State"
			+"\nChaos State time is increased to 10 seconds"
			+"\nNON-CALAMITY BUFF POTION");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Зелье Раздора");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Позволяет телепортироваться на курсор при нажатии горячей клавиши\nНарушает гравитацию игрока на 1 секунду после использования\nНаносит значительные повреждения, если вы в Хаотическом состоянии\nДлительность дебаффа увеличена до 10 секунд\nЗелье не из Каламити мода");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "混乱药剂");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "允许使用快捷键传送到鼠标位置"
            + "\n传送后扭曲玩家一秒钟"
            + "\n混乱状态时使用会受到巨大的伤害"
            + "\n混乱状态延长至10秒"
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
            Item.buffType = ModContent.BuffType<Buffs.DiscordBuff>();           //this is where you put your Buff
            Item.buffTime = 18000;    //this is the buff duration        10 = 10 Second
            return;
        }
    }
}
