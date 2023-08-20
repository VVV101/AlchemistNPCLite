using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlchemistNPCLite.Items
{
    public class ThoriumCombination : ModItem
    {
       public override bool IsLoadingEnabled(Mod mod)
        {
            ModLoader.TryGetMod("ThoriumMod", out Mod Thorium);
            return Thorium != null;
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
            Item.width = 32;
            Item.height = 32;
            Item.value = Item.sellPrice(0, 8, 0, 0);
            Item.rare = 10;
            Item.buffType = ModContent.BuffType<Buffs.ThoriumComb>();           //this is where you put your Buff
            Item.buffTime = 52000;    //this is the buff duration        10 = 10 Second
        }
		
		public override void AddRecipes()
        {
            Recipe recipe = Recipe.Create(Item.type); ;
            recipe.AddTile(TileID.AlchemyTable);
            string[][] modComponents = new string[][]{
                new string[] {"ThoriumMod", "AssassinPotion"},
				new string[] {"ThoriumMod", "BloodPotion"},
                new string[] {"ThoriumMod", "FrenzyPotion"},
                new string[] {"ThoriumMod", "CreativityPotion"},
				new string[] {"ThoriumMod", "EarwormPotion"},
				new string[] {"ThoriumMod", "InspirationReachPotion"},
				new string[] {"ThoriumMod", "GlowingPotion"},
				new string[] {"ThoriumMod", "HolyPotion"},
				new string[] {"ThoriumMod", "HydrationPotion"}
            };
            foreach (string[] arr in modComponents)
            {
                if (ModContent.TryFind<ModItem>(arr[0], arr[1], out ModItem currItem))
                {
                    recipe.AddIngredient(currItem, 1);
                }
            }
            recipe.Register();
        }
    }
}
