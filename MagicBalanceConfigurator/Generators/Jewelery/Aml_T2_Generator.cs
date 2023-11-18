using System.Linq;
using System.Windows.Forms;

namespace MagicBalanceConfigurator.Generators
{
    public class Aml_T2_Generator : BaseGenerator
    {
        public Aml_T2_Generator(RandomController controller) :
            base(controller, Consts.Aml_T2_FileName)
        {
            TierPrefix = CommonTemplates.TierPrefix_T2;
            ItemIdPrefix = CommonTemplates.Amulet_IdPrefix;
            ItemName = "Магический Амулет";
            UseUniqName = false;
            ItemType = CommonTemplates.Amulet_RandSufix;
            ModPower = 3;
            ItemsPrice = 1750;
            SetModsCountRange(2, 3);
            ItemVisuals = CommonTemplates.AmuletVisuals;
        }

        public override string GetTemplate() => CommonTemplates.AmuletTemplate;
    }
}
                  