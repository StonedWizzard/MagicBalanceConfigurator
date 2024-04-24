using System;
using System.Collections.Generic;

namespace MagicBalanceConfigurator.Generators
{
    internal class Weap_Bow_T1_Generator : BaseWeaponGenerator
    {
        public Weap_Bow_T1_Generator(RandomController controller) : base(controller, Consts.Weap_bow_T1_FileName) 
        {
            TierPrefix = CommonTemplates.TierPrefix_T1;
            ItemIdPrefix = CommonTemplates.Weapon_bow_IdPrefix;
            ItemType = CommonTemplates.Weapon_bow_RandSufix;
            ItemName = "Лук";
            ModPower = 0.75;
            ItemsPrice = 500;
            BaseOnEquipFunc = "equip_bow_light();";
            BaseOnUnEquipFunc = "unequip_bow_light();";
            SetWeaponDamageRange(30, 60);
            SetItemCondRange(25, 50);
            SetModsCountRange(1, 2);
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
                Visuals = new string[] { "ItRw_Bow_L_01.mms", "ItRw_Bow_L_02.mms", "ITRW_G3_SMALL_BOW_01.mms", "ItRw_Bow_L_05.mms", "ITRW_G3_LONG_BOW_01.mms" },
                ExtraConditions = new string[] { CommonTemplates.ItemCondAtr_Bow },
            },
            new ItemTemplatePreset()
            {
                ItemCondStat = CommonTemplates.ItemCondAtr_Str,
                WeaponDamageType = "dam_point",
                ItemType = "item_bow",
                Visuals = new string[] { "ItRw_Bow_L_01.mms", "ItRw_Bow_L_02.mms", "ITRW_G3_SMALL_BOW_01.mms", "ItRw_Bow_L_05.mms", "ITRW_G3_LONG_BOW_01.mms" },
                ExtraConditions = new string[] { CommonTemplates.ItemCondAtr_Bow },
            },
            new ItemTemplatePreset()
            {
                ItemCondStat = CommonTemplates.ItemCondAtr_Bow,
                WeaponDamageType = "dam_point",
                ItemType = "item_bow",
                Visuals = new string[] { "ItRw_Bow_L_01.mms", "ItRw_Bow_L_02.mms", "ITRW_G3_SMALL_BOW_01.mms", "ItRw_Bow_L_05.mms", "ITRW_G3_LONG_BOW_01.mms" },
            }
        };

        public override string GetTemplate() => CommonTemplates.BowTempalte;
    }
}
