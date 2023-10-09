﻿using System.Windows.Forms;

namespace MagicBalanceConfigurator.Generators
{
    public class Aml_T2_Generator : BaseGenerator
    {
        public Aml_T2_Generator(RandomController controller) : 
            base (controller, Consts.Aml_T2_FileName) 
        {
            TierPrefix = CommonTemplates.TierPrefix_T2;
            ItemIdPrefix = CommonTemplates.Amulet_IdPrefix;
            ItemName = "Магический Амулет";
            UseUniqName = false;
            ItemType = CommonTemplates.Amulet_RandSufix;
            ModPower = 3;
            ItemsPrice = 1750;
            SetModsCountRange(2, 3);
        }

        protected override string GetItemVisual() => CommonTemplates.AmuletVisuals.GetRandomElement();

        public override string GetTemplate() =>
@"instance [IdPrefix][Id](c_item) 
{
    name = name_amulett;
    mainflag = item_kat_magic;
    flags = item_amulet | item_mission;
    value = [Price];
    visual = [Visual];
    visual_skin = 0;
    material = mat_metal;
    on_equip = equip_[IdPrefix][Id];
    on_unequip = unequip_[IdPrefix][Id];
    wear = wear_effect;
    description = [NameId];
[ModsText]
    text[5] = name_value;
    count[5] = value;
    inv_zbias = invcam_entf_amulette_standard;
    inv_animate = 1;
};
func void equip_[IdPrefix][Id]()
{
[ModsEquip]
};
func void unequip_[IdPrefix][Id]()
{
[ModsUnEquip]
};";
    }
}
                  