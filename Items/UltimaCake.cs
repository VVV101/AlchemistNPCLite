using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlchemistNPCLite.Items
{
    public class UltimaCake : ModItem
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
            Item.UseSound = SoundID.Item2;                 //this is the sound that plays when you use the item
            Item.useStyle = 2;                 //this is how the item is holded when used
            Item.useTurn = true;
            Item.useAnimation = 17;
            Item.useTime = 17;
            Item.maxStack = 1;                 //this is where you set the max stack of item
            Item.consumable = false;           //this make that the item is consumable when used
            Item.width = 18;
            Item.height = 28;
            Item.value = Item.sellPrice(1, 0, 0, 0);
            Item.rare = 7;
            Item.buffType = ModContent.BuffType<Buffs.StationUltimaBuff>();           //this is where you put your Buff
            Item.buffTime = 108000;    //this is the buff duration        10 = 10 Second
            return;
        }
    }
}
