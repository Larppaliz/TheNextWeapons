using Terraria.ModLoader;

namespace TheNextWeapons.Items.Void
{
    public class VoidOre : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Void Ore");
            // Tooltip.SetDefault("Ore that absorbs mana");
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
            Item.value = 15000;
            Item.rare = 7;
            Item.consumable = true;
            Item.scale = 1.0f;
            Item.autoReuse = true;
            Item.createTile = Mod.Find<ModTile>("VoidOre").Type;
        }
    }
}