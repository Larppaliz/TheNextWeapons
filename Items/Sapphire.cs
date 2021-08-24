using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items
{
public class Sapphire : ModItem
{
public override void SetStaticDefaults()
{
DisplayName.SetDefault("Sapphire Swing");
Tooltip.SetDefault("");
}
public override void SetDefaults()
{
item.damage = 15;
item.melee = true;
item.width = 54;
item.height = 24;
item.maxStack = 1;
item.useTime = 18;
item.useAnimation = 18;
item.useStyle = 1;
item.knockBack = 3;
item.value = 50000;
item.rare = 2;
item.UseSound = SoundID.Item1;
item.noMelee = false;
item.scale = 1.0f;
item.crit = 2;
item.autoReuse = true;
}

public override void AddRecipes()
{
ModRecipe recipe = new ModRecipe(mod);
recipe.AddIngredient(ItemID.Sapphire, 25);
recipe.AddTile(TileID.Anvils);
recipe.SetResult(this);
recipe.AddRecipe();
}
}
}