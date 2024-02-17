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
    public class ElectricBlast : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 3;
        }
        public override void SetDefaults()
        {
            Projectile.width = 9;
            Projectile.height = 9;
            Projectile.aiStyle = 0;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.timeLeft = 800;
            Projectile.penetrate = -1;
            Projectile.tileCollide = true;
            Projectile.ignoreWater = true;
            DrawOffsetX = 0;
            Projectile.extraUpdates = 10;
            Projectile.localNPCHitCooldown = 60;
            Projectile.usesLocalNPCImmunity = true;
        }
        public override Color? GetAlpha(Color lightColor) => new Color(150, 200, 255, 0);
        public override void AI()
        {
            if (Projectile.timeLeft == 600)
            {
                float numberProjectiles = 15;
                float rotation = MathHelper.ToRadians(120);
                for (int i = 0; i < numberProjectiles; i++)
                {
                    Vector2 velocity = Projectile.velocity.RotatedBy(MathHelper.ToRadians((MathHelper.ToDegrees(rotation)/numberProjectiles)*i)-rotation/2)/4;
                    velocity *= 1f - Main.rand.NextFloat(0.15f);
                    int dustspawn = Dust.NewDust(Projectile.Center, 0, 0, DustID.UltraBrightTorch, velocity.X, velocity.Y, 0, default(Color), 2f);
                    Main.dust[dustspawn].noGravity = true;
                }
            }
            if (Projectile.timeLeft > 2)
            {
                Dust dust = Dust.NewDustPerfect(Projectile.Center, DustID.UltraBrightTorch, new Vector2(Main.rand.NextFloat(-1, 1), Main.rand.NextFloat(-1, 1)), 0, default(Color), 2.0f);
                dust.noGravity = true;
                Lighting.AddLight(Projectile.Center, new Vector3(0.1f, 0.35f, 0.5f));
                Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(90f);
            }
        }
        bool xploder = false;
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (!xploder)
            {
                Projectile.hide = true;
                Projectile.timeLeft = 2;
                Projectile.height = 100;
                Projectile.width = 100;
                Projectile.position -= new Vector2(Projectile.width, Projectile.height) / 2;
                Projectile.velocity *= 0f;
                float numberProjectiles = 25;
                float rotation = MathHelper.ToRadians(360);
                for (int i = 0; i < numberProjectiles; i++)
                {
                    Vector2 position = Projectile.Center + new Vector2(0, 3).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles * 2)));
                    Vector2 velocity = position.DirectionFrom(Projectile.Center) * 3;
                    int dustspawn = Dust.NewDust(position, 0, 0, DustID.UltraBrightTorch, velocity.X, velocity.Y, 0, default(Color), 2f);
                    Main.dust[dustspawn].noGravity = true;
                }
                xploder = true;
            }
            return false;
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (target.life > 0)
            {
                if (!xploder)
                {
                    Projectile.hide = true;
                    Projectile.timeLeft = 2;
                    Projectile.height = 100;
                    Projectile.width = 100;
                    Projectile.position -= new Vector2(Projectile.width, Projectile.height) / 2;
                    Projectile.velocity *= 0f;
                    float numberProjectiles = 25;
                    float rotation = MathHelper.ToRadians(360);
                    for (int i = 0; i < numberProjectiles; i++)
                    {
                        Vector2 position = Projectile.Center + new Vector2(0, 3).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles * 2)));
                        Vector2 velocity = position.DirectionFrom(Projectile.Center) * 3;
                        int dustspawn = Dust.NewDust(position, 0, 0, DustID.UltraBrightTorch, velocity.X, velocity.Y, 0, default(Color), 2f);
                        Main.dust[dustspawn].noGravity = true;
                    }
                    xploder = true;
                }
            }
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            if (target.statLife > 0)
            {
                if (!xploder)
                {
                    Projectile.hide = true;
                    Projectile.timeLeft = 2;
                    Projectile.height = 100;
                    Projectile.width = 100;
                    Projectile.position -= new Vector2(Projectile.width, Projectile.height) / 2;
                    Projectile.velocity *= 0f;
                    float numberProjectiles = 25;
                    float rotation = MathHelper.ToRadians(360);
                    for (int i = 0; i < numberProjectiles; i++)
                    {
                        Vector2 position = Projectile.Center + new Vector2(0, 3).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles * 2)));
                        Vector2 velocity = position.DirectionFrom(Projectile.Center) * 3;
                        int dustspawn = Dust.NewDust(position, 0, 0, DustID.UltraBrightTorch, velocity.X, velocity.Y, 0, default(Color), 2f);
                        Main.dust[dustspawn].noGravity = true;
                    }
                    xploder = true;
                }
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
    }
}