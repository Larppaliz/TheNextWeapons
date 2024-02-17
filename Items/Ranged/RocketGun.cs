using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items.Ranged
{
    public class RocketGun : ModItem
    {
        public override void SetStaticDefaults()
        {
        }
        public override void SetDefaults()
        {
            Item.damage = 32;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 54;
            Item.height = 24;
            Item.maxStack = 1;
            Item.useTime = 10;
            Item.useAnimation = 10;
            Item.useStyle = 5;
            Item.knockBack = 6;
            Item.value = 30000;
            Item.rare = 3;
            Item.noMelee = true;
            Item.shoot = 14;
            Item.shootSpeed = 6f;
            Item.autoReuse = true;
            Item.useAmmo = 97;
        }
        public override Vector2? HoldoutOffset()
        {
            Vector2 offset = new Vector2(-3, -2);
            return offset;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            SoundEngine.PlaySound(SoundID.Item41);

            Vector2 muzzleOffset = Vector2.Normalize(velocity) * 30f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }

            if (type == ProjectileID.Bullet)
            {
                type = ProjectileID.ExplosiveBullet;
            }
            float ActualAngle = 7f;
            float Rotate = MathHelper.ToRadians(Main.rand.NextFloat(ActualAngle / -2, ActualAngle / 2));

            Vector2 newVelocity = velocity.RotatedBy(Rotate);
            player.itemRotation += Rotate / 2;


            newVelocity *= 1f - Main.rand.NextFloat(0.15f);

            int x = 1;
            if (newVelocity.X < 0) { x = -1; }
            Vector2 offset = newVelocity.RotatedBy(90 * x) * -0.5f;
            position += offset;
            // Create a projectile.
            Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
            return false; // Return false because we don't want tModLoader to shoot projectile
        }
    }
}