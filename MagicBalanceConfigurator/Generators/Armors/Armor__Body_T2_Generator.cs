using System;
using System.Collections.Generic;

namespace MagicBalanceConfigurator.Generators
{
    internal class Armor_Body_T2_Generator : BaseArmorGenerator
    {
        public Armor_Body_T2_Generator(RandomController controller) : base(controller, Consts.Armor_Body_T2_FileName) 
        {
            TierPrefix = CommonTemplates.TierPrefix_T2;
            ItemIdPrefix = CommonTemplates.Armor_Body_IdPrefix;
            ItemType = CommonTemplates.Armor_body_RandSufix;
            ItemName = "Доспех";
            ModPower = 1.75;
            ItemsPrice = 2500;
            BaseOnEquipFunc = "equip_otherarmor();";
            BaseOnUnEquipFunc = String.Empty;
            SetArmorProtectionRange(50, 100);
            SetItemCondRange(50, 125);
            SetModsCountRange(2, 3);
            ItemModType = "StExt_ItemType_Armor";
        }

        protected override List<ItemTemplatePreset> BuildItemTemplatePresets() => new List<ItemTemplatePreset>()
        {
            // armor mana
            new ItemTemplatePreset()
            {
                ItemNamePlaceholder = "Роба",
                ItemCondStat = CommonTemplates.ItemCondAtr_Mana,
                Visuals = new string[] { "ItAr_Governor.3DS", "ItAr_KdF_L.3ds", "kdfs.3ds", "ItAr_KDW_L_ADDON.3ds", "ItAr_DMT_L.3ds",
                    "ITAR_PREVIEW_SUM1.3ds", "ItAr_Xardas.3ds", "ItAr_GUR_L.3ds", "ItAr_GUR_M.3ds", "ItAr_Guard_05.3ds" },
                VisualChanges = new string[] { "PIRANHA_INNOSROBE.asc", "PIRANHA_INNOSROBE_NEW.asc", "PIRANHA_INNOSROBE_ADRIAN.asc",
                    "Armor_Kdf_L.asc", "FIREMAGE.asc", "ARMOR_WATERMAGES_L.asc", "DARKEMAGE.asc", "SUMMONERROBE1.asc", "ARMOR_DRK_L.asc",
                    "HUM_GURM_ARMOR.asc", "HUM_GURMAYA_ARMOR.asc", "ARMOR_KDM_ADEPT.asc" },
                AltOnEquipFunc = "equip_itar_robecommon();",
                AltOnUnEquipFunc = "unequip_itar_robecommon();",
                ProtFireMult = 1.35,
                ProtMagicMult = 1.35,
                ProtPointMult = 0.75,
                ProtBluntMult = 0.85,
                ProtEdgeMult = 0.85,
                ProtFlyMult = 0.25,
                SpecialSection = "weight = 1;"
            },
            // armor str
            new ItemTemplatePreset()
            {
                ItemCondStat = CommonTemplates.ItemCondAtr_Str,
                Visuals = new string[] { "ItAr_Ranger_ADDON.3ds", "ItAr_PIR_M_ADDON.3ds", "ItAr_Reb_M.3ds", "grdl.3ds", "ItAr_Bloodwyn_ADDON.3ds",
                    "ItAr_Bloodwyn_ADDO1.3ds", "Armor_Bloodwyn_ADDO1.asc", "ItAr_MIL_L.3DS", "ItAr_MIL_L_V1.3DS", "ItAr_Sld_L.3ds", "ItAr_Sld_L_V1.3ds",
                    "ItAr_Sld_M.3ds", "ItAr_Sld_M_V1.3ds", "ItAr_TPL_L.3ds", "ItAr_TPL_S.3ds", "ITAR_ORCS.3ds" },
                VisualChanges = new string[] { "HUM_HUNH_V3_ARMOR.ASC", "HUM_HUNH_V1_ARMOR.ASC", "HUM_HUNH_V2_ARMOR.ASC", "Armor_PIR_M_ADDON.asc",
                    "ItAr_Reb_M.asc", "NRDWARIOR.asc", "BUNTOWNIK.asc", "Hum_GRDL_ARMOR.asc", "Armor_Bloodwyn_ADDON.asc", "Spaeher.asc",
                    "WACHE_ARMOR_V2.asc", "Armor_Mil_S.asc", "Armor_Sld_L.asc", "ARMOR_SLD_L_FORGED.asc", "Armor_Sld_M.asc", "Armor_Sld_S.asc", 
                    "HUM_TPLL_ARMOR.asc", "HUM_TPLS_ARMOR.asc", "ARMOR_VAR.asc" },
                AltOnEquipFunc = "equip_otherarmor();",
                AltOnUnEquipFunc = String.Empty,
                ProtFireMult = 0.5,
                ProtMagicMult = 0.5,
                ProtPointMult = 0.85,
                ProtBluntMult = 1.35,
                ProtEdgeMult = 1.35,
                ProtFlyMult = 0.5,
                SpecialSection = "weight = 2;"
            },
            // armor hp
            new ItemTemplatePreset()
            {
                ItemCondStat = CommonTemplates.ItemCondAtr_Hp,
                Visuals = new string[] { "ItAr_Ranger_ADDON.3ds", "ItAr_PIR_L_ADDON.3ds", "ItAr_PIR_M_ADDON.3ds", "ItAr_Reb_M.3ds",
                    "ItAr_Reb_M.3ds", "ItAr_MIL_L.3DS", "ItAr_MIL_L_V1.3DS", "ItAr_Sld_L.3ds", "ItAr_Sld_L_V1.3ds", "ItAr_Sld_M.3ds",
                    "ITAR_BM_L.3DS", "ItAr_Uniform_M.3ds", "ITAR_ORCS.3ds" },
                VisualChanges = new string[] { "HUM_HUNH_V0_ARMOR.ASC", "Armor_Pir_L_Addon.ASC", "Armor_PIR_M_ADDON.asc", "GUILDS_BANDIT.asc",
                    "NRDWARIOR.asc", "WACHE_ARMOR_V2.asc", "ARMOR_RANGERIST.asc", "Armor_Sld_L.asc", "ARMOR_SLD_L_FORGED.asc", "Armor_Sld_M.asc",
                    "Armor_PIR_H_ADDON.asc", "ARMOR_SOILDER.asc", "HUM_ARMOR_AW_01.asc", "HUM_GRDI_ARMOR.asc", "ARMOR_VAR.asc", "ARMOR_SLD_DEX1.asc",
                    "ARMOR_TEMPLARHUNT.asc", "ARMOR_DK_START_DEX.asc", "ARMOR_DK_START.asc", "ARMOR_DEMONHUNTER_0.asc", "ARMOR_MLH_FORGED.asc" },
                AltOnEquipFunc = "equip_otherarmor();",
                AltOnUnEquipFunc = String.Empty,
                ProtFireMult = 0.5,
                ProtMagicMult = 0.5,
                ProtPointMult = 0.85,
                ProtBluntMult = 1.15,
                ProtEdgeMult = 1.25,
                ProtFlyMult = 0.75,
                SpecialSection = "weight = 1;"
            },
            // armor agi
            new ItemTemplatePreset()
            {
                ItemCondStat = CommonTemplates.ItemCondAtr_Agi,
                Visuals = new string[] { "ItAr_Ranger_ADDON.3ds", "ItAr_PIR_L_ADDON.3ds", "ItAr_Reb_M.3ds", "ItAr_Reb_M.3ds",
                    "ItAr_Djg_Crawler.3ds", "Armor_W2_TKnight.3ds", "ItAr_Sld_L.3ds", "ItAr_TPL_L.3ds", "ItAr_PIR_H_ADDON.3ds",
                    "ItAr_Uniform_M.3ds", "ItAr_Hun_M.3ds" },
                VisualChanges = new string[] { "HUM_HUNH_V0_ARMOR.ASC", "Armor_Pir_L_Addon.ASC", "GUILDS_BANDIT.asc", "Armor_Djg_Crawler.asc",
                    "Armor_MilHunt.asc", "Armor_Sld_L.asc", "HUM_TPLL_ARMOR.asc", "ARMOR_DHT_3_ARMOR.asc", "ARMOR_RAMIREZ_NEW.ASC",
                    "HUM_ARMOR_AW_01.asc", "HUM_GRDI_ARMOR.asc", "FER_M_BLACK_ARMOR_01.asc", "ARMOR_DK_START.asc", "ARMOR_DEMONHUNTER_0.asc", "ARMOR_MLH_FORGED.asc" },
                AltOnEquipFunc = "equip_oldghostarmor();",
                AltOnUnEquipFunc = "unequip_oldghostarmor();",
                ProtFireMult = 0.85,
                ProtMagicMult = 0.75,
                ProtPointMult = 1.1,
                ProtBluntMult = 1.0,
                ProtEdgeMult = 1.0,
                ProtFlyMult = 0.75,
                SpecialSection = "weight = 1;"
            }
        };

        public override string GetTemplate() => CommonTemplates.ArmorTemplate;
    }
}
