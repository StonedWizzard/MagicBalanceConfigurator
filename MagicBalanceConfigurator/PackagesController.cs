using MagicBalanceConfigurator.Configs;
using MagicBalanceConfigurator.Packages;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MagicBalanceConfigurator
{
    public class PackagesController
    {
        public List<PackageInfo> Packages { get; private set; }
        private PackagesInstaller PckgInstaller { get; set; }
        private PackagesLoader PckgLoader { get; set; }
        private PackageBuilder PckgBuilder { get; set; }
        public bool RequireUpdate { get; private set; }

        public PackagesController() 
        {
            PckgLoader = new PackagesLoader();
            PckgInstaller = new PackagesInstaller();
            PckgBuilder = new PackageBuilder();
            Directory.CreateDirectory(AppConfigsProvider.GetPackagesDir());
            Packages = PckgLoader.LoadPackages();
            RequireUpdate = true;
        }

        public void InstallSelectedPackages(bool cleanUpAutorun)
        {
            if(cleanUpAutorun)
            {
                foreach (string filePath in AppConfigsProvider.GetAutorunFiles())
                    File.Delete(filePath);
            }
            PackagesLoader packagesLoader = new PackagesLoader();
            foreach (var pckg in GetSortedPackages())
                packagesLoader.UpdatePackageFiles(pckg);
            PckgInstaller.InstallSelectedPackages(GetSortedPackages());
        }

        /// <summary>
        /// Load all packages not present in current packages collection
        /// </summary>
        public void CheckPackages()
        {
            var newPckgs = PckgLoader.GetNotInitializedPackages(Packages);
            var missingPckgs = PckgLoader.GetMissingPackages(Packages);
            bool hasMissingPckgs = missingPckgs?.Count > 0;
            bool hasNewPckgs = newPckgs?.Count > 0;
            bool hasIncompatibles = false;
            bool hasRequired = false;

            if (hasNewPckgs)
                Packages.AddRange(newPckgs);
            if (hasMissingPckgs)
                missingPckgs.ForEach(x => Packages.Remove(x));

            hasRequired = EnableRequiredPackages();
            hasIncompatibles = DisableIncompatiblePackages();
            RequireUpdate = hasNewPckgs || hasMissingPckgs || hasIncompatibles || hasRequired;
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

        private bool EnableRequiredPackages()
        {
            bool hasRequired = false;
            foreach (var package in Packages.Where(x => x.IsEnabled))
            {
                if (package?.RequiredPackages?.Count() == 0) continue;

                var requiredPckgs = Packages.Where(x => package.RequiredPackages.Contains(x.Name));
                foreach (var pckg in requiredPckgs)
                    pckg.IsEnabled = true;
                hasRequired = true;
            }
            SavePackagesMeta();
            return hasRequired;
        }
        private bool DisableIncompatiblePackages()
        {
            bool updateReq = false;
            List<string> incompatiblePackages = new List<string>();
            foreach (var package in Packages.Where(x => x.IsEnabled))
            {
                if (package?.IncompatiblePackages?.Count() == 0) continue;
                if (!package.IsEnabled) continue;
                incompatiblePackages.AddRange(package.IncompatiblePackages);
            }

            if(incompatiblePackages.Count > 0)
            {
                updateReq = true;
                var incompatibleResult = Packages.Where(x => x.IsEnabled && incompatiblePackages.Contains(x.Name));
                foreach (var pckg in incompatibleResult)
                    pckg.IsEnabled = false;
            }
            return updateReq;
        }
    }
}
