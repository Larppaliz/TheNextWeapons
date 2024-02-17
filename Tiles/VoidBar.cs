using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.WorldBuilding;
using Terraria.Audio;
using Terraria.ObjectData;
using Terraria.Localization;
using Terraria.DataStructures;

namespace TheNextWeapons.Tiles
{
    public class VoidBar : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileShine[Type] = 1100;
            Main.tileSolid[Type] = true;
            Main.tileSolidTop[Type] = true;
            Main.tileFrameImportant[Type] = true;

            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.LavaDeath = false;
            TileObjectData.addTile(Type);

            AddMapEntry(new Color(180, 20, 255), Language.GetText("MapObject.MetalBar")); // localized text for "Metal Bar"

            DustType = ModContent.DustType<Dusts.VoidDust>();
            HitSound = SoundID.Tink;
        }

        public override bool CanDrop(int i, int j)
        {
            Tile t = Main.tile[i, j];
            int style = t.TileFrameX / 18;

            // It can be useful to share a single tile with multiple styles. This code will let you drop the appropriate bar if you had multiple.
            if (style == 0)
            {
                Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 16, ModContent.ItemType<Items.Void.VoidBar>());
            }

            return base.CanDrop(i, j);
        }
    }
}