namespace MagicBalanceConfigurator.Generators
{
    public class Pot_T4_Generator : BasePotionGenerator
    {
        public Pot_T4_Generator(RandomController controller) : base(controller, Consts.Pot_T4_FileName) 
        {
            TierPrefix = CommonTemplates.TierPrefix_T4;
            ItemIdPrefix = CommonTemplates.Poition_IdPrefix;
            ItemName = "Уникальное зелье";            
            ItemType = CommonTemplates.Poition_RandSufix;
            ModPower = 5;
            ItemsPrice = 2500;
            SetDurationRange(12, 240);
            SetModsCountRange(3, 4);
        }

        protected override string GetItemVisual() => CommonTemplates.PoitionsT3Visuals.GetRandomElement();
    }
}
