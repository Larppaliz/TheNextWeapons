using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items
{
public class axe : ModItem
{
public override void SetStaticDefaults()
{
DisplayName.SetDefault("Scanedium Waraxe");
Tooltip.SetDefault("");
}
public override void SetDefaults()
{
item.damage = 26;
item.melee = true;
item.width = 54;
item.height = 24;
item.maxStack = 1;
item.useTime = 10;
item.useAnimation = 40;
item.useStyle = 1;
item.knockBack = 3;
item.value = 16000;
item.rare = 7;
item.axe = 20;
item.UseSound = SoundID.Item1;
item.noMelee = false;
item.scale = 1.0f;
item.crit = 10;
item.autoReuse = true;
}

public override void AddRecipes()
{
ModRecipe recipe = new ModRecipe(mod);
recipe.AddIngredient(mod.ItemType("bar"), 14);
recipe.AddTile(TileID.Anvils);
recipe.SetResult(this);
recipe.AddRecipe();
}
}
}