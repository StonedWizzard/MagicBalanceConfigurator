using System;
using System.Collections.Generic;

namespace MagicBalanceConfigurator.Generators
{
    internal class Armor_Shield_T4_Generator : BaseShieldGenerator
    {
        public Armor_Shield_T4_Generator(RandomController controller) : base(controller, Consts.Armor_Shield_T4_FileName) 
        {
            TierPrefix = CommonTemplates.TierPrefix_T4;
            ItemIdPrefix = CommonTemplates.Armor_Shield_IdPrefix;
            ItemType = CommonTemplates.Armor_shield_RandSufix;
            ItemName = "Щит";
            ModPower = 3;
            ItemsPrice = 2500;
            BaseOnEquipFunc = "equip_itar_shield_09();";
            BaseOnUnEquipFunc = "unequip_itar_shield_09();";
            SetArmorProtectionRange(120, 175);
            SetItemCondRange(200, 300);
            SetModsCountRange(4, 5);
            ProhibitedMods = new List<int> { 326, 328, 329 };
        }

        protected override List<ItemTemplatePreset> BuildItemTemplatePresets() => new List<ItemTemplatePreset>()
        {
            // shields
            new ItemTemplatePreset()
            {
                ItemCondStat = CommonTemplates.ItemCondAtr_Shield,
                Visuals = new string[] { "ItAr_Shield_07_02.3ds", "Innos_bulwak.3ds", "ITAR_SHIELD_GOD.3DS", "Udead_Guard.3ds", "ItAr_Shield_04_New.3ds"},
                ProtFireMult = 0.3,
                ProtMagicMult = 0.3,
                ProtPointMult = 1.5,
                ProtFlyMult = 0.25,
            }            
        };

        public override string GetTemplate() => CommonTemplates.ShieldTemplate;
    }
}
