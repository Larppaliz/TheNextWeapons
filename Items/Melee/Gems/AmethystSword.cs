using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items.Melee.Gems
{
    public class AmethystSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Amethyst Sword");
            // Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.damage = 15;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 32;
            Item.height = 32;
            Item.maxStack = 1;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = 1;
            Item.knockBack = 1;
            Item.value = 400;
            Item.rare = 0;
            Item.UseSound = SoundID.Item1;
            Item.noMelee = false;
            Item.scale = 1.0f;
            Item.crit = 2;
            Item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Amethyst, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}