using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items.Radium
{
    public class RadiumAxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Radium Axe");
            // Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.damage = 34;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 54;
            Item.height = 24;
            Item.maxStack = 1;
            Item.useTime = 8;
            Item.useAnimation = 40;
            Item.useStyle = 1;
            Item.knockBack = 3;
            Item.value = 26000;
            Item.rare = 3;
            Item.axe = 30;
            Item.UseSound = SoundID.Item1;
            Item.noMelee = false;
            Item.scale = 1.1f;
            Item.crit = 15;
            Item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod.Find<ModItem>("RadiumBar").Type, 14);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}