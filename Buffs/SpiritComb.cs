using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

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
