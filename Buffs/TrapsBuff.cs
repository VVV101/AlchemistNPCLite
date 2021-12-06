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
	public class TrapsBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Traps Buff");
			Description.SetDefault("Traps are empowered");
			Main.debuff[Type] = false;
			BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Усилитель ловушек");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Ловушки значительно усилены");
		}
		
		public override void Update(Player player, ref int buffIndex)
		{
		(player.GetModPlayer<AlchemistNPCLitePlayer>()).Traps = true;
		}
	}
}
