using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlchemistNPCLite.Buffs
{
    public class BuilderComb : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = false;
            BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.pickSpeed -= 0.25f;
            player.calmed = true;
            player.tileSpeed += 0.25f;
            player.wallSpeed += 0.25f;
            ++player.blockRange;
            player.buffImmune[104] = true;
            player.buffImmune[106] = true;
            player.buffImmune[107] = true;
        }
    }
}
