using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using System;
using System.Linq;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.UI;

namespace AlchemistNPCLite.Projectiles
{
	public class CorrosiveFlaskCloud : ModProjectile
	{
        public override void SetDefaults()
        {
            Projectile.damage = 250;
			Projectile.width = 32;
            Projectile.height = 32;
            Projectile.penetrate = 12;
            Projectile.aiStyle = 92;
            AIType = 511;
            Projectile.friendly = true;
            Projectile.timeLeft = 600;
			Projectile.DamageType = DamageClass.Throwing;
        }
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
			{
				target.AddBuff(ModContent.BuffType<Buffs.Corrosion>(), 300);
				target.immune[Projectile.owner] = 3;
			}
    }
}