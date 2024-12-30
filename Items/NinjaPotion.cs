using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlchemistNPCLite.Items
{
    public class NinjaPotion : ModItem
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
            Item.value = Item.sellPrice(0, 5, 0, 0);
            Item.rare = 7;
            Item.buffType = ModContent.BuffType<Buffs.NinjaSkill>();           //this is where you put your Buff
            Item.buffTime = 36000;    //this is the buff duration        10 = 10 Second
            return;
        }

        public override void AddRecipes()
        {
            Recipe recipeCursedFlame = Recipe.Create(Item.type);
            recipeCursedFlame.AddIngredient(ItemID.Daybloom, 1);
            recipeCursedFlame.AddIngredient(ItemID.Waterleaf, 1);
            recipeCursedFlame.AddIngredient(ItemID.Fireblossom, 1);
            recipeCursedFlame.AddIngredient(ItemID.Deathweed, 1);
            recipeCursedFlame.AddIngredient(ItemID.HellstoneBar, 1);
            recipeCursedFlame.AddIngredient(ItemID.RottenChunk, 2);
            recipeCursedFlame.AddIngredient(ItemID.SoulofNight, 3);
            recipeCursedFlame.AddIngredient(ItemID.BottledWater, 1);
            recipeCursedFlame.AddIngredient(ItemID.ChlorophyteOre, 1);
            recipeCursedFlame.AddIngredient(ItemID.Ectoplasm, 1);
            recipeCursedFlame.AddTile(TileID.Bottles);

            Recipe recipeIchor = recipeCursedFlame.Clone();

            recipeCursedFlame.AddIngredient(ItemID.CursedFlame, 1);
            recipeIchor.AddIngredient(ItemID.Ichor, 1);

            recipeCursedFlame.Register();
            recipeIchor.Register();
        }
    }
}
