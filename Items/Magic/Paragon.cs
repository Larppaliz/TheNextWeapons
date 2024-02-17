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
    public class Paragon : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Paragon");
            /* Tooltip.SetDefault("Right click to change mode\n" +
                "[c/eeaa33:UNOBTAIANBLE]"); */
            Item.staff[Item.type] = true;
        }
        public static int maxProjectiles;
        int Projectiles;
        public static int mode = -1;
        public override void SetDefaults()
        {
            Item.damage = 285;
            Item.DamageType = DamageClass.Magic;
            Item.width = 22;
            Item.height = 22;
            Item.useTime = 36;
            Item.useAnimation = 36;
            Item.useStyle = 13;
            Item.maxStack = 1;
            Item.consumable = false;
            Item.noMelee = true;
            Item.knockBack = 6;
            Item.value = 1000000;
            Item.shoot = Mod.Find<ModProjectile>("AnotherZenith").Type;
            Item.rare = ModContent.RarityType<CustomRarity.UnobtainableRarity>();
            Item.scale = 1.0f;
            Item.UseSound = SoundID.Item8;
            Item.autoReuse = true;
            Item.noUseGraphic = true; // this defines if it does not use graphic
            Item.shootSpeed = 25f;
            Item.channel = true;
        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                Item.shoot = 0;
                mode += 1;
                if (mode > 11)
                {
                    mode = -1;
                }
                if (mode == -1)
                {
                    Main.NewText("Mode Set to: Random");
                }
                if (mode == 0)
                {
                    Main.NewText("Mode Set to: Thunder Zapper");
                }
                if (mode == 1)
                {
                    Main.NewText("Mode Set to: Frost Staff");
                }
                if (mode == 2)
                {
                    Main.NewText("Mode Set to: Staff of Earth");
                }
                if (mode == 3)
                {
                    Main.NewText("Mode Set to: Inferno Fork");
                }
                if (mode == 4)
                {
                    Main.NewText("Mode Set to: Spectre Staff");
                }
                if (mode == 5)
                {
                    Main.NewText("Mode Set to: Shadowbeam Staff");
                }
                if (mode == 6)
                {
                    Main.NewText("Mode Set to: Sky Fracture");
                }
                if (mode == 7)
                {
                    Main.NewText("Mode Set to: Bat Scepter");
                }
                if (mode == 8)
                {
                    Main.NewText("Mode Set to: Nettle Burst");
                }
                if (mode == 9)
                {
                    Main.NewText("Mode Set to: Tome of Infinite Wisdom");
                }
                if (mode == 10)
                {
                    Main.NewText("Mode Set to: Unholy Trident");
                }
                if (mode == 11)
                {
                    Main.NewText("Mode Set to: Crystal Serpent");
                }
            }
            else
            {
                Item.shoot = Mod.Find<ModProjectile>("AnotherZenith").Type;
            }
            return base.CanUseItem(player);
        }
        public override void UpdateInventory(Player player)
        {
            if (player.channel == false) { Projectiles = maxProjectiles; }
            Item.useAnimation = Item.useTime;
            maxProjectiles = 180 / Item.useTime;
            if (Projectiles == 0)
            {
                Item.useTime = 1;
                Item.UseSound = null;
            }
            else
            {
                Item.useTime = 36;
                Item.UseSound = SoundID.Item8;
            }
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
                if (player.channel == true & Projectiles > 0) { Projectiles -= 1; velocity *= 0; position = player.Center; Projectile.NewProjectileDirect(source, position, velocity, type, damage, knockback, player.whoAmI); }
                return false;
        }
    }
}
