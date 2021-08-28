using Terraria.Localization;
using Terraria;
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
			NPC.NewNPC((int)player.position.X, (int)player.position.Y - 350, NPCID.DungeonGuardian);
            Main.NewText("Dungeon Guardian has awoken!", 175, 75, 255);
            NetMessage.SendData(23, -1, -1, null, NPCID.DungeonGuardian, 0f, 0f, 0f, 0);
			SoundEngine.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
			return true;
		}
	}
}