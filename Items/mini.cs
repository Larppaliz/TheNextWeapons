using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items
{
public class mini : ModItem
	{
	public override void SetStaticDefaults()
	{
	DisplayName.SetDefault("Power Shark");
	Tooltip.SetDefault("");
	}
	public override void SetDefaults()
	{
            item.damage = 6;
            item.ranged = true;
            item.width = 22;
            item.height = 22;
            item.useTime = 4;
            item.useAnimation = 4;
            item.useStyle = 5;
	    item.maxStack = 1;
            item.consumable = false;
            item.noMelee = true;
            item.knockBack = 1;
            item.value = 100000;
	    item.shoot = 14;
            item.rare = 7;
            item.scale = 1.0f;
            item.useAmmo = 97;
	    item.UseSound = SoundID.Item11;
            item.autoReuse = true;
            item.noUseGraphic = false; // this defines if it does not use graphic
            item.shootSpeed = 12f;
}

public override void AddRecipes()
{
ModRecipe recipe = new ModRecipe(mod);
recipe.AddRecipeGroup("IronBar", 15);
 //recipe.AddIngredient(ItemID.CrystalBlood, 15);
recipe.AddIngredient(ItemID.IllegalGunParts, 1);
recipe.AddIngredient(ItemID.Minishark, 1);
recipe.AddTile(TileID.Anvils);
recipe.SetResult(this,1);
recipe.AddRecipe();

        }

        public static Vector2[] randomSpread(float speedX, float speedY, int angle, int num)
        {
            var posArray = new Vector2[num];
            float spread = (float)(angle * 0.06);
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
            for (int i = 0; i < 1; ++i)
            {
                Projectile.NewProjectile(position.X, position.Y, speeds[i].X, speeds[i].Y, type, damage, knockBack, player.whoAmI);
            }
            return false;
        }
    }
}