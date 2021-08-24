using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items
{
public class BarofLight : ModItem
	{
	public override void SetStaticDefaults()
	{
	DisplayName.SetDefault("Bar Of Light");
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
recipe.AddIngredient(ItemID.SoulofLight, 6);
recipe.AddRecipeGroup("IronBar", 2);
recipe.AddTile(TileID.Furnaces);
recipe.SetResult(this,1);
recipe.AddRecipe();
        }
    }
}