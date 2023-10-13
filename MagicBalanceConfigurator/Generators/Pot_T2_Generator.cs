namespace MagicBalanceConfigurator.Generators
{
    public class Pot_T2_Generator : BasePotionGenerator
    {
        public Pot_T2_Generator(RandomController controller) : base(controller, Consts.Pot_T2_FileName) 
        {
            TierPrefix = CommonTemplates.TierPrefix_T2;
            ItemIdPrefix = CommonTemplates.Poition_IdPrefix;
            ItemName = "Зелье";            
            ItemType = CommonTemplates.Poition_RandSufix;
            ModPower = 2.25;
            ItemsPrice = 1000;
            SetModsCountRange(2, 3);
        }

        protected override string GetItemVisual() => CommonTemplates.PoitionsT2Visuals.GetRandomElement();
    }
}
