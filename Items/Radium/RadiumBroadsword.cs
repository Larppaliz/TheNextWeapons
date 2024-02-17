using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items.Radium
{
    public class RadiumBroadsword : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Radium Broadsword");
            // Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.damage = 45;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 54;
            Item.height = 24;
            Item.maxStack = 1;
            Item.useTime = 24;
            Item.useAnimation = 24;
            Item.useStyle = 1;
            Item.knockBack = 3;
            Item.value = 16000;
            Item.rare = 3;
            Item.UseSound = SoundID.Item1;
            Item.noMelee = false;
            Item.scale = 1.45f;
            Item.crit = 4;
            Item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod.Find<ModItem>("RadiumBar").Type, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }

    }

}