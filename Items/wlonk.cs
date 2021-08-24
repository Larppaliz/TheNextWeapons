 using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items
{
public class wlonk : ModItem
{
public override void SetStaticDefaults()
{
DisplayName.SetDefault("Wooden Longsword");
Tooltip.SetDefault("");
}
public override void SetDefaults()
{
item.damage = 10;
item.melee = true;
item.width = 54;
item.height = 24;
item.maxStack = 1;
item.useTime = 30;
item.useAnimation = 30;
item.useStyle = 1;
item.knockBack = 4;
item.value = 0;
item.rare = 0;
item.UseSound = SoundID.Item1;
item.noMelee = false;
item.scale = 1.1f;
item.crit = 6;
item.autoReuse = true;
}

public override void AddRecipes()
{
ModRecipe recipe = new ModRecipe(mod);
recipe.AddIngredient(ItemID.Wood, 12);
recipe.AddTile(TileID.WorkBenches);
recipe.SetResult(this);
recipe.AddRecipe();
}
}
}