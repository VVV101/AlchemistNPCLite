using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlchemistNPCLite.Items.Misc
{
    public class AlchemistCharmTier3 : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.value = 3000000;
            Item.rare = 10;
        }

        public override void UpdateInventory(Player player)
        {
            (player.GetModPlayer<AlchemistNPCLitePlayer>()).AlchemistCharmTier3 = true;
            (player.GetModPlayer<AlchemistNPCLitePlayer>()).DistantPotionsUse = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = Recipe.Create(Item.type);
            recipe.AddIngredient(null, "AlchemistCharmTier2");
            recipe.AddRecipeGroup("AlchemistNPCLite:Tier3Bar", 15);
            recipe.AddRecipeGroup("AlchemistNPCLite:HardmodeComponent", 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}
