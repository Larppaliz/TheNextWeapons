using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items
{
public class lightaxe : ModItem
{
public override void SetStaticDefaults()
{
DisplayName.SetDefault("Axe Of Light");
Tooltip.SetDefault("");
}
public override void SetDefaults()
{
item.damage = 16;
item.melee = true;
item.width = 54;
item.height = 24;
item.maxStack = 1;
item.useTime = 15;
item.useAnimation = 20;
item.useStyle = 1;
item.knockBack = 3;
item.value = 16000;
item.rare = 7;
item.axe = 80;
item.UseSound = SoundID.Item1;
item.noMelee = false;
item.scale = 1.0f;
item.crit = 10;
item.autoReuse = true;
}

public override void AddRecipes()
{
ModRecipe recipe = new ModRecipe(mod);
recipe.AddIngredient(mod.ItemType("BarofLight"), 10);
recipe.AddTile(TileID.Anvils);
recipe.SetResult(this);
recipe.AddRecipe();
}
}
}