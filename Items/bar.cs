using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items
{
public class bar : ModItem
	{
	public override void SetStaticDefaults()
	{
	DisplayName.SetDefault("Scanedium Bar");
	Tooltip.SetDefault("");
	}
	public override void SetDefaults()
	{
            item.damage = -1;
            item.width = 40;
            item.height = 20;
            item.useTime = 5;
	    item.maxStack = 99999;
            item.useAnimation = 10;
            item.useStyle = 0;
            item.noMelee = true;
            item.knockBack = 0;
            item.value = 45000;
            item.rare = 7;
            item.scale = 1.0f;
            item.autoReuse = true;
}

public override void AddRecipes()
{
ModRecipe recipe = new ModRecipe(mod);
recipe.AddIngredient(mod.ItemType("Ore"), 15);
recipe.AddTile(TileID.Furnaces);
recipe.SetResult(this,3);
recipe.AddRecipe();
        }
    }
}