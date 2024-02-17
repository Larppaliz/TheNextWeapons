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
    public class BounceLaser: ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 85;
            Projectile.height = 85;
            Projectile.aiStyle = 0;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.timeLeft = 600;
            Projectile.penetrate = 1;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            DrawOffsetX = 0;
            Projectile.extraUpdates = 10;
            Projectile.localNPCHitCooldown = 60;
            Projectile.usesLocalNPCImmunity = true;
        }
        public NPC oldclosestnpc = null;

        public override void OnKill(int timeLeft)
        {
            for (int k = 0; k < 10; k++)
            {
                int dust = Dust.NewDust(Projectile.Center, 1, 1, 163, 0f,0f, 0, default(Color), 2f);
                Main.dust[dust].noGravity = true;
            }
        }
        public override void AI()
        {
            Dust dust = Dust.NewDustPerfect(Projectile.Center, 163, new Vector2(0, 0), 0, default(Color), 2.0f);
            dust.noGravity = true;
            Lighting.AddLight(Projectile.Center, new Vector3(0.1f, 0.35f, 0.5f));
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(90f);
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
        }
    }
}