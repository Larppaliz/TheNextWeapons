using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Projectiles
{
    public class hamr : ModProjectile
    {
        public override void SetDefaults()
        {

            Projectile.width = 28;
            Projectile.height = 28;
            Projectile.friendly = true;
            Projectile.aiStyle = 0;
            Projectile.timeLeft = 200;
            Projectile.tileCollide = true;
            Projectile.ignoreWater = true;
            Projectile.penetrate = 4;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 10;
        }
        public override Color? GetAlpha(Color lightColor) => new Color(200, 200, 200, 0);

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Magic Mallet");

        }

        public override void OnKill(int timeLeft)
        {
            for (int k = 0; k < 5; k++)
            {
                int dust = Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, 204, Projectile.oldVelocity.X * 1.0f, Projectile.oldVelocity.Y * 1.0f, 1, default(Color), 0.5f);
            }
        }

        public override void AI()
        {
            int dust = Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, 204, Projectile.velocity.X * 1.0f, Projectile.velocity.Y * 1.0f, 1, default(Color), 0.5f);
            Main.dust[dust].noGravity = true;
            if (Projectile.timeLeft == 170)
            {
                Projectile.velocity *= 0.5f;
            }
            if (Projectile.timeLeft < 170)
            {
                Projectile.velocity.Y -= 0.2f;
            }
                Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(45f);
        }
    }
}