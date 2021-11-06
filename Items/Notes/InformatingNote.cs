using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCLite.Items.Notes
{
	public class InformatingNote : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Informating Note");
			Tooltip.SetDefault("No Treasure Bags available yet."
			+"\nBeat Skeletron to unlock the first wave.");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Информирующая Записка");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Нет доступных Сумок Боссов.\nПобедите Скелетрона, чтобы разблокировать первую волну.");
        }

		public override void SetDefaults()
		{
			Item.width = 28;
			Item.height = 36;
			Item.maxStack = 1;
			Item.rare = 3;
		}	
	}
}