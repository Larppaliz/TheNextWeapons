using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items.Melee
{
    public class SteelBroadsword : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Steel Broadsword");
            // Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.damage = 15;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 54;
            Item.height = 24;
            Item.maxStack = 1;
            Item.useTime = 23;
            Item.useAnimation = 23;
            Item.useStyle = 1;
            Item.knockBack = 4;
            Item.value = Item.buyPrice(gold: 9, silver: 50);
            Item.rare = 1;
            Item.UseSound = SoundID.Item1;
            Item.noMelee = false;
            Item.scale = 1.0f;
            Item.crit = 10;
            Item.autoReuse = true;
        }
    }
}