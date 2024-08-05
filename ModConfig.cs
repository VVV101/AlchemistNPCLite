using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader.Config;
using Terraria.ModLoader.Config.UI;
using Terraria.UI;

namespace AlchemistNPCLite
{
	public class ModConfiguration : ModConfig
	{
		public override ConfigScope Mode => ConfigScope.ServerSide;
		
		[DefaultValue(true)]
		public bool AlchemistSpawn;
		
		[DefaultValue(true)]
		public bool BrewerSpawn;
		
		[DefaultValue(true)]
		public bool JewelerSpawn;
		
		[DefaultValue(true)]
		public bool YoungBrewerSpawn;
		
		[DefaultValue(true)]
		public bool ArchitectSpawn;
		
		[DefaultValue(true)]
		public bool OperatorSpawn;
		
		[DefaultValue(true)]
		public bool MusicianSpawn;
		
		[DefaultValue(true)]
		public bool TinkererSpawn;
		
		[DefaultValue(true)]
		public bool LifeformAnalyzer;
		
		[DefaultValue(false)]
		public bool LifeformAnalyzerAlt;

		[Range(40, 4000)]
		[DefaultValue(4000)]
		public int LocatorRange;
		//[Range(-4000, 4000)]
		public HashSet<NPCDefinition> DisabledLocatorNpcs = new HashSet<NPCDefinition>();

		[DefaultValue(true)]
		public bool RevPrices;
		
		[DefaultValue(true)]
		public bool CatchNPC;
		
		[DefaultValue(true)]
		public bool ModItems;
		
		[Range(1, 1000)]
		[DefaultValue(1)]
		public int PotsPriceMulti;
		
		[Range(1, 1000000)]
		[DefaultValue(1000)]
		public int StarPrice;
		
		[Range(1, 1000000)]
		[DefaultValue(1000)]
		public int RecallPrice;
		
		[Range(1, 1000000)]
		[DefaultValue(1000)]
		public int WormholePrice;
		
		[Range(1, 1000000)]
		[DefaultValue(700)]
		public int SiltSlushPrice;
		
		[Range(1, 1000000)]
		[DefaultValue(1000)]
		public int DesertFossilPrice;

		[Range(0, 100)]
		[DefaultValue(10)]
		public int ShopChangeDelay;

		public override ModConfig Clone() {
			var clone = (ModConfiguration)base.Clone();
			return clone;
		}

		public override void OnLoaded() {
			AlchemistNPCLite.modConfiguration = this;
		}

		public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref string message) {
			if (!NetMessage.DoesPlayerSlotCountAsAHost(whoAmI)) {
				message = NetworkText.FromKey("tModLoader.ModConfigRejectChangesNotHost"); // "Only the host can change this config"
				return false;
			}
			return true;
		}
	}
}
