using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items
{
public class silong : ModItem
{
public override void SetStaticDefaults()
{
DisplayName.SetDefault("Silver Longsword");
Tooltip.SetDefault("");
}
public override void SetDefaults()
{
item.damage = 17;
item.melee = true;
item.width = 54;
item.height = 24;
item.maxStack = 1;
item.useTime = 40;
item.useAnimation = 40;
item.useStyle = 1;
item.knockBack = 9;
item.value = 1200;
item.rare = 0;
item.UseSound = SoundID.Item1;
item.noMelee = false;
item.scale = 1.4f;
item.crit = 20;
item.autoReuse = true;
}

public override void AddRecipes()
{
ModRecipe recipe = new ModRecipe(mod);
recipe.AddIngredient(ItemID.SilverBar, 12);
recipe.AddTile(TileID.Anvils);
recipe.SetResult(this);
recipe.AddRecipe();
}
}
}