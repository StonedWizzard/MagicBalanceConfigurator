using System;
using System.Collections.Generic;

namespace MagicBalanceConfigurator.Generators
{
    internal class Armor_Body_T3_Generator : BaseArmorGenerator
    {
        public Armor_Body_T3_Generator(RandomController controller) : base(controller, Consts.Armor_Body_T3_FileName) 
        {
            TierPrefix = CommonTemplates.TierPrefix_T3;
            ItemIdPrefix = CommonTemplates.Armor_Body_IdPrefix;
            ItemType = CommonTemplates.Armor_body_RandSufix;
            ItemName = "Доспех";
            ModPower = 2.5;
            ItemsPrice = 4500;
            BaseOnEquipFunc = "equip_otherarmor();";
            BaseOnUnEquipFunc = String.Empty;
            SetArmorProtectionRange(100, 200);
            SetItemCondRange(125, 250);
            SetModsCountRange(3, 4);
        }

        protected override List<ItemTemplatePreset> BuildItemTemplatePresets() => new List<ItemTemplatePreset>()
        {
            // armor mana
            new ItemTemplatePreset()
            {
                ItemNamePlaceholder = "Роба",
                ItemCondStat = CommonTemplates.ItemCondAtr_Mana,
                Visuals = new string[] { "ItAr_KdF_L.3ds", "kdfs.3ds", "ItAr_KDW_L_ADDON.3ds", "ItAr_DMT_L.3ds",
                    "ITAR_PREVIEW_SUM1.3ds", "ItAr_Xardas.3ds", "ItAr_GUR_L.3ds", "ItAr_GUR_M.3ds", "ItAr_KdF_H.3ds",
                    "ItAr_KdW_H.3ds", "ITAR_PREVIEW_SUM2.3ds", "ItAr_GUR_H.3ds", "ItAr_Guard_05.3ds" },
                VisualChanges = new string[] { "Armor_Kdf_L.asc", "FIREMAGE.asc", "ARMOR_WATERMAGES_L.asc", "DARKEMAGE.asc", "SUMMONERROBE1.asc", "ARMOR_DRK_L.asc",
                    "HUM_GURM_ARMOR.asc", "Armor_Kdf_H.asc", "ARMOR_WATERMAGES_H.asc", "ARMOR_DRK_H.asc", "SUMMONERROBE2.asc", "ARMOR_DS_DARKMAG_03.asc",
                    "ARMOR_DS_DARKMAG_02.asc", "ARMOR_KDM_MASTER.asc", "HUM_GURS_ARMOR_NEW.asc", "HUM_GURS_ARMOR.asc", "ARMOR_KDM_ADEPT.asc" },
                AltOnEquipFunc = "equip_itar_kdf_h();",
                AltOnUnEquipFunc = "unequip_itar_kdf_h();",
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
                Visuals = new string[] { "ItAr_Uniform_H.3DS", "ITAR_DHT_END_4.3ds", "ItAr_Thorus_ADDON.3ds", "ItAr_CHAOS_ADDON.3ds",
                    "ITAR_CHAOS_ADDO1.3ds", "ITAR_CHAOS_ADDOZ.3ds", "Armor_W2_TKnight.3ds", "ItAr_Pal_M.3ds", "ItAr_Sld_H.3ds", "ItAr_Sld_H_V1.3ds",
                    "ItAr_Pal_H.3ds", "ItAr_Pal_H_V1.3ds", "ItAr_Pal_H_V2.3ds", "ItAr_Djg_M.3ds", "ItAr_Djg_H.3ds", "ItAr_Pal_M_V4.3ds", "ItAr_Pal_H_V8.3ds",
                    "ORC_NAJEMNIK_H.3ds", },
                VisualChanges = new string[] { "DEADRICARMOR.asc", "SKYRIMNORDPLYTOWA.asc", "DEADRICARMOZ.asc", "Armor_Thorus_ADDON.asc",
                    "Armor_CHAOS_ADDON.asc", "Armor_CHAOS_ADDOZ.asc", "Armor_CHAOS_ADDO1.asc", "ARMOR_DEMHUNT.asc", "czerwonakurtamax.ASC",
                    "Armor_Sld_H.asc", "ARMOR_SLDH_FORGED.asc", "ARMOR_SLD_ELITE.asc", "ARMOR_LHBO_ADDON.asc", "Armor_Pal_V.asc", "ARMOR_PAL_NEW_H02.asc",
                    "ITAR_PAL_M_V15.asc", "ITAR_PAL_M_V2.asc", "Armor_Pal_H.asc", "ARMOR_PALADIN_HV1.asc", "ITAR_PAL_H_V15.asc", "ITAR_PAL_H_V2.asc",
                    "Armor_Djg_M.asc", "Armor_Djg_N.asc", "Armor_Djg_D.asc", "Armor_Djg_H.asc", "Armor_Djg_I.asc", "ARMOR_DJG_H_CM3.asc", "DRAGONBONEARMOR.asc",
                    "Armor_Pal_D.asc", "Armor_Pal_U.asc", "ARMOR_DRAMTHAR.asc", "OREARMOR_ASGARD.asc", "Armor_Ilarah.ASC", "ARMOR_WARRIOR_LIGHT.asc",
                    "ARMOR_WARRIOR_DARK.asc", "Armor_Pal_Skeleton.asc", "Armor_MayaZombie_Addon.asc", "ORC_NAJEMNIK_H.asc", "itar_knight_darkness.asc",
                    "ARMOR_DRAMTHAR2.asc" },
                AltOnEquipFunc = "equip_otherarmor();",
                AltOnUnEquipFunc = String.Empty,
                ProtFireMult = 0.5,
                ProtMagicMult = 0.5,
                ProtPointMult = 0.85,
                ProtBluntMult = 1.35,
                ProtEdgeMult = 1.35,
                ProtFlyMult = 0.5,
                SpecialSection = "weight = 4;"
            },
            // armor hp
            new ItemTemplatePreset()
            {
                ItemCondStat = CommonTemplates.ItemCondAtr_Hp,
                Visuals = new string[] { "ItAr_Uniform_H.3DS", "ITAR_DHT_END_4.3ds", "ItAr_Thorus_ADDON.3ds", "ItAr_CHAOS_ADDON.3ds",
                    "ITAR_CHAOS_ADDO1.3ds", "ITAR_CHAOS_ADDOZ.3ds", "Armor_W2_TKnight.3ds", "ItAr_Pal_M.3ds", "ItAr_Sld_H.3ds", "ItAr_Sld_H_V1.3ds",
                    "ItAr_Djg_L.3ds", "ItAr_Djg_L.3ds", "ItAr_Djg_M.3ds", "ItAr_CorAngar.3ds", "ORC_NAJEMNIK_H.3ds" },
                VisualChanges = new string[] { "DEADRICARMOR.asc", "SKYRIMNORDPLYTOWA.asc", "PIRANHA_SOWL.asc", "DEADRICARMOZ.asc",
                    "ARENABOSS_6_ARMOR.asc", "Armor_Thorus_ADDON.asc", "Armor_CHAOS_ADDON.asc", "Armor_CHAOS_ADDOZ.asc", "Armor_CHAOS_ADDO1.asc",
                    "ARMOR_DEMHUNT.asc", "czerwonakurtamax.ASC", "Armor_Sld_H.asc", "ARMOR_SLDH_FORGED.asc", "Armor_Pal_M.asc",
                    "Armor_Djg_S.asc", "Armor_Djg_L.asc", "Armor_Djg_M.asc", "Armor_Djg_N.asc", "Armor_Djg_D.asc", "HUM_TPLM_ARMOR.asc",
                    "Armor_CorAngar_1.asc", "HUM_TPLS_ARMOR.asc", "ARMOR_TPL_ELITE.asc", "ARMOR_DRAMTHAR.asc", "OREARMOR_ASGARD.asc", "Armor_Ilarah.ASC", 
                    "ARMOR_WARRIOR_LIGHT.asc", "ARMOR_WARRIOR_DARK.asc", "Armor_MayaZombie_Addon.asc", "ORC_NAJEMNIK_H.asc", "ARMOR_DEMHUNT.asc",
                    "ARMOR_DK_START.asc", "ARMOR_DRAMTHAR2.asc", "ARMOR_DKNIGHT_DEX_HEAVY.ASC" },
                AltOnEquipFunc = "equip_otherarmor();",
                AltOnUnEquipFunc = String.Empty,
                ProtFireMult = 0.5,
                ProtMagicMult = 0.5,
                ProtPointMult = 0.85,
                ProtBluntMult = 1.15,
                ProtEdgeMult = 1.25,
                ProtFlyMult = 0.75,
                SpecialSection = "weight = 3;"
            },
            // armor agi
            new ItemTemplatePreset()
            {
                ItemCondStat = CommonTemplates.ItemCondAtr_Agi,
                Visuals = new string[] { "ItAr_Uniform_H.3DS", "ITAR_DHT_END_4.3ds", "ITAR_BM_L.3DS", "ItAr_PIR_H_ADDON.3ds", "ItAr_CHAOS_ADDON.3ds",
                    "ITAR_CHAOS_ADDO1.3ds", "ITAR_CHAOS_ADDOZ.3ds", "ItAr_Djg_L.3ds", "ItAr_Djg_L.3ds", "ItAr_CorAngar.3ds", "ITAR_ASS_M.3ds",
                    "ItAr_Hun_X.3ds", "ITAR_ORCS.3ds" },
                VisualChanges = new string[] { "SZKLANKA1.asc", "PIRANHA_SOWL.asc", "DEADRICARMOZ.asc", "ARMOR_SOILDER.asc", "Armor_PIR_N_ADDON.asc",
                     "Armor_CHAOS_ADDON.asc", "Armor_CHAOS_ADDOZ.asc", "Armor_CHAOS_ADDO1.asc", "Armor_Djg_S.asc", "Armor_Djg_L.asc", "HUM_TPLM_ARMOR.asc",
                     "Armor_CorAngar_1.asc", "HUM_TPLS_ARMOR.asc", "ARMOR_TPL_ELITE.asc", "ARMOR_DRAMTHAR.asc", "Armor_Ilarah.ASC", "HUM_ASSB_Armor.asc",
                     "FER_TROLL_ARMOR_01.asc", "ARMOR_HUNTER_4.ASC", "ARMOR_VAR.asc", "ARMOR_DHT_3_ARMOR.asc", "FER_H_ARMOR_01.asc", "ItAr_GodArmor.asc", 
                     "HUM_ASSA_Armor.asc", "ARMOR_DEMHUNT.asc", "ARMOR_NORDMARRUESTUNG.asc", "ARMOR_TEMPLARHUNT.asc", "ARMOR_DK_START_DEX.asc", "ARMOR_DKNIGHT_DEX_LIGHT.ASC",
                     "ARMOR_DKNIGHT_DEX_HEAVY.ASC", "ARMOR_DEMONHUNTER_1.ASC", "ARMOR_TPL_ELITE2.asc", "ARMOR_MLH_FORGED.asc" },
                AltOnEquipFunc = "equip_oldghostarmor();",
                AltOnUnEquipFunc = "unequip_oldghostarmor();",
                ProtFireMult = 0.85,
                ProtMagicMult = 0.75,
                ProtPointMult = 1.1,
                ProtBluntMult = 1.0,
                ProtEdgeMult = 1.0,
                ProtFlyMult = 0.75,
                SpecialSection = "weight = 2;"
            }
        };

        public override string GetTemplate() => CommonTemplates.ArmorTemplate;
    }
}
