using Terraria;
using Terraria.GameContent.Biomes;
using Terraria.ID;
using Terraria.ModLoader;
using TheNextWeapons.Items.Melee.Gems;
using TheNextWeapons.Projectiles.Shortswords;

namespace TheNextWeapons.Items.Melee
{
    public class Duneblade : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Desert Blade");
            // Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.damage = 30;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 32;
            Item.height = 32;
            Item.scale = 1.0f;
            Item.maxStack = 1;
            Item.useTime = 22;
            Item.useAnimation = 22;
            Item.knockBack = 4f;
            Item.autoReuse = true;
            Item.UseSound = SoundID.Item1;
            Item.noMelee = false;
            Item.noUseGraphic = false;
            Item.useTurn = true;
            Item.useStyle = 1;
            Item.value = 0;
            Item.rare = 2;
            Item.shootSpeed = 2.4f;
        }

        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (hit.Crit)
            {
                target.AddBuff(ModContent.BuffType<Buffs.DesertsCurse>(), 300);
            }
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.AntlionClaw, 1);
            recipe.AddIngredient(ItemID.Cactus, 20);
            recipe.AddIngredient(ItemID.AntlionMandible, 6);
            recipe.AddIngredient(ItemID.PinkPricklyPear, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}