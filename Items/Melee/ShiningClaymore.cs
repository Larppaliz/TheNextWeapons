using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items.Melee
{
    public class ShiningClaymore : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Shining Claymore");
            // Tooltip.SetDefault("It looks like its worth a million.");
        }
        public override void SetDefaults()
        {
            Item.damage = 84;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 54;
            Item.height = 24;
            Item.maxStack = 1;
            Item.useTime = 60;
            Item.useAnimation = 20;
            Item.useStyle = 1;
            Item.knockBack = 10;
            Item.value = Item.buyPrice(platinum: 1);
            Item.rare = 5;
            Item.shoot = Mod.Find<ModProjectile>("RainbowGemSlash").Type;
            Item.shootSpeed = 20f;
            Item.UseSound = SoundID.Item1;
            Item.noMelee = false;
            Item.scale = 1.0f;
            Item.crit = 15;
            Item.autoReuse = true;
        }
        public override bool ReforgePrice(ref int reforgePrice, ref bool canApplyDiscount)
        {
            canApplyDiscount = true;
            reforgePrice = Item.buyPrice(gold: 10);
            return base.ReforgePrice(ref reforgePrice, ref canApplyDiscount);
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod.Find<ModItem>("AmethystSword").Type, 1);
            recipe.AddIngredient(Mod.Find<ModItem>("AmberSword").Type, 1);
            recipe.AddIngredient(Mod.Find<ModItem>("TopazSword").Type, 1);
            recipe.AddIngredient(Mod.Find<ModItem>("SapphireSword").Type, 1);
            recipe.AddIngredient(Mod.Find<ModItem>("EmeraldSword").Type, 1);
            recipe.AddIngredient(Mod.Find<ModItem>("DiamondSword").Type, 1);
            recipe.AddIngredient(Mod.Find<ModItem>("RubySword").Type, 1);
            recipe.AddIngredient(ItemID.SoulofLight, 10);
            recipe.AddIngredient(ItemID.SoulofNight, 10);
            recipe.AddTile(TileID.DemonAltar);
            recipe.Register();
        }
    }
}