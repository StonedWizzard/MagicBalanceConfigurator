using System;
using System.Collections.Generic;

namespace MagicBalanceConfigurator.Generators
{
    internal class Weap_1h_T4_Generator : BaseWeaponGenerator
    {
        public Weap_1h_T4_Generator(RandomController controller) : base(controller, Consts.Weap_1h_T4_FileName) 
        {
            TierPrefix = CommonTemplates.TierPrefix_T4;
            ItemIdPrefix = CommonTemplates.Weapon_1h_IdPrefix;
            ItemType = CommonTemplates.Weapon_1h_RandSufix;
            ModPower = 3;
            ItemsPrice = 2500;
            BaseOnEquipFunc = "equip_1h_heavy();";
            BaseOnUnEquipFunc = "unequip_1h_heavy();";
            SetWeaponDamageRange(225, 350);
            SetWeaponRangeRange(95, 120);
            SetItemCondRange(150, 250);
            SetModsCountRange(4, 5);
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
                Visuals = new string[] { "ITMW_NEWSIMPLESWORD_01.3DS", "ItMw_1h_Pal_Sword_New.3DS", "ITMW_1H_BLACKSWORD.3DS", "ITMW_HARAD_SWORD_01.3DS", "ItMw_037_1h_sword_long_02.3DS",
                    "ITMW_HARAD_SWORD_02.3DS", "ItMw_RubinSword.3DS", "ItMw_ElBastardo_New.3DS", "ITMW_1H_DJG_CRAFT_01.3DS", "ITMW_1H_DJG_CRAFT_02.3DS", "ITMW_1H_DJG_CRAFT_03.3DS", "ITMW_1H_DJG_CRAFT_04.3DS",
                    "ITMW_SWORD_NEW_04.3DS", "ITMW_SWORD_NEW_03.3DS", "ItMw_1H_PALBLESSED_01_NEW.3ds", "ITMW_BANE_1H.3DS", "ItMw_1H_SilverBane_01.3DS", "ItMw_1H_GodBane_01.3ds"}
            },
            // dex swords
            new ItemTemplatePreset()
            {
                ItemNamePlaceholder = "Меч",
                ItemCondStat = CommonTemplates.ItemCondAtr_Agi,
                WeaponDamageType = "dam_edge",
                ItemType = "item_swd",
                Visuals = new string[] { "ItMW_1H_DexSword_03.3DS", "ITMW_1H_PIRSWORD_02.3DS", "ItMw_1H_Machete_02.3DS", "ITMW_1H_DRAKESABEL_NB.3DS",
                    "ITMW_BANE_1H.3DS", "ItMW_1H_DexSword_06.3DS", "ItMW_1H_DexSword_09.3DS", "ItMW_1H_DexSword_10.3DS", "ItMW_1H_DexSword_11.3DS", "ItMW_1H_DexSword_12.3DS",
                    "ItMW_1H_DexSword_13.3DS", "ItMW_1H_DexSword_14.3DS", "ItMW_1H_DexSword_15.3DS", "ItMW_1H_DexSword_16.3DS"},
                SpecialSection = "setitemvartrue([IdPrefix][Id], bit_item_dex_sword);",
                AltOnEquipFunc = "equip_1h_medium();",
                AltOnUnEquipFunc = "unequip_1h_medium();"
            },
            // axes
            new ItemTemplatePreset()
            {
                ItemNamePlaceholder = "Топор",
                ItemCondStat = CommonTemplates.ItemCondAtr_Str,
                WeaponDamageType = "dam_edge",
                ItemType = "item_axe",
                Visuals = new string[] { "ItMw_Doppelaxt_New.3DS", "ItMw_Doppelaxt_New_NB.3DS", "ITMW_1H_PIRAXE_01.3DS",
                    "ItMw_DemonFist_New.3DS" },
                WeaponExtraRange = -10
            },
            // maces
            new ItemTemplatePreset()
            {
                ItemNamePlaceholder = "Булава",
                ItemCondStat = CommonTemplates.ItemCondAtr_Str,
                WeaponDamageType = "dam_blunt",
                ItemType = "item_axe",
                Visuals = new string[] { "ItMw_Nagelkeule_New.3DS", "ItMw_Nagelkeule2_New.3DS",  "ItMw_Morgenstern_New.3DS", "ItMw_Streitkolben_New.3DS",
                    "ItMw_Steinbrecher_New.3DS", "ItMw_Kriegskeule_New.3DS", "ItMw_Spicker_New.3DS", "ITMW_1H_MAKEDHAMMER2_S_NORDIC.3DS", "ItMw_Kriegshammer2_New.3DS",
                "ITMW_STINGMACE.3DS", "ITMW_1H_MOLAGBAR.3DS", "ItMw_Inquisitor_New.3DS", "ITMI_TARACOTHAMMER_NEW.3ds", "1h_stormhammer.3DS" },
                AltOnEquipFunc = "equip_1h_veryheavy();",
                AltOnUnEquipFunc = "unequip_1h_veryheavy();",
                WeaponExtraRange = -10
            },
            // rapiers
            new ItemTemplatePreset()
            {
                ItemNamePlaceholder = "Шпага",
                ItemCondStat = CommonTemplates.ItemCondAtr_Agi,
                WeaponDamageType = "dam_edge",
                ItemType = "item_swd",
                Visuals = new string[] { "ItMw_065_1h_SwordCane_02.3ds", "ITMW_SPAGE_05.3DS", "ITMW_SPAGE_06.3DS", "ITMW_SPAGE_07.3DS", "ItMw_018_1h_SwordCane_01.3ds",
                    "ITMW_SILVERRAPIER.3DS", "THIEFRAPIER_08.3DS", "ARENABOSS_5_RAPIER.3DS", "ItMw_1H_BloodSpage.3DS"},
                SpecialSection = "setitemvartrue([IdPrefix][Id], bit_item_pierce_damage);",
                AltOnEquipFunc = "equip_1h_light_dex();",
                AltOnUnEquipFunc = "unequip_1h_light_dex();"
            }
        };

        public override string GetTemplate() => CommonTemplates.WeaponTemplate;
    }
}
