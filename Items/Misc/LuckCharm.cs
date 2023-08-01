using Terraria;
using Terraria.ModLoader;

namespace AlchemistNPCLite.Items.Misc
{
    public class LuckCharm : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.value = 1000000;
            Item.rare = 8;
        }
    }
}
