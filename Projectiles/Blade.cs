using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Projectiles
{
    public class Blade: ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 22;
            Projectile.height = 22;
            Projectile.aiStyle = 0;
            Projectile.friendly  = true;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.timeLeft = 60;
	    Projectile.penetrate = 7;
			Projectile.tileCollide = true;
            Projectile.ignoreWater = true;
            Projectile.localNPCHitCooldown = 10;
            Projectile.usesLocalNPCImmunity = true;
        }

        public override void AI()
		{
	    	Projectile.rotation = Projectile.timeLeft * 5;
			Projectile.position = Main.MouseWorld;
		}
	}
}