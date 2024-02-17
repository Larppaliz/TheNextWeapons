using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items.Sodalite
{
    public class SodaliteWaraxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Sodalite Waraxe");
            // Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.damage = 26;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 54;
            Item.height = 24;
            Item.maxStack = 1;
            Item.useTime = 15;
            Item.useAnimation = 30;
            Item.useStyle = 1;
            Item.knockBack = 3;
            Item.value = 19000;
            Item.rare = 3;
            Item.axe = 20;
            Item.UseSound = SoundID.Item1;
            Item.noMelee = false;
            Item.scale = 1.0f;
            Item.crit = 10;
            Item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod.Find<ModItem>("SodaliteBar").Type, 14);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}