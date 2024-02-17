using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using TheNextWeapons.Buffs;

namespace TheNextWeapons.Projectiles
{
    public class WaterShot : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 48;
            Projectile.height = 48;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.aiStyle = 0;
            Projectile.timeLeft = 100;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = false;
            Projectile.penetrate = 1;
            Projectile.extraUpdates = 0;
            Projectile.scale = 1.0f;
            Projectile.frame = Main.rand.Next(4);
            Projectile.direction = Main.rand.Next(new int[] { -1, 1 });
            Projectile.alpha = 90;
        }
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Water Wave Slash");
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 7;
            Main.projFrames[Projectile.type] = 4;

        }

        public override void OnSpawn(IEntitySource source)
        {
            for (int k = 0; k < 15; k++)
            {
                int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Water, 0, 0, 0, default(Color), Main.rand.NextFloat(1f, 2.5f));
                Main.dust[dust].noGravity = true;
            }
            SoundEngine.PlaySound(SoundID.Item21);
        }
        public override bool PreDraw(ref Color lightColor)
        {
            Main.instance.LoadProjectile(Projectile.type);
            Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
            Color[] pixels = new Color[48 * 48];
            texture.GetData(0, new Rectangle(0, Projectile.frame * 48, 48, 48), pixels, 0, pixels.Length);

            Texture2D textureFrame = new Texture2D(Main.graphics.GraphicsDevice, 48, 48);

            if (textureFrame != null) { textureFrame.SetData(pixels); }

            // Redraw the projectile with the color not influenced by light
            Vector2 drawOrigin = new Vector2(texture.Width * 0.5f, Projectile.height * 0.5f);
            for (int k = 0; k < Projectile.oldPos.Length; k++)
            {
                Vector2 drawPos = (Projectile.oldPos[k] - Main.screenPosition) + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
                Color color = (Projectile.GetAlpha(lightColor) * 0.2f) * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length);

                Main.EntitySpriteDraw(textureFrame, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            }

            return true;
        }
        public override void OnKill(int timeLeft)
        {
            for (int k = 0; k < 25; k++)
            {
                int dust = Dust.NewDust(Projectile.position + Projectile.velocity, 48, 48, DustID.Water, Projectile.oldVelocity.X, Projectile.oldVelocity.Y, 0, default(Color), Main.rand.NextFloat(1f,2.5f));
                Main.dust[dust].noGravity = true;
            }
            SoundEngine.PlaySound(SoundID.Splash);
        }
        int timer;
        public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            Projectile.rotation = Projectile.velocity.ToRotation();
            for (int k = 0; k < 3; k++)
            {
                int dust = Dust.NewDust(Projectile.position + Projectile.velocity, 48, 48, DustID.Water, 0, 0, 0, default(Color), Main.rand.NextFloat(1f, 1.5f));
                Main.dust[dust].noGravity = true;
            }


            if (timer >= 5)
            {
                timer = 0;
                if (Projectile.frame >= 3)
                {
                    Projectile.frame = 0;
                }
                else
                {
                    Projectile.frame++;
                }
                if (Projectile.wet)
                {
                    Projectile.timeLeft += 2;
                    Projectile.damage += (Projectile.damage/20);
                }
            }
            else
            {
                timer++;
            }
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Drenched.damage = damageDone;
            if (hit.Crit)
            {
                Drenched.damage = damageDone/2;
            }
            int BuffID = ModContent.BuffType<Buffs.Drenched>();
            target.AddBuff(BuffID, 80);
        }
    }
}