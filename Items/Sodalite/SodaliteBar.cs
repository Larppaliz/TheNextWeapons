using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items.Sodalite
{
    public class SodaliteBar : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Sodalite Bar");
            // Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.damage = -1;
            Item.width = 40;
            Item.height = 20;
            Item.useTime = 5;
            Item.maxStack = 99999;
            Item.useAnimation = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.noMelee = true;
            Item.knockBack = 0;
            Item.value = 1600;
            Item.rare = 3;
            Item.scale = 1.0f;
            Item.consumable = true;
            Item.autoReuse = true;
            Item.createTile = ModContent.TileType<Tiles.SodaBar>();
            Item.placeStyle = 0;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(Mod.Find<ModItem>("SodaliteOre").Type, 3);
            recipe.AddTile(TileID.Furnaces);
            recipe.Register();
        }
    }
}