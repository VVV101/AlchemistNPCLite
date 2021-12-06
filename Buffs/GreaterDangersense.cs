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
	public class GreaterDangersense : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Greater Dangersense");
			Description.SetDefault("Lights up enemy projectiles");
			BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Зелье Великого Чувства Опасности");
			Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Подсвечивает снаряды противника");
        }
		
		public override void Update(Player player, ref int buffIndex)
		{
			AlchemistNPCLite.GreaterDangersense = true;
		}
	}
}
