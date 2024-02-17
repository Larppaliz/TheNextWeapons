using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Exceptions;

namespace TheNextWeapons.Items.Melee
{
    public class Stingblade : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Stingblade");
            // Tooltip.SetDefault("Can poison enemies and releases spores on crit");
        }
        public override void SetDefaults()
        {
            Item.damage = 12;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 54;
            Item.height = 24;
            Item.maxStack = 1;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = 1;
            Item.knockBack = 3;
            Item.value = 0;
            Item.rare = 2;
            Item.UseSound = SoundID.Item1;
            Item.noMelee = false;
            Item.scale = 1.0f;
            Item.crit = 12;
            Item.autoReuse = true;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(ItemID.RichMahoganySword, 1);
            recipe.AddIngredient(ItemID.BambooBlock, 15);
            recipe.AddIngredient(ItemID.LivingMahoganyWand, 1);
            recipe.AddIngredient(ItemID.JungleRose, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();

            Recipe recipe2 = CreateRecipe(1);
            recipe2.AddIngredient(ItemID.RichMahoganySword, 1);
            recipe2.AddIngredient(ItemID.BambooBlock, 15);
            recipe2.AddIngredient(ItemID.LivingMahoganyLeafWand, 1);
            recipe2.AddIngredient(ItemID.JungleRose, 1);
            recipe2.AddTile(TileID.WorkBenches);
            recipe2.Register();
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.NextBool(3))
            {
                Dust dust;
                dust = Main.dust[Terraria.Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Poisoned, 0f, 0f, 200, default(Color), 1f)];
                dust.noGravity = true;
                dust.fadeIn = 1.5f;
            }
        }
        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (hit.Crit)
            {
                target.AddBuff(BuffID.Venom, 60, true);
            }
            else
            {
                if (Main.rand.NextBool(4))
                {
                    target.AddBuff(BuffID.Poisoned, 90, true);
                }
            }
        }
    }
}