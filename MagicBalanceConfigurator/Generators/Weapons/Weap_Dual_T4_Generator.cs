using System;
using System.Collections.Generic;

namespace MagicBalanceConfigurator.Generators
{
    internal class Weap_Dual_T4_Generator : BaseDualWeaponGenerator
    {
        public Weap_Dual_T4_Generator(RandomController controller) : base(controller, Consts.Weap_dual_T4_FileName) 
        {
            TierPrefix = CommonTemplates.TierPrefix_T4;
            ItemIdPrefix = CommonTemplates.Weapon_dual_IdPrefix;
            ItemType = CommonTemplates.Weapon_dual_RandSufix;
            ModPower = 3;
            ItemsPrice = 2500;
            SetWeaponDamageRange(225, 350);
            SetWeaponRangeRange(95, 120);
            SetItemCondRange(150, 250);
            SetModsCountRange(4, 5);
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
                Visuals = new string[] { "ITMW_1H_DUAL_ORE_RIGHT.3DS", "ItMw_1H_Ancient_Right.3DS", "ITMW_1H_DUAL_TWILIGHT_RIGHT.3DS", "ItMw_ArabicSword_01.3DS",
                    "ITMW_KATANA_01.3DS", "ITMW_1H_BELIARSWORD.3DS", "ItMw_1H_ChelDrak_Right.3DS", "ItMw_1H_IlArahBlade.3DS" },
                VisualsExtra = new string[] { "ITMW_1H_DUAL_ORE_LEFT.3DS", "ItMw_1H_Ancient_Left.3DS", "ITMW_1H_DUAL_TWILIGHT_LEFT.3DS", "ItMw_1H_AssBlade_Left.3DS",
                    "ITMW_KATANA_02.3DS", "ITMW_1H_BELIARSWORD_LEFT.3DS", "ItMw_1H_ChelDrak_Left.3DS", "ItMw_1H_IlArahBlade_Left.3DS" },
            },
        };
    }
}
