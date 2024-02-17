using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items.Soul
{
    public class SoulSaber : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Soul Saber");
            // Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.damage = 39;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 54;
            Item.height = 24;
            Item.maxStack = 1;
            Item.useTime = 12;
            Item.useAnimation = 12;
            Item.useStyle = 1;
            Item.knockBack = 5;
            Item.value = 12000;
            Item.rare = 4;
            Item.shootSpeed = 9f;
            Item.UseSound = SoundID.Item1;
            Item.noMelee = false;
            Item.scale = 1.2f;
            Item.crit = 8;
            Item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod.Find<ModItem>("BarofSouls").Type, 15);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}