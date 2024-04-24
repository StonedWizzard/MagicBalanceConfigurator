using System;

namespace MagicBalanceConfigurator.Generators.SerealizebleGenerators
{
    [Serializable]
    public class ItemTemplateConfigs
    {
        public string ItemNamePlaceholder { get; set; }
        public string[] Visuals { get; set; } = new string[] { };
        public string[] VisualChanges { get; set; } = new string[] { };
        public string[] VisualsExtra { get; set; } = new string[] { };
        public string[] ExtraConditions { get; set; } = new string[] { };
        public string ItemType { get; set; }
        public string WeaponDamageType { get; set; }
        public int WeaponExtraRange { get; set; }
        public string ItemCondStat { get; set; }
        public string AltOnEquipFunc { get; set; }
        public string AltOnUnEquipFunc { get; set; }
        public string SpecialSection { get; set; } = String.Empty;

        public double ProtBluntMult { get; set; } = 1;
        public double ProtEdgeMult { get; set; } = 1;
        public double ProtFireMult { get; set; } = 1;
        public double ProtMagicMult { get; set; } = 1;
        public double ProtPointMult { get; set; } = 1;
        public double ProtFlyMult { get; set; } = 1;
    }
}
