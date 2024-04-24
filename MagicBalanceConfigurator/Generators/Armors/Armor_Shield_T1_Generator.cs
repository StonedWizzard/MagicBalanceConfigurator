using System;
using System.Collections.Generic;

namespace MagicBalanceConfigurator.Generators
{
    internal class Armor_Shield_T1_Generator : BaseShieldGenerator
    {
        public Armor_Shield_T1_Generator(RandomController controller) : base(controller, Consts.Armor_Shield_T1_FileName) 
        {
            TierPrefix = CommonTemplates.TierPrefix_T1;
            ItemIdPrefix = CommonTemplates.Armor_Shield_IdPrefix;
            ItemType = CommonTemplates.Armor_shield_RandSufix;
            ItemName = "Щит";
            ModPower = 0.75;
            ItemsPrice = 500;
            BaseOnEquipFunc = "equip_itar_shield_02();";
            BaseOnUnEquipFunc = "unequip_itar_shield_02();";
            SetArmorProtectionRange(30, 60);
            SetItemCondRange(25, 50);
            SetModsCountRange(1, 2);
            ProhibitedMods = new List<int> { 326, 328, 329 };
            ItemModType = "StExt_ItemType_Shield";
        }

        protected override List<ItemTemplatePreset> BuildItemTemplatePresets() => new List<ItemTemplatePreset>()
        {
            // shields
            new ItemTemplatePreset()
            {
                ItemCondStat = CommonTemplates.ItemCondAtr_Shield,
                Visuals = new string[] { "ITAR_NEWSHIELD_01.3ds", "ITSH_SHIELD_G3_ROUND.3ds", "ITAR_NEWSHIELD_02.3ds", "BESTFARMERWOODSHIELD.3ds" },
                ProtFireMult = 0.3,
                ProtMagicMult = 0.3,
                ProtPointMult = 1.5,
                ProtFlyMult = 0.25,
            }            
        };

        public override string GetTemplate() => CommonTemplates.ShieldTemplate;
    }
}
