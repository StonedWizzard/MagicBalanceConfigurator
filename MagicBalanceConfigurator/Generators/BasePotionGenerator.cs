using System;
using System.Linq;
using System.Text;

namespace MagicBalanceConfigurator.Generators
{
    public abstract class BasePotionGenerator : BaseGenerator
    {
        public const int MaxPotionDuration = 86400;

        public double PotionDurationMult { get; set; }
        protected int _potionMinDuration;
        public int PotionMinDuration
        {
            get => _potionMinDuration;
            set
            {
                if (value < 15) value = 15;
                if (value > PotionMaxDuration) value = PotionMaxDuration;
                _potionMinDuration = value;
            }
        }

        protected int _potionMaxDuration;
        public int PotionMaxDuration
        {
            get => _potionMaxDuration;
            set
            {
                if (value < 15) value = 15;
                if (value > MaxPotionDuration) value = MaxPotionDuration;
                _potionMaxDuration = value;
            }
        }

        protected BasePotionGenerator(RandomController controller, string fileName) : 
            base(controller, fileName) 
        {
            PotionDurationMult = 1;
            SetDurationRange(60, 180);
            UseUniqName = true;
        }

        protected override ItemMod[] GetItemsMods() =>
            ItemModsProvider.ItemMods.Where(x => x.IsEnabled && x.Id > 100 && x.Id < 200).ToArray();

        protected override void PostProcessTemplate(StringBuilder template)
        {
            string duration = GetRandomDuration();
            template.Replace("[Duration]", duration);
        }

        protected string GetRandomDuration()
        {
            int duration = new Random(GetRandomSeed()).Next(PotionMinDuration, PotionMaxDuration);
            duration = (int)(duration * (ModPower + PotionDurationMult));
            return duration.ToString();
        }

        protected void SetDurationRange(int min, int max)
        {
            var val = SetValueRange(min, max, MaxPotionDuration);
            _potionMinDuration = val.Min;
            _potionMaxDuration = val.Max;
        }

        public override string GetTemplate() => CommonTemplates.PotionTemplate; 

    }
}
