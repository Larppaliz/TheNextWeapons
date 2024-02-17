using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items.Sodalite
{
    public class SodaliteThrowingKnife : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Sodalite Throwing Knife");
            // Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.damage = 19;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 22;
            Item.height = 22;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.useStyle = 1;
            Item.maxStack = 99999;
            Item.consumable = true;
            Item.noMelee = true;
            Item.knockBack = 1;
            Item.value = 25;
            Item.shoot = Mod.Find<ModProjectile>("knife").Type;
            Item.rare = 3;
            Item.scale = 1.0f;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.noUseGraphic = true; // this defines if it does not use graphic
            Item.shootSpeed = 13f;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(50);
            recipe.AddIngredient(Mod.Find<ModItem>("SodaliteBar").Type, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();

        }
    }
}