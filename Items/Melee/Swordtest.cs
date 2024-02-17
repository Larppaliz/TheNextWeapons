using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.Utilities;

namespace TheNextWeapons.Items.Melee
{
    public class SwordTest : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Dark Age Katana");
            // Tooltip.SetDefault("Gets faster the more times you hit enemies in a row");
        }
        public static int olditemspeed;
        int timer;
        public bool itemdamagestore;
        public override void SetDefaults()
        {
            Item.damage = 35;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 54;
            Item.height = 24;
            Item.maxStack = 1;
            Item.useTime = 25;
            Item.useAnimation = 25;
            Item.useStyle = 1;
            Item.knockBack = 4;
            Item.value = 7500;
            Item.rare = 4;
            Item.UseSound = SoundID.Item1;
            Item.noMelee = false;
            Item.scale = 1.0f;
            Item.crit = 10;
            Item.shootSpeed = 5f;
            Item.autoReuse = true;
            olditemspeed = Item.useAnimation;
        }
        public override void PostReforge()
        {
            olditemspeed = Item.useAnimation;
        }
        public override void OnCreated(ItemCreationContext context)
        {
            olditemspeed = Item.useAnimation;
        }
        public override void LoadData(TagCompound tag)
        {
            if (tag.ContainsKey("SpeedFix"))
            {
                olditemspeed = tag.GetAsInt("SpeedFix");
            }
            else { itemdamagestore = false; }
        }
        public override void SaveData(TagCompound tag)
        {
            tag.Add("SpeedFix", olditemspeed);
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(ItemID.Katana, 1);
            recipe.AddIngredient(ItemID.SoulofNight, 25);
            recipe.AddIngredient(ItemID.DarkShard, 2);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
        int speedcap = olditemspeed - 20;
        public override void UpdateInventory(Player player)
        {
            if (timer >= 34) { if (Item.useAnimation < olditemspeed) { Item.useAnimation += 1; timer = 0; } }
            else { timer += 1; }
            if (Item.useAnimation > speedcap)
            {
                Item.shoot = 0;
            }
            else
            {
                Item.shoot = Mod.Find<ModProjectile>("DarkAirSlash").Type;
            }
        }
        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (Item.useAnimation >= speedcap)
            {
                Item.useAnimation -= 1;
            }
            else
            {
                Item.useAnimation = speedcap;
            }

        }
    }
}