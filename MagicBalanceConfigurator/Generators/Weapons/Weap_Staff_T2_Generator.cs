using System;
using System.Collections.Generic;

namespace MagicBalanceConfigurator.Generators
{
    internal class Weap_Staff_T2_Generator : BaseWeaponGenerator
    {
        public Weap_Staff_T2_Generator(RandomController controller) : base(controller, Consts.Weap_Staff_T2_FileName) 
        {
            TierPrefix = CommonTemplates.TierPrefix_T2;
            ItemIdPrefix = CommonTemplates.Weapon_Staff_IdPrefix;
            ItemType = CommonTemplates.Weapon_staff_RandSufix;
            ItemName = "Посох";
            ModPower = 2.5;
            ItemsPrice = 1500;
            BaseOnEquipFunc = "equip_zauberstab_highpriest_yark();";
            BaseOnUnEquipFunc = "unequip_zauberstab_highpriest_yark();";
            SetWeaponDamageRange(100, 200);
            SetWeaponRangeRange(110, 130);
            SetItemCondRange(50, 100);
            SetModsCountRange(3, 4);
            ProhibitedMods = new List<int> { 227, 228, 229 };
            ItemModType = "StExt_ItemType_MeleeWeap";
            ItemAltConditionMode = true;
        }

        protected override List<ItemTemplatePreset> BuildItemTemplatePresets() => new List<ItemTemplatePreset>()
        {
            // staffs
            new ItemTemplatePreset()
            {
                ItemCondStat = CommonTemplates.ItemCondAtr_Mana,
                WeaponDamageType = "dam_magic",
                ItemType = "item_2hd_axe",
                Visuals = new string[] { "ITMW_2H_G3_STAFFDRUID_01.3DS", "ITMW_2H_G3_STAFFDRUID_01.3DS", "ITMW_2H_G3_STAFFFIRE_01.3DS",
                    "ITMW_2H_G3_STAFFWATER_01.3DS", "ITMW_2H_KMR_BLACKSTAFF_01.3DS", "ItMW_Addon_Stab04_New.3ds", "ITMW_2H_SERPENTSTAFF.3ds" }
            },
            new ItemTemplatePreset()
            {
                ItemCondStat = CommonTemplates.ItemCondAtr_Mana,
                WeaponDamageType = "dam_fire",
                ItemType = "item_2hd_axe",
                Visuals = new string[] { "ITMW_2H_G3_STAFFDRUID_01.3DS", "ITMW_2H_G3_STAFFDRUID_01.3DS", "ITMW_2H_G3_STAFFFIRE_01.3DS",
                    "ITMW_2H_G3_STAFFWATER_01.3DS", "ITMW_2H_KMR_BLACKSTAFF_01.3DS", "ItMW_Addon_Stab04_New.3ds", "ITMW_2H_SERPENTSTAFF.3ds" }
            },
            new ItemTemplatePreset()
            {
                ItemCondStat = CommonTemplates.ItemCondAtr_Mana,
                WeaponDamageType = "dam_fly",
                ItemType = "item_2hd_axe",
                Visuals = new string[] { "ITMW_2H_G3_STAFFDRUID_01.3DS", "ITMW_2H_G3_STAFFDRUID_01.3DS", "ITMW_2H_G3_STAFFFIRE_01.3DS",
                    "ITMW_2H_G3_STAFFWATER_01.3DS", "ITMW_2H_KMR_BLACKSTAFF_01.3DS", "ItMW_Addon_Stab04_New.3ds", "ITMW_2H_SERPENTSTAFF.3ds" }
            },
        };

        public override string GetTemplate() => CommonTemplates.StaffTemplate;
    }
}
