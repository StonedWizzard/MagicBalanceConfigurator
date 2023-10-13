using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicBalanceConfigurator.Generators
{
    public class Pot_T1_Generator : BasePotionGenerator
    {
        public Pot_T1_Generator(RandomController controller) : base(controller, Consts.Pot_T1_FileName) 
        {
            TierPrefix = CommonTemplates.TierPrefix_T1;
            ItemIdPrefix = CommonTemplates.Poition_IdPrefix;
            ItemName = "Слабое зелье";            
            ItemType = CommonTemplates.Poition_RandSufix;
            ModPower = 1;
            ItemsPrice = 500;
            SetModsCountRange(1, 2);
        }

        protected override string GetItemVisual() => CommonTemplates.PoitionsT1Visuals.GetRandomElement();
    }
}
