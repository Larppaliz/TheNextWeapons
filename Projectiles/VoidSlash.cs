using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;

namespace TheNextWeapons.Projectiles
{
    public class VoidSlash : ModProjectile
    {
        public override void SetDefaults()
        {

            Projectile.width = 128;
            Projectile.height = 128;
            Projectile.friendly = true;
            Projectile.aiStyle = 0;
            Projectile.timeLeft = 45;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.penetrate = -1;
        }

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Void Twinkle");

        }

        public override void OnKill(int timeLeft)
        {
            for (int k = 0; k < 40; k++)
            {
                int dust = Dust.NewDust(Projectile.Center, 0, 0, ModContent.DustType<Dusts.VoidDust>(), 0, 0, 0);
                Main.dust[dust].noGravity = true;
            }
        }
        int rotate = Main.rand.Next(new int[] { -1, 1 });
        int timer;
        bool can = true;
        public override void AI()
        {
            Player player = Main.player[Projectile.owner];

                timer++;
            Projectile.rotation = MathHelper.ToRadians(timer) * 10 * rotate;

            // Calculate the angle of the projectile's rotation
            float angle = Projectile.rotation;

            // Calculate the velocity of the dust based on the angle of the projectile's rotation
            Vector2 dustVelocity;
            dustVelocity.X = (float)Math.Cos(angle) * 3f;
            dustVelocity.Y = (float)Math.Sin(angle) * 3f;

            // Calculate the angle of the projectile's rotation
            float angle2 = Projectile.rotation + MathHelper.ToRadians(90);

            // Calculate the velocity of the dust based on the angle of the projectile's rotation
            Vector2 dustVelocity2;
            dustVelocity2.X = (float)Math.Cos(angle2) * 3f;
            dustVelocity2.Y = (float)Math.Sin(angle2) * 3f;


            // Calculate the angle of the projectile's rotation
            float angle3 = Projectile.rotation + MathHelper.ToRadians(180);

            // Calculate the velocity of the dust based on the angle of the projectile's rotation
            Vector2 dustVelocity3;
            dustVelocity3.X = (float)Math.Cos(angle3) * 3f;
            dustVelocity3.Y = (float)Math.Sin(angle3) * 3f;


            // Calculate the angle of the projectile's rotation
            float angle4 = Projectile.rotation - MathHelper.ToRadians(90);

            // Calculate the velocity of the dust based on the angle of the projectile's rotation
            Vector2 dustVelocity4;
            dustVelocity4.X = (float)Math.Cos(angle4) * 3f;
            dustVelocity4.Y = (float)Math.Sin(angle4) * 3f;

            // Create the dust
            for (int i = 0; i < 3; i++)
            {
                Dust dust = Dust.NewDustPerfect(Projectile.Center, ModContent.DustType<Dusts.VoidDust>(), dustVelocity*2, 0, default(Color), 1f);
                dust.noGravity = true;

                Dust dust2 = Dust.NewDustPerfect(Projectile.Center, ModContent.DustType<Dusts.VoidDust>(), dustVelocity2*2, 0, default(Color), 1f);
                dust2.noGravity = true;

                Dust dust3 = Dust.NewDustPerfect(Projectile.Center, ModContent.DustType<Dusts.VoidDust>(), dustVelocity3*2, 0, default(Color), 1f);
                dust3.noGravity = true;

                Dust dust4 = Dust.NewDustPerfect(Projectile.Center, ModContent.DustType<Dusts.VoidDust>(), dustVelocity4*2, 0, default(Color), 1f);
                dust4.noGravity = true;
            }
            Lighting.AddLight(Projectile.Center, new Vector3(0.3f, 0f, 0.5f));
            if (player.channel && player.statMana >= 10 && can)
            {
                Projectile.timeLeft = 45;
            }
            else { can = false; }
        }
        public override Color? GetAlpha(Color lightColor) => new Color(250, 200, 255, 0);

        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
            modifiers.FinalDamage /= 2;
            if (Vector2.Distance(target.Center, Projectile.Center) <= 32)
            {
                modifiers.FinalDamage.Flat = (int)(modifiers.FinalDamage.Flat * 1.5f);
            }
        }
    }
}