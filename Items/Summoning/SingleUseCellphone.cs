using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlchemistNPCLite.Items.Summoning
{
    public class SingleUseCellphone : ModItem
    {
		public override bool IsLoadingEnabled(Mod mod) {
			return ModContent.GetInstance<ModConfiguration>().ModItems;
		}
		
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 3;
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.maxStack = 20;
            Item.value = 1000;
            Item.rare = 1;
            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.useStyle = 4;
            Item.consumable = true;
        }

        public override bool? UseItem(Player player)
        {
            if (player.whoAmI != Main.myPlayer)
                return true;

            if (Main.netMode == NetmodeID.SinglePlayer)
            {
                // Gregg: single player - set up the shop and spawn directly
                Chest.SetupTravelShop();
                NPC.SpawnOnPlayer(player.whoAmI, NPCID.TravellingMerchant);
            }
            else
            {
                // Gregg: in MP the SpawnBoss path doesn't set up the merchant's shop; ask the server
                // to do SetupTravelShop + SendTravelShop + SpawnOnPlayer (see HandlePacket)
                var packet = Mod.GetPacket();
                packet.Write((byte)AlchemistNPCLite.AlchemistNPCLiteMessageType.SpawnTravelMerchant);
                packet.Write(player.whoAmI);
                packet.Send();
            }
            return true;
        }
		
		public override bool CanUseItem(Player player)
        {
            return !NPC.AnyNPCs(NPCID.TravellingMerchant) && Main.dayTime;
        }
    }
}