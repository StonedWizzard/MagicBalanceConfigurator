using System;
using System.Collections.Generic;

namespace MagicBalanceConfigurator.Generators
{
    internal class Weap_Crossbow_T3_Generator : BaseWeaponGenerator
    {
        public Weap_Crossbow_T3_Generator(RandomController controller) : base(controller, Consts.Weap_crosbow_T3_FileName) 
        {
            TierPrefix = CommonTemplates.TierPrefix_T3;
            ItemIdPrefix = CommonTemplates.Weapon_crossbow_IdPrefix;
            ItemType = CommonTemplates.Weapon_crossbow_RandSufix;
            ItemName = "Арбалет";
            ModPower = 2;
            ItemsPrice = 1500;
            BaseOnEquipFunc = "equip_crossbow_heavy();";
            BaseOnUnEquipFunc = "unequip_crossbow_heavy();";
            SetWeaponDamageRange(175, 275);
            SetItemCondRange(175, 275);
            SetModsCountRange(3, 4);
            ProhibitedDamageTypes = new List<string>() { "dam_fire" };
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
