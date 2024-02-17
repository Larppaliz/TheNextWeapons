using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Projectiles.Chess
{
    public class Priest : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("tas");
        }
        public override void SetDefaults()
        {
            Projectile.width = 20;  
            Projectile.height = 20;   
            Projectile.aiStyle = 0; 
            Projectile.friendly = true;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 200;
            Projectile.alpha = -2550;
        }
        public override bool PreKill(int timeLeft)
        {
            Projectile.width = 50;
            Projectile.height = 50;
            Projectile.alpha = 255;
            Projectile.position.X -= (Projectile.width / 2);
            Projectile.position.Y -= (Projectile.height / 2);
            int dust3 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Smoke, Projectile.velocity.X * 1f, Projectile.velocity.Y * 1f, 1, default(Color), 4.0f);
            Main.dust[dust3].noGravity = true;
            int dust2 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.GreenTorch, Projectile.velocity.X * 1f, Projectile.velocity.Y * 1f, 1, default(Color), 1.5f);
            Main.dust[dust2].noGravity = true;
            int dust4 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Smoke, Projectile.velocity.X * 1f, Projectile.velocity.Y * 1f, 1, default(Color), 2.0f);
            Main.dust[dust4].noGravity = true;
            int dust5 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.GreenTorch, Projectile.velocity.X * 1f, Projectile.velocity.Y * 1f, 1, default(Color), 1.0f);
            Main.dust[dust5].noGravity = true;
            SoundEngine.PlaySound(SoundID.DD2_ExplosiveTrapExplode, Projectile.position);
            return true;
        }
        public override void AI()
        {
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(90f);
            int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Smoke, Projectile.velocity.X * 1f, Projectile.velocity.Y * 1f, 1, default(Color), 1.0f);
            Main.dust[dust].noGravity = true;
            int dust6 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.DungeonSpirit, Projectile.velocity.X * 1f, Projectile.velocity.Y * 1f, 1, default(Color), 1.0f);
            Main.dust[dust6].noGravity = true;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.immune[Projectile.owner] = 25;
        }
    }
}