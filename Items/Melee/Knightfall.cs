using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items.Melee
{
    public class Knightfall : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Knightfall");
            // Tooltip.SetDefault("'Does more damage based on Crit Chance'");
        }
        public override void SetDefaults()
        {
            Item.damage = 70;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 54;
            Item.height = 24;
            Item.maxStack = 1;
            Item.useTime = 28;
            Item.useAnimation = 28;
            Item.useStyle = 1;
            Item.knockBack = 4;
            Item.value = 250000;
            Item.rare = 4;
            Item.UseSound = SoundID.Item1;
            Item.noMelee = false;
            Item.scale = 1.0f;
            Item.crit = 0;
            Item.autoReuse = true;
        }
        public override void ModifyHitNPC(Player player, NPC target, ref NPC.HitModifiers modifiers)
        {
            modifiers.FinalDamage = modifiers.FinalDamage * (1 + Item.crit / 35);
        }
    }
}