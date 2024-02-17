using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace TheNextWeapons.Buffs
{
    public class Radiated : ModBuff
    {

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Radiation Poisoning");
            // Description.SetDefault("You're Losing Life");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.lifeRegen = -5;
            if (Main.rand.NextFloat() < 0.05f)
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = Main.LocalPlayer.Center;
                dust = Main.dust[Terraria.Dust.NewDust(position, 30, 30, 163, 0f, -1f, 0, new Color(255, 255, 255), 1f)];
                dust.noGravity = true;
                dust.fadeIn = 2f;
            }


        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.lifeRegen = -20;
            if (Main.rand.NextFloat() < 0.3f)
            {
                Dust dust;
                dust = Main.dust[Terraria.Dust.NewDust(npc.position, npc.width, npc.height, 163, 0f, -1f, 0, new Color(255, 255, 255), 1f)];
                dust.noGravity = true;
                dust.fadeIn = 2f;
            }

        }
    }
}