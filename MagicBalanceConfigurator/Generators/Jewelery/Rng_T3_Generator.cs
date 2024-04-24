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
            ItemVisuals = CommonTemplates.RingVisuals;
            ItemModType = "StExt_ItemType_Ring";
        }

        public override string GetTemplate() => CommonTemplates.RingTemplate;
    }
}
                  