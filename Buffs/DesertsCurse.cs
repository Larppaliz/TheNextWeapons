using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Buffs
{
    public class DesertsCurse : ModBuff
    {
        public override bool RightClick(int buffIndex)
        {
            return false;
        }

        public override void ModifyBuffText(ref string buffName, ref string tip, ref int rare)
        {
            buffName = "Curse of The Desert";
            tip = "You are suffocating from nothing";
            rare = 1;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.lifeRegen = -20;
            Dust dust;

            Vector2 position = Main.LocalPlayer.Center;
            dust = Main.dust[Terraria.Dust.NewDust(position, 30, 30, DustID.Sand, 0f, -2f, 0, new Color(255, 255, 255), 1f)];
            dust.noGravity = false;
            dust.fadeIn = 0.5f;

        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.lifeRegen = -20;

            if (Main.rand.NextFloat() < 0.18f)
            {
                Dust dust;
                dust = Main.dust[Terraria.Dust.NewDust(npc.position, npc.width, npc.height, DustID.Sand, 0f, -2f, 0, new Color(255, 255, 255), 1f)];
                dust.noGravity = false;
                dust.fadeIn = 0.5f;
            }
        }
    }
}