using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items.Ranged
{
    public class FrostSMG : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Frost SMG");
            // Tooltip.SetDefault("'Shoots Ice Bolts Instead of Musket Shots'");
        }
        public override void SetDefaults()
        {
            Item.damage = 3;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 54;
            Item.height = 24;
            Item.maxStack = 1;
            Item.useTime = 7;
            Item.useAnimation = 7;
            Item.useStyle = 5;
            Item.knockBack = 0.2f;
            Item.value = 30000;
            Item.rare = 1;
            Item.UseSound = SoundID.Item11;
            Item.noMelee = true;
            Item.shoot = ProjectileID.Bullet;
            Item.shootSpeed = 15f;
            Item.autoReuse = true;
            Item.scale = 0.85f;
            Item.useAmmo = 97;
        }
        public override Vector2? HoldoutOffset()
        {
            Vector2 offset = new Vector2(-13, 1);
            return offset;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            position.Y -= 7;
            Vector2 muzzleOffset = Vector2.Normalize(velocity) * 15f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }

            if (type == ProjectileID.Bullet)
            {
                type = Mod.Find<ModProjectile>("FrostBullet").Type;
            }
                // Rotate the velocity randomly by 30 degrees at max.
                Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(6));

                // Decrease velocity randomly for nicer visuals.
                newVelocity *= 1f - Main.rand.NextFloat(0.15f);

            if (Main.rand.NextBool(10))
            {
                knockback *= 2;
                type = ProjectileID.FrostBoltStaff;
                damage += 5;
            }

            // Create a projectile.
            Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);

            return false; // Return false because we don't want tModLoader to shoot projectile
        }
    }
}