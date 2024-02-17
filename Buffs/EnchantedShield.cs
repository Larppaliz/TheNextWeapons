using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Mono.Cecil;
using TheNextWeapons.Projectiles;
using Terraria.Audio;
using Steamworks;
using static Humanizer.In;

namespace TheNextWeapons.Buffs
{
    public class EnchantedShield : ModBuff
    {

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Drenched");
            // Description.SetDefault("Defense Lowered, Taking Damage & Slowed");
        }
        public override bool ReApply(Player player, int time, int buffIndex)
        {
            return true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
        }
    }
}