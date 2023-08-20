using AlchemistNPCLite.Interface;
using AlchemistNPCLite.Items;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;
using static Terraria.ModLoader.ModContent;

namespace AlchemistNPCLite
{
    public class AlchemistNPCLite : Mod
    {
        public static Mod Instance;
        internal static AlchemistNPCLite instance;
        internal static ModConfiguration modConfiguration;
        public static ModKeybind DiscordBuff;
        public static bool SF = false;
        public static bool GreaterDangersense = false;
        public static int DTH = 0;
        public static float ppx = 0f;
        public static float ppy = 0f;
        public static string GithubUserName { get { return "VVV101"; } }
        public static string GithubProjectName { get { return "AlchemistNPCLite"; } }
        public static int ReversivityCoinTier1ID;
        public static int ReversivityCoinTier2ID;
        public static int ReversivityCoinTier3ID;
        public static int ReversivityCoinTier4ID;
        public static int ReversivityCoinTier5ID;
        public static int ReversivityCoinTier6ID;
        private UserInterface alchemistUserInterface;
        internal ShopChangeUI alchemistUI;
        private UserInterface alchemistUserInterfaceA;
        internal ShopChangeUIA alchemistUIA;
        private UserInterface alchemistUserInterfaceO;
        internal ShopChangeUIO alchemistUIO;
        private UserInterface alchemistUserInterfaceM;
        internal ShopChangeUIM alchemistUIM;

        public override void Load()
        {
            Instance = this;
            string DiscordBuffTeleportation = Language.GetTextValue("Discord Buff Teleportation");
            DiscordBuff = KeybindLoader.RegisterKeybind(this, DiscordBuffTeleportation, "Q");
            instance = this;
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

        public override void PostSetupContent()
        {
            ModLoader.TryGetMod("Census", out Mod censusMod);
            if (censusMod != null)
            {
                censusMod.Call("TownNPCCondition", NPCType<NPCs.Alchemist>(), "Defeat Eye of Cthulhu");
                censusMod.Call("TownNPCCondition", NPCType<NPCs.Brewer>(), "Defeat Eye of Cthulhu");
                censusMod.Call("TownNPCCondition", NPCType<NPCs.Jeweler>(), "Defeat Eye of Cthulhu");
                censusMod.Call("TownNPCCondition", NPCType<NPCs.Tinkerer>(), "Defeat Eye of Cthulhu");
                censusMod.Call("TownNPCCondition", NPCType<NPCs.Architect>(), "Have any 3 other NPC present");
                censusMod.Call("TownNPCCondition", NPCType<NPCs.Operator>(), "Defeat Eater of Worlds/Brain of Cthulhu");
                censusMod.Call("TownNPCCondition", NPCType<NPCs.Musician>(), "Defeat Skeletron");
                censusMod.Call("TownNPCCondition", NPCType<NPCs.YoungBrewer>(), "World state is Hardmode and both Alchemist and Operator are alive");
            }
        }

        public override void Unload()
        {
            Instance = null;
            instance = null;
            DiscordBuff = null;
            modConfiguration = null;
        }

        public override void HandlePacket(BinaryReader reader, int whoAmI)
        {
            AlchemistNPCLiteMessageType msgType = (AlchemistNPCLiteMessageType)reader.ReadByte();
            switch (msgType)
            {
                case AlchemistNPCLiteMessageType.TeleportPlayer:
                    TeleportClass.HandleTeleport(reader.ReadInt32(), true, whoAmI);
                    break;
                default:
                    Logger.Error("AlchemistNPCLite: Unknown Message type: " + msgType);
                    break;
            }
        }

        public enum AlchemistNPCLiteMessageType : byte
        {
            TeleportPlayer
        }
    }
}
