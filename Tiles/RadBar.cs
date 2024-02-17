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

namespace TheNextWeapons.Tiles
{
    public class RadBar : ModTile
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

            RegisterItemDrop(ModContent.ItemType<Items.Radium.RadiumBar>());
            AddMapEntry(new Color(200, 255, 0), Language.GetText("MapObject.MetalBar")); // localized text for "Metal Bar"
            DustType = 84;
            HitSound = SoundID.Tink;
        }
    }
}