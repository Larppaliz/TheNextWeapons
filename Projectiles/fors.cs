using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace TheNextWeapons.Projectiles
{
	public class fors : ModProjectile
	{
		public override void SetDefaults()
		{

			projectile.width = 17;
			projectile.height = 17;
			projectile.friendly = true;
			projectile.aiStyle = 37;
			projectile.timeLeft = 120;
			projectile.penetrate = 10;
			projectile.tileCollide = true;
			projectile.ignoreWater = false;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bullet Disc");

		}

		public override void Kill(int timeLeft)
		{
			for (int k = 0; k < 2; k++)
			{
				int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 21, projectile.oldVelocity.X * 1.0f, projectile.oldVelocity.Y * 1.0f);
		}
		}
		public override void AI()
		{
			int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 21, projectile.velocity.X * 1f, projectile.velocity.Y * 1f, 20, default(Color), 1f);
			Main.dust[dust].noGravity = true;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.NextBool(2))
			{
				target.AddBuff(0, 0, true);
			}
			projectile.velocity *= 0.50f;
		}

		public override void OnHitPvp(Player target, int damage, bool crit)
		{
			if (Main.rand.NextBool(2))
			{
				target.AddBuff(0, 0, false);
			}
		}
	}
}