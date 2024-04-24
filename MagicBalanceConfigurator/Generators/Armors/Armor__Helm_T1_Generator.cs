using System;
using System.Collections.Generic;

namespace MagicBalanceConfigurator.Generators
{
    internal class Armor_Helm_T1_Generator : BaseArmorGenerator
    {
        public Armor_Helm_T1_Generator(RandomController controller) : base(controller, Consts.Armor_Helm_T1_FileName) 
        {
            TierPrefix = CommonTemplates.TierPrefix_T1;
            ItemIdPrefix = CommonTemplates.Armor_Helm_IdPrefix;
            ItemType = CommonTemplates.Armor_helm_RandSufix;
            ItemName = "Шлем";
            ModPower = 0.5;
            ItemsPrice = 750;
            BaseOnEquipFunc = "equip_itar_hut();";
            BaseOnUnEquipFunc = "unequip_itar_hut();";
            SetArmorProtectionRange(5, 20);
            SetItemCondRange(25, 50);
            SetModsCountRange(1, 2);
            ItemModType = "StExt_ItemType_Helm";
        }

        protected override List<ItemTemplatePreset> BuildItemTemplatePresets() => new List<ItemTemplatePreset>()
        {
            // helms mana
            new ItemTemplatePreset()
            {
                ItemCondStat = CommonTemplates.ItemCondAtr_Mana,
                Visuals = new string[] { "ITAR_THIEFHELMET.3ds", "ItAr_HelmHood.3ds" },
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
                Visuals = new string[] { "ItAr_Helm_01.3ds", "ItAr_Helm_G3_01.3ds" },
                AltOnEquipFunc = "equip_itar_helm_01();",
                AltOnUnEquipFunc = "unequip_itar_helm_01();",
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
                Visuals = new string[] { "ITAR_THIEFHELMET.3ds", "ItAr_HelmHood.3ds", "ItAr_Hem_Pirate.3ds" },
                AltOnEquipFunc = "equip_itar_hut();",
                AltOnUnEquipFunc = "unequip_itar_hut();",
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
