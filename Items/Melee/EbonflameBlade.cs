using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items.Melee
{
    public class EbonflameBlade : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 45;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 54;
            Item.height = 58;
            Item.maxStack = 1;
            Item.useTime = 32;
            Item.useAnimation = 32;
            Item.useStyle = 1;
            Item.knockBack = 8;
            Item.value = Item.buyPrice(gold: 15);
            Item.rare = 4;
            Item.shootSpeed = 15f;
            Item.UseSound = SoundID.Item1;
            Item.noMelee = false;
            Item.scale = 1.2f;
            Item.crit = 12;
            Item.autoReuse = true;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(ItemID.EbonwoodSword, 1);
            recipe.AddIngredient(ItemID.CursedFlame, 8);
            recipe.AddIngredient(ItemID.SoulofNight, 5);
            recipe.AddIngredient(ItemID.DarkShard, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            for (int i = 1; i < 3; i++)
            {
                int k = Main.rand.Next(6);
                Vector2 pos = (Vector2)player.HandPosition + new Vector2(0f, (k+3)*Item.width/4.5f).RotatedBy(player.itemRotation + MathHelper.ToRadians(player.direction * 220));
                Dust dust;
                dust = Main.dust[Terraria.Dust.NewDust(pos, 0, 0, DustID.CursedTorch, 0f, 0f, 0, new Color(0, 255, 0, 255), 2.5f)];
                dust.velocity.Y -= 2f;
                dust.noGravity = true;
                dust.fadeIn = 1.5f / i;
                if (Item.rare < 20)
                {
                    if (Main.rand.NextBool(30 - Item.rare*2))
                    {
                        Projectile.NewProjectileDirect(player.GetSource_FromThis(), dust.position, new Vector2(player.direction * 3, -1), ModContent.ProjectileType<Projectiles.CursedFlame>(), Item.damage / 2, 0f, player.whoAmI);
                    }
                }
                else
                {
                    Projectile.NewProjectileDirect(player.GetSource_FromThis(), dust.position, new Vector2(player.direction * 3, -1), ModContent.ProjectileType<Projectiles.CursedFlame>(), Item.damage / 2, 0f, player.whoAmI);
                }
            }
        }
        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (hit.Crit)
            {
                Projectile.NewProjectileDirect(player.GetSource_FromThis(), target.Center, new Vector2(0, -1), ModContent.ProjectileType<Projectiles.CursedFlame>(), damageDone/2, 0f, player.whoAmI);
            }
        }
        public override Color? GetAlpha(Color lightColor) => new Color(255, 255, 255, 200);
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            /*
            Texture2D texture = TextureAssets.Item[Item.type].Value;
            Rectangle hitbox = Item.getRect();
            Vector2 drawOrigin = new Vector2(texture.Width * 0.5f, texture.Height * 0.5f);
            Color color = Color.White;
            Main.EntitySpriteDraw(texture, Item.position, hitbox, color, 0f, drawOrigin, Item.scale, SpriteEffects.None, 0);
            */
        }
    }
}