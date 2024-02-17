using System.Numerics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items.Melee
{
    public class Scarlet : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Scarlet");
            // Tooltip.SetDefault("Swing to deal more damage");
        }
        public override void SetDefaults()
        {
            Item.damage = 21;
            Item.DamageType = DamageClass.Melee;
            Item.width = 54;
            Item.height = 24;
            Item.maxStack = 1;
            Item.useTime = 10;
            Item.useAnimation = 40;
            Item.useStyle = 5;
            Item.noUseGraphic = true;
            Item.knockBack = 7f;
            Item.value = Item.buyPrice(gold: 1, silver: 50);
            Item.rare = 2;
            Item.shoot = ModContent.ProjectileType<Projectiles.Scarlet>();
            Item.shootSpeed = 0.001f;
            Item.channel = true;
            Item.noMelee = true;
            Item.scale = 1.0f;
            Item.crit = 2;
            Item.autoReuse = true;
        }
        bool projectile = true;
        int timerwait;
        public override void UpdateInventory(Player player)
        {
            timerwait--;
            if (!player.channel && timerwait <= 0)
            {
                projectile = true;
            }
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Microsoft.Xna.Framework.Vector2 position, Microsoft.Xna.Framework.Vector2 velocity, int type, int damage, float knockback)
        {
            if (projectile)
            {
                timerwait = Item.useAnimation;
                projectile = false;
                return true;
            }
            return false;
        }
    }
}