using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using TheNextWeapons.Projectiles;

namespace TheNextWeapons.Items.Magic
{
    public class EarthStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Ground Staff");
            // Tooltip.SetDefault("Hold down to create earth pieces that float around you and release to launch them");
            Item.staff[Item.type] = true;
        }
        bool channelthing;
        int OriginalManaUse = 60;
        public override void SetDefaults()
        {
            Item.damage = 98;
            Item.mana = 60;
            Item.DamageType = DamageClass.Magic;
            Item.width = 22;
            Item.height = 22;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.reuseDelay = 40;
            Item.useStyle = 5;
            Item.maxStack = 1;
            Item.consumable = false;
            Item.noMelee = true;
            Item.knockBack = 10;
            Item.value = 1000000;
            Item.shoot = ModContent.ProjectileType<Earth>();
            Item.rare = 6;
            Item.scale = 1.0f;
            Item.UseSound = SoundID.Item8;
            Item.autoReuse = true;
            Item.noUseGraphic = true; // this defines if it does not use graphic
            Item.shootSpeed = 14f;
            Item.channel = true;
        }
        public override void PostReforge()
        {
            OriginalManaUse = Item.mana;
        }

        public override void HoldItem(Player player)
        {
            if (!player.channel)
            {
                Item.mana = OriginalManaUse;
                Item.reuseDelay = 40;
                channelthing = true;
            }
            else
            {
                Item.reuseDelay = 0;
                Item.mana = 4;
            }
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (channelthing)
            {
                for (int i = 0; i < 5; i++)
                {
                    Projectile proj = Projectile.NewProjectileDirect(source, position, new Vector2(0, 0), type, damage, knockback, player.whoAmI);
                    proj.ai[0] = i;
                }
                Projectile.NewProjectileDirect(source, position, new Vector2(0, 0), ModContent.ProjectileType<GroundStaff>(), damage, knockback, player.whoAmI);
                channelthing = false;
            }
            return false;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(ItemID.StaffofEarth, 1);
            recipe.AddIngredient(Mod.Find<ModItem>("SodaliteBar").Type, 25);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 10);
            recipe.AddIngredient(ItemID.SoulofFlight, 5);
            recipe.AddIngredient(ItemID.Obsidian, 50);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();

        }
    }
}
