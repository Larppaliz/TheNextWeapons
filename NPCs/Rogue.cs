using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheNextWeapons.Items.Melee;
using TheNextWeapons.Items.Ranged;
using System;
using Terraria.GameContent.Bestiary;
using Microsoft.VisualBasic;
using System.Linq;

namespace TheNextWeapons.NPCs
{
    [AutoloadHead]
    public class Rogue : ModNPC
    {
        public override string Texture => "TheNextWeapons/NPCs/Rogue";

        public override void SetDefaults()
        {
            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.width = 18;
            NPC.height = 50;
            NPC.aiStyle = 7;
            NPC.defense = 25;
            NPC.lifeMax = 250;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.5f;
            Main.npcFrameCount[NPC.type] = 26;
            NPCID.Sets.ExtraFramesCount[NPC.type] = 0;
            NPCID.Sets.AttackFrameCount[NPC.type] = 4;
            NPCID.Sets.DangerDetectRange[NPC.type] = 700;
            NPCID.Sets.AttackType[NPC.type] = 0;
            NPCID.Sets.AttackTime[NPC.type] = 90;
            NPCID.Sets.AttackAverageChance[NPC.type] = 30;
            NPCID.Sets.HatOffsetY[NPC.type] = 0;
            AnimationType = NPCID.Guide;
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
        }
        public override List<string> SetNPCNameList()
        {
            return new List<string> {
                "Joe",
                "Guy",
                "Timmy",
                "Larry",
                "Bob"
            };
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = "Shop";   //this defines the buy button name
        }
        public override void OnChatButtonClicked(bool firstButton, ref string shop)
        {
            if (firstButton)
            {
                shop = "Shop";
            }
        }

        public override void AddShops()
        {
            var npcShop = new NPCShop(Type, "Shop")
                .Add(new Item(ModContent.ItemType<Items.Melee.SteelBroadsword>()) { shopCustomPrice = Item.buyPrice(gold: 5) }, Condition.PreHardmode)
                .Add(new Item(ModContent.ItemType<Items.Melee.SteelShortsword>()) { shopCustomPrice = Item.buyPrice(gold: 5) }, Condition.PreHardmode)
                .Add(new Item(ModContent.ItemType<Items.Melee.SteelLongsword>()) { shopCustomPrice = Item.buyPrice(gold: 5) }, Condition.PreHardmode)

                .Add(new Item(ModContent.ItemType<Items.Melee.EngravedSteelGreatsword>()) { shopCustomPrice = Item.buyPrice(gold: 25) }, Condition.Hardmode)

                .Add(new Item(ModContent.ItemType<Items.Ranged.Luger>()) { shopCustomPrice = Item.buyPrice(gold: 12) }, Condition.DownedSkeletron, Condition.NotDownedPlantera)
                .Add(new Item(ModContent.ItemType<Items.Ranged.JimmyGun>()) { shopCustomPrice = Item.buyPrice(gold: 12) }, Condition.DownedSkeletron, Condition.NotDownedPlantera)

                .Add(new Item(ModContent.ItemType<Items.Ranged.Eradicator>()) { shopCustomPrice = Item.buyPrice(gold: 20) }, Condition.DownedDeerclops, Condition.NotDownedPlantera)
                .Add(new Item(ModContent.ItemType<Items.Ranged.Quadrant>()) { shopCustomPrice = Item.buyPrice(gold: 20) }, Condition.DownedDeerclops, Condition.NotDownedPlantera)

                .Add(new Item(ModContent.ItemType<Items.Ranged.AA12>()) { shopCustomPrice = Item.buyPrice(gold: 40) }, Condition.DownedPlantera)
                .Add(new Item(ModContent.ItemType<Items.Ranged.Famas>()) { shopCustomPrice = Item.buyPrice(gold: 40) }, Condition.DownedPlantera)
                                .Add(new Item(ModContent.ItemType<Items.Ranged.GalilMAR>()) { shopCustomPrice = Item.buyPrice(gold: 40) }, Condition.DownedPlantera)

                .Add(new Item(ItemID.Ichor) { shopCustomPrice = Item.buyPrice(gold: 1) }, Condition.CrimsonWorld, Condition.Hardmode)
                .Add(new Item(ItemID.CursedFlame) { shopCustomPrice = Item.buyPrice(gold: 1) }, Condition.CorruptWorld, Condition.Hardmode)
                ;
                npcShop.Register();
        }

        public override string GetChat()       //Allows you to give this town NPC a chat message when a player talks to it.
        {
            switch (Main.rand.Next(4))    //this are the messages when you talk to the npc
            {
                case 0:
                    return "How's It Going My Friend?";
                case 1:
                    return "Wanna Buy Somenthing?";
                case 2:
                    return "I Wonder Where All The Daggers Dissapeared...";
                case 3:
                    return "I Have The Last Longsword.";
                default:
                    return "Sup Buddy.";
            }
        }
        public override bool CanTownNPCSpawn(int numTownNPCs)/* tModPorter Suggestion: Copy the implementation of NPC.SpawnAllowed_Merchant in vanilla if you to count money, and be sure to set a flag when unlocked, so you don't count every tick. */
        {
            if (ModContent.GetInstance<Config>().SpawnTownNPC)
            {
                for (int k = 1; k < 255; k++)
                {
                    Player player = Main.player[k];
                    if (!player.active)
                    {
                        continue;
                    }
                    if (NPC.downedBoss1)
                    {
                        return true;
                    }
                    return false;
                }
            }
            return false;
        }
        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = 15; // The amount of damage the Town NPC inflicts.
            knockback = 8f; // The amount of knockback the Town NPC inflicts.
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 15; // The amount of ticks the Town NPC takes to cool down. Every 60 in-game ticks is a second.
            randExtraCooldown = 90; // How long it takes until the NPC attacks again, but with a chance.
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            projType = ProjectileID.Grenade; // The Projectile this NPC shoots. Search up Terraria Projectile IDs, I cannot link the websites in this code
            attackDelay = 1; // Delays the attacks, obviously.
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 6.5f; // The Speed of the Projectile
            randomOffset = 2.5f; // Random Offset
        }
    }
}