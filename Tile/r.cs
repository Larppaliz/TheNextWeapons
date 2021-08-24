using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TheNextWeapons.Tile
{
    public class r : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true; // Is the tile solid
            Main.tileMergeDirt[Type] = true; // Will tile merge with dirt?
            Main.tileLighted[Type] = true; // ???
            Main.tileBlockLight[Type] = true; // Emits Light
            
            drop = mod.ItemType("r"); // What item drops after destorying the tile
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Radium");
            AddMapEntry(new Color(80, 120, 0), name); // Colour of Tile on Map
            minPick = 90; // What power pick minimum is needed to mine this block.
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 0.3f;
            g = 0.6f;
            b = 0.0f;
        }
    }
}