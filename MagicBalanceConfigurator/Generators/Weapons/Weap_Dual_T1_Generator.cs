using System;
using System.Collections.Generic;

namespace MagicBalanceConfigurator.Generators
{
    internal class Weap_Dual_T1_Generator : BaseDualWeaponGenerator
    {
        public Weap_Dual_T1_Generator(RandomController controller) : base(controller, Consts.Weap_dual_T1_FileName) 
        {
            TierPrefix = CommonTemplates.TierPrefix_T1;
            ItemIdPrefix = CommonTemplates.Weapon_dual_IdPrefix;
            ItemType = CommonTemplates.Weapon_dual_RandSufix;
            ModPower = 0.75;
            ItemsPrice = 500;            
            SetWeaponDamageRange(50, 75);
            SetWeaponRangeRange(60, 80);
            SetItemCondRange(25, 50);
            SetModsCountRange(1, 2);
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
                Visuals = new string[] { "ITMW_1H_DUAL_IRON_RIGHT.3DS", "ITMW_1H_DUAL_OLD_RIGHT.3DS", "ITMW_1H_DUAL_STEEL_RIGHT.3DS" },
                VisualsExtra = new string[] {"ITMW_1H_DUAL_IRON_LEFT.3DS", "ITMW_1H_DUAL_OLD_LEFT.3DS", "ITMW_1H_DUAL_STEEL_LEFT.3DS" },
            },
        };
    }
}
