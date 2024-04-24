namespace MagicBalanceConfigurator.Generators
{
    public class Blt_T2_Generator : BaseGenerator
    {
        public Blt_T2_Generator(RandomController controller) : 
            base (controller, Consts.Blt_T2_FileName) 
        {
            TierPrefix = CommonTemplates.TierPrefix_T2;
            ItemIdPrefix = CommonTemplates.Belt_IdPrefix;
            ItemName = "Магический Пояс";
            UseUniqName = false;
            ItemType = CommonTemplates.Belt_RandSufix;
            ModPower = 2.5;
            ItemsPrice = 1500;
            SetModsCountRange(2, 3);
            ItemVisuals = CommonTemplates.BeltVisuals;
            ItemModType = "StExt_ItemType_Belt";
        }

        public override string GetTemplate() => CommonTemplates.BeltTemplate;
    }
}
                  