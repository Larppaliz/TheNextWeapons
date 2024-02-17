using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items.Radium
{
    public class RadiumArrow : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Radium Arrow");
            // Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.damage = 12;    //The damage stat for the Weapon.
            Item.DamageType = DamageClass.Ranged;  //This defines if it does Ranged damage and if its effected by Ranged increasing Armor/Accessories.
            Item.width = 8;  //The size of the width of the hitbox in pixels.
            Item.height = 8;   //The size of the height of the hitbox in pixels.
            Item.maxStack = 999; //This defines the Items max stack
            Item.consumable = true;  //Tells the game that this should be used up once fired
            Item.knockBack = 1.5f;  //Added with the weapon's knockback
            Item.value = 70;
            Item.rare = 3;
            Item.shoot = Mod.Find<ModProjectile>("RadiumArrow").Type;
            Item.shootSpeed = 2f;
            Item.ammo = 40;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(50);
            recipe.AddIngredient(Mod.Find<ModItem>("RadiumBar").Type, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}