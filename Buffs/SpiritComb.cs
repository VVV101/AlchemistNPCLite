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
	public class SpiritComb : ModBuff
	{
		public override bool IsLoadingEnabled(Mod mod)
		{
			ModLoader.TryGetMod("SpiritMod", out Mod Spirit);
			return Spirit != null;
		}
		
		public override void SetStaticDefaults()
		{
			Main.debuff[Type] = false;
			BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
			DisplayName.SetDefault("Spirit Combination");
			Description.SetDefault("Grants most buffs from Spirit Mod potions (Runescribe, Soulguard, Spirit, Starburn, Steadfast and Toxin)");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Комбинация Spirit");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Даёт большинство баффов от зелий мода Spirit (Runescribe, Soulguard, Spirit, Starburn, Steadfast and Toxin)");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "魂灵药剂包");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "获得大部分魂灵Buff (符文之力, 灵魂之护, 魂灵, 星之燃烧, 坚定和毒素)");
        }
		
		// IMPLEMENT WHEN WEAKREFERENCES FIXED
		/*
		public override void Update(Player player, ref int buffIndex)
		{
			player.buffImmune[ModLoader.GetMod("SpiritMod").BuffType("SpiritBuff")] = true;
			player.buffImmune[ModLoader.GetMod("SpiritMod").BuffType("RunePotionBuff")] = true;
			player.buffImmune[ModLoader.GetMod("SpiritMod").BuffType("CombatProwess")] =true;
			player.buffImmune[ModLoader.GetMod("SpiritMod").BuffType("StarPotionBuff")] = true;
			player.buffImmune[ModLoader.GetMod("SpiritMod").BuffType("TurtlePotionBuff")] = true;
			player.buffImmune[ModLoader.GetMod("SpiritMod").BuffType("BismitePotionBuff")] = true;
				if (ModLoader.GetMod("SpiritMod") != null)
				{
					SpiritBoosts(player, ref buffIndex);
				}
		}
		
		private void SpiritBoosts(Player player, ref int buffIndex)
        {
            SpiritMod.MyPlayer SpiritPlayer = player.GetModPlayer<SpiritMod.MyPlayer>();
			Spirit.GetBuff("SpiritBuff").Update(player, ref buffIndex);
			Spirit.GetBuff("RunePotionBuff").Update(player, ref buffIndex);
			Spirit.GetBuff("SoulPotionBuff").Update(player, ref buffIndex);
			Spirit.GetBuff("StarPotionBuff").Update(player, ref buffIndex);
			Spirit.GetBuff("TurtlePotionBuff").Update(player, ref buffIndex);
			Spirit.GetBuff("BismitePotionBuff").Update(player, ref buffIndex);
        }
		*/
		private Mod Spirit;
	}
}
