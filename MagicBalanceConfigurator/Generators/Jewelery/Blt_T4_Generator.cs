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
            ItemVisuals = CommonTemplates.BeltVisuals;
            ItemModType = "StExt_ItemType_Belt";
        }

        public override string GetTemplate() => CommonTemplates.BeltTemplate;
    }
}
                  