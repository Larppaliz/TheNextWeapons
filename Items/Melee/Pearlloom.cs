using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items.Melee
{
    public class Pearlloom : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Pearlloom");
            // Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.damage = 90;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 54;
            Item.height = 24;
            Item.maxStack = 1;
            Item.useTime = 25;
            Item.useAnimation = 25;
            Item.useStyle = 1;
            Item.knockBack = 2;
            Item.value = Item.buyPrice(gold: 25);
            Item.rare = 8;
            Item.UseSound = SoundID.Item1;
            Item.noMelee = false;
            Item.scale = 1.0f;
            Item.crit = 15;
            Item.autoReuse = true;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(ItemID.PearlwoodSword, 1);
            recipe.AddIngredient(ItemID.PixieDust, 8);
            recipe.AddIngredient(ItemID.UnicornHorn, 1);
            recipe.AddIngredient(ItemID.SoulofLight, 5);
            recipe.AddIngredient(ItemID.LightShard, 1);
            recipe.AddIngredient(ItemID.SoulofMight, 2);
            recipe.AddIngredient(ItemID.SoulofSight, 2);
            recipe.AddIngredient(ItemID.SoulofFright, 2);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }

        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {

            if (hit.Crit) 
            {
                if (!player.HasBuff(ModContent.BuffType<Buffs.EnchantedShield>()))
                {
                    Projectile.NewProjectileDirect(player.GetSource_FromThis(), player.Center, player.velocity, ModContent.ProjectileType<Projectiles.enchanted>(), damageDone/2, 15f, player.whoAmI);
                }
                player.AddBuff(ModContent.BuffType<Buffs.EnchantedShield>(), 2500);
            }
        }
        public override Color? GetAlpha(Color lightColor) => new Color(255, 255, 255, 200);
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            for (int i = 1; i < 2; i++)
            {
                int k = Main.rand.Next(6);
                Vector2 pos = (Vector2)player.HandPosition + new Vector2(0f, (k + 5) * Item.width / 8f).RotatedBy(player.itemRotation + MathHelper.ToRadians(player.direction * 220));
                Dust dust;
                dust = Main.dust[Terraria.Dust.NewDust(pos, 0, 0, DustID.MagicMirror, 0f, 0f, 0, new Color(175, 200, 255, 0), 1.5f)];
                dust.velocity.Y -= 2f;
                dust.noGravity = true;
                dust.fadeIn = 0.2f / i;
            }
        }
    }
}