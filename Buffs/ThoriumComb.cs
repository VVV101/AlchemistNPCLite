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
	public class ThoriumComb : ModBuff
	{
		public override bool IsLoadingEnabled(Mod mod)
		{
			ModLoader.TryGetMod("ThoriumMod", out Mod Thorium);
			return Thorium != null;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Thorium Combination");
			Description.SetDefault("Perfect sum of Thorium buffs"
			+"\nAssassin, Blood, Frenzy, Creativity, Earworm, Inspirational Reach, Glowing, Holy, Hydration");
			Main.debuff[Type] = false;
			BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Комбинация Ториума");
			Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Идеальное сочетание баффов Ториум мода");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "瑟银药剂包");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "完美结合了瑟银药剂的Buff：\n精准药剂、嗜血药剂、战斗药剂、狂怒药剂、光辉药剂、圣洁药剂以及动能药剂");
        }
		
		// IMPLEMENT WHEN WEAKREFERENCES FIXED
		/*
		public override void Update(Player player, ref int buffIndex)
		{
			player.buffImmune[ModLoader.GetMod("ThoriumMod").BuffType("AssassinBuff")] = true;
			player.buffImmune[ModLoader.GetMod("ThoriumMod").BuffType("BloodRush")] = true;
			player.buffImmune[ModLoader.GetMod("ThoriumMod").BuffType("Frenzy")] = true;
			player.buffImmune[ModLoader.GetMod("ThoriumMod").BuffType("RadiantBoost")] = true;
			player.buffImmune[ModLoader.GetMod("ThoriumMod").BuffType("HolyBonus")] = true;
			player.buffImmune[ModLoader.GetMod("ThoriumMod").BuffType("CreativityDrop")] = true;
			player.buffImmune[ModLoader.GetMod("ThoriumMod").BuffType("EarwormBuff")] = true;
			player.buffImmune[ModLoader.GetMod("ThoriumMod").BuffType("InspirationReach")] = true;
			player.buffImmune[ModLoader.GetMod("ThoriumMod").BuffType("HydrationBuff")] = true;
			if (ModLoader.GetMod("ThoriumMod") != null)
			{
				ThoriumBoosts(player, ref buffIndex);
			}
		}

		private void ThoriumBoosts(Player player, ref int buffIndex)
        {
            Thorium.GetBuff("AssassinBuff").Update(player, ref buffIndex);
			Thorium.GetBuff("BloodRush").Update(player, ref buffIndex);
			Thorium.GetBuff("Frenzy").Update(player, ref buffIndex);
			Thorium.GetBuff("RadiantBoost").Update(player, ref buffIndex);
			Thorium.GetBuff("HolyBonus").Update(player, ref buffIndex);
			Thorium.GetBuff("CreativityDrop").Update(player, ref buffIndex);
			Thorium.GetBuff("EarwormBuff").Update(player, ref buffIndex);
			Thorium.GetBuff("InspirationReach").Update(player, ref buffIndex);
			Thorium.GetBuff("HydrationBuff").Update(player, ref buffIndex);
        }
		*/
		private Mod Thorium;
	}
}
