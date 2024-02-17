using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items.Melee
{
    public class IchorwhisperClaymore : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Ichor Sword");
            // Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.damage = 40;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 54;
            Item.height = 24;
            Item.maxStack = 1;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = 1;
            Item.knockBack = 12;
            Item.value = Item.buyPrice(gold: 15);
            Item.rare = 4;
            Item.UseSound = SoundID.Item1;
            Item.noMelee = false;
            Item.scale = 1.3f;
            Item.crit = 10;
            Item.autoReuse = true;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(ItemID.ShadewoodSword, 1);
            recipe.AddIngredient(ItemID.Ichor, 8);
            recipe.AddIngredient(ItemID.SoulofNight, 5);
            recipe.AddIngredient(ItemID.DarkShard, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
        public override Color? GetAlpha(Color lightColor) => new Color(255, 255, 255, 200);
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            for (int i = 1; i < 2; i++)
            {
                int k = Main.rand.Next(6);
                Vector2 pos = (Vector2)player.HandPosition + new Vector2(0f, (k + 3) * Item.width / 4.5f).RotatedBy(player.itemRotation + MathHelper.ToRadians(player.direction * 220));
                Dust dust;
                dust = Main.dust[Terraria.Dust.NewDust(pos, 0, 0, DustID.Ichor, 0f, 0f, 0, default(Color), 1f)];
                dust.velocity.Y -= 2f;
                dust.noGravity = true;
                dust.fadeIn = 0.2f / i;
            }
        }
        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(BuffID.Ichor, 60);
            if (hit.Crit && target.type != NPCID.TargetDummy)
            {
                SoundEngine.PlaySound(SoundID.DD2_ExplosiveTrapExplode);
                for (int i = 0; i < 12; i++)
                {
                    Vector2 velocity = new Vector2(Main.rand.NextFloat(-4f, 4f), Main.rand.NextFloat(-4f, 4f));
                    int dust2 = Dust.NewDust(target.Center, 0, 0, DustID.Ichor, velocity.X, velocity.Y, 0, default(Color), 2.5f);
                    Main.dust[dust2].noGravity = true;
                    Main.dust[dust2].noLightEmittence = true;
                    Main.dust[dust2].noLight = false;
                    Main.dust[dust2].fadeIn = 2f;
                }
                Projectile.NewProjectileDirect(player.GetSource_FromThis(), target.Center, new Vector2(Main.rand.NextFloat(-15f, 15f), -15f), ModContent.ProjectileType<Projectiles.IchorBlast>(), damageDone, 3, player.whoAmI);
            }
        }
    }
}