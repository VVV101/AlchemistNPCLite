using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using Terraria.GameContent.Events;
using AlchemistNPCLite;

namespace AlchemistNPCLite.Items.Misc
{
	public class WorldControlUnit : ModItem
	{
		public override bool IsLoadingEnabled(Mod mod) {
			return ModContent.GetInstance<ModConfiguration>().ModItems;
		}
		
		public override void SetStaticDefaults()
		{
			Item.ResearchUnlockCount = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.rare = 5;
			Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useStyle = 4;
			Item.UseSound = SoundID.Item4;
			Item.consumable = false;
		}
		
		public override bool CanRightClick()
        {            
            return true;
        }

		public override bool ConsumeItem(Player player)
		{
			return false;
		}

        public override void RightClick(Player player)
        {
			if (player.ZoneDesert)
			{
				if (Sandstorm.Happening)
				{
					if (Main.netMode == 0 || Main.netMode == 1)
					{
						Main.NewText(Language.GetTextValue("Mods.AlchemistNPCLite.Common.SandstormStopped"), 255, 255, 255);
					}
					Sandstorm.Happening = false;
					Sandstorm.TimeLeft = 0;
					Sandstorm.IntendedSeverity = !Sandstorm.Happening ? (Main.rand.Next(3) != 0 ? Main.rand.NextFloat() * 0.3f : 0.0f) : 0.4f + Main.rand.NextFloat();
					if (Main.netMode != 1) NetMessage.SendData(7);
					return;
				}
				if (!Sandstorm.Happening)
				{
					if (Main.netMode == 0 || Main.netMode == 1)
					{
						Main.NewText(Language.GetTextValue("Mods.AlchemistNPCLite.Common.SandstormStarted"), 255, 255, 255);
					}
					Sandstorm.Happening = true;
					Sandstorm.TimeLeft = 36000;
					Sandstorm.IntendedSeverity = !Sandstorm.Happening ? (Main.rand.Next(3) != 0 ? Main.rand.NextFloat() * 0.3f : 0.0f) : 0.4f + Main.rand.NextFloat();
					if (Main.netMode != 1) NetMessage.SendData(7);
					return;
				}
			}
			if (Main.raining)
			{
				if (Main.netMode == 0 || Main.netMode == 1)
				{
					Main.NewText(Language.GetTextValue("Mods.AlchemistNPCLite.Common.RainStopped"), 255, 255, 255);
				}
				Main.rainTime = 0;
				Main.maxRaining = 0f;
				Main.raining = false;
				return;
			}
			if (!Main.raining)
			{
				if (Main.netMode == 0 || Main.netMode == 1)
				{
					Main.NewText(Language.GetTextValue("Mods.AlchemistNPCLite.Common.RainStarted"), 255, 255, 255);
				}
				Main.rainTime = 24000;
				Main.maxRaining = 1f;
				Main.raining = true;
				return;
			}
		}
		
		public override bool? UseItem(Player player)
        {
			if (Main.dayTime)
			{
				if (Main.netMode == 0 || Main.netMode == 1)
				{
					Main.NewText(Language.GetTextValue("Mods.AlchemistNPCLite.Common.NightTimeSet"), 255, 255, 255);
				}
				Main.dayTime = false;
				Main.time = 0.0;
				return true;
			}
			if (!Main.dayTime)
			{
				if (Main.netMode == 0 || Main.netMode == 1)
				{
					Main.NewText(Language.GetTextValue("Mods.AlchemistNPCLite.Common.DayTimeSet"), 255, 255, 255);
				}
				Main.dayTime = true;
				Main.time = 0.0;
				return true;
			}
			return true;
		}
	}
}
