using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlchemistNPCLite.Items
{
    public class GreaterDangersensePotion : ModItem
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
            Item.UseSound = SoundID.Item3;
            Item.useStyle = 2;
            Item.useTurn = true;
            Item.useAnimation = 17;
            Item.useTime = 17;
            Item.maxStack = 99;
            Item.consumable = true;
            Item.width = 20;
            Item.height = 30;
            Item.value = Item.sellPrice(0, 0, 2, 0);
            Item.rare = 7;
            Item.buffType = ModContent.BuffType<Buffs.GreaterDangersense>();
            Item.buffTime = 36000;
            return;
        }
    }
}
