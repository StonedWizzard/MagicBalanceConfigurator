using System;
using System.Collections.Generic;

namespace MagicBalanceConfigurator.Generators
{
    internal class Armor_Body_T1_Generator : BaseArmorGenerator
    {
        public Armor_Body_T1_Generator(RandomController controller) : base(controller, Consts.Armor_Body_T1_FileName) 
        {
            TierPrefix = CommonTemplates.TierPrefix_T1;
            ItemIdPrefix = CommonTemplates.Armor_Body_IdPrefix;
            ItemType = CommonTemplates.Armor_body_RandSufix;
            ItemName = "Доспех";
            ModPower = 1;
            ItemsPrice = 1500;
            BaseOnEquipFunc = "equip_otherarmor();";
            BaseOnUnEquipFunc = String.Empty;
            SetArmorProtectionRange(15, 45);
            SetItemCondRange(15, 40);
            SetModsCountRange(1, 2);
            ItemModType = "StExt_ItemType_Armor";
        }

        protected override List<ItemTemplatePreset> BuildItemTemplatePresets() => new List<ItemTemplatePreset>()
        {
            // armor mana
            new ItemTemplatePreset()
            {
                ItemNamePlaceholder = "Роба",
                ItemCondStat = CommonTemplates.ItemCondAtr_Mana,
                Visuals = new string[] { "ItAr_VLK_L.3DS", "ItAr_VLK_M.3DS", "ItAr_VLK_H.3DS", "ItAr_Alch.3DS", "ItAr_Governor.3DS",
                    "ItAr_Nov_L.3ds", "ItAr_NDW_L.3ds", "ItAr_NDM_L.3ds", "ItAr_Uniform_L.3DS" },
                VisualChanges = new string[] { "Armor_Vlk_L.asc", "Armor_Vlk_M.asc", "ItAr_TopTrader_02.asc", 
                    "ItAr_TopTrader_01.asc", "ItAr_TopTrader_03.asc", "Armor_Alchemist.asc", "Armor_Judge.asc", "HUM_NOVL_Armor.asc",
                    "Armor_Nov_L.asc", "Armor_NDW_L.asc", "Armor_NDM_L.asc" },
                AltOnEquipFunc = "equip_itar_nov_l();",
                AltOnUnEquipFunc = "unequip_itar_nov_l();",
                ProtFireMult = 1.35,
                ProtMagicMult = 1.35,
                ProtPointMult = 0.75,
                ProtBluntMult = 0.85,
                ProtEdgeMult = 0.85,
                ProtFlyMult = 0.25,
                SpecialSection = "weight = 0;"
            },
            // armor str
            new ItemTemplatePreset()
            {
                ItemCondStat = CommonTemplates.ItemCondAtr_Str,
                Visuals = new string[] { "ItAr_VLK_L.3DS", "ItAr_VLK_M.3DS", "ItAr_VLK_H.3DS", "ItAr_Lester.3ds",
                    "RoWoo_armor.3ds", "ItAr_Leather_L.3ds", "ITAR_BM_L.3DS", "ItAr_Reb_M.3ds", "ItAr_Diego.3ds" },
                VisualChanges = new string[] { "HUM_NOVL_Armor.asc", "Armor_Vlk_L.asc", "Armor_Vlk_M.asc", "ItAr_TopTrader_02.asc",
                    "ItAr_TopTrader_01.asc", "ItAr_TopTrader_03.asc", "Armor_Lester.asc", "Hum_RoWoo_armor.asc", 
                    "ARMOR_LEATHER_L_GRD5.asc", "ARMOR_LEATHER_L_GRD1.asc", "ARMOR_BM_M.asc", "ARMOR_RANGERIST.asc",
                    "ARMOR_GERALT_ADDON_GRD1.asc", "ARMOR_SHADOW_OLD.asc" },
                AltOnEquipFunc = "equip_otherarmor();",
                AltOnUnEquipFunc = String.Empty,
                ProtFireMult = 0.5,
                ProtMagicMult = 0.5,
                ProtPointMult = 0.85,
                ProtBluntMult = 1.35,
                ProtEdgeMult = 1.35,
                ProtFlyMult = 0.5,
                SpecialSection = "weight = 1;"
            },
            // armor hp
            new ItemTemplatePreset()
            {
                ItemCondStat = CommonTemplates.ItemCondAtr_Hp,
                Visuals = new string[] { "ItAr_Sekbed.3ds", "ItAr_Prisonel.3ds", "ItAr_Prisoner.3ds", "ItAr_Bau_L.3DS", "ARMOR_BAU_L_KANION.3DS",
                    "ItAr_Bau_M.3ds", "ARMOR_BAU_M_KANION.3ds", "ItAr_Wirt.3DS", "ItAr_Smith.3DS", "ItAr_Uniform_L.3DS", "ItAr_Diego.3ds" },
                VisualChanges = new string[] { "Armor_Prisonel.asc", "Armor_Prisoner.asc", "Armor_Bau_L.asc", "ARMOR_BAU_L_KANION.asc",
                    "Armor_Bau_M.asc", "ARMOR_BAU_M_KANION.asc", "Armor_Barkeeper.asc", "Armor_Smith.asc", "HUM_BODY_COOKSMITH.ASC",
                    "MATROSENKLEIDUNZ.asc", "Armor_Her_N.asc", "ARMOR_GERALT_ADDON_GRD1.asc", "ARMOR_SHADOW_OLD.asc" },
                AltOnEquipFunc = "equip_otherarmor();",
                AltOnUnEquipFunc = String.Empty,
                ProtFireMult = 0.5,
                ProtMagicMult = 0.5,
                ProtPointMult = 0.85,
                ProtBluntMult = 1.15,
                ProtEdgeMult = 1.25,
                ProtFlyMult = 0.75,
                SpecialSection = "weight = 0;"
            },
            // armor agi
            new ItemTemplatePreset()
            {
                ItemCondStat = CommonTemplates.ItemCondAtr_Agi,
                Visuals = new string[] { "ItAr_VLK_L.3DS", "ItAr_VLK_M.3DS", "ItAr_VLK_H.3DS", "ItAr_Uniform_L.3DS",
                    "RoWoo_armor.3ds", "ItAr_Leather_L.3ds", "ITAR_BM_L.3DS", "ItAr_Diego.3ds" },
                VisualChanges = new string[] { "HUM_NOVL_Armor.asc", "Armor_Vlk_L.asc", "Armor_Vlk_M.asc", "ItAr_TopTrader_02.asc",
                    "ItAr_TopTrader_01.asc", "ItAr_TopTrader_03.asc", "Hum_RoWoo_armor.asc", "Armor_Her_N.asc", "HUM_DHT1_ARMOR.asc",
                    "ARMOR_LEATHER_L_GRD5.asc", "ARMOR_LEATHER_L_GRD1.asc", "ARMOR_BM_M.asc", "ARMOR_GERALT_ADDON_GRD1.asc", 
                    "ARMOR_SHADOW_OLD.asc" },
                AltOnEquipFunc = "equip_otherarmor();",
                AltOnUnEquipFunc = String.Empty,
                ProtFireMult = 0.85,
                ProtMagicMult = 0.75,
                ProtPointMult = 1.1,
                ProtBluntMult = 1.0,
                ProtEdgeMult = 1.0,
                ProtFlyMult = 0.75,
                SpecialSection = "weight = 0;"
            }
        };

        public override string GetTemplate() => CommonTemplates.ArmorTemplate;
    }
}
