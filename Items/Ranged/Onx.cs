using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items.Ranged
{
    public class Onx : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Void Blaster");
            // Tooltip.SetDefault("[c/eeaa33:UNOBTAIANBLE]");
        }
        public override void SetDefaults()
        {
            Item.damage = 30;
            Item.DamageType = DamageClass.Magic;
            Item.width = 54;
            Item.height = 24;
            Item.maxStack = 1;
            Item.useTime = 9;
            Item.useAnimation = 9;
            Item.useStyle = 5;
            Item.knockBack = 6;
            Item.value = 30000;
            Item.rare = ModContent.RarityType<CustomRarity.UnobtainableRarity>();
            Item.UseSound = SoundID.Item41;
            Item.noMelee = true;
            Item.shoot = 121;
            Item.shootSpeed = 15f;
            Item.autoReuse = true;
            Item.useAmmo = 97;
            Item.scale = 0.9f;
        }
        public override Vector2? HoldoutOffset()
        {
            Vector2 offset = new Vector2(-6, -3);
            return offset;
        }
        int shot = 0;
        int soundsave = 1;
        Terraria.Audio.SoundStyle? sound;
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (soundsave == 1)
            {
                soundsave = 0;
                sound = Item.UseSound;
                shot = 0;
            }
            shot++;
            int NumProjectiles = 1; // The humber of projectiles that this gun will shoot.
            Vector2 muzzleOffset = Vector2.Normalize(velocity) * 40f;
            muzzleOffset.Y -= 8;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            if (shot > 6) { Item.reuseDelay = 5; }
            if (shot > 7) { Item.reuseDelay = 45; Item.UseSound = SoundID.Item117; }
            if (shot > 8) { NumProjectiles = 1; type = ModContent.ProjectileType<Projectiles.VoidSlash>(); shot = 0; damage *= 4; Item.reuseDelay = 0; Item.UseSound = sound; }
            for (int i = 0; i < NumProjectiles; i++)
            {
                // Rotate the velocity randomly by 30 degrees at max.
                Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(4));

                // Decrease velocity randomly for nicer visuals.
                newVelocity *= 1f - Main.rand.NextFloat(0.15f);

                // Create a projectile.
                Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
            }

            return false; // Return false because we don't want tModLoader to shoot projectile
        }
    }
}