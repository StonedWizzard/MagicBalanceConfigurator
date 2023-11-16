using System;
using System.Collections.Generic;

namespace MagicBalanceConfigurator.Generators
{
    internal class Weap_1h_T2_Generator : BaseWeaponGenerator
    {
        public Weap_1h_T2_Generator(RandomController controller) : base(controller, Consts.Weap_1h_T2_FileName) 
        {
            TierPrefix = CommonTemplates.TierPrefix_T2;
            ItemIdPrefix = CommonTemplates.Weapon_1h_IdPrefix;
            ItemType = CommonTemplates.Weapon_1h_RandSufix;
            ModPower = 1.25;
            ItemsPrice = 1000;
            BaseOnEquipFunc = "equip_1h_medium();";
            BaseOnUnEquipFunc = "unequip_1h_medium();";
            SetWeaponDamageRange(75, 125);
            SetWeaponRangeRange(70, 90);
            SetItemCondRange(50, 100);
            SetModsCountRange(2, 3);
        }

        protected override List<ItemTemplatePreset> BuildItemTemplatePresets() => new List<ItemTemplatePreset>()
        {
            // swords
            new ItemTemplatePreset()
            {
                ItemCondStat = CommonTemplates.ItemCondAtr_Str,
                WeaponDamageType = "dam_edge",
                ItemType = "item_swd",
                Visuals = new string[] { "ItMw_ShortSword1_New.3DS", "ITMW_NEWSIMPLESWORD_01.3DS", "ItMw_Schwert_New.3DS", 
                    "NEW_STL_BROADSWORD.3DS",  "ITMW_HARAD_SWORD_02.3DS", "ItMw_RubinSword.3DS", "ITMW_1H_DJG_CRAFT_01.3DS", "ITMW_1H_DJG_CRAFT_02.3DS",
                    "ITMW_SWORD_NEW_01.3DS", "ITMW_SWORD_NEW_02.3DS", "ITMW_BANE_1H.3DS" }
            },
            // dex swords
            new ItemTemplatePreset()
            {
                ItemCondStat = CommonTemplates.ItemCondAtr_Agi,
                WeaponDamageType = "dam_edge",
                ItemType = "item_swd",
                Visuals = new string[] { "ItMw_PirCutlas.3DS", "ItMW_1H_DexSword_03.3DS", "ITMW_1H_PIRSWORD_02.3DS", "ItMw_1H_Machete_02.3DS",
                    "ITMW_BANE_1H.3DS", "ItMW_1H_DexSword_06.3DS", "ItMW_1H_DexSword_03.3DS"},
                SpecialSection = "setitemvartrue([IdPrefix][Id], bit_item_dex_sword);",
                AltOnEquipFunc = "equip_1h_light();",
                AltOnUnEquipFunc = "unequip_1h_light();"
            },
            // axes
            new ItemTemplatePreset()
            {
                ItemCondStat = CommonTemplates.ItemCondAtr_Str,
                WeaponDamageType = "dam_edge",
                ItemType = "item_axe",
                Visuals = new string[] { "ItMw_Doppelaxt_New.3DS", "ItMw_Doppelaxt_New_NB.3DS", "ITMW_1H_PIRAXE_01.3DS" },
                WeaponExtraRange = -10
            },
            // maces
            new ItemTemplatePreset()
            {
                ItemCondStat = CommonTemplates.ItemCondAtr_Str,
                WeaponDamageType = "dam_blunt",
                ItemType = "item_axe",
                Visuals = new string[] { "ItMw_Nagelkeule_New.3DS", "ItMw_Morgenstern_New.3DS", "ItMw_Streitkolben_New.3DS", "ItMw_Kriegskeule_New.3DS" },
                AltOnEquipFunc = "equip_1h_medium();",
                AltOnUnEquipFunc = "unequip_1h_medium();",
                WeaponExtraRange = -10
            },
            // rapiers
            new ItemTemplatePreset()
            {
                ItemCondStat = CommonTemplates.ItemCondAtr_Agi,
                WeaponDamageType = "dam_edge",
                ItemType = "item_swd",
                Visuals = new string[] { "THIEFRAPIER_01.3DS", "THIEFRAPIER_02.3DS", "ITMW_SPAGE_04.3DS", "ITMW_SPAGE_03.3DS" },
                SpecialSection = "setitemvartrue([IdPrefix][Id], bit_item_pierce_damage);",
                AltOnEquipFunc = "equip_1h_light_dex();",
                AltOnUnEquipFunc = "unequip_1h_light_dex();"
            }
        };

        public override string GetTemplate() => CommonTemplates.WeaponTemplate;
    }
}
