using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Mono.Cecil;
using TheNextWeapons.Projectiles;
using Terraria.Audio;
using Steamworks;

namespace TheNextWeapons.Buffs
{
    public class Drenched : ModBuff
    {

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Drenched");
            // Description.SetDefault("Defense Lowered, Taking Damage & Slowed");
        }
        public override void Update(Player player, ref int buffIndex)
        {
            Dust dust;
            dust = Main.dust[Terraria.Dust.NewDust(player.position, player.width, player.height, DustID.Water, 0f, -2f, 0, default(Color), 1.2f)];
            dust.noGravity = true;
        }
        int timer = 0;
        public static int damage;
        public override void Update(NPC npc, ref int buffIndex)
        {
            timer = npc.buffTime[buffIndex];
            if (timer == 20|| timer == 40|| timer == 60)
            {
                NPC.HitInfo hit = new NPC.HitInfo();
                hit.Crit = false;
                hit.Knockback = 0;
                hit.HitDirection = npc.direction * -1;
                float damagemult = 1f;
                if ((npc.lavaImmune || npc.wet) && !npc.CountsAsACritter && npc.type != NPCID.TargetDummy)
                {
                    damagemult = Main.rand.NextFloat(0.9f, 1.1f);
                }
                else
                {
                    damagemult = Main.rand.NextFloat(0.6f, 0.75f);
                }

                hit.Damage = (int)(damagemult*damage);

                if (!npc.boss) { hit.Knockback = 1f; }

                hit.DamageType = DamageClass.Melee;
                npc.StrikeNPC(hit, false, false);

                for (int i = 0; i < 12; i++)
                {
                    SoundEngine.PlaySound(SoundID.SplashWeak);
                    Dust dust2;
                    dust2 = Main.dust[Terraria.Dust.NewDust(npc.position, npc.width, npc.height, DustID.Water, 5f*hit.HitDirection, -15, 0, default(Color), Main.rand.NextFloat(1f,1.8f))];
                    dust2.noGravity = true;
                }
            }

            Dust dust;
            dust = Main.dust[Terraria.Dust.NewDust(npc.position, npc.width, npc.height, DustID.Water, 0f, -2f, 0, default(Color), 1.2f)];
            dust.noGravity = true;
        }
    }
}