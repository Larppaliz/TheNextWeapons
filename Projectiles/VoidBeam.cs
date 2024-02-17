using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Projectiles
{
    public class VoidBeam : ModProjectile
    {
        static float StartTimeLeft;

        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 3;
        }
        public override void SetDefaults()
        {
            Projectile.width = 22;
            Projectile.height = 22;
            Projectile.aiStyle = 0;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.timeLeft = 60;
            Projectile.penetrate = -1;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            DrawOffsetX = -4;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = -1;
            StartTimeLeft = Projectile.timeLeft;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 10;
        }
        public override Color? GetAlpha(Color lightColor) => new Color(250, 200, 255, 0);
        Vector2 oldvel;
        Vector2 position;
        public override void OnKill(int timeLeft)
        {
            for (int k = 0; k < 40; k++)
            {
                int dust = Dust.NewDust(position, 0, 0, ModContent.DustType<Dusts.VoidDust>(), 0, 0, 0);
                Main.dust[dust].noGravity = true;
            }
        }
        public override void AI()
        {
            Projectile.knockBack = 0.1f;
            if (Projectile.timeLeft == StartTimeLeft)
            {
                oldvel = Projectile.velocity;
                SoundEngine.PlaySound(SoundID.Item71);
                for (int i = 0; i < 15; i++)
                {
                    int dust2 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.VoidDust>(), 0f, 0f, 0, default(Color), 1.0f);
                    Main.dust[dust2].noGravity = true;
                }
            }
            Lighting.AddLight(Projectile.Center, new Vector3(0.3f, 0f, 0f));
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(90);
            Player player = Main.player[Projectile.owner];
            IEntitySource source = Projectile.GetSource_FromThis();
            if (Projectile.timeLeft == 30)
            {
                position = Projectile.Center;
            }
            if (Projectile.timeLeft <= 30)
            {
                Projectile.width++;
                Projectile.height++;
                Projectile.position.Y -= 0.5f;
                Projectile.position.X -= 0.5f;
                Projectile.hide = true;
                Vector2 dustvelocity = oldvel.RotatedBy(MathHelper.ToRadians(90)) / 2;

                int dust1 = Dust.NewDust(position, 0, 0, ModContent.DustType<Dusts.VoidDust>(), 0, 0, 0, default(Color), 2.0f);
                Main.dust[dust1].noGravity = true;

                int dust2 = Dust.NewDust(position, 0, 0, ModContent.DustType<Dusts.VoidDust>(), dustvelocity.X, dustvelocity.Y, 0, default(Color), 2.0f);
                Main.dust[dust2].noGravity = true;

                int dust3 = Dust.NewDust(position, 0, 0, ModContent.DustType<Dusts.VoidDust>(), dustvelocity.X*-1, dustvelocity.Y*-1, 0, default(Color), 2.0f);
                Main.dust[dust3].noGravity = true;
                Projectile.velocity *= 0f;

                Projectile.localNPCHitCooldown = 5;
            }
            else
            {
                int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Dusts.VoidDust>(), Projectile.velocity.X * 0, Projectile.velocity.Y * 0, 0, default(Color), 1.0f);
                Main.dust[dust].noGravity = true;
            }
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

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (Projectile.timeLeft > 31)
            {
                Projectile.timeLeft = 31;
            }
        }
    }
}