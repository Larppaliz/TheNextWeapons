using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items.Melee
{
    public class ArcaneBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Arcane Blade");
            // Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.damage = 25;   //The damage stat for the Weapon.                       
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;   //This defines if it does magic damage and if its effected by magic increasing Armor/Accessories.
            Item.width = 24;      //The size of the width of the hitbox in pixels.
            Item.height = 24;      //The size of the height of the hitbox in pixels.
            Item.useTime = 24;     //How fast the Weapon is used.
            Item.useAnimation = 24;    //How long the Weapon is used for.
            Item.useStyle = 1;
            Item.noMelee = false;
            Item.knockBack = 5;
            Item.rare = 2;
            Item.mana = 0;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.shootSpeed = 0.5f;
            Item.value = 35000;
        }
        public override bool CanUseItem(Player player)
        {
            if (player.statMana >= player.statManaMax2) { Item.shoot = ModContent.ProjectileType<Projectiles.AirSlash>(); Item.mana = 40; }
            else { Item.shoot = 0; Item.mana = 0; }
            return true;
        }
    }
}