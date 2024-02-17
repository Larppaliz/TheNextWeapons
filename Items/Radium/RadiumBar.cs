using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items.Radium
{
    public class RadiumBar : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Radium Bar");
            // Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.damage = -1;
            Item.width = 40;
            Item.height = 20;
            Item.useTime = 5;
            Item.maxStack = 999;
            Item.useAnimation = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.noMelee = true;
            Item.knockBack = 0;
            Item.value = 2000;
            Item.rare = 3;
            Item.scale = 1.0f;
            Item.consumable = true;
            Item.autoReuse = true;
            Item.createTile = ModContent.TileType<Tiles.RadBar>();
            Item.placeStyle = 0;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(Mod.Find<ModItem>("RadiumOre").Type, 3);
            recipe.AddIngredient(ItemID.Bone, 1);
            recipe.AddTile(TileID.Furnaces);
            recipe.Register();
        }
    }
}