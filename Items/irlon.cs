using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items
{
public class irlon : ModItem
{
public override void SetStaticDefaults()
{
DisplayName.SetDefault("Iron Longsword");
Tooltip.SetDefault("");
}
public override void SetDefaults()
{
item.damage = 13;
item.melee = true;
item.width = 54;
item.height = 24;
item.maxStack = 1;
item.useTime = 30;
item.useAnimation = 30;
item.useStyle = 1;
item.knockBack = 5;
item.value = 410;
item.rare = 0;
item.UseSound = SoundID.Item1;
item.noMelee = false;
item.scale = 1.2f;
item.crit = 20;
item.autoReuse = true;
}

public override void AddRecipes()
{
ModRecipe recipe = new ModRecipe(mod);
recipe.AddIngredient(ItemID.IronBar, 12);
recipe.AddTile(TileID.Anvils);
recipe.SetResult(this);
recipe.AddRecipe();
}
}
}