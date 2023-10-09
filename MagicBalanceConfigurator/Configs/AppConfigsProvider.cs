using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MagicBalanceConfigurator.Configs
{
    public class AppConfigsProvider
    {
        public static AppConfigs Configs { get; private set; }

        public static AppConfigs GetConfigs()
        {
            if(Configs != null)
                return Configs;

            if(!IsConfigsExist())
            {
                Configs = new AppConfigs()
                {
                    GamePath = default,
                    GameArchive = Consts.DefaultG2GameArchive,
                    Language = "Eng",
                };
                SetConfigs();
            }

            string raw = File.ReadAllText(Consts.AppConfigsPath);            
            AppConfigs cnfg = JsonConvert.DeserializeObject<AppConfigs>(raw);
            Configs = cnfg;
            return cnfg;
        }

        public static void SetConfigs()
        {
            if (Configs != null)
            {
                string raw = JsonConvert.SerializeObject(Configs);
                File.WriteAllText(Consts.AppConfigsPath, raw);
            }
        }

        public static bool IsConfigsExist() => File.Exists(Consts.AppConfigsPath);

        /// <summary>
        /// Detect game path, if app running from correct folder
        /// </summary>
        public static void DetectAndSetGamePath()
        {
            if (IsGamePathCorrect(Application.StartupPath))
            {
                Configs.GamePath = Application.StartupPath;
                SetConfigs();
            }
        }

        public static bool IsGamePathCorrect()
        {
            string gameExePath = $"{GetG2SystemDir()}\\{Consts.G2GameExe}";
            return File.Exists(gameExePath);
        }
        private static bool IsGamePathCorrect(string gamePath)
        {
            string gameExePath = $"{gamePath}\\{Consts.G2SystemDir}\\{Consts.G2GameExe}";
            return File.Exists(gameExePath);
        }

        public static string GetGameArchiveName() => Configs.GameArchive;
        public static string GetGamePath() => Configs.GamePath;
        public static string GetG2SystemDir() => $"{GetGamePath()}\\{Consts.G2SystemDir}";
        public static string GetAutorunDir() => $"{GetG2SystemDir()}\\{Consts.G2AutorunDir}";
        public static string GetPackagesDir() => $"{GetGamePath()}\\{Consts.PackagesDir}";
        public static string GetG2CompiledScriptsDir() => $"{GetGamePath()}\\{Consts.G2CompiledScriptDir}";
        public static string GetG2DataDir() => $"{GetGamePath()}\\{Consts.G2DataDir}";
        public static string GetTmpDir() => $"{GetGamePath()}\\{Consts.TmpDir}";
        public static string GetBackUpDir() => $"{GetGamePath()}\\{Consts.BackUpDir}";

        public static string[] GetAutorunFiles() => Directory.GetFiles(AppConfigsProvider.GetAutorunDir(), "*.*", SearchOption.TopDirectoryOnly)
            .Where(s => Consts.PackageExt.Contains(Path.GetExtension(s).TrimStart('.').ToLowerInvariant())).ToArray();
    }
}
