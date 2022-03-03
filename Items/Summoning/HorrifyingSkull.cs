using Terraria.Localization;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using static Terraria.ModLoader.ModContent;

namespace AlchemistNPCLite.Items.Summoning
{
	public class HorrifyingSkull : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Horrifying Skull");
			Tooltip.SetDefault("Summons the mightiest enemy"
			+"\nUse with the extreme care");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Пугающий Череп");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Призывает могущественного противника\nИспользовать с крайней осторожностью");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 3;
		}

		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 20;
			Item.maxStack = 20;
			Item.value = 100;
			Item.rare = 1;
			Item.useAnimation = 30;
			Item.useTime = 30;
			Item.useStyle = 4;
			Item.consumable = true;
		}

		public override bool? UseItem(Player player)
		{
			if (player.whoAmI == Main.myPlayer) {
				int type = NPCID.DungeonGuardian;

				if (Main.netMode != NetmodeID.MultiplayerClient) {
					NPC.SpawnOnPlayer(player.whoAmI, type);
				}
				else {
					// NPCID.Sets.MPAllowedEnemies[type] is set in ModGlobalNPC
					NetMessage.SendData(MessageID.SpawnBoss, number: player.whoAmI, number2: type);
				}
			}
			return true;
		}
	}
}