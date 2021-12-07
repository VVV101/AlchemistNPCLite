using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using Terraria.ID;

namespace AlchemistNPCLite.Buffs
{
    public class LongInvincible : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Longer Invincibility");
            Description.SetDefault("Your invincibility time is increased");
            Main.debuff[Type] = false;
            BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Продлённая неуязвимость");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Ваш период неуязвимости увеличен");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "延长无敌");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "增加你的无敌时间");
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.longInvince = true;
        }
    }
}
