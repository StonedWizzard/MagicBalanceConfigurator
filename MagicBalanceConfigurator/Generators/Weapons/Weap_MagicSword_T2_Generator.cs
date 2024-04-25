using System;
using System.Collections.Generic;

namespace MagicBalanceConfigurator.Generators
{
    internal class Weap_MagicSword_T2_Generator : BaseWeaponGenerator
    {
        public Weap_MagicSword_T2_Generator(RandomController controller) : base(controller, Consts.Weap_MagicSword_T2_FileName) 
        {
            TierPrefix = CommonTemplates.TierPrefix_T2;
            ItemIdPrefix = CommonTemplates.Weapon_MagicSword_IdPrefix;
            ItemType = CommonTemplates.Weapon_magicsword_RandSufix;
            ModPower = 2.25;
            ItemsPrice = 1500;
            BaseOnEquipFunc = "equip_itmw_blade_mage();";
            BaseOnUnEquipFunc = "unequip_itmw_blade_mage();";
            SetWeaponDamageRange(60, 120);
            SetWeaponRangeRange(50, 80);
            SetItemCondRange(75, 150);
            SetModsCountRange(3, 4);
            ProhibitedMods = new List<int> { 226, 228, 229 };
            ItemModType = "StExt_ItemType_MeleeWeap";
        }

        protected override List<ItemTemplatePreset> BuildItemTemplatePresets() => new List<ItemTemplatePreset>()
        {
            // magic swords
            new ItemTemplatePreset()
            {
                ItemNamePlaceholder = "Меч",
                ItemCondStat = CommonTemplates.ItemCondAtr_Mana,
                WeaponDamageType = "dam_magic",
                ItemType = "item_swd",
                Visuals = new string[] { "ITMW_BLADE_ADEPT.3DS", "DB_ITMW_1H_SWORD_LONG_MISSION.3DS", "NEW_STL_BROADSWORD.3DS", "ITMW_HARAD_SWORD_02.3DS", "ItMw_RubinSword.3DS" },
                SpecialSection = "setitemvartrue([IdPrefix][Id], bit_item_mag_sword);"
            },
            new ItemTemplatePreset()
            {
                ItemNamePlaceholder = "Меч",
                ItemCondStat = CommonTemplates.ItemCondAtr_Mana,
                WeaponDamageType = "dam_fire",
                ItemType = "item_swd",
                Visuals = new string[] { "ITMW_BLADE_ADEPT.3DS", "DB_ITMW_1H_SWORD_LONG_MISSION.3DS", "NEW_STL_BROADSWORD.3DS", "ITMW_HARAD_SWORD_02.3DS", "ItMw_RubinSword.3DS" },
                SpecialSection = "setitemvartrue([IdPrefix][Id], bit_item_mag_sword);"
            },
            new ItemTemplatePreset()
            {
                ItemNamePlaceholder = "Меч",
                ItemCondStat = CommonTemplates.ItemCondAtr_Mana,
                WeaponDamageType = "dam_fly",
                ItemType = "item_swd",
                Visuals = new string[] { "ITMW_BLADE_ADEPT.3DS", "DB_ITMW_1H_SWORD_LONG_MISSION.3DS", "NEW_STL_BROADSWORD.3DS", "ITMW_HARAD_SWORD_02.3DS", "ItMw_RubinSword.3DS" },
                SpecialSection = "setitemvartrue([IdPrefix][Id], bit_item_mag_sword);"
            }
        };

        public override string GetTemplate() => CommonTemplates.WeaponTemplate;
    }
}
