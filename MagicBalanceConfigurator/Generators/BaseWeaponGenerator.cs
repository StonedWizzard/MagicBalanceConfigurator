using MagicBalanceConfigurator.Generators.SerealizebleGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagicBalanceConfigurator.Generators
{
    public abstract class BaseWeaponGenerator : BaseItemGenerator
    {
        protected const int MaxWeaponDamage = 1000;
        protected const int MaxWeaponRange = 250;

        public double WeaponDamageMult { get; set; }
        public double WeaponRangeMult { get; set; }

        protected int _minWeaponDamageValue;
        public int MinWeaponDamageValue 
        {
            get => _minWeaponDamageValue;
            set
            {
                if (value < 5) value = 5;
                if (value > MaxWeaponDamageValue) value = MaxWeaponDamageValue;
                _minWeaponDamageValue = value;
            }
        }
        protected int _maxWeaponDamageValue;
        public int MaxWeaponDamageValue 
        {
            get => _maxWeaponDamageValue;
            set
            {
                if (value < 5) value = 5;
                if (value > MaxWeaponDamage) value = MaxWeaponDamage;
                _maxWeaponDamageValue = value;
            }
        }

        protected int _minWeaponRangeValue;
        public int MinWeaponRangeValue 
        {
            get => _minWeaponRangeValue;
            set
            {
                if (value < 30) value = 30;
                if (value > MaxWeaponRangeValue) value = MaxWeaponRangeValue;
                _minWeaponRangeValue = value;
            }
        }
        protected int _maxWeaponRangeValue;
        public int MaxWeaponRangeValue 
        {
            get => _maxWeaponRangeValue;
            set
            {
                if (value < 30) value = 30;
                if (value > MaxWeaponRange) value = MaxWeaponRange;
                _maxWeaponRangeValue = value;
            }
        }

        protected List<string> ProhibitedDamageTypes { get; set; }

        public BaseWeaponGenerator(RandomController controller, string fileName) : base(controller, fileName)
        {
            ItemName = "Оружие";
            WeaponDamageMult = 1;
            WeaponRangeMult = 1;
            SetWeaponDamageRange(10, 50);
            SetWeaponRangeRange(30, 60);
            ProhibitedDamageTypes = new List<string>();
        }

        protected override ItemMod[] GetItemsMods() =>
            ItemModsProvider.ItemMods.Where(x => x.IsEnabled && x.Id > 200 && x.Id < 300).ToArray();

        protected override string PreProcessTemplate(ItemModsSet modsSet)
        {
            StringBuilder template = new StringBuilder(base.PreProcessTemplate(modsSet));
            DamageInfo damageInfo = GetWeaponDamageInfo();
            template.Replace("[DamageSection]", damageInfo.DamageSection);
            template.Replace("[DamageTotal]", damageInfo.DamageTotal);
            template.Replace("[DamageTotalType]", damageInfo.DamageType);
            template.Replace("[WeaponRange]", GetWeaponRangeValue().ToString());
            template.Replace("[WeapModsData]", GetWeaponModsData(modsSet).ToString());
            return template.ToString();
        }

        private DamageInfo GetWeaponDamageInfo()
        {
            DamageInfo damageInfo = new DamageInfo();
            StringBuilder damageSection = new StringBuilder();
            StringBuilder damageTypeSection = new StringBuilder();
            StringBuilder damageLine = new StringBuilder(CommonTemplates.WeaponDamageString);
            List<string> usedDamageTypes = new List<string>();
            int totalDamage = GetWeaponDamageValue();
            string damageType = CurrentItemPreset.WeaponDamageType;
            usedDamageTypes.Add(damageType);
            int extraDamageTypesCount = new Random(GetRandomSeed()).Next(100) > 50 ? 1 : 0;
            extraDamageTypesCount += new Random(GetRandomSeed()).Next(100) > 95 ? 1 : 0;

            damageLine.Replace("[DamageIndex]", CommonTemplates.WeaponDamagePair[damageType]);
            damageLine.Replace("[DamageValue]", totalDamage.ToString());
            damageSection.Append($"\t{damageLine}");
            damageTypeSection.Append($"{damageType}");

            int damage;
            for (int i = 0; i < extraDamageTypesCount; i++)
            {
                damage = (int)(GetWeaponDamageValue() * GetNextDamageMult());
                totalDamage += damage;
                damageType = GetNextDamageType(usedDamageTypes);
                usedDamageTypes.Add(damageType);
                damageLine = new StringBuilder(CommonTemplates.WeaponDamageString);
                damageLine.Replace("[DamageIndex]", CommonTemplates.WeaponDamagePair[damageType]);
                damageLine.Replace("[DamageValue]", damage.ToString());
                damageSection.Append($"\r\n\t{damageLine}");
                damageTypeSection.Append($" | {damageType}");
            }
            damageInfo.DamageType = damageTypeSection.ToString();
            damageInfo.DamageSection = damageSection.ToString();
            damageInfo.DamageTotal = totalDamage.ToString();
            return damageInfo;
        }

        private string GetNextDamageType(List<string> usedDamageTypes)
        {
            var availebleTypes = CommonTemplates.WeaponDamagePair.Keys.Where(x => !usedDamageTypes.Contains(x)).
                Except(ProhibitedDamageTypes).ToArray();
            return availebleTypes.GetRandomElement();
        }

        private double GetNextDamageMult()
        {
            double val = new Random(GetRandomSeed()).Next(150, 850);
            double result = val / 1000;
            return result;
        }
        private int GetWeaponDamageValue()
        {
            int result = new Random(GetRandomSeed()).Next(MinWeaponDamageValue, MaxWeaponDamageValue);
            return (int)(result * WeaponDamageMult);
        }

        private int GetWeaponRangeValue()
        {
            int result = new Random(GetRandomSeed()).Next(MinWeaponRangeValue, MaxWeaponRangeValue);
            return (int)(result * WeaponRangeMult) + CurrentItemPreset.WeaponExtraRange;
        }

        protected void SetWeaponDamageRange(int min, int max)
        {
            var val = SetValueRange(min, max, MaxWeaponDamage);
            _minWeaponDamageValue = val.Min;
            _maxWeaponDamageValue = val.Max;
        }

        protected void SetWeaponRangeRange(int min, int max)
        {
            var val = SetValueRange(min, max, MaxWeaponRange);
            _minWeaponRangeValue = val.Min;
            _maxWeaponRangeValue = val.Max;
        }
        
        protected int GetWeaponModsData(ItemModsSet modsSet)
        {
            int result = 0;
            if(modsSet?.ModsCount > 0) 
            {
                foreach (var mod in modsSet.ItemMods)
                    result = result | mod.ModDataFlag;
            }
            return result;
        }

        public override GeneratorConfig GetGeneratorConfig()
        {
            var result = base.GetGeneratorConfig();
            result.WeaponDamageMult = WeaponDamageMult;
            result.WeaponRangeMult = WeaponRangeMult;
            result.MinWeaponDamageValue = MinWeaponDamageValue;
            result.MaxWeaponDamageValue = MaxWeaponDamageValue;
            result.MaxWeaponRangeValue = MaxWeaponRangeValue;
            result.MinWeaponRangeValue = MinWeaponRangeValue;
            result.ProhibitedDamageTypes = ProhibitedDamageTypes;
            return result;
        }
        public override void ApplyGeneratorConfig(GeneratorConfig generatorConfig)
        {
            base.ApplyGeneratorConfig(generatorConfig);
            WeaponDamageMult = generatorConfig.WeaponDamageMult;
            WeaponRangeMult = generatorConfig.WeaponRangeMult;
            SetWeaponDamageRange(generatorConfig.MinWeaponDamageValue, generatorConfig.MaxWeaponDamageValue);
            SetWeaponRangeRange(generatorConfig.MinWeaponRangeValue, generatorConfig.MaxWeaponRangeValue);
            ProhibitedDamageTypes = generatorConfig.ProhibitedDamageTypes == null ? new List<string>() : generatorConfig.ProhibitedDamageTypes;
        }

        private class DamageInfo
        {
            public string DamageTotal { get; set; }
            public string DamageType { get; set; }
            public string DamageSection { get; set; }
        }
    }
}
