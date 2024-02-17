using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items.Sodalite
{
    public class SodaliteBullarang : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Sodalite Bullarang");
            // Tooltip.SetDefault("goes back to where you shot it from and goes trough walls if hitting a npc");
        }
        public override void SetDefaults()
        {
            Item.damage = 10;    //The damage stat for the Weapon.
            Item.DamageType = DamageClass.Ranged;  //This defines if it does Ranged damage and if its effected by Ranged increasing Armor/Accessories.
            Item.width = 8;  //The size of the width of the hitbox in pixels.
            Item.height = 8;   //The size of the height of the hitbox in pixels.
            Item.maxStack = 999; //This defines the Items max stack
            Item.consumable = true;  //Tells the game that this should be used up once fired
            Item.knockBack = 1.5f;  //Added with the weapon's knockback
            Item.value = 80;
            Item.rare = 3;
            Item.shoot = Mod.Find<ModProjectile>("Bullet").Type;
            Item.shootSpeed = 2f;
            Item.ammo = 97;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(50);
            recipe.AddIngredient(Mod.Find<ModItem>("SodaliteBar").Type, 1);
            recipe.AddTile(TileID.Anvils);   //this is where to craft the Item ,Anvils = all Anvils    Anvils = all anvils , MythrilAnvil = Mythril Anvil and Orichalcum Anvil, Furnaces = all furnaces , DemonAltar = Demon Altar and Crimson Altar , TinkerersWorkbench = Tinkerer's Workbench
            recipe.Register();
        }
    }
}