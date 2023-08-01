using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlchemistNPCLite.Buffs
{
    public class MageComb : ModBuff
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
            modPlayer.Clairvoyance = true;
            player.GetDamage(DamageClass.Magic) += 0.2f;
            player.manaRegenBuff = true;
            player.buffImmune[6] = true;
            player.buffImmune[7] = true;
            player.buffImmune[29] = true;
            player.buffImmune[115] = true;
            player.buffImmune[117] = true;
        }
    }
}
