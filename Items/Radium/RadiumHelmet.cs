using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items.Radium
{
    [AutoloadEquip(EquipType.Head)]
    public class RadiumHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            // DisplayName.SetDefault("Radium Helmet");
            // Tooltip.SetDefault("6% increased Ranged damage");
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = 30000;
            Item.rare = 3;
            Item.defense = 5;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<RadiumBreastplate>() && legs.type == ModContent.ItemType<RadiumLeggings>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = $"Increases Ranged damage by 9% but you are dying from Radiation Poisoning";
            player.AddBuff(Mod.Find<ModBuff>("Radiated").Type, 2);
            player.GetDamage(DamageClass.Ranged) += 0.09f;
        }

        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Ranged) += 0.06f;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod.Find<ModItem>("RadiumBar").Type, 20);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}