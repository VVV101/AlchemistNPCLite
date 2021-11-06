using Terraria;
using Terraria.GameContent.Creative;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCLite.Items.Summoning
{
	public class AlchemistHorcrux : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Alchemist Horcrux");
			Tooltip.SetDefault("The piece of Alchemist's soul is inside it.");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Крестраж Алхимика");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Часть души Алхимика находится внутри");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "炼金师魂器");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "里面有炼金师的一片灵魂");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

		public override void SetDefaults()
		{
			Item.width = 46;
            Item.height = 42;
            Item.maxStack = 30;
            Item.rare = 10;
            Item.useStyle = 1;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.consumable = true;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.UseSound = SoundID.Item37;
			Item.makeNPC = (short)ModContent.NPCType<NPCs.Alchemist>();
		}

		public override void HoldItem(Player player)
		{
		Player.tileRangeX += 600;
        Player.tileRangeY += 600;
		}
		
		public override bool CanUseItem(Player player)
		{
			return !NPC.AnyNPCs(ModContent.NPCType<NPCs.Alchemist>());
		}
		
		public override void OnConsumeItem(Player player)
		{
			Main.NewText("An Alchemist is spawned.", 255, 255, 255);
		}
	}
}