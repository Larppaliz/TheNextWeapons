using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.IO;

namespace TheNextWeapons.Items.Melee
{
    public class CrystalSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Crystal Sword");
            // Tooltip.SetDefault("");
            Item.staff[Item.type] = false;
        }
        public override void SetDefaults()
        {
            Item.damage = 49;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 22;
            Item.height = 22;
            Item.useTime = 23;
            Item.useAnimation = 23;
            Item.useStyle = 1;
            Item.maxStack = 1;
            Item.consumable = false;
            Item.noMelee = false;
            Item.knockBack = 1;
            Item.value = 1000;
            Item.rare = 4;
            Item.scale = 1.0f;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.noUseGraphic = false; // this defines if it does not use graphic
            Item.shootSpeed = 10f;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(ItemID.CrystalShard, 50);
            recipe.AddIngredient(ItemID.CobaltSword, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();

            Recipe recipe1 = CreateRecipe(1);
            recipe1.AddIngredient(ItemID.CrystalShard, 50);
            recipe1.AddIngredient(ItemID.PalladiumSword, 1);
            recipe1.AddTile(TileID.MythrilAnvil);
            recipe1.Register();

        }
        int shot;
        public override bool CanUseItem(Player player)
        {
            if (shot == 2) { shot = 0; Item.shoot = 94; }
            else { shot += 1; Item.shoot = 0; }
            return true;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            int NumProjectiles = Main.rand.Next(3, 8); // The humber of projectiles that this gun will shoot.

            for (int i = 0; i < NumProjectiles; i++)
            {
                // Rotate the velocity randomly by 30 degrees at max.
                Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(60));

                // Decrease velocity randomly for nicer visuals.
                newVelocity *= 1f - Main.rand.NextFloat(0.3f);

                // Create a projectile.
                Projectile.NewProjectileDirect(source, position, newVelocity, type, damage/NumProjectiles, knockback, player.whoAmI);
            }

            return false; // Return false because we don't want tModLoader to shoot projectile
        }
    }
}