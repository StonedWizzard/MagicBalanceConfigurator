using System;
using System.Linq;
using System.Text;

namespace MagicBalanceConfigurator.Generators
{
    public abstract class BaseShieldGenerator : BaseArmorGenerator
    {
        public BaseShieldGenerator(RandomController controller, string fileName) : base(controller, fileName) { }

        protected override string PreProcessTemplate(ItemModsSet modsSet)
        {
            StringBuilder template = new StringBuilder(base.PreProcessTemplate(modsSet));
            template.Replace("[ShieldText]", GetShieldText());
            return template.ToString();
        }

        private string GetShieldText()
        {
            StringBuilder result = new StringBuilder();
            string textLine = CommonTemplates.ItemModTextString_Text2;
            string countLine = CommonTemplates.ItemModTextString_Value2;
            string condKey = String.Empty;

            textLine = textLine.Replace("[Index]", $"{1}");
            textLine = textLine.Replace("[ModText]", "StExt_Str_DisplayShieldProtWeap");
            countLine = countLine.Replace("[Index]", $"{1}");
            countLine = countLine.Replace("[ModValue]", "protection[1]");
            result.AppendLine($"\t{textLine}\r\n\t{countLine}");

            textLine = CommonTemplates.ItemModTextString_Text2;
            countLine = CommonTemplates.ItemModTextString_Value2;
            textLine = textLine.Replace("[Index]", $"{2}");
            textLine = textLine.Replace("[ModText]", "StExt_Str_DisplayShieldProtPoint");
            countLine = countLine.Replace("[Index]", $"{2}");
            countLine = countLine.Replace("[ModValue]", "protection[6]");
            result.Append($"\t{textLine}\r\n\t{countLine}");

            if (CurrentConditionsData?.Count >= 1)
            {
                textLine = CommonTemplates.ItemModTextString_Text2;
                countLine = CommonTemplates.ItemModTextString_Value2;
                condKey = CurrentConditionsData.Keys.First();
                textLine = textLine.Replace("[Index]", $"{3}");
                textLine = textLine.Replace("[ModText]", CommonTemplates.CondTextPair[condKey]);
                countLine = countLine.Replace("[Index]", $"{3}");
                countLine = countLine.Replace("[ModValue]", $"{CurrentConditionsData[condKey]}");
                result.Append($"\r\n\t{textLine}\r\n\t{countLine}");
            }
            if (CurrentConditionsData?.Count >= 2)
            {
                textLine = CommonTemplates.ItemModTextString_Text2;
                countLine = CommonTemplates.ItemModTextString_Value2;
                condKey = CurrentConditionsData.Keys.ToArray()[1];
                textLine = textLine.Replace("[Index]", $"{4}");
                textLine = textLine.Replace("[ModText]", CommonTemplates.CondTextPair[condKey]);
                countLine = countLine.Replace("[Index]", $"{4}");
                countLine = countLine.Replace("[ModValue]", $"{CurrentConditionsData[condKey]}");
                result.Append($"\r\n\t{textLine}\r\n\t{countLine}");
            }
            return result.ToString();
        }
    }
}
