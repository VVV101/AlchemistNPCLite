using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlchemistNPCLite.Items.Placeable
{
    public class PreHMPenny : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }
        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.maxStack = 1;
            Item.value = 1000000;
            Item.rare = 7;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = 1;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<Tiles.PreHMPenny>();
        }

        public override void AddRecipes()
        {
            Recipe recipe = Recipe.Create(Item.type);
            recipe.AddIngredient(ItemID.WorkBench);
            recipe.AddRecipeGroup("AlchemistNPCLite:AnyPreHMAnvil");
            recipe.AddIngredient(ItemID.Hellforge);
            recipe.AddIngredient(ItemID.Loom);
            recipe.AddIngredient(ItemID.AlchemyTable);
            recipe.AddIngredient(ItemID.DyeVat);
            recipe.AddIngredient(ItemID.WoodenTable);
            recipe.AddIngredient(ItemID.WoodenChair);
            recipe.AddIngredient(ItemID.CookingPot);
            recipe.AddIngredient(ItemID.TinkerersWorkshop);
            recipe.AddIngredient(ItemID.HeavyWorkBench);
            recipe.AddIngredient(ItemID.Sawmill);
            recipe.Register();
        }
    }
}
