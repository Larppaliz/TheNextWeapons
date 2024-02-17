using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Projectiles
{
    public class Earth : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 6;
            // DisplayName.SetDefault("Earth Piece");

        }
        public override void SetDefaults()
        {
            Projectile.frame = Main.rand.Next(new int[] {0, 1, 2, 3, 4, 5});
            Projectile.width = 34;
            Projectile.height = 40;
            Projectile.friendly = true;
            Projectile.aiStyle = 0;
            Projectile.penetrate = -1;
            Projectile.maxPenetrate = -1;
            Projectile.timeLeft = 100;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.hide = true;
            Projectile.velocity *= 0f;
            Projectile.alpha = 255;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 30;
        }
        int timer;
        public override void OnKill(int timeLeft)
        {
            if (Projectile.ai[0] == 1)
            {
                SoundEngine.PlaySound(SoundID.Item62, Projectile.position);
            }
            Player player = Main.player[Projectile.owner];
            for (int k = 0; k < 8; k++)
            {
                Vector2 velocity = Projectile.position.DirectionFrom(pos) + velo;
                int dust = Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, 0, velocity.X, velocity.Y, 0, default(Color), Main.rand.NextFloat(1f, 2f));
            }
        }
        bool once = true;
        bool shoot = false;
        bool repeat = true;
        Vector2 pos;
        Vector2 velo;
        int dir;
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
            Player player = Main.player[Projectile.owner];
            for (int k = 0; k < 4; k++)
            {
                Vector2 velocity = Projectile.position.DirectionFrom(pos) + velo;
                velocity.RotatedByRandom(MathHelper.ToRadians(80));
                int dust = Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, 0, velocity.X, velocity.Y, 0, default(Color), Main.rand.NextFloat(1f, 1.5f));
            }
        }
        public override void OnSpawn(IEntitySource source)
        {
        }
        public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            player.heldProj = Projectile.whoAmI;
            if (Projectile.timeLeft == 100)
            {
                Projectile.ai[1] += Projectile.ai[0] * 72f;
                Projectile.ai[2] = 70;
                Projectile.position.X = Main.LocalPlayer.Center.X - Projectile.width / 2;
                Projectile.position.Y = Main.LocalPlayer.Center.Y - Projectile.height / 2;

                dir = player.direction;
                Projectile.timeLeft = 60;
                Projectile.hide = false;
                double deg = (double)Projectile.ai[1]; //The degrees, you can multiply projectile.ai[1] to make it orbit faster, may be choppy depending on the value
                double rad = deg * (Math.PI / 180); //Convert degrees to radians
                double dist = Projectile.ai[2]; //Distance away from the player
                Projectile.position.X = player.Center.X - (int)(Math.Cos(rad) * dist) - Projectile.width / 2;
                Projectile.position.Y = player.Center.Y - (int)(Math.Sin(rad) * dist) - Projectile.height / 2;
                Projectile.ai[1] += 2.5f * dir;
                pos = player.Center;
                velo = pos.DirectionTo(Main.MouseWorld) * 5;
            }
            if (Projectile.alpha >= 10) Projectile.alpha -= 15;
            bool stillInUse = player.channel & player.statMana >= 3;
            timer++;
            if (stillInUse) { if (repeat) { shoot = false; } }
            else { shoot = true; repeat = false; }
            if (Main.rand.NextFloat() < 0.1)
            {
                int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 0, Projectile.velocity.X * 0.0f, Projectile.velocity.Y * 0.0f, 1, default(Color), Main.rand.NextFloat(1f,1.5f));
                Main.dust[dust].noGravity = false;
            }
            if (stillInUse)
            {
                if (shoot == false)
                {
                    dir = player.direction;
                    Projectile.timeLeft = 50;
                    Projectile.hide = false;
                    double deg = (double)Projectile.ai[1]; //The degrees, you can multiply projectile.ai[1] to make it orbit faster, may be choppy depending on the value
                    double rad = deg * (Math.PI / 180); //Convert degrees to radians
                    double dist = Projectile.ai[2]; //Distance away from the player
                    Projectile.position.X = player.Center.X - (int)(Math.Cos(rad) * dist) - Projectile.width / 2;
                    Projectile.position.Y = player.Center.Y - (int)(Math.Sin(rad) * dist) - Projectile.height / 2;
                    Projectile.ai[1] += (player.HeldItem.shootSpeed / 5) * dir;
                    pos = player.Center;
                    velo = pos.DirectionTo(Main.MouseWorld) * player.HeldItem.shootSpeed;
                }
            }
            if (shoot)
            {
                pos += velo;
                Projectile.hide = false;
                double deg = (double)Projectile.ai[1]; //The degrees, you can multiply projectile.ai[1] to make it orbit faster, may be choppy depending on the value
                double rad = deg * (Math.PI / 180); //Convert degrees to radians
                double dist = Projectile.ai[2]; //Distance away from the player
                Projectile.position.X = pos.X - (int)(Math.Cos(rad) * dist) - Projectile.width / 2;
                Projectile.position.Y = pos.Y - (int)(Math.Sin(rad) * dist) - Projectile.height / 2;
                Projectile.ai[2] -= 0.5f;
                Projectile.ai[1] += (player.HeldItem.shootSpeed/5) * dir;
            }
        }
    }
}