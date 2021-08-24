using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace TheNextWeapons.Items
{
    public class hp : ModItem
    {
        public override void SetStaticDefaults() 
        {
            DisplayName.SetDefault("1000 life item");

            Tooltip.SetDefault("1000 Max Health");
        }
        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 28;
            item.rare = 12;
            item.value = 500000000;
	    item.defense = 0;
            item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statLifeMax2 = 1000;
        }
    }
}