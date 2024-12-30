using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlchemistNPCLite.Items
{
    public class FortitudePotion : ModItem
    {
		public override bool IsLoadingEnabled(Mod mod) {
			return ModContent.GetInstance<ModConfiguration>().ModItems;
		}
		
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 20;
        }
        public override void SetDefaults()
        {
            Item.UseSound = SoundID.Item3;                 //this is the sound that plays when you use the item
            Item.useStyle = 2;                 //this is how the item is holded when used
            Item.useTurn = true;
            Item.useAnimation = 17;
            Item.useTime = 17;
            Item.maxStack = 99;                 //this is where you set the max stack of item
            Item.consumable = true;           //this make that the item is consumable when used
            Item.width = 20;
            Item.height = 30;
            Item.value = Item.sellPrice(0, 0, 5, 0);
            Item.rare = 7;
            Item.buffType = ModContent.BuffType<Buffs.Fortitude>();           //this is where you put your Buff
            Item.buffTime = 52000;    //this is the buff duration        10 = 10 Second
            return;
        }

        public override void AddRecipes()
        {
            Recipe recipeIron = Recipe.Create(Item.type);
            recipeIron.AddIngredient(ItemID.Waterleaf, 1);
            recipeIron.AddIngredient(ItemID.Moonglow, 1);
            recipeIron.AddIngredient(ItemID.Deathweed, 1);
            recipeIron.AddIngredient(ItemID.StoneBlock, 1);
            recipeIron.AddIngredient(ItemID.BottledWater, 1);
            recipeIron.AddTile(TileID.Bottles);

            Recipe recipeLead = recipeIron.Clone();

            recipeIron.AddIngredient(ItemID.IronOre, 1);
            recipeLead.AddIngredient(ItemID.LeadOre, 1);

            recipeIron.Register();
            recipeLead.Register();

        }
    }
}
