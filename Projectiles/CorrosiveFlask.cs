using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using static Terraria.ModLoader.ModContent;

namespace AlchemistNPCLite.Projectiles
{
	public class CorrosiveFlask : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Corrosive Flask");
		}
		
		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.ToxicFlask);
			Projectile.damage = 350;
			AIType = ProjectileID.ToxicFlask;
			Projectile.DamageType = DamageClass.Throwing;
		}

		public override bool PreKill(int timeLeft)
		{
			Projectile.type = ProjectileID.ToxicFlask;
			return true;
		}

		public override void Kill(int timeLeft)
		{
			Player player = Main.player[Projectile.owner];
			SoundEngine.PlaySound(SoundID.Item107, Projectile.position);
			Gore.NewGore(Projectile.GetSource_FromThis(), Projectile.position, -Projectile.oldVelocity * 0.2f, 704, 1f);
			if (Projectile.owner == Main.myPlayer)
			{
				int num220 = Main.rand.Next(20, 31);
				for (int num221 = 0; num221 < num220; num221++)
				{
					Vector2 value17 = new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101));
					value17.Normalize();
					value17 *= Main.rand.Next(20, 402) * 0.01f;
					Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, value17.X, value17.Y, ModContent.ProjectileType<CorrosiveFlaskCloud>(), Projectile.damage, 1f, Projectile.owner, 0f, Main.rand.Next(-30, 2));
				}
			}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
			{
				target.AddBuff(ModContent.BuffType<Buffs.Corrosion>(), 300);
				target.immune[Projectile.owner] = 1;
			}
	}
}