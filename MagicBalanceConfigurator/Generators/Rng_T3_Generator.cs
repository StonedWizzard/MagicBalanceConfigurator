namespace MagicBalanceConfigurator.Generators
{
    public class Rng_T3_Generator : BaseGenerator
    {
        public Rng_T3_Generator(RandomController controller) : 
            base (controller, Consts.Rng_T3_FileName) 
        {
            TierPrefix = CommonTemplates.TierPrefix_T3;
            ItemIdPrefix = CommonTemplates.Ring_IdPrefix;
            ItemName = "Редкое магическое Кольцо";
            UseUniqName = false;
            ItemType = CommonTemplates.Ring_RandSufix;
            ModPower = 2.5;
            ItemsPrice = 1500;
            SetModsCountRange(2, 3);
        }

        protected override string GetItemVisual() => CommonTemplates.AmuletVisuals.GetRandomElement();

        public override string GetTemplate() =>
@"instance [IdPrefix][Id](c_item) 
{
    name = name_ring;
    mainflag = item_kat_magic;
    flags = item_ring | item_mission;
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
    inv_zbias = invcam_entf_ring_standard;
    inv_rotz = invcam_z_ring_standard;
    inv_rotx = invcam_x_ring_standard;
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
                  