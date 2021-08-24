using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items
{
public class beer : ModItem
{
public override void SetStaticDefaults()
{
	DisplayName.SetDefault("Steel Spear");
	Tooltip.SetDefault("");
	}
        public override void SetDefaults()
        {
            item.damage = 21;
            item.melee = true;
            item.width = 32;
            item.height = 32;
            item.scale = 1.1f;
            item.maxStack = 1;
            item.useTime = 46;
            item.useAnimation = 46;
            item.knockBack = 6f;
            item.UseSound = SoundID.Item1;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.useTurn = true;
            item.useStyle = 5;
            item.value = 75000;
            item.rare = 4;
	    item.shoot = mod.ProjectileType("beer");
            item.shootSpeed = 6.5f;
        }      
    }
}