using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items.Void      //We need this to basically indicate the folder where it is to be read from, so you the texture will load correctly
{
    public class VoidStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Infinitude Staff");
            // Tooltip.SetDefault("");
            Item.staff[Item.type] = true;
        }
        public override void SetDefaults()
        {
            Item.damage = 46;   //The damage stat for the Weapon.                       
            Item.DamageType = DamageClass.Magic;   //This defines if it does magic damage and if its effected by magic increasing Armor/Accessories.
            Item.width = 24;      //The size of the width of the hitbox in pixels.
            Item.height = 28;      //The size of the height of the hitbox in pixels.
            Item.useTime = 45;     //How fast the Weapon is used.
            Item.useAnimation = 45;    //How long the Weapon is used for.
            Item.useStyle = 5;         //The way your Weapon will be used, 5 is the Holding Out Used for: Guns, Spellbooks, Drills, Chainsaws, Flails, Spears for example
            Item.noMelee = true;     //Setting to True allows the weapon sprite to stop doing damage, so only the projectile does the damge
            Item.knockBack = 2;  //The knockback stat of your Weapon.      
            Item.value = 700000; // How much the Item is worth, in copper coins, when you sell it to a merchant. It costs 1/5th of this to buy it back from them. An easy way to remember the value is platinum, gold, silver, copper or PPGGSSCC (so this Item price is 10gold)
            Item.rare = 7;   //The color the title of your Weapon when hovering over it ingame
            Item.mana = 10;//How many mana this weapon use
            Item.UseSound = SoundID.Item117;
            Item.autoReuse = true;
            Item.shoot = Mod.Find<ModProjectile>("VoidSlash").Type;
	        Item.channel = true;
            Item.shootSpeed = 5f;
        }
        int MaxProjs = 1;

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(Mod.Find<ModItem>("VoidBar").Type, 15);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();

        }

        public override void HoldItem(Player player)
        {
            if(!player.channel) { MaxProjs = 1; }
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (MaxProjs > 0)
            {
                MaxProjs -= 1;
                position = Main.MouseWorld;
                velocity *= 0f;
                Projectile.NewProjectileDirect(source, position, velocity, type, damage, knockback, player.whoAmI);
            }
            return false;
        }
    }
}