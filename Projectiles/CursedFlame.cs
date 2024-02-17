using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Projectiles
{
    public class CursedFlame : ModProjectile
    {
        public override void SetDefaults()
        {

            Projectile.width = 14;
            Projectile.height = 16;
            Projectile.friendly = true;
            Projectile.aiStyle = 0;
            Projectile.penetrate = 10;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = false;
            Projectile.timeLeft = 90;
        }
        int StartDamage;
        public override Color? GetAlpha(Color lightColor) => new Color(255, 255, 255, 0);


        public override void OnSpawn(IEntitySource source)
        {
            StartDamage = Projectile.damage;
        }

        public override void OnKill(int timeLeft)
        {
            for (int k = 0; k < 5; k++)
            {
                int dust = Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.CursedTorch, Projectile.oldVelocity.X * 1.0f, Projectile.oldVelocity.Y * 1.0f, 0, default(Color), StartDamage/20);
                Main.dust[dust].noGravity = true;
            }
        }

        public override void AI()
        {
            if (Main.rand.NextBool(4))
            {
                int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.CursedTorch, 0f, -5f, 20, default(Color), Projectile.scale*2f);
                Main.dust[dust].noGravity = true;
            }
            Projectile.rotation = Projectile.velocity.ToRotation();
            if (Projectile.velocity.X < 0)
            {
                Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(180);

            }

            Projectile.damage = (StartDamage + Projectile.timeLeft/2)/2;
            Projectile.scale -= 0.008f;
            Projectile.velocity.X *= 0.97f;
            Projectile.velocity.Y *= 0.95f;
        }


        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(BuffID.CursedInferno, damageDone*10);
        }
    }
}