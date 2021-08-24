using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items
{
	[AutoloadEquip(EquipType.Body)]
	public class brplate : ModItem
	{
		public override void SetStaticDefaults() {
			base.SetStaticDefaults();
			DisplayName.SetDefault("Scanedium Breastplate");
			Tooltip.SetDefault("\nImmunity to 'On Fire!'"
				+ "\n+10 max mana and +10 max health");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = 8;
			item.defense = 7;
		}

		public override void UpdateEquip(Player player) {
			player.buffImmune[BuffID.OnFire] = true;
			player.statManaMax2 += 10;
			player.statLifeMax2 += 10;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("bar"), 25);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}