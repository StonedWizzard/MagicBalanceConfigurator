using System;
using System.Collections.Generic;

namespace MagicBalanceConfigurator.Generators
{
    internal class Weap_Crossbow_T2_Generator : BaseWeaponGenerator
    {
        public Weap_Crossbow_T2_Generator(RandomController controller) : base(controller, Consts.Weap_crosbow_T2_FileName) 
        {
            TierPrefix = CommonTemplates.TierPrefix_T2;
            ItemIdPrefix = CommonTemplates.Weapon_crossbow_IdPrefix;
            ItemType = CommonTemplates.Weapon_crossbow_RandSufix;
            ItemName = "Арбалет";
            ModPower = 1;
            ItemsPrice = 1000;
            BaseOnEquipFunc = "equip_crossbow_medium();";
            BaseOnUnEquipFunc = "unequip_crossbow_medium();";
            SetWeaponDamageRange(75, 150);
            SetItemCondRange(80, 160);
            SetModsCountRange(2, 3);
            ProhibitedDamageTypes = new List<string>() { "dam_fire" };
            ProhibitedMods = new List<int> { 226, 227, 228 };
        }

        protected override List<ItemTemplatePreset> BuildItemTemplatePresets() => new List<ItemTemplatePreset>()
        {
            // crosbows
            new ItemTemplatePreset()
            {
                ItemCondStat = CommonTemplates.ItemCondAtr_Str,
                WeaponDamageType = "dam_point",
                ItemType = "item_crossbow",
                Visuals = new string[] { "ItRw_Crossbow_L_01.mms", "ItRw_Crossbow_L_02.mms", "ItRw_Crossbow_M_02.mms", "CROSSBOW_BLACK_03.mms" },
                ExtraConditions = new string[] { CommonTemplates.ItemCondAtr_Crosbow },
            },
            new ItemTemplatePreset()
            {
                ItemCondStat = CommonTemplates.ItemCondAtr_Crosbow,
                WeaponDamageType = "dam_point",
                ItemType = "item_crossbow",
                Visuals = new string[] { "ItRw_Crossbow_L_01.mms", "ItRw_Crossbow_L_02.mms", "ItRw_Crossbow_M_02.mms", "CROSSBOW_BLACK_03.mms" }
            }
        };

        public override string GetTemplate() => CommonTemplates.CrosbowTempalte;
    }
}
