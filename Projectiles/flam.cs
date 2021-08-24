using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace TheNextWeapons.Projectiles
{
	public class flam : ModProjectile
	{
		public override void SetDefaults()
		{

			projectile.width = 12;
			projectile.height = 12;
			projectile.friendly = true;
			projectile.aiStyle = 23;
			projectile.penetrate = 5;
			projectile.maxPenetrate = 5;
			projectile.timeLeft = 200;
			projectile.tileCollide = true;
			projectile.ignoreWater = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Flame");

		}

		public override void Kill(int timeLeft)
		{
			for (int k = 0; k < 0; k++)
			{
				int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 6, projectile.oldVelocity.X * 2f, projectile.oldVelocity.Y * 2f);
			}
		}

		public override void AI()
		{
			int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6, projectile.velocity.X * 2f, projectile.velocity.Y * 2f, 1, default(Color), 2f);
			Main.dust[dust].noGravity = true;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.NextBool(1))
			{
				target.AddBuff(24, 400, true);
			}

			projectile.velocity *= 1.0f;
		}

		public override void OnHitPvp(Player target, int damage, bool crit)
		{
			if (Main.rand.NextBool(1))
			{
				target.AddBuff(24, 400, false);
			}
		}
	}
}