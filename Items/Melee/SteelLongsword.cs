using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items.Melee
{
    public class SteelLongsword : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Steel Longsword");
            // Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.damage = 28;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 54;
            Item.height = 24;
            Item.maxStack = 1;
            Item.useTime = 38;
            Item.useAnimation = 38;
            Item.useStyle = 1;
            Item.knockBack = 9;
            Item.value = Item.buyPrice(gold: 10);
            Item.rare = 1;
            Item.UseSound = SoundID.Item1;
            Item.noMelee = false;
            Item.scale = 1.2f;
            Item.crit = 12;
            Item.autoReuse = true;
        }
    }
}