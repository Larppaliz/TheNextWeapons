using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Items.VanillaEdit
{
    public class Crit : GlobalItem
    {
        public override bool InstancePerEntity => true;
        static int Hit = 0;
        public static int HitNeed = 0;

        public override void OnHitNPC(Item item, Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
                    if (hit.Crit) { Hit = 0; }
        }
        public override void ModifyHitNPC(Item item, Player player, NPC target, ref NPC.HitModifiers modifiers)
        {
            if (item.DamageType == DamageClass.Melee)
            {
                if (HitNeed > 0)
                {
                    Hit++;
                    if (Hit >= HitNeed)
                    {
                        SoundEngine.PlaySound(SoundID.DD2_ExplosiveTrapExplode);
                        modifiers.SetCrit();
                    }
                }
            }
        }
    }
}