﻿namespace MagicBalanceConfigurator.Generators
{
    public class Rng_T1_Generator : BaseGenerator
    {
        public Rng_T1_Generator(RandomController controller) : 
            base (controller, Consts.Rng_T1_FileName) 
        {
            TierPrefix = CommonTemplates.TierPrefix_T1;
            ItemIdPrefix = CommonTemplates.Ring_IdPrefix;
            ItemName = "Простое магическое Кольцо";
            UseUniqName = false;
            ItemType = CommonTemplates.Ring_RandSufix;
            ModPower = 1;
            ItemsPrice = 500;
            SetModsCountRange(1, 1);
        }

        protected override string GetItemVisual() => CommonTemplates.RingVisuals.GetRandomElement();

        public override string GetTemplate() => CommonTemplates.RingTemplate;

    }
}
                  