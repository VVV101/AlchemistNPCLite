using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlchemistNPCLite
{
    public class StarPrice : GlobalItem
    {
        public override void SetDefaults(Item item)
        {
            switch(item.type)
            {
                case ItemID.FallenStar:
                    item.value = Config.StarPrice;
                    break;
            }
        }
    }
}