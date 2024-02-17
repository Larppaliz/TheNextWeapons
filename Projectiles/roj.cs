using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Projectiles
{
    public class roj : ModProjectile
    {
        public override void SetDefaults()
        {

            Projectile.width = 18;
            Projectile.height = 18;
            Projectile.friendly = true;
            Projectile.aiStyle = 0;
            Projectile.timeLeft = 300;
            Projectile.tileCollide = true;
            Projectile.ignoreWater = false;
            Projectile.penetrate = -1;
            Projectile.light = 0f;
        }
        public override Color? GetAlpha(Color lightColor) => new Color(255, 255, 255, 0);


        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Radiation Flower");

        }

        public override void OnKill(int timeLeft)
        {
            for (int k = 0; k <5; k++)
            {
                int dust = Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, 163, Projectile.oldVelocity.X * 1.0f, Projectile.oldVelocity.Y * 1.0f);
            }
        }

        int timer = 0;
        public override void AI()
        {
            if (Projectile.timeLeft == 300)
            {
                for (int i = 0; i < 15; i++)
                {
                    int dust2 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 163, 0f, 0f, 0, default(Color), 1.0f);
                    Main.dust[dust2].noGravity = true;
                }
            }
            Player player = Main.player[Projectile.owner];
            Projectile.rotation = MathHelper.ToRadians(Projectile.timeLeft) * 2;
            int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 163, Projectile.velocity.X * 1f, Projectile.velocity.Y * 1f, 40, default(Color), 1f);
            Main.dust[dust].noGravity = true;

            float numberProjectiles = 100;
            float rotation = MathHelper.ToRadians(360);
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 position = Projectile.Center + new Vector2(200, 200).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1)));
                //int dust2 = Dust.NewDust(position, 0, 0, 163, 0, 0, 20, default(Color), 1f);
                //Main.dust[dust2].noGravity = true;
            }
            NPC closestNPC = FindClosestNPC(350);
            if (closestNPC == null)
            {
                return;
            }
            Vector2 velocity = (closestNPC.Center - Projectile.Center).SafeNormalize(Vector2.Zero) * 10;

            timer++;
            if (timer == 10)
            {
                SoundEngine.PlaySound(SoundID.Item72);
                Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), Projectile.Center, velocity, Mod.Find<ModProjectile>("BounceLaser").Type, Projectile.damage - 5, Projectile.knockBack, player.whoAmI);
                timer = 0;
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
                if (target.CanBeChasedBy())
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

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (Main.rand.NextBool(3))
            {
                target.AddBuff(Mod.Find<ModBuff>("Radiation").Type, 120);
            }
        }
        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            if (Main.rand.NextBool(3))
            {
                target.AddBuff(Mod.Find<ModBuff>("Radiation").Type, 120);
            }
        }
    }
}