using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlchemistNPCLite.Buffs
{
    public class UniversalComb : ModBuff
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
            modPlayer.AllCrit10 = true;
            modPlayer.Defense8 = true;
            modPlayer.DR10 = true;
            modPlayer.Regeneration = true;
            modPlayer.Lifeforce = true;
            modPlayer.MS = true;
            modPlayer.Bewitched = true;
            modPlayer.Clairvoyance = true;
            modPlayer.WarTable = true;
            player.GetDamage(DamageClass.Magic) += 0.2f;
            player.manaRegenBuff = true;
            player.archery = true;
            player.ammoPotion = true;
            player.lavaImmune = true;
            player.fireWalk = true;
            player.buffImmune[24] = true;
            player.buffImmune[29] = true;
            player.buffImmune[39] = true;
            player.buffImmune[44] = true;
            player.buffImmune[46] = true;
            player.buffImmune[47] = true;
            player.buffImmune[69] = true;
            player.buffImmune[110] = true;
            player.buffImmune[112] = true;
            player.buffImmune[113] = true;
            player.buffImmune[114] = true;
            player.buffImmune[115] = true;
            player.buffImmune[117] = true;
            player.buffImmune[150] = true;
            player.buffImmune[348] = true;
            player.buffImmune[ModContent.BuffType<Buffs.BattleComb>()] = true;
            player.buffImmune[ModContent.BuffType<Buffs.TankComb>()] = true;
            player.buffImmune[ModContent.BuffType<Buffs.VanTankComb>()] = true;
            player.buffImmune[ModContent.BuffType<Buffs.RangerComb>()] = true;
            player.buffImmune[ModContent.BuffType<Buffs.MageComb>()] = true;
            player.buffImmune[ModContent.BuffType<Buffs.SummonerComb>()] = true;
            player.buffImmune[1] = true;
            player.buffImmune[2] = true;
            player.buffImmune[5] = true;
            player.buffImmune[6] = true;
            player.buffImmune[7] = true;
            player.buffImmune[14] = true;
            ++player.maxMinions;
            // IMPLEMENT WHEN WEAKREFERENCES FIXED
            /*
			if (ModLoader.GetMod("MorePotions") != null)
			{
				if (player.HasBuff(ModContent.BuffType<Buffs.MorePotionsComb>()) || player.HasBuff(ModLoader.GetMod("MorePotions").BuffType("SoulbindingElixerPotionBuff")))
				{
					--player.maxMinions;
				}
				if (player.HasBuff(ModContent.BuffType<Buffs.MorePotionsComb>()) || player.HasBuff(ModLoader.GetMod("MorePotions").BuffType("DiamondSkinPotionBuff")))
				{
					player.statDefense -= 8;
				}
			}
			*/
            if (player.thorns < 1.0)
            {
                player.thorns = 0.3333333f;
            }
            BuffLoader.Update(BuffID.ObsidianSkin, player, ref buffIndex);
        }
    }
}
