using MagicBalanceConfigurator.Configs;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using VdfsSharp;

namespace MagicBalanceConfigurator
{
    public class ScriptsPatcher
    {
        private const string ZparseExtenderSection = "ZPARSE_EXTENDER";
        private const string CompileDatValue = "CompileDat";
        private const string CompileOUValue = "CompileOU";

        public void PatchGame(bool isClearCompilation)
        {
            if (!IsIniFileExist)
                throw new InvalidOperationException($"{SystemPackIniPath} Not found!");
            if (!IsG2GameProcessExists)
                throw new InvalidOperationException($"{G2GameProcess} Not found!");

            try
            {
                if (isClearCompilation)
                    InstallBackupVdfs();

                ConfigureIniFile(true);
                CleanUpPreviousCompilationResult();
                var g2process = Process.Start(G2GameProcess);
                g2process.WaitForExit();
                BuildArchive();
                PostInstallCleanUp();
            }
            catch { throw; }
            finally
            {
                ConfigureIniFile(false);
            }
        }

        public void BackUpFiles()
        {
            string backUpPath = $"{AppConfigsProvider.GetGamePath()}\\{Consts.BackUpDir}\\{GetBackUpDirName()}";
            string backUpAutorunPath = $"{backUpPath}\\{Consts.G2AutorunDir}";
            string backUpDataPath = $"{backUpPath}\\{Consts.G2DataDir}";
            string archivePath = $"{AppConfigsProvider.GetG2DataDir()}\\{AppConfigsProvider.GetGameArchiveName()}";
            string backUpArchivePath = $"{backUpDataPath}\\{AppConfigsProvider.GetGameArchiveName()}";

            Directory.CreateDirectory(backUpPath);
            Directory.CreateDirectory(backUpAutorunPath);
            Directory.CreateDirectory(backUpDataPath);

            foreach (string filePath in AppConfigsProvider.GetAutorunFiles())
            {
                string fileName = Path.GetFileName(filePath);
                File.Copy(filePath, $"{backUpAutorunPath}\\{fileName}", true);
            }
            File.Copy(archivePath, backUpArchivePath, true);
        }

        public void BuildArchive()
        {
            string compilationResultFile = CompilationResultFilePath;
            if (!File.Exists(compilationResultFile))
                throw new InvalidOperationException("Scripts compilation seems failed or reult file not found!");

            string archivePath = $"{AppConfigsProvider.GetG2DataDir()}\\{AppConfigsProvider.GetGameArchiveName()}";
            string outputPath = $"{AppConfigsProvider.GetTmpDir()}\\{Consts.G2CompiledScriptDir}";
            string outputFile = $"{outputPath}\\{Consts.G2CompiledScriptFileOut}";
            Directory.CreateDirectory(outputPath);

            var extractor = new VdfsExtractor(archivePath);
            extractor.ExtractFiles(AppConfigsProvider.GetTmpDir(), ExtractOption.Hierarchy);
            extractor.Dispose();
            File.Copy(compilationResultFile, outputFile , true);

            string comments = $"Patched - {DateTime.Now.ToLongDateString()} {DateTime.Now.ToLongTimeString()}";
            var writer = new VdfsWriter(archivePath, comments, GothicVersion.Gothic2);
            writer.AddDirectory(AppConfigsProvider.GetTmpDir());
            writer.Save();
            writer.Dispose();
        }

        public void SetBackUpArchive(string path)
        {
            Directory.CreateDirectory(AppConfigsProvider.GetBackUpDir());
            File.Copy(path, BackUpArchiveLookUpPath, true);
        }

        private void InstallBackupVdfs()
        {
            if (File.Exists(BackUpArchiveLookUpPath))
                File.Copy(BackUpArchiveLookUpPath, $"{AppConfigsProvider.GetG2DataDir()}\\{AppConfigsProvider.Configs.GameArchive}", true);
        }

        /// <summary>
        /// Delete 'Gothic.edited.dat' file
        /// </summary>
        private void CleanUpPreviousCompilationResult()
        {
            string path = CompilationResultFilePath;
            if (File.Exists(path))
                File.Delete(path);
            if(Directory.Exists(AppConfigsProvider.GetTmpDir()))
                Directory.Delete(AppConfigsProvider.GetTmpDir(), true);
        }

        private void PostInstallCleanUp()
        {
            foreach (string filePath in AppConfigsProvider.GetAutorunFiles())
                File.Delete(filePath);
            CleanUpPreviousCompilationResult();
        }

        /// <summary>
        /// Modify ini file to allow scripts compilation 'on fly'
        /// </summary>
        private void ConfigureIniFile(bool value)
        {
            INIFileWorker iniFile = new INIFileWorker(SystemPackIniPath);
            iniFile.Write(ZparseExtenderSection, CompileDatValue, value.ToString());
            iniFile.Write(ZparseExtenderSection, CompileOUValue, value.ToString());
        }

        private bool IsIniFileExist => File.Exists(SystemPackIniPath);
        private bool IsG2GameProcessExists => File.Exists(G2GameProcess);
        private bool IsVmFileExists => File.Exists(VmFilePath);
        private string SystemPackIniPath => $"{AppConfigsProvider.GetG2SystemDir()}\\{Consts.G2SystemPackIni}";
        private string G2GameProcess => $"{AppConfigsProvider.GetG2SystemDir()}\\{Consts.G2GameExe}";
        private string VmFilePath => $"{AppConfigsProvider.GetGamePath()}\\{Consts.StExtDataBuilderFile}";
        private string VdfsExePath => $"{AppConfigsProvider.GetGamePath()}\\{Consts.G2VdfsExe}";
        private string BackUpArchiveLookUpPath => $"{AppConfigsProvider.GetBackUpDir()}\\{AppConfigsProvider.Configs.GameArchive}";
        private string CompilationResultFilePath => 
            $"{AppConfigsProvider.GetGamePath()}\\{Consts.G2CompiledScriptDir}\\{Consts.G2CompiledScriptFile}";

        private string GetBackUpDirName() => DateTime.Now.ToString("yyyyMMddHHmmssffff");
    }
}
