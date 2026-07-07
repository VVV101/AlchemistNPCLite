using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace AlchemistNPCLite
{
	public class ModConfiguration : ModConfig
	{
		public override ConfigScope Mode => ConfigScope.ServerSide;

		[Header("NpcSpawns")]
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
		
		[Header("LifeformLocator")]
		[DefaultValue(true)]
		public bool LifeformAnalyzer;

		[DefaultValue(false)]
		public bool LifeformAnalyzerAlt;

		[Range(40, 4000)]
		[DefaultValue(4000)]
		public int LocatorRange;
		//[Range(-4000, 4000)]
		public HashSet<NPCDefinition> DisabledLocatorNpcs = new HashSet<NPCDefinition>();

		[Header("General")]
		[DefaultValue(true)]
		public bool RevPrices;
		
		[DefaultValue(true)]
		public bool CatchNPC;
		
		[DefaultValue(true)]
		[ReloadRequired]
		public bool ModItems;
		
		[Header("ShopPrices")]
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

		// Gregg: user-defined items for the Operator's "Custom Items" shop tab.
		// Uses ItemDefinition, so any vanilla OR modded item resolves at runtime
		// without hardcoding mod names (items whose mod isn't loaded are skipped).
		[Header("OperatorShop")]
		[ReloadRequired]
		// Gregg: [SeparatePage] must sit on the LIST FIELD (not the item class) — it makes each entry open on
		// its own page (roomy Item/Price/Availability). tML checks the member then the member's TYPE, and for a
		// list the member Type is List<...>, so a class-level attribute is never seen for list items
		// (ConfigManager.GetCustomAttributeFromMemberThenMemberType). Entry labels come from OperatorShopItem.ToString().
		[SeparatePage]
		public List<OperatorShopItem> OperatorCustomItems = new List<OperatorShopItem>();

		// Gregg: same as OperatorCustomItems but for the Tinkerer's config-driven "Custom Items" tab.
		[Header("TinkererShop")]
		[ReloadRequired]
		[SeparatePage]
		public List<OperatorShopItem> TinkererCustomItems = new List<OperatorShopItem>();

		public override ModConfig Clone() {
			var clone = (ModConfiguration)base.Clone();
			return clone;
		}

		public override void OnLoaded() {
			AlchemistNPCLite.modConfiguration = this;
		}

		public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref NetworkText message) {
			if (!NetMessage.DoesPlayerSlotCountAsAHost(whoAmI)) {
				message = NetworkText.FromKey("tModLoader.ModConfigRejectChangesNotHost"); // "Only the host can change this config"
				return false;
			}
			message = NetworkText.FromKey("ModConfigAccepted");
			return true;
		}
	}

	// Gregg: one entry of a config-driven "Custom Items" shop (Operator, Tinkerer, ...). ToString() gives the
	// readable label for the [SeparatePage] entry button (tML renders list-item buttons as "N: {ToString()}").
	public class OperatorShopItem
	{
		public ItemDefinition Item = new ItemDefinition(0);

		[Range(1, 2000000000)]
		public int Price = 10000;

		[DefaultValue(OperatorShopGate.Always)]
		public OperatorShopGate Availability = OperatorShopGate.Always;

		public override bool Equals(object obj) =>
			obj is OperatorShopItem o && Item.Equals(o.Item) && Price == o.Price && Availability == o.Availability;

		public override int GetHashCode() => System.HashCode.Combine(Item, Price, Availability);

		// Gregg: readable label for the [SeparatePage] entry button. tML renders list-item buttons as
		// "N: {ToString()}" (ObjectElement) — without this override they read just "1:", "2:" and you
		// can't tell which item an entry configures. Show the item name + the availability gate.
		public override string ToString()
		{
			string name = (Item != null && Item.Type > 0)
				? Lang.GetItemNameValue(Item.Type)
				: (string.IsNullOrEmpty(Item?.Name) ? "(no item)" : Item.Name);
			return name + " — " + Availability;
		}
	}

	// Gregg: progression gate the user picks per custom item (conditions can't be serialized, so we offer presets).
	public enum OperatorShopGate
	{
		Always,
		Hardmode,
		PostEvilBoss,
		PostSkeletron,
		PostAnyMechBoss,
		PostPlantera,
		PostGolem,
		PostMoonLord
	}
}
