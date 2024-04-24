using System;
using System.Collections.Generic;

namespace MagicBalanceConfigurator.Generators
{
    internal class Weap_2h_T2_Generator : BaseWeaponGenerator
    {
        public Weap_2h_T2_Generator(RandomController controller) : base(controller, Consts.Weap_2h_T2_FileName) 
        {
            TierPrefix = CommonTemplates.TierPrefix_T2;
            ItemIdPrefix = CommonTemplates.Weapon_2h_IdPrefix;
            ItemType = CommonTemplates.Weapon_2h_RandSufix;
            ModPower = 1.25;
            ItemsPrice = 1000;
            BaseOnEquipFunc = "equip_2h_medium();";
            BaseOnUnEquipFunc = "unequip_2h_medium();";
            SetWeaponDamageRange(150, 225);
            SetWeaponRangeRange(85, 100);
            SetItemCondRange(50, 100);
            SetModsCountRange(2, 3);
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
                Visuals = new string[] { "ItMw_2H_Machete_02.3DS", "ItMw_2H_Garad_01.3DS", "ItMw_2H_Garad_02.3DS", "ItMw_2H_Garad_03.3DS", "ItMw_Zweihaender2_New.3DS", 
                    "ITMW_2H_DJG_CRAFT_02.3DS", "ITMW_2H_DJG_CRAFT_03.3DS", "ITMW_ZWEIHAENDER_GORNAKOSH_NB.3DS", "ITMW_TAMPLIER_SPECIAL_2H_SWORD_1.3DS"  }
            },
            // spears
            new ItemTemplatePreset()
            {
                ItemNamePlaceholder = "Копьё",
                ItemCondStat = CommonTemplates.ItemCondAtr_Agi,
                WeaponDamageType = "dam_edge",
                ItemType = "item_2hd_swd",
                Visuals = new string[] { "ItMw_HeavySwordSpear.3DS", "ItMw_Speer_GoblinDemon_01.3DS", "ITMW_2H_SPEAR_BANDIT.3DS", "ItMw_SwordSpear.3DS",
                    "ItMw_Speer_02.3DS", "ITMW_2H_G3_LONGHALBERD_01.3DS", "ItMw_Speer_Silver.3DS", "ItMw_Speer_Silver_Strong.3DS", "ItMw_Speer_Guardian_01.3DS" },
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
                Visuals = new string[] { "ITMW_HALLEBERD_GUARD_01.3DS", "STEEL_HALLEBERDE.3DS", "ITMW_2H_HALLEBERDE_03.3DS", 
                    "ITMW_2H_HALLEBERDE_04.3DS", "itmw_halleberd_guard_02.3DS", "itmw_halleberd_guard_01.3DS" },
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
                Visuals = new string[] { "ITMW_2H_AXE_BERSERK_107.3DS", "ITMW_AXE_NEW_02.3DS", "ITMW_AXE_NEW_03.3DS", "ItMw_2h_Sld_Axe_New.3DS", "ItMw_Streitaxt1_New.3DS",
                    "ITMW_AXE_ST_02.3DS", "ITMW_2H_OLDAXE.3DS", "ITMW_2H_G3A_ORCAXE_02.3DS"}
            },
            // maces
            new ItemTemplatePreset()
            {
                ItemNamePlaceholder = "Булава",
                ItemCondStat = CommonTemplates.ItemCondAtr_Str,
                WeaponDamageType = "dam_blunt",
                ItemType = "item_2hd_axe",
                Visuals = new string[] { "ItMw_025_2h_Staff_02.3DS", "ItMw_032_2h_staff_03.3DS", "ITMW_BATTLEMAGE_STAB_02.3DS", "ItMw_Iron_Club.3DS",
                    "ITMW_2H_SPIKEHAMMER.3DS", "ItMw_WarHammer_Iron.3DS", "ITMW_2H_MACE_107.3DS", "1h_hammer_godendar.3DS"},
                AltOnEquipFunc = "equip_2h_heavy();",
                AltOnUnEquipFunc = "unequip_2h_heavy();"
            }
        };

        public override string GetTemplate() => CommonTemplates.WeaponTemplate;
    }
}
