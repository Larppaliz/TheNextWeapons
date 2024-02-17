using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheNextWeapons.Projectiles.Shortswords;

namespace TheNextWeapons.Items.Sodalite
{
    public class SodaliteShortsword : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Sodalite Shortsword");
            // Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.damage = 18;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 32;
            Item.height = 32;
            Item.scale = 1.1f;
            Item.maxStack = 1;
            Item.useTime = 12;
            Item.useAnimation = 12;
            Item.knockBack = 4f;
            Item.UseSound = SoundID.Item1;
            Item.value = 8000;
            Item.rare = 3;

            Item.shoot = ModContent.ProjectileType<SodaliteShortswordProj>(); // The projectile is what makes a shortsword work
            Item.shootSpeed = 2.1f;
            Item.useStyle = ItemUseStyleID.Rapier;
            Item.autoReuse = true;
            Item.noUseGraphic = true; // The sword is actually a "projectile", so the item should not be visible when used
            Item.noMelee = true; // The projectile will do the damage and not the item
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod.Find<ModItem>("SodaliteBar").Type, 8);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}