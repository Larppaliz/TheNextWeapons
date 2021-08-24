using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items
{
public class bra : ModItem
	{
	public override void SetStaticDefaults()
	{
	DisplayName.SetDefault("Radium Bar");
	Tooltip.SetDefault("");
	}
	public override void SetDefaults()
	{
            item.damage = -1;
            item.width = 40;
            item.height = 20;
            item.useTime = 5;
	    item.maxStack = 999;
            item.useAnimation = 10;
            item.useStyle = 0;
            item.noMelee = true;
            item.knockBack = 0;
            item.value = 350000;
            item.rare = 7;
            item.scale = 1.0f;
            item.autoReuse = true;
}

public override void AddRecipes()
{
ModRecipe recipe = new ModRecipe(mod);
recipe.AddIngredient(mod.ItemType("r"), 10);
recipe.AddIngredient(ItemID.Bone, 5);
recipe.AddTile(TileID.Furnaces);
recipe.SetResult(this,1);
recipe.AddRecipe();
        }
    }
}