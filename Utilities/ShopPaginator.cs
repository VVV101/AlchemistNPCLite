using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ModLoader;

namespace AlchemistNPCLite.Utilities
{
    // Gregg: general, seamless shop pagination without any engine IL/detours.
    //
    // How it works:
    //  * A shop hands its full (unbounded) entry list here at AddShops() time via Register().
    //    We capture the entries and register an EMPTY stub NPCShop under the same name, so the
    //    name still opens the shop (a >39-entry real shop would trip tML's overflow warning on
    //    every open, hence the stub).
    //  * ShopPaginatorGlobalNPC.ModifyActiveShop routes the open shop through Apply(), which
    //    writes only the current page into the 40-slot array that vanilla is about to display.
    //  * The nav panel (ShopPageUI) flips the page and calls Chest.SetupShop(name, npc) on the
    //    already-open shop for a seamless in-place refill.
    //
    // Only public tML API is touched: NPCShop.Entries, GlobalNPC.ModifyActiveShop and the
    // public Chest.SetupShop(string, NPC).
    public static class ShopPaginator
    {
        // Items per page. 39 mirrors vanilla FillShop (which reserves the last of the 40 slots
        // when FillLastSlot is false), leaving room for the buyback slot. Navigation lives in a
        // separate panel, so no slot is spent on arrows.
        public const int ItemsPerPage = 39;

        // Full shop name (NPCShopDatabase.GetShopName) -> captured entries, in registration order.
        private static readonly Dictionary<string, List<NPCShop.Entry>> registry = new();

        // Full name of the currently-open paginated shop, or null when none is open.
        public static string ActiveShop { get; private set; }
        // The NPC that owns the open shop (cached: SetupShop skips ModifyActiveShop when npc==null).
        public static NPC ActiveNpc { get; private set; }
        // Zero-based page currently shown for ActiveShop.
        public static int CurrentPage { get; private set; }
        // Page count for the last fill, recomputed against live conditions.
        public static int ActivePageCount { get; private set; } = 1;

        public static bool IsPaginated(string fullShopName) =>
            fullShopName != null && registry.ContainsKey(fullShopName);

        /// <summary>
        /// Capture a built shop's entries for paging and register an empty stub under the same
        /// name so the shop still opens. Do NOT also call builtShop.Register().
        /// Note: entry ordering hints (OrderLast/SortBefore/After) are NOT applied — paginated
        /// shops are shown in registration order.
        /// </summary>
        public static void Register(NPCShop builtShop)
        {
            if (builtShop == null)
                return;

            registry[builtShop.FullName] = builtShop.Entries.ToList();
            new NPCShop(builtShop.NpcType, builtShop.Name).Register();
        }

        /// <summary>
        /// Entry point from ShopPaginatorGlobalNPC.ModifyActiveShop. Fills <paramref name="items"/>
        /// with the current page of <paramref name="fullShopName"/>, or clears the active state if
        /// the opened shop is not paginated.
        /// </summary>
        public static void Apply(string fullShopName, Item[] items, NPC npc)
        {
            if (!registry.TryGetValue(fullShopName, out var entries))
            {
                // A non-paginated shop is now the active one — hide the nav panel.
                ActiveShop = null;
                return;
            }

            if (fullShopName != ActiveShop)
            {
                // Fresh open (or switched tab/shop): start at the first page.
                ActiveShop = fullShopName;
                CurrentPage = 0;
            }
            ActiveNpc = npc;

            Fill(entries, items, npc);
        }

        // Mirrors NPCShop.FillShop semantics (Disabled / ConditionsMet / SlotReserved / OnShopOpen),
        // but writes only the current page's slice.
        private static void Fill(List<NPCShop.Entry> entries, Item[] items, NPC npc)
        {
            var visible = new List<NPCShop.Entry>(entries.Count);
            foreach (var e in entries)
            {
                if (e.Disabled)
                    continue;
                if (e.ConditionsMet() || e.SlotReserved)
                    visible.Add(e);
            }

            ActivePageCount = Math.Max(1, (visible.Count + ItemsPerPage - 1) / ItemsPerPage);
            if (CurrentPage < 0)
                CurrentPage = 0;
            if (CurrentPage >= ActivePageCount)
                CurrentPage = ActivePageCount - 1;

            Array.Fill(items, null);
            int start = CurrentPage * ItemsPerPage;
            for (int i = 0; i < ItemsPerPage && i < items.Length; i++)
            {
                int idx = start + i;
                if (idx >= visible.Count)
                    break;

                var e = visible[idx];
                if (e.ConditionsMet())
                {
                    Item item = e.Item.Clone();
                    e.OnShopOpen(item, npc);
                    items[i] = item;
                }
                else // SlotReserved but conditions not met
                {
                    items[i] = new Item(0);
                }
            }
            // Chest.SetupShop's epilogue null-fills the remaining slots and marks isAShopItem.
        }

        // True while a paginated shop with more than one page is open.
        public static bool NavVisible =>
            Main.npcShop > 0 && IsPaginated(ActiveShop) && ActivePageCount > 1;

        // Call every frame (client-side): drops the active shop once its window closes.
        public static void Update()
        {
            if (Main.npcShop <= 0)
                ActiveShop = null;
        }

        public static void NextPage()
        {
            if (ActiveShop == null || CurrentPage >= ActivePageCount - 1)
                return;
            CurrentPage++;
            Refresh();
        }

        public static void PrevPage()
        {
            if (ActiveShop == null || CurrentPage <= 0)
                return;
            CurrentPage--;
            Refresh();
        }

        // Seamless in-place refill of the open shop grid. Re-running SetupShop re-invokes our
        // ModifyActiveShop, which fills the (now changed) current page. No engine IL.
        private static void Refresh()
        {
            if (Main.npcShop <= 0 || ActiveShop == null || ActiveNpc == null)
                return;
            Main.instance.shop[Main.npcShop].SetupShop(ActiveShop, ActiveNpc);
        }
    }
}
