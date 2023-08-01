using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlchemistNPCLite.Buffs
{
    public class TankComb : ModBuff
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
            player.longInvince = true;
            if (NPC.downedMechBoss2)
            {
                player.buffImmune[39] = true;
                player.buffImmune[69] = true;
            }
            player.buffImmune[24] = true;
            player.buffImmune[44] = true;
            player.buffImmune[46] = true;
            player.buffImmune[47] = true;
            player.lavaImmune = true;
            player.fireWalk = true;
            player.buffImmune[1] = true;
            player.buffImmune[2] = true;
            player.buffImmune[5] = true;
            player.buffImmune[14] = true;
            player.buffImmune[113] = true;
            player.buffImmune[114] = true;
            player.buffImmune[ModContent.BuffType<Buffs.LongInvincible>()] = true;
            player.buffImmune[ModContent.BuffType<Buffs.TitanSkin>()] = true;
            if (player.thorns < 1.0)
            {
                player.thorns = 0.3333333f;
            }
            BuffLoader.Update(BuffID.ObsidianSkin, player, ref buffIndex);
        }
    }
}
