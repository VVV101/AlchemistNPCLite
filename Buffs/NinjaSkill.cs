using Terraria;
using System.Linq;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCLite.Buffs
{
	public class NinjaSkill : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ninja");
			Description.SetDefault("You are a true ninja!");
			Main.debuff[Type] = false;
			CanBeCleared = true;
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Ниндзя");
			Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Вы - истинный ниндзя!");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "忍者");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "现在你是个真正的忍者了!");
        }
		public override void Update(Player player, ref int buffIndex)
		{
			player.GetDamage(DamageClass.Generic) += 0.05f;
			player.GetCritChance(DamageClass.Melee) += 5;
            player.GetCritChance(DamageClass.Ranged) += 5;
            player.GetCritChance(DamageClass.Magic) += 5;
            player.GetCritChance(DamageClass.Throwing) += 5;
			player.blackBelt = true;
            player.spikedBoots = 2;
				// if (ModLoader.GetMod("ThoriumMod") != null)
				// {
				// ThoriumBoosts(player);
				// }
				// if (ModLoader.GetMod("Redemption") != null)
				// {
				// RedemptionBoost(player);
				// }
			// Mod Calamity = ModLoader.GetMod("CalamityMod");
				// if(Calamity != null)
				// {
				// 	Calamity.Call("AddRogueCrit", player, 5);
				// }
		}
		
		private void CalamityBoost(Player player)
        {
			// IMPLEMENT LATER
			// CalamityMod.Calplayer.CalamityPlayer CalamityPlayer = player.GetModPlayer<CalamityMod.Calplayer.CalamityPlayer>();
            // Calamityplayer.GetDamage(DamageClass.throwing) += 5;
        }
		// private readonly Mod Calamity = ModLoader.GetMod("CalamityMod");
		
		private void RedemptionBoost(Player player)
        {
			// IMPLEMENT LATER
			// Redemption.Items.DruidDamageClass.DruidDamagePlayer RedemptionPlayer = player.GetModPlayer<Redemption.Items.DruidDamageClass.DruidDamagePlayer>();
            // Redemptionplayer.GetDamage(DamageClass.druid) += 5;
        }
		// private readonly Mod Redemption = ModLoader.GetMod("Redemption");
		
		private void ThoriumBoosts(Player player)
        {
			// IMPLEMENT LATER
            // ThoriumMod.ThoriumPlayer ThoriumPlayer = player.GetModPlayer<ThoriumMod.ThoriumPlayer>();
            // Thoriumplayer.GetDamage(DamageClass.symphonic) += 5;
            // Thoriumplayer.GetDamage(DamageClass.radiant) += 5;
        }
		
		// private readonly Mod Thorium = ModLoader.GetMod("ThoriumMod");
	}
}
