using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items
{
public class Ore : ModItem
	{
	public override void SetStaticDefaults()
	{
	DisplayName.SetDefault("Scanedium Ore");
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
            item.useStyle = 1;
            item.noMelee = true;
            item.knockBack = 0;
            item.value = 15000;
            item.rare = 7;
	    item.consumable = true;
            item.scale = 1.0f;
            item.autoReuse = true;
            item.createTile = mod.TileType("Ore");
        }
    }
}