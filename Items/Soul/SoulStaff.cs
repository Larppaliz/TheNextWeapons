using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TheNextWeapons.Projectiles;

namespace TheNextWeapons.Items.Soul        //We need this to basically indicate the folder where it is to be read from, so you the texture will load correctly
{
    public class SoulStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Soul Staff");
            // Tooltip.SetDefault("'I thought it was gonna be necromancy related'");
            Item.staff[Item.type] = true;
        }
        public override void SetDefaults()
        {
            Item.damage = 18;   //The damage stat for the Weapon.                       
            Item.DamageType = DamageClass.Magic;   //This defines if it does magic damage and if its effected by magic increasing Armor/Accessories.
            Item.width = 24;      //The size of the width of the hitbox in pixels.
            Item.height = 28;      //The size of the height of the hitbox in pixels.
            Item.useTime = 30;     //How fast the Weapon is used.
            Item.useAnimation = 30;    //How long the Weapon is used for.
            Item.reuseDelay = 0;
            Item.useStyle = 5;         //The way your Weapon will be used, 5 is the Holding Out Used for: Guns, Spellbooks, Drills, Chainsaws, Flails, Spears for example
            Item.noMelee = true;     //Setting to True allows the weapon sprite to stop doing damage, so only the projectile does the damge
            Item.knockBack = 2;  //The knockback stat of your Weapon.      
            Item.value = 14000; // How much the Item is worth, in copper coins, when you sell it to a merchant. It costs 1/5th of this to buy it back from them. An easy way to remember the value is platinum, gold, silver, copper or PPGGSSCC (so this Item price is 10gold)
            Item.rare = 4;   //The color the title of your Weapon when hovering over it ingame
            Item.mana = 12;//How many mana this weapon use
            Item.UseSound = SoundID.Item88;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<SoulStaffShard>();
            Item.shootSpeed = 30f;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod.Find<ModItem>("BarofSouls").Type, 15);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
        int Spin;
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            velocity = new Vector2(0f, Item.shootSpeed);
            Spin += 15;
            position = Main.MouseWorld;
            int projCount = Item.rare+2;
            Vector2 helperVector = new Vector2(0, 100f).RotatedBy(MathHelper.ToRadians(Spin));

            for (int i = 1; i < projCount+1; i++)
            {
                Vector2 offset = helperVector.RotatedBy(MathHelper.ToRadians(i*(360/projCount)));


                Vector2 newPosition = position + offset;
                Projectile.NewProjectileDirect(source, newPosition, velocity, type, damage, knockback, player.whoAmI);  // 1 is up


            }

            return false; // Return false because we don't want tModLoader to shoot projectile
        }

    }
}