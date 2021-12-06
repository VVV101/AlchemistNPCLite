using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using AlchemistNPCLite.NPCs;
using Terraria.Localization;
using Terraria.ID;

namespace AlchemistNPCLite.Buffs
{
    public class Corrosion : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Corrosion");
            Description.SetDefault("Your flesh is melting!");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = false;
            BuffID.Sets.LongerExpertDebuff[Type] = true;
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Коррозия");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Ваша плоть плавится!");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "腐蚀");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "你的肉体正在融化!");
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<ModGlobalNPC>().corrosion = true;
        }
    }
}