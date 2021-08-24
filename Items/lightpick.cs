using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items
{
public class lightpick : ModItem
{
public override void SetStaticDefaults()
{
DisplayName.SetDefault("Pickaxe Of Light");
Tooltip.SetDefault("For a pickaxe made out of metal it is quite LIGHTweight.");
}
public override void SetDefaults()
{
item.damage = 12;
item.melee = true;
item.width = 54;
item.height = 24;
item.maxStack = 1;
item.useTime = 17;
item.useAnimation = 17;
item.useStyle = 1;
item.knockBack = 3;
item.value = 16000;
item.rare = 7;
item.pick = 125;
item.UseSound = SoundID.Item1;
item.noMelee = false;
item.scale = 1.0f;
item.crit = 10;
item.autoReuse = true;
}

public override void AddRecipes()
{
ModRecipe recipe = new ModRecipe(mod);
recipe.AddIngredient(mod.ItemType("BarofLight"), 15);
recipe.AddTile(TileID.Anvils);
recipe.SetResult(this);
recipe.AddRecipe();
}
}
}