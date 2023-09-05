using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlchemistNPCLite.Buffs
{
    public class SummonerComb : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = false;
            BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            AlchemistNPCLitePlayer modPlayer = player.GetModPlayer<AlchemistNPCLitePlayer>();
            modPlayer.AllDamage10 = true;
            modPlayer.Bewitched = true;
            modPlayer.WarTable = true;
            ++player.maxMinions;
            player.buffImmune[110] = true;
            player.buffImmune[115] = true;
            player.buffImmune[150] = true;
            player.buffImmune[348] = true;
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
