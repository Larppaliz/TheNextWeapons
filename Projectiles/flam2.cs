using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace TheNextWeapons.Projectiles
{
	public class flam2 : ModProjectile
	{
		public override void SetDefaults()
		{

			projectile.width = 24;
			projectile.height = 24;
			projectile.friendly = true;
			projectile.aiStyle = 6;
			projectile.penetrate = 5;
			projectile.maxPenetrate = 5;
			projectile.timeLeft = 150;
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
				int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 60, projectile.oldVelocity.X * 4f, projectile.oldVelocity.Y * 4f);
			}
		}

		public override void AI()
		{
			int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 60, projectile.velocity.X * 4f, projectile.velocity.Y * 4f, 2, default(Color), 3f);
			Main.dust[dust].noGravity = true;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.NextBool(1))
			{
				target.AddBuff(70, 400, true);
			}

			projectile.velocity *= 1.0f;
		}

		public override void OnHitPvp(Player target, int damage, bool crit)
		{
			if (Main.rand.NextBool(1))
			{
				target.AddBuff(70, 400, false);
			}
		}
	}
}