using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace TheNextWeapons.Projectiles
{
	public class knife : ModProjectile
	{
		public override void SetDefaults()
		{

			projectile.width = 22;
			projectile.height = 22;
			projectile.friendly = true;
			projectile.aiStyle = 2;
			projectile.timeLeft = 1200;
			projectile.penetrate = 1;
			projectile.tileCollide = true;
			projectile.ignoreWater = false;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Knife");

		}

		public override void Kill(int timeLeft)
		{
			for (int k = 0; k < 0; k++)
			{
				int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 0, projectile.oldVelocity.X * 0.3f, projectile.oldVelocity.Y * 0.3f);
			}
			Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 27);
		}

		public override void AI()
		{
			int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 0, projectile.velocity.X * 0.3f, projectile.velocity.Y * 0.3f, 0, default(Color), 0.0f);
			Main.dust[dust].noGravity = true;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.NextBool(2))
			{
				target.AddBuff(0, 0, true);
			}

			projectile.ai[0] += 0.1f;
			projectile.velocity *= 0.50f;
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