using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlchemistNPCLite.Buffs
{
    public class CalamityComb : ModBuff
    {
        private string[] BuffList = {
                "PhotosynthesisBuff",
                "FabsolVodkaBuff",
                "Soaring",
                "BoundingBuff"
        };

        public override bool IsLoadingEnabled(Mod mod)
        {
            ModLoader.TryGetMod("CalamityMod", out Calamity);
            return Calamity != null;
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
                if (Calamity.TryFind<ModBuff>(BuffString, out ModBuff buff))
                    player.buffImmune[buff.Type] = true;
            }
            if (ModLoader.GetMod("CalamityMod") != null)
            {
                CalamityBoost(player, ref buffIndex);
            }
        }


        private void CalamityBoost(Player player, ref int buffIndex)
        {
            foreach (string BuffString in BuffList)
            {
                if (Calamity.TryFind<ModBuff>(BuffString, out ModBuff buff))
                    buff.Update(player, ref buffIndex);
            }
        }
        private Mod Calamity;

        // IMPLEMENT WHEN WEAKREFERENCES FIXED
        /*
		private void RedemptionBoost(Player player)
        {
			Redemption.Items.DruidDamageClass.DruidDamagePlayer RedemptionPlayer = player.GetModPlayer<Redemption.Items.DruidDamageClass.DruidDamagePlayer>();
            Redemptionplayer.GetDamage(DamageClass.druid) += 2;
        }
		private void ThoriumBoosts(Player player)
        {
            ThoriumMod.ThoriumPlayer ThoriumPlayer = player.GetModPlayer<ThoriumMod.ThoriumPlayer>();
            Thoriumplayer.GetDamage(DamageClass.symphonic) += 2;
            Thoriumplayer.GetDamage(DamageClass.radiant) += 2;
        }
		*/
    }
}
