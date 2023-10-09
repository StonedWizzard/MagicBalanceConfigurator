using System;

namespace MagicBalanceConfigurator.Generators
{
    [Serializable]
    public class ItemMod
    {
        public ItemMod() { IsEnabled = true; }
        public ItemMod(int id, int minValue, int maxValue) : this() 
        {
            Id = (long)1<<id;
            ValueMax = maxValue;
            ValueMin = minValue;
        }

        public long Id { get; set; }
        public int ValueMin {get; set; }
        public int ValueMax {get; set; }

        protected int _modRarity;
        public int ModRarity 
        {
            get => _modRarity;
            set
            {
                if(value < 1) value = 1;
                if (value > 99) value = 99;
                _modRarity = value;
            }
        }

        public string Template_Text { get; set; }
        public string Template_OnEquip { get; set; }
        public string Template_OnUnequip { get; set; }
        public string ModName { get; set; }
        public bool IsEnabled { get; set; }

        public void SetValueRange(int min, int max)
        {
            if (min < 1) min = 1;
            if (min > ValueMax) min = ValueMax;
            ValueMin = min;

            if (max < 1) max = 1;
            if (max < ValueMin) max = ValueMin;
            ValueMax = max;
        }
    }
}
