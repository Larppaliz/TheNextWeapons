using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Projectiles
{
    public class Bullet : ModProjectile
    {
        public override void SetDefaults()
        {

            Projectile.width = 18;
            Projectile.height = 18;
            Projectile.friendly = true;
            Projectile.aiStyle = 0;
            Projectile.penetrate = -1;
            Projectile.tileCollide = true;
            Projectile.ignoreWater = false;
            Projectile.timeLeft = 120;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 10;
        }
        public override Color? GetAlpha(Color lightColor) => new Color(255, 255, 255, 0);


        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Boomerang Bullet");

        }

        public override void OnKill(int timeLeft)
        {
            for (int k = 0; k < 2; k++)
            {
                int dust = Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, 21, Projectile.oldVelocity.X * 1.0f, Projectile.oldVelocity.Y * 1.0f);
            }
            SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
        }

        public override void AI()
        {
            int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 21, Projectile.velocity.X * 1f, Projectile.velocity.Y * 1f, 20, default(Color), 1f);
            Main.dust[dust].noGravity = true;
            Projectile.rotation = Projectile.timeLeft * 5;
            if (Projectile.timeLeft == 120)
            {
                Projectile.velocity *= 1.15f;
            }
            if (Projectile.timeLeft == 60)
            {
                Projectile.velocity *= -1f;
            }
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Projectile.tileCollide = false;
        }
    }
}