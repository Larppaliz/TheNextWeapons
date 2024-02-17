using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items.Magic
{
    public class EMG_01B : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("EMG-01B");
            // Tooltip.SetDefault("Shoots electric blasts");
        }
        public override void SetDefaults()
        {
            Item.damage = 76;
            Item.DamageType = DamageClass.Magic;
            Item.width = 54;
            Item.height = 24;
            Item.maxStack = 1;
            Item.useTime = 40;
            Item.useAnimation = 40;
            Item.useStyle = 5;
            Item.knockBack = 1;
            Item.value = 12500;
            Item.rare = 2;
            Item.UseSound = SoundID.Item68;
            Item.noMelee = true;
            Item.shoot = ModContent.ProjectileType<Projectiles.ElectricBlast>();
            Item.shootSpeed = 15f;
            Item.autoReuse = true;
            Item.mana = 15;
            Item.useAmmo = 0;
            Item.scale = 0.9f;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 muzzleOffset = Vector2.Normalize(velocity) * 55f;
            if (velocity.X > 0)
            {
                muzzleOffset += velocity.RotatedBy(MathHelper.ToRadians(-90)) * 0.35f;
            }
            else
            {
                muzzleOffset += velocity.RotatedBy(MathHelper.ToRadians(90)) * 0.35f;
            }
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
                Projectile.NewProjectileDirect(source, position, velocity, type, damage, knockback, player.whoAmI);

            return false; // Return false because we don't want tModLoader to shoot projectile
        }
        public override Vector2? HoldoutOffset()
        {
            Vector2 offset = new Vector2(-6, -1);
            return offset;
        }
    }
}