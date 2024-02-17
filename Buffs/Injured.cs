using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace TheNextWeapons.Buffs
{
    public class Injured : ModBuff
    {

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Injured");
            // Description.SetDefault("Lowered defense and slowed down");
        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            Dust dust;
            dust = Main.dust[Terraria.Dust.NewDust(npc.position, npc.height, npc.width, DustID.Blood, 0f, 0f, 0, new Color(255, 0, 0), 1.5f)];
            dust.noGravity = true;
            //npc.defense -= 10;
            if (!npc.boss)
            {
                npc.velocity *= 0.85f;
            }
        }
    }
}