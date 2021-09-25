using System.IO;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;
using static Terraria.ModLoader.ModContent;
using Terraria.WorldBuilding;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using Terraria.ModLoader.IO;
using Terraria.DataStructures;
using Microsoft.Xna.Framework.Graphics;
using AlchemistNPCLite.Interface;

namespace AlchemistNPCLite
{
	public class AlchemistNPCLiteWorld : ModSystem
	{
		private const int saveVersion = 0;
		public static bool downedDOGPumpking;
		public static bool downedDOGIceQueen;
		public static bool downedSandElemental;
		private UserInterface alchemistUserInterface;
		internal ShopChangeUI alchemistUI;
		private UserInterface alchemistUserInterfaceA;
		internal ShopChangeUIA alchemistUIA;
		private UserInterface alchemistUserInterfaceO;
		internal ShopChangeUIO alchemistUIO;
		private UserInterface alchemistUserInterfaceM;
		internal ShopChangeUIM alchemistUIM;

		public override void OnWorldLoad()
		{
			downedDOGIceQueen = false;
			downedDOGPumpking = false;
			downedSandElemental = false;
			if (!Main.dedServ)
			{
                alchemistUI = new ShopChangeUI();
                alchemistUI.Activate();
                alchemistUserInterface = new UserInterface();
                alchemistUserInterface.SetState(alchemistUI);
                
                alchemistUIA = new ShopChangeUIA();
                alchemistUIA.Activate();
                alchemistUserInterfaceA = new UserInterface();
                alchemistUserInterfaceA.SetState(alchemistUIA);
                
                alchemistUIO = new ShopChangeUIO();
                alchemistUIO.Activate();
                alchemistUserInterfaceO = new UserInterface();
                alchemistUserInterfaceO.SetState(alchemistUIO);
                
                alchemistUIM = new ShopChangeUIM();
                alchemistUIM.Activate();
                alchemistUserInterfaceM = new UserInterface();
                alchemistUserInterfaceM.SetState(alchemistUIM);
			}
		}

		public override void SaveWorldData(TagCompound tag)
		{
			var downed = new List<string>();
			if (downedDOGPumpking) downed.Add("DOGPumpking");
			if (downedDOGIceQueen) downed.Add("DOGIceQueen");
			if (downedSandElemental) downed.Add("SandElemental");
			
			tag["downed"] = downed;
		}
		
		public override void NetSend(BinaryWriter writer)
		{
			BitsByte flags = new BitsByte();
			flags[0] = downedDOGPumpking;
			flags[1] = downedDOGIceQueen;
			flags[2] = downedSandElemental;
			writer.Write(flags);
		}

		public override void NetReceive(BinaryReader reader)
		{
			BitsByte flags = reader.ReadByte();
			downedDOGPumpking = flags[0];
			downedDOGIceQueen = flags[1];
			downedSandElemental = flags[2];
			// As mentioned in NetSend, BitBytes can contain 8 values. If you have more, be sure to read the additional data:
			// BitsByte flags2 = reader.ReadByte();
			// downed9thBoss = flags[0];
		}

		public override void LoadWorldData(TagCompound tag)
		{
			var downed = tag.GetList<string>("downed");
			downedDOGPumpking = downed.Contains("DOGPumpking");
			downedDOGIceQueen = downed.Contains("DOGIceQueen");
			downedSandElemental = downed.Contains("SandElemental");
		}

		public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
		{
			int MouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
			if (MouseTextIndex != -1)
			{
				layers.Insert(MouseTextIndex, new LegacyGameInterfaceLayer(
					"AlchemistNPC: Shop Selector",
					delegate
					{
						if (ShopChangeUI.visible)
						{
							alchemistUI.Draw(Main.spriteBatch);
						}
						return true;
					},
					InterfaceScaleType.UI)
				);
			}
			int MouseTextIndexA = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
			if (MouseTextIndexA != -1)
			{
				layers.Insert(MouseTextIndexA, new LegacyGameInterfaceLayer(
					"AlchemistNPC: Shop Selector A",
					delegate
					{
						if (ShopChangeUIA.visible)
						{
							alchemistUIA.Draw(Main.spriteBatch);
						}
						return true;
					},
					InterfaceScaleType.UI)
				);
			}
			int MouseTextIndexO = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
			if (MouseTextIndexO != -1)
			{
				layers.Insert(MouseTextIndexO, new LegacyGameInterfaceLayer(
					"AlchemistNPC: Shop Selector O",
					delegate
					{
						if (ShopChangeUIO.visible)
						{
							alchemistUIO.Draw(Main.spriteBatch);
						}
						return true;
					},
					InterfaceScaleType.UI)
				);
			}
			int MouseTextIndexM = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
			if (MouseTextIndexM != -1)
			{
				layers.Insert(MouseTextIndexM, new LegacyGameInterfaceLayer(
					"AlchemistNPC: Shop Selector M",
					delegate
					{
						if (ShopChangeUIM.visible)
						{
							alchemistUIM.Draw(Main.spriteBatch);
						}
						return true;
					},
					InterfaceScaleType.UI)
				);
			}
		}

		public override void UpdateUI(GameTime gameTime)
		{
			if (alchemistUserInterface != null && ShopChangeUI.visible)
			{
				alchemistUserInterface.Update(gameTime);
			}
			
			if (alchemistUserInterfaceA != null && ShopChangeUIA.visible)
			{
				alchemistUserInterfaceA.Update(gameTime);
			}
			
			if (alchemistUserInterfaceO != null && ShopChangeUIO.visible)
			{
				alchemistUserInterfaceO.Update(gameTime);
			}
			
			if (alchemistUserInterfaceM != null && ShopChangeUIM.visible)
			{
				alchemistUserInterfaceM.Update(gameTime);
			}
		}
	}
}
