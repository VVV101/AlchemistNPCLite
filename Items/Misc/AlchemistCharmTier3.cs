using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using AlchemistNPCLite;

namespace AlchemistNPCLite.Items.Misc
{
    public class AlchemistCharmTier3 : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Alchemist Charm Tier 3");
            Tooltip.SetDefault("While this is in your inventory, you have a high chance not to consume potion"
            + "\nAllows to use potions from Piggy Bank by Quick Buff"
            + "\nAlchemist, Brewer and Young Brewer are providing 35% discount"
            + "\nBuffs duration is 35% longer");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Талисман Алхимика Третьего Уровня");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Если находится в инвентаре, вы имеет большой шанс не потратить зелье\nПозволяет использовать зелья из Свиньи-Копилки с помощью клавиши Быстрого Баффа\nАлхимик, Зельеварщица и Юный Зельевар предоставляют скидку в 35%\nДлительность баффов увеличена на 35%");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.value = 3000000;
            Item.rare = 10;
        }

        public override void UpdateInventory(Player player)
        {
            (player.GetModPlayer<AlchemistNPCLitePlayer>()).AlchemistCharmTier3 = true;
            (player.GetModPlayer<AlchemistNPCLitePlayer>()).DistantPotionsUse = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = Recipe.Create(Item.type);
            recipe.AddIngredient(null, "AlchemistCharmTier2");
            recipe.AddRecipeGroup("AlchemistNPCLite:Tier3Bar", 15);
            recipe.AddRecipeGroup("AlchemistNPCLite:HardmodeComponent", 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}
