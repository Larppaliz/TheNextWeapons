using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Projectiles
{
    public class RainbowGemSlash : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 44;
            Projectile.height = 44;
            Projectile.friendly = true;
            Projectile.aiStyle = 0;
            Projectile.timeLeft = 60;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.penetrate = -1;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = -1;
            Projectile.light = 0.3f;
        }
        static Color[] possibleColors = new Color[] { new Color(255, 100, 100, 100), new Color(255, 255, 100, 100), new Color(100, 255, 100, 100), new Color(255, 100, 255, 100), new Color(255, 120, 100, 100), new Color(100, 100, 255, 100) };
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Rainbow Slash");
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
        }
        Color colour = Main.rand.Next(possibleColors);
        public override void OnKill(int timeLeft)
        {
            for (int k = 0; k < 30; k++)
            {
                Vector2 vel = Projectile.oldVelocity.RotatedBy(MathHelper.ToRadians(360)/k);
                vel += Projectile.oldVelocity;
                int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.AncientLight, vel.X, vel.Y, 250, colour, 1.2f+(k/15));
                Main.dust[dust].noGravity = true;
            }
        }
        public override void AI()
        {
            Projectile.rotation = Projectile.velocity.ToRotation();
            Projectile.velocity *= 0.965f;
            Projectile.alpha += 2;

            Vector2 vel = Projectile.velocity * 0.5f;
            int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.AncientLight, vel.X, vel.Y, 250, colour, 1.2f);
            Main.dust[dust].noGravity = true;
        }
        public override bool PreDraw(ref Color lightColor)
        {
            Main.instance.LoadProjectile(Projectile.type);
            Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
            // Redraw the projectile with the color not influenced by light
            Vector2 drawOrigin = new Vector2(texture.Width * 0.5f, Projectile.height * 0.5f);
            for (int k = 0; k < Projectile.oldPos.Length; k++)
            {
                Vector2 drawPos = (Projectile.oldPos[k] - Main.screenPosition) + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
                Main.EntitySpriteDraw(texture, drawPos, null, colour, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            }
            return true;
        }
        public override Color? GetAlpha(Color lightColor) => new Color(200 + colour.R / 10, 200 + colour.G / 10, 200 + colour.B / 10, 100);
    }
}