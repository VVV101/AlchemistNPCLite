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
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Traps Buff");
			Description.SetDefault("Traps are empowered");
			Main.debuff[Type] = false;
			canBeCleared = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Усилитель ловушек");
            Description.AddTranslation(GameCulture.Russian, "Ловушки значительно усилены");
		}
		
		public override void Update(Player player, ref int buffIndex)
		{
		((AlchemistNPCLitePlayer)player.GetModPlayer(mod, "AlchemistNPCLitePlayer")).Traps = true;
		}
	}
}
