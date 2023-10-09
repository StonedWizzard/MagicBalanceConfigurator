using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;

namespace MagicBalanceConfigurator.Generators
{
    public class ItemModsProvider
    {
        public static ItemMod[] ItemMods { get; private set; } = new ItemMod[] { };
        public static string[] ItemsPrefixes { get; set; } = new string[] { };
        public static string[] ItemsAfixes { get; set; } = new string[] { };
        public static string[] ItemsSufixes { get; set; } = new string[] { };

        public static void InitializeItemsMods()
        {
            if (!IsItemModsConfigsExist())
            {
                ItemMods = GetDefaultMods();
                UpdateItemsMods();
            }
            string raw = File.ReadAllText(Consts.ItemModsConfigsPath);
            ItemsModsContainer itemsModsContainer = JsonConvert.DeserializeObject<ItemsModsContainer>(raw);
            ItemMods = itemsModsContainer.ItemMods;
            ItemsPrefixes = itemsModsContainer.ItemsPrefixes;
            ItemsAfixes = itemsModsContainer.ItemsAfixes;
            ItemsSufixes = itemsModsContainer.ItemsSufixes;
        }

        public static void UpdateItemsMods()
        {
            ItemsModsContainer itemsModsContainer = new ItemsModsContainer() 
            { 
                ItemMods = ItemMods,
                ItemsAfixes = ItemsAfixes, 
                ItemsPrefixes = ItemsPrefixes, 
                ItemsSufixes = ItemsSufixes 
            };
            string raw = JsonConvert.SerializeObject(itemsModsContainer);
            File.WriteAllText(Consts.ItemModsConfigsPath, raw);
        }

        public static bool IsItemModsConfigsExist() => File.Exists(Consts.ItemModsConfigsPath);

        public static ItemMod GetModByName(string name) => ItemMods.FirstOrDefault(x => x.ModName == name);

        private static ItemMod[] GetDefaultMods()
        {
            return new ItemMod[]
            {
                new ItemMod(1, 1 ,3) {ModName = "Mana regeneration", Template_Text = "StExt_str_JwlrOpt_ManaRegen", ModRarity = 15,
                    Template_OnEquip = "StExt_Jwlr_ManaRegen += [Value]", Template_OnUnequip = "StExt_Jwlr_ManaRegen -= [Value]"  },
                new ItemMod(2, 5, 15) { ModName = "Summon HP bonus", Template_Text = "StExt_Str_ShowWeapStats_SumHp", ModRarity = 30,
                    Template_OnEquip = "StExt_SumBonus_Hp += [Value]", Template_OnUnequip = "StExt_SumBonus_Hp -= [Value]"  },
                new ItemMod(3, 3, 9) { ModName = "Summon stats bonus", Template_Text = "StExt_Str_ShowWeapStats_SumPwr", ModRarity = 30,
                    Template_OnEquip = "StExt_SumBonus_Stats += [Value]", Template_OnUnequip = "StExt_SumBonus_Stats -= [Value]"  },
                new ItemMod(4, 3, 9) { ModName = "Summon protection bonus", Template_Text = "StExt_Str_ShowWeapStats_SumProt", ModRarity = 30,
                    Template_OnEquip = "StExt_SumBonus_Prot += [Value]", Template_OnUnequip = "StExt_SumBonus_Prot -= [Value]"  },
                new ItemMod(5, 4, 12) { ModName = "Energy shield regen", Template_Text = "StExt_str_JwlrOpt_EsRegen", ModRarity = 30,
                    Template_OnEquip = "StExt_Jwlr_EsRegen += [Value]", Template_OnUnequip = "StExt_Jwlr_EsRegen -= [Value]"  },
                new ItemMod(6, 1, 15) { ModName = "Luck", Template_Text = "StExt_Str_ShowWeapStats_Luck", ModRarity = 10,
                    Template_OnEquip = "StExt_LootBonus += [Value]", Template_OnUnequip = "StExt_LootBonus -= [Value]" },
                new ItemMod(7, 5, 10) { ModName = "Str + Agility", Template_Text = "StExt_str_JwlrOpt_Stats", ModRarity = 25,
                    Template_OnEquip = "npc_changeattribute(self, atr_dexterity, [Value]);\r\n\tnpc_changeattribute(self, atr_strength, [Value])", Template_OnUnequip = "npc_changeattribute(self, atr_dexterity, -[Value]);\r\n\tnpc_changeattribute(self, atr_strength, -[Value])" },
                new ItemMod(8, 10, 30) { ModName = "Mana", Template_Text = "name_bonus_manamax", ModRarity = 70,
                    Template_OnEquip = "self.attribute[3] += [Value]", Template_OnUnequip = "self.attribute[3] -= [Value]" },
                new ItemMod(9, 10, 30) { ModName = "Hp", Template_Text = "name_bonus_hpmax", ModRarity = 70,
                    Template_OnEquip = "self.attribute[1] += [Value]", Template_OnUnequip = "self.attribute[1] -= [Value]" },
                new ItemMod(10, 5, 20) { ModName = "Hp + Mana", Template_Text = "StExt_str_JwlrOpt_StatsHpMp", ModRarity = 35,
                    Template_OnEquip = "self.attribute[1] += [Value];\r\n\tself.attribute[3] += [Value]", Template_OnUnequip = "self.attribute[1] -= [Value];\r\n\tself.attribute[3] -= [Value]" },
                new ItemMod(11, 5, 20) { ModName = "Int", Template_Text = "StExt_str_JwlrOpt_Int", ModRarity = 50,
                    Template_OnEquip = "rx_changeintquiet([Value])", Template_OnUnequip = "rx_changeintquiet(-[Value])" },
                new ItemMod(12, 15, 35) { ModName = "Energy shield", Template_Text = "StExt_str_JwlrOpt_Es", ModRarity = 50,
                    Template_OnEquip  = "StExt_Jwlr_Es += [Value]", Template_OnUnequip = "StExt_Jwlr_Es -= [Value]" },
                new ItemMod(13, 5, 10) { ModName = "Magic + Fire protection", Template_Text = "StExt_str_JwlrOpt_ProtMagic", ModRarity = 15,
                    Template_OnEquip = "self.protection[5] += [Value];\r\n\tself.protection[3] += [Value]", Template_OnUnequip = "self.protection[5] -= [Value];\r\n\tself.protection[3] -= [Value]" },
                new ItemMod(14, 5, 10) { Id = 1<<13, ModName = "Physics protection", Template_Text = "StExt_str_JwlrOpt_ProtWeap", ModRarity = 15,
                    Template_OnEquip = "self.protection[6] += [Value];\r\n\tself.protection[2] += [Value];\r\n\tself.protection[1] += [Value]", Template_OnUnequip = "self.protection[6] -= [Value];\r\n\tself.protection[2] -= [Value];\r\n\tself.protection[1] -= [Value]" },
                new ItemMod(15, 10, 20) { ModName = "Point protection", Template_Text = "rx_inv_descarmor_prot_point", ModRarity = 40,
                    Template_OnEquip = "self.protection[6] += [Value]", Template_OnUnequip = "self.protection[6] -= [Value]" },
                new ItemMod(16, 10, 20) { ModName = "Edge protection", Template_Text = "rx_inv_descarmor_prot_edge", ModRarity = 40,
                    Template_OnEquip = "self.protection[2] += [Value]", Template_OnUnequip = "self.protection[2] -= [Value]" },
                new ItemMod(17, 10, 20) { ModName = "Blunt protection", Template_Text = "rx_inv_descarmor_prot_blunt", ModRarity = 40,
                    Template_OnEquip = "self.protection[1] += [Value]", Template_OnUnequip = "self.protection[1] -= [Value]" },
                new ItemMod(18, 10, 20) { ModName = "Fly protection", Template_Text = "rx_shield_endurancelevel_str", ModRarity = 40,
                    Template_OnEquip = "self.protection[4] += [Value]", Template_OnUnequip = "self.protection[4] -= [Value]" },
                new ItemMod(19, 10, 20) { ModName = "Fire protection", Template_Text = "rx_inv_descarmor_prot_fire", ModRarity = 40,
                    Template_OnEquip = "self.protection[3] += [Value]", Template_OnUnequip = "self.protection[3] -= [Value]" },
                new ItemMod(20, 10, 20) { ModName = "Magic protection", Template_Text = "rx_inv_descarmor_prot_magic", ModRarity = 40,
                    Template_OnEquip = "self.protection[5] += [Value]", Template_OnUnequip = "self.protection[5] -= [Value]" },
                new ItemMod(21, 1, 2) { ModName = "Hp regeneration", Template_Text = "StExt_str_JwlrOpt_HpRegen", ModRarity = 25,
                    Template_OnEquip = "StExt_Jwlr_HpRegen += [Value]", Template_OnUnequip = "StExt_Jwlr_HpRegen -= [Value]"  },
                new ItemMod(22, 1, 1) { ModName = "Max summons", Template_Text = "StExt_Str_ShowWeapStats_SumCount", ModRarity = 15,
                    Template_OnEquip = "StExt_Jwlr_SumCount += [Value]", Template_OnUnequip = "StExt_Jwlr_SumCount -= [Value]"  },
                new ItemMod(23, 1, 2) { ModName = "Dodge chance", Template_Text = "StExt_str_JwlrOpt_Dodge", ModRarity = 40,
                    Template_OnEquip = "rx_dodgechange += [Value]", Template_OnUnequip = "rx_dodgechange -= [Value]" },
                new ItemMod(24, 15, 30) { ModName = "Energy shield barrier", Template_Text = "StExt_str_JwlrOpt_EsBarier", ModRarity = 30,
                    Template_OnEquip = "StExt_Jwlr_EsBarrier += [Value]", Template_OnUnequip = "StExt_Jwlr_EsBarrier -= [Value]" },
                new ItemMod(25, 3, 9) { ModName = "Speed modifier", Template_Text = "StExt_str_JwlrOpt_SpeedMod", ModRarity = 10,
                    Template_OnEquip = "additionalacceleration += [Value]", Template_OnUnequip = "additionalacceleration -= [Value]" },
                new ItemMod(26, 1, 3) { ModName = "2H bonus", Template_Text = "StExt_str_JwlrOpt_2hBonus", ModRarity = 20,
                    Template_OnEquip = "b_addfightskill(self, npc_talent_2h, [Value])", Template_OnUnequip = "b_addfightskill(self, npc_talent_2h, -[Value])" },
                new ItemMod(27, 1, 3) { ModName = "1H bonus", Template_Text = "StExt_str_JwlrOpt_1hBonus", ModRarity = 20,
                    Template_OnEquip = "b_addfightskill(self, npc_talent_1h, [Value])", Template_OnUnequip = "b_addfightskill(self, npc_talent_1h, -[Value])" },
                new ItemMod(28, 1, 3) { ModName = "Bow bonus", Template_Text = "StExt_str_JwlrOpt_BowBonus", ModRarity = 20,
                    Template_OnEquip = "b_addfightskill(self, npc_talent_bow, [Value])", Template_OnUnequip = "b_addfightskill(self, npc_talent_bow, -[Value])" },
                new ItemMod(29, 1, 3) { ModName = "Crossbow bonus", Template_Text = "StExt_str_JwlrOpt_CrossbowBonus", ModRarity = 20,
                    Template_OnEquip = "b_addfightskill(self, npc_talent_crossbow, [Value])", Template_OnUnequip = "b_addfightskill(self, npc_talent_crossbow, -[Value])" },
                new ItemMod(30, 10, 50) { ModName = "Aura bonus", Template_Text = "StExt_str_Jwlr_AuraPwrDist", ModRarity = 20,
                    Template_OnEquip = "StExt_Jwlr_AuraPwrDist += [Value]", Template_OnUnequip = "StExt_Jwlr_AuraPwrDist -= [Value]" },
                new ItemMod(31, 1, 1) { ModName = "Poision immune", Template_Text = "StExt_str_Jwlr_PoisionResist", ModRarity = 5,
                    Template_OnEquip = "StExt_Jwlr_PoisionResist += [Value]", Template_OnUnequip = "StExt_Jwlr_PoisionResist -= [Value]" },
                new ItemMod(32, 1, 1) { ModName = "Curse immune", Template_Text = "StExt_str_Jwlr_CurseResist", ModRarity = 5,
                    Template_OnEquip = "StExt_Jwlr_CurseResist += [Value]", Template_OnUnequip = "StExt_Jwlr_CurseResist -= [Value]" },
                new ItemMod(33, 10, 25) { ModName = "Death magic bonus", Template_Text = "StExt_Str_DeathMasteryDamage", ModRarity = 5,
                    Template_OnEquip = "StExt_Jwlr_DeathMasteryDamage += [Value]", Template_OnUnequip = "StExt_Jwlr_DeathMasteryDamage -= [Value]" },
                new ItemMod(34, 10, 25) { ModName = "Life magic bonus", Template_Text = "StExt_Str_LifeMasteryDamage", ModRarity = 5,
                    Template_OnEquip = "StExt_Jwlr_LifeMasteryDamage += [Value]", Template_OnUnequip = "StExt_Jwlr_LifeMasteryDamage -= [Value]" },
                new ItemMod(35, 10, 25) { ModName = "Light magic bonus", Template_Text = "StExt_Str_LightMasteryDamage", ModRarity = 5,
                    Template_OnEquip = "StExt_Jwlr_LightMasteryDamage += [Value]", Template_OnUnequip = "StExt_Jwlr_LightMasteryDamage -= [Value]" },
                new ItemMod(36, 10, 25) { ModName = "Dark magic bonus", Template_Text = "StExt_Str_DarkMasteryDamage", ModRarity = 5,
                    Template_OnEquip = "StExt_Jwlr_DarkMasteryDamage += [Value]", Template_OnUnequip = "StExt_Jwlr_DarkMasteryDamage -= [Value]" },
                new ItemMod(37, 10, 25) { ModName = "Electric magic bonus", Template_Text = "StExt_Str_ElectricMasteryDamage", ModRarity = 5,
                    Template_OnEquip = "StExt_Jwlr_ElectricMasteryDamage += [Value]", Template_OnUnequip = "StExt_Jwlr_ElectricMasteryDamage -= [Value]" },
                new ItemMod(38, 10, 25) { ModName = "Air magic bonus", Template_Text = "StExt_Str_AirMasteryDamage", ModRarity = 5,
                    Template_OnEquip = "StExt_Jwlr_AirMasteryDamage += [Value]", Template_OnUnequip = "StExt_Jwlr_AirMasteryDamage -= [Value]" },
                new ItemMod(39, 10, 25) { ModName = "Earth magic bonus", Template_Text = "StExt_Str_EarthMasteryDamage", ModRarity = 5,
                    Template_OnEquip = "StExt_Jwlr_EarthMasteryDamage += [Value]", Template_OnUnequip = "StExt_Jwlr_EarthMasteryDamage -= [Value]" },
                new ItemMod(40, 10, 25) { ModName = "Ice magic bonus", Template_Text = "StExt_Str_IceMasteryDamage", ModRarity = 5,
                    Template_OnEquip = "StExt_Jwlr_IceMasteryDamage += [Value]", Template_OnUnequip = "StExt_Jwlr_IceMasteryDamage -= [Value]" },
                new ItemMod(41, 10, 25) { ModName = "Fire magic bonus", Template_Text = "StExt_Str_FireMasteryDamage", ModRarity = 5,
                    Template_OnEquip = "StExt_Jwlr_FireMasteryDamage += [Value]", Template_OnUnequip = "StExt_Jwlr_FireMasteryDamage -= [Value]" },
            };
        }

        [Serializable]
        class ItemsModsContainer
        {
            public ItemMod[] ItemMods { get; set; } = new ItemMod[] { };

            public string[] ItemsPrefixes { get; set; } = new string[] { };
            public string[] ItemsAfixes { get; set; } = new string[] { };
            public string[] ItemsSufixes { get; set; } = new string[] { };
        }
    }
}
