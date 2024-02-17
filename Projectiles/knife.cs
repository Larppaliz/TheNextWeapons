using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Projectiles
{
    public class knife : ModProjectile
    {
        public override void SetDefaults()
        {

            Projectile.width = 22;
            Projectile.height = 22;
            Projectile.friendly = true;
            Projectile.aiStyle = 0;
            Projectile.timeLeft = 400;
            Projectile.penetrate = 5;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.alpha = 180;
        }

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Knife");

        }

        public override void OnKill(int timeLeft)
        {
            for (int k = 0; k < 0; k++)
            {
                int dust = Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, 0, Projectile.oldVelocity.X * 0.3f, Projectile.oldVelocity.Y * 0.3f);
            }
            SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
        }

        public override void AI()
        {
            int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 0, Projectile.velocity.X * 0.3f, Projectile.velocity.Y * 0.3f, 0, default(Color), 0.0f);
            Main.dust[dust].noGravity = true;
		if(Projectile.timeLeft == 379){
			Projectile.velocity *= 0.5f;
		}
            if (Projectile.timeLeft < 380)
            {
                Projectile.alpha = 0;
                Projectile.aiStyle = 2;
                Projectile.tileCollide = true;
                Projectile.ignoreWater = false;
            }
            else
            {
                Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(90f);
            }
        }
    }
}