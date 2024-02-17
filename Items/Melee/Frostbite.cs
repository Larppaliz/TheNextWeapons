using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items.Melee
{
    public class Frostbite : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Frostbite");
            // Tooltip.SetDefault("Chance to freeze enemies for 2s");
        }
        public override void SetDefaults()
        {
            Item.damage = 16;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 54;
            Item.height = 24;
            Item.maxStack = 1;
            Item.useTime = 23;
            Item.useAnimation = 23;
            Item.useStyle = 1;
            Item.knockBack = 6;
            Item.value = Item.buyPrice(silver: 5);
            Item.rare = 0;
            Item.UseSound = SoundID.Item1;
            Item.noMelee = false;
            Item.scale = 1.0f;
            Item.crit = 0;
            Item.autoReuse = true;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(ItemID.BorealWoodSword, 1);
            recipe.AddIngredient(ItemID.FlinxFur, 10);
            recipe.AddIngredient(ItemID.Shiverthorn, 2);
            recipe.AddIngredient(ModContent.ItemType<Items.Melee.OldWoodSword>(), 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.NextFloat() < 0.1f)
            {
                Dust dust;
                dust = Main.dust[Terraria.Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.IceRod, 0f, 0f, 0, new Color(255, 255, 255), 1f)];
                dust.noLight = true;
                dust.noGravity = true;
                dust.fadeIn = 1.5f;
            }
        }

        public override void ModifyHitNPC(Player player, NPC target, ref NPC.HitModifiers modifiers)
        {
            if (Main.rand.NextBool(4) && !target.HasBuff(ModContent.BuffType<Buffs.Frozen>()))
            {
                modifiers.FinalDamage += 0.2f;
                SoundEngine.PlaySound(SoundID.DeerclopsIceAttack);
                for (int i = 0; i < 4; i++)
            {
                Dust dust;
                dust = Main.dust[Terraria.Dust.NewDust(target.position, target.width, target.height, DustID.IceRod, 0f, -5f, 0, new Color(255, 255, 255), 1f)];
                dust.noLight = true;
                dust.noGravity = false;
                dust.fadeIn = 1f;
            }
                target.AddBuff(ModContent.BuffType<Buffs.Frozen>(), 120);
            }
        }
    }
}