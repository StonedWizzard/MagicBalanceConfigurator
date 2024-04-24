using System;
using System.Collections.Generic;

namespace MagicBalanceConfigurator.Generators
{
    internal class Weap_Crossbow_T1_Generator : BaseWeaponGenerator
    {
        public Weap_Crossbow_T1_Generator(RandomController controller) : base(controller, Consts.Weap_crosbow_T1_FileName) 
        {
            TierPrefix = CommonTemplates.TierPrefix_T1;
            ItemIdPrefix = CommonTemplates.Weapon_crossbow_IdPrefix;
            ItemType = CommonTemplates.Weapon_crossbow_RandSufix;
            ItemName = "Арбалет";
            ModPower = 0.75;
            ItemsPrice = 500;
            BaseOnEquipFunc = "equip_crossbow_light();";
            BaseOnUnEquipFunc = "unequip_crossbow_light();";
            SetWeaponDamageRange(35, 70);
            SetItemCondRange(30, 60);
            SetModsCountRange(1, 2);
            ProhibitedDamageTypes = new List<string>() { "dam_fire" };
            ProhibitedMods = new List<int> { 226, 227, 228 };
            ItemModType = "StExt_ItemType_RangeWeap";
        }

        protected override List<ItemTemplatePreset> BuildItemTemplatePresets() => new List<ItemTemplatePreset>()
        {
            // crosbows
            new ItemTemplatePreset()
            {
                ItemCondStat = CommonTemplates.ItemCondAtr_Str,
                WeaponDamageType = "dam_point",
                ItemType = "item_crossbow",
                Visuals = new string[] { "ITRW_MIL_CROSSBOW.mms", "ITRW_CB_DM_0.mms", "CROSSBOW_BLACK_05_MIL.mms", "KM_ITRW_CROSSBOW_05_BANDIT.MMS" },
                ExtraConditions = new string[] { CommonTemplates.ItemCondAtr_Crosbow },
            },
            new ItemTemplatePreset()
            {
                ItemCondStat = CommonTemplates.ItemCondAtr_Crosbow,
                WeaponDamageType = "dam_point",
                ItemType = "item_crossbow",
                Visuals = new string[] { "ITRW_MIL_CROSSBOW.mms", "ITRW_CB_DM_0.mms", "CROSSBOW_BLACK_05_MIL.mms", "KM_ITRW_CROSSBOW_05_BANDIT.MMS" }
            }
        };

        public override string GetTemplate() => CommonTemplates.CrosbowTempalte;
    }
}
