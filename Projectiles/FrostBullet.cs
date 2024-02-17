using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Projectiles
{
    public class FrostBullet : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 4;
            Projectile.height = 4;
            Projectile.aiStyle = 0;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.timeLeft = 150;
            Projectile.penetrate = 1;
            Projectile.scale = 1.00f;
            Projectile.tileCollide = true;
            Projectile.ignoreWater = true;
            Projectile.light = 0.3f;
        }
        public override Color? GetAlpha(Color lightColor) => new Color(255, 255, 255, 0);

        public override void AI()
        {
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(90f);
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
            return true;
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (Main.rand.NextBool(15))
            {
                target.AddBuff(Mod.Find<ModBuff>("Freeze").Type, 60);
            }
            if (Main.rand.NextBool(5))
            {
                target.AddBuff(BuffID.Frostburn, 60);
            }
        }
        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            if (Main.rand.NextBool(15))
            {
                target.AddBuff(Mod.Find<ModBuff>("Freeze").Type, 60);
            }
            if (Main.rand.NextBool(5))
            {
                target.AddBuff(BuffID.Frostburn, 60);
            }
        }
    }
}