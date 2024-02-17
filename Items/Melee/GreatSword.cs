using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items.Melee
{
    public class GreatSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("The Great Greatsword");
            /* Tooltip.SetDefault("How did a weird wooden sword, some ancient stone sword and the rustiest sword in history turn into this?\n" 
                + "Benefits more from prefixes\n" +
                "Crits lower enemy defense and slows them down for a little bit"); */
        }
        public override void SetDefaults()
        {
            Item.damage = 72;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 54;
            Item.height = 24;
            Item.maxStack = 1;
            Item.useTime = 48;
            Item.useAnimation = 48;
            Item.useStyle = 1;
            Item.knockBack = 9;
            Item.value = Item.sellPrice(gold: 10);
            Item.rare = 4;
            Item.UseSound = SoundID.Item1;
            Item.noMelee = false;
            Item.scale = 1.25f;
            Item.crit = 17;
            Item.autoReuse = true;
        }
        bool prefixbonus = true;
        public override void PostReforge()
        {
            Item.damage += 6;
            Item.useTime -= 3;
            Item.useAnimation -= 3;
            prefixbonus = false;
        }

        public override void UpdateInventory(Player player)
        {
            if (prefixbonus)
            {
                if (Item.prefix > 0)
                {
                    Item.damage += 6;
                    Item.useTime -= 3;
                    Item.useAnimation -= 3;
                    prefixbonus = false;
                }
            }
        }

        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (hit.Crit)
            {
                target.AddBuff(ModContent.BuffType<Buffs.Injured>(), 80);
            }
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(ModContent.ItemType<FixedSword>(), 1);
            recipe.AddIngredient(ModContent.ItemType<StoneSword>(), 1);
            recipe.AddIngredient(ModContent.ItemType<RustedBlade>(), 1);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.Register();
        }
    }
}