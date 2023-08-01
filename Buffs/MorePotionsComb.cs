using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlchemistNPCLite.Buffs
{
    public class MorePotionsComb : ModBuff
    {
        public override bool IsLoadingEnabled(Mod mod)
        {
            ModLoader.TryGetMod("MorePotions", out MorePotions);
            return MorePotions != null;
        }

        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = false;
            BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
        }

        // IMPLEMENT WHEN WEAKREFERENCES FIXED
        /*
        public override void Update(Player player, ref int buffIndex)
        {
            player.buffImmune[ModLoader.GetMod("MorePotions").BuffType("CouragePotionBuff")] = true;
            player.buffImmune[ModLoader.GetMod("MorePotions").BuffType("DawnPotionBuff")] = true;
            player.buffImmune[ModLoader.GetMod("MorePotions").BuffType("DuskPotionBuff")] = true;
            player.buffImmune[ModLoader.GetMod("MorePotions").BuffType("DiamondSkinPotionBuff")] = true;
            player.buffImmune[ModLoader.GetMod("MorePotions").BuffType("EnhancedRegenerationPotionBuff")] = true;
            player.buffImmune[ModLoader.GetMod("MorePotions").BuffType("GladiatorsPotionBuff")] = true;
            player.buffImmune[ModLoader.GetMod("MorePotions").BuffType("SoulbindingElixerPotionBuff")] = true;
            player.buffImmune[ModLoader.GetMod("MorePotions").BuffType("RangersDroughtPotionBuff")] = true;
            player.buffImmune[ModLoader.GetMod("MorePotions").BuffType("SpeedPotionBuff")] = true;
            player.buffImmune[ModLoader.GetMod("MorePotions").BuffType("SummonersDroughtPotionBuff")] = true;
            player.buffImmune[ModLoader.GetMod("MorePotions").BuffType("SwiftHandsPotionBuff")] = true;
            player.buffImmune[ModLoader.GetMod("MorePotions").BuffType("WarriorsDroughtPotionBuff")] = true;
            if (ModLoader.GetMod("MorePotions") != null)
            {
                MorePotionsBoosts(player, ref buffIndex);
            }
        }

        private void MorePotionsBoosts(Player player, ref int buffIndex)
        {
            MorePotions.MorePotionsPlayer MorePotionsPlayer = player.GetModPlayer<MorePotions.MorePotionsPlayer>();
            MorePotions.GetBuff("CouragePotionBuff").Update(player, ref buffIndex);
            MorePotions.GetBuff("DawnPotionBuff").Update(player, ref buffIndex);
            MorePotions.GetBuff("DuskPotionBuff").Update(player, ref buffIndex);
            MorePotions.GetBuff("DiamondSkinPotionBuff").Update(player, ref buffIndex);
            MorePotions.GetBuff("EnhancedRegenerationPotionBuff").Update(player, ref buffIndex);
            MorePotions.GetBuff("GladiatorsPotionBuff").Update(player, ref buffIndex);
            MorePotions.GetBuff("SoulbindingElixerPotionBuff").Update(player, ref buffIndex);
            MorePotions.GetBuff("RangersDroughtPotionBuff").Update(player, ref buffIndex);
            MorePotions.GetBuff("SpeedPotionBuff").Update(player, ref buffIndex);
            MorePotions.GetBuff("SummonersDroughtPotionBuff").Update(player, ref buffIndex);
            MorePotions.GetBuff("SwiftHandsPotionBuff").Update(player, ref buffIndex);
            MorePotions.GetBuff("WarriorsDroughtPotionBuff").Update(player, ref buffIndex);
        }
		*/
        private Mod MorePotions;
    }
}
