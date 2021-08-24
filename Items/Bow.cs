using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace TheNextWeapons.Items        //We need this to basically indicate the folder where it is to be read from, so you the texture will load correctly
{
    public class bow : ModItem
    {
	public override void SetStaticDefaults()
	{
	DisplayName.SetDefault("Radium Bow");
	Tooltip.SetDefault("Shoots 3 arrows");
        }
        public override void SetDefaults()
        {
            item.damage = 15;   //The damage stat for the Weapon.                       
            item.ranged = true;   //This defines if it does magic damage and if its effected by magic increasing Armor/Accessories.
            item.width = 24;      //The size of the width of the hitbox in pixels.
            item.height = 28;      //The size of the height of the hitbox in pixels.
            item.useTime = 20;     //How fast the Weapon is used.
            item.useAnimation = 20;    //How long the Weapon is used for.
            item.useStyle = 5;         //The way your Weapon will be used, 5 is the Holding Out Used for: Guns, Spellbooks, Drills, Chainsaws, Flails, Spears for example
            item.noMelee = true;     //Setting to True allows the weapon sprite to stop doing damage, so only the projectile does the damge
            item.knockBack = 2;  //The knockback stat of your Weapon.      
            item.value = 1050000; // How much the item is worth, in copper coins, when you sell it to a merchant. It costs 1/5th of this to buy it back from them. An easy way to remember the value is platinum, gold, silver, copper or PPGGSSCC (so this item price is 10gold)
            item.rare = 10;   //The color the title of your Weapon when hovering over it ingame
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.shoot = 1;
            item.useAmmo = 40;
            item.shootSpeed = 30f;
	}

	public override void AddRecipes()
	{
	ModRecipe recipe = new ModRecipe(mod);
	recipe.AddIngredient(mod.ItemType("bra"), 11);
	recipe.AddTile(TileID.Anvils);
	recipe.SetResult(this);
        }
        //  -----------------------------------------------Even Arc style: Multiple Projectile, Even Spread ---------------------------------------------------------
          public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
          {
              float numberProjectiles = 3; // This defines how many projectiles to shot
              float rotation = MathHelper.ToRadians(9);
              position += Vector2.Normalize(new Vector2(speedX, speedY)) * 45f; //this defines the distance of the projectiles form the player when the projectile spawns
              for (int i = 0; i < numberProjectiles; i++)
              {
                  Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .4f; // This defines the projectile roatation and speed. .4f == projectile speed
                  Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
              }
              return false;
          }  
           
        }
}