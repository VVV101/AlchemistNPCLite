using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Terraria.Localization;

namespace AlchemistNPCLite.Buffs
{
	public class Sunshine : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sunshine");
			Description.SetDefault("You are producing light like miniature Sun");
			Main.debuff[Type] = false;
			BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Солнечное Сияние");
			Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Вы сияете как миниатюрное Солнце");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "阳光普照");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "你正像一颗小太阳一样发出光芒");
        }
		public override void Update(Player player, ref int buffIndex)
		{
			Lighting.AddLight((int)((double)player.position.X + (double)(player.width / 2)) / 16, (int)((double)player.position.Y + (double)(player.height / 2)) / 16, 3f, 3f, 3f);
		}
	}
}
