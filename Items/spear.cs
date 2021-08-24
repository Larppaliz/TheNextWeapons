using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items
{
public class spear : ModItem
{
public override void SetStaticDefaults()
{
	DisplayName.SetDefault("Scanedium Shortsword");
	Tooltip.SetDefault("");
	}
        public override void SetDefaults()
        {
            item.damage = 19;
            item.melee = true;
            item.width = 32;
            item.height = 32;
            item.scale = 1.1f;
            item.maxStack = 1;
            item.useTime = 15;
            item.useAnimation = 15;
            item.knockBack = 4f;
            item.UseSound = SoundID.Item1;
            item.noMelee = false;
            item.noUseGraphic = false;
            item.useTurn = true;
            item.useStyle = 3;
            item.value = 140000;
            item.rare = 3;
            item.shootSpeed = 5f;
	}

	public override void AddRecipes()
	{
	ModRecipe recipe = new ModRecipe(mod);
	recipe.AddIngredient(mod.ItemType("bar"), 7);
	recipe.AddTile(TileID.Anvils);
	recipe.SetResult(this);
        }      
    }
}