using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MagicBalanceConfigurator.Generators
{
    public abstract class BaseItemGenerator : BaseGenerator
    {
        protected const int MaxCondValue = 500;

        public override bool UseUniqName { get => true; set => base.UseUniqName = true; }

        protected List<ItemTemplatePreset> ItemTemplatePresets { get; set; }
        protected ItemTemplatePreset CurrentItemPreset { get; set; }

        public double ItemCondMultiplier { get; set; }

        protected int _minItemCondValue;
        public int MinItemCondValue 
        {
            get => _minItemCondValue;
            set
            {
                if (value < 5) value = 5;
                if (value > MaxItemCondValue) value = MaxItemCondValue;
                _minItemCondValue = value;
            }
        }

        protected int _maxItemCondValue;
        public int MaxItemCondValue 
        {
            get => _maxItemCondValue;
            set
            {
                if (value < 5) value = 5;
                if (value > MaxCondValue) value = MaxCondValue;
                _maxItemCondValue = value;
            }
        }

        protected string BaseOnEquipFunc { get; set; }
        protected string BaseOnUnEquipFunc { get; set; }

        public BaseItemGenerator(RandomController controller, string fileName) : base(controller, fileName)
        {
            ItemName = string.Empty;
            ItemTemplatePresets = BuildItemTemplatePresets();
            ItemCondMultiplier = 1;
            SetItemCondRange(5, 10);
        }

        protected override ItemMod[] GetItemsMods() =>
            ItemModsProvider.ItemMods.Where(x => x.IsEnabled && x.Id > 200).ToArray();

        protected override string PreProcessTemplate(ItemModsSet modsSet)
        {
            StringBuilder template = new StringBuilder(base.PreProcessTemplate(modsSet));
            CurrentItemPreset = GetItemTemplatePreset();
            template.Replace("[CondSection]", BuildItemCondSection());

            if(!String.IsNullOrEmpty(CurrentItemPreset.AltOnEquipFunc))
                template.Replace("[BaseOnEquipFunc]", CurrentItemPreset.AltOnEquipFunc);
            if (!String.IsNullOrEmpty(CurrentItemPreset.AltOnUnEquipFunc))
                template.Replace("[BaseOnUnEquipFunc]", CurrentItemPreset.AltOnUnEquipFunc);
            // else
            template.Replace("[BaseOnEquipFunc]", BaseOnEquipFunc);
            template.Replace("[BaseOnUnEquipFunc]", BaseOnUnEquipFunc);

            if (!String.IsNullOrEmpty(CurrentItemPreset.SpecialSection))
                template.Replace("[SpecialSection]", CurrentItemPreset.SpecialSection);
            else
            {
                string templateString = template.ToString();
                Match match = Regex.Match(templateString, @"\n(.*?)\[SpecialSection(.*?)\n\}");
                if (match.Success)
                    template.Replace(match.Value, "}");
                else
                    template.Replace("[SpecialSection]", CurrentItemPreset.SpecialSection);
            }
            template.Replace("[ItemType]", CurrentItemPreset.ItemType);
            template.Replace("[Visual]", GetItemVisual());
            template.Replace("[VisualChange]", GetItemVisualChange());
            return template.ToString();
        }

        private string BuildItemCondSection()
        {
            StringBuilder condAtrSection = new StringBuilder();
            StringBuilder condValueSection = new StringBuilder();
            StringBuilder result = new StringBuilder();

            StringBuilder condAtrLine = new StringBuilder(CommonTemplates.ItemCondString_Atr);
            StringBuilder condValueLine = new StringBuilder(CommonTemplates.ItemCondString_Value);
            condAtrLine.Replace("[Index]", "1");
            condAtrLine.Replace("[AtrIndex]", CurrentItemPreset.ItemCondStat);
            condValueLine.Replace("[Index]", "1");
            condValueLine.Replace("[CondAtrValue]", GetItemCondValue(CurrentItemPreset.ItemCondStat).ToString());
            condAtrSection.Append($"\t{condAtrLine}");
            condValueSection.Append($"\t{condValueLine}");

            if(new Random(GetRandomSeed()).Next(100) > 50)
            {
                var allowedStats = CommonTemplates.ItemCondAtributes.Except(new List<string> { CurrentItemPreset.ItemCondStat })
                    .ToList();
                allowedStats.AddRange(CurrentItemPreset.ExtraConditions);
                string condStat = allowedStats.ToArray().GetRandomElement();
                condAtrLine = new StringBuilder(CommonTemplates.ItemCondString_Atr);
                condValueLine = new StringBuilder(CommonTemplates.ItemCondString_Value);
                condAtrLine.Replace("[Index]", "2");
                condAtrLine.Replace("[AtrIndex]", condStat);
                condValueLine.Replace("[Index]", "2");
                condValueLine.Replace("[CondAtrValue]", GetItemCondValue(condStat).ToString());
                condAtrSection.Append($"\t{condAtrLine}");
                condValueSection.Append($"\t{condValueLine}");
            }
            result.Append(condAtrSection);
            result.Append(condValueSection.ToString().TrimEnd(CommonTemplates.EndTrimChars));
            return result.ToString();
        }

        public virtual int GetItemCondValue(string atr)
        {
            double mult = ItemCondMultiplier;
            int result = new Random(GetRandomSeed()).Next(MinItemCondValue, MaxItemCondValue);
            if (atr == CommonTemplates.ItemCondAtr_Stamina)
                mult = 0.3;
            else if (atr == CommonTemplates.ItemCondAtr_Mana)
                mult += 4;
            else if (atr == CommonTemplates.ItemCondAtr_Hp)
                mult += 6;
            else if (atr == CommonTemplates.ItemCondAtr_Bow)
                mult = 0.3;
            else if (atr == CommonTemplates.ItemCondAtr_Crosbow)
                mult = 0.3;
            else if (atr == CommonTemplates.ItemCondAtr_Shield)
                mult = 1;
            result = (int)(result * mult);

            if (atr == CommonTemplates.ItemCondAtr_Bow && result >= 99) result = 99;
            if (atr == CommonTemplates.ItemCondAtr_Crosbow && result >= 99) result = 99;
            if (atr == CommonTemplates.ItemCondAtr_Shield && result > 1) result = 1;
            if (atr == CommonTemplates.ItemCondAtr_Stamina && result >= 99) result = 99;
            return result;
        }

        protected void SetItemCondRange(int min, int max)
        {
            var val = SetValueRange(min, max, MaxCondValue);
            _minItemCondValue = val.Min;
            _maxItemCondValue = val.Max;
        }

        protected override string GetItemVisual() => $"\"{CurrentItemPreset.Visuals.GetRandomElement()}\"";
        protected virtual string GetItemVisualChange() => $"\"{CurrentItemPreset.VisualChanges?.GetRandomElement()}\"";

        protected virtual ItemTemplatePreset GetItemTemplatePreset() => (ItemTemplatePreset)ItemTemplatePresets.GetRandomObj();
        protected abstract List<ItemTemplatePreset> BuildItemTemplatePresets();
        protected class ItemTemplatePreset
        {
            public string[] Visuals { get; set; } = new string[] { };
            public string[] VisualChanges { get; set; } = new string[] { };
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
}
