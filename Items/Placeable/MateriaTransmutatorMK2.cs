using Terraria;
using Terraria.ModLoader;

namespace AlchemistNPCLite.Items.Placeable
{
    public class MateriaTransmutatorMK2 : ModItem
    {
        public override bool IsLoadingEnabled(Mod mod)
        {
            ModLoader.TryGetMod("CalamityMod", out Calamity);
            return Calamity != null;
        }

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.maxStack = 99;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = 1;
            Item.consumable = true;
            Item.rare = 11;
            Item.value = 1000000;
            Item.createTile = ModContent.TileType<Tiles.MateriaTransmutatorMK2>();
        }

        public override void AddRecipes()
        {
            Recipe recipe = Recipe.Create(Item.type);
            recipe.AddIngredient(Mod, "MateriaTransmutator");
            if (Calamity != null && Calamity.TryFind<ModItem>("DraedonsForge", out ModItem currItem))
            {
                recipe.AddIngredient(currItem.Type);
            }
            recipe.Register();
        }
        private Mod Calamity;
    }
}