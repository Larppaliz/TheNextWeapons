using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items
{
public class knife : ModItem
	{
	public override void SetStaticDefaults()
	{
	DisplayName.SetDefault("Scanedium Knife");
	Tooltip.SetDefault("");
	}
	public override void SetDefaults()
	{
            item.damage = 12;
            item.thrown = true;
            item.width = 22;
            item.height = 22;
            item.useTime = 15;
            item.useAnimation = 15;
            item.useStyle = 1;
	    item.maxStack = 99999;
            item.consumable = true;
            item.noMelee = true;
            item.knockBack = 1;
            item.value = 1000;
	    item.shoot = mod.ProjectileType("knife");
            item.rare = 5;
            item.scale = 1.0f;
	    item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.noUseGraphic = true; // this defines if it does not use graphic
            item.shootSpeed = 10f;
}

public override void AddRecipes()
{
ModRecipe recipe = new ModRecipe(mod);
recipe.AddIngredient(mod.ItemType("bar"), 1);
recipe.AddTile(TileID.Anvils);
recipe.SetResult(this,50);
recipe.AddRecipe();

        }

        public static Vector2[] randomSpread(float speedX, float speedY, int angle, int num)
        {
            var posArray = new Vector2[num];
            float spread = (float)(angle * 0.04);
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
            for (int i = 0; i < 3; ++i)
            {
                Projectile.NewProjectile(position.X, position.Y, speeds[i].X, speeds[i].Y, type, damage, knockBack, player.whoAmI);
            }
            return false;
        }
    }
}