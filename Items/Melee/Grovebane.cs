using Microsoft.Xna.Framework;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items.Melee
{
    public class Grovebane : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Grovebane");
            // Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.damage = 11;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 54;
            Item.height = 24;
            Item.maxStack = 1;
            Item.useTime = 16;
            Item.useAnimation = 16;
            Item.useStyle = 1;
            Item.knockBack = 4;
            Item.value = Item.buyPrice(silver: 3, copper: 50);
            Item.rare = 0;
            Item.shoot = ModContent.ProjectileType<Projectiles.LeafSlash>();
            Item.shootSpeed = Item.scale * 6.5f;
            Item.UseSound = SoundID.Item1;
            Item.noMelee = false;
            Item.scale = 1.0f;
            Item.crit = 5;
            Item.autoReuse = true;

        }

        public override void PostReforge()
        {
            Item.shootSpeed = Item.scale * 6.5f;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(ItemID.WoodenSword, 1);
            recipe.AddIngredient(ItemID.Acorn, 10);
            recipe.AddIngredient(ItemID.LeafWand, 1);
            recipe.AddIngredient(ItemID.Sunflower, 1);
            recipe.AddIngredient(ModContent.ItemType<Items.Melee.OldWoodSword>(), 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();

            Recipe recipe2 = CreateRecipe(1);
            recipe2.AddIngredient(ItemID.WoodenSword, 1);
            recipe2.AddIngredient(ItemID.Acorn, 10);
            recipe2.AddIngredient(ItemID.LivingWoodWand, 1);
            recipe2.AddIngredient(ItemID.Sunflower, 1);
            recipe2.AddIngredient(ModContent.ItemType<Items.Melee.OldWoodSword>(), 1);
            recipe2.AddTile(TileID.WorkBenches);
            recipe2.Register();

        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.NextFloat() < 0.1f)
            {
                Dust dust;
                dust = Main.dust[Terraria.Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Grass, 0f, 0f, 99, default(Color), 1f)];
                dust.noGravity = true;
                dust.fadeIn = 1.5f;
            }
        }
    }
}