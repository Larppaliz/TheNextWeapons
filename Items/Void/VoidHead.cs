using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheNextWeapons.Items.VanillaEdit;
using TheNextWeapons.NPCs;

namespace TheNextWeapons.Items.Void
{
    [AutoloadEquip(EquipType.Head)]
    public class VoidHead : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            // DisplayName.SetDefault("Void Mask");
            // Tooltip.SetDefault("Increase crit damage based on mana");
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = 18000;
            Item.rare = 7;
            Item.defense = 9;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<VoidBody>() && legs.type == ModContent.ItemType<VoidLegs>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = $"Increased defense based on mana";
            player.statDefense += player.statMana / 20;
        }
        public override void UpdateEquip(Player player)
        {
            player.GetCritChance(DamageClass.Generic) += player.statManaMax2 / 20;
        }

        public override void ModifyHitNPC(Player player, NPC target, ref NPC.HitModifiers modifiers)
        {
            base.ModifyHitNPC(player, target, ref modifiers);
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod.Find<ModItem>("VoidBar").Type, 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}