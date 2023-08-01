using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlchemistNPCLite.Buffs
{
    public class BattleComb : ModBuff
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
            player.buffImmune[2] = true;
            player.buffImmune[5] = true;
            player.buffImmune[113] = true;
            player.buffImmune[114] = true;
            player.buffImmune[115] = true;
            player.buffImmune[117] = true;
        }
    }
}
