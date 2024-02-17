using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Projectiles
{
    public class FrozenShield : ModProjectile
    {
        public static bool alive = false;
        int health = 5;
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 2;
            // DisplayName.SetDefault("Frost Shield");

        }
        public override void SetDefaults()
        {
            Projectile.width = 14;
            Projectile.height = 30;
            Projectile.friendly = true;
            Projectile.aiStyle = 0;
            Projectile.penetrate = -1;
            Projectile.maxPenetrate = -1;
            Projectile.timeLeft = 100;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.hide = false;
            Projectile.localNPCHitCooldown = 10;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.velocity *= 0f;
        }
        public override void OnKill(int timeLeft)
        {
            for (int k = 0; k < 4; k++)
            {
                    int dust = Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.Ice, Projectile.oldVelocity.X * 0.5f, Projectile.oldVelocity.Y * 0.5f);
            }
            SoundEngine.PlaySound(SoundID.Shatter, Projectile.position);
            alive = false;
        }
        public override void AI()
        {
            Projectile.timeLeft = 3;
            float extrapos = 0f;
            alive = true;
            Player player = Main.player[Projectile.owner];
            if (player.direction == 1)
            {
                Projectile.frame = 0;
                    extrapos = 20;
            }
            if (player.direction == -1)
            {
                Projectile.frame = 1;
                    extrapos = -16;
            }
            Projectile.position = player.position + new Vector2(extrapos,6);
            if (health <= 0)
            { Projectile.Kill(); }
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            health -= 1;
            int dust = Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.Ice, Projectile.oldVelocity.X * 0.5f, Projectile.oldVelocity.Y * 0.5f);
        }
    }
}