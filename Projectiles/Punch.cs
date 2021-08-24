using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace TheNextWeapons.Projectiles
{
	public class punch : ModProjectile
	{
		public override void SetDefaults()
		{

			projectile.width = 32;
			projectile.height = 32;
			projectile.friendly = true;
			projectile.aiStyle = 6;
			projectile.timeLeft = 10;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
			projectile.penetrate = -1;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Punch");

		}

		public override void Kill(int timeLeft)
		{
			for (int k = 0; k < 0; k++)
			{
				int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 0, projectile.oldVelocity.X * 0f, projectile.oldVelocity.Y * 0f);
		}
		}

		public override void AI()
		{
			int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 0, projectile.velocity.X * 0f, projectile.velocity.Y * 0f, 0, default(Color), 0f);
			Main.dust[dust].noGravity = true;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.NextBool(0))
			{
				target.AddBuff(0, 0, true);
			}

			projectile.ai[0] += 0.0f;
			projectile.velocity *= 0.80f;
		}

		public override void OnHitPvp(Player target, int damage, bool crit)
		{
			if (Main.rand.NextBool(0))
			{
				target.AddBuff(0, 0, true);
			}
		}
	}
}