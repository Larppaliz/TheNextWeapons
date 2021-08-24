using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items
{
public class sdag : ModItem
{
public override void SetStaticDefaults()
{
	DisplayName.SetDefault("Scanedium Dagger");
	Tooltip.SetDefault("");
	}
        public override void SetDefaults()
        {
            item.damage = 15;
            item.melee = true;
            item.width = 32;
            item.height = 32;
            item.scale = 1.0f;
            item.maxStack = 1;
            item.useTime = 8;
            item.useAnimation = 8;
            item.knockBack = 1f;
            item.UseSound = SoundID.Item1;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.useTurn = true;
            item.useStyle = 5;
            item.value = 80000;
            item.rare = 0;
	    item.shoot = mod.ProjectileType("sdag");
            item.shootSpeed = 6.5f;
}

public override void AddRecipes()
{
ModRecipe recipe = new ModRecipe(mod);
recipe.AddIngredient(mod.ItemType("bar"), 6);
recipe.AddTile(TileID.Anvils);
recipe.SetResult(this,1);
recipe.AddRecipe();
        }      
    }
}