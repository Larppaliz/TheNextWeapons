using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TheNextWeapons.Items.Magic;

namespace TheNextWeapons.Projectiles
{
    public class AnotherZenith : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 12;
            // DisplayName.SetDefault("Zenith Staff");

        }
        public override void SetDefaults()
        {
            Projectile.width = 44;
            Projectile.height = 44;
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
            if (Paragon.mode > -1)
            {
                Projectile.frame = Paragon.mode;
            }
            else
            {
                Projectile.frame = Main.rand.Next(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11});
            }
        }
            int timer;
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
                Projectile.rotation = Projectile.position.AngleTo(Main.MouseWorld) + MathHelper.ToRadians(45f);
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
                if (timer >= 17)
                {
                    SoundEngine.PlaySound(SoundID.Item43);
                    Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), position, (Main.MouseWorld - Projectile.Center).SafeNormalize(Vector2.Zero) * 8f, ProjectileID.ThunderStaffShot, Projectile.damage, Projectile.knockBack, player.whoAmI);
                    timer = 0;
                }
            }
            if (Projectile.frame == 1)
            {
                if (timer >= 16)
                {
                    SoundEngine.PlaySound(SoundID.Item20);
                    Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), position, (Main.MouseWorld - Projectile.Center).SafeNormalize(Vector2.Zero) * 16f, ProjectileID.FrostBoltStaff, Projectile.damage, Projectile.knockBack, player.whoAmI); timer = 0;
                }
            }
            if (Projectile.frame == 2)
            {
                if (timer >= 24)
                {
                    SoundEngine.PlaySound(SoundID.Item69);
                    Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), position, (Main.MouseWorld - Projectile.Center).SafeNormalize(Vector2.Zero) * 12f, ProjectileID.BoulderStaffOfEarth, Projectile.damage, Projectile.knockBack, player.whoAmI);
                    timer = 0;
                }
            }
            if (Projectile.frame == 3)
            {
                if (timer >= 30)
                {
                    SoundEngine.PlaySound(SoundID.Item73);
                    Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), position, (Main.MouseWorld - Projectile.Center).SafeNormalize(Vector2.Zero) * 8f, ProjectileID.InfernoFriendlyBolt, Projectile.damage, Projectile.knockBack, player.whoAmI);
                    timer = 0;
                }
            }
            if (Projectile.frame == 4)
            {
                if (timer >= 24)
                {
                    SoundEngine.PlaySound(SoundID.Item43);
                    Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), position, (Main.MouseWorld - Projectile.Center).SafeNormalize(Vector2.Zero) * 6f, ProjectileID.LostSoulFriendly, Projectile.damage, Projectile.knockBack, player.whoAmI);
                    timer = 0;
                }
            }
            if (Projectile.frame == 5)
            {
                if (timer >= 15)
                {
                    SoundEngine.PlaySound(SoundID.Item72);
                    Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), position, (Main.MouseWorld - Projectile.Center).SafeNormalize(Vector2.Zero) * 6f, ProjectileID.ShadowBeamFriendly, Projectile.damage, Projectile.knockBack, player.whoAmI);
                    timer = 0;
                }
            }
            if (Projectile.frame == 6)
            {
                if (timer == 0)
                {
                    position.X += Main.rand.NextFloat(-40, 40);
                    position.Y += Main.rand.NextFloat(-40, 40);
                    Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), position, (Main.MouseWorld - Projectile.Center).SafeNormalize(Vector2.Zero) * 14f, ProjectileID.SkyFracture, Projectile.damage, Projectile.knockBack, player.whoAmI);
                }
                if (timer == 4)
                {
                    position.X += Main.rand.NextFloat(-40, 40);
                    position.Y += Main.rand.NextFloat(-40, 40);
                    Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), position, (Main.MouseWorld - Projectile.Center).SafeNormalize(Vector2.Zero) * 14f, ProjectileID.SkyFracture, Projectile.damage, Projectile.knockBack, player.whoAmI);
                }
                if (timer == 8)
                {
                    position.X += Main.rand.NextFloat(-40, 40);
                    position.Y += Main.rand.NextFloat(-40, 40);
                    Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), position, (Main.MouseWorld - Projectile.Center).SafeNormalize(Vector2.Zero) * 14f, ProjectileID.SkyFracture, Projectile.damage, Projectile.knockBack, player.whoAmI);
                }
                if (timer >= 26)
                {
                    timer = 0;
                }
            }
            if (Projectile.frame == 7)
            {
                if (timer >= 12)
                {
                    Vector2 newVelocity = ((Main.MouseWorld - Projectile.Center).SafeNormalize(Vector2.Zero) * 10f).RotatedByRandom(MathHelper.ToRadians(30));
                    Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), position, newVelocity, ProjectileID.Bat, Projectile.damage, Projectile.knockBack, player.whoAmI);
                    if (Main.rand.NextBool(2))
                    {
                        newVelocity = ((Main.MouseWorld - Projectile.Center).SafeNormalize(Vector2.Zero) * 10f).RotatedByRandom(MathHelper.ToRadians(30));
                        Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), position, newVelocity, ProjectileID.Bat, Projectile.damage, Projectile.knockBack, player.whoAmI);
                    }
                    if (Main.rand.NextBool(2))
                    {
                        newVelocity = ((Main.MouseWorld - Projectile.Center).SafeNormalize(Vector2.Zero) * 10f).RotatedByRandom(MathHelper.ToRadians(30));
                        Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), position, newVelocity, ProjectileID.Bat, Projectile.damage, Projectile.knockBack, player.whoAmI);
                    }
                    timer = 0;
                }
            }
            if (Projectile.frame == 8)
            {
                if (timer >= 25)
                {
                    SoundEngine.PlaySound(SoundID.Item8);
                    Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), position, (Main.MouseWorld - Projectile.Center).SafeNormalize(Vector2.Zero) * 32f, ProjectileID.NettleBurstRight, Projectile.damage, Projectile.knockBack, player.whoAmI);
                    timer = 0;
                }
            }
            if (Projectile.frame == 9)
            {
                SoundEngine.PlaySound(SoundID.DD2_BookStaffCast);
                if (timer == 0)
                {
                    Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), position, (Main.MouseWorld - Projectile.Center).SafeNormalize(Vector2.Zero) * 11f, ProjectileID.BookStaffShot, Projectile.damage, Projectile.knockBack, player.whoAmI);
                }
                if (timer == 3)
                {
                    Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), position, (Main.MouseWorld - Projectile.Center).SafeNormalize(Vector2.Zero) * 11f, ProjectileID.BookStaffShot, Projectile.damage, Projectile.knockBack, player.whoAmI);
                }
                if (timer == 6)
                {
                    Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), position, (Main.MouseWorld - Projectile.Center).SafeNormalize(Vector2.Zero) * 11f, ProjectileID.BookStaffShot, Projectile.damage, Projectile.knockBack, player.whoAmI);
                }
                if (timer == 9)
                {
                    Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), position, (Main.MouseWorld - Projectile.Center).SafeNormalize(Vector2.Zero) * 11f, ProjectileID.BookStaffShot, Projectile.damage, Projectile.knockBack, player.whoAmI);
                }
                if (timer >= 25)
                {
                    timer = 0;
                }
            }
            if (Projectile.frame == 10)
            {
                if (timer >= 17)
                {
                    SoundEngine.PlaySound(SoundID.Item20);
                    Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), position, (Main.MouseWorld - Projectile.Center).SafeNormalize(Vector2.Zero) * 13f, ProjectileID.UnholyTridentFriendly, Projectile.damage, Projectile.knockBack, player.whoAmI);
                    timer = 0;
                }
            }
                if (Projectile.frame == 11)
            {
                if (timer >= 29)
                {
                    SoundEngine.PlaySound(SoundID.Item109);
                    Vector2 newVelocity = ((Main.MouseWorld - Projectile.Center).SafeNormalize(Vector2.Zero) * 10f).RotatedByRandom(MathHelper.ToRadians(14));
                    Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), position, (Main.MouseWorld - Projectile.Center).SafeNormalize(Vector2.Zero) * 13f, ProjectileID.CrystalPulse, Projectile.damage, Projectile.knockBack, player.whoAmI);
                    timer = 0;
                }
            }
        }
    }
}