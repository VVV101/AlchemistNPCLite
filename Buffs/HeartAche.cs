using Terraria;
using Terraria.ModLoader;
using AlchemistNPCLite.NPCs;
using Terraria.Localization;

namespace AlchemistNPCLite.Buffs
{
	public class HeartAche : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Heart Ache");
			Description.SetDefault("You cannot use Potion of Darkness now");
			Main.debuff[Type] = true;
			Main.buffNoSave[Type] = false;
			longerExpertDebuff = false;
			canBeCleared = false;
			DisplayName.AddTranslation(GameCulture.Russian, "Боль Сердца");
			Description.AddTranslation(GameCulture.Russian, "Вы не можете использовать Зелье Тьмы сейчас");
			DisplayName.AddTranslation(GameCulture.Chinese, "痛心");
            		Description.AddTranslation(GameCulture.Chinese, "无法使用黑暗药剂");
        }
	}
}
