using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Mono.Cecil;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using TheNextWeapons.Items.Melee;

namespace TheNextWeapons.Projectiles
{
    public class GroundStaff : ModProjectile
    {
        public override void SetDefaults()
        {
            Player player = Main.player[Projectile.owner];
            Projectile.width = 40;
            Projectile.height = 40;
            Projectile.friendly = true;
            Projectile.aiStyle = 0;
            Projectile.timeLeft = 60;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.penetrate = -1;
        }

        public override void SetStaticDefaults()
        {
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
        Vector2 direction;
        public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            player.heldProj = Projectile.whoAmI;


            Projectile.Center = player.Center + direction;
            if (player.channel && player.statMana > 3)
            {
                direction = player.DirectionTo(Main.MouseWorld) * 35f;
                Projectile.spriteDirection = player.direction;
                Projectile.timeLeft = 30;
                if (Projectile.spriteDirection == -1)
                {
                    Projectile.rotation = player.AngleTo(Main.MouseWorld) + MathHelper.ToRadians(-225f);
                }
                else
                {
                    Projectile.rotation = player.AngleTo(Main.MouseWorld) + MathHelper.ToRadians(45f);
                }
            }
        }
        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
            modifiers.FinalDamage -= 0.8f;
            modifiers.Knockback += 5f;
        }
    }
}