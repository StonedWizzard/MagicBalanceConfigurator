namespace MagicBalanceConfigurator.Generators
{
    public class Rng_T4_Generator : BaseGenerator
    {
        public Rng_T4_Generator(RandomController controller) : 
            base (controller, Consts.Rng_T4_FileName) 
        {
            TierPrefix = CommonTemplates.TierPrefix_T4;
            ItemIdPrefix = CommonTemplates.Ring_IdPrefix;
            ItemName = "Уникальное магическое Кольцо";
            UseUniqName = true;
            ItemType = CommonTemplates.Ring_RandSufix;
            ModPower = 4;           
            ItemsPrice = 2000;
            SetModsCountRange(3, 4);
            ItemVisuals = CommonTemplates.RingVisuals;
            ItemModType = "StExt_ItemType_Ring";
        }

        public override string GetTemplate() => CommonTemplates.RingTemplate;
    }
}
                  