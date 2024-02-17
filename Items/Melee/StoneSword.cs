using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

using TheNextWeapons.Items;

namespace TheNextWeapons.Items.Melee
{
    public class StoneSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Ancient Stone Sword");
            // Tooltip.SetDefault("An ancient stone sword left from long long ago.");
        }
        public override void SetDefaults()
        {
            Item.damage = 10;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 32;
            Item.height = 32;
            Item.maxStack = 1;
            Item.useTime = 17;
            Item.useAnimation = 17;
            Item.useStyle = 1;
            Item.knockBack = 6;
            Item.value = 0;
            Item.rare = -1;
            Item.UseSound = SoundID.Item1;
            Item.noMelee = false;
            Item.scale = 1.0f;
            Item.crit = 0;
            Item.autoReuse = true;
        }
    }
}