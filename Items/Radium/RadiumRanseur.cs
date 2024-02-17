using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TheNextWeapons.Projectiles;

namespace TheNextWeapons.Items.Radium        //We need this to basically indicate the folder where it is to be read from, so you the texture will load correctly
{
    public class RadiumRanseur : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Radium Ranseur");
            // Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.Spear);
            Item.damage = 32;   //The damage stat for the Weapon.                       
            Item.DamageType = DamageClass.Melee;   //This defines if it does magic damage and if its effected by magic increasing Armor/Accessories.
            Item.width = 24;      //The size of the width of the hitbox in pixels.
            Item.height = 28;      //The size of the height of the hitbox in pixels.
            Item.useTime = 5;     //How fast the Weapon is used.
            Item.useAnimation = 5;    //How long the Weapon is used for.
            Item.useStyle = 5;         //The way your Weapon will be used, 5 is the Holding Out Used for: Guns, Spellbooks, Drills, Chainsaws, Flails, Spears for example
            Item.noMelee = true;     //Setting to True allows the weapon sprite to stop doing damage, so only the projectile does the damge
            Item.knockBack = 2;  //The knockback stat of your Weapon.      
            Item.value = 21000; // How much the Item is worth, in copper coins, when you sell it to a merchant. It costs 1/5th of this to buy it back from them. An easy way to remember the value is platinum, gold, silver, copper or PPGGSSCC (so this Item price is 10gold)
            Item.rare = 3;   //The color the title of your Weapon when hovering over it ingame
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<Projectiles.RadiumRanseurProjectile>();
            Item.shootSpeed = 5f;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(Mod.Find<ModItem>("RadiumBar").Type, 15);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();

        }
        public override bool CanUseItem(Player player)
        {
            if ((int)player.Distance(Main.MouseWorld) + 20f > RadiumRanseurProjectile.HoldoutRangeMax) { Item.reuseDelay = (int)RadiumRanseurProjectile.HoldoutRangeMax / 5; }
            else
            {
                Item.reuseDelay = (int)(player.Distance(Main.MouseWorld) + 50f) / 5;
            }
            return true;
        }

    }
}