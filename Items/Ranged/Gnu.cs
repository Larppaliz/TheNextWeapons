using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items.Ranged
{
    public class Gnu : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Double Barrel Blaster");
            // Tooltip.SetDefault("Shoots bullets");
        }
        public override void SetDefaults()
        {
            Item.damage = 14;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 54;
            Item.height = 24;
            Item.maxStack = 1;
            Item.useTime = 9;
            Item.useAnimation = 9;
            Item.useStyle = 5;
            Item.knockBack = 2;
            Item.value = 30000;
            Item.rare = 3;
            Item.UseSound = SoundID.Item41;
            Item.noMelee = true;
            Item.shoot = 14;
            Item.shootSpeed = 5f;
            Item.autoReuse = true;
            Item.useAmmo = 97;
        }
        int bulletNRO = 1;
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (bulletNRO == 1) 
            {
                bulletNRO = 2;
                position.Y -= 10;
            }
            else if (bulletNRO == 2)
            {
                bulletNRO = 1;
                position.Y -= 3;
            }
            Vector2 muzzleOffset = Vector2.Normalize(velocity) * 50f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }

            if (type == ProjectileID.Bullet)
            {
                type = ProjectileID.BulletHighVelocity;
            }


            Projectile.NewProjectileDirect(source, position, velocity, type, damage, knockback, player.whoAmI);

            return false; // Return false because we don't want tModLoader to shoot projectile
        }
        public override Vector2? HoldoutOffset()
        {
            Vector2 offset = new Vector2(-16, -5);
            return offset;
        }
    }
}