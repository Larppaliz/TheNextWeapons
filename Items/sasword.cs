using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items
{
public class sasword : ModItem
{
public override void SetStaticDefaults()
{
DisplayName.SetDefault("Radium Broadsword");
Tooltip.SetDefault("");
}
public override void SetDefaults()
{
item.damage = 30;
item.melee = true;
item.width = 54;
item.height = 24;
item.maxStack = 1;
item.useTime = 26;
item.useAnimation = 26;
item.useStyle = 1;
item.knockBack = 3;
item.value = 200000;
item.rare = 2;
item.UseSound = SoundID.Item1;
item.noMelee = false;
item.scale = 1.45f;
item.crit = 4;
item.autoReuse = true;
}

public override void AddRecipes()
{
ModRecipe recipe = new ModRecipe(mod);
recipe.AddIngredient(mod.ItemType("bra"), 10);
recipe.AddTile(TileID.Anvils);
recipe.SetResult(this);
recipe.AddRecipe();
	}

    }

}