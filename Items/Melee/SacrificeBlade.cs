using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.Utilities;
using TheNextWeapons.Items.VanillaEdit;

namespace TheNextWeapons.Items.Melee
{
    public class SacrificeBlade: ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Sacrifice Blade");
            // Tooltip.SetDefault("Alt use to change the amount of blood the sword can drain");
        }
	    public static int Intensity = 0;
        public override void SetDefaults()
        {
            Item.damage = 50;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 32;
            Item.height = 32;
            Item.scale = 1f;
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
            Item.shootSpeed = 5f;
            Item.value = 150000;
            Item.rare = 4;
            Item.crit = 0;
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                Item.shoot = 0;
                Item.UseSound = SoundID.Item43;
                if (Intensity < 3)
                {
                    Intensity++;
                }
                else { Intensity = 0; }

                float numberProjectiles = 25;
                float rotation = MathHelper.ToRadians(360);
                for (int i = 0; i < numberProjectiles * (Intensity + 1); i++)
                {
                    Vector2 position = player.Center + new Vector2(20,20).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1)));
                        int dust = Dust.NewDust(position, 0, 0, DustID.Blood, 0, 0, 20, default(Color), 1f);
                        Main.dust[dust].noGravity = false;
                }
            }
            else
            {
                Item.UseSound = SoundID.Item1;
                if (Intensity == 3)
                {
                    Item.shoot = Mod.Find<ModProjectile>("SacrificeSlash").Type;
                }
                else
                {
                    Item.shoot = 0;
                }
            }
            return base.CanUseItem(player);
        }

        public override void UpdateInventory(Player player)
        {
            if (Intensity > 0)
            {
                player.AddBuff(Mod.Find<ModBuff>("Sacrifice").Type, 10);
            }
        }
        public override void ModifyHitNPC(Player player, NPC target, ref NPC.HitModifiers modifiers)
        {
            if (Main.rand.NextBool(100 / (Intensity + 1)))
            {
                modifiers.SetCrit();
            }
            modifiers.FinalDamage.Flat += (Intensity * Intensity) + (Intensity * 5);
        }

        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
        }

        public override void ModifyHitPvp(Player player, Player target, ref Player.HurtModifiers modifiers)
        {
            modifiers.FinalDamage.Flat += (Intensity * Intensity) + (Intensity * 5);
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            if (Intensity == 1)
            {
                tooltips.Add(new(Mod, "intensity", "Current Drain: -12.5% Max Life"));
            }
            if (Intensity == 2)
            {
                tooltips.Add(new(Mod, "intensity", "Current Drain: -25% Max Life"));
            }
            if (Intensity == 3)
            {
                tooltips.Add(new(Mod, "intensity", "Current Drain: -50% Max Life"));
            }
        }
    }
}