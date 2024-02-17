using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace TheNextWeapons.Buffs
{
    public class Leaking : ModBuff
    {

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Leaking");
            // Description.SetDefault("'You feel weak'");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            Dust dust;
            Vector2 position = Main.LocalPlayer.Center;
            dust = Main.dust[Terraria.Dust.NewDust(position, 30, 30, DustID.Blood, 0f, 0f, 0, new Color(255, 0, 0), 1f)];
            dust.noGravity = true;
            player.moveSpeed *= 0.5f;
            player.lifeRegen = -10;
        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            if (npc.boss)
            {
                Dust dust;
                dust = Main.dust[Terraria.Dust.NewDust(npc.position, npc.height, npc.width, DustID.Blood, 0f, 0f, 0, new Color(255, 0, 0), 1.5f)];
                dust.noGravity = true;
                npc.lifeRegen = -15;
            }
            else
            {
                Dust dust;
                dust = Main.dust[Terraria.Dust.NewDust(npc.position, npc.height, npc.width, DustID.Blood, 0f, 0f, 0, new Color(255, 0, 0), 1f)];
                dust.noGravity = true;
                npc.lifeRegen = -15;
                npc.velocity *= 0.5f;
            }
        }
    }
}