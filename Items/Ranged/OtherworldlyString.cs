using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using System;


namespace TheNextWeapons.Items.Ranged        //We need this to basically indicate the folder where it is to be read from, so you the texture will load correctly
{
    public class OtherworldlyString : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Otherworldly String");
            // Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.damage = 30;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 24;
            Item.height = 28;
            Item.useTime = 22;
            Item.useAnimation = 22;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 5;
            Item.value = 100000;
            Item.rare = 5;
            Item.crit = 10;
            Item.scale = 1.0f;
            Item.useAmmo = 40;
            Item.UseSound = SoundID.Item5;
            Item.autoReuse = true;
            Item.shoot = ProjectileID.WoodenArrowFriendly;
            Item.shootSpeed = 5f;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.DemoniteBar, 10);
            recipe.AddIngredient(ItemID.CursedFlame, 6);
            recipe.AddIngredient(ItemID.CrimtaneBar, 10);
            recipe.AddIngredient(ItemID.Ichor, 6);
            recipe.AddIngredient(ItemID.SoulofNight, 10);
            recipe.AddTile(TileID.MythrilAnvil);
        }
        int shot = 1;
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Projectile proj = Projectile.NewProjectileDirect(source, position, velocity, type, damage, knockback, player.whoAmI);
            if (type != ProjectileID.MoonlordArrow)
            {
                proj.extraUpdates += 3;
                proj.ai[2] = 1.12345f;
            }
            return false;
        }

        public void AIExtra()
        {

        }
        public override Vector2? HoldoutOffset()
        {
            Vector2 offset = new Vector2(5 , 0); ;
            return offset;
        }

    }
}