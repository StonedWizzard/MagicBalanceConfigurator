using MagicBalanceConfigurator.Configs;
using MagicBalanceConfigurator.Packages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicBalanceConfigurator
{
    public class PackagesController
    {
        public List<PackageInfo> Packages { get; private set; }
        private PackagesInstaller PckgInstaller { get; set; }
        private PackagesLoader PckgLoader { get; set; }
        private PackageBuilder PckgBuilder { get; set; }
        private bool FirstUpdate;

        public PackagesController() 
        {
            PckgLoader = new PackagesLoader();
            PckgInstaller = new PackagesInstaller();
            PckgBuilder = new PackageBuilder();
            Directory.CreateDirectory(AppConfigsProvider.GetPackagesDir());
            Packages = PckgLoader.LoadPackages();
            FirstUpdate = true;
        }

        public void InstallSelectedPackages(bool cleanUpAutorun)
        {
            if(cleanUpAutorun)
            {
                foreach (string filePath in AppConfigsProvider.GetAutorunFiles())
                    File.Delete(filePath);
            }
            PckgInstaller.InstallSelectedPackages(GetSortedPackages());
        }

        /// <summary>
        /// Load all packages not present in current packages collection
        /// </summary>
        public bool ReloadPackages()
        {
            var newPckgs = PckgLoader.GetNotInitializedPackages(Packages);
            var missingPckgs = PckgLoader.GetMissingPackages(Packages);
            bool hasMissingPckgs = missingPckgs?.Count > 0;
            bool hasNewPckgs = newPckgs?.Count > 0;
            bool firstUpdate = FirstUpdate;

            if(hasNewPckgs)
                Packages.AddRange(newPckgs);
            if (hasMissingPckgs)
                missingPckgs.ForEach(x => Packages.Remove(x));
            if(firstUpdate) FirstUpdate = false;
            
            return hasNewPckgs || hasMissingPckgs || firstUpdate;
        }

        public List<PackageInfo> GetSortedPackages() => Packages.OrderBy(p => p.LoadOrder).ToList();

        public PackageInfo GetPackage(string packageName) => 
            Packages.FirstOrDefault(p => p.Name == packageName);

        public void SavePackageMeta(PackageInfo package)
        {
            try { PckgBuilder.UpdatePackageMeta(package); }
            catch { Packages.Remove(package); }
        }
        public void SavePackagesMeta()
        {
            foreach (var package in Packages)
                SavePackageMeta(package);
        }
    }
}
