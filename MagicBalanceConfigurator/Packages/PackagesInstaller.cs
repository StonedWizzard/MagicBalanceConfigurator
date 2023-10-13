using MagicBalanceConfigurator.Configs;
using System.Collections.Generic;
using System.IO;

namespace MagicBalanceConfigurator.Packages
{
    class PackagesInstaller
    {
        public void InstallSelectedPackages(List<PackageInfo> packages) 
        {
            Directory.CreateDirectory(AppConfigsProvider.GetAutorunDir());
            foreach (var package in packages)
            {
                if (!package.IsEnabled) continue;
                InstallPackage(package);
            }
        }

        public void InstallPackage(PackageInfo package) 
        {
            foreach(var file in package.IncludedFiles)
            {
                string newPath = $"{AppConfigsProvider.GetAutorunDir()}\\{Path.GetFileName(file)}";
                File.Copy(file, newPath, true);
            }
        }
    }
}
