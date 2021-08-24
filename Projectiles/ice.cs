using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace TheNextWeapons.Projectiles
{
	public class ice : ModProjectile
	{
		public override void SetDefaults()
		{

			projectile.width = 8;
			projectile.height = 8;
			projectile.friendly = true;
			projectile.aiStyle = 1;
			projectile.timeLeft = 1200;
			projectile.penetrate = 1;
			projectile.tileCollide = true;
			projectile.ignoreWater = false;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ice Shard");

		}

		public override void Kill(int timeLeft)
		{
			for (int k = 0; k < 0; k++)
			{
				int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 0, projectile.oldVelocity.X * 0.0f, projectile.oldVelocity.Y * 0.0f);
			}
			Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 27);
		}

		public override void AI()
		{
			int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 0, projectile.velocity.X * 0.0f, projectile.velocity.Y * 0.0f, 0, default(Color), 0.0f);
			Main.dust[dust].noGravity = true;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.NextBool(2))
			{
				target.AddBuff(0, 0, true);
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