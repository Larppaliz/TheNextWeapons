using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheNextWeapons.Items.VanillaEdit;

namespace TheNextWeapons.Items.Melee
{
    public class Darkheart : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Darkheart");
            // Tooltip.SetDefault("Crits do 50% more damage and cause leaking");
        }
        public override void SetDefaults()
        {
            Item.damage = 182;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 32;
            Item.height = 32;
            Item.scale = 1.2f;
            Item.maxStack = 1;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.knockBack = 7f;
            Item.UseSound = SoundID.Item1;
            Item.noMelee = false;
            Item.noUseGraphic = false;
            Item.autoReuse = true;
            Item.useTurn = false;
            Item.useStyle = 1;
            Item.value = 0;
            Item.rare = 9;
            Item.crit = 15;
            Item.shootSpeed = 0.0f;
        }

        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (hit.Crit)
            {
                target.AddBuff(Mod.Find<ModBuff>("Death").Type, 600);
            }
        }
        public override void ModifyHitNPC(Player player, NPC target, ref NPC.HitModifiers modifiers)
        {
            modifiers.CritDamage += 0.5f;
        }
    }
}