using Terraria;
using Terraria.GameContent.Creative;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using Microsoft.Xna.Framework;

namespace AlchemistNPCLite.Items.Summoning
{
	public class TinkererHorcrux : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tinkerer Horcrux");
			Tooltip.SetDefault("The piece of Tinkerer's soul is inside it.");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Крестраж Инженера");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Часть души Инженера находится внутри");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "音乐家魂器");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "里面有音乐家的一片灵魂.");
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
			Item.makeNPC = (short)ModContent.NPCType<NPCs.Tinkerer>();
		}

		public override void HoldItem(Player player)
		{
			Player.tileRangeX += 600;
			Player.tileRangeY += 600;
		}
		
		public override bool CanUseItem(Player player)
		{
			Vector2 vector2 = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
			return (!NPC.AnyNPCs(ModContent.NPCType<NPCs.Tinkerer>()) && !Collision.SolidCollision(vector2, player.width, player.height));
		}
		
		public override void OnConsumeItem(Player player)
		{
			Main.NewText("A Tinkerer is spawned.", 255, 255, 255);
		}
	}
}