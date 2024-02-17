using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheNextWeapons;
using TheNextWeapons.Items.VanillaEdit;

namespace TheNextWeapons.Items.Sodalite
{
    [AutoloadEquip(EquipType.Head)]
    public class SodaliteHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            // DisplayName.SetDefault("Sodalite Helmet");
            /* Tooltip.SetDefault("3% Increased Melee Damage and Crit Chance\n" +
            "Enemies are more likely to target you"); */
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = 28000;
            Item.rare = 3;
            Item.defense = 7;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<SodaliteBreastplate>() && legs.type == ModContent.ItemType<SodaliteLeggings>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = $"7% Increased Melee Damage and Increases health regen by 2\n" + $"Force a critical hit if you dont crit in 7 hits when using a melee weapon";
            player.lifeRegen += 2;
            Crit.HitNeed = 7;
            player.GetDamage(DamageClass.Melee) += 0.07f;
        }
        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Melee) += 0.03f;
		// Crit Damage Here
            player.GetCritChance(DamageClass.Generic) += 3;
            player.aggro += 20;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod.Find<ModItem>("SodaliteBar").Type, 20);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}