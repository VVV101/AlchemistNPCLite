using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ObjectData;
using System.Collections.Generic;

namespace AlchemistNPCLite.Tiles
{
	public class AlchemistGlobalTiles : GlobalTile
	{
		public override int[] AdjTiles(int type)
		{
			if (type == ModContent.TileType<MateriaTransmutator>())
			{
				Main.LocalPlayer.adjHoney = true;
				Main.LocalPlayer.adjLava = true;
				Main.LocalPlayer.adjWater = true;
				Main.LocalPlayer.alchemyTable = true;
			}
			if (type == ModContent.TileType<MateriaTransmutatorMK2>())
			{
				Main.LocalPlayer.adjHoney = true;
				Main.LocalPlayer.adjLava = true;
				Main.LocalPlayer.adjWater = true;
				Main.LocalPlayer.alchemyTable = true;
			}
			if (type == ModContent.TileType<SpecCraftPoint>())
			{
				Main.LocalPlayer.adjHoney = true;
				Main.LocalPlayer.adjLava = true;
				Main.LocalPlayer.adjWater = true;
			}
			if (type == ModContent.TileType<PreHMPenny>())
			{
				Main.LocalPlayer.alchemyTable = true;
			}
			return base.AdjTiles(type);
		}
		
		/*public override void KillTile(int i, int j, int type, ref bool fail, ref bool effectOnly, ref bool noItem)
		{
			foreach (var player in Main.player) 
			{
				if (player.active && player.HasBuff(ModContent.BuffType<Buffs.Whatever>()))
				{
					player.PickTile(i-1, j-1, 35);
					player.PickTile(i-1, j, 35);
					player.PickTile(i, j-1, 35);
					player.PickTile(i+1, j+1, 35);
					player.PickTile(i+1, j, 35);
					player.PickTile(i, j+1, 35);
					player.PickTile(i+1, j-1, 35);
					player.PickTile(i-1, j+1, 35);
					player.PickTile(i, j, 35);
				}
			}
		}*/
	}
}