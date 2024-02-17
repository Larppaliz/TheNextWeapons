using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Projectiles
{
    public class SoulArrow : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 12;
            Projectile.height = 12;
            Projectile.aiStyle = 0;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.timeLeft = 450;
            Projectile.penetrate = 3;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 5;
            Projectile.tileCollide = true;
            Projectile.ignoreWater = true;
        }
        public override Color? GetAlpha(Color lightColor) => new Color(255, 180, 210, 0);

        public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
            for (int k = 0; k < 4; k++)
            {
                int dust = Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.CrystalPulse2, Projectile.oldVelocity.X * 1.5f, Projectile.oldVelocity.Y * 1.5f, 20, default(Color), 2f);
                Main.dust[dust].noGravity = true;
            }
        }

        public override void AI()
        {
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(90f);
            int dust = Dust.NewDust(Projectile.position, 1, 1, 255, Projectile.velocity.X * 1f, Projectile.velocity.Y * 1f, 20, default(Color), 2f);
            Main.dust[dust].noGravity = true;
            if (Projectile.timeLeft == 450) { Projectile.velocity *= 2; }
            Projectile.velocity.Y += 0.5f;
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Projectile.velocity.Y += 5f;
        }
        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
            modifiers.FinalDamage *= 2;
        }
        }
}