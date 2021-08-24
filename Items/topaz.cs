 using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items
{
public class topaz : ModItem
{
public override void SetStaticDefaults()
{
DisplayName.SetDefault("Topaz Terminator");
Tooltip.SetDefault("");
}
public override void SetDefaults()
{
item.damage = 20;
item.melee = true;
item.width = 54;
item.height = 24;
item.maxStack = 1;
item.useTime = 54;
item.useAnimation = 22;
item.useStyle = 1;
item.knockBack = 3;
item.value = 50000;
item.rare = 2;
item.UseSound = SoundID.Item1;
item.noMelee = false;
item.scale = 1.0f;
item.crit = 15;
item.autoReuse = true;
}

public override void AddRecipes()
{
ModRecipe recipe = new ModRecipe(mod);
recipe.AddIngredient(ItemID.Topaz, 25);
recipe.AddTile(TileID.Anvils);
recipe.SetResult(this);
recipe.AddRecipe();
}
}
}