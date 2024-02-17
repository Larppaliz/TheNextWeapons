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
	public class RadiumOre : ModTile
	{
		public override void SetStaticDefaults()
		{
			TileID.Sets.Ore[Type] = true;
			Main.tileSpelunker[Type] = true; // The tile will be affected by spelunker highlighting
			Main.tileShine2[Type] = true; // Modifies the draw color slightly.
			Main.tileShine[Type] = 1200; // How often tiny dust appear off this tile. Larger is less frequently
			Main.tileSolid[Type] = true; // Is the tile solid
			Main.tileMergeDirt[Type] = true; // Will tile merge with dirt?
			Main.tileLighted[Type] = true; // ???
			Main.tileBlockLight[Type] = true; // Emits Light

            RegisterItemDrop(ModContent.ItemType<Items.Radium.RadiumOre>());
            LocalizedText name = CreateMapEntryName();
			AddMapEntry(new Color(80, 100, 0), name); // Colour of Tile on Map

			// name.SetDefault("Radium");
			MinPick = 90; // What power pick minimum is needed to mine this block.
			MineResist = 8f;
			DustType = 84;
			HitSound = SoundID.Tink;
			SoundEngine.PlaySound(SoundID.Tink);
		}

		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			r = 0.45f;
			g = 0.6f;
			b = 0.2f;
		}
	}
}