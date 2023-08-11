using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using AlchemistNPCLite.Projectiles;
using System.IO;
using AlchemistNPCLite.NPCs;
using Terraria.ModLoader.IO;

namespace AlchemistNPCLite.Projectiles
{
	public class AlchemistGlobalProjectile : GlobalProjectile
	{
		public override bool InstancePerEntity
		{
			get { return true; }
		}
		
		public override Color? GetAlpha(Projectile projectile, Color lightColor)
        {
			foreach (var player in Main.player) 
			{
				if (player.active && player.HasBuff(ModContent.BuffType<Buffs.GreaterDangersense>()))
				{
					if (projectile.hostile && !projectile.friendly && (projectile.type < 452 || projectile.type > 462))
					{
						Lighting.AddLight(projectile.Center, 1f, 1f, 0f);
						return Color.Yellow;
					}
				}
			}
			return base.GetAlpha(projectile, lightColor);
        }

		public override void OnHitNPC(Projectile projectile, NPC target, NPC.HitInfo hit, int damageDone)
		{
			Player player = Main.player[projectile.owner];
			if (((AlchemistNPCLitePlayer)player.GetModPlayer<AlchemistNPCLitePlayer>()).Traps == true)
			{
				if (projectile.type == 98)
				{
					if (Main.expertMode)
					{
						projectile.damage += 40;
					}
					else
					{
						projectile.damage += 20;
					}
					target.immune[projectile.owner] = 1;
				}
				else if (projectile.type == 184)
				{
					if (Main.expertMode)
					{
						projectile.damage += 40;
					}
					else
					{
						projectile.damage += 20;
					}
					target.immune[projectile.owner] = 1;
				}
				else if (projectile.type == 185)
				{
					if (Main.expertMode)
					{
						projectile.damage += 40;
					}
					else
					{
						projectile.damage += 20;
					}
					target.immune[projectile.owner] = 3;
				}
				else if (projectile.type == 186)
				{
					if (Main.expertMode)
					{
						projectile.damage += 20;
					}
					else
					{
						projectile.damage += 10;
					}
					target.immune[projectile.owner] = 1;
				}
				else if (projectile.type == 187)
				{
					if (Main.expertMode)
					{
						projectile.damage += 40;
					}
					else
					{
						projectile.damage += 20;
					}
					target.immune[projectile.owner] = 2;
				}
				else if (projectile.type == 188)
				{
					if (Main.expertMode)
					{
						projectile.damage += 40;
					}
					else
					{
						projectile.damage += 20;
					}
					target.immune[projectile.owner] = 2;
				}
				else if (projectile.type == 654)
				{
					if (Main.expertMode)
					{
						projectile.damage += 40;
					}
					else
					{
						projectile.damage += 20;
					}
					target.immune[projectile.owner] = 2;
				}
			}
		}
	}
}