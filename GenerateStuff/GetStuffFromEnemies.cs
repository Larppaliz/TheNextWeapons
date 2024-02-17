using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons
{
    public class GetStuffFromEnemies : GlobalNPC
    {
        public override void OnKill(NPC npc)
        {
            if (Main.rand.NextBool(10))
            {
                if (npc.type == NPCID.Mimic)
                {
                    Item.NewItem(npc.GetSource_Death(), npc.position, new Vector2(), ModContent.ItemType<Items.Magic.MagicMallet>(), 1, false, 0, false, false); // vec2 both
                }
	    }
            if (Main.rand.NextBool(400))
            {
                if (npc.type == NPCID.HellArmoredBones)
                {
                    Item.NewItem(npc.GetSource_Death(), npc.position, new Vector2(), Mod.Find<ModItem>("Darkheart").Type, 1, false, 0, false, false); // vec2 both
                }
                if (npc.type == NPCID.GiantCursedSkull)
                {
                    Item.NewItem(npc.GetSource_Death(), npc.position, new Vector2(), Mod.Find<ModItem>("Darkheart").Type, 1, false, 0, false, false); // vec2 both
                }
            }
            if (Main.rand.NextBool(100))
            {
                if (npc.type == NPCID.AngryBones)
                {
                    Item.NewItem(npc.GetSource_Death(), npc.position, new Vector2(), Mod.Find<ModItem>("CharredScythe").Type, 1, false, 0, false, false); // vec2 both
                }
                if (npc.type == NPCID.DarkCaster)
                {
                    Item.NewItem(npc.GetSource_Death(), npc.position, new Vector2(), Mod.Find<ModItem>("CharredScythe").Type, 1, false, 0, false, false); // vec2 both
                }
                if (npc.type == NPCID.CursedSkull)
                {
                    Item.NewItem(npc.GetSource_Death(), npc.position, new Vector2(), Mod.Find<ModItem>("CharredScythe").Type, 1, false, 0, false, false); // vec2 both
                }
            }
            if (Main.rand.NextBool(30))
            {
                if (npc.type == NPCID.DungeonSlime)
                {
                    Item.NewItem(npc.GetSource_Death(), npc.position, new Vector2(), Mod.Find<ModItem>("CharredScythe").Type, 1, false, 0, false, false); // vec2 both
                }
            }
            if (Main.rand.NextBool(80))
            {
                if (npc.type == NPCID.Demon)
                {
                    Item.NewItem(npc.GetSource_Death(), npc.position, new Vector2(), Mod.Find<ModItem>("Netherstrand").Type, 1, false, 0, false, false); // vec2 both
                }
                if (npc.type == NPCID.FireImp)
                {
                    Item.NewItem(npc.GetSource_Death(), npc.position, new Vector2(), Mod.Find<ModItem>("Netherstrand").Type, 1, false, 0, false, false); // vec2 both
                }
                if (npc.type == NPCID.VoodooDemon)
                {
                    Item.NewItem(npc.GetSource_Death(), npc.position, new Vector2(), Mod.Find<ModItem>("Netherstrand").Type, 1, false, 0, false, false); // vec2 both
                }
                if (npc.type == NPCID.FireImp)
                {
                    Item.NewItem(npc.GetSource_Death(), npc.position, new Vector2(), Mod.Find<ModItem>("Netherstrand").Type, 1, false, 0, false, false); // vec2 both
                }
            }
            if (Main.rand.NextBool(60))
            {
                if (npc.type == NPCID.Demon)
                {
                    Item.NewItem(npc.GetSource_Death(), npc.position, new Vector2(), Mod.Find<ModItem>("Fleshrender").Type, 1, false, 0, false, false); // vec2 both
                }
                if (npc.type == NPCID.FireImp)
                {
                    Item.NewItem(npc.GetSource_Death(), npc.position, new Vector2(), Mod.Find<ModItem>("Fleshrender").Type, 1, false, 0, false, false); // vec2 both
                }
                if (npc.type == NPCID.VoodooDemon)
                {
                    Item.NewItem(npc.GetSource_Death(), npc.position, new Vector2(), Mod.Find<ModItem>("Fleshrender").Type, 1, false, 0, false, false); // vec2 both
                }
                if (npc.type == NPCID.FireImp)
                {
                    Item.NewItem(npc.GetSource_Death(), npc.position, new Vector2(), Mod.Find<ModItem>("Fleshrender").Type, 1, false, 0, false, false); // vec2 both
                }
            }
            if (Main.hardMode)
            {
                if (Main.rand.NextBool(70))
                {
                    if (npc.type == NPCID.AngryBones)
                    {
                        Item.NewItem(npc.GetSource_Death(), npc.position, new Vector2(), Mod.Find<ModItem>("Knightfall").Type, 1, false, 0, false, false); // vec2 both
                    }
                    if (npc.type == NPCID.DarkCaster)
                    {
                        Item.NewItem(npc.GetSource_Death(), npc.position, new Vector2(), Mod.Find<ModItem>("Knightfall").Type, 1, false, 0, false, false); // vec2 both
                    }
                    if (npc.type == NPCID.CursedSkull)
                    {
                        Item.NewItem(npc.GetSource_Death(), npc.position, new Vector2(), Mod.Find<ModItem>("Knightfall").Type, 1, false, 0, false, false); // vec2 both
                    }
                }
                if (Main.rand.NextBool(50))
                {
                    if (npc.type == NPCID.IlluminantBat)
                    {
                        Item.NewItem(npc.GetSource_Death(), npc.position, new Vector2(), Mod.Find<ModItem>("Knightfall").Type, 1, false, 0, false, false); // vec2 both
                    }
                }
            }

            return;
        }

    }
}