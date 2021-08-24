using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items
{
public class Tola : ModItem
{
public override void SetStaticDefaults()
{
DisplayName.SetDefault("Steel Broadsword");
Tooltip.SetDefault("");
}
public override void SetDefaults()
{
item.damage = 12;
item.melee = true;
item.width = 54;
item.height = 24;
item.maxStack = 1;
item.useTime = 15;
item.useAnimation = 15;
item.useStyle = 1;
item.knockBack = 9;
item.value = 30000;
item.rare = 3;
item.UseSound = SoundID.Item1;
item.noMelee = false;
item.scale = 1.0f;
item.crit = 7;
item.autoReuse = true;
}
}
}