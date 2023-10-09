namespace MagicBalanceConfigurator.Generators
{
    public class Blt_T4_Generator : BaseGenerator
    {
        public Blt_T4_Generator(RandomController controller) : 
            base (controller, Consts.Blt_T4_FileName) 
        {
            TierPrefix = CommonTemplates.TierPrefix_T4;
            ItemIdPrefix = CommonTemplates.Belt_IdPrefix;
            ItemName = "Уникальный магический Пояс";
            UseUniqName = true;
            ItemType = CommonTemplates.Belt_RandSufix;
            ModPower = 5;
            ItemsPrice = 3000;
            SetModsCountRange(4, 5);
        }

        protected override string GetItemVisual() => CommonTemplates.BeltVisuals.GetRandomElement();

        public override string GetTemplate() =>
@"instance [IdPrefix][Id](c_item) 
{
    name = stext_itbe_rnd_name;
    mainflag = item_kat_magic;
    flags = item_belt | item_mission | item_multi;
    value = [Price];
    visual = [Visual];
    visual_skin = 0;
    material = mat_metal;
    on_equip = equip_[IdPrefix][Id];
    on_unequip = unequip_[IdPrefix][Id];
    description = [NameId];
[ModsText]
    text[5] = name_value;
    count[5] = value;
    inv_animate = 0;
    inv_rotx = invcam_entf_misc2_standard;
    inv_zbias = invcam_entf_amulette_standard;
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
                  