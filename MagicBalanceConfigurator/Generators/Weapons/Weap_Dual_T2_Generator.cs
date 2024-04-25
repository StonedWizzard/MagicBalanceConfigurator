using System;
using System.Collections.Generic;

namespace MagicBalanceConfigurator.Generators
{
    internal class Weap_Dual_T2_Generator : BaseDualWeaponGenerator
    {
        public Weap_Dual_T2_Generator(RandomController controller) : base(controller, Consts.Weap_dual_T2_FileName) 
        {
            TierPrefix = CommonTemplates.TierPrefix_T2;
            ItemIdPrefix = CommonTemplates.Weapon_dual_IdPrefix;
            ItemType = CommonTemplates.Weapon_dual_RandSufix;
            ModPower = 1.25;
            ItemsPrice = 1000;
            SetWeaponDamageRange(75, 125);
            SetWeaponRangeRange(70, 90);
            SetItemCondRange(50, 100);
            SetModsCountRange(2, 3);
            ProhibitedMods = new List<int> { 226, 228, 229 };
            ItemModType = "StExt_ItemType_MeleeWeap";
        }

        protected override List<ItemTemplatePreset> BuildItemTemplatePresets() => new List<ItemTemplatePreset>()
        {
            new ItemTemplatePreset()
            {
                ItemCondStat = CommonTemplates.ItemCondAtr_Stamina,
                WeaponDamageType = "dam_edge",
                ItemType = String.Empty,
                Visuals = new string[] { "ITMW_1H_DUAL_IRON_RIGHT.3DS", "ITMW_1H_DUAL_OLD_RIGHT.3DS", "ITMW_1H_DUAL_STEEL_RIGHT.3DS", "ITMW_1H_DUAL_CURVED_RIGHT.3DS",
                    "ITMW_1H_DUAL_ORE_RIGHT.3DS", "ItMw_1H_Ancient_Right.3DS" },
                VisualsExtra = new string[] {"ITMW_1H_DUAL_IRON_LEFT.3DS", "ITMW_1H_DUAL_OLD_LEFT.3DS", "ITMW_1H_DUAL_STEEL_LEFT.3DS","ITMW_1H_DUAL_CURVED_LEFT.3DS",
                    "ITMW_1H_DUAL_ORE_LEFT.3DS", "ItMw_1H_Ancient_Left.3DS"  },
            },
            new ItemTemplatePreset()
            {
                ItemCondStat = CommonTemplates.ItemCondAtr_Mana,
                WeaponDamageType = "dam_magic",
                ItemType = String.Empty,
                Visuals = new string[] { "ITMW_1H_DUAL_IRON_RIGHT.3DS", "ITMW_1H_DUAL_OLD_RIGHT.3DS", "ITMW_1H_DUAL_STEEL_RIGHT.3DS", "ITMW_1H_DUAL_CURVED_RIGHT.3DS",
                    "ITMW_1H_DUAL_ORE_RIGHT.3DS", "ItMw_1H_Ancient_Right.3DS" },
                VisualsExtra = new string[] {"ITMW_1H_DUAL_IRON_LEFT.3DS", "ITMW_1H_DUAL_OLD_LEFT.3DS", "ITMW_1H_DUAL_STEEL_LEFT.3DS","ITMW_1H_DUAL_CURVED_LEFT.3DS",
                    "ITMW_1H_DUAL_ORE_LEFT.3DS", "ItMw_1H_Ancient_Left.3DS"  },
                SpecialSection = "setitemvartrue([IdPrefix][Id]_right, bit_item_mag_sword);",
                SpecialSectionExtra = "setitemvartrue([IdPrefix][Id]_left, bit_item_mag_sword);"
            },
            new ItemTemplatePreset()
            {
                ItemCondStat = CommonTemplates.ItemCondAtr_Mana,
                WeaponDamageType = "dam_fire",
                ItemType = String.Empty,
                Visuals = new string[] { "ITMW_1H_DUAL_IRON_RIGHT.3DS", "ITMW_1H_DUAL_OLD_RIGHT.3DS", "ITMW_1H_DUAL_STEEL_RIGHT.3DS", "ITMW_1H_DUAL_CURVED_RIGHT.3DS",
                    "ITMW_1H_DUAL_ORE_RIGHT.3DS", "ItMw_1H_Ancient_Right.3DS" },
                VisualsExtra = new string[] {"ITMW_1H_DUAL_IRON_LEFT.3DS", "ITMW_1H_DUAL_OLD_LEFT.3DS", "ITMW_1H_DUAL_STEEL_LEFT.3DS","ITMW_1H_DUAL_CURVED_LEFT.3DS",
                    "ITMW_1H_DUAL_ORE_LEFT.3DS", "ItMw_1H_Ancient_Left.3DS"  },
                SpecialSection = "setitemvartrue([IdPrefix][Id]_right, bit_item_mag_sword);",
                SpecialSectionExtra = "setitemvartrue([IdPrefix][Id]_left, bit_item_mag_sword);"
            },
            new ItemTemplatePreset()
            {
                ItemCondStat = CommonTemplates.ItemCondAtr_Mana,
                WeaponDamageType = "dam_fly",
                ItemType = String.Empty,
                Visuals = new string[] { "ITMW_1H_DUAL_IRON_RIGHT.3DS", "ITMW_1H_DUAL_OLD_RIGHT.3DS", "ITMW_1H_DUAL_STEEL_RIGHT.3DS", "ITMW_1H_DUAL_CURVED_RIGHT.3DS",
                    "ITMW_1H_DUAL_ORE_RIGHT.3DS", "ItMw_1H_Ancient_Right.3DS" },
                VisualsExtra = new string[] {"ITMW_1H_DUAL_IRON_LEFT.3DS", "ITMW_1H_DUAL_OLD_LEFT.3DS", "ITMW_1H_DUAL_STEEL_LEFT.3DS","ITMW_1H_DUAL_CURVED_LEFT.3DS",
                    "ITMW_1H_DUAL_ORE_LEFT.3DS", "ItMw_1H_Ancient_Left.3DS"  },
                SpecialSection = "setitemvartrue([IdPrefix][Id]_right, bit_item_mag_sword);",
                SpecialSectionExtra = "setitemvartrue([IdPrefix][Id]_left, bit_item_mag_sword);"
            },
        };
    }
}
