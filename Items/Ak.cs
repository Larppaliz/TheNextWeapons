using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items
{
public class Ak : ModItem
{
public override void SetStaticDefaults()
{
DisplayName.SetDefault("Ak-41");
Tooltip.SetDefault("");
}
public override void SetDefaults()
{
item.damage = 34;
item.ranged = true;
item.width = 54;
item.height = 24;
item.maxStack = 1;
item.useTime = 25;
item.useAnimation = 25;
item.useStyle = 5;
item.knockBack = 6;
item.value = 30000;
item.rare = 3;
item.UseSound = SoundID.Item11;
item.noMelee = true;
item.shoot = 14;
item.shootSpeed = 14f;
item.autoReuse = true;
item.useAmmo = 97;
}
}
}