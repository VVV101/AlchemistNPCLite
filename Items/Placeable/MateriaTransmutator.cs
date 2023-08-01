using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlchemistNPCLite.Items.Placeable
{
    public class MateriaTransmutator : ModItem
    {
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
            Item.createTile = ModContent.TileType<Tiles.MateriaTransmutator>();
        }

        public override void AddRecipes()
        {
            Recipe recipe = Recipe.Create(Item.type);
            recipe.AddIngredient(null, "PreHMPenny");
            recipe.AddIngredient(null, "HMCraftPound");
            recipe.AddIngredient(null, "SpecCraftPoint");
            recipe.AddIngredient(ItemID.ManaCrystal);
            recipe.AddIngredient(ItemID.DD2ElderCrystalStand);
            recipe.AddIngredient(ItemID.FragmentSolar, 10);
            recipe.AddIngredient(ItemID.FragmentNebula, 10);
            recipe.AddIngredient(ItemID.FragmentVortex, 10);
            recipe.AddIngredient(ItemID.FragmentStardust, 10);
            // IMPLEMENT WHEN WEAKREFERENCES FIXED
            /*
			if (ModLoader.GetMod("ThoriumMod") != null)
			{
				recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("ThoriumAnvil")));
				recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("ArcaneArmorFabricator")));
				recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("SoulForge")));
			}
			*/
            recipe.Register();
        }
    }
}