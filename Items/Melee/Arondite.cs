using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace TheNextWeapons.Items.Melee
{
    public class Arondite : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Arondite");
            /* Tooltip.SetDefault("'The ultimate sword used by the ultimate hero'\n" +
                    "[c/eeaa33:Gets stronger as you kill bosses]\n" + "Can't get prefixes"); */
        }
        public override void SetDefaults()
        {
            Item.damage = 15;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 54;
            Item.height = 24;
            Item.maxStack = 1;
            Item.useTime = 18;
            Item.useAnimation = 18;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 5;
            Item.value = 250000;
            Item.rare = ModContent.RarityType<CustomRarity.MythRarity>();
            Item.UseSound = SoundID.Item1;
            Item.noMelee = false;
            Item.shoot = ProjectileID.None;
            Item.shootSpeed = 1f;
            Item.scale = 1.0f;
            Item.crit = 5;
            Item.autoReuse = true;
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
        int NotKilledBoss1 = 1;
        int NotKilledBoss2 = 1;
        int NotKilledBoss3 = 1;
        int NotKilledBeeBoss = 1;
        int DeerGuy = 1;
        int HardmodeBonus = 1;
        int SlimeQueen = 1;
        int KillMechBoss = 1;
        int KillPlantBoss = 1;
        int Liunatic = 1;
        int KillGolem = 1;
        int Lunatic = 1;
        int Duke = 1;
        int Towers = 1;
        int MoonGuy = 1;
        public override void UpdateInventory(Player player)
        {
            cooldowntimer--;
            if (NPC.downedBoss1) { if (NotKilledBoss1 == 1) { Item.damage += 5; NotKilledBoss1 = 0; } }
            if (NPC.downedBoss2) { if (NotKilledBoss2 == 1) { Item.damage += 10; NotKilledBoss2 = 0; } }
            if (NPC.downedBoss3) { if (NotKilledBoss3 == 1) { Item.damage += 10; NotKilledBoss3 = 0; } }
            if (NPC.downedDeerclops) { if (DeerGuy == 1) { Item.damage += 5; DeerGuy = 0; } }
            if (NPC.downedQueenBee) { if (NotKilledBeeBoss == 1) { Item.damage += 5; NotKilledBeeBoss = 0; } }
            if (Main.hardMode) { if (HardmodeBonus == 1) { Item.damage += 10; HardmodeBonus = 0; Item.shoot = Mod.Find<ModProjectile>("AirSlashThing").Type; } }
            if (NPC.downedQueenSlime) { if (SlimeQueen == 1) { Item.damage += 15; SlimeQueen = 0; } }
            if (NPC.downedMechBossAny) { if (KillMechBoss == 1) { Item.damage += 20; KillMechBoss = 0; } }
            if (NPC.downedPlantBoss) { if (KillPlantBoss == 1) { Item.damage += 20; KillPlantBoss = 0; } }
            if (NPC.downedEmpressOfLight) { if (Liunatic == 1) { Item.damage += 25; Liunatic = 0; } }
            if (NPC.downedGolemBoss) { if (KillGolem == 1) { Item.damage += 20; KillGolem = 0; } }
            if (NPC.downedAncientCultist) { if (Lunatic == 1) { Item.damage += 15; Lunatic = 0; } }
            if (NPC.downedTowers) { if (Towers == 1) { Item.damage += 25; Towers = 0; } }
            if (NPC.downedFishron) { if (Duke == 1) { Item.damage += 40; Duke = 0; } }
            if (NPC.downedMoonlord) { if (MoonGuy == 1) { Item.damage += 75; MoonGuy = 0; } }
        }
        public override bool AltFunctionUse(Player player)
        {
                return true;
        }
        int cooldowntimer = 0;
        public override bool CanUseItem(Player player)
        {
            if (NPC.downedPlantBoss)
            {
                if (player.altFunctionUse == 2)
                {
                    if (cooldowntimer <= 0)
                    {
                        Item.shoot = Mod.Find<ModProjectile>("AirSlashThingX").Type;
                        cooldowntimer = 60;
                    }
                    else { return false; }
                }
                else
                {
                    if (Main.hardMode)
                    {
                        Item.shoot = Mod.Find<ModProjectile>("AirSlashThing").Type;
                    }
                    else { Item.shoot = ProjectileID.None; }
                    cooldowntimer += 30;
                }
            }
            return base.CanUseItem(player);
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            int NewDamage = damage;
            if (player.altFunctionUse == 2)
            {
                NewDamage = (int)(NewDamage * 1.5f);
            }
            Projectile.NewProjectileDirect(source, position, velocity, type, NewDamage, knockback, player.whoAmI);
            return false;
        }
    }
}