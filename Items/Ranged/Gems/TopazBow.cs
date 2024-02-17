using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items.Ranged.Gems
{
    public class TopazBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Topaz Longbow");
            // Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.width = 24;      //The size of the width of the hitbox in pixels.
            Item.height = 28;      //The size of the height of the hitbox in pixels.
            Item.noMelee = true;     //Setting to True allows the weapon sprite to stop doing damage, so only the projectile does the damge   
            Item.value = 600; // How much the Item is worth, in copper coins, when you sell it to a merchant. It costs 1/5th of this to buy it back from them. An easy way to remember the value is platinum, gold, silver, copper or PPGGSSCC (so this Item price is 10gold)
            Item.rare = 0;   //The color the title of your Weapon when hovering over it ingame

            Item.damage = 17;   //The damage stat for the Weapon.                       
            Item.DamageType = DamageClass.Ranged;   //This defines if it does magic damage and if its effected by magic increasing Armor/Accessories.
	    Item.crit = 8;
            Item.knockBack = 2;  //The knockback stat of your Weapon.   

            Item.useTime = 39;     //How fast the Weapon is used.
            Item.useAnimation = 39;    //How long the Weapon is used for.
            Item.useStyle = 5;         //The way your Weapon will be used, 5 is the Holding Out Used for: Guns, Spellbooks, Drills, Chainsaws, Flails, Spears for example
            Item.UseSound = SoundID.Item5;
            Item.autoReuse = true;

            Item.shoot = 1;
            Item.useAmmo = 40;
            Item.shootSpeed = 7.5f;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Topaz, 10);
            recipe.AddIngredient(ItemID.TinBar, 12);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
 
            Recipe recipe2 = CreateRecipe();
            recipe2.AddIngredient(ItemID.Topaz, 10);
            recipe2.AddIngredient(ItemID.TinBow, 1);
            recipe2.AddIngredient(ItemID.TinBar, 5);
            recipe2.AddTile(TileID.Anvils);
            recipe2.Register();
        }

    }
}