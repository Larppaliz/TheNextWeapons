using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items.Melee
{
    public class Tidecaller : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Tidecaller");
            // Tooltip.SetDefault("Gives extra defense, movement speed and always causes drenching Underwater");
        }
        public override void SetDefaults()
        {
            Item.damage = 14;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 54;
            Item.height = 24;
            Item.maxStack = 1;
            Item.useTime = 80;
            Item.useAnimation = 25;
            Item.useStyle = 1;
            Item.knockBack = 2;
            Item.value = Item.buyPrice(gold: 1);
            Item.rare = 1;
            Item.shoot = ModContent.ProjectileType<Projectiles.WaterShot>();
            Item.shootSpeed = 6f;
            Item.UseSound = SoundID.Item1;
            Item.noMelee = false;
            Item.scale = 1.0f;
            Item.crit = 8;
            Item.autoReuse = true;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(ItemID.PalmWoodSword, 1);
            recipe.AddIngredient(ItemID.PalmWood, 20);
            recipe.AddIngredient(ItemID.Coral, 5);
            recipe.AddIngredient(ItemID.WaterWalkingPotion, 2);
            recipe.AddIngredient(ItemID.WaterBucket, 1);
            recipe.AddIngredient(ModContent.ItemType<Items.Melee.OldWoodSword>(), 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.NextFloat() < 0.25f)
            {
                Dust dust;
                dust = Main.dust[Terraria.Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Water, 0f, 0f, 0, default(Color), 1.2f)];
                dust.noGravity = true;
                dust.fadeIn = 1.5f;
            }
        }
        public override void HoldItem(Player player)
        {
        }

        public override void ModifyHitNPC(Player player, NPC target, ref NPC.HitModifiers modifiers)
        {
        }
    }
}