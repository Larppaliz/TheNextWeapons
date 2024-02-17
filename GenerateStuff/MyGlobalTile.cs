using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using TheNextWeapons.Items;

namespace TheNextWeapons.GenerateStuff
{
public class MyGlobalTile : GlobalTile
{
    public override void KillTile(int i, int j, int type, ref bool fail, ref bool effectOnly, ref bool noItem)
    {
	Tile t = Main.tile[i, j];
	int Style = t.TileFrameX / (48);
	int Style2 = t.TileFrameY / (32);
        if (!noItem && type == 186) {
		if (Style == 6) {
            if (Main.rand.NextBool(5)) // Give every tile a 1/5 chance to drop an item.
            {
		Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 48, 32,  ModContent.ItemType<Items.Melee.StoneSword>());
                noItem = true;
            }
        }
		if (Style == 5 && Style2 == -1) {
            if (Main.rand.NextBool(5)) // Give every tile a 1/5 chance to drop an item.
            {
		Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 48, 32,  ModContent.ItemType<Items.Melee.OldWoodSword>());
                noItem = true;
            }
        }
	}
    }
}
}