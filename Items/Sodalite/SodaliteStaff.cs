using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TheNextWeapons.Projectiles.Shortswords;

namespace TheNextWeapons.Items.Sodalite
{
    public class SodaliteStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Sodalite Staff");
            // Tooltip.SetDefault("Heals you when you crit");
            Item.staff[Item.type] = true;
        }
        public override void SetDefaults()
        {
            Item.damage = 15;
            Item.DamageType = DamageClass.Magic;
            Item.width = 22;
            Item.height = 22;
            Item.mana = 5;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.reuseDelay = 0;
            Item.useStyle = 5;
            Item.maxStack = 1;
            Item.consumable = false;
            Item.noMelee = true;
            Item.knockBack = 1;
            Item.value = 18000;
            Item.shoot = Mod.Find<ModProjectile>("Ore").Type;
            Item.rare = 3;
            Item.scale = 1.0f;
            Item.UseSound = SoundID.Item68;
            Item.autoReuse = true;
            Item.noUseGraphic = false; // this defines if it does not use graphic
            Item.shootSpeed = 30f;
            
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(Mod.Find<ModItem>("SodaliteBar").Type, 12);
            recipe.AddIngredient(ItemID.LifeCrystal, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
        int shot = 0;
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 muzzleOffset = Vector2.Normalize(velocity) * 50f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }

            float numberProjectiles = 5;
            float rotation = MathHelper.ToRadians(10f);
            if (shot == 1)
            {
                rotation = MathHelper.ToRadians(8.5f);
                numberProjectiles = 4;
                Item.reuseDelay = 20;
            }
            if (shot == 2)
            {
                Item.reuseDelay = 0;
                rotation = MathHelper.ToRadians(7f);
                numberProjectiles = 3;
                shot = 0;
            }
            else { shot++;}

            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1)));
                Projectile.NewProjectileDirect(source, position, perturbedSpeed, type, damage, knockback, player.whoAmI);
            }
            return false;
        }
    }
}