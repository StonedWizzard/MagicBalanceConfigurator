using System;
using System.Collections.Generic;

namespace MagicBalanceConfigurator.Generators.SerealizebleGenerators
{
    [Serializable]
    public class GeneratorConfigsBundle
    {
        public List<GeneratorConfig> GeneratorConfigs {  get; set; } = new List<GeneratorConfig>();
    }
}
