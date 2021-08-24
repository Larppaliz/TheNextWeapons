 using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items
{
public class wshot : ModItem
{
public override void SetStaticDefaults()
{
DisplayName.SetDefault("Wooden Shortsword");
Tooltip.SetDefault("");
}
public override void SetDefaults()
{
item.damage = 5;
item.melee = true;
item.width = 54;
item.height = 24;
item.maxStack = 1;
item.useTime = 18;
item.useAnimation = 18;
item.useStyle = 3;
item.knockBack = 4;
item.value = 0;
item.rare = 0;
item.UseSound = SoundID.Item1;
item.noMelee = false;
item.scale = 1.0f;
item.crit = 0;
item.autoReuse = true;
}

public override void AddRecipes()
{
ModRecipe recipe = new ModRecipe(mod);
recipe.AddIngredient(ItemID.Wood, 6);
recipe.AddTile(TileID.WorkBenches);
recipe.SetResult(this);
recipe.AddRecipe();
}
}
}