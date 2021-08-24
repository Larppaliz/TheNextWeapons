using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace TheNextWeapons.Projectiles
{
	public class arrow : ModProjectile
	{
		public override void SetDefaults()
		{

			projectile.width = 12;
			projectile.height = 12;
			projectile.friendly = true;
			projectile.aiStyle = 1;
			projectile.timeLeft = 12000;
			projectile.tileCollide = true;
			projectile.ignoreWater = false;
			projectile.light = 0.5f;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Arrow");

		}

		public override void Kill(int timeLeft)
		{
			for (int k = 0; k < 2; k++)
			{
				int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 39, projectile.oldVelocity.X *1.0f, projectile.oldVelocity.Y * 1.0f);
			}
			Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 1);
		}

		public override void AI()
		{
			int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 39, projectile.velocity.X * 1f, projectile.velocity.Y * 1f, 1, default(Color), 1f);
			Main.dust[dust].noGravity = true;
			Main.PlaySound(60);
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.NextBool(1))
			{
				target.AddBuff(39, 300, true);
			}
			if (Main.rand.NextBool(1))
			{
				target.AddBuff(69, 300, true);
			}

			projectile.velocity *= 1.00f;
		}

		public override void OnHitPvp(Player target, int damage, bool crit)
		{
			if (Main.rand.NextBool(2))
			{
				target.AddBuff(160, 2000, false);
			}
		}
	}
}