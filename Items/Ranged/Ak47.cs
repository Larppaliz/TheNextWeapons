using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items.Ranged
{
    public class Ak47 : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Kalashnikov Assault Rifle");
            // Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.damage = 28;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 54;
            Item.height = 24;
            Item.maxStack = 1;
            Item.useTime = 7;
            Item.useAnimation = 7;
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
        /*
        float innaccuracy = 0f;
        int shoottimer = 0;
        public override void UpdateInventory(Player player)
        {
            shoottimer--;
            if (shoottimer < 1)
            {
                innaccuracy = 0f;
            }
        }
        public override bool AltFunctionUse(Player player)
        {
            
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                Item.noUseGraphic = true;
                Item.useStyle = 1;
                Item.UseSound = SoundID.Item1;
                Item.shoot = Mod.Find<ModProjectile>("Chains").Type;
                Item.useAmmo = 0;
                Item.consumable = true;
            }
            else
            {
                Item.noUseGraphic = false;
                Item.useStyle = 5;
                Item.UseSound = SoundID.Item41;
                Item.shoot = 14;
                Item.useAmmo = 97;
            }
            return player.inventory[player.selectedItem] == Item || player.inventory[player.selectedItem + 10] == Item;
        }
        */
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            /*
            shoottimer = 20;
            if (innaccuracy < 20f)
            {
                innaccuracy += 1f;
            */
            Vector2 muzzleOffset = Vector2.Normalize(velocity) * 20f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }

            if (type == ProjectileID.Bullet)
            {
                type = ProjectileID.BulletHighVelocity;
            }
            position.Y -= 2;
            /*
                Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(innaccuracy + (player.velocity.Y * 4) + (player.velocity.X * 2)));
            */
            Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(3));
            // Decrease velocity randomly for nicer visuals.
            newVelocity *= 1f - Main.rand.NextFloat(0.15f);

                // Create a projectile.
                Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);

            return false; // Return false because we don't want tModLoader to shoot projectile
        }
        public override Vector2? HoldoutOffset()
        {
            Vector2 offset = new Vector2(-1, 1);
            return offset;
        }
    }
}