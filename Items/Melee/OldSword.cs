using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items.Melee
{
    public class OldSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Old Sword");
            /* Tooltip.SetDefault("Increases defense but drains mana on hit when held\n" +
                    "Made of a metal that does not rust"); */
        }
        public override void SetDefaults()
        {
            Item.damage = 19;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 54;
            Item.height = 24;
            Item.maxStack = 1;
            Item.useTime = 36;
            Item.useAnimation = 36;
            Item.useStyle = 1;
            Item.knockBack = 4;
            Item.value = 10000;
            Item.rare = 1;
            Item.UseSound = SoundID.Item1;
            Item.noMelee = false;
            Item.scale = 1.0f;
            Item.crit = 10;
            Item.autoReuse = true;
        }
        bool buffThing = false;
        int timer;
        public override void HoldItem(Player player)
        {
            if (buffThing)
            {
                if (player.statMana > 0)
                {
                    player.AddBuff(ModContent.BuffType<Buffs.DefenseBuffPlayer>(), 2);
                }
                else { buffThing = false; }
            }
            else if (player.statMana == player.statManaMax)
            {
                buffThing = true;
                for (int i = 0; i < 20; i++)
                {
                    int dust = Dust.NewDust(player.position, player.width, player.height, DustID.DungeonSpirit, 0f, 0f, 1, default(Color), 1f);
                    Main.dust[dust].noGravity = true;
                }
            }
        }
    }
}