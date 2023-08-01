using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlchemistNPCLite.Buffs
{
    public class RangerComb : ModBuff
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
            player.ammoPotion = true;
            player.archery = true;
            player.buffImmune[16] = true;
            player.buffImmune[112] = true;
            player.buffImmune[115] = true;
            player.buffImmune[117] = true;
        }
    }
}
