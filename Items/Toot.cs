using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items
{
public class Toot : ModItem
{
public override void SetStaticDefaults()
{
	DisplayName.SetDefault("Steel Dagger");
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
            item.useTime = 9;
            item.useAnimation = 9;
            item.knockBack = 4f;
            item.UseSound = SoundID.Item1;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.useTurn = true;
            item.useStyle = 5;
            item.value = 25000;
            item.rare = 4;
	    item.shoot = mod.ProjectileType("pear");
            item.shootSpeed = 6.0f;
        }      
    }
}