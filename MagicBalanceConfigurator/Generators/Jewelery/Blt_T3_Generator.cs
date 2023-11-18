namespace MagicBalanceConfigurator.Generators
{
    public class Blt_T3_Generator : BaseGenerator
    {
        public Blt_T3_Generator(RandomController controller) : 
            base (controller, Consts.Blt_T3_FileName) 
        {
            TierPrefix = CommonTemplates.TierPrefix_T3;
            ItemIdPrefix = CommonTemplates.Belt_IdPrefix;
            ItemName = "Редкий магический Пояс";
            UseUniqName = false;
            ItemType = CommonTemplates.Belt_RandSufix;
            ModPower = 4;
            ItemsPrice = 2500;
            SetModsCountRange(3, 4);
            ItemVisuals = CommonTemplates.BeltVisuals;
        }

        public override string GetTemplate() => CommonTemplates.BeltTemplate;
    }
}
                  