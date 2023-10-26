using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicBalanceConfigurator.Generators
{
    public abstract class BaseArmorGenerator : BaseItemGenerator
    {
        protected const int MaxArmorProtection = 500;
        public double ArmorProtectionMult { get; set; }

        protected int _minArmorProtectionValue;
        public int MinArmorProtectionValue
        {
            get => _minArmorProtectionValue;
            set
            {
                if (value < 5) value = 5;
                if (value > MaxArmorProtectionValue) value = MaxArmorProtectionValue;
                _minArmorProtectionValue = value;
            }
        }
        protected int _maxArmorProtectionValue;

        public int MaxArmorProtectionValue
        {
            get => _maxArmorProtectionValue;
            set
            {
                if (value < 5) value = 5;
                if (value > MaxArmorProtection) value = MaxArmorProtection;
                _maxArmorProtectionValue = value;
            }
        }

        protected BaseArmorGenerator(RandomController controller, string fileName) : base(controller, fileName)
        {
            ArmorProtectionMult = 1;
            SetArmorProtectionRange(15, 30);
        }

        protected override ItemMod[] GetItemsMods() =>
            ItemModsProvider.ItemMods.Where(x => x.IsEnabled && x.Id > 300 && x.Id < 400).ToArray();

        protected override string PreProcessTemplate(ItemModsSet modsSet)
        {
            StringBuilder template = new StringBuilder(base.PreProcessTemplate(modsSet));
            template.Replace("[ProtectionSection]", CommonTemplates.ArmorProtectionSectionTemplate);
            template.Replace("[ProtBlunt]", (GetArmorProtectionValue(CurrentItemPreset.ProtBluntMult).ToString()));
            template.Replace("[ProtEdge]", (GetArmorProtectionValue(CurrentItemPreset.ProtEdgeMult).ToString()));
            template.Replace("[ProtFire]", (GetArmorProtectionValue(CurrentItemPreset.ProtFireMult).ToString()));
            template.Replace("[ProtMagic]", (GetArmorProtectionValue(CurrentItemPreset.ProtMagicMult).ToString()));
            template.Replace("[ProtPoint]", (GetArmorProtectionValue(CurrentItemPreset.ProtPointMult).ToString()));
            template.Replace("[ProtFly]", (GetArmorProtectionValue(CurrentItemPreset.ProtFlyMult).ToString()));
            return template.ToString();
        }

        private int GetArmorProtectionValue(double mult = 1)
        {
            int result = new Random(GetRandomSeed()).Next(MinArmorProtectionValue, MaxArmorProtectionValue);
            return (int)((result * ArmorProtectionMult) * mult);
        }

        protected void SetArmorProtectionRange(int min, int max)
        {
            var val = SetValueRange(min, max, MaxArmorProtection);
            _minArmorProtectionValue = val.Min;
            _maxArmorProtectionValue = val.Max;
        }
    }
}
