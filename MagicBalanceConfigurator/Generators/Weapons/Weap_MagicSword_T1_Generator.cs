using System;
using System.Collections.Generic;

namespace MagicBalanceConfigurator.Generators
{
    internal class Weap_MagicSword_T1_Generator : BaseWeaponGenerator
    {
        public Weap_MagicSword_T1_Generator(RandomController controller) : base(controller, Consts.Weap_MagicSword_T1_FileName) 
        {
            TierPrefix = CommonTemplates.TierPrefix_T1;
            ItemIdPrefix = CommonTemplates.Weapon_MagicSword_IdPrefix;
            ItemType = CommonTemplates.Weapon_magicsword_RandSufix;
            ModPower = 1.25;
            ItemsPrice = 750;
            BaseOnEquipFunc = "equip_itmw_blade_adept();";
            BaseOnUnEquipFunc = "unequip_itmw_blade_adept();";
            SetWeaponDamageRange(40, 60);
            SetWeaponRangeRange(30, 70);
            SetItemCondRange(35, 75);
            SetModsCountRange(2, 3);
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
                Visuals = new string[] { "ItMw_SteelDagger_01_New_Magic.3DS", "ITMW_1H_ON_107.3DS", "ITMW_1H_KNIFE_HUNT.3DS", "ItMw_IronDagger_01_New.3DS" },
                SpecialSection = "setitemvartrue([IdPrefix][Id], bit_item_mag_sword);"
            },
            new ItemTemplatePreset()
            {
                ItemNamePlaceholder = "Меч",
                ItemCondStat = CommonTemplates.ItemCondAtr_Mana,
                WeaponDamageType = "dam_fire",
                ItemType = "item_swd",
                Visuals = new string[] { "ItMw_SteelDagger_01_New_Magic.3DS", "ITMW_1H_ON_107.3DS", "ITMW_1H_KNIFE_HUNT.3DS", "ItMw_IronDagger_01_New.3DS" },
                SpecialSection = "setitemvartrue([IdPrefix][Id], bit_item_mag_sword);"
            }
        };

        public override string GetTemplate() => CommonTemplates.WeaponTemplate;
    }
}
