using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicBalanceConfigurator.Generators
{
    public abstract class BasePotionGenerator : BaseGenerator
    {
        protected int PotionDurationMin { get; set; }
        protected int PotionDurationMax { get; set; }

        protected BasePotionGenerator(RandomController controller, string fileName) : 
            base(controller, fileName) 
        {
            PotionDurationMin = 60;
            PotionDurationMax = 180;
            UseUniqName = true;
        }

        protected override ItemMod[] GetItemsMods() =>
            ItemModsProvider.ItemMods.Where(x => x.IsEnabled && x.Id > 100).ToArray();

        protected override void PostProcessTemplate(StringBuilder template)
        {
            string duration = GetRandomDuration();
            template.Replace("[Duration]", duration);
        }

        protected string GetRandomDuration()
        {
            int duration = new Random(GetRandomSeed()).Next(PotionDurationMin, PotionDurationMax);
            duration = (int)(duration * ModPower);
            return duration.ToString();
        }

        public override string GetTemplate() => @"instance [IdPrefix][Id](c_item) 
{
    name = stext_itpo_rnd_name;
    mainflag = item_kat_potions;
    flags = item_multi;
    value = [Price];
    visual = [Visual];
    material = mat_glas;
    on_state = use[IdPrefix][Id];
    scemename = ""POTIONFAST"";
    wear = wear_effect;
    description = [NameId];
[ModsText]
    text[5] = name_value;
    count[5] = value;
    inv_animate = 1;
};
func void use[IdPrefix][Id]() 
{
[ModsEquip]
};
";

    }
}
