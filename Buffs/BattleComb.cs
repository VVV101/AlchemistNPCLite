using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCLite.Buffs
{
    public class BattleComb : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Battle Combination");
            Description.SetDefault("Combination of Endurance, Lifeforce, Ironskin, Regeneration, Rage & Wrath buffs");
            Main.debuff[Type] = false;
            BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Боевая комбинация");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сочетание баффов Выносливости, Жизненных Сил, Железной Кожи, Регенерации, Ярости и Гнева");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "战斗药剂包");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "包含以下Buff：耐力, 生命力, 铁皮, 恢复, 暴怒, 怒气");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            AlchemistNPCLitePlayer modPlayer = player.GetModPlayer<AlchemistNPCLitePlayer>();
            modPlayer.AllDamage10 = true;
            modPlayer.AllCrit10 = true;
            modPlayer.Defense8 = true;
            modPlayer.DR10 = true;
            modPlayer.Regeneration = true;
            modPlayer.Lifeforce = true;
            player.buffImmune[2] = true;
            player.buffImmune[5] = true;
            player.buffImmune[113] = true;
            player.buffImmune[114] = true;
            player.buffImmune[115] = true;
            player.buffImmune[117] = true;
        }
    }
}
