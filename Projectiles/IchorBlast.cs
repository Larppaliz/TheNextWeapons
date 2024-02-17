using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Projectiles
{
    public class IchorBlast : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 4;
        }
        public override void SetDefaults()
        {

            Projectile.width = 36;
            Projectile.height = 36;
            Projectile.friendly = false;
            Projectile.hostile = false;
            Projectile.aiStyle = 0;
            Projectile.penetrate = 1;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = false;
            Projectile.timeLeft = 120;
            Projectile.gfxOffY = -10;
            Projectile.alpha = 0;
            Projectile.localNPCHitCooldown = 10;
            Projectile.usesLocalNPCImmunity = true;
        }
        public override Color? GetAlpha(Color lightColor) => new Color(255,255,255,80);

        public List<NPC> NPCs = new List<NPC>();
        public override void OnSpawn(IEntitySource source)
        {
        }

        public override void OnKill(int timeLeft)
        {
            for (int k = 0; k < 5; k++)
            {
                int dust = Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.Ichor, Projectile.oldVelocity.X * 1.0f, Projectile.oldVelocity.Y * 1.0f, 0, default(Color), 2f);
                Main.dust[dust].noGravity = true;
            }
        }
        int timer;
        float projSpeed = 15f;
        public override void AI()
        {

            Projectile.frame = (int)Projectile.knockBack;

            if (Projectile.knockBack < 0f)
            {
                Projectile.Kill();
            }
            Projectile.velocity *= 0.95f;
            Projectile.rotation = Projectile.velocity.ToRotation()+MathHelper.ToRadians(45);

            float maxDetectRadius = 800f; // The maximum radius at which a projectile can detect a target
            float minDistance = 0f;

            // Trying to find NPC closest to the projectile
            timer++;
            if (timer >= 25)
            {
                Projectile.friendly = true;
                NPC closestNPC = FindClosestNPC(maxDetectRadius);
                if (closestNPC == null)
                {
                    return;
                }
                if (NPCs.Contains(closestNPC))
                {
                    return;
                }

                // If found, change the velocity of the projectile and turn it in the direction of the target
                // Use the SafeNormalize extension method to avoid NaNs returned by Vector2.Normalize when the vector is zero
                if (closestNPC.Distance(Projectile.Center) > minDistance)
                {
                    projSpeed += 0.5f;
                    Projectile.velocity = (closestNPC.Center - Projectile.Center).SafeNormalize(Vector2.Zero) * projSpeed;
                }
            }

        }
        public NPC FindClosestNPC(float maxDetectDistance)
        {
            NPC closestNPC = null;

            // Using squared values in distance checks will let us skip square root calculations, drastically improving this method's speed.
            float sqrMaxDetectDistance = maxDetectDistance * maxDetectDistance;

            // Loop through all NPCs(max always 200)
            for (int k = 0; k < Main.maxNPCs; k++)
            {
                NPC target = Main.npc[k];
                // Check if NPC able to be targeted. It means that NPC is
                // 1. active (alive)
                // 2. chaseable (e.g. not a cultist archer)
                // 3. max life bigger than 5 (e.g. not a critter)
                // 4. can take damage (e.g. moonlord core after all it's parts are downed)
                // 5. hostile (!friendly)
                // 6. not immortal (e.g. not a target dummy)
                if (target.CanBeChasedBy() && !NPCs.Contains(closestNPC))
                {
                    // The DistanceSquared function returns a squared distance between 2 points, skipping relatively expensive square root calculations
                    float sqrDistanceToTarget = Vector2.DistanceSquared(target.Center, Projectile.Center);

                    // Check if it is within the radius
                    if (sqrDistanceToTarget < sqrMaxDetectDistance)
                    {
                        sqrMaxDetectDistance = sqrDistanceToTarget;
                        closestNPC = target;
                    }
                }
            }

            return closestNPC;
        }



        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
            modifiers.Knockback *= 0f;
            if (target.CanBeChasedBy() && Projectile.knockBack > 0)
            {
                SoundEngine.PlaySound(SoundID.NPCHit3);
                Projectile.knockBack -= 1;
                Projectile.timeLeft = 120;
                Projectile.damage = (int)(Projectile.damage / 1.6f);
                Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), Projectile.position, Projectile.velocity, ModContent.ProjectileType<Projectiles.IchorBlast>(), Projectile.damage, Projectile.knockBack, Projectile.owner);
                Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), Projectile.position, Projectile.velocity * -1f, ModContent.ProjectileType<Projectiles.IchorBlast>(), Projectile.damage, Projectile.knockBack, Projectile.owner);
            }
            target.AddBuff(BuffID.Ichor, Projectile.damage*2);
        }
    }
}