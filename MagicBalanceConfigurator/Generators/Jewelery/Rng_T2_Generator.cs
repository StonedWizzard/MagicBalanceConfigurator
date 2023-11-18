namespace MagicBalanceConfigurator.Generators
{
    public class Rng_T2_Generator : BaseGenerator
    {
        public Rng_T2_Generator(RandomController controller) :
            base(controller, Consts.Rng_T2_FileName)
        {
            TierPrefix = CommonTemplates.TierPrefix_T2;
            ItemIdPrefix = CommonTemplates.Ring_IdPrefix;
            ItemName = "Магическое Кольцо";
            UseUniqName = false;
            ItemType = CommonTemplates.Ring_RandSufix;
            ModPower = 1.5;
            ItemsPrice = 1000;
            SetModsCountRange(1, 2);
            ItemVisuals = CommonTemplates.RingVisuals;
        }

        public override string GetTemplate() => CommonTemplates.RingTemplate;
    }
}
                  