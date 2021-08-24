using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons
{
    public class ModGloba : GlobalNPC
    {
        public override void NPCLoot(NPC npc)
        {
            if (Main.rand.Next(100) == 0)
            {
                if (npc.type == NPCID.Skeleton)
                {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BladedGlove, Main.rand.Next(1, 1));
                }
                if (npc.type == NPCID.EaterofSouls)
                {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BladedGlove, Main.rand.Next(1, 1));
                }
            }
        }
    }
}