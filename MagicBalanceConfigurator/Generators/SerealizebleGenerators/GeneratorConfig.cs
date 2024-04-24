using System;
using System.Collections.Generic;

namespace MagicBalanceConfigurator.Generators.SerealizebleGenerators
{
    [Serializable]
    public class GeneratorConfig
    {
        public string SchemaName { get; set; }
        public bool IsActive { get; set; }     
        
        public int ItemsCount { get; set; }
        public int ItemsPrice { get; set; }
        public double ModPower { get; set; }
        public int ModsCountMin { get; set; }
        public int ModsCountMax { get; set; }
        public string ItemModType { get; set; }
        public string ItemName { get; set; }
        public double ItemCondMultiplier { get; set; }

        public double PotionDurationMult { get; set; }
        public int PotionMinDuration { get; set; }
        public int PotionMaxDuration { get; set; }

        public double ArmorProtectionMult { get; set; }
        public int MinArmorProtectionValue { get; set; }
        public int MaxArmorProtectionValue { get; set; }

        public double WeaponDamageMult { get; set; }
        public double WeaponRangeMult { get; set; }
        public int MinWeaponDamageValue { get; set; }
        public int MaxWeaponDamageValue { get; set; }
        public int MinWeaponRangeValue { get; set; }
        public int MaxWeaponRangeValue { get; set; }

        public virtual bool UseUniqName { get; set; }
        public List<int> ProhibitedMods { get; set; }
        public List<ItemTemplateConfigs> ItemTemplates { get; set; }
        public List<string> ProhibitedDamageTypes { get; set; }
        public List<string> ItemVisuals { get; set; }
    }
}
