using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

using TheNextWeapons.Items;

namespace TheNextWeapons.Items.Melee
{
    public class FixedSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Rebuilt Dynasty Sword");
            // Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.damage = 30;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 32;
            Item.height = 32;
            Item.maxStack = 1;
            Item.useTime = 17;
            Item.useAnimation = 17;
            Item.useStyle = 1;
            Item.knockBack = 1;
            Item.value = 0;
            Item.rare = 0;
            Item.UseSound = SoundID.Item1;
            Item.noMelee = false;
            Item.scale = 1.0f;
            Item.crit = 2;
            Item.autoReuse = true;
        }
        public override bool ReforgePrice(ref int reforgePrice, ref bool canApplyDiscount)
        {
            return base.ReforgePrice(ref reforgePrice, ref canApplyDiscount);
        }
    }
}