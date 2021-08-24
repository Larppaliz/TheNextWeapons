using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items
{
public class diamond : ModItem
{
public override void SetStaticDefaults()
{
DisplayName.SetDefault("Diamond Danger");
Tooltip.SetDefault("");
}
public override void SetDefaults()
{
item.damage = 15;
item.melee = true;
item.width = 54;
item.height = 24;
item.maxStack = 1;
item.useTime = 22;
item.useAnimation = 22;
item.useStyle = 1;
item.knockBack = 3;
item.value = 50000;
item.rare = 2;
item.UseSound = SoundID.Item1;
item.noMelee = false;
item.scale = 1.3f;
item.crit = 5;
item.autoReuse = true;
}

public override void AddRecipes()
{
ModRecipe recipe = new ModRecipe(mod);
recipe.AddIngredient(ItemID.Diamond, 25);
recipe.AddTile(TileID.Anvils);
recipe.SetResult(this);
recipe.AddRecipe();
}
}
}