using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace TheNextWeapons.Projectiles.Chess
{
	public class PriestExplode : ModProjectile
	{
		public override void SetDefaults()
		{

			Projectile.width = 100;
			Projectile.height = 100;
			Projectile.friendly = true;
			Projectile.aiStyle = 0;
			Projectile.timeLeft = 3;
			Projectile.tileCollide = false;
			Projectile.ignoreWater = true;
			Projectile.penetrate = -1;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Moab Explosion");

		}

		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
		target.immune[Projectile.owner] = 10;
		}
			public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
			{
			if (target.defense > 0) {
			modifiers.FinalDamage = modifiers.FinalDamage + (target.defense/3);
			}
			if (target.boss)
			{
			modifiers.FinalDamage *= 2;
			}
			}
	}
}