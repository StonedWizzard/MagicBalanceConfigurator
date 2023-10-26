using System;
using System.Collections.Generic;

namespace MagicBalanceConfigurator.Generators
{
    internal class Weap_Staff_T1_Generator : BaseWeaponGenerator
    {
        public Weap_Staff_T1_Generator(RandomController controller) : base(controller, Consts.Weap_Staff_T1_FileName) 
        {
            TierPrefix = CommonTemplates.TierPrefix_T1;
            ItemIdPrefix = CommonTemplates.Weapon_Staff_IdPrefix;
            ItemType = CommonTemplates.Weapon_staff_RandSufix;
            ItemName = "Посох";
            ModPower = 1.25;
            ItemsPrice = 750;
            BaseOnEquipFunc = "equip_stab_newbie();";
            BaseOnUnEquipFunc = "unequip_stab_newbie();";
            SetWeaponDamageRange(50, 100);
            SetWeaponRangeRange(100, 120);
            SetItemCondRange(25, 50);
            SetModsCountRange(2, 3);
        }

        protected override List<ItemTemplatePreset> BuildItemTemplatePresets() => new List<ItemTemplatePreset>()
        {
            // staffs
            new ItemTemplatePreset()
            {
                ItemCondStat = CommonTemplates.ItemCondAtr_Mana,
                WeaponDamageType = "dam_magic",
                ItemType = "item_2hd_axe",
                Visuals = new string[] { "ItMw_020_2h_Nov_Staff_01.3DS", "ItMw_025_2h_Staff_02.3DS", "ItMw_032_2h_staff_03.3DS",
                    "ITMW_BATTLEMAGE_STAB_02.3DS", "ItMw_RangerStaff_Addon_New2.3DS"}
            },
            new ItemTemplatePreset()
            {
                ItemCondStat = CommonTemplates.ItemCondAtr_Mana,
                WeaponDamageType = "dam_fire",
                ItemType = "item_2hd_axe",
                Visuals = new string[] { "ItMw_020_2h_Nov_Staff_01.3DS", "ItMw_025_2h_Staff_02.3DS", "ItMw_032_2h_staff_03.3DS",
                    "ITMW_BATTLEMAGE_STAB_02.3DS", "ItMw_RangerStaff_Addon_New2.3DS"}
            }
        };

        public override string GetTemplate() => CommonTemplates.StaffTemplate;
    }
}
