﻿using MagicBalanceConfigurator.Configs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicBalanceConfigurator.Packages
{
    /// <summary>
    /// Search packages in dedicated directory
    /// </summary>
    class PackagesLoader
    {
        public List<PackageInfo> LoadPackages()
        {
            List<PackageInfo> packages = new List<PackageInfo>();
            var dirs = Directory.GetDirectories(AppConfigsProvider.GetPackagesDir());
            foreach (var dir in dirs)
            {
                if (IsPackageDir(dir))
                    packages.Add(ReadPackageInfo(dir));
            }
            return packages;
        }
        public List<PackageInfo> GetNotInitializedPackages(IEnumerable<PackageInfo> packages)
        {
            var packagesInDirectory = LoadPackages();
            return packagesInDirectory.Union(packages).
                Except(packagesInDirectory.Intersect(packages)).ToList();
        }

        public List<PackageInfo> GetMissingPackages(IEnumerable<PackageInfo> packages)
        {
            var packagesInDirectory = LoadPackages();
            return packages.Except(packagesInDirectory).ToList();
        }

        public PackageInfo UpdatePackageFiles(PackageInfo package)
        {
            package.IncludedFiles = GetPackageFiles(package.Directory);
            return package;
        }

        private PackageInfo ReadPackageInfo(string packagePath)
        {
            string raw = File.ReadAllText($"{packagePath}\\{Consts.PackageInfoFile}");
            PackageInfo package = JsonConvert.DeserializeObject<PackageInfo>(raw);            
            package.IncludedFiles = GetPackageFiles(packagePath);
            package.Directory = packagePath;
            return package;
        }

        private List<string> GetPackageFiles(string packagePath) =>
            Directory.EnumerateFiles(packagePath, "*.*", SearchOption.AllDirectories)
                .Where(s => Consts.PackageExt.Contains(Path.GetExtension(s).TrimStart('.').ToLowerInvariant())).ToList();

        private bool IsPackageDir(string path) => 
            File.Exists($"{path}\\{Consts.PackageInfoFile}");
    }
}
