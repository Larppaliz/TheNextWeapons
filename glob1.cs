using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons
{
    public class glob1 : GlobalNPC
    {
        public override void NPCLoot(NPC npc)
        {
            if (Main.rand.Next(4) == 0)
            {
                if (npc.type == NPCID.RuneWizard)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("rudag"));
                }
            }
        }
    }
}