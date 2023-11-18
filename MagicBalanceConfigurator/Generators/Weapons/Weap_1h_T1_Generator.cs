using System;
using System.Collections.Generic;

namespace MagicBalanceConfigurator.Generators
{
    internal class Weap_1h_T1_Generator : BaseWeaponGenerator
    {
        public Weap_1h_T1_Generator(RandomController controller) : base(controller, Consts.Weap_1h_T1_FileName) 
        {
            TierPrefix = CommonTemplates.TierPrefix_T1;
            ItemIdPrefix = CommonTemplates.Weapon_1h_IdPrefix;
            ItemType = CommonTemplates.Weapon_1h_RandSufix;
            ModPower = 0.75;
            ItemsPrice = 500;
            BaseOnEquipFunc = "equip_1h_light();";
            BaseOnUnEquipFunc = "unequip_1h_light();";
            SetWeaponDamageRange(50, 75);
            SetWeaponRangeRange(60, 80);
            SetItemCondRange(25, 50);
            SetModsCountRange(1, 2);
            ProhibitedMods = new List<int> { 226, 228, 229 };
        }

        protected override List<ItemTemplatePreset> BuildItemTemplatePresets() => new List<ItemTemplatePreset>()
        {
            // swords
            new ItemTemplatePreset()
            {
                ItemNamePlaceholder = "Меч",
                ItemCondStat = CommonTemplates.ItemCondAtr_Str,
                WeaponDamageType = "dam_edge",
                ItemType = "item_swd",
                Visuals = new string[] { "ItMw_020_1h_sword_old_01.3DS", "ItMw_ShortSword2_New.3DS", 
                    "ItMw_ShortSword3_New.3DS", "ItMw_ShortSword2_New.3DS", "ItMw_ShortSword1_New.3DS", "ITMW_NEWSIMPLESWORD_01.3DS" }
            },
            // dex swords
            new ItemTemplatePreset()
            {
                ItemNamePlaceholder = "Меч",
                ItemCondStat = CommonTemplates.ItemCondAtr_Agi,
                WeaponDamageType = "dam_edge",
                ItemType = "item_swd",
                Visuals = new string[] { "ItMw_020_1h_sword_old_01.3DS", "ItMw_ShortSword2_New.3DS", "ItMw_ShortSword3_New.3DS",
                    "ItMw_PirCutlas.3DS", "ItMW_1H_DexSword_17.3DS" },
                SpecialSection = "setitemvartrue([IdPrefix][Id], bit_item_dex_sword);",
                AltOnEquipFunc = "equip_1h_light();",
                AltOnUnEquipFunc = "unequip_1h_light();",
            },
            // axes
            new ItemTemplatePreset()
            {
                ItemNamePlaceholder = "Топор",
                ItemCondStat = CommonTemplates.ItemCondAtr_Str,
                WeaponDamageType = "dam_edge",
                ItemType = "item_axe",
                Visuals = new string[] { "ITMW_1H_G4_AXESMALL_01.3DS", "NB_AXE_RUDE_01.3DS", "ItMw_Doppelaxt_New.3DS", "ITMW_1H_G4_AXESMALL_01.3DS",
                    "ItMw_010_1h_Club_01.3DS" },
                WeaponExtraRange = -5
            },
            // maces
            new ItemTemplatePreset()
            {
                ItemNamePlaceholder = "Булава",
                ItemCondStat = CommonTemplates.ItemCondAtr_Str,
                WeaponDamageType = "dam_blunt",
                ItemType = "item_axe",
                Visuals = new string[] { "G3_Item_Tools_Hammer_Sledge_01.3DS", "ITMW_1H_G3_SMITHHAMMER_01.3DS", "Itmw_008_1h_pole_01.3ds", "ItMw_StoneHammer.3DS" },
                AltOnEquipFunc = "equip_1h_medium();",
                AltOnUnEquipFunc = "unequip_1h_medium();",
                WeaponExtraRange = -5
            },
            // rapiers
            new ItemTemplatePreset()
            {
                ItemNamePlaceholder = "Шпага",
                ItemCondStat = CommonTemplates.ItemCondAtr_Agi,
                WeaponDamageType = "dam_edge",
                ItemType = "item_swd",
                Visuals = new string[] { "ITMW_NB_RAPIER_VERYOLD.3DS", "ITMW_SPAGE_OLD.3DS", "ITMW_SPAGE_04.3DS", "ITMW_SPAGE_03.3DS" },
                SpecialSection = "setitemvartrue([IdPrefix][Id], bit_item_pierce_damage);",   
                AltOnEquipFunc = "equip_1h_light_dex();",
                AltOnUnEquipFunc = "unequip_1h_light_dex();"
            }
        };

        public override string GetTemplate() => CommonTemplates.WeaponTemplate;
    }
}
