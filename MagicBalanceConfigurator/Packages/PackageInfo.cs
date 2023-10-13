using System;
using System.Collections.Generic;

namespace MagicBalanceConfigurator.Packages
{
    [Serializable]
    public class PackageInfo
    {
        public int LoadOrder { get; set; }
        public string Name { get; set; }
        public bool IsEnabled { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
        public string Author { get; set; }
        public List<string> RequiredPackages { get; set; } = new List<string>();
        public List<string> IncompatiblePackages { get; set; } = new List<string>();

        [NonSerialized]
        public List<string> IncludedFiles = new List<string>();

        [NonSerialized]
        public string Directory;

        public override bool Equals(object obj)
        {
            PackageInfo other = obj as PackageInfo;
            return Name.Equals(other?.Name);
        }
        public override int GetHashCode() => Name.GetHashCode();
    }
}
