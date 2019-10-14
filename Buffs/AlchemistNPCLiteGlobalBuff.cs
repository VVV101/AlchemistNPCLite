using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCLite.Buffs
{
	public class AlchemistNPCLiteGlobalBuffs : GlobalBuff
	{
		public override void Update(int type, Player player, ref int buffIndex)
		{
			if (type == 165)
			{
				Main.buffNoTimeDisplay[type] = false;
			}
		}
	}
}