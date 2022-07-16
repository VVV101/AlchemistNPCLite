using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Terraria.Localization;

namespace AlchemistNPCLite.Buffs
{
	public class StationUltimaBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Station Ultima");
			Description.SetDefault("Grants effects of all stations simultaneously");
			Main.debuff[Type] = false;
			BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Станция Ультима");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Даёт эффекты всех станций одновременно");
        }
		
		public override void Update(Player player, ref int buffIndex)
		{
			AlchemistNPCLitePlayer modPlayer = player.GetModPlayer<AlchemistNPCLitePlayer>();
			modPlayer.Bewitched = true;
			modPlayer.Sharpen = true;
			modPlayer.Clairvoyance = true;
			modPlayer.AmmoBox = true;
			modPlayer.SugarRush = true;
			modPlayer.Lamps = true;
			player.statDefense += 5;
			player.buffImmune[159] = true;
			player.buffImmune[29] = true;
			player.buffImmune[150] = true;
			player.buffImmune[93] = true;
			player.buffImmune[192] = true;
			player.buffImmune[89] = true;
			player.buffImmune[87] = true;
			player.buffImmune[158] = true;
			player.buffImmune[215] = true;
		}
	}
}
