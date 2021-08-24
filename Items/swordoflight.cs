using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items
{
public class swordoflight : ModItem
{
public override void SetStaticDefaults()
{
DisplayName.SetDefault("Sword Of Light");
Tooltip.SetDefault("");
}
public override void SetDefaults()
{
item.damage = 40;
item.melee = true;
item.width = 54;
item.height = 24;
item.maxStack = 1;
item.useTime = 52;
item.useAnimation = 26;
item.useStyle = 1;
item.knockBack = 5;
item.value = 50000;
item.rare = 5;
item.shoot = mod.ProjectileType("swordoflight");
item.shootSpeed = 4.5f;
item.UseSound = SoundID.Item1;
item.noMelee = false;
item.scale = 1.0f;
item.crit = 2;
item.autoReuse = true;
}

public override void AddRecipes()
{
ModRecipe recipe = new ModRecipe(mod);
recipe.AddIngredient(mod.ItemType("BarofLight"), 8);
recipe.AddTile(TileID.Anvils);
recipe.SetResult(this);
recipe.AddRecipe();
}
}
}