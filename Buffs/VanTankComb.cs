using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlchemistNPCLite.Buffs
{
    public class VanTankComb : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = false;
            BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
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
