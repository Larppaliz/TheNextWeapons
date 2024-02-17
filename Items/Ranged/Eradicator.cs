using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items.Ranged
{
    public class Eradicator : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Eradicator");
            // Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.damage = 16;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 54;
            Item.height = 24;
            Item.maxStack = 1;
            Item.useTime = 7;
            Item.useAnimation = 7;
            Item.useStyle = 5;
            Item.knockBack = 3;
            Item.value = 125000;
            Item.rare = 2;
            Item.UseSound = SoundID.Item41;
            Item.noMelee = true;
            Item.shoot = 14;
            Item.shootSpeed = 25f;
            Item.autoReuse = true;
            Item.useAmmo = 97;
            Item.scale = 0.9f;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            int NumProjectiles = 1; // The humber of projectiles that this gun will shoot.
            Vector2 muzzleOffset = Vector2.Normalize(velocity) * 12.5f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            for (int i = 0; i < NumProjectiles; i++)
            {
                // Rotate the velocity randomly by 30 degrees at max.
                Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(3));

                // Decrease velocity randomly for nicer visuals.
                newVelocity *= 1f - Main.rand.NextFloat(0.15f);

                // Create a projectile.
                Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
            }

            return false; // Return false because we don't want tModLoader to shoot projectile
        }
        public override Vector2? HoldoutOffset()
        {
            Vector2 offset = new Vector2(-7, 0);
            return offset;
        }
    }
}