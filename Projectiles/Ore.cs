using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace TheNextWeapons.Projectiles
{
	public class Ore : ModProjectile
	{
		public override void SetDefaults()
		{

			projectile.width = 4;
			projectile.height = 4;
			projectile.friendly = true;
			projectile.aiStyle = 27;
			projectile.timeLeft = 1200;
			projectile.penetrate = 1;
			projectile.tileCollide = true;
			projectile.ignoreWater = false;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystal Shard");

		}

		public override void Kill(int timeLeft)
		{
			for (int k = 0; k < 0; k++)
			{
				int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 60, projectile.oldVelocity.X * 0.3f, projectile.oldVelocity.Y * 0.3f);
		}
	}
		public override void AI()
		{
			int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 60, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f, 0, default(Color), 1.0f);
			Main.dust[dust].noGravity = true;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.NextBool(1))
			{
				target.AddBuff(68, 500, true);
			}
			if (Main.rand.NextBool(5))
			{
				target.AddBuff(36, 500, true);
			}
			projectile.velocity *= 1.0f;
		}

		public override void OnHitPvp(Player target, int damage, bool crit)
		{
			if (Main.rand.NextBool(2))
			{
				target.AddBuff(0, 0, true);
			}
		}
	}
}