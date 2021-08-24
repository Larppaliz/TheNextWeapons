using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items
{
public class leaddag : ModItem
{
public override void SetStaticDefaults()
{
	DisplayName.SetDefault("Lead Dagger");
	Tooltip.SetDefault("");
	}
        public override void SetDefaults()
        {
            item.damage = 9;
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
            item.value = 469;
            item.rare = 0;
	    item.shoot = mod.ProjectileType("leaddag");
            item.shootSpeed = 6.5f;
}

public override void AddRecipes()
{
ModRecipe recipe = new ModRecipe(mod);
recipe.AddIngredient(ItemID.LeadBar, 9);
recipe.AddTile(TileID.Anvils);
recipe.SetResult(this,1);
recipe.AddRecipe();
        }      
    }
}