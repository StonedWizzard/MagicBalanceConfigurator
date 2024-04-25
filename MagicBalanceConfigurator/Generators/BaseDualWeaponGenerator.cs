using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MagicBalanceConfigurator.Generators
{
    public abstract class BaseDualWeaponGenerator : BaseWeaponGenerator
    {
        public BaseDualWeaponGenerator(RandomController controller, string fileName) : base(controller, fileName)
        {
            ItemName = "Парное оружие";
            WeaponDamageMult = 1;
            WeaponRangeMult = 1;
            BaseOnEquipFunc = String.Empty;
            BaseOnUnEquipFunc = String.Empty;
            SetWeaponDamageRange(10, 50);
            SetWeaponRangeRange(30, 60);
            ProhibitedDamageTypes = new List<string>();
        }

        protected override string PreProcessTemplate(ItemModsSet modsSet)
        {
            var template = new StringBuilder(base.PreProcessTemplate(modsSet));
            template.Replace("[VisualL]", GetItemVisualL());

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

            if (!String.IsNullOrEmpty(CurrentItemPreset.SpecialSectionExtra))
                template.Replace("[SpecialSectionL]", CurrentItemPreset.SpecialSectionExtra);
            else
            {
                string templateString = template.ToString();
                Match match = Regex.Match(templateString, @"\n(.*?)\[SpecialSectionL(.*?)\n\}");
                if (match.Success)
                    template.Replace(match.Value, "}");
                else
                    template.Replace("[SpecialSectionL]", CurrentItemPreset.SpecialSectionExtra);
            }
            return template.ToString();
        }

        protected override void ProcessTemplateName((string FullId, string Id) itemIdInfo, StringBuilder template)
        {
            if (UseUniqName)
            {
                string nameId_L = $"str_{itemIdInfo.FullId}_L_name";
                string nameId_R = $"str_{itemIdInfo.FullId}_R_name";
                string uniqName = GetUniqueName();
                StringBuilder nameTemplate_L = new StringBuilder(CommonTemplates.ItemNameTemplateString);
                StringBuilder nameTemplate_R = new StringBuilder(CommonTemplates.ItemNameTemplateString);

                nameTemplate_L.Replace("[StringName]", nameId_L);
                nameTemplate_R.Replace("[StringName]", nameId_R);
                nameTemplate_L.Replace("[StringValue]", $"{uniqName} (L)");
                nameTemplate_R.Replace("[StringValue]", $"{uniqName} (R)");
                template.Replace("[NameId_L]", nameId_L);
                template.Replace("[NameId_R]", nameId_R);
                StringSection.AppendLine(nameTemplate_L.ToString());
                StringSection.AppendLine(nameTemplate_R.ToString());
            }
            else
            {
                template.Replace("[NameId_L]", $"{ItemGenericNameId} (L)");
                template.Replace("[NameId_R]", $"{ItemGenericNameId} (R)");
            }
        }

        protected override void ProcessLootTable(int itemIndex, (string FullId, string Id) itemIdInfo) =>
            base.ProcessLootTable(itemIndex, ($"{itemIdInfo.FullId}_right", itemIdInfo.Id));        

        protected override void ProcessLootTable2(int itemIndex, (string FullId, string Id) itemIdInfo) =>
            base.ProcessLootTable2(itemIndex, ($"{itemIdInfo.FullId}_right", itemIdInfo.Id));

        protected override string GetItemPointer(string fullId) => $"{base.GetItemPointer(fullId)}_right";

        public override string GetTemplate() => CommonTemplates.DualWeaponTemplate;

        protected string GetItemVisualL() => $"\"{CurrentItemPreset.VisualsExtra.GetRandomElement()}\"";
    }
}
