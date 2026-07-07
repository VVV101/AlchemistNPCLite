using AlchemistNPCLite.Utilities;
using Terraria;
using Terraria.ModLoader;

namespace AlchemistNPCLite.Globals
{
    // Gregg: fills any shop registered with ShopPaginator with its current page. Fires for every
    // NPC's shop (this is how we detect a non-paginated shop opening and hide the nav panel too).
    public class ShopPaginatorGlobalNPC : GlobalNPC
    {
        public override void ModifyActiveShop(NPC npc, string shopName, Item[] items)
        {
            ShopPaginator.Apply(shopName, items, npc);
        }
    }
}
