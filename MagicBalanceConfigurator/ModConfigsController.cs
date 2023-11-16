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

        private string _configsDir;
        private string ConfigsPath { get => 
                $"{_configsDir}\\{Consts.ModConfigsPath}"; }

        public ModConfigsController(string modulePath)
        {
            _configsDir = modulePath;
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

        public void UpdateConfigsPath(string modulePath) 
        {
            _configsDir = modulePath;
            RawConfigs = GetRawConfigs();
        }
    }
}
