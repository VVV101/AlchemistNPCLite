using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlchemistNPCLite.Buffs
{
    public class StationUltimaBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = false;
            BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            AlchemistNPCLitePlayer modPlayer = player.GetModPlayer<AlchemistNPCLitePlayer>();
            modPlayer.Bewitched = true;
            modPlayer.Sharpen = true;
            modPlayer.Clairvoyance = true;
            modPlayer.AmmoBox = true;
            modPlayer.SugarRush = true;
            modPlayer.Lamps = true;
            modPlayer.WarTable = true;
            player.statDefense += 5;
            player.buffImmune[159] = true;
            player.buffImmune[29] = true;
            player.buffImmune[150] = true;
            player.buffImmune[93] = true;
            player.buffImmune[192] = true;
            player.buffImmune[89] = true;
            player.buffImmune[87] = true;
            player.buffImmune[158] = true;
            player.buffImmune[215] = true;
            player.buffImmune[348] = true;
        }
    }
}
