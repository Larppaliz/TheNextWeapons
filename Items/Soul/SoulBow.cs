using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TheNextWeapons.Projectiles;

namespace TheNextWeapons.Items.Soul        //We need this to basically indicate the folder where it is to be read from, so you the texture will load correctly
{
    public class SoulBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Soul Bow");
            // Tooltip.SetDefault("Every 5th shot shoots a soul arrow that deals double damage");
        }
        public override void SetDefaults()
        {
            Item.damage = 45;   //The damage stat for the Weapon.                       
            Item.DamageType = DamageClass.Ranged;   //This defines if it does magic damage and if its effected by magic increasing Armor/Accessories.
            Item.width = 24;      //The size of the width of the hitbox in pixels.
            Item.height = 28;      //The size of the height of the hitbox in pixels.
            Item.useTime = 17;     //How fast the Weapon is used.
            Item.useAnimation = 17;    //How long the Weapon is used for.
            Item.useStyle = 5;         //The way your Weapon will be used, 5 is the Holding Out Used for: Guns, Spellbooks, Drills, Chainsaws, Flails, Spears for example
            Item.noMelee = true;     //Setting to True allows the weapon sprite to stop doing damage, so only the projectile does the damge
            Item.knockBack = 2;  //The knockback stat of your Weapon.      
            Item.value = 9000; // How much the Item is worth, in copper coins, when you sell it to a merchant. It costs 1/5th of this to buy it back from them. An easy way to remember the value is platinum, gold, silver, copper or PPGGSSCC (so this Item price is 10gold)
            Item.rare = 4;   //The color the title of your Weapon when hovering over it ingame
            Item.UseSound = SoundID.Item5;
            Item.autoReuse = true;
            Item.shoot = 1;
            Item.useAmmo = 40;
            Item.shootSpeed = 18f;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod.Find<ModItem>("BarofSouls").Type, 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
        int shot;
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (shot > 3)
            {
                SoundEngine.PlaySound(SoundID.DD2_BallistaTowerShot);
                type = ModContent.ProjectileType<Projectiles.SoulArrow>();
                shot = 0;
                for (int i = 0; i < 12; i++)
                {
                    int dust = Dust.NewDust(position + (velocity*1.1f), 1, 1, DustID.CrystalPulse2, 0f, 0f, 0, default(Color), 1+(i/10)*2);;
                    Main.dust[dust].noGravity = true;
                }
            }
            else { shot += 1; }
            Projectile.NewProjectileDirect(source, position, velocity, type, damage, knockback, player.whoAmI);
            return false;
        }
        public override Vector2? HoldoutOffset()
        {
            Vector2 offset = new Vector2(0, 0);
            return offset;
        }
    }
}