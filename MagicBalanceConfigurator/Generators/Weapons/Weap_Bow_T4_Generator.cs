using System;
using System.Collections.Generic;

namespace MagicBalanceConfigurator.Generators
{
    internal class Weap_Bow_T4_Generator : BaseWeaponGenerator
    {
        public Weap_Bow_T4_Generator(RandomController controller) : base(controller, Consts.Weap_bow_T4_FileName) 
        {
            TierPrefix = CommonTemplates.TierPrefix_T4;
            ItemIdPrefix = CommonTemplates.Weapon_bow_IdPrefix;
            ItemType = CommonTemplates.Weapon_bow_RandSufix;
            ItemName = "Лук";
            ModPower = 3;
            ItemsPrice = 2000;
            BaseOnEquipFunc = "equip_bow_veryheavy();";
            BaseOnUnEquipFunc = "unequip_bow_veryheavy();";
            SetWeaponDamageRange(240, 400);
            SetItemCondRange(150, 250);
            SetModsCountRange(4, 5);
            ProhibitedDamageTypes = new List<string>() { "dam_fire" };
        }

        protected override List<ItemTemplatePreset> BuildItemTemplatePresets() => new List<ItemTemplatePreset>()
        {
            // bows
            new ItemTemplatePreset()
            {
                ItemCondStat = CommonTemplates.ItemCondAtr_Agi,
                WeaponDamageType = "dam_point",
                ItemType = "item_bow",
                Visuals = new string[] { "ITRW_G3_LONG_BOW_01.mms", "ITRW_KMR_DARKLONG_BOW_01.mms", "ITRW_BOWMAKED8_S_DRAGONBONE.mms",
                    "ITRW_BOWMAKED4_G3_HORN.mms", "ItRw_Bow_Long_Arabic.mms", "ITRW_G3_LONG_BOW_02.mms", "ITRW_KMR_KADAT_BOW_01.mms",
                    "ITRW_KMR_DARKLONG_BOW_01.mms", "ITRW_BOWMAKED6_S_NIGHTINGALEBOW.mms", "ITRW_KMR_SHADOWS_BOW_01.mms", "ITRW_G3_SILENTDEATH_BOW_01.mms",
                    "ITRW_BOW_BONES_01.mms", "ITRW_G4_OAK_BOW_01.mms", "ITRW_BOWMAKED5_A_COBRA.mms"},
                ExtraConditions = new string[] { CommonTemplates.ItemCondAtr_Bow },
            },
            new ItemTemplatePreset()
            {
                ItemCondStat = CommonTemplates.ItemCondAtr_Str,
                WeaponDamageType = "dam_point",
                ItemType = "item_bow",
                Visuals = new string[] { "ITRW_G3_LONG_BOW_01.mms", "ITRW_KMR_DARKLONG_BOW_01.mms", "ITRW_BOWMAKED8_S_DRAGONBONE.mms",
                    "ITRW_BOWMAKED4_G3_HORN.mms", "ItRw_Bow_Long_Arabic.mms", "ITRW_G3_LONG_BOW_02.mms", "ITRW_KMR_KADAT_BOW_01.mms",
                    "ITRW_KMR_DARKLONG_BOW_01.mms", "ITRW_BOWMAKED6_S_NIGHTINGALEBOW.mms", "ITRW_KMR_SHADOWS_BOW_01.mms", "ITRW_G3_SILENTDEATH_BOW_01.mms",
                    "ITRW_BOW_BONES_01.mms", "ITRW_G4_OAK_BOW_01.mms", "ITRW_BOWMAKED5_A_COBRA.mms"},
                ExtraConditions = new string[] { CommonTemplates.ItemCondAtr_Bow },
            },
            new ItemTemplatePreset()
            {
                ItemCondStat = CommonTemplates.ItemCondAtr_Bow,
                WeaponDamageType = "dam_point",
                ItemType = "item_bow",
                Visuals = new string[] { "ITRW_G3_LONG_BOW_01.mms", "ITRW_KMR_DARKLONG_BOW_01.mms", "ITRW_BOWMAKED8_S_DRAGONBONE.mms",
                    "ITRW_BOWMAKED4_G3_HORN.mms", "ItRw_Bow_Long_Arabic.mms", "ITRW_G3_LONG_BOW_02.mms", "ITRW_KMR_KADAT_BOW_01.mms",
                    "ITRW_KMR_DARKLONG_BOW_01.mms", "ITRW_BOWMAKED6_S_NIGHTINGALEBOW.mms", "ITRW_KMR_SHADOWS_BOW_01.mms", "ITRW_G3_SILENTDEATH_BOW_01.mms",
                    "ITRW_BOW_BONES_01.mms", "ITRW_G4_OAK_BOW_01.mms", "ITRW_BOWMAKED5_A_COBRA.mms"},
            }
        };

        public override string GetTemplate() => CommonTemplates.BowTempalte;
    }
}
