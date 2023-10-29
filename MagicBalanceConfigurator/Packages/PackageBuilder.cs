using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace MagicBalanceConfigurator.Packages
{
    /// <summary>
    /// Creates package on disk.
    /// </summary>
    public class PackageBuilder
    {
        public PackageInfo BuildPackage(string name, string dirName, string author, List<string> requiredPckgs = default,
            List<string> incompatiblePckgs = default, string version = default, string description = default, bool isEnabled = default) 
        {
            PackageInfo packageInfo = new PackageInfo()
            {
                Author = author,
                Version = version,
                Description = description,
                Name = name,
                IsEnabled = isEnabled,
                Directory = dirName,
                RequiredPackages = requiredPckgs,
                IncompatiblePackages = incompatiblePckgs
            };
            Directory.CreateDirectory(dirName);
            UpdatePackageMeta(packageInfo);
            return packageInfo;
        }

        public void UpdatePackageMeta(PackageInfo packageInfo)
        {
            string path = $"{packageInfo.Directory}\\{Consts.PackageInfoFile}";
            string raw = JsonConvert.SerializeObject(packageInfo);
            File.WriteAllText(path, raw);
        }
    }
}
