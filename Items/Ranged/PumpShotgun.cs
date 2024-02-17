using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items.Ranged
{
    public class PumpShotgun : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Pump Shotgun");
            // Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.damage = 12;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 22;
            Item.height = 22;
            Item.useTime = 80;
            Item.useAnimation = 80;
            Item.useStyle = 5;
            Item.maxStack = 1;
            Item.consumable = false;
            Item.noMelee = true;
            Item.knockBack = 1;
            Item.value = 50000;
            Item.shoot = 14;
            Item.rare = 1;
            Item.scale = 1.0f;
            Item.useAmmo = 97;
            Item.UseSound = SoundID.Item36;
            Item.autoReuse = true;
            Item.noUseGraphic = false; // this defines if it does not use graphic
            Item.shootSpeed = 5f;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);
            recipe.AddRecipeGroup(RecipeGroupID.IronBar, 15);
            recipe.AddIngredient(ItemID.IllegalGunParts, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();

        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            int NumProjectiles = 5; // The humber of projectiles that this gun will shoot.
            Vector2 muzzleOffset = Vector2.Normalize(velocity) * 45f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            position.Y -= 5;

            for (int i = 0; i < NumProjectiles; i++)
            {
                // Rotate the velocity randomly by 30 degrees at max.
                Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(12));

                // Decrease velocity randomly for nicer visuals.
                newVelocity *= 1f - Main.rand.NextFloat(0.15f);

                // Create a projectile.
                Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
            }

            return false; // Return false because we don't want tModLoader to shoot projectile
        }
        public override Vector2? HoldoutOffset()
        {
            Vector2 offset = new Vector2(-5, -1);
            return offset;
        }
    }
}