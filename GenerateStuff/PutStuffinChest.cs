using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.WorldBuilding;
using Terraria.Audio;

namespace TheNextWeapons
{
    public class PutStuffinChest : ModSystem
    {
        public override void PostWorldGen()
        {
            int[] theIdems = { ItemID.None };
            for (int chestIndex = 0; chestIndex < 1000; chestIndex++)
            {
                if (Main.rand.NextBool(20))
                {
                    theIdems = new int[] { ModContent.ItemType<Items.Melee.ArcaneBlade>(), ModContent.ItemType<Items.Melee.OldSword>() };
                }
                Chest chest = Main.chest[chestIndex];
                if (chest != null && Main.tile[chest.x, chest.y].TileType == TileID.Containers && Main.tile[chest.x, chest.y].TileFrameX == 1 * 36)
                {
                    for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
                    {
                        if (chest.item[inventoryIndex].type == ItemID.None)
                        {
                            chest.item[inventoryIndex].SetDefaults(Main.rand.Next(theIdems));
                            break;
                        }
                    }
                }
                for (chestIndex = 0; chestIndex < 1000; chestIndex++)
                {
                    if (Main.rand.NextBool(20))
                {
                    theIdems = new int[] { ModContent.ItemType<Items.Melee.OldWoodSword>() , ModContent.ItemType<Items.Accessories.CrackedEmblem>() };
                }

                    chest = Main.chest[chestIndex];
                    if (chest != null && Main.tile[chest.x, chest.y].TileType == TileID.Containers && Main.tile[chest.x, chest.y].TileFrameX == 0 * 36)
                    {
                        for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
                        {
                            if (chest.item[inventoryIndex].type == ItemID.None)
                            {
                                chest.item[inventoryIndex].SetDefaults(Main.rand.Next(theIdems));
                                break;
                            }
                        }
                    }
                }
                for (chestIndex = 0; chestIndex < 1000; chestIndex++)
                {
                    if (Main.rand.NextBool(20))
                {
                    theIdems = new int[] { ModContent.ItemType<Items.Melee.RustedBlade>() };
                }
                    chest = Main.chest[chestIndex];
                    if (chest != null && Main.tile[chest.x, chest.y].TileType == TileID.Containers && Main.tile[chest.x, chest.y].TileFrameX == 2 * 36)
                    {
                        for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
                        {
                            if (chest.item[inventoryIndex].type == ItemID.None)
                            {
                                chest.item[inventoryIndex].SetDefaults(Main.rand.Next(theIdems));
                                break;
                            }
                        }
                    }
                }
                for (chestIndex = 0; chestIndex < 1000; chestIndex++)
                {
                if (Main.rand.NextBool(25))
                {
                    theIdems = new int[] { ModContent.ItemType<Items.Ranged.FrostSMG>() };
                }
                    chest = Main.chest[chestIndex];
                    if (chest != null && Main.tile[chest.x, chest.y].TileType == TileID.Containers && Main.tile[chest.x, chest.y].TileFrameX == 11 * 36)
                    {
                        for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
                        {
                            if (chest.item[inventoryIndex].type == ItemID.None)
                            {
                                chest.item[inventoryIndex].SetDefaults(Main.rand.Next(theIdems));
                                break;
                            }
                        }
                    }
                }
                for (chestIndex = 0; chestIndex < 1000; chestIndex++)
                {
                    if (Main.rand.NextBool(25))
                {
                    theIdems = new int[] { ModContent.ItemType<Items.Melee.SacrificeBlade>() };
                }
                    chest = Main.chest[chestIndex];
                    if (chest != null && Main.tile[chest.x, chest.y].TileType == TileID.Containers && Main.tile[chest.x, chest.y].TileFrameX == 4 * 36)
                    {
                        for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
                        {
                            if (chest.item[inventoryIndex].type == ItemID.None)
                            {
                                chest.item[inventoryIndex].SetDefaults(Main.rand.Next(theIdems));
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}
/* Chest things
0: Wooden Chest
1: Gold Chest
2: Locked Gold Chest
3: Shadow Chests
4: Shadow Chests Locked
5: Barrel
6: Trash Can
7: Ebonwood Chest
8: Rich Mahogany
9: Pearlwood Chest
10: Ivy Chest
11: Ice Chest
12: Living Wood Chest
13: Sky Chest
14: Shadewood Chest
15: Web Chest
16: Lizhard Chest
17: Water Chest
18: Dungeon Jungle Chest
19: Dungeon Corrupt Chest
20: Dungeon Crimson Chest
21: Dungeon Hallowed Chest
22: Dungeon Ice Chest
23: Locked Dungeon Jungle Chest
24: Locked Dungeon Corrupt Chest
25: Locked Dungeon Crimson Chest
26: Locked Dungeon Hallowed Chest
27: Locked Dungeon Ice Chest
28: Dynasty Chest
29: Honey Chest
30: Steampunk Chest
31: Palm Wood Chest
32: Glowing Mushroom chest
33: Boreal Wood Chest
34: Gel Chest
35: Green Dungeon Chest
36: Locked Green Dungeon Chest
37: Pink Dungeon Chest
38: Locked Pink Dungeon Chest
39: Blue Dungeon Chest
40: Locked Blue Dungeon Chest
41: Bone Chest
42: Cactus Chest
43: Flesh Chest
44: Obsidian Chest
45: Pumpkin Chest
46: Spooky Chest
47: Glass Chest
48: Martian Chest
49: Meteorite Chest
50: Granite Chest
51: Marble Chest
52: Crystal Chest
53: Golden Chest
*/

