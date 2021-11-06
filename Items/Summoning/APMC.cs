using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using Microsoft.Xna.Framework;

namespace AlchemistNPCLite.Items.Summoning
{
	public class APMC : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("AI Programming and Memory Chip");
			Tooltip.SetDefault("It is Angela's backup.");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Модуль данных ИИ");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Это резервная копия Анджелы.");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "AI程序与记忆芯片");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "这是Angela的备份.");
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
			Item.makeNPC = (short)ModContent.NPCType<NPCs.Operator>();
		}

		public override void HoldItem(Player player)
		{
		Player.tileRangeX += 600;
        Player.tileRangeY += 600;
		}
		
		
		public override bool CanUseItem(Player player)
		{
			Vector2 vector2 = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
			return (!NPC.AnyNPCs(ModContent.NPCType<NPCs.Operator>()) && !Collision.SolidCollision(vector2, player.width, player.height));
		}

		public override void OnConsumeItem(Player player)
		{
			Main.NewText("An Operator is spawned.", 255, 255, 255);
		}
	}
}