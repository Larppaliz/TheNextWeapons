using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.ID;
using TheNextWeapons.Items.VanillaEdit;

namespace TheNextWeapons.Items.Accessories
{
	public class CrackedEmblem : ModItem
	{
		public override void SetStaticDefaults() {
            		// DisplayName.SetDefault("Cracked Emblem");
			/* Tooltip.SetDefault("An old cracked emblem with an unknown gem inside\n"
							 + "Increased crit chance by 5% and crit damage by 25%"); */

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 40;
            Item.accessory = true;
            Item.defense = 0;
            Item.rare = 1;
        }
        public override void UpdateAccessory(Player player, bool hideVisual) {
			player.GetCritChance(DamageClass.Generic) += 5;
            player.GetDamage(DamageClass.Generic) += 0.05f;
        }
	}
}