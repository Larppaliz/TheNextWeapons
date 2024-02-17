using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.Utilities;

namespace TheNextWeapons.Items.Melee
{
    public class Kinslayer: ModItem
    {
        public override void SetStaticDefaults()
        {
        // DisplayName.SetDefault("Kinslayer");
            /* Tooltip.SetDefault("Kill an enemy then right click to get their damage\n" +
                    "Can't get prefixes"); */
        }
        public override bool ConsumeItem(Player player) => false;
        public override void SetDefaults()
        {
            Item.damage = 5;
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
            Item.value = 150000;
            Item.rare = ModContent.RarityType<CustomRarity.MythRarity>();
            Item.crit = 2;
        }
        public override bool? PrefixChance(int pre, UnifiedRandom rand)
        {
            if (pre == -3)
            {
                return false;
            }
            if (pre == -1)
            {
                return false;
            }
            else { return true; }
        }
        public override void LoadData(TagCompound tag)
        {
            if (tag.ContainsKey("KinSlayerDamage"))
            {
                Item.damage = tag.GetAsInt("KinSlayerDamage");
            }
        }
        public override void SaveData(TagCompound tag)
        {
            tag.Add("KinSlayerDamage", Item.damage);
        }
        NPC targets;
        Player players;
        public override bool CanRightClick()
        {
            int Damagecap = 80;
            if (NPC.downedPlantBoss)
            {
                Damagecap = 300;
            }
            else if (Main.hardMode)
            {
                Damagecap = 160;
            }
            if (targets != null)
            {
                if (targets.damage <= Damagecap && targets.damage > 0)
                {
                    SoundEngine.PlaySound(SoundID.Item23);
                    CombatText.NewText(players.getRect(), new Color(200, 120, 170), "New Damage: " + targets.damage, true, true);
                    Item.damage = targets.damage;
                    targets = null;
                }
                else if (targets.damage > Damagecap)
                {
                    SoundEngine.PlaySound(SoundID.Item50);
                    CombatText.NewText(players.getRect(), new Color(150, 80, 120), "New Damage: " + Damagecap, true, true);
                    Item.damage = Damagecap;
                    targets = null;
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            int Damagecap = 80;
            if (NPC.downedPlantBoss)
            {
                Damagecap = 300;
            }
            else if (Main.hardMode)
            {
                Damagecap = 160;
            }
            tooltips.Add(new(Mod, "KinSlayer DamageCap", "Damage Cap: " + Damagecap));
            if (targets != null)
            {
                tooltips.Add(new(Mod, "TargetsName", "Last Killed Enemy Type: " + targets.GetFullNetName()));
                tooltips.Add(new(Mod, "TargetsDamage", "Last Killed Enemy Damage: " + targets.damage));
            }
        }

        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (target.life <= 0)
            {
                players = player;
                targets = target;
            }
        }
    }
}