
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheNextWeapons.Items;
 
namespace TheNextWeapons.Items
{
    public class Bullet : ModItem
    {
public override void SetStaticDefaults()
{
DisplayName.SetDefault("Disc Bullet");
Tooltip.SetDefault("Returns to your original spot");
}
public override void SetDefaults()
{
            item.damage = 10;    //The damage stat for the Weapon.
            item.ranged = true;  //This defines if it does Ranged damage and if its effected by Ranged increasing Armor/Accessories.
            item.width = 8;  //The size of the width of the hitbox in pixels.
            item.height = 8;   //The size of the height of the hitbox in pixels.
            item.maxStack = 999; //This defines the items max stack
            item.consumable = true;  //Tells the game that this should be used up once fired
            item.knockBack = 1.5f;  //Added with the weapon's knockback
            item.value = 4000;
            item.rare = 4;
            item.shoot = mod.ProjectileType("fors");
            item.shootSpeed = 2f;
            item.ammo = 97;
        }
 
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
	    recipe.AddIngredient(mod.ItemType("bar"), 1);
            recipe.AddTile(TileID.Anvils);   //this is where to craft the item ,Anvils = all Anvils    Anvils = all anvils , MythrilAnvil = Mythril Anvil and Orichalcum Anvil, Furnaces = all furnaces , DemonAltar = Demon Altar and Crimson Altar , TinkerersWorkbench = Tinkerer's Workbench
            recipe.SetResult(this, 50);
            recipe.AddRecipe();
        }
    }
}