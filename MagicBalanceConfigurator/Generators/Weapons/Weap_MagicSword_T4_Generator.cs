using System;
using System.Collections.Generic;

namespace MagicBalanceConfigurator.Generators
{
    internal class Weap_MagicSword_T4_Generator : BaseWeaponGenerator
    {
        public Weap_MagicSword_T4_Generator(RandomController controller) : base(controller, Consts.Weap_MagicSword_T4_FileName) 
        {
            TierPrefix = CommonTemplates.TierPrefix_T4;
            ItemIdPrefix = CommonTemplates.Weapon_MagicSword_IdPrefix;
            ItemType = CommonTemplates.Weapon_magicsword_RandSufix;
            ModPower = 4.5;
            ItemsPrice = 4500;
            BaseOnEquipFunc = "equip_itmw_sender();";
            BaseOnUnEquipFunc = "unequip_itmw_sender();";
            SetWeaponDamageRange(240, 360);
            SetWeaponRangeRange(85, 110);
            SetItemCondRange(200, 300);
            SetModsCountRange(5, 6);
            ProhibitedMods = new List<int> { 226, 228, 229 };
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
                Visuals = new string[] { "ITMW_BLADE_HIGHMAGE.3DS", "ITMW__SPELLSWORD.3DS", "ITMW_SWORD_NEW_03.3DS", 
                    "ITMW__STORM.3DS", "ITMW_TWILIGHT.3DS"},
                SpecialSection = "setitemvartrue([IdPrefix][Id], bit_item_mag_sword);"
            },
            new ItemTemplatePreset()
            {
                ItemNamePlaceholder = "Меч",
                ItemCondStat = CommonTemplates.ItemCondAtr_Mana,
                WeaponDamageType = "dam_fire",
                ItemType = "item_swd",
                Visuals = new string[] { "ITMW_BLADE_HIGHMAGE.3DS", "ITMW__SPELLSWORD.3DS", "ITMW_SWORD_NEW_03.3DS",
                    "ITMW__STORM.3DS", "ITMW_TWILIGHT.3DS"},
                SpecialSection = "setitemvartrue([IdPrefix][Id], bit_item_mag_sword);"
            }
        };

        public override string GetTemplate() => CommonTemplates.WeaponTemplate;
    }
}
