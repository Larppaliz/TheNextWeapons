using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items
{
public class Tolon : ModItem
{
public override void SetStaticDefaults()
{
DisplayName.SetDefault("Steel Longsword");
Tooltip.SetDefault("");
}
public override void SetDefaults()
{
item.damage = 15;
item.melee = true;
item.width = 54;
item.height = 24;
item.maxStack = 1;
item.useTime = 25;
item.useAnimation = 25;
item.useStyle = 1;
item.knockBack = 9;
item.value = 40000;
item.rare = 3;
item.UseSound = SoundID.Item1;
item.noMelee = false;
item.scale = 1.2f;
item.crit = 10;
item.autoReuse = true;
}
}
}