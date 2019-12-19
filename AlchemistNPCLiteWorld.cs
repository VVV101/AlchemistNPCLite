using System.IO;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using Terraria.ModLoader.IO;
using Terraria.DataStructures;
using Microsoft.Xna.Framework.Graphics;

namespace AlchemistNPCLite
{
	public class AlchemistNPCLiteWorld : ModWorld
	{
		private const int saveVersion = 0;
		public static bool downedDOGPumpking;
		public static bool downedDOGIceQueen;

		public override void Initialize()
		{
			downedDOGIceQueen = false;
			downedDOGPumpking = false;
		}

		public override TagCompound Save()
		{
			var downed = new List<string>();
			if (downedDOGPumpking) downed.Add("DOGPumpking");
			if (downedDOGIceQueen) downed.Add("DOGIceQueen");
			
			return new TagCompound {
				{"downed", downed}
			};
		}
		
		public override void NetSend(BinaryWriter writer)
		{
			BitsByte flags = new BitsByte();
			flags[0] = downedDOGPumpking;
			flags[1] = downedDOGIceQueen;
			writer.Write(flags11);
		}

		public override void NetReceive(BinaryReader reader)
		{
			BitsByte flags = reader.ReadByte();
			downedDOGPumpking = flags[0];
			downedDOGIceQueen = flags[1];
			// As mentioned in NetSend, BitBytes can contain 8 values. If you have more, be sure to read the additional data:
			// BitsByte flags2 = reader.ReadByte();
			// downed9thBoss = flags[0];
		}

		public override void Load(TagCompound tag)
		{
			var downed = tag.GetList<string>("downed");
			downedDOGPumpking = downed.Contains("DOGPumpking");
			downedDOGIceQueen = downed.Contains("DOGIceQueen");
		}
	}
}
