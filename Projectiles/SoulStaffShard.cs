using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;

namespace TheNextWeapons.Projectiles
{
    public class SoulStaffShard : ModProjectile
    {
        public override void SetDefaults()
        {

            Projectile.width = 10;
            Projectile.height = 10;
            Projectile.friendly = true;
            Projectile.aiStyle = 0;
            Projectile.timeLeft = 30;
            Projectile.penetrate = 1;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = false;
            Projectile.alpha = 255;
            Projectile.frame = Main.rand.Next(3);
        }
        public override Color? GetAlpha(Color lightColor) => new Color(255, 255, 255, 0);


        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 3;
        }
        int[] DustIDs = new int[] { DustID.VenomStaff, DustID.GemAmethyst };

        public override void OnSpawn(IEntitySource source)
        {
            Projectile.timeLeft = (int)Projectile.velocity.Y;
            for (int k = 0; k < 4; k++)
            {
                int dust2 = Dust.NewDust(Projectile.Center, 0, 0, Main.rand.Next(DustIDs), Main.rand.NextFloat(-1, 1), Main.rand.NextFloat(-1, 1), 0, new Color(0,0,255), 1.5f);
                Main.dust[dust2].noGravity = true;
                Main.dust[dust2].fadeIn = 1.5f;
            }
            Projectile.velocity = (Main.MouseWorld - Projectile.Center).SafeNormalize(Vector2.Zero) * (6.5f - ((float)Projectile.timeLeft / 10));
        }
        public override void OnKill(int timeLeft)
        {
            for (int k = 0; k < 2; k++)
            {
                int dust = Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, Main.rand.Next(DustIDs), Projectile.oldVelocity.X * 0.5f, Projectile.oldVelocity.Y * 0.5f, 0, new Color(0, 0, 255), 2f);
                Main.dust[dust].noGravity = true;
            }
        }
        public override void AI()
        {
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(90f);
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(BuffID.Suffocation, 500, true);
            if (Main.rand.NextBool(5))
            {
                target.AddBuff(BuffID.BrokenArmor, 500, true);
            }
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            if (Main.rand.NextBool(2))
            {
                target.AddBuff(0, 0, true);
            }
        }
    }
}