using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
 
namespace AlchemistNPCLite.Items
{
    public class HeartAttackPotion : ModItem
    {
		// Probably removed
		// public override bool Autoload(ref string name)
		// {
		// 	return ModLoader.GetMod("CalamityMod") != null;
		// }
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Potion of Darkness");
			Tooltip.SetDefault("Fills Rage meter and causes Heart Attack"
			+"\nCannot be used if any boss is alive"
			+"\nNON-CALAMITY POTION");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Зелье Тьмы");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Заполняет счётчик Ярости и вызывает Сердечный Приступ\nНе может быть использовано, если жив любой босс\nЗЕЛЬЕ НЕ ИЗ КАЛАМИТИ МОДА");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "黑暗药剂");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "装填愤怒槽, 造成心脏衰竭"
			+"\n非灾厄药剂");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 20;
        }    

		public override void SetDefaults()
        {
            Item.UseSound = SoundID.Item3;
            Item.useStyle = 2;
            Item.useTurn = true;
            Item.useAnimation = 17;
            Item.useTime = 17;
            Item.maxStack = 30;
            Item.consumable = true;
            Item.width = 20;
            Item.height = 30;
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.rare = 10;
			// IMPLEMENT WHEN WEAKREFERENCES FIXED
			/*
            Item.buffType = ModLoader.GetMod("CalamityMod").BuffType("AbsoluteRage");
			*/
            Item.buffTime = 18000;
        }
		
		// IMPLEMENT WHEN WEAKREFERENCES FIXED
		/*
		public bool CalamityModRevengeance
		{
			get { return CalamityMod.World.CalamityWorld.revenge; }
        }
		*/
		
		public override bool CanUseItem(Player player)
		{
			for (int v = 0; v < 200; ++v)
			{
				NPC npc = Main.npc[v];
				if (npc.active && npc.boss)
				{
					return false;
				}
			}
			// IMPLEMENT WHEN WEAKREFERENCES FIXED
			/*
			if (CalamityModRevengeance)
			{
				return true;
			}
			*/
			return false;
		}
		
		// IMPLEMENT WHEN WEAKREFERENCES FIXED
		/*
		private readonly Mod Calamity = ModLoader.GetMod("CalamityMod");
		
		public override bool? UseItem(Player player)
		{
			CalamityMod.CalPlayer.CalamityPlayer CalamityPlayer = Player.GetModPlayer<CalamityMod.CalPlayer.CalamityPlayer>();
			CalamityPlayer.rage = CalamityPlayer.rageMax;
			return true;
		}
		*/
    }
}
