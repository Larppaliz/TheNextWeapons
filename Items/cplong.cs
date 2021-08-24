using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items
{
public class cplong : ModItem
{
public override void SetStaticDefaults()
{
DisplayName.SetDefault("Copper Longsword");
Tooltip.SetDefault("");
}
public override void SetDefaults()
{
item.damage = 12;
item.melee = true;
item.width = 54;
item.height = 24;
item.maxStack = 1;
item.useTime = 32;
item.useAnimation = 32;
item.useStyle = 1;
item.knockBack = 9;
item.value = 120;
item.rare = 0;
item.UseSound = SoundID.Item1;
item.noMelee = false;
item.scale = 1.2f;
item.crit = 12;
item.autoReuse = true;
}

public override void AddRecipes()
{
ModRecipe recipe = new ModRecipe(mod);
recipe.AddIngredient(ItemID.CopperBar, 12);
recipe.AddTile(TileID.Anvils);
recipe.SetResult(this);
recipe.AddRecipe();
}
}
}