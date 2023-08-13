using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlchemistNPCLite.Buffs
{
    public class Excavation : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = false;
            BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
        }
    }
}
