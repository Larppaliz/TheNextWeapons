using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace TheNextWeapons.CustomRarity
{
    public class UnobtainableRarity : ModRarity
    {
        public override Color RarityColor
        {
            get
            {
                return new Color(238, 170, 51);
            }
        }
    }
}