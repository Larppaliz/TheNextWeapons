using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items
{
public class gun : ModItem
	{
	public override void SetStaticDefaults()
	{
DisplayName.SetDefault("Scanedium Dualshot");
Tooltip.SetDefault("");
}
public override void SetDefaults()
{
item.damage = 12;
item.ranged = true;
item.width = 54;
item.height = 24;
item.maxStack = 1;
item.useTime = 20;
item.useAnimation = 20;
item.useStyle = 5;
item.knockBack = 2;
item.value = 30000;
item.rare = 3;
item.UseSound = SoundID.Item11;
item.noMelee = true;
item.shoot = 14;
item.shootSpeed = 8f;
item.autoReuse = true;
item.useAmmo = 97;
}

public override void AddRecipes()
{
ModRecipe recipe = new ModRecipe(mod);
recipe.AddIngredient(mod.ItemType("bar"), 14);
recipe.AddTile(TileID.Anvils);
recipe.SetResult(this,1);
recipe.AddRecipe();

        }

        public static Vector2[] randomSpread(float speedX, float speedY, int angle, int num)
        {
            var posArray = new Vector2[num];
            float spread = (float)(angle * 0.015);
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
            Vector2[] speeds = randomSpread(speedX, speedY, 8, 8);
            for (int i = 0; i < 2; ++i)
            {
                Projectile.NewProjectile(position.X, position.Y, speeds[i].X, speeds[i].Y, type, damage, knockBack, player.whoAmI);
            }
            return false;
        }
    }
}