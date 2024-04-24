using System;
using System.Collections.Generic;

namespace MagicBalanceConfigurator.Generators
{
    internal class Weap_Bow_T3_Generator : BaseWeaponGenerator
    {
        public Weap_Bow_T3_Generator(RandomController controller) : base(controller, Consts.Weap_bow_T3_FileName) 
        {
            TierPrefix = CommonTemplates.TierPrefix_T3;
            ItemIdPrefix = CommonTemplates.Weapon_bow_IdPrefix;
            ItemType = CommonTemplates.Weapon_bow_RandSufix;
            ItemName = "Лук";
            ModPower = 2;
            ItemsPrice = 1500;
            BaseOnEquipFunc = "equip_bow_heavy();";
            BaseOnUnEquipFunc = "unequip_bow_heavy();";
            SetWeaponDamageRange(120, 240);
            SetItemCondRange(75, 150);
            SetModsCountRange(3, 4);
            ProhibitedDamageTypes = new List<string>() { "dam_fire" };
            ProhibitedMods = new List<int> { 226, 227, 229 };
            ItemModType = "StExt_ItemType_RangeWeap";
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
