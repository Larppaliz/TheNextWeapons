using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items.Sodalite
{
    [AutoloadEquip(EquipType.Body)]
    public class SodaliteBreastplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            // DisplayName.SetDefault("Sodalite Breastplate");
            /* Tooltip.SetDefault("\nImmunity to 'On Fire!'"
                + "\n+10 max mana and +10 max health"); */
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = 35000;
            Item.rare = 3;
            Item.defense = 7;
        }

        public override void UpdateEquip(Player player)
        {
            player.buffImmune[BuffID.OnFire] = true;
            player.statManaMax2 += 10;
            player.statLifeMax2 += 10;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod.Find<ModItem>("SodaliteBar").Type, 25);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}