using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlchemistNPCLite.Items.Placeable
{
    public class SpecCraftPoint : ModItem
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
            Item.value = 10000;
            Item.createTile = ModContent.TileType<Tiles.SpecCraftPoint>();
        }

        public override void AddRecipes()
        {
            Recipe recipe = Recipe.Create(Item.type);
            recipe.AddIngredient(ItemID.HoneyDispenser);
            recipe.AddIngredient(ItemID.SteampunkBoiler);
            recipe.AddIngredient(ItemID.FleshCloningVaat);
            recipe.AddIngredient(ItemID.SkyMill);
            recipe.AddIngredient(ItemID.Solidifier);
            recipe.AddIngredient(ItemID.Keg);
            recipe.AddIngredient(ItemID.IceMachine);
            recipe.AddIngredient(ItemID.GlassKiln);
            recipe.AddIngredient(ItemID.LivingLoom);
            recipe.AddIngredient(ItemID.BoneWelder);
            recipe.AddIngredient(ItemID.WaterBucket);
            recipe.AddIngredient(ItemID.LavaBucket);
            recipe.AddIngredient(ItemID.HoneyBucket);
            recipe.AddTile(TileID.CrystalBall);
            recipe.Register();
        }
    }
}
