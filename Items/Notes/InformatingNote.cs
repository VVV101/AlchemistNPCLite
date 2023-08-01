using Terraria;
using Terraria.ModLoader;

namespace AlchemistNPCLite.Items.Notes
{
    public class InformatingNote : ModItem
    {
        public override void SetStaticDefaults()
        {

        }

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 36;
            Item.maxStack = 1;
            Item.rare = 3;
        }
    }
}