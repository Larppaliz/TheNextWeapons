using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items
{
public class lonk : ModItem
{
public override void SetStaticDefaults()
{
DisplayName.SetDefault("Scanedium Longsword");
Tooltip.SetDefault("");
}
public override void SetDefaults()
{
item.damage = 32;
item.melee = true;
item.width = 54;
item.height = 24;
item.maxStack = 1;
item.useTime = 26;
item.useAnimation = 26;
item.useStyle = 1;
item.knockBack = 8;
item.value = 80000;
item.rare = 2;
item.UseSound = SoundID.Item1;
item.noMelee = false;
item.scale = 1.6f;
item.crit = 6;
item.autoReuse = true;
}

public override void AddRecipes()
{
ModRecipe recipe = new ModRecipe(mod);
recipe.AddIngredient(mod.ItemType("bar"), 18);
recipe.AddTile(TileID.Anvils);
recipe.SetResult(this);
recipe.AddRecipe();
	}

    }

}