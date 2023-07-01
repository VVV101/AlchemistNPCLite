using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace AlchemistNPCLite.Buffs
{
    public class NinjaSkill : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ninja");
            Description.SetDefault("You are a true ninja!");
            Main.debuff[Type] = false;
            BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Ниндзя");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Вы - истинный ниндзя!");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "忍者");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "现在你是个真正的忍者了!");
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.GetDamage(DamageClass.Generic) += 0.05f;
            player.GetCritChance(DamageClass.Melee) += 5;
            player.GetCritChance(DamageClass.Ranged) += 5;
            player.GetCritChance(DamageClass.Magic) += 5;
            player.GetCritChance(DamageClass.Throwing) += 5;
            player.blackBelt = true;
            player.spikedBoots = 2;
            if (ModLoader.TryGetMod("ThoriumMod", out Mod thoriumMod))
			{
				if (thoriumMod.TryFind("BardDamage", out DamageClass damageClass))
				{
					player.GetCritChance(damageClass) += 5;
				}
				if (thoriumMod.TryFind("HealerDamage", out DamageClass damageClass1))
				{
					player.GetCritChance(damageClass1) += 5;
				}
			}
        }
    }
}
