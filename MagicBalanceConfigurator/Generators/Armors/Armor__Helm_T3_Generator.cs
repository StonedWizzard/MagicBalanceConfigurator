using System;
using System.Collections.Generic;

namespace MagicBalanceConfigurator.Generators
{
    internal class Armor_Helm_T3_Generator : BaseArmorGenerator
    {
        public Armor_Helm_T3_Generator(RandomController controller) : base(controller, Consts.Armor_Helm_T3_FileName) 
        {
            TierPrefix = CommonTemplates.TierPrefix_T3;
            ItemIdPrefix = CommonTemplates.Armor_Helm_IdPrefix;
            ItemType = CommonTemplates.Armor_helm_RandSufix;
            ItemName = "Шлем";
            ModPower = 1.25;
            ItemsPrice = 1500;
            BaseOnEquipFunc = "equip_itar_hut();";
            BaseOnUnEquipFunc = "unequip_itar_hut();";
            SetArmorProtectionRange(35, 80);
            SetItemCondRange(100, 150);
            SetModsCountRange(3, 4);
        }

        protected override List<ItemTemplatePreset> BuildItemTemplatePresets() => new List<ItemTemplatePreset>()
        {
            // helms mana
            new ItemTemplatePreset()
            {
                ItemCondStat = CommonTemplates.ItemCondAtr_Mana,
                Visuals = new string[] { "ItAr_HelmHood.3ds", "ItAr_Hem_Yarkendar.3ds", "ITAR_DRAGONHELM.3DS", "DAEDRAHELM3.3DS",
                    "ItMi_IceCrown.3ds", "ITAR_SLEEPER_MASK_01.3ds", "ItAr_Helm_UndeadKing.3ds", "ITAR_CROWN_NEW_SPIRIT.3ds" },
                AltOnEquipFunc = "equip_itar_hut();",
                AltOnUnEquipFunc = "unequip_itar_hut();",
                ProtFireMult = 1.25,
                ProtMagicMult = 1.25,
                ProtPointMult = 0.5,
                ProtBluntMult = 0.75,
                ProtEdgeMult = 0.75,
                ProtFlyMult = 0.1,
            },
            // helms str
            new ItemTemplatePreset()
            {
                ItemCondStat = CommonTemplates.ItemCondAtr_Str,
                Visuals = new string[] { "ItAr_Helm_G3_02.3ds", "ItAr_Helm_G3_04.3ds", "ItAr_Hem_Hunt.3DS", "ITHL_HELMET_S_DAWNGUARDFULL.3ds",
                    "ItAr_Helm_Paladin_Elite_01.3ds", "ItAr_Helm_Paladin_01.3ds", "ItAr_Helm_Paladin_02.3ds", "ItAr_DJG_Helm.3ds", "ItHe_dark_02.3DS",
                    "ITAR_DRAGONHELM.3DS", "DAEDRAHELM3.3DS", "ITAR_ANCIENTHELM.3ds"},
                AltOnEquipFunc = "equip_itar_helm_new_02();",
                AltOnUnEquipFunc = "unequip_itar_helm_new_02();",
                ProtFireMult = 0.5,
                ProtMagicMult = 0.5,
                ProtPointMult = 0.75,
                ProtBluntMult = 1.25,
                ProtEdgeMult = 1.25,
                ProtFlyMult = 0.5,
            },
            // helms agi
            new ItemTemplatePreset()
            {
                ItemCondStat = CommonTemplates.ItemCondAtr_Agi,
                Visuals = new string[] { "ITHL_MAKEDHELMET2_S_STUDDED.3ds", "ITAR_HEM_HUNT_DEX_02.3ds", "ITAR_HEM_HUNT_DEX_03.3ds",
                    "ITHL_MAKEDHELMET3_A_TOOSHOO_LEATHER.3ds", "ITHL_MAKEDHELMET1_AS_THORNIARA_ROBE.3ds", "ItAr_Hem_Hunt.3DS", "ItAr_DJG_Helm.3ds",
                    "ItHe_dark_02.3DS", "ITAR_DRAGONHELM.3DS", "DAEDRAHELM3.3DS", "ItAr_Helm_UndeadKing.3ds" },
                AltOnEquipFunc = "equip_itar_helm_dex_04();",
                AltOnUnEquipFunc = "unequip_itar_helm_dex_04();",
                ProtFireMult = 0.75,
                ProtMagicMult = 0.75,
                ProtPointMult = 1.0,
                ProtBluntMult = 1.0,
                ProtEdgeMult = 1.0,
                ProtFlyMult = 0.25,
            }
        };

        public override string GetTemplate() => CommonTemplates.HelmTemplate;
    }
}
