using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheNextWeapons.Items.Magic;

namespace TheNextWeapons.Items.Soul
{
    [AutoloadEquip(EquipType.Body)]
    public class SoulBreastplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            // DisplayName.SetDefault("Soul Breastplate");
            // Tooltip.SetDefault("Increased Attack Speed by 5%");
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = 21000;
            Item.rare = 4;
            Item.defense = 10;
        }

        public override void UpdateEquip(Player player)
        {
        Paragon.maxProjectiles += 1;
		player.GetAttackSpeed(DamageClass.Generic) += 0.05f;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod.Find<ModItem>("BarofSouls").Type, 25);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}