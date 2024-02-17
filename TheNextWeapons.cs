using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.ModLoader.Config;
using System.ComponentModel;
using Terraria.GameInput;
using System.IO;

namespace TheNextWeapons
{
    public class TheNextWeapons : Mod
    {
    }

	public class Config : ModConfig
	{
        public override ConfigScope Mode => ConfigScope.ServerSide;

        // The "$" character before a name means it should interpret the name as a translation key and use the loaded translation with the same key.
        // The things in brackets are known as "Attributes".
        [Header("General")] // Headers are like titles in a config. You only need to declare a header on the item it should appear over, not every item in the category.
        [Label("Spawn mod town npcs?")] // A label is the text displayed next to the option. This should usually be a short description of what it does.
        [Tooltip("Toggles if the town npcs from this mod can spawn")] // A tooltip is a description showed when you hover your mouse over the option. It can be used as a more in-depth explanation of the option.
        [DefaultValue(true)] // This sets the configs default value.
        [ShowDespiteJsonIgnore]
        //[ReloadRequired]
        public bool SpawnTownNPC; // To see the implementation of this option, see ExampleWings.cs

        [Label("Generate mod ores?")] // A label is the text displayed next to the option. This should usually be a short description of what it does.
        [Tooltip("Toggle if the mod generates the ores on map gen")] // A tooltip is a description showed when you hover your mouse over the option. It can be used as a more in-depth explanation of the option.
        [DefaultValue(true)] // This sets the configs default value.
        //[Range(-20, 20)] // This sets the maximum value for the option.
        [ShowDespiteJsonIgnore]
        public bool GenerateOres;
    }
}