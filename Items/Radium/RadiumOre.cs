using Terraria.ModLoader;

namespace TheNextWeapons.Items.Radium
{
    public class RadiumOre : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Radium Ore");
            // Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.damage = -1;
            Item.width = 40;
            Item.height = 20;
            Item.useTime = 5;
            Item.maxStack = 999;
            Item.useAnimation = 10;
            Item.useStyle = 1;
            Item.noMelee = true;
            Item.knockBack = 0;
            Item.value = 600;
            Item.rare = 3;
            Item.consumable = true;
            Item.scale = 1.0f;
            Item.autoReuse = true;
            Item.createTile = Mod.Find<ModTile>("RadiumOre").Type;
        }
    }
}