using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items
{
public class swordofnight : ModItem
{
public override void SetStaticDefaults()
{
DisplayName.SetDefault("Sword Of Night");
Tooltip.SetDefault("");
}
public override void SetDefaults()
{
item.damage = 45;
item.melee = true;
item.width = 54;
item.height = 24;
item.maxStack = 1;
item.useTime = 60;
item.useAnimation = 30;
item.useStyle = 1;
item.knockBack = 5;
item.value = 50000;
item.rare = 5;
item.shoot = mod.ProjectileType("swordofnight");
item.shootSpeed = 5.5f;
item.UseSound = SoundID.Item1;
item.noMelee = false;
item.scale = 1.2f;
item.crit = 2;
item.autoReuse = true;
}

public override void AddRecipes()
{
ModRecipe recipe = new ModRecipe(mod);
recipe.AddIngredient(mod.ItemType("BarofNight"), 8);
recipe.AddTile(TileID.Anvils);
recipe.SetResult(this);
recipe.AddRecipe();
}
}
}