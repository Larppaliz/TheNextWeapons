using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class hat : ModItem
	{
		public override void SetStaticDefaults() {
			base.SetStaticDefaults();
			DisplayName.SetDefault("Scanedium Helmet");
			Tooltip.SetDefault("10% increased Melee damage and melee crit chance\n" +
			"Enemies are more likely to target you");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = 8;
			item.defense = 7;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ModContent.ItemType<brplate>() && legs.type == ModContent.ItemType<pant>();
		}

		public override void UpdateArmorSet(Player player) {
			player.setBonus = "Increases health regen by 2";
			player.lifeRegen += 2;
			player.spaceGun = true;
		}

		public override void UpdateEquip(Player player) {
			player.meleeDamage += 0.1f;
			player.meleeCrit += 10;
			player.aggro += 100;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("bar"), 20);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}