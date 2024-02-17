using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace TheNextWeapons.Projectiles
{
    public class flam : ModProjectile
    {
        public override void SetDefaults()
        {

            Projectile.width = 12;
            Projectile.height = 12;
            Projectile.friendly = true;
            Projectile.aiStyle = 23;
            Projectile.penetrate = 5;
            Projectile.maxPenetrate = 5;
            Projectile.timeLeft = 200;
            Projectile.tileCollide = true;
            Projectile.ignoreWater = true;
        }

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Flame");

        }

        public override void OnKill(int timeLeft)
        {
            for (int k = 0; k < 0; k++)
            {
                int dust = Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, 6, Projectile.oldVelocity.X * 2f, Projectile.oldVelocity.Y * 2f);
            }
        }

        public override void AI()
        {
            int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 6, Projectile.velocity.X * 2f, Projectile.velocity.Y * 2f, 1, default(Color), 2f);
            Main.dust[dust].noGravity = true;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (Main.rand.NextBool(1))
            {
                target.AddBuff(24, 400, true);
            }

            Projectile.velocity *= 1.0f;
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
                target.AddBuff(24, 400, false);
        }
    }
}