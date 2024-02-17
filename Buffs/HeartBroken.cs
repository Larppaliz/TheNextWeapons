using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace TheNextWeapons.Buffs
{
    public class HeartBroken : ModBuff
    {

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Heart Broken");
            // Description.SetDefault("");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.lifeRegen = player.statLifeMax2 / -100;
            Dust dust;
            // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
            Vector2 position = Main.LocalPlayer.Center;
            dust = Main.dust[Terraria.Dust.NewDust(position, 30, 30, 90, 0f, 1.860465f, 0, new Color(255, 255, 255), 1.35f)];
            dust.noGravity = true;
            dust.fadeIn = 1.186047f;
        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.lifeRegen = npc.lifeMax / -100;
            Dust dust;
            // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
            dust = Main.dust[Terraria.Dust.NewDust(npc.position, npc.width, npc.height, 90, 0f, 1.860465f, 0, new Color(255, 255, 255), 1.35f)];
            dust.noGravity = true;
            dust.fadeIn = 1.186047f;
        }
    }
}