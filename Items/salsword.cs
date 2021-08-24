using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items
{
public class salsword : ModItem
{
public override void SetStaticDefaults()
{
DisplayName.SetDefault("Radium Longsword");
Tooltip.SetDefault("");
}
public override void SetDefaults()
{
item.damage = 40;
item.melee = true;
item.width = 54;
item.height = 24;
item.maxStack = 1;
item.useTime = 38;
item.useAnimation = 38;
item.useStyle = 1;
item.knockBack = 3;
item.value = 200000;
item.rare = 2;
item.UseSound = SoundID.Item1;
item.noMelee = false;
item.scale = 1.7f;
item.crit = 12;
item.autoReuse = true;
}

public override void AddRecipes()
{
ModRecipe recipe = new ModRecipe(mod);
recipe.AddIngredient(mod.ItemType("bra"), 12);
recipe.AddTile(TileID.Anvils);
recipe.SetResult(this);
recipe.AddRecipe();
	}

    }

}