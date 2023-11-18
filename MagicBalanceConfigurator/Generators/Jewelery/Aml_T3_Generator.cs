using System.Linq;

namespace MagicBalanceConfigurator.Generators
{
    public class Aml_T3_Generator : BaseGenerator
    {
        public Aml_T3_Generator(RandomController controller) : 
            base (controller, Consts.Aml_T3_FileName) 
        {
            TierPrefix = CommonTemplates.TierPrefix_T3;
            ItemIdPrefix = CommonTemplates.Amulet_IdPrefix;
            ItemName = "Редкий магический Амулет";
            UseUniqName = false;
            ItemType = CommonTemplates.Amulet_RandSufix;
            ModPower = 4;
            ItemsPrice = 2500;
            SetModsCountRange(3 , 4);
            ItemVisuals = CommonTemplates.AmuletVisuals;
        }

        public override string GetTemplate() => CommonTemplates.AmuletTemplate;
    }
}
                  