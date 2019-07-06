using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPCLite.Items.Summoning
{
	public class MusicianHorcrux : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Musician Horcrux");
			Tooltip.SetDefault("The piece of Musician's soul is inside it.");
			DisplayName.AddTranslation(GameCulture.Russian, "Крестраж Музыканта");
			Tooltip.AddTranslation(GameCulture.Russian, "Часть души Музыканта находится внутри");
			DisplayName.AddTranslation(GameCulture.Chinese, "音乐家魂器");
			Tooltip.AddTranslation(GameCulture.Chinese, "里面有音乐家的一片灵魂.");
        }

		public override void SetDefaults()
		{
			item.width = 46;
            item.height = 42;
            item.maxStack = 1;
            item.rare = 10;
            item.useStyle = 1;
            item.useAnimation = 15;
            item.useTime = 15;
            item.consumable = true;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.UseSound = SoundID.Item37;
			item.makeNPC = (short)mod.NPCType("Musician");
		}

		public override void HoldItem(Player player)
		{
		Player.tileRangeX += 600;
        Player.tileRangeY += 600;
		}
		
		public override bool CanUseItem(Player player)
		{
			return !NPC.AnyNPCs(mod.NPCType("Musician"));
		}
		
		public override void OnConsumeItem(Player player)
		{
			Main.NewText("A Musician is spawned.", 255, 255, 255);
		}
	}
}
