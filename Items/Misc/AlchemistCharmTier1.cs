using Terraria;
using Terraria.ModLoader;

namespace AlchemistNPCLite.Items.Misc
{
    public class AlchemistCharmTier1 : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.value = 0;
            Item.rare = 6;
        }

        public override void UpdateInventory(Player player)
        {
            (player.GetModPlayer<AlchemistNPCLitePlayer>()).AlchemistCharmTier1 = true;
        }
    }
}
