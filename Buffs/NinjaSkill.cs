using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlchemistNPCLite.Buffs
{
    public class NinjaSkill : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = false;
            BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetDamage(DamageClass.Generic) += 0.05f;
            player.GetCritChance(DamageClass.Melee) += 5;
            player.GetCritChance(DamageClass.Ranged) += 5;
            player.GetCritChance(DamageClass.Magic) += 5;
            player.GetCritChance(DamageClass.Throwing) += 5;
            player.blackBelt = true;
            player.spikedBoots = 2;
            if (ModLoader.TryGetMod("ThoriumMod", out Mod thoriumMod))
			{
				if (thoriumMod.TryFind("BardDamage", out DamageClass damageClass))
				{
					player.GetCritChance(damageClass) += 5;
				}
				if (thoriumMod.TryFind("HealerDamage", out DamageClass damageClass1))
				{
					player.GetCritChance(damageClass1) += 5;
				}
			}
			
        }
    }
}
