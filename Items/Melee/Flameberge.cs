using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using TheNextWeapons.Buffs;

namespace TheNextWeapons.Items.Melee
{
    public class Flameberge : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 37;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 54;
            Item.height = 58;
            Item.maxStack = 1;
            Item.useTime = 21;
            Item.useAnimation = 21;
            Item.useStyle = 1;
            Item.knockBack = 8;
            Item.value = Item.buyPrice(gold: 5);
            Item.rare = 4;
            Item.shootSpeed = 15f;
            Item.UseSound = SoundID.Item1;
            Item.noMelee = false;
            Item.scale = 1.1f;
            Item.crit = 12;
            Item.autoReuse = true;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(ItemID.AshWoodSword, 1);
            recipe.AddIngredient(ItemID.Torch, 8);
            recipe.AddIngredient(ItemID.PalladiumBar, 4);
            recipe.AddIngredient(ItemID.HellstoneBar, 4);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();

            Recipe recipe2 = CreateRecipe(1);
            recipe2.AddIngredient(ItemID.AshWoodSword, 1);
            recipe2.AddIngredient(ItemID.Torch, 8);
            recipe2.AddIngredient(ItemID.CobaltBar, 4);
            recipe2.AddIngredient(ItemID.HellstoneBar, 4);
            recipe2.AddTile(TileID.WorkBenches);
            recipe2.Register();
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            int[] dustIDs = new int[] { DustID.CrimsonTorch, DustID.RedTorch };
            for (int i = 0; i < 3; i++)
            {
                Vector2 pos = (Vector2)player.HandPosition + new Vector2(0f, (Item.width + Item.height) / Main.rand.NextFloat(1.4f, 3f)).RotatedBy(player.itemRotation+MathHelper.ToRadians(player.direction*220));
                int dustID = dustIDs[Main.rand.Next(dustIDs.Length)];
                Dust dust;
                dust = Main.dust[Terraria.Dust.NewDust(pos, 0, 0, dustID, 0f, 0f, 0, new Color(255, 0, 255, 255), 2f)];
                dust.noGravity = true;
                dust.fadeIn = 1f;
            }
        }
        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
                target.AddBuff(ModContent.BuffType<Red_Fire>(), 401);
        }
        public override Color? GetAlpha(Color lightColor) => new Color(255, 255, 255, 200);
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
        }
    }
}