using System.Linq;

namespace MagicBalanceConfigurator.Generators
{
    public class Aml_T4_Generator : BaseGenerator
    {
        public Aml_T4_Generator(RandomController controller) : 
            base (controller, Consts.Aml_T4_FileName) 
        {
            TierPrefix = CommonTemplates.TierPrefix_T4;
            ItemIdPrefix = CommonTemplates.Amulet_IdPrefix;
            ItemName = "Уникальный магический Амулет";
            UseUniqName = true;
            ItemType = CommonTemplates.Amulet_RandSufix;
            ModPower = 5.5;
            ItemsPrice = 3500;
            SetModsCountRange(4, 5);
            ItemVisuals = CommonTemplates.AmuletVisuals;
        }

        public override string GetTemplate() => CommonTemplates.AmuletTemplate;
    }
}
                  