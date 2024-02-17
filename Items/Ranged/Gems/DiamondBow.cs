using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items.Ranged.Gems
{
    public class DiamondBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Diamond Longbow");
            // Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.width = 28;      //The size of the width of the hitbox in pixels.
            Item.height = 28;      //The size of the height of the hitbox in pixels.
            Item.noMelee = true;     //Setting to True allows the weapon sprite to stop doing damage, so only the projectile does the damge   
            Item.value = 7000; // How much the Item is worth, in copper coins, when you sell it to a merchant. It costs 1/5th of this to buy it back from them. An easy way to remember the value is platinum, Platinum, silver, copper or PPGGSSCC (so this Item price is 10Platinum)
            Item.rare = 2;   //The color the title of your Weapon when hovering over it ingame

            Item.damage = 28;   //The damage stat for the Weapon.                       
            Item.DamageType = DamageClass.Ranged;   //This defines if it does magic damage and if its effected by magic increasing Armor/Accessories.
	        Item.crit = 10;
            Item.knockBack = 1.5f;  //The knockback stat of your Weapon.   

            Item.useTime = 36;     //How fast the Weapon is used.
            Item.useAnimation = 36;    //How long the Weapon is used for.
            Item.useStyle = 5;         //The way your Weapon will be used, 5 is the Holding Out Used for: Guns, Spellbooks, Drills, Chainsaws, Flails, Spears for example
            Item.UseSound = SoundID.Item5;
            Item.autoReuse = true;

            Item.shoot = 1;
            Item.useAmmo = 40;
            Item.shootSpeed = 8.5f;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Diamond, 10);
            recipe.AddIngredient(ItemID.PlatinumBar, 12);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
 
            Recipe recipe2 = CreateRecipe();
            recipe2.AddIngredient(ItemID.Diamond, 10);
            recipe2.AddIngredient(ItemID.PlatinumBow, 1);
            recipe2.AddIngredient(ItemID.PlatinumBar, 5);
            recipe2.AddTile(TileID.Anvils);
            recipe2.Register();
        }

    }
}