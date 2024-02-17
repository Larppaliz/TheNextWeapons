using Terraria.ModLoader;

namespace TheNextWeapons.Items.Sodalite
{
    public class SodaliteOre : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Sodalite Ore");
            // Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.damage = -1;
            Item.width = 40;
            Item.height = 20;
            Item.useTime = 5;
            Item.maxStack = 99999;
            Item.useAnimation = 10;
            Item.useStyle = 1;
            Item.noMelee = true;
            Item.knockBack = 0;
            Item.value = 300;
            Item.rare = 3;
            Item.consumable = true;
            Item.scale = 1.0f;
            Item.autoReuse = true;
            Item.createTile = Mod.Find<ModTile>("SodaliteOre").Type;
        }
    }
}