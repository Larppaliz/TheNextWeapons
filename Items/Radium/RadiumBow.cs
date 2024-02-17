using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
namespace TheNextWeapons.Items.Radium
{
    public class RadiumBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Radium Longbow");
            // Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.damage = 26;   //The damage stat for the Weapon.                       
            Item.DamageType = DamageClass.Ranged;   //This defines if it does magic damage and if its effected by magic increasing Armor/Accessories.
            Item.width = 24;      //The size of the width of the hitbox in pixels.
            Item.height = 28;      //The size of the height of the hitbox in pixels.
            Item.useTime = 30;     //How fast the Weapon is used.
            Item.useAnimation = 30;    //How long the Weapon is used for.
            Item.useStyle = 5;         //The way your Weapon will be used, 5 is the Holding Out Used for: Guns, Spellbooks, Drills, Chainsaws, Flails, Spears for example
            Item.noMelee = true;     //Setting to True allows the weapon sprite to stop doing damage, so only the projectile does the damge
            Item.knockBack = 2;  //The knockback stat of your Weapon.      
            Item.value = 19000; // How much the Item is worth, in copper coins, when you sell it to a merchant. It costs 1/5th of this to buy it back from them. An easy way to remember the value is platinum, gold, silver, copper or PPGGSSCC (so this Item price is 10gold)
            Item.rare = 3;   //The color the title of your Weapon when hovering over it ingame
            Item.UseSound = SoundID.Item5;
            Item.autoReuse = true;
            Item.shoot = 1;
            Item.useAmmo = 40;
            Item.shootSpeed = 20f;
        }
        int swing;
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod.Find<ModItem>("RadiumBar").Type, 11);
            recipe.AddTile(TileID.Anvils);
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            swing++;
            if (swing > 1)
            {
                float numberProjectiles = swing;
                float rotation = MathHelper.ToRadians(7);
                if (swing >= 3)
                {
                    rotation = MathHelper.ToRadians(15);
                    swing = 0;
                }
                for (int i = 0; i < numberProjectiles; i++)
                {
                    Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1)));
                    Projectile.NewProjectileDirect(source, position, perturbedSpeed, Mod.Find<ModProjectile>("RadiumArrow").Type, damage, knockback, player.whoAmI);
                }
            }
            else 
            {
                Projectile.NewProjectileDirect(source, position, velocity, Mod.Find<ModProjectile>("RadiumArrow").Type, damage, knockback, player.whoAmI);
            }
            return false;
        }

    }
}