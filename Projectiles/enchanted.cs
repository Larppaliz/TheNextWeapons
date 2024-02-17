using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Linq;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Projectiles
{
    public class enchanted : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 36;
            Projectile.height = 36;
            Projectile.friendly = true;
            Projectile.aiStyle = 0;
            Projectile.timeLeft = 3;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.penetrate = -1;
            Projectile.extraUpdates = 0;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 10;
        }

        public override void OnSpawn(IEntitySource source)
        {
            SoundEngine.PlaySound(SoundID.Item68);
        }
        public override Color? GetAlpha(Color lightColor) => new Color(180, 200, 225, 150);
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Hallowed Sword Beam");
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 10;

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
                color.B += 50;
                Main.EntitySpriteDraw(texture, drawPos, null, color*0.2f, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            }

            return true;
        }
        public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Shatter);
            for (int k = 0; k < 20; k++)
            {
                int dust = Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, 15, Projectile.oldVelocity.X * 1.0f, Projectile.oldVelocity.Y * 1.0f, 0, new Color(175, 200, 255, 0), 1f);
            }
        }
        public override void AI()
        {
            Projectile.velocity *= 0;
            Player player = Main.player[Projectile.owner];
            Projectile.rotation = MathHelper.ToRadians(90) * player.direction ;

            Projectile.Center = player.Center + (new Vector2((player.direction * 15f)-4f, 0f));

            if (player.HasBuff(ModContent.BuffType<Buffs.EnchantedShield>()))
            {
                Projectile.timeLeft = 3;
            }

        }
        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {

            SoundEngine.PlaySound(SoundID.Item70);
            Player player = Main.player[Projectile.owner];

            modifiers.HitDirectionOverride = player.direction;

            for (int k = 0; k < 7; k++)
            {
                int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 15, 5f * player.direction, 0f, 0, new Color(175, 200, 255, 0), 1f);
            }

            for (int i = 0; i < player.buffType.Count(); i++)
            {
                if (player.buffType[i] == ModContent.BuffType<Buffs.EnchantedShield>())
                {
                    player.buffTime[i] -= 120;
                    return;
                }
            }
        }
    }
}