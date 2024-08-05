using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlchemistNPCLite.Items
{
    public class ExcavationPotion : ModItem
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
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.rare = 4;
            Item.buffType = ModContent.BuffType<Buffs.Excavation>();           //this is where you put your Buff
            Item.buffTime = 18000;    //this is the buff duration        10 = 10 Second
            return;
        }
		
		public override void AddRecipes()
        {
            Recipe recipe = Recipe.Create(Item.type, 5);
            recipe.AddIngredient(ItemID.RockLobster, 1);
            recipe.AddRecipeGroup("AlchemistNPCLite:AnyTier3PreHmOre", 5);
            recipe.AddIngredient(ItemID.BottledWater, 5);
            recipe.AddTile(TileID.Bottles);
            recipe.Register();
        }
    }
}
