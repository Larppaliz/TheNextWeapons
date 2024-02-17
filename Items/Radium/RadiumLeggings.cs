using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items.Radium
{
    [AutoloadEquip(EquipType.Legs)]
    public class RadiumLeggings : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            // DisplayName.SetDefault("Radium Leggings");
            // Tooltip.SetDefault("15% Increased Movement Speed");
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = 10000;
            Item.rare = 3;
            Item.defense = 5;
        }

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.15f;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod.Find<ModItem>("RadiumBar").Type, 15);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemID.RuneRobe && head.type == ItemID.RuneHat;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.moveSpeed += 1.5f;
            player.manaCost *= 0.0f;
            player.lifeRegen *= 50;
        }
    }
}