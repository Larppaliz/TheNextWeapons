using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace TheNextWeapons.Projectiles
{
	public class swordoflight : ModProjectile
	{
		public override void SetDefaults()
		{

			projectile.width = 20;
			projectile.height = 20;
			projectile.friendly = true;
			projectile.aiStyle = 27;
			projectile.timeLeft = 400;
			projectile.tileCollide = true;
			projectile.ignoreWater = true;
			projectile.penetrate = 1;
			projectile.light = 0.3f;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sword Of Light");

		}

		public override void Kill(int timeLeft)
		{
			for (int k = 0; k < 5; k++)
			{
				int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 71, projectile.oldVelocity.X * 1.0f, projectile.oldVelocity.Y * 1.0f);
			}
			Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 20);
		}

		public override void AI()
		{
			int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 71, projectile.velocity.X * 1f, projectile.velocity.Y * 1f, 10, default(Color), 1f);
			Main.dust[dust].noGravity = true;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.NextBool(2))
			{
				target.AddBuff(153, 1000, true);
			}

			projectile.velocity *= 2f;
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