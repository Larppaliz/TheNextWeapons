using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Buffs
{
    public class Red_Fire : ModBuff
    {

        public override bool RightClick(int buffIndex)
        {
            return false;
        }

        public override void ModifyBuffText(ref string buffName, ref string tip, ref int rare)
        {
            buffName = "On Red Fire!!!";
            tip = "The red fire stuff burns your uhh soul and body";
            rare = 4;
        }
        public override bool ReApply(NPC npc, int time, int buffIndex)
        {
            npc.GetGlobalNPC<RedFireLifeRegenEffectNPC>().RedFireDamage += 1;
            npc.buffTime[buffIndex] -= 30;
            return true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<RedFireLifeRegenEffectPlayer>().lifeRegenDebuff = true;
            int[] dustIDs = new int[] { DustID.CrimsonTorch, DustID.RedTorch };
            if (Main.rand.NextBool(2))
            {
                int dustID = dustIDs[Main.rand.Next(dustIDs.Length)];
                Dust dust;
                dust = Main.dust[Terraria.Dust.NewDust(player.position, player.width, player.height, dustID, 0f, -2f, 0, new Color(255, 0, 255, 255), 2f)];
                dust.noGravity = true;
                dust.fadeIn = 1f;
            }
        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<RedFireLifeRegenEffectNPC>().lifeRegenDebuff = true;
            int[] dustIDs = new int[] { DustID.CrimsonTorch, DustID.RedTorch };
            if (Main.rand.NextFloat() < ((float)npc.GetGlobalNPC<RedFireLifeRegenEffectNPC>().RedFireDamage) / 10f)
            {
                int dustID = dustIDs[Main.rand.Next(dustIDs.Length)];
                Dust dust;
                dust = Main.dust[Terraria.Dust.NewDust(npc.position, npc.width, npc.height, dustID, 0f, -3f, 0, new Color(255, 0, 255, 255), 1.5f)];
                dust.noGravity = true;
                dust.velocity.Y -= 2f;
                dust.fadeIn = 1f + ((float)npc.GetGlobalNPC<RedFireLifeRegenEffectNPC>().RedFireDamage) / 20f;
            }

            if (npc.buffTime[buffIndex] < 2)
            {
                npc.GetGlobalNPC<RedFireLifeRegenEffectNPC>().RedFireDamage = 2;
            }
        }

        public class RedFireLifeRegenEffectPlayer : ModPlayer
        {
            public bool lifeRegenDebuff;

            public override void ResetEffects()
            {
                lifeRegenDebuff = false;
            }
            public override void UpdateBadLifeRegen()
            {
                if (lifeRegenDebuff)
                {
                    if (Player.lifeRegen > 0)
                        Player.lifeRegen = 0;
                    Player.lifeRegenTime = 0;
                    Player.lifeRegen -= 16;
                }
            }
        }

        public class RedFireLifeRegenEffectNPC : GlobalNPC
        {

            public override bool InstancePerEntity => true;
            public int RedFireDamage = 1;
            public bool lifeRegenDebuff;

            public override void ResetEffects(NPC npc)
            {
                lifeRegenDebuff = false;
            }
            public override void UpdateLifeRegen(NPC npc, ref int damage)
            {
                if (lifeRegenDebuff)
                {
                    damage = RedFireDamage;
                    if (npc.lifeRegen > 0)
                        npc.lifeRegen = 0;
                        npc.lifeRegen -= RedFireDamage*8;
                }
            }
        }
    }
}