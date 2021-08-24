using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace TheNextWeapons.Items
{
    public class da : ModItem
    {
        public override void SetStaticDefaults() 
        {
            DisplayName.SetDefault("Geiger Nullifier");

            Tooltip.SetDefault("Nullifies Radioactivity");
        }
        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 28;
            item.rare = 7;
            item.value = 50000;
	    item.defense = 0;
            item.accessory = true;
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Wire, 30);
	    recipe.AddIngredient(mod.ItemType("bra"), 5);
	    recipe.AddIngredient(mod.ItemType("bar"), 15);
            recipe.AddIngredient(ItemID.Emerald, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.lifeRegen += 5;
        }
    }
}