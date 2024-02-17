using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Projectiles
{
    public class Chains : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Blades of Discord Chain");
        }

        public override void SetDefaults()
        {
            Projectile.width = 32;
            Projectile.height = 32;
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 200;
            Projectile.rotation = 0;
            Projectile.light = 0.5f;
            Projectile.alpha = 0;
            Projectile.scale = 1f;
        }
        int timer = 0;
        int extrarotate = Main.rand.Next(0, 360);
        public override void AI()
        {
            Projectile.velocity.Y += 0.2f;
            // Spin
            Projectile.rotation = MathHelper.ToRadians(Projectile.timeLeft * 2 + extrarotate);

            // Calculate the velocity vector for the new projectile based on the rotation
            Vector2 velocity = new Vector2((float)Math.Cos(Projectile.rotation), (float)Math.Sin(Projectile.rotation)) * 10;

            // Create the new projectile using the current position and velocity of the original projectile
            IEntitySource source = Projectile.GetSource_FromThis();
            timer++;
            if (timer == 7)
            {
                timer = 0;
                SoundEngine.PlaySound(SoundID.Item41);
                Vector2 position = Projectile.Center;
                Vector2 muzzleOffset = Vector2.Normalize(velocity) * 20f;
                if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
                {
                    position += muzzleOffset;
                }
                Projectile.NewProjectileDirect(source, Projectile.Center, velocity, ProjectileID.BulletHighVelocity, Projectile.damage, Projectile.knockBack, Main.myPlayer);
            }
        }
    }
}
