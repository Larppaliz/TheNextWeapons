using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheNextWeapons.NPCs
{
    public class OverrideShop : GlobalNPC
    {
        public static bool VoidSet = false;
        public static bool buffThing = false;
        public override void ModifyShop(NPCShop shop)
        {
            //shopSpecialCurrency = CustomCurrencyID.DefenderMedals // omit this line if shopCustomPrice should be in regular coins.
            if (shop.NpcType == NPCID.Merchant)
            {
                if (NPC.downedMechBossAny)
                {
                    shop.Add(new Item(ModContent.ItemType<Items.Ranged.RocketGun>())
                    {
                        shopCustomPrice = 500000,
                    });
                }
            }
        }

        public override void AI(NPC npc)
        {
            buffThing = false;
            VoidSet = false;
            base.AI(npc);
        }
        public override void GetChat(NPC npc, ref string chat)
        {
            Player player = Main.LocalPlayer;
            if (player.HasItem(ModContent.ItemType<Items.Melee.OldWoodSword>()))
            {
                if (Main.rand.NextBool(2))
                {
                    chat = "[c/ffffa0:I won't just tinker around with what you find, i can also try repairing whatever objects you find broken.]";
                }
            }
        }



        public override void OnHitPlayer(NPC npc, Player target, Player.HurtInfo hurtInfo)
        {
            if (target.HasBuff(ModContent.BuffType<Buffs.DefenseBuffPlayer>()))
            {
                target.statMana -= 40;
            }
            if (VoidSet)
            {
                int trueDamage = hurtInfo.Damage - (target.statDefense / 2);
                if (trueDamage > 0)
                {
                        if (trueDamage > target.statManaMax2)
                    {
                        target.ManaEffect(target.statManaMax2 * -1);
                        target.statMana = 0;
                    }
                    else
                    {
                        if (trueDamage > target.statMana)
                        {
                            hurtInfo.Damage -= target.statMana;
                            target.ManaEffect(target.statMana * -1);
                            target.statMana = 0;
                        }
                        else
                        {
                            hurtInfo.Damage -= target.statMana;
                            target.ManaEffect(trueDamage * -1);
                            target.statMana -= trueDamage;
                        }
                    }
                }
                else { hurtInfo.Damage -= target.statMana; }
            }
        }
        public override void OnKill(NPC npc)
        {
            if (true)//ModContent.GetInstance<Config>().GenerateOres)
            {
                if (npc.type == NPCID.TheDestroyer || npc.type == NPCID.SkeletronPrime || npc.type == NPCID.Spazmatism || npc.type == NPCID.Retinazer)
                {
                    if (!NPC.downedMechBossAny)
                    {
                        for (int x = 0; x < Main.maxTilesX; x++)
                        {
                            for (int y = 0; y < Main.maxTilesY; y++)
                            {
                                if ((Main.tile[x, y].TileType == TileID.Demonite || Main.tile[x, y].TileType == TileID.Crimtane))
                                {
                                    Main.tile[x, y].TileType = (ushort)ModContent.TileType<Tiles.VoidOre>();
                                }
                            }
                        }
                        Main.NewText("[c/7d26cd:It feels like your mana is being pulled towards something underground.]");
                    }
                }
            }
        }
    }
}