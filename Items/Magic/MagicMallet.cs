using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items.Magic        //We need this to basically indicate the folder where it is to be read from, so you the texture will load correctly
{
    public class MagicMallet : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Magic Mallet");
            // Tooltip.SetDefault("A magical returning mallet");
        }
        public override void SetDefaults()
        {
            Item.damage = 90;   //The damage stat for the Weapon.                       
            Item.DamageType = DamageClass.Magic;   //This defines if it does magic damage and if its effected by magic increasing Armor/Accessories.
            Item.width = 24;      //The size of the width of the hitbox in pixels.
            Item.height = 24;      //The size of the height of the hitbox in pixels.
            Item.useTime = 30;     //How fast the Weapon is used.
            Item.useAnimation = 30;    //How long the Weapon is used for.
            Item.useStyle = 1;    //The way your Weapon will be used, 5 is the Holding Out Used for: Guns, Spellbooks, Drills, Chainsaws, Flails, Spears for example
            Item.noMelee = true;     //Setting to True allows the weapon sprite to stop doing damage, so only the projectile does the damge
            Item.knockBack = 5;  //The knockback stat of your Weapon.      
            Item.value = 105000; // How much the Item is worth, in copper coins, when you sell it to a merchant. It costs 1/5th of this to buy it back from them. An easy way to remember the value is platinum, gold, silver, copper or PPGGSSCC (so this Item price is 10gold)
            Item.rare = 4;   //The color the title of your Weapon when hovering over it ingame
            Item.mana = 18;//How many mana this weapon use
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.shoot = Mod.Find<ModProjectile>("hamr").Type;
            Item.noUseGraphic = true; // this defines if it does not use graphic
            Item.shootSpeed = 14f;
        }
    }
}