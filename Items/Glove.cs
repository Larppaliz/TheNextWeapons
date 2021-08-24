using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items
{
public class Glove : ModItem
	{
	public override void SetStaticDefaults()
	{
	DisplayName.SetDefault("Spitfire Glove");
	Tooltip.SetDefault("");
	}
	public override void SetDefaults()
	{
            item.damage = 26;
            item.melee = true;
            item.width = 40;
            item.height = 20;
            item.useTime = 16;
            item.useAnimation = 8;
            item.useStyle = 1;
            item.noMelee = false;
            item.knockBack = 7;
            item.value = 10000;
            item.rare = 2;
            item.scale = 1.5f;
	    item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = 504;
            item.shootSpeed = 7f;
}

public override void AddRecipes()
{
ModRecipe recipe = new ModRecipe(mod);
recipe.AddIngredient(ItemID.HellstoneBar, 8);
recipe.AddIngredient(mod.ItemType("fire"), 15);
recipe.AddIngredient(ItemID.BladedGlove, 1);
recipe.AddTile(TileID.Anvils);
recipe.SetResult(this,1);
recipe.AddRecipe();

recipe = new ModRecipe(mod);
recipe.AddIngredient(ItemID.IronBar, 15);
recipe.AddIngredient(ItemID.Leather, 5);
recipe.SetResult(ItemID.BladedGlove, 1);
recipe.AddTile(TileID.Anvils);
recipe.AddRecipe();
        }

        public static Vector2[] randomSpread(float speedX, float speedY, int angle, int num)
        {
            var posArray = new Vector2[num];
            float spread = (float)(angle * 0.037);
            float baseSpeed = (float)System.Math.Sqrt(speedX * speedX + speedY * speedY);
            double baseAngle = System.Math.Atan2(speedX, speedY);
            double randomAngle;
            for (int i = 0; i < num; ++i)
            {
                randomAngle = baseAngle + (Main.rand.NextFloat() - 0.5f) * spread;
                posArray[i] = new Vector2(baseSpeed * (float)System.Math.Sin(randomAngle), baseSpeed * (float)System.Math.Cos(randomAngle));
            }
            return (Vector2[])posArray;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2[] speeds = randomSpread(speedX, speedY, 8, 6);
            for (int i = 0; i < 5; ++i)
            {
                Projectile.NewProjectile(position.X, position.Y, speeds[i].X, speeds[i].Y, type, damage, knockBack, player.whoAmI);
            }
            return false;
        }
    }
}