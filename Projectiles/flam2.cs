using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Projectiles
{
    public class flam2 : ModProjectile
    {
        public override void SetDefaults()
        {

            Projectile.width = 24;
            Projectile.height = 24;
            Projectile.friendly = true;
            Projectile.aiStyle = 6;
            Projectile.penetrate = 5;
            Projectile.maxPenetrate = 5;
            Projectile.timeLeft = 150;
            Projectile.tileCollide = true;
            Projectile.ignoreWater = true;
        }

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Flame");

        }

        public override void    OnKill(int timeLeft)
        {
            for (int k = 0; k < 0; k++)
            {
                int dust = Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, 60, Projectile.oldVelocity.X * 4f, Projectile.oldVelocity.Y * 4f);
            }
        }

        public override void AI()
        {
            int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 60, Projectile.velocity.X * 4f, Projectile.velocity.Y * 4f, 2, default(Color), 3f);
            Main.dust[dust].noGravity = true;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (Main.rand.NextBool(1))
            {
                target.AddBuff(70, 400, true);
            }

            Projectile.velocity *= 1.0f;
        }
        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
                target.AddBuff(70, 400, false);
        }
    }
}