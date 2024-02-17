using Humanizer;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Projectiles
{
    public class LeafSlash : ModProjectile
    {
        public override void SetDefaults()
        {

            Projectile.width = 120;
            Projectile.height = 120;
            Projectile.friendly = true;
            Projectile.aiStyle = 6;
            Projectile.timeLeft = 2;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.penetrate = -1;
        }

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Grovebane Cut");

        }

        public override void OnKill(int timeLeft)
        {
        }
        float spacing; // Spacing between dust particles
        public override void AI()
        {
            if (Projectile.timeLeft == 2)
            {
                Projectile.knockBack *= 0f;
                Projectile.position += Projectile.velocity * 20f;
                Projectile.velocity *= 0f;
                Projectile.rotation = Projectile.AngleTo(Main.player[Projectile.owner].Center) + MathHelper.ToRadians(90 + Main.rand.Next(-60, 60));
                spacing = 1f;
            }
            else
            {
                int numDust = 25; // Number of dust particles to create
                for (int i = 0; i < numDust; i++)
                {
                    spacing *= 1.05f;
                    float rotation = Projectile.rotation; // Get the projectile's rotation
                    Vector2 offset = new Vector2(spacing * i + 5, 0f).RotatedBy(rotation); // Calculate the offset based on rotation

                    int dustID = Main.rand.Next(new int[] { DustID.GreenTorch, DustID.SparkForLightDisc, DustID.GemEmerald, DustID.GrassBlades });
                    int dust2 = Dust.NewDust(Projectile.Center + offset, 0, 0, dustID, 0f, 0f, 0, new Color(0, 255, 0, 125), 1.5f - spacing / 20);
                    Main.dust[dust2].noGravity = true;
                    Main.dust[dust2].noLightEmittence = true;
                    Main.dust[dust2].noLight = false;
                    Main.dust[dust2].fadeIn = 1.5f;
                    int dust = Dust.NewDust(Projectile.Center - offset, 0, 0, dustID, 0f, 0f, 0, new Color(0,255,0, 125), 1.5f - spacing / 20);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].noLight = false;
                    Main.dust[dust].noLightEmittence = true;
                    Main.dust[dust].fadeIn = 1.5f;
                }
            }
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            for (int i = 0; i < 8; i++)
            {
                Vector2 velocity = new Vector2(Main.rand.NextFloat(-4f, 4f), Main.rand.NextFloat(-4f, 4f));
                int dust2 = Dust.NewDust(target.Center, 0, 0, DustID.GemEmerald, velocity.X, velocity.Y, 0, new Color(120, 255, 120, 255), 1.5f);
                Main.dust[dust2].noGravity = true;
                Main.dust[dust2].noLightEmittence = true;
                Main.dust[dust2].noLight = false;
                Main.dust[dust2].fadeIn = 1f;
            }

        }                
    }
}