using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCLite.Buffs
{
	public class Fortitude : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fortitude");
			Description.SetDefault("You cannot be knockbacked");
			Main.debuff[Type] = false;
			CanBeCleared = true;
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Стойкость");
			Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Вам нельзя отбросить при атаке");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "刚毅");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "你无法被击退");
        }
		public override void Update(Player player, ref int buffIndex)
		{
			player.noKnockback = true;
		}
	}
}
