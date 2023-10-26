namespace MagicBalanceConfigurator.Generators
{
    public class Blt_T1_Generator : BaseGenerator
    {
        public Blt_T1_Generator(RandomController controller) : 
            base (controller, Consts.Blt_T1_FileName) 
        {
            TierPrefix = CommonTemplates.TierPrefix_T1;
            ItemIdPrefix = CommonTemplates.Belt_IdPrefix;
            ItemName = "Простой магический Пояс";
            UseUniqName = false;
            ItemType = CommonTemplates.Belt_RandSufix;
            ModPower = 1.5;
            ItemsPrice = 1000;
            SetModsCountRange(1, 2);
        }

        protected override string GetItemVisual() => CommonTemplates.BeltVisuals.GetRandomElement();

        public override string GetTemplate() => CommonTemplates.BeltTemplate;

    }
}
                  