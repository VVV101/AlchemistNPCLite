using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
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
			if (AlchemistNPCLite.GreaterDangersense == true)
			{
				if (projectile.hostile && !projectile.friendly)
				{
					return Color.Yellow;
				}
			}
			return base.GetAlpha(projectile, lightColor);
        }
		
		public override void AI(Projectile projectile)
		{
			if (AlchemistNPCLite.GreaterDangersense == true)
			{
				if (projectile.hostile && !projectile.friendly)
				{
					Lighting.AddLight(projectile.Center, 1f, 1f, 0f);
				}
			}
		}

		public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit)
		{
			Player player = Main.player[projectile.owner];
			if ((projectile.type == 98) && ((AlchemistNPCLitePlayer)player.GetModPlayer(mod, "AlchemistNPCLitePlayer")).Traps == true)
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
			if ((projectile.type == 184) && ((AlchemistNPCLitePlayer)player.GetModPlayer(mod, "AlchemistNPCLitePlayer")).Traps == true)
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
			if ((projectile.type == 185) && ((AlchemistNPCLitePlayer)player.GetModPlayer(mod, "AlchemistNPCLitePlayer")).Traps == true)
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
			if ((projectile.type == 186) && ((AlchemistNPCLitePlayer)player.GetModPlayer(mod, "AlchemistNPCLitePlayer")).Traps == true)
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
			if ((projectile.type == 187) && ((AlchemistNPCLitePlayer)player.GetModPlayer(mod, "AlchemistNPCLitePlayer")).Traps == true)
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
			if ((projectile.type == 188) && ((AlchemistNPCLitePlayer)player.GetModPlayer(mod, "AlchemistNPCLitePlayer")).Traps == true)
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
			if ((projectile.type == 654) && ((AlchemistNPCLitePlayer)player.GetModPlayer(mod, "AlchemistNPCLitePlayer")).Traps == true)
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