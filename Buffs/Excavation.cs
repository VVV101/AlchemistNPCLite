using Terraria;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPCLite.Buffs
{
    public class Excavation : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = false;
            BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
        }
		
		public override void ModifyBuffText(ref string buffName, ref string tip, ref int rare)
		{
			Player player = Main.player[Main.myPlayer];
			AlchemistNPCLitePlayer modPlayer = player.GetModPlayer<AlchemistNPCLitePlayer>();
			tip = Language.GetTextValue("Mods.AlchemistNPCLite.Excavation1")+"\n"+Language.GetTextValue("Mods.AlchemistNPCLite.Excavation2")+" "+modPlayer.ExcavationPower+" x "+modPlayer.ExcavationPower+"\n"+Language.GetTextValue("Mods.AlchemistNPCLite.Excavation3");
		}
		
		public override bool RightClick(int buffIndex)
		{
			Player player = Main.player[Main.myPlayer];
			AlchemistNPCLitePlayer modPlayer = player.GetModPlayer<AlchemistNPCLitePlayer>();
            switch (modPlayer.ExcavationPower)
			{
				case 1: modPlayer.ExcavationPower  = 3; break;
				case 3: modPlayer.ExcavationPower  = 1; break;
			}
			if (PlayerInput.Triggers.Current.SmartCursor) return true;
			return false;
		}
		
    }
}
