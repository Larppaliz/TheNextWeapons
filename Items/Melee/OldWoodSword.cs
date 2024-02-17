using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace TheNextWeapons.Items.Melee
{
    public class OldWoodSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Old Wooden Sword");
            // Tooltip.SetDefault("");

        }
        public override void SetDefaults()
        {
            Item.damage = 5;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 32;
            Item.height = 32;
            Item.maxStack = 1;
            Item.useTime = 14;
            Item.useAnimation = 14;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 1;
            Item.value = 0;
            Item.rare = -1;
            Item.UseSound = SoundID.Item1;
            Item.noMelee = false;
            Item.scale = 1.0f;
            Item.crit = 0;
            Item.autoReuse = true;
            Item.prefix = PrefixID.Broken;
        }
        public override void PostReforge()
        {
            Player player = Main.LocalPlayer;
            if (Main.rand.NextBool(2))
            {
                Main.reforgeItem = new Item(ModContent.ItemType<FixedSword>(), 1, PrefixID.Unreal);
            }
            else
            {
                Main.reforgeItem = new Item(ModContent.ItemType<FixedSword>(), 1, 0);
            }
        }

        public override bool ReforgePrice(ref int reforgePrice, ref bool canApplyDiscount)
        {
            canApplyDiscount = false;
            reforgePrice = 50000;
            return base.ReforgePrice(ref reforgePrice, ref canApplyDiscount);
        }
        public override bool? PrefixChance(int pre, UnifiedRandom rand)
        {
            if (pre == -1)
            {
                return false;
            }
            return true;
        }
    }
}