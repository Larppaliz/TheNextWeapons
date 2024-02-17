using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items.Ranged
{
    public class AA12 : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("AA-12");
            // Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.damage = 15;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 22;
            Item.height = 22;
            Item.useTime = 16;
            Item.useAnimation = 16;
            Item.useStyle = 5;
            Item.maxStack = 1;
            Item.consumable = false;
            Item.noMelee = true;
            Item.knockBack = 1;
            Item.value = 350000;
            Item.shoot = 14;
            Item.rare = 5;
            Item.scale = 0.9f;
            Item.useAmmo = 97;
            Item.UseSound = SoundID.Item36;
            Item.autoReuse = true;
            Item.noUseGraphic = false; // this defines if it does not use graphic
            Item.shootSpeed = 10f;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            int NumProjectiles = 6; // The humber of projectiles that this gun will shoot.
            Vector2 muzzleOffset = Vector2.Normalize(velocity) * 25f;
            muzzleOffset.Y -= 4f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 1))
            {
                position += muzzleOffset;
            }
            if (type == ProjectileID.Bullet)
            {
                type = ProjectileID.BulletHighVelocity;
            }
            for (int i = 0; i < NumProjectiles; i++)
            {
                float ActualAngle = 30-Item.useTime;
                float Rotate = MathHelper.ToRadians(Main.rand.NextFloat(ActualAngle / -2, ActualAngle/2));

                Vector2 newVelocity = velocity.RotatedBy(Rotate);

                newVelocity *= 1f - Main.rand.NextFloat(0.15f);

                // Create a projectile.
                Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
            }

            return false; // Return false because we don't want tModLoader to shoot projectile
        }
        public override Vector2? HoldoutOffset()
        {
            Vector2 offset = new Vector2(-8, -2);
            return offset;
        }
    }
}