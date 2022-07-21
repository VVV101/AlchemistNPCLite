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
		[Label("Alchemist Spawn toggle")]
		[Tooltip("True to enable Alchemist NPC spawn, false to disable. True by default")]
		public bool AlchemistSpawn;
		
		[DefaultValue(true)]
		[Label("Brewer Spawn toggle")]
		[Tooltip("True to enable Brewer NPC spawn, false to disable. True by default")]
		public bool BrewerSpawn;
		
		[DefaultValue(true)]
		[Label("Jeweler Spawn toggle")]
		[Tooltip("True to enable Jeweler NPC spawn, false to disable. True by default")]
		public bool JewelerSpawn;
		
		[DefaultValue(true)]
		[Label("Young Brewer Spawn toggle")]
		[Tooltip("True to enable Young Brewer NPC spawn, false to disable. True by default")]
		public bool YoungBrewerSpawn;
		
		[DefaultValue(true)]
		[Label("Architect Spawn toggle")]
		[Tooltip("True to enable Architect NPC spawn, false to disable. True by default")]
		public bool ArchitectSpawn;
		
		[DefaultValue(true)]
		[Label("Operator Spawn toggle")]
		[Tooltip("True to enable Operator NPC spawn, false to disable. True by default")]
		public bool OperatorSpawn;
		
		[DefaultValue(true)]
		[Label("Musician Spawn toggle")]
		[Tooltip("True to enable Musician NPC spawn, false to disable. True by default")]
		public bool MusicianSpawn;
		
		[DefaultValue(true)]
		[Label("Tinkerer Spawn toggle")]
		[Tooltip("True to enable Tinkerer NPC spawn, false to disable. True by default")]
		public bool TinkererSpawn;
		
		[DefaultValue(true)]
		[Label("Lifeform Analyzer laser pointing")]
		[Tooltip("Enable or disable laser pointing of Lifeform Analyzer (ticks each second). True by default")]
		public bool LifeformAnalyzer;

		[Range(40, 4000)]
		[DefaultValue(4000)]
		[Label("Lifeform Analyzer Pointing Range")]
		[Tooltip("Max distance the pointer will track. 4000 by default")]
		public int LocatorRange;
		
		//[Range(-4000, 4000)]
		[Label("Disabled NPCs for Lifeform Analyzer Locator")]
		[Tooltip("Arrows won't point to these NPCs")]
		public HashSet<NPCDefinition> DisabledLocatorNpcs = new HashSet<NPCDefinition>();

		[DefaultValue(true)]
		[Label("Revengeance mode prices scaling")]
		[Tooltip("True to make potions prices bigger. True by default")]
		public bool RevPrices;
		
		[DefaultValue(true)]
		[Label("Catcheable mod's NPCs toggle")]
		[Tooltip("True to make mod's town NPCs catcheable. True by default")]
		public bool CatchNPC;
		
		[Range(1, 1000)]
		[DefaultValue(1)]
		[Label("Potions price multiplier")]
		[Tooltip("Multiplies potions price by X. 1 by default")]
		public int PotsPriceMulti;
		
		[Range(1, 1000000)]
		[DefaultValue(1000)]
		[Label("Fallen Stars Price")]
		[Tooltip("1000 is 10 silver price by default")]
		public int StarPrice;
		
		[Range(1, 1000000)]
		[DefaultValue(1000)]
		[Label("Recall Potion Price")]
		[Tooltip("1000 is 10 silver price by default")]
		public int RecallPrice;
		
		[Range(1, 1000000)]
		[DefaultValue(1000)]
		[Label("Wormhole Potion Price")]
		[Tooltip("1000 is 10 silver price by default")]
		public int WormholePrice;
		
		[Range(1, 1000000)]
		[DefaultValue(700)]
		[Label("Silt/Slush blocks Price")]
		[Tooltip("700 is 7 silver price by default")]
		public int SiltSlushPrice;
		
		[Range(1, 1000000)]
		[DefaultValue(1000)]
		[Label("Desert Fossil Price")]
		[Tooltip("1000 is 10 silver price by default")]
		public int DesertFossilPrice;

		[Range(0, 100)]
		[DefaultValue(10)]
		[Label("Shop Change Delay")]
		[Tooltip("Delay before shop can be changed after opening interface. 10 frames by default")]
		public int ShopChangeDelay;

		public override ModConfig Clone() {
			var clone = (ModConfiguration)base.Clone();
			return clone;
		}

		public override void OnLoaded() {
			AlchemistNPCLite.modConfiguration = this;
		}

		public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref string message) {
			if (whoAmI == 0) {
				message = "Changes accepted!";
				return true;
			}
			if (whoAmI != 0)
			{
				message = "You have no rights to change AlchemistNPCLite.modConfiguration.";
				return false;
			}
			return false;
		}
	}
}
