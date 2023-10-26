using System;
using System.Collections.Generic;

namespace MagicBalanceConfigurator.Generators
{
    internal class Weap_2h_T4_Generator : BaseWeaponGenerator
    {
        public Weap_2h_T4_Generator(RandomController controller) : base(controller, Consts.Weap_2h_T4_FileName) 
        {
            TierPrefix = CommonTemplates.TierPrefix_T4;
            ItemIdPrefix = CommonTemplates.Weapon_2h_IdPrefix;
            ItemType = CommonTemplates.Weapon_2h_RandSufix;
            ModPower = 3;
            ItemsPrice = 2000;
            BaseOnEquipFunc = "equip_2h_heavy();";
            BaseOnUnEquipFunc = "unequip_2h_heavy();";
            SetWeaponDamageRange(350, 500);
            SetWeaponRangeRange(120, 140);
            SetItemCondRange(150, 250);
            SetModsCountRange(4, 5);
        }

        protected override List<ItemTemplatePreset> BuildItemTemplatePresets() => new List<ItemTemplatePreset>()
        {
            // swords
            new ItemTemplatePreset()
            {
                ItemCondStat = CommonTemplates.ItemCondAtr_Str,
                WeaponDamageType = "dam_edge",
                ItemType = "item_2hd_swd",
                Visuals = new string[] { "ItMw_2H_Garad_03.3DS", "ItMw_2H_Garad_04.3DS", "ItMw_2H_Garad_05.3DS", "ITMW_2H_DJG_CRAFT_03.3DS",
                    "ITMW_2H_DJG_CRAFT_04.3DS", "ItMw_2H_PALBLESSED_01_NEW.3ds", "ItMw_2H_GodBane_01.3ds", "ITMW_2H_SPECIAL_04_NEW.3DS", "RAGE_GODDESS.3ds",
                    "ITMW_2H_KMR_SOULSWORD_01.3DS", "ITMW_INN_2HSWORD.3DS", "ITMW_SLEEPER_SWORD_2H_CRYSTAL.3DS", "GODDESS_2H.3DS", "ItMw_DementorSword.3DS",
                    "ItMw_2H_DarkSoul.3DS", "G3_Weapon_Orc_Sword_01.3DS", "ITMW_TAMPLIER_SPECIAL_2H_SWORD_1.3DS", "SWORD_2H_TEMPLAR_02.3DS", "SWORD_2H_TEMPLAR_03.3DS",
                    "SWORD_2H_TEMPLAR_04.3DS", "ITMW_TAMPLIER_SPECIAL_2H_SWORD_5.3DS", "ITMW_2h_holywrath.3DS" }
            },
            // spears
            new ItemTemplatePreset()
            {
                ItemCondStat = CommonTemplates.ItemCondAtr_Agi,
                WeaponDamageType = "dam_edge",
                ItemType = "item_2hd_swd",
                Visuals = new string[] { "ITMW_2H_G3_LONGHALBERD_01.3DS", "ItMw_Speer_Silver.3DS", "ItMw_Speer_Silver_Strong.3DS", "ITMW_2H_SPEAR_RUNIC.3DS", "ItMw_Speer_GoblinDemon_01.3DS",
                    "ItMw_Speer_04.3DS", "ItMw_Speer_03.3DS", "ItMw_Speer_03.3DS", "ItMw_DemonSpear.3DS", "ItMw_Speer_Guardian_01.3DS", "ItMw_Speer_05.3DS"},
                SpecialSection = "setitemvartrue([IdPrefix][Id], bit_item_speer);",
                AltOnEquipFunc = "equip_2h_heavy_speer();",
                AltOnUnEquipFunc = "unequip_2h_heavy_speer();",
                WeaponExtraRange = 35
            },
            // halleberdes
            new ItemTemplatePreset()
            {
                ItemCondStat = CommonTemplates.ItemCondAtr_Str,
                WeaponDamageType = "dam_edge",
                ItemType = "item_2hd_swd",
                Visuals = new string[] { "ITMW_2H_HALLEBERDE_03.3DS", "ITMW_2H_HALLEBERDE_04.3DS", "itmw_halleberd_guard_01.3DS" },
                SpecialSection = "setitemvartrue([IdPrefix][Id], bit_item_hellebarde);",
                AltOnEquipFunc = "equip_2h_heavy_halleberde();",
                AltOnUnEquipFunc = "unequip_2h_heavy_halleberde();",
                WeaponExtraRange = 30
            },
            // axes
            new ItemTemplatePreset()
            {
                ItemCondStat = CommonTemplates.ItemCondAtr_Str,
                WeaponDamageType = "dam_edge",
                ItemType = "item_2hd_axe",
                Visuals = new string[] { "ITMW_2H_AXE_BERSERK_107.3DS", "ITMW_AXE_NEW_02.3DS", "ITMW_AXE_NEW_03.3DS", "ITMW_AXE_NEW_04.3DS", "ITMW_AXE_ST03.3DS",
                    "ITMW_SLD_AXE_LAST.3DS", "ITMW_2H_G3A_DOUBLEAXE_01.3DS", "ItMw_Streitaxt3_New.3DS" }
            },
            // maces
            new ItemTemplatePreset()
            {
                ItemCondStat = CommonTemplates.ItemCondAtr_Str,
                WeaponDamageType = "dam_blunt",
                ItemType = "item_2hd_axe",
                Visuals = new string[] { "ITMW_2H_SPIKEHAMMER.3DS", "ITMW_2H_KNIGHTHAMMER.3DS", "ItMw_WarHammer_Iron.3DS", "ItMw_Steel_Warhammer.3DS",
                    "KM_WARHAMMER_RUNIC.3DS", "crushed_hammer_2h.3DS", "ITMW_2H_ARMORDESTR.3DS", "ItMw_2H_NewHammer_01.3DS", "ItMw_2H_SharpTeeth_New.3DS" },
                AltOnEquipFunc = "equip_2h_veryheavy();",
                AltOnUnEquipFunc = "unequip_2h_veryheavy();"
            }
        };

        public override string GetTemplate() => CommonTemplates.WeaponTemplate;
    }
}
