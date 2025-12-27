using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlchemistNPCLite.Items.Summoning
{
    public class SingleUseCellphone : ModItem
    {
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
			Chest.SetupTravelShop();
            if (player.whoAmI == Main.myPlayer)
            {
                int type = NPCID.TravellingMerchant;

                if (Main.netMode != NetmodeID.MultiplayerClient)
                {
                    NPC.SpawnOnPlayer(player.whoAmI, type);
                }
                else
                {
                    // NPCID.Sets.MPAllowedEnemies[type] is set in ModGlobalNPC
                    NetMessage.SendData(MessageID.SpawnBossUseLicenseStartEvent, number: player.whoAmI, number2: type);
                }
            }
            return true;
        }
		
		public override bool CanUseItem(Player player)
        {
            return !NPC.AnyNPCs(NPCID.TravellingMerchant) && Main.dayTime;
        }
    }
}