using System.Linq;
using System.Windows.Forms;

namespace MagicBalanceConfigurator.Generators
{
    public class Aml_T1_Generator : BaseGenerator
    {
        public Aml_T1_Generator(RandomController controller) : 
            base (controller, Consts.Aml_T1_FileName) 
        {
            TierPrefix = CommonTemplates.TierPrefix_T1;
            ItemIdPrefix = CommonTemplates.Amulet_IdPrefix;
            ItemName = "Простой магический Амулет";
            UseUniqName = false;
            ItemType = CommonTemplates.Amulet_RandSufix;
            ModPower = 2;
            ItemsPrice = 1000;
            SetModsCountRange(1, 2);
            ItemVisuals = CommonTemplates.AmuletVisuals;
            ItemModType = "StExt_ItemType_Amulet";
        }

        public override string GetTemplate() => CommonTemplates.AmuletTemplate;

    }
}
                  