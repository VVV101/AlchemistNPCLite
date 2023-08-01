using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlchemistNPCLite.Buffs
{
    public class ExplorerComb : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = false;
            BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.findTreasure = true;
            Lighting.AddLight((int)((double)player.position.X + (double)(player.width / 2)) / 16, (int)((double)player.position.Y + (double)(player.height / 2)) / 16, 0.8f, 0.95f, 1f);
            player.nightVision = true;
            player.detectCreature = true;
            player.pickSpeed -= 0.25f;
            player.dangerSense = true;
            player.gills = true;
            player.waterWalk = true;
            player.ignoreWater = true;
            player.accFlipper = true;
            player.buffImmune[4] = true;
            player.buffImmune[15] = true;
            player.buffImmune[109] = true;
            player.buffImmune[9] = true;
            player.buffImmune[11] = true;
            player.buffImmune[12] = true;
            player.buffImmune[17] = true;
            player.buffImmune[104] = true;
            player.buffImmune[111] = true;
            BuffLoader.Update(BuffID.Gills, player, ref buffIndex);
            BuffLoader.Update(BuffID.Flipper, player, ref buffIndex);
            BuffLoader.Update(BuffID.Shine, player, ref buffIndex);
        }
    }
}
