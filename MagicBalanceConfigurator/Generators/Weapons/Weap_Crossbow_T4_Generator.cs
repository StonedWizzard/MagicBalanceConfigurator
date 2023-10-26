using System;
using System.Collections.Generic;

namespace MagicBalanceConfigurator.Generators
{
    internal class Weap_Crossbow_T4_Generator : BaseWeaponGenerator
    {
        public Weap_Crossbow_T4_Generator(RandomController controller) : base(controller, Consts.Weap_crosbow_T4_FileName) 
        {
            TierPrefix = CommonTemplates.TierPrefix_T4;
            ItemIdPrefix = CommonTemplates.Weapon_crossbow_IdPrefix;
            ItemType = CommonTemplates.Weapon_crossbow_RandSufix;
            ItemName = "Арбалет";
            ModPower = 3;
            ItemsPrice = 2000;
            BaseOnEquipFunc = "equip_crossbow_heavy();";
            BaseOnUnEquipFunc = "unequip_crossbow_heavy();";
            SetWeaponDamageRange(275, 400);
            SetItemCondRange(275, 300);
            SetModsCountRange(4, 5);
        }

        protected override List<ItemTemplatePreset> BuildItemTemplatePresets() => new List<ItemTemplatePreset>()
        {
            // crosbows
            new ItemTemplatePreset()
            {
                ItemCondStat = CommonTemplates.ItemCondAtr_Str,
                WeaponDamageType = "dam_point",
                ItemType = "item_crossbow",
                Visuals = new string[] { "ITRW_CROSSBOW_A_XBOW_OCEAN.mms", "ITRW_CROSSBOW_A_XBOW_LEVIATHAN.mms", "KM_ITRW_CROSSBOW_01_UNDEADTOP.mms",
                    "ItRw_Crossbow_H_01.mms", "ItRw_Crossbow_M_02.mms" },
                ExtraConditions = new string[] { CommonTemplates.ItemCondAtr_Crosbow },
            },
            new ItemTemplatePreset()
            {
                ItemCondStat = CommonTemplates.ItemCondAtr_Crosbow,
                WeaponDamageType = "dam_point",
                ItemType = "item_crossbow",
                Visuals = new string[] { "ITRW_CROSSBOW_A_XBOW_OCEAN.mms", "ITRW_CROSSBOW_A_XBOW_LEVIATHAN.mms", "KM_ITRW_CROSSBOW_01_UNDEADTOP.mms",
                    "ItRw_Crossbow_H_01.mms", "ItRw_Crossbow_M_02.mms" }
            }
        };

        public override string GetTemplate() => CommonTemplates.CrosbowTempalte;
    }
}
