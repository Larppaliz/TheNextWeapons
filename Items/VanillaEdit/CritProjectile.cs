using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.UI.ModBrowser;
using Terraria.WorldBuilding;
using TheNextWeapons.NPCs;

namespace TheNextWeapons.Items.VanillaEdit
{
    public class CritProjectile : GlobalProjectile
    {
        static int Hit = 0;
        public override bool InstancePerEntity => true;
        public override void OnSpawn(Projectile projectile, IEntitySource source)
        {
            if ((projectile.type == ProjectileID.MoonlordArrow))
            {
                projectile.knockBack = 2f;
            }
            if (projectile.knockBack == 1.99498939892835989f && projectile.aiStyle == 1)
            {
                projectile.velocity *= 1.5f;
                for (int i = 0; i < 10; i++)
                {
                    int dust2 = Dust.NewDust(projectile.position, projectile.width, projectile.height, Mod.Find<ModDust>("VoidDust").Type, projectile.velocity.X / 2, projectile.velocity.Y / 2, 0, default(Color), 1.0f);
                    Main.dust[dust2].noGravity = true;
                }
                projectile.aiStyle = 0;
                projectile.alpha = 1;
            }
        }
        int timertest;
        public override bool PreAI(Projectile projectile)
        {
            if (projectile.ai[2] == 1.12345f)
            {
                timertest++;
                if (timertest >= 8)
                {
                    timertest = 0;
                    int dust = Dust.NewDust(projectile.Center, 0, 0, Main.rand.Next(new int[] { DustID.Ichor, DustID.CursedTorch }), Main.rand.NextFloat(-5, 5), Main.rand.NextFloat(-5, 5), 240, Color.Gray, 1f);

                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].fadeIn = 1f;
                }
            }
            else if (projectile.ai[2] == 1.1121524f)
            {
                projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(90);
                Dust dust = Dust.NewDustPerfect(projectile.Center, Mod.Find<ModDust>("VoidDust").Type, projectile.velocity, 0, default(Color), 1.0f);
                dust.noGravity = true;
            }
            return true;
        }


        public override void ModifyHitNPC(Projectile projectile, NPC target, ref NPC.HitModifiers modifiers)
        {
        Player player = Main.player[projectile.owner];
            int HitNeed = Crit.HitNeed;
            if (projectile.friendly)
            {
                if (projectile.DamageType == DamageClass.Melee)
                {
                    if (HitNeed > 0)
                    {
                        Hit++;
                        if (Hit >= HitNeed)
                        {
                            SoundEngine.PlaySound(SoundID.Tink);
                            modifiers.SetCrit();
                        }
                    }
                }
            }
        }

        public override void OnHitNPC(Projectile projectile, NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (hit.Crit) { Hit = 0; }

            if (projectile.ai[2] == 1.12345f)
            {
                target.AddBuff(BuffID.Ichor, 60);
                target.AddBuff(BuffID.CursedInferno , 60);
            }
        }

        public override void OnHitPlayer(Projectile projectile, Player target, Player.HurtInfo info)
        {
            if (OverrideShop.VoidSet)
            {
                target.ManaEffect(info.Damage * -1);
            }
        }
        public override void ModifyHitPlayer(Projectile projectile, Player target, ref Player.HurtModifiers modifiers)
        {
            if (target.HasBuff(ModContent.BuffType<Buffs.DefenseBuffPlayer>()))
            {
                target.statMana -= 40;
            }
            if (OverrideShop.VoidSet)
            {
                modifiers.FinalDamage.Flat -= target.statMana;
            }
             
        }

        public override void OnKill(Projectile projectile, int timeLeft)
        {
            if (projectile.ai[2] == 1.12345f)
            {
                for (int i = 0; i < 10; i++)
                {
                    int dust = Dust.NewDust(projectile.Center, 0, 0, Main.rand.Next(new int[] { DustID.Ichor , DustID.CursedTorch }), Main.rand.NextFloat(-5, 5), Main.rand.NextFloat(-5, 5), 240, Color.Gray, 1.5f);
                    
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].fadeIn = 1.5f;
                }
            }
        }
    }
}