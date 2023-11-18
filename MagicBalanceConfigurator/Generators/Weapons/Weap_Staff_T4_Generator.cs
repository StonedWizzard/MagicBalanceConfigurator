using System;
using System.Collections.Generic;

namespace MagicBalanceConfigurator.Generators
{
    internal class Weap_Staff_T4_Generator : BaseWeaponGenerator
    {
        public Weap_Staff_T4_Generator(RandomController controller) : base(controller, Consts.Weap_Staff_T4_FileName) 
        {
            TierPrefix = CommonTemplates.TierPrefix_T4;
            ItemIdPrefix = CommonTemplates.Weapon_Staff_IdPrefix;
            ItemType = CommonTemplates.Weapon_staff_RandSufix;
            ItemName = "Посох";
            ModPower = 5;
            ItemsPrice = 5000;
            BaseOnEquipFunc = "equip_zauberstab_dragon();";
            BaseOnUnEquipFunc = "unequip_zauberstab_dragon();";
            SetWeaponDamageRange(300, 450);
            SetWeaponRangeRange(130, 150);
            SetItemCondRange(250, 400);
            SetModsCountRange(5, 7);
            ProhibitedMods = new List<int> { 227, 228, 229 };
        }

        protected override List<ItemTemplatePreset> BuildItemTemplatePresets() => new List<ItemTemplatePreset>()
        {
            // staffs
            new ItemTemplatePreset()
            {
                ItemCondStat = CommonTemplates.ItemCondAtr_Mana,
                WeaponDamageType = "dam_magic",
                ItemType = "item_2hd_axe",
                Visuals = new string[] { "ITMW_2H_SERPENTSTAFF.3ds", "FIRE_STAFF.3ds", "WATER_STAFF.3ds", "ITMW_2H_KMR_BLACKSTAFF_01.3DS",
                    "ItMW_Addon_Stab03_New.3ds", "STAFF_GURU.3ds", "ItMW_Addon_Stab04_New.3ds", "AZGALOR_STAFF.3ds", "ITMW_2H_KMR_DAEMONSTAFF_01.3DS",
                    "BLOOD_STAFF.3ds", "ITMW_2H_G3_STAFFDRUID_01.3DS" }
            },
            new ItemTemplatePreset()
            {
                ItemCondStat = CommonTemplates.ItemCondAtr_Mana,
                WeaponDamageType = "dam_fire",
                ItemType = "item_2hd_axe",
                Visuals = new string[] { "ITMW_2H_SERPENTSTAFF.3ds", "FIRE_STAFF.3ds", "WATER_STAFF.3ds", "ITMW_2H_KMR_BLACKSTAFF_01.3DS",
                    "ItMW_Addon_Stab03_New.3ds", "STAFF_GURU.3ds", "ItMW_Addon_Stab04_New.3ds", "AZGALOR_STAFF.3ds", "ITMW_2H_KMR_DAEMONSTAFF_01.3DS",
                    "BLOOD_STAFF.3ds", "ITMW_2H_G3_STAFFDRUID_01.3DS" }
            }
        };

        public override string GetTemplate() => CommonTemplates.StaffTemplate;
    }
}
