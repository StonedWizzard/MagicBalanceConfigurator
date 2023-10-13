namespace MagicBalanceConfigurator.Generators
{
    public class Pot_T3_Generator : BasePotionGenerator
    {
        public Pot_T3_Generator(RandomController controller) : base(controller, Consts.Pot_T3_FileName) 
        {
            TierPrefix = CommonTemplates.TierPrefix_T3;
            ItemIdPrefix = CommonTemplates.Poition_IdPrefix;
            ItemName = "Отличное зелье";            
            ItemType = CommonTemplates.Poition_RandSufix;
            ModPower = 3.5;
            ItemsPrice = 1500;
            SetModsCountRange(3, 4);
        }

        protected override string GetItemVisual() => CommonTemplates.PoitionsT3Visuals.GetRandomElement();
    }
}
