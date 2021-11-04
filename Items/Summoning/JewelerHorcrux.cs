using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCLite.Items.Summoning
{
	public class JewelerHorcrux : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Jeweler Horcrux");
			Tooltip.SetDefault("The piece of Jeweler's soul is inside it.");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Крестраж Ювелира");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Часть души Ювелира находится внутри");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "珠宝师魂器");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "里面有珠宝师的一片灵魂");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 20;
			Item.maxStack = 30;
			Item.value = 15000;
			Item.rare = 6;
			Item.useAnimation = 30;
			Item.useTime = 30;
			Item.useStyle = 4;
			Item.consumable = true;
			Item.UseSound = SoundID.Item37;
			Item.makeNPC = (short)ModContent.NPCType<NPCs.Jeweler>();
		}

		public override void HoldItem(Player player)
		{
			Player.tileRangeX += 600;
			Player.tileRangeY += 600;
		}
		
		public override bool CanUseItem(Player player)
		{
			return !NPC.AnyNPCs(ModContent.NPCType<NPCs.Jeweler>());
		}

		public override void OnConsumeItem(Player player)
		{
			Main.NewText("A Jeweler is spawned.", 255, 255, 255);
		}
	}
}