using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlchemistNPCLite.Items
{
    public class HeartAttackPotion : ModItem
    {
        public override bool IsLoadingEnabled(Mod mod)
        {
            return false;
            // IMPLEMENT, DISABLED UNTIL THEN
            /*
			ModLoader.TryGetMod("CalamityMod", out Calamity);
			return Calamity != null;
			*/
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
            Item.maxStack = 30;
            Item.consumable = true;
            Item.width = 20;
            Item.height = 30;
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.rare = 10;
            if (Calamity.TryFind<ModBuff>("AbsoluteRage", out ModBuff currBuff))
                Item.buffType = currBuff.Type;
            Item.buffTime = 18000;
        }

        public bool CalamityModRevengeance
        {
            get
            {
                if (ModLoader.TryGetMod("CalamityMod", out Mod Calamity))
                {
                    return (bool)Calamity.Call("GetDifficultyActive", "revengeance");
                }
                return false;
            }
        }

        public override bool CanUseItem(Player player)
        {
            for (int v = 0; v < 200; ++v)
            {
                NPC npc = Main.npc[v];
                if (npc.active && npc.boss)
                {
                    return false;
                }
            }
            if (CalamityModRevengeance)
            {
                return true;
            }
            return false;
        }

        private Mod Calamity;

        // IMPLEMENT
        /*
		public override bool? UseItem(Player player)
		{
			CalamityMod.CalPlayer.CalamityPlayer CalamityPlayer = Player.GetModPlayer<CalamityMod.CalPlayer.CalamityPlayer>();
			CalamityPlayer.rage = CalamityPlayer.rageMax;
			return true;
		}
		*/
    }
}
