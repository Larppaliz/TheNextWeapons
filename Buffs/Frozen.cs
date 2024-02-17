using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Buffs
{
    public class Frozen : ModBuff
    {

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Frozen");
            // Description.SetDefault("'Chilling down your spines'");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            if (Main.rand.NextFloat() < 0.05813954f)
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = Main.LocalPlayer.Center;
                dust = Main.dust[Terraria.Dust.NewDust(position, 30, 30, 180, 0f, 0f, 0, new Color(255, 255, 255), 1f)];
                dust.noGravity = true;
                dust.fadeIn = 1.465116f;
            }

            int Timer = 0;
            Timer++;
            if (Timer < 20) { player.moveSpeed *= 0.3f; }
            if (Timer < 30) { player.moveSpeed *= 0.4f; }
            if (Timer < 40) { player.moveSpeed *= 0.6f; }
            if (Timer < 50) { player.moveSpeed *= 0.9f; }
            if (Timer == 60) { Timer = 0; }
        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            if (!npc.boss)
            {
                int Timer = 0;
                Timer++;
                if (npc.noGravity)
                {
                    if (Timer < 20) { npc.velocity *= 0.3f; }
                    if (Timer < 30) { npc.velocity *= 0.4f; }
                    if (Timer < 40) { npc.velocity *= 0.6f; }
                    if (Timer < 50) { npc.velocity *= 0.9f; }
                    if (Timer == 60) { Timer = 0; }
                }
                else
                {
                    if (Timer < 20) { npc.velocity.X *= 0.3f; }
                    if (Timer < 30) { npc.velocity.X *= 0.4f; }
                    if (Timer < 40) { npc.velocity.X *= 0.6f; }
                    if (Timer < 50) { npc.velocity.X *= 0.9f; }
                    if (Timer == 60) { Timer = 0; }
                }
                if (Main.rand.NextBool(5))
                {
                    Dust dust;
                    dust = Main.dust[Terraria.Dust.NewDust(npc.position, npc.width, npc.height, DustID.IceRod, 0f, -2f, 0, new Color(255, 255, 255), 1f)];
                    dust.noGravity = true;
                    dust.fadeIn = 1.5f;
                }
            }
        }
    }
}