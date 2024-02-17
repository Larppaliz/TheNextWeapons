using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items.Void
{
    [AutoloadEquip(EquipType.Body)]
    public class VoidBody : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Void Breastplate");
            // Tooltip.SetDefault("Increased damage based on mana");
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = 21000;
            Item.rare = 7;
            Item.defense = 15;
        }

        public override void UpdateEquip(Player player)
        {
		player.GetDamage(DamageClass.Generic) += (0.001f * (player.statManaMax2 - player.statMana));
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod.Find<ModItem>("VoidBar").Type, 25);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}