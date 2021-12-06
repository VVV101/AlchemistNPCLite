using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Terraria.Localization;

namespace AlchemistNPCLite.Buffs
{
	public class VanTankComb : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tank Combination (Vanilla)");
			Description.SetDefault("Combination of Swiftness, Endurance, Lifeforce, Ironskin, Obsidian Skin, Thorns and Regeneration buffs");
			Main.debuff[Type] = false;
			BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Комбинация Танка (без Модовых)");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сочетание баффов Быстроты, Выносливости, Жизненных Сил, Железной Кожи, Обсидиановой Кожи, Шипов и Регенерации");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "坦克药剂包 (原版)");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "包含以下Buff：耐力, 生命力, 铁皮, 黑曜石皮肤, 荆棘, 恢复");
        }
		
		public override void Update(Player player, ref int buffIndex)
		{
			AlchemistNPCLitePlayer modPlayer = player.GetModPlayer<AlchemistNPCLitePlayer>();
			modPlayer.Defense8 = true;
			modPlayer.DR10 = true;
			modPlayer.Regeneration = true;
			modPlayer.Lifeforce = true;
			modPlayer.MS = true;
			player.lavaImmune = true;
			player.fireWalk = true;
			player.buffImmune[1] = true;
			player.buffImmune[2] = true;
			player.buffImmune[5] = true;
			player.buffImmune[14] = true;
			player.buffImmune[113] = true;
			player.buffImmune[114] = true;
			if (player.thorns < 1.0)
			{
				player.thorns = 0.3333333f;
			}
			BuffLoader.Update(BuffID.ObsidianSkin, player, ref buffIndex);
		}
	}
}
