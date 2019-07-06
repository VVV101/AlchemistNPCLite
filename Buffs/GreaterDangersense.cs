using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;
using AlchemistNPCLite;

namespace AlchemistNPCLite.Buffs
{
	public class GreaterDangersense : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Greater Dangersense");
			Description.SetDefault("Lights up enemy projectiles");
			canBeCleared = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Зелье Великого Чувства Опасности");
			Description.AddTranslation(GameCulture.Russian, "Подсвечивает снаряды противника");
			DisplayName.AddTranslation(GameCulture.Chinese, "强效危险感知");
            		Description.AddTranslation(GameCulture.Chinese, "高亮敌人的抛射物");
        }
		
		public override void Update(Player player, ref int buffIndex)
		{
			AlchemistNPCLite.GreaterDangersense = true;
		}
	}
}
