using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items
{
public class woodag : ModItem
{
public override void SetStaticDefaults()
{
	DisplayName.SetDefault("Wooden Dagger");
	Tooltip.SetDefault("");
	}
        public override void SetDefaults()
        {
            item.damage = 3;
            item.melee = true;
            item.width = 32;
            item.height = 32;
            item.scale = 1.0f;
            item.maxStack = 1;
            item.useTime = 10;
            item.useAnimation = 10;
            item.knockBack = 0.2f;
            item.UseSound = SoundID.Item1;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.useTurn = true;
            item.useStyle = 5;
            item.value = -0;
            item.rare = 0;
	    item.shoot = mod.ProjectileType("woodag");
            item.shootSpeed = 4f;
}

public override void AddRecipes()
{
ModRecipe recipe = new ModRecipe(mod);
recipe.AddIngredient(ItemID.Wood, 4);
recipe.AddTile(TileID.WorkBenches);
recipe.SetResult(this,1);
recipe.AddRecipe();
        }      
    }
}