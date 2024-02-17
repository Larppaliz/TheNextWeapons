using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Projectiles
{
    public class LinkedSword : ModProjectile
    {
        public override void SetDefaults()
        {

            Projectile.width = 42;
            Projectile.height = 42;
            Projectile.hostile = true;
            Projectile.aiStyle = 27;
            Projectile.timeLeft = 400;
            Projectile.tileCollide = true;
            Projectile.ignoreWater = true;
            Projectile.penetrate = 1;
            Projectile.light = 0.0f;
        }

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Orange Sword Beam");

        }

        public override Color? GetAlpha(Color lightColor) => new Color(255, 200, 200, 0);

        public override void OnKill(int timeLeft)
        {
            for (int i = 0; i < 5; i++)
            {
                int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 90, Projectile.oldVelocity.X, Projectile.oldVelocity.Y, 0, default(Color), 1.0f);
                Main.dust[dust].noGravity = true;
            }
        }
        public override void AI()
        {
            if (Projectile.timeLeft == 400)
            {
                SoundEngine.PlaySound(SoundID.Item71);
                for (int i = 0; i < 15; i++)
                {
                    int dust2 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 90, 0f, 0f, 0, default(Color), 1.0f);
                    Main.dust[dust2].noGravity = true;
                }
            }
            Lighting.AddLight(Projectile.Center, new Vector3(0.3f, 0f, 0f));
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(90);
            int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 90, Projectile.velocity.X * 0, Projectile.velocity.Y * 0, 0, default(Color), 1.0f);
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