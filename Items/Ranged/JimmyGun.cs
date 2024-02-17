using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items.Ranged
{
    public class JimmyGun : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 7;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 54;
            Item.height = 24;
            Item.maxStack = 1;
            Item.useTime = 6;
            Item.useAnimation = 6;
            Item.useStyle = 5;
            Item.knockBack = 0.5f;
            Item.value = Item.buyPrice(gold: 2);
            Item.rare = ItemRarityID.Green;
            Item.UseSound = SoundID.Item11;
            Item.noMelee = true;
            Item.shoot = ProjectileID.Bullet;
            Item.shootSpeed = 7f;
            Item.autoReuse = true;
            Item.useAmmo = 97;
            Item.scale = 0.9f;
        }
        public override Vector2? HoldoutOffset()
        {
            Vector2 offset = new Vector2(6, 2);
            return offset;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 muzzleOffset = Vector2.Normalize(velocity) * 30f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }

            int x = 1;
            if (velocity.X < 0) { x = -1; }
            Vector2 offset = velocity.RotatedBy(90 * x) * -0.55f;
            position += offset;


            float ActualAngle = 16f;
            float Rotate = MathHelper.ToRadians(Main.rand.NextFloat(ActualAngle / -2, ActualAngle / 2));

            Vector2 newVelocity = velocity.RotatedBy(Rotate);
            player.itemRotation += Rotate / 2;


            newVelocity *= 1f - Main.rand.NextFloat(0.15f);

            // Create a projectile.
            Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);

            return false; // Return false because we don't want tModLoader to shoot projectile
        }
    }
}