using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheNextWeapons.Projectiles.Shortswords;

namespace TheNextWeapons.Items.Melee
{
    public class SteelShortsword : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Steel Shortsword");
            // Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.damage = 11;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 54;
            Item.height = 24;
            Item.maxStack = 1;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.knockBack = 1;
            Item.value = Item.buyPrice(gold: 7, silver: 50);
            Item.rare = 1;
            Item.UseSound = SoundID.Item1;
            Item.scale = 1.00f;
            Item.crit = 6;

            Item.shoot = ModContent.ProjectileType<SteelShortswordProj>(); // The projectile is what makes a shortsword work
            Item.shootSpeed = 2.1f;
            Item.useStyle = ItemUseStyleID.Rapier;
            Item.autoReuse = true;
            Item.noUseGraphic = true; // The sword is actually a "projectile", so the item should not be visible when used
            Item.noMelee = true; // The projectile will do the damage and not the item
        }
    }
}