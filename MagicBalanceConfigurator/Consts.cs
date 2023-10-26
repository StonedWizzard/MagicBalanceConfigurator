using System;
using System.Collections.Generic;

namespace MagicBalanceConfigurator
{
    public static class Consts
    {
        public const int RandomModsDublicationThreshold = 99;
        public const string HomePageLink = "http://www.stonedwizzard.somee.com/";

        public const string AppConfigsPath = "StExt_MagicBalanceConfigs.json";
        public const string ItemModsConfigsPath = "StExt_ItemsModsConfigs.json";
        public const string PackagesDir = "StExt Packages";
        public const string PackageInfoFile = "Package.json";
        public const string RandomItemsPackageDir = "StExtMod - RandItemPack";
        public const string BackUpDir = "StExt_BackUp";
        public const string TmpDir = "StExt_Tmp";
        public const string CustomConfigsDir = "StExtMod - Custom configs";

        public const string G2SystemDir = "System";
        public const string G2AutorunDir = "Autorun";
        public const string G2CompiledScriptDir = "_work\\Data\\Scripts\\_compiled";
        public const string G2CompiledScriptFile = "GOTHIC.EDITED.DAT";
        public const string G2CompiledScriptFileOut = "GOTHIC.DAT";
        public const string G2GameExe = "Gothic2.exe";
        public const string G2VdfsExe = "_work\\tools\\VDFS\\GothicVDFS.exe";
        public const string G2SystemPackIni = "SystemPack.ini";
        public const string G2DataDir = "Data";
        public const string DefaultG2GameArchive = "AB_Scripts.vdf";
        public const string StExtDataBuilderFile = "StExtDataBuilder.vm";
        public const string StExtDataBuilderBatFile = "StExtDataBuilder.bat";
        public static readonly string[] PackageExt = new string[] { "d", "src" };

        public const string ModConfigsPath = "StExt_Configs.d";
        public const string RandLocalizationFileName = "StExt_Localization_RndItems.d";
        public const string RandMetaFileName = "StExt_RndItems_Meta.d";
        public const string Aml_T4_FileName = "StExt_Aml_T4_generated.d";
        public const string Aml_T3_FileName = "StExt_Aml_T3_generated.d";
        public const string Aml_T2_FileName = "StExt_Aml_T2_generated.d";
        public const string Aml_T1_FileName = "StExt_Aml_T1_generated.d";
        public const string Rng_T4_FileName = "StExt_Rng_T4_generated.d";
        public const string Rng_T3_FileName = "StExt_Rng_T3_generated.d";
        public const string Rng_T2_FileName = "StExt_Rng_T2_generated.d";
        public const string Rng_T1_FileName = "StExt_Rng_T1_generated.d";
        public const string Blt_T4_FileName = "StExt_Blt_T4_generated.d";
        public const string Blt_T3_FileName = "StExt_Blt_T3_generated.d";
        public const string Blt_T2_FileName = "StExt_Blt_T2_generated.d";
        public const string Blt_T1_FileName = "StExt_Blt_T1_generated.d";
        public const string Pot_T4_FileName = "StExt_Pot_T4_generated.d";
        public const string Pot_T3_FileName = "StExt_Pot_T3_generated.d";
        public const string Pot_T2_FileName = "StExt_Pot_T2_generated.d";
        public const string Pot_T1_FileName = "StExt_Pot_T1_generated.d";
        public const string Weap_1h_T1_FileName = "StExt_Weap_1h_T1_generated.d";
        public const string Weap_1h_T2_FileName = "StExt_Weap_1h_T2_generated.d";
        public const string Weap_1h_T3_FileName = "StExt_Weap_1h_T3_generated.d";
        public const string Weap_1h_T4_FileName = "StExt_Weap_1h_T4_generated.d";
        public const string Weap_2h_T1_FileName = "StExt_Weap_2h_T1_generated.d";
        public const string Weap_2h_T2_FileName = "StExt_Weap_2h_T2_generated.d";
        public const string Weap_2h_T3_FileName = "StExt_Weap_2h_T3_generated.d";
        public const string Weap_2h_T4_FileName = "StExt_Weap_2h_T4_generated.d";
        public const string Weap_bow_T1_FileName = "StExt_Weap_bow_T1_generated.d";
        public const string Weap_bow_T2_FileName = "StExt_Weap_bow_T2_generated.d";
        public const string Weap_bow_T3_FileName = "StExt_Weap_bow_T3_generated.d";
        public const string Weap_bow_T4_FileName = "StExt_Weap_bow_T4_generated.d";
        public const string Weap_crosbow_T1_FileName = "StExt_Weap_crosbow_T1_generated.d";
        public const string Weap_crosbow_T2_FileName = "StExt_Weap_crosbow_T2_generated.d";
        public const string Weap_crosbow_T3_FileName = "StExt_Weap_crosbow_T3_generated.d";
        public const string Weap_crosbow_T4_FileName = "StExt_Weap_crosbow_T4_generated.d";
        public const string Weap_Staff_T1_FileName = "StExt_Weap_Staff_T1_generated.d";
        public const string Weap_Staff_T2_FileName = "StExt_Weap_Staff_T2_generated.d";
        public const string Weap_Staff_T3_FileName = "StExt_Weap_Staff_T3_generated.d";
        public const string Weap_Staff_T4_FileName = "StExt_Weap_Staff_T4_generated.d";
        public const string Weap_MagicSword_T1_FileName = "StExt_Weap_MagicSword_T1_generated.d";
        public const string Weap_MagicSword_T2_FileName = "StExt_Weap_MagicSword_T2_generated.d";
        public const string Weap_MagicSword_T3_FileName = "StExt_Weap_MagicSword_T3_generated.d";
        public const string Weap_MagicSword_T4_FileName = "StExt_Weap_MagicSword_T4_generated.d";
        public const string Armor_Shield_T1_FileName = "StExt_Shield_T1_generated.d";
        public const string Armor_Shield_T2_FileName = "StExt_Shield_T2_generated.d";
        public const string Armor_Shield_T3_FileName = "StExt_Shield_T3_generated.d";
        public const string Armor_Shield_T4_FileName = "StExt_Shield_T4_generated.d";
        public const string Armor_Helm_T1_FileName = "StExt_Helm_T1_generated.d";
        public const string Armor_Helm_T2_FileName = "StExt_Helm_T2_generated.d";
        public const string Armor_Helm_T3_FileName = "StExt_Helm_T3_generated.d";
        public const string Armor_Helm_T4_FileName = "StExt_Helm_T4_generated.d";        
        public const string Armor_Body_T1_FileName = "StExt_Body_T1_generated.d";
        public const string Armor_Body_T2_FileName = "StExt_Body_T2_generated.d";
        public const string Armor_Body_T3_FileName = "StExt_Body_T3_generated.d";
        public const string Armor_Body_T4_FileName = "StExt_Body_T4_generated.d";
    }
}
