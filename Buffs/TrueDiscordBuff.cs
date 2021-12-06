using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Terraria.Localization;
using AlchemistNPCLite;

namespace AlchemistNPCLite.Buffs
{
	public class TrueDiscordBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("True Discord");
			Description.SetDefault("You may teleport to cursor position by using hotkey"
			+"\nBehaves exactly like Rod of Discord");
			Main.debuff[Type] = false;
			BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Истинный Раздор");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Вы можете телепортироваться к курсору, используя горячую клавишу\nПри применении ведёт себя аналогично Жезлу Раздора");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "真·混乱传送");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "你可以使用快捷键传送至鼠标位置" +
                "\n相当于混乱法杖");
		}
		
		public override void Update(Player player, ref int buffIndex)
		{
		player.buffImmune[ModContent.BuffType<Buffs.DiscordBuff>()] = true;
		}
	}
}
