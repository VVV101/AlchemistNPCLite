using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlchemistNPCLite.Buffs
{
    public class ThoriumComb : ModBuff
    {
        private string[] BuffList = {
                "AssassinBuff",
                "BloodRush",
                "Frenzy",
                "RadiantBoost",
                "HolyBonus",
                "CreativityDrop",
                "EarwormBuff",
                "InspirationReach",
                "HydrationBuff"
        };

        public override bool IsLoadingEnabled(Mod mod)
        {
            ModLoader.TryGetMod("ThoriumMod", out Thorium);
            return Thorium != null;
        }

        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = false;
            BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            foreach (string BuffString in BuffList)
            {
                if (Thorium.TryFind(BuffString, out ModBuff buff))
                    player.buffImmune[buff.Type] = true;
            }
            if (ModLoader.GetMod("ThoriumMod") != null)
            {
                ThoriumBoosts(player, ref buffIndex);
            }
        }

        private void ThoriumBoosts(Player player, ref int buffIndex)
        {
            foreach (string BuffString in BuffList)
            {
                if (Thorium.TryFind(BuffString, out ModBuff buff))
                    buff.Update(player, ref buffIndex);
            }
        }
        private Mod Thorium;
    }
}
