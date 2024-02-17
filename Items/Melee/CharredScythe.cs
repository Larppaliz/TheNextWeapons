using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.Utilities;

namespace TheNextWeapons.Items.Melee;

public class CharredScythe : ModItem
{
    public override void SetStaticDefaults()
    {
        //DisplayName.SetDefaults("Charred Scythe");
        //Tooltip.SetDefaults("Killing enemies increases damage temporarily");
    }
        public int olditemdamage;
    public bool itemdamagestore;
    public override void SetDefaults()
    {

        Item.damage = 25;
        Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
        Item.width = 54;
        Item.height = 54;
        Item.maxStack = 1;
        Item.useTime = 20;
        Item.useAnimation = 20;
        Item.useStyle = 1;
        Item.knockBack = 2;
        Item.value = Item.damage;
        Item.rare = 2;
        Item.UseSound = SoundID.Item1;
        Item.noMelee = false;
        Item.scale = 1.0f;
        Item.crit = 1;
        Item.autoReuse = true;
        olditemdamage = Item.damage;
    }
    public override bool? PrefixChance(int pre, UnifiedRandom rand)
    {
        if (pre == -1) { return false; }
        else
        {
            return true;
        }
    }
    public override void PostReforge()
    {
        olditemdamage = Item.damage;
    }
    public override void LoadData(TagCompound tag)
    {
    if (tag.ContainsKey("prefixfix"))
        {
            olditemdamage = tag.GetAsInt("prefixfix");
        }
    else { itemdamagestore = false; }
    }
    public override void SaveData(TagCompound tag)
    {
        tag.Add("prefixfix", olditemdamage);
    }
    int timer;
    int speed = 2;
    public override void UpdateInventory(Player player)
    {
        if (speed/2 < 1) { speed = 2; }
        if (timer >= 60 / (speed/2)) { if (Item.damage > olditemdamage) { Item.damage -= 1; timer = 0; speed += 1; } }
        timer += 1;
    }
    public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
    {
        if (speed > 2)
        {
            speed -= 1;
        }
        if (target.life < 1 & target.damage / 5 > 0) { Item.damage += target.damage / 5; speed = 2; 
        }

    }
}