using System.Linq;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Terraria.Localization;

namespace AlchemistNPCLite.Buffs
{
	public class SummonerComb : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Summoner Combination");
			Description.SetDefault("Combination of Summoning, Bewitched and Wrath buffs");
			Main.debuff[Type] = false;
			BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Комбинация Призывателя");
			Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сочетание баффов Призыва, Колдовства и Гнева");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "召唤师药剂包");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "包含以下Buff：召唤, 迷人, 怒气");
        }
		
		public override void Update(Player player, ref int buffIndex)
		{
			AlchemistNPCLitePlayer modPlayer = player.GetModPlayer<AlchemistNPCLitePlayer>();
			modPlayer.AllDamage10 = true;
			modPlayer.Bewitched = true;
			++player.maxMinions;
			player.buffImmune[110] = true;
			player.buffImmune[115] = true;
			player.buffImmune[150] = true;
			// IMPLEMENT WHEN WEAKREFERENCES FIXED
			/*
			if (ModLoader.GetMod("MorePotions") != null)
			{
				if (player.HasBuff(ModContent.BuffType<Buffs.MorePotionsComb>()) || player.HasBuff(ModLoader.GetMod("MorePotions").BuffType("SoulbindingElixerPotionBuff")))
				{
					--player.maxMinions;
				}
			}
			*/
		}
	}
}
