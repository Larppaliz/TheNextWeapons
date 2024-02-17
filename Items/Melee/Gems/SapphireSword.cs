using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items.Melee.Gems
{
    public class SapphireSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Sapphire Sword");
            // Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.damage = 19;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 54;
            Item.height = 24;
            Item.maxStack = 1;
            Item.useTime = 18;
            Item.useAnimation = 18;
            Item.useStyle = 1;
            Item.knockBack = 2;
            Item.value = 2000;
            Item.rare = 1;
            Item.UseSound = SoundID.Item1;
            Item.noMelee = false;
            Item.scale = 1.0f;
            Item.crit = 6;
            Item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Sapphire, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}