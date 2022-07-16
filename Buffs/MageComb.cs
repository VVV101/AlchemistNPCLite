using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Terraria.Localization;

namespace AlchemistNPCLite.Buffs
{
	public class MageComb : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mage Combination");
			Description.SetDefault("Combination of Magic Power, Mana Regeneration, Clairvoyance, Wrath & Rage buffs");
			Main.debuff[Type] = false;
			BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Комбинация Мага");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сочетание баффов Магической Силы, Регенерации Маны, Ясновидения, Гнева и Ярости");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "魔法药剂包");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "包含以下Buff：魔能, 魔力再生, 智慧, 暴怒, 怒气");
        }
		public override void Update(Player player, ref int buffIndex)
		{
			AlchemistNPCLitePlayer modPlayer = player.GetModPlayer<AlchemistNPCLitePlayer>();
			modPlayer.AllDamage10 = true;
			modPlayer.AllCrit10 = true;
            modPlayer.Clairvoyance = true;
			player.GetDamage(DamageClass.Magic) += 0.2f;
			player.manaRegenBuff = true;
			player.buffImmune[6] = true;
			player.buffImmune[7] = true;
			player.buffImmune[29] = true;
			player.buffImmune[115] = true;
			player.buffImmune[117] = true;
		}
	}
}
