using System;
using System.Collections.Generic;

namespace MagicBalanceConfigurator.Generators
{
    internal class Armor_Shield_T2_Generator : BaseShieldGenerator
    {
        public Armor_Shield_T2_Generator(RandomController controller) : base(controller, Consts.Armor_Shield_T2_FileName) 
        {
            TierPrefix = CommonTemplates.TierPrefix_T2;
            ItemIdPrefix = CommonTemplates.Armor_Shield_IdPrefix;
            ItemType = CommonTemplates.Armor_shield_RandSufix;
            ItemName = "Щит";
            ModPower = 1.25;
            ItemsPrice = 1000;
            BaseOnEquipFunc = "equip_itar_shield_03();";
            BaseOnUnEquipFunc = "unequip_itar_shield_03();";
            SetArmorProtectionRange(60, 90);
            SetItemCondRange(50, 100);
            SetModsCountRange(2, 3);
            ProhibitedMods = new List<int> { 326, 328, 329 };
        }

        protected override List<ItemTemplatePreset> BuildItemTemplatePresets() => new List<ItemTemplatePreset>()
        {
            // shields
            new ItemTemplatePreset()
            {
                ItemCondStat = CommonTemplates.ItemCondAtr_Shield,
                Visuals = new string[] { "ITSH_SHIELD_GUARD_01.3ds", "ITAR_NEWSHIELD_03.3ds", "ITSH_SHIELD_A_WOLF.3DS", "ITAR_NEWSHIELD_04.3ds" },
                ProtFireMult = 0.3,
                ProtMagicMult = 0.3,
                ProtPointMult = 1.5,
                ProtFlyMult = 0.25,
            }            
        };

        public override string GetTemplate() => CommonTemplates.ShieldTemplate;
    }
}
