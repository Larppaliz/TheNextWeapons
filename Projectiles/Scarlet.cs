using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using TheNextWeapons.Items.Melee;

namespace TheNextWeapons.Projectiles
{
    public class Scarlet : ModProjectile
    {
        public override void SetDefaults()
        {
            Player player = Main.player[Projectile.owner];
            Projectile.width = 46;
            Projectile.height = 46;
            Projectile.friendly = true;
            Projectile.aiStyle = 0;
            Projectile.timeLeft = 40;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.penetrate = -1;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 30;
            Projectile.extraUpdates = 1;

        }

        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
        }

        public override void OnKill(int timeLeft)
        {
        }
        int timer;
        Vector2 oldpos;
        Vector2 playeroldpos;
        int postimer;
        List<NPC> NPCS = new List<NPC>();
        public override void OnSpawn(IEntitySource source)
        {
            Player player = Main.player[Projectile.owner];
            Projectile.position = player.Center;
            oldpos = Projectile.position;
            playeroldpos = player.position;
        }
        public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            if (player.channel)
            {
                player.heldProj = Projectile.whoAmI;
                Projectile.timeLeft = 2;
                Projectile.hide = false;
            }
            else
            {
                Projectile.hide = true;
            }
            if (timer <= 0)
            {
                NPCS = new List<NPC>();
            }
            postimer--;
            if (postimer <= 0)
            {
                postimer = 15;
                if (Projectile.position.Distance(oldpos + (player.position - playeroldpos)) > 20)
                {
                    //Vector2 position = (oldpos - playeroldpos + player.position);
                    SoundEngine.PlaySound(SoundID.Item1);
                    //Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), player.Center, Projectile.velocity.RotatedBy(position.AngleTo(Projectile.position)/2), ProjectileID.SwordBeam, Projectile.damage, Projectile.knockBack, player.whoAmI);
                }
                playeroldpos = player.position;
                oldpos = Projectile.position;

            }
            if (Projectile.position.Distance(oldpos + (player.position - playeroldpos)) > 20)
            {
                for (int i = 0; i < 1; i++)
                {
                    int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.YellowStarDust, 0, 0, 0, default(Color), 1.5f);
                    Main.dust[dust].noGravity = true;
                }
            }
                Projectile.Center = player.Center + player.DirectionTo(Main.MouseWorld) * 35f;
            Projectile.rotation = player.AngleTo(Main.MouseWorld) + MathHelper.ToRadians(45f);
        }
        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
            Player player = Main.player[Projectile.owner];
            NPCS.Add(target);
            modifiers.HitDirectionOverride = player.direction;
            if (Projectile.position.Distance(oldpos + (player.position - playeroldpos)) < 20)
            {
                modifiers.FinalDamage -= 0.7f;
                modifiers.Knockback -= 0.9f;
            }
            timer = 11;
        }

        public override void PostDraw(Color lightColor)
        {
            Player player = Main.player[Projectile.owner];
            Main.instance.LoadProjectile(Projectile.type);
            Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
            // Redraw the projectile with the color not influenced by light
            Vector2 drawOrigin = new Vector2(texture.Width * 0.5f, Projectile.height * 0.5f);

            for (int k = 0; k < Projectile.oldPos.Length; k++)
            {
                Color color = Color.White;
                color = Projectile.GetAlpha(lightColor) * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length);
                Vector2 drawPos = (Projectile.oldPos[k] - Main.screenPosition) + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
                Main.EntitySpriteDraw(texture, drawPos, null, color*0.4f, Projectile.oldRot[k], drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            }
        }
    }
}