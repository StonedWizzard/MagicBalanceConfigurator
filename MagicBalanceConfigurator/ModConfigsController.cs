using MagicBalanceConfigurator.Configs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicBalanceConfigurator
{
    /// <summary>
    /// Allow to load and modify mod configs 'on fly'
    /// </summary>
    public class ModConfigsController
    {
        public string RawConfigs { get; private set; }
        private string ConfigsPath { get => 
                $"{AppConfigsProvider.GetPackagesDir()}\\{Consts.CustomConfigsDir}\\{Consts.ModConfigsPath}"; }

        public ModConfigsController()
        {
            RawConfigs = GetRawConfigs();
        }

        private string GetRawConfigs() => File.ReadAllText(ConfigsPath);        
        private void SetRawConfigs() => File.WriteAllText(ConfigsPath, RawConfigs);

        public void UpdateConfigs(string rawConfigs)
        {
            if (!String.IsNullOrEmpty(rawConfigs))
            {
                RawConfigs = rawConfigs;
                SetRawConfigs();
            }
        }
    }
}
