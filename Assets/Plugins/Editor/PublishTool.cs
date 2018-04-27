
using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class PublishTool
{
    /// netcosmos ios provision profile ID
    public static string iOSManualProvisioningProfileID = "8b6869d4-3b32-4680-a3b7-14e47cc5a0f6";
    public static string levelName = "";
    public static string debugLevelName = "";
    public static string outPath = "C:/";
    public static string buildLevelName = "";

    #region  common function
    public static string GetCommandLineArg(string key)
    {
        foreach (string item in System.Environment.GetCommandLineArgs())
        {
            if (item.StartsWith(key))
            {
                return item.Split('-')[1];
            }
        }
        return null;
    }

    public static void UseManualSign()
    {
#if UNITY_IOS
        PlayerSettings.iOS.appleEnableAutomaticSigning = false;
		PlayerSettings.iOS.iOSManualProvisioningProfileID = iOSManualProvisioningProfileID;
#endif
    }

    public static void ClearPath(string path)
    {
        if (!Directory.Exists(path))
                Directory.Delete(path, true);
        Directory.CreateDirectory(path);
    }

    public static void SetSymbols(bool isDebug)
    {
        List<string> list = new List<string>();
        if (isDebug)
            list.Add("DEVELOP");
        else
        {

        }


        string key = string.Join(";", list.ToArray());
        if (list.Count == 0)
            key = "";

        PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android, key);
        PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.iOS, key);
        AssetDatabase.SaveAssets();

    }

    public static void SetScriptType(ScriptingImplementation type, BuildTarget buildTarget = BuildTarget.iOS)
    {
        PlayerSettings.SetPropertyInt("ScriptingBackend", (int)type, buildTarget);
    }

    public static void UpdateBundleVersion(string key)
    {

        TimeSpan time = DateTime.Now - new DateTime(2017, 1, 1);
#if UNITY_IOS
		PlayerSettings.iOS.buildNumber = key;
//		PlayerSettings.iOS.buildNumber = Mathf.FloorToInt((float)time.TotalMinutes).ToString();
#endif
    }


    public static string[] GetSceneList()
    {
        string mainPath = EditorBuildSettings.scenes[0].path;
        List<string> list = new List<string>();
        list.Insert(0, mainPath);

        return list.ToArray();
    }

    #endregion

    [MenuItem("VIPlugin/BuildiOSPack")]
    public static void BuildiOSPack()
    {
        _buildiOSPack();
    }

    [MenuItem("VIPlugin/BuildAndroidPack")]

    private static void BuildAndroidPack()
    {

    }

    private static void _buildiOSPack()
    {
        string str = GetCommandLineArg("OutPath");
        //  0 debug 1 release 2 il2cpp
        string type = GetCommandLineArg("ScriptType");
        string appversion = GetCommandLineArg("AppVersion");
        string distributionType = GetCommandLineArg("DistributionType");
        string platformID = GetCommandLineArg("platformID");
        string versionKey = GetCommandLineArg("versionKey");

        if(string.IsNullOrEmpty(versionKey))
        {
            versionKey = "20171010101010";
        }
        if (string.IsNullOrEmpty(platformID))
        {
            platformID = "Develop_IOS";
        }
        if (string.IsNullOrEmpty(type))
        {
            type = "2";
        }
        if (string.IsNullOrEmpty(distributionType))
        {
            distributionType = "Distribution";
        }
        if (str != null)
            outPath = str;
        string path = outPath + "/Src";

        buildLevelName = levelName;
        BuildOptions buildOptions = BuildOptions.None;
        bool isDebug = false;

        if(type == "0")
        {
            SetSymbols(true);
            buildOptions = BuildOptions.Development;
            SetScriptType(ScriptingImplementation.Mono2x);
            isDebug = true;
        }  else if(type == "1")
        {
            SetSymbols(true);
            SetScriptType(ScriptingImplementation.IL2CPP);
            isDebug = true;
        }  else
        {
            SetSymbols(false);
            SetScriptType(ScriptingImplementation.IL2CPP);
            buildOptions = BuildOptions.Il2CPP;
            isDebug = false;
        }

        if(distributionType == "Development")
        {

        }else if(distributionType == "Distribution")
        {
            UseManualSign();
        }


        PlayerSettings.bundleVersion = string.IsNullOrEmpty(appversion) ? "1.0.0" : appversion.Trim();
        UpdateBundleVersion(versionKey);
        BuildPipeline.BuildPlayer(GetSceneList(), path, BuildTarget.iOS, buildOptions);
    }
}