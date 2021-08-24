using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.Projectiles
{
    public class goldag : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 6;
            projectile.height = 6;
            projectile.scale = 1.0f;
            projectile.aiStyle = 19;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.tileCollide = false;
            projectile.penetrate = -1;
            projectile.ownerHitCheck = true;
            projectile.melee = true;
            projectile.timeLeft = 50;
            projectile.hide = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Golden Dagger");
        }

        public override void AI()

        {
            Main.player[projectile.owner].direction = projectile.direction;
            Main.player[projectile.owner].heldProj = projectile.whoAmI;
            Main.player[projectile.owner].itemTime = Main.player[projectile.owner].itemAnimation;
            projectile.position.X = Main.player[projectile.owner].position.X + (float)(Main.player[projectile.owner].width / 2) - (float)(projectile.width / 2);
            projectile.position.Y = Main.player[projectile.owner].position.Y + (float)(Main.player[projectile.owner].height / 2) - (float)(projectile.height / 2);
            projectile.position += projectile.velocity * projectile.ai[0]; if (projectile.ai[0] == 0f)
            {
                projectile.ai[0] = 3f;
                projectile.netUpdate = true;
            }
            if (Main.player[projectile.owner].itemAnimation < Main.player[projectile.owner].itemAnimationMax / 3)
            {
                projectile.ai[0] -= 1.1f;
            }
            else
            {
                projectile.ai[0] += 0.95f;
            }

            if (Main.player[projectile.owner].itemAnimation == 0)
            {
                projectile.Kill();
            }

            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 2.355f;
            if (projectile.spriteDirection == -1)
            {
                projectile.rotation -= 1.57f;
            }
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.NextBool(1))
			{
				target.AddBuff(195, 0, true);
			}			
			if (Main.rand.NextBool(1))
			{
				target.AddBuff(196, 0, true);
			}			
			if (Main.rand.NextBool(1))
			{
				target.AddBuff(33, 0, true);
			}
			projectile.velocity *= 0.8f;
		}
        }
    }