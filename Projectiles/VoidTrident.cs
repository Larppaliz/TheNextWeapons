using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TheNextWeapons.Items.Radium;

namespace TheNextWeapons.Projectiles
{
	public class VoidTrident : ModProjectile
    {
		public static float HoldoutRangeMax = 130f;
        public static float HoldoutRangeMin = 42.5f;
        public float HoldoutRangeLimit = 130f;
        // Define the range of the Spear Projectile. These are overrideable properties, in case you'll want to make a class inheriting from this one.
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Void Trident");
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = 10;
		}
		
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.Spear); // Clone the default values for a vanilla spear. Spear specific values set for width, height, aiStyle, friendly, penetrate, tileCollide, scale, hide, ownerHitCheck, and melee.
		}
		bool once = true;
		public Vector2 mousepos = Main.MouseWorld;
        public override bool PreAI()
        {
            Player player = Main.player[Projectile.owner];
			HoldoutRangeMax = player.Distance(mousepos) + 50f;
			if (HoldoutRangeMax > HoldoutRangeLimit) { HoldoutRangeMax = HoldoutRangeLimit; }
			HoldoutRangeMin = HoldoutRangeMax/4;
			player.heldProj = Projectile.whoAmI; // Update the player's held projectile id
			int duration = (int)HoldoutRangeMax / 5;

			// Reset projectile time left if necessary
			if (Projectile.timeLeft > duration) {
				Projectile.timeLeft = duration;
			}

			Projectile.velocity = Vector2.Normalize(Projectile.velocity); // Velocity isn't used in this spear implementation, but we use the field to store the spear's attack direction.

			float halfDuration = duration * 0.5f;
			float progress;

			// Here 'progress' is set to a value that goes from 0.0 to 1.0 and back during the item use animation.
			if (Projectile.timeLeft < halfDuration) {
				progress = Projectile.timeLeft / halfDuration;
			}
			else {
				progress = (duration - Projectile.timeLeft) / halfDuration;
			}
			// Move the projectile from the HoldoutRangeMin to the HoldoutRangeMax and back, using SmoothStep for easing the movement
			Projectile.Center = player.MountedCenter + Vector2.SmoothStep(Projectile.velocity * HoldoutRangeMin, Projectile.velocity * HoldoutRangeMax, progress);

			// Apply proper rotation to the sprite.
			if (Projectile.spriteDirection == -1) {
				// If sprite is facing left, rotate 45 degrees
				Projectile.rotation += MathHelper.ToRadians(45f);
			}
			else {
				// If sprite is facing right, rotate 135 degrees
				Projectile.rotation += MathHelper.ToRadians(135f);
			}
			if (Projectile.timeLeft < halfDuration)
			{
				if (once)
				{
					once = false;
					int type = ModContent.ProjectileType<Projectiles.VoidTridentBlast>();
					Vector2 position = Projectile.Center;
					Vector2 velocity = Projectile.velocity * 20f;
					float angle = 10;
					SoundEngine.PlaySound(SoundID.Item68);
					IEntitySource source = Projectile.GetSource_FromThis();
					velocity = velocity.RotatedByRandom(MathHelper.ToRadians(angle));
					Projectile.NewProjectileDirect(source, position, velocity, type, Projectile.damage / 3, Projectile.knockBack / 2, player.whoAmI);
					velocity = velocity.RotatedByRandom(MathHelper.ToRadians(angle));
					Projectile.NewProjectileDirect(source, position, velocity, type, Projectile.damage / 3, Projectile.knockBack / 2, player.whoAmI);
					velocity = velocity.RotatedByRandom(MathHelper.ToRadians(angle));
					Projectile.NewProjectileDirect(source, position, velocity, type, Projectile.damage / 3, Projectile.knockBack / 2, player.whoAmI);
				}
			}
			return false; // Don't execute vanilla AI.
		}
	}
}