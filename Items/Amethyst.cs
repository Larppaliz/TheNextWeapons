using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items
{
public class Amethyst : ModItem
{
public override void SetStaticDefaults()
{
DisplayName.SetDefault("Amethyst Agression");
Tooltip.SetDefault("");
}
public override void SetDefaults()
{
item.damage = 14;
item.melee = true;
item.width = 54;
item.height = 24;
item.maxStack = 1;
item.useTime = 22;
item.useAnimation = 22;
item.useStyle = 1;
item.knockBack = 8;
item.value = 50000;
item.rare = 2;
item.UseSound = SoundID.Item1;
item.noMelee = false;
item.scale = 1.0f;
item.crit = 8;
item.autoReuse = true;
}

public override void AddRecipes()
{
ModRecipe recipe = new ModRecipe(mod);
recipe.AddIngredient(ItemID.Amethyst, 25);
recipe.AddTile(TileID.Anvils);
recipe.SetResult(this);
recipe.AddRecipe();
}
}
}