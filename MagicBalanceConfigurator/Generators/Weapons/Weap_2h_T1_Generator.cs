using System;
using System.Collections.Generic;

namespace MagicBalanceConfigurator.Generators
{
    internal class Weap_2h_T1_Generator : BaseWeaponGenerator
    {
        public Weap_2h_T1_Generator(RandomController controller) : base(controller, Consts.Weap_2h_T1_FileName) 
        {
            TierPrefix = CommonTemplates.TierPrefix_T1;
            ItemIdPrefix = CommonTemplates.Weapon_2h_IdPrefix;
            ItemType = CommonTemplates.Weapon_2h_RandSufix;
            ModPower = 0.75;
            ItemsPrice = 500;
            BaseOnEquipFunc = "equip_2h_light();";
            BaseOnUnEquipFunc = "unequip_2h_light();";
            SetWeaponDamageRange(75, 150);
            SetWeaponRangeRange(70, 90);
            SetItemCondRange(25, 50);
            SetModsCountRange(1, 2);
            ProhibitedMods = new List<int> { 227, 228, 229 };
            ItemModType = "StExt_ItemType_MeleeWeap";
        }

        protected override List<ItemTemplatePreset> BuildItemTemplatePresets() => new List<ItemTemplatePreset>()
        {
            // swords
            new ItemTemplatePreset()
            {
                ItemNamePlaceholder = "Двуручный меч",
                ItemCondStat = CommonTemplates.ItemCondAtr_Str,
                WeaponDamageType = "dam_edge",
                ItemType = "item_2hd_swd",
                Visuals = new string[] { "ItMw_2H_Machete_01.3DS", "ItMw_2H_Garad_01.3DS", "ItMw_025_2h_Sword_old_01.3DS", "ITMW_2H_DJG_CRAFT_01.3DS", "ITMW_2H_DJG_CRAFT_02.3DS" }
            },
            // spears
            new ItemTemplatePreset()
            {
                ItemNamePlaceholder = "Копьё",
                ItemCondStat = CommonTemplates.ItemCondAtr_Agi,
                WeaponDamageType = "dam_edge",
                ItemType = "item_2hd_swd",
                Visuals = new string[] { "ItMw_2H_Falx.3DS", "ItMw_Speer_01.3DS", "ItMw_SwordSpear.3DS", "ITMW_2H_SPEAR_BANDIT.3DS", "ItMw_HeavySwordSpear.3DS" },
                SpecialSection = "setitemvartrue([IdPrefix][Id], bit_item_speer);\r\n\townerguild = 123;",
                AltOnEquipFunc = "equip_2h_medium_speer();",
                AltOnUnEquipFunc = "unequip_2h_medium_speer();",
                WeaponExtraRange = 30
            },
            // halleberdes
            new ItemTemplatePreset()
            {
                ItemNamePlaceholder = "Алебарда",
                ItemCondStat = CommonTemplates.ItemCondAtr_Str,
                WeaponDamageType = "dam_edge",
                ItemType = "item_2hd_swd",
                Visuals = new string[] { "ITAR_HALLEBERD_NOW.3DS", "ItMw_Hellebarde_New.3DS", "ITMW_HALLEBERD_GUARD_01.3DS", "itmw_halleberd_guard_02.3DS" },
                SpecialSection = "setitemvartrue([IdPrefix][Id], bit_item_hellebarde);",
                AltOnEquipFunc = "equip_2h_medium_halleberde();",
                AltOnUnEquipFunc = "unequip_2h_medium_halleberde();",
                WeaponExtraRange = 30
            },
            // axes
            new ItemTemplatePreset()
            {
                ItemNamePlaceholder = "Топор",
                ItemCondStat = CommonTemplates.ItemCondAtr_Str,
                WeaponDamageType = "dam_edge",
                ItemType = "item_2hd_axe",
                Visuals = new string[] { "ITMW_AXE_NEW_01.3DS", "ITMW_AXE_NEW_02.3DS", "ITMW_2H_LUMBERAXE_01.3DS", "ITMW_2H_PIRAXE_01.3DS", "ItMw_2h_Sld_Axe_New.3DS" }
            },
            // maces
            new ItemTemplatePreset()
            {
                ItemNamePlaceholder = "Булава",
                ItemCondStat = CommonTemplates.ItemCondAtr_Str,
                WeaponDamageType = "dam_blunt",
                ItemType = "item_2hd_axe",
                Visuals = new string[] { "ItMw_OgreHummer.3DS", "ItMw_020_2h_Nov_Staff_01.3DS", "ItMw_025_2h_Staff_02.3DS", "ItMw_Iron_Club.3DS" },
                AltOnEquipFunc = "equip_2h_medium();",
                AltOnUnEquipFunc = "unequip_2h_medium();"
            }
        };

        public override string GetTemplate() => CommonTemplates.WeaponTemplate;
    }
}
