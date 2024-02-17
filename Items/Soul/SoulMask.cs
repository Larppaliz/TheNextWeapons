using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheNextWeapons.Items.VanillaEdit;

namespace TheNextWeapons.Items.Soul
{
    [AutoloadEquip(EquipType.Head)]
    public class SoulMask : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            // DisplayName.SetDefault("Soul Mask");
            // Tooltip.SetDefault("Icreased Crit Chance By 9%");
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = 18000;
            Item.rare = 4;
            Item.defense = 7;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<SoulBreastplate>() && legs.type == ModContent.ItemType<SoulBoots>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = $"Increased All Damage By 10%, Increased Crit Chance by 12% and You are glowing";
            player.GetDamage(DamageClass.Generic) += 0.1f;
            player.AddBuff(11, 5);
            player.GetCritChance(DamageClass.Generic) += 12;
        }

        public override void UpdateEquip(Player player)
        {
            player.GetCritChance(DamageClass.Generic) += 9;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod.Find<ModItem>("BarofSouls").Type, 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}