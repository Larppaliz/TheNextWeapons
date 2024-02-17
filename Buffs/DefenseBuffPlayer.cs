using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace TheNextWeapons.Buffs
{
    public class DefenseBuffPlayer : ModBuff
    {

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Defense Buff");
            // Description.SetDefault("Defense is increased by 6");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            //player.statDefense += 6;

        }
    }
}