using TheNextWeapons.Items.Melee;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons
{
    public class StartingStuff : ModPlayer
    {
        int Chance = Main.rand.Next(15);
        
        
        /*
        public override IEnumerable<Item> AddStartingItems(bool mediumCoreDeath)
        {
            if (Player.name == "Breadcast") { Chance = 1; }
            if (Chance == 1)
            {
                return new[]
                {
                new Item(ModContent.ItemType<Arondite>(), 1),
                new Item(ItemID.SlimeCrown, 1),
                new Item(ItemID.SuspiciousLookingEye, 1),
                };
            }
            else if (Player.difficulty == PlayerDifficultyID.Creative)
            {
                return new[] 
                {
                    new Item(ModContent.ItemType<Kinslayer>(), 1),
                };
            }
            return null;
        }
        */
    }
}