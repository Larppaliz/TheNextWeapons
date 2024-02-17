using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using TheNextWeapons.Items.Melee;

namespace TheNextWeapons.Buffs
{
    public class Sacrifice : ModBuff
    {

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Sacrifice");
            // Description.SetDefault("The Sword is using your blood to gain strength");
        }
        public override void Update(Player player, ref int buffIndex)
        {
            if (SacrificeBlade.Intensity == 1)
            {
                player.statLifeMax2 -= player.statLifeMax2 / 8;
            }
            if (SacrificeBlade.Intensity == 2)
            {
                player.statLifeMax2 -= player.statLifeMax2 / 4;
            }
            if (SacrificeBlade.Intensity == 3)
            {
                player.statLifeMax2 /= 2;
            }
        }
    }
}