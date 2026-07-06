using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlchemistNPCLite.Items
{
    public class OceanTeleporterPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 20;
        }
        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.RecallPotion);
            Item.maxStack = 99;
            Item.consumable = true;
            return;
        }

        public override bool? UseItem(Player player)
        {
            // Gregg: teleport here, not in CanUseItem (that hook must be side-effect free)
            if (Main.myPlayer == player.whoAmI)
            {
                TeleportClass.HandleTeleport(player.altFunctionUse == 2 ? 1 : 2);
                return true;
            }
            return false;
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool CanRightClick()
        {
            return true;
        }

        public override void RightClick(Player player)
        {
            if (Main.myPlayer == player.whoAmI)
            {
                TeleportClass.HandleTeleport(1);
            }
        }
    }
}
