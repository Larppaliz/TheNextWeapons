using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items.Melee
{
    public class EngravedSteelGreatsword : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Engraved Steel Greatsword");
            // Tooltip.SetDefault("On a closer look you can see tiny engravings in the sword.");
        }
        public override void SetDefaults()
        {
            Item.damage = 90;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 54;
            Item.height = 24;
            Item.maxStack = 1;
            Item.useTime = 38;
            Item.useAnimation = 38;
            Item.useStyle = 1;
            Item.knockBack = 9;
            Item.value = Item.buyPrice(gold: 50);
            Item.rare = 5;
            Item.UseSound = SoundID.Item1;
            Item.noMelee = false;
            Item.scale = 1.2f;
            Item.crit = 18;
            Item.autoReuse = true;
        }
        bool prefixbonus = true;
        public override void PostReforge()
        {
            Item.scale += 0.2f;
            prefixbonus = false;
        }

        public override void UpdateInventory(Player player)
        {
            if (prefixbonus)
            {
                if (Item.prefix > 0)
                {
                    Item.scale += 0.2f;
                    prefixbonus = false;
                }
            }
        }
    }
}