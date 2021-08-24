using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items
{
public class tshort : ModItem
{
public override void SetStaticDefaults()
{
DisplayName.SetDefault("Steel Shortsword");
Tooltip.SetDefault("");
}
public override void SetDefaults()
{
item.damage = 11;
item.melee = true;
item.width = 54;
item.height = 24;
item.maxStack = 1;
item.useTime = 12;
item.useAnimation = 12;
item.useStyle = 3;
item.knockBack = 9;
item.value = 20000;
item.rare = 3;
item.UseSound = SoundID.Item1;
item.noMelee = false;
item.scale = 0.85f;
item.crit = 2;
item.autoReuse = true;
}
}
}