using System;
using System.Collections.Generic;

namespace MagicBalanceConfigurator.Generators
{
    internal class Weap_Dual_T3_Generator : BaseDualWeaponGenerator
    {
        public Weap_Dual_T3_Generator(RandomController controller) : base(controller, Consts.Weap_dual_T3_FileName) 
        {
            TierPrefix = CommonTemplates.TierPrefix_T3;
            ItemIdPrefix = CommonTemplates.Weapon_dual_IdPrefix;
            ItemType = CommonTemplates.Weapon_dual_RandSufix;
            ModPower = 2;
            ItemsPrice = 1500;
            SetWeaponDamageRange(125, 225);
            SetWeaponRangeRange(85, 110);
            SetItemCondRange(100, 150);
            SetModsCountRange(3, 4);
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
                Visuals = new string[] { "ITMW_1H_DUAL_CURVED_RIGHT.3DS", "ITMW_1H_DUAL_ORE_RIGHT.3DS", "ItMw_1H_Ancient_Right.3DS", "ITMW_1H_DUAL_TWILIGHT_RIGHT.3DS",
                    "ItMw_ArabicSword_01.3DS", "ITMW_KATANA_01.3DS", "ItMw_1H_ChelDrak_Right.3DS", "ItMw_1H_IlArahBlade.3DS", },
                VisualsExtra = new string[] { "ITMW_1H_DUAL_CURVED_LEFT.3DS", "ITMW_1H_DUAL_ORE_LEFT.3DS", "ItMw_1H_Ancient_Left.3DS", "ITMW_1H_DUAL_TWILIGHT_LEFT.3DS", 
                    "ItMw_1H_AssBlade_Left.3DS", "ITMW_KATANA_02.3DS", "ITMW_1H_BELIARSWORD_LEFT.3DS", "ItMw_1H_ChelDrak_Left.3DS", "ItMw_1H_IlArahBlade_Left.3DS",
                    "ItMw_1H_ChelDrak_Left.3DS", "ItMw_1H_IlArahBlade_Left.3DS" },
            },
            new ItemTemplatePreset()
            {
                ItemCondStat = CommonTemplates.ItemCondAtr_Mana,
                WeaponDamageType = "dam_magic",
                ItemType = String.Empty,
                Visuals = new string[] { "ITMW_1H_DUAL_CURVED_RIGHT.3DS", "ITMW_1H_DUAL_ORE_RIGHT.3DS", "ItMw_1H_Ancient_Right.3DS", "ITMW_1H_DUAL_TWILIGHT_RIGHT.3DS",
                    "ItMw_ArabicSword_01.3DS", "ITMW_KATANA_01.3DS", "ItMw_1H_ChelDrak_Right.3DS", "ItMw_1H_IlArahBlade.3DS", },
                VisualsExtra = new string[] { "ITMW_1H_DUAL_CURVED_LEFT.3DS", "ITMW_1H_DUAL_ORE_LEFT.3DS", "ItMw_1H_Ancient_Left.3DS", "ITMW_1H_DUAL_TWILIGHT_LEFT.3DS",
                    "ItMw_1H_AssBlade_Left.3DS", "ITMW_KATANA_02.3DS", "ITMW_1H_BELIARSWORD_LEFT.3DS", "ItMw_1H_ChelDrak_Left.3DS", "ItMw_1H_IlArahBlade_Left.3DS",
                    "ItMw_1H_ChelDrak_Left.3DS", "ItMw_1H_IlArahBlade_Left.3DS" },
                SpecialSection = "setitemvartrue([IdPrefix][Id]_right, bit_item_mag_sword);",
                SpecialSectionExtra = "setitemvartrue([IdPrefix][Id]_left, bit_item_mag_sword);"
            },
            new ItemTemplatePreset()
            {
                ItemCondStat = CommonTemplates.ItemCondAtr_Mana,
                WeaponDamageType = "dam_fire",
                ItemType = String.Empty,
                Visuals = new string[] { "ITMW_1H_DUAL_CURVED_RIGHT.3DS", "ITMW_1H_DUAL_ORE_RIGHT.3DS", "ItMw_1H_Ancient_Right.3DS", "ITMW_1H_DUAL_TWILIGHT_RIGHT.3DS",
                    "ItMw_ArabicSword_01.3DS", "ITMW_KATANA_01.3DS", "ItMw_1H_ChelDrak_Right.3DS", "ItMw_1H_IlArahBlade.3DS", },
                VisualsExtra = new string[] { "ITMW_1H_DUAL_CURVED_LEFT.3DS", "ITMW_1H_DUAL_ORE_LEFT.3DS", "ItMw_1H_Ancient_Left.3DS", "ITMW_1H_DUAL_TWILIGHT_LEFT.3DS",
                    "ItMw_1H_AssBlade_Left.3DS", "ITMW_KATANA_02.3DS", "ITMW_1H_BELIARSWORD_LEFT.3DS", "ItMw_1H_ChelDrak_Left.3DS", "ItMw_1H_IlArahBlade_Left.3DS",
                    "ItMw_1H_ChelDrak_Left.3DS", "ItMw_1H_IlArahBlade_Left.3DS" },
                SpecialSection = "setitemvartrue([IdPrefix][Id]_right, bit_item_mag_sword);",
                SpecialSectionExtra = "setitemvartrue([IdPrefix][Id]_left, bit_item_mag_sword);"
            },
            new ItemTemplatePreset()
            {
                ItemCondStat = CommonTemplates.ItemCondAtr_Mana,
                WeaponDamageType = "dam_fly",
                ItemType = String.Empty,
                Visuals = new string[] { "ITMW_1H_DUAL_CURVED_RIGHT.3DS", "ITMW_1H_DUAL_ORE_RIGHT.3DS", "ItMw_1H_Ancient_Right.3DS", "ITMW_1H_DUAL_TWILIGHT_RIGHT.3DS",
                    "ItMw_ArabicSword_01.3DS", "ITMW_KATANA_01.3DS", "ItMw_1H_ChelDrak_Right.3DS", "ItMw_1H_IlArahBlade.3DS", },
                VisualsExtra = new string[] { "ITMW_1H_DUAL_CURVED_LEFT.3DS", "ITMW_1H_DUAL_ORE_LEFT.3DS", "ItMw_1H_Ancient_Left.3DS", "ITMW_1H_DUAL_TWILIGHT_LEFT.3DS",
                    "ItMw_1H_AssBlade_Left.3DS", "ITMW_KATANA_02.3DS", "ITMW_1H_BELIARSWORD_LEFT.3DS", "ItMw_1H_ChelDrak_Left.3DS", "ItMw_1H_IlArahBlade_Left.3DS",
                    "ItMw_1H_ChelDrak_Left.3DS", "ItMw_1H_IlArahBlade_Left.3DS" },
                SpecialSection = "setitemvartrue([IdPrefix][Id]_right, bit_item_mag_sword);",
                SpecialSectionExtra = "setitemvartrue([IdPrefix][Id]_left, bit_item_mag_sword);"
            },
        };
    }
}
