using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items
{
public class emerald : ModItem
{
public override void SetStaticDefaults()
{
DisplayName.SetDefault("Emerald Execution");
Tooltip.SetDefault("Somehow Causes Magic Damage...");
}
public override void SetDefaults()
{
item.damage = 13;
item.magic = true;
item.width = 54;
item.height = 24;
item.maxStack = 1;
item.useTime = 20;
item.useAnimation = 20;
item.useStyle = 1;
item.knockBack = 5;
item.value = 50000;
item.rare = 2;
item.UseSound = SoundID.Item1;
item.noMelee = false;
item.scale = 0.8f;
item.crit = 5;
item.autoReuse = true;
}

public override void AddRecipes()
{
ModRecipe recipe = new ModRecipe(mod);
recipe.AddIngredient(ItemID.Emerald, 25);
recipe.AddTile(TileID.Anvils);
recipe.SetResult(this);
recipe.AddRecipe();
}
}
}