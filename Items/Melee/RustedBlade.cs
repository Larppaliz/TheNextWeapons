using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheNextWeapons.Items.VanillaEdit;

namespace TheNextWeapons.Items.Melee
{
    public class RustedBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Rusted Blade");
            // Tooltip.SetDefault("Crits do 120% less damage");
        }
        public override void SetDefaults()
        {
            Item.damage = 34;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 54;
            Item.height = 24;
            Item.maxStack = 1;
            Item.useTime = 16;
            Item.useAnimation = 16;
            Item.useStyle = 1;
            Item.knockBack = 9;
            Item.value = 20000;
            Item.rare = 2;
            Item.UseSound = SoundID.Item1;
            Item.noMelee = false;
            Item.scale = 1.0f;
            Item.crit = 30;
            Item.autoReuse = true;
        }
        public override void ModifyHitNPC(Player player, NPC target, ref NPC.HitModifiers modifiers)
        {
            modifiers.CritDamage -= 1.2f;
        }
    }
}