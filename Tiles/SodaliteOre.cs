using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.IO;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.WorldBuilding;
using Terraria.Audio;


namespace TheNextWeapons.Tiles
{
    public class SodaliteOre : ModTile
    {
        public override void SetStaticDefaults()
        {
            TileID.Sets.Ore[Type] = true;
            Main.tileSpelunker[Type] = true;
            Main.tileShine2[Type] = true;
            Main.tileShine[Type] = 975;
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileLighted[Type] = true;
            Main.tileBlockLight[Type] = true;

            RegisterItemDrop(ModContent.ItemType<Items.Sodalite.SodaliteOre>());
            LocalizedText name = CreateMapEntryName();
            // name.SetDefault("Sodalite");
            AddMapEntry(new Color(15, 30, 180), name); // Colour of Tile on Map
            MinPick = 65; // What power pick minimum is needed to mine this block.
            MineResist = 5f;
            DustType = 84;
            HitSound = SoundID.Tink;
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 0.6f;
            g = 0.2f;
            b = 0.8f;
        }
    }
}