using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Projectiles.Chess
{
    public class Rotaters : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 8;
            // DisplayName.SetDefault("Chess Set");

        }
        public override void SetDefaults()
        {
            Projectile.width = 83;
            Projectile.height = 83;
            Projectile.friendly = true;
            Projectile.aiStyle = 0;
            Projectile.penetrate = -1;
            Projectile.maxPenetrate = -1;
            Projectile.timeLeft = 100;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.hide = true;
            Projectile.localNPCHitCooldown = 60;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.velocity *= 0f;
            Projectile.alpha = 255;
            Projectile.frame = 0;
            // Projectile.frame = Main.rand.Next(new int[] {1, 2, 3, 4, 5, 6, 7});
        }
        int timer;
        int extra = 0;
        public override void AI()
        {

            if (Projectile.timeLeft == 100)
            {
                Projectile.position.X = Main.LocalPlayer.Center.X - Projectile.width / 2;
                Projectile.position.Y = Main.LocalPlayer.Center.Y - Projectile.height / 2;
            }
            Projectile.alpha -= 15;
            Player player = Main.player[Projectile.owner];
            bool stillInUse = player.channel & player.statMana >= 3;
            timer++;
            Vector2 position;
            position.X = Projectile.position.X + Projectile.width / 2;
            position.Y = Projectile.position.Y + Projectile.height / 2;
            if (stillInUse)
            {
                Projectile.timeLeft = 60;
                Projectile.hide = false;
                double deg = (double)Projectile.ai[1]; //The degrees, you can multiply projectile.ai[1] to make it orbit faster, may be choppy depending on the value
                double rad = deg * (Math.PI / 180); //Convert degrees to radians
                double dist = 64; //Distance away from the player
                Projectile.position.X = player.Center.X - (int)(Math.Cos(rad) * dist) - Projectile.width / 2;
                Projectile.position.Y = player.Center.Y - (int)(Math.Sin(rad) * dist) - Projectile.height / 2;
                Projectile.ai[1] += 2f;
            }
            if (stillInUse == false)
            {
                Projectile.Kill();
            }
            if (Projectile.frame == 0)
            {
                if (timer >= 60)
                {
                    //Projectile.frame = Main.rand.Next(new int[] { 1, 2, 3});
                    Projectile.frame = 1;
                    timer = 0;
                }
            }
            if (Projectile.frame == 1)
            {
                if (timer >= 50)
                {
                    SoundEngine.PlaySound(SoundID.DD2_BallistaTowerShot);
                    Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), position, (Main.MouseWorld - Projectile.Center).SafeNormalize(Vector2.Zero) * 16f, ModContent.ProjectileType<Projectiles.Chess.Pawn>(), Projectile.damage, Projectile.knockBack, player.whoAmI); timer = 0;
                    Projectile.frame = 0;
                }
            }
            if (Projectile.frame == 2)
            {
                if (timer >= 80)
                {
                    SoundEngine.PlaySound(SoundID.DD2_ExplosiveTrapExplode);
                    Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), position, (Main.MouseWorld - Projectile.Center).SafeNormalize(Vector2.Zero) * 16f, ModContent.ProjectileType<Projectiles.AirSlash>(), Projectile.damage, Projectile.knockBack, player.whoAmI); timer = 0;
                    Projectile.frame = 0;
                }
            }
            if (Projectile.frame == 3)
            {
                if (timer >= 130)
                {
                    SoundEngine.PlaySound(SoundID.DD2_DarkMageAttack);
                    Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), position, (Main.MouseWorld - Projectile.Center).SafeNormalize(Vector2.Zero) * 16f, ModContent.ProjectileType<Projectiles.Chess.Priest>(), Projectile.damage, Projectile.knockBack, player.whoAmI); timer = 0;
                    Projectile.frame = 0;
                }
            }
            if (Projectile.frame == 4)
            {
                extra++;
                Projectile.rotation = MathHelper.ToRadians(extra*10);
                if (timer >= 25)
                {
                    SoundEngine.PlaySound(SoundID.Item1);
                    timer = 0;
                }
            }
            if (Projectile.frame == 5)
            {
                extra++;
                Projectile.rotation = MathHelper.ToRadians(extra * -10);
                if (timer >= 25)
                {
                    SoundEngine.PlaySound(SoundID.Item1);
                    timer = 0;
                }
            }
            if (Projectile.frame == 6)
            {
                if (timer >= 26)
                {
                    timer = 0;
                }
            }
            if (Projectile.frame == 7)
            {
                if (timer >= 12)
                {
                    timer = 0;
                }
            }
            if (Projectile.frame == 8)
            {
                if (timer >= 25)
                {
                    timer = 0;
                }
            }
        }
    }
}