using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items.Soul
{
    public class BarofSouls : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Bar of Souls");
            // Tooltip.SetDefault("'The Light And Night have fused into one'");
        }
        public override void SetDefaults()
        {
            Item.damage = -1;
            Item.width = 40;
            Item.height = 20;
            Item.useTime = 5;
            Item.maxStack = 99999;
            Item.useAnimation = 10;
            Item.useStyle = 1;
            Item.noMelee = true;
            Item.knockBack = 0;
            Item.value = 1000;
            Item.rare = 4;
            Item.scale = 1.0f;
            Item.autoReuse = true;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<Tiles.SoulBar>();
            Item.placeStyle = 0;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(3);
            recipe.AddIngredient(ItemID.SoulofNight, 1);
            recipe.AddIngredient(ItemID.SoulofLight, 1);
            recipe.AddIngredient(ItemID.AdamantiteBar, 3);
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.Register();

            Recipe recipe2 = CreateRecipe(3);
            recipe2.AddIngredient(ItemID.SoulofNight, 1);
            recipe2.AddIngredient(ItemID.SoulofLight, 1);
            recipe2.AddIngredient(ItemID.TitaniumBar, 3);
            recipe2.AddTile(TileID.AdamantiteForge);
            recipe2.Register();
        }
    }
}