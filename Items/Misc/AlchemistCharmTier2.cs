using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlchemistNPCLite.Items.Misc
{
    public class AlchemistCharmTier2 : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.value = 2000000;
            Item.rare = 8;
        }

        public override void UpdateInventory(Player player)
        {
            (player.GetModPlayer<AlchemistNPCLitePlayer>()).AlchemistCharmTier2 = true;
            (player.GetModPlayer<AlchemistNPCLitePlayer>()).DistantPotionsUse = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = Recipe.Create(Item.type);
            recipe.AddIngredient(null, "AlchemistCharmTier1");
            recipe.AddRecipeGroup("AlchemistNPCLite:EvilBar", 15);
            recipe.AddRecipeGroup("AlchemistNPCLite:EvilComponent", 20);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
