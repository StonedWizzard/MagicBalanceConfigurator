using System;
using System.Collections.Generic;

namespace MagicBalanceConfigurator.Generators
{
    internal class Weap_Bow_T2_Generator : BaseWeaponGenerator
    {
        public Weap_Bow_T2_Generator(RandomController controller) : base(controller, Consts.Weap_bow_T2_FileName) 
        {
            TierPrefix = CommonTemplates.TierPrefix_T2;
            ItemIdPrefix = CommonTemplates.Weapon_bow_IdPrefix;
            ItemType = CommonTemplates.Weapon_bow_RandSufix;
            ItemName = "Лук";
            ModPower = 1;
            ItemsPrice = 1000;
            BaseOnEquipFunc = "equip_bow_medium();";
            BaseOnUnEquipFunc = "equip_bow_medium();";
            SetWeaponDamageRange(60, 120);
            SetItemCondRange(50, 75);
            SetModsCountRange(2, 3);
        }

        protected override List<ItemTemplatePreset> BuildItemTemplatePresets() => new List<ItemTemplatePreset>()
        {
            // bows
            new ItemTemplatePreset()
            {
                ItemCondStat = CommonTemplates.ItemCondAtr_Agi,
                WeaponDamageType = "dam_point",
                ItemType = "item_bow",
                Visuals = new string[] { "ItRw_Bow_M_02.mms", "ItRw_Bow_M_04.mms", "ItRw_Bow_H_02.mms", "ItRw_Bow_H_03.mms",
                    "ITRW_BOW_S_IRON.mms", "ItRw_Bow_M_01.mms", "ITRW_G3_LONG_BOW_01.mms", "ITRW_KMR_DARKLONG_BOW_01.mms", 
                    "ITRW_G3_LONG_BOW_02.mms", "ITRW_G3_SILENTDEATH_BOW_01.mms", "ITRW_G4_OAK_BOW_01.mms" },
                ExtraConditions = new string[] { CommonTemplates.ItemCondAtr_Bow },
            },
            new ItemTemplatePreset()
            {
                ItemCondStat = CommonTemplates.ItemCondAtr_Str,
                WeaponDamageType = "dam_point",
                ItemType = "item_bow",
                Visuals = new string[] { "ItRw_Bow_M_02.mms", "ItRw_Bow_M_04.mms", "ItRw_Bow_H_02.mms", "ItRw_Bow_H_03.mms",
                    "ITRW_BOW_S_IRON.mms", "ItRw_Bow_M_01.mms", "ITRW_G3_LONG_BOW_01.mms", "ITRW_KMR_DARKLONG_BOW_01.mms",
                    "ITRW_G3_LONG_BOW_02.mms", "ITRW_G3_SILENTDEATH_BOW_01.mms", "ITRW_G4_OAK_BOW_01.mms" },
                ExtraConditions = new string[] { CommonTemplates.ItemCondAtr_Bow },
            },
            new ItemTemplatePreset()
            {
                ItemCondStat = CommonTemplates.ItemCondAtr_Bow,
                WeaponDamageType = "dam_point",
                ItemType = "item_bow",
                Visuals = new string[] { "ItRw_Bow_M_02.mms", "ItRw_Bow_M_04.mms", "ItRw_Bow_H_02.mms", "ItRw_Bow_H_03.mms",
                    "ITRW_BOW_S_IRON.mms", "ItRw_Bow_M_01.mms", "ITRW_G3_LONG_BOW_01.mms", "ITRW_KMR_DARKLONG_BOW_01.mms",
                    "ITRW_G3_LONG_BOW_02.mms", "ITRW_G3_SILENTDEATH_BOW_01.mms", "ITRW_G4_OAK_BOW_01.mms" },
            }
        };

        public override string GetTemplate() => CommonTemplates.BowTempalte;
    }
}
