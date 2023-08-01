using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlchemistNPCLite.Buffs
{
    public class Blurring : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = false;
            BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.onHitDodge = true;
            if (player.onHitDodge && player.shadowDodgeTimer == 0 && Main.rand.Next(4) == 0)
            {
                if (!player.shadowDodge) player.shadowDodgeTimer = 1800;
                player.AddBuff(59, 600, true);
            }
        }
    }
}
