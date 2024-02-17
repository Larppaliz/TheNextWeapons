using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items.Radium
{
    public class GeigerNullifier : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Geiger Nullifier");

            // Tooltip.SetDefault("Increases Health Regen and nullifies radioactivity");
        }
        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 28;
            Item.rare = 3;
            Item.value = 50000;
            Item.defense = 3;
            Item.accessory = true;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(ItemID.Wire, 10);
            recipe.AddIngredient(Mod.Find<ModItem>("RadiumBar").Type, 3);
            recipe.AddIngredient(Mod.Find<ModItem>("SodaliteBar").Type, 7);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.buffImmune[Mod.Find<ModBuff>("Radiated").Type] = true;
            player.buffImmune[Mod.Find<ModBuff>("Radiation").Type] = true;
            player.lifeRegen += 10;
        }
    }
}