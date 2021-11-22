using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Terraria.Enums;
namespace AlchemistNPCLite.Projectiles
{
	class LocatorProjectile : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.width = 22;
			Projectile.height = 28;
			Projectile.light = 0.75f;
			// NO! Projectile.aiStyle = 48;
			Projectile.friendly = false;
			Projectile.hostile = false;
			Projectile.timeLeft = 61; // lowered from 300
			Projectile.penetrate = -1;
			Projectile.tileCollide = false;
		}

		public override void AI()
		{
			int NPCnumber = (int)Projectile.ai[0];
			Vector2 npcpos = new Vector2((int)Main.npc[NPCnumber].Center.X, (int)Main.npc[NPCnumber].Center.Y);
			Player player = Main.player[Projectile.owner];
			
			if (Projectile.owner == Main.myPlayer) // Multiplayer support
			{
				Vector2 diff = npcpos - player.Center;
				diff.Normalize();
				Projectile.velocity = diff;
				Projectile.direction = npcpos.X > player.Center.X ? 1 : -1;
				Projectile.netUpdate = true;
			}
			Projectile.position = player.position + Projectile.velocity * 45f;
			Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(90f);
		}
	}
}