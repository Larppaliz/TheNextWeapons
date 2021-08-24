using System.IO;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;

namespace TheNextWeapons
{
    public class ModWorrl : ModWorld
    {
        private const int saveVersion = 0;
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
        {
            int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
            if (ShiniesIndex == -1)
            {
                return;
            }
            tasks.Insert(ShiniesIndex + 1, new PassLegacy("Radioactive Ores", delegate (GenerationProgress progress)
            {
                progress.Message = "Radioactive Ores";
                                                                                                                                                                                                                                         //Put your custom tile block name
                for (int k = 0; k < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 6E-05); k++)                                                                                                                                      //      |
                {                                                                                                                                                                                                                      //       |
                    WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)WorldGen.worldSurfaceLow, Main.maxTilesY), (double)WorldGen.genRand.Next(5, 7), WorldGen.genRand.Next(7, 9), mod.TileType("r"), false, 0f, 0f, false, true);
                }
            }));
        }

    }
}
