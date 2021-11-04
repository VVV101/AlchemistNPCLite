using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using AlchemistNPCLite.Items;

namespace AlchemistNPCLite.Items
{
    public class BeachTeleporterPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Beach Teleporter Potion");
            Tooltip.SetDefault("Teleports you to the Beach"
            + "\nSide depends on used mouse button");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Телепортёр к Пляжу");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Телепортирует вас на пляж\nСторона зависит от нажатой кнопки мыши");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "信标传送药剂");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "将你传送至信标处\n没有放置信标无法工作");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 20;
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
            if (Main.myPlayer == player.whoAmI)
            {
                return true;
            }
            return false;
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                if (Main.myPlayer == player.whoAmI)
                {
                    TeleportClass.HandleTeleport(3);
                    return true;
                }
            }
            if (player.altFunctionUse != 2)
            {
                if (Main.myPlayer == player.whoAmI)
                {
                    TeleportClass.HandleTeleport(4);
                    return true;
                }
            }
            return false;
        }

        public override bool CanRightClick()
        {
            return true;
        }

        public override void RightClick(Player player)
        {
            if (Main.myPlayer == player.whoAmI)
            {
                TeleportClass.HandleTeleport(3);
            }
        }
    }
}
