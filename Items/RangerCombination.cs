using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlchemistNPCLite.Items
{
    public class RangerCombination : ModItem
    {
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
            Item.width = 32;
            Item.height = 32;
            Item.value = Item.sellPrice(0, 0, 5, 0);
            Item.rare = 10;
            Item.buffType = ModContent.BuffType<Buffs.RangerComb>();           //this is where you put your Buff
            Item.buffTime = 52000;    //this is the buff duration        10 = 10 Second
            return;
        }

        public override void AddRecipes()
        {
            Recipe recipe = Recipe.Create(Item.type);
            recipe.AddIngredient(ItemID.ArcheryPotion, 1);
            recipe.AddIngredient(ItemID.AmmoReservationPotion, 1);
            recipe.AddIngredient(ItemID.WrathPotion, 1);
            recipe.AddIngredient(ItemID.RagePotion, 1);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.Register();
        }
    }
}
