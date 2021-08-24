using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items
{
public class tulon : ModItem
{
public override void SetStaticDefaults()
{
DisplayName.SetDefault("Tungsten Longsword");
Tooltip.SetDefault("");
}
public override void SetDefaults()
{
item.damage = 20;
item.melee = true;
item.width = 54;
item.height = 24;
item.maxStack = 1;
item.useTime = 45;
item.useAnimation = 45;
item.useStyle = 1;
item.knockBack = 9;
item.value = 1650;
item.rare = 0;
item.UseSound = SoundID.Item1;
item.noMelee = false;
item.scale = 1.6f;
item.crit = 5;
item.autoReuse = true;
}

public override void AddRecipes()
{
ModRecipe recipe = new ModRecipe(mod);
recipe.AddIngredient(ItemID.TungstenBar, 12);
recipe.AddTile(TileID.Anvils);
recipe.SetResult(this);
recipe.AddRecipe();
}
}
}