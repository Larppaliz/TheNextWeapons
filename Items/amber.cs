using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items
{
public class amber : ModItem
{
public override void SetStaticDefaults()
{
DisplayName.SetDefault("Amber Armageddon");
Tooltip.SetDefault("");
}
public override void SetDefaults()
{
item.damage = 19;
item.melee = true;
item.width = 54;
item.height = 24;
item.maxStack = 1;
item.useTime = 19;
item.useAnimation = 19;
item.useStyle = 1;
item.knockBack = 6;
item.value = 250000;
item.rare = 2;
item.UseSound = SoundID.Item1;
item.noMelee = false;
item.scale = 1.2f;
item.crit = 12;
item.autoReuse = true;
}

public override void AddRecipes()
{
ModRecipe recipe = new ModRecipe(mod);
recipe.AddIngredient(ItemID.Amber, 25);
recipe.AddTile(TileID.Anvils);
recipe.SetResult(this);
recipe.AddRecipe();
}
}
}