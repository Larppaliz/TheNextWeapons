using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace TheNextWeapons.CustomRarity
{
    public class MythRarity : ModRarity
    {
        public override Color RarityColor
        {
            get
            {
                return new Color(251, 203, 103);
            }
        }
    }
}