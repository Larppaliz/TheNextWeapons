using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Projectiles
{
    public class VoidTridentBlast : ModProjectile
    {
        static float StartTimeLeft;

        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 3;
        }
        public override void SetDefaults()
        {
            Projectile.width = 14;
            Projectile.height = 14;
            Projectile.aiStyle = 0;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.timeLeft = 10;
            Projectile.penetrate = 1;
            Projectile.tileCollide = true;
            Projectile.ignoreWater = true;
            DrawOffsetX = -4;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = -1;
            StartTimeLeft = Projectile.timeLeft;
        }
        public override Color? GetAlpha(Color lightColor) => new Color(250, 200, 255, 0);

        public override void OnKill(int timeLeft)
        {
            for (int i = 0; i < 10; i++)
            {
                int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, Mod.Find<ModDust>("VoidDust").Type, 0, 0, 0, default(Color), 2.0f);
                Main.dust[dust].noGravity = true;
            }
        }
        public override void AI()
        {
            if (Projectile.timeLeft == StartTimeLeft)
            {
                //Projectile.position += Projectile.velocity * Projectile.timeLeft;
                //Projectile.velocity *= -1;
                for (int i = 0; i < 10; i++)
                {
                    int dust2 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, Mod.Find<ModDust>("VoidDust").Type, 0f, 0f, 0, default(Color), 2.0f);
                    Main.dust[dust2].noGravity = true;
                }
            }
            Lighting.AddLight(Projectile.Center, new Vector3(0.3f, 0f, 0.5f));
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(90);
                int dust = Dust.NewDust(Projectile.position, 1, Projectile.height, Mod.Find<ModDust>("VoidDust").Type, Projectile.velocity.X * 0, Projectile.velocity.Y * 0, 0, default(Color), 2f);
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
                Color color = Projectile.GetAlpha(lightColor) * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length);
                Main.EntitySpriteDraw(texture, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            }

            return true;
        }
    }
}