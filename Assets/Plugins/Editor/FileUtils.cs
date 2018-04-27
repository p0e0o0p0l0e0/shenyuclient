using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEditor;
using System.IO;

public class FileUtils
{
    public static string SourcePath = "/AssetBundles/";
    public static string DesPath = "/Assets/StreamingAssets/res";

    public static string GetPath(string root,string resName)
    {
        return Application.dataPath.Substring(0,Application.dataPath.Length - 7) + root + resName;
    }
    public static string GetSourcePath(string resType)
    {
        return GetPath(SourcePath ,resType);
    }
    public static string GetDesPath(string resType)
    {
        return GetPath(DesPath, resType);
    }

    public static void MoveAllDirectory(string sourcePath,string  desPath)
    {
        if (Directory.Exists(desPath))
            Directory.Delete(desPath,true);

        if (Directory.Exists(sourcePath))
        {
            Directory.Move(sourcePath, desPath);
            AssetDatabase.SaveAssets();
            Debug.Log("Directory Move,sourcePath:" + sourcePath + ",desPath:" + desPath);
        }
        else
        {
            Debug.LogError("not found sourcePath:" + sourcePath);
        }
    }
    public static void MoveFile(string sourcePath,string desPath)
    {
        if (!Directory.Exists(desPath))
            Directory.CreateDirectory(desPath);

        string[] filePaths = Directory.GetFiles(sourcePath);
        for (int i = 0; i < filePaths.Length; i++)
        {
            string[] array = filePaths[i].Split('\\');
            File.Move(filePaths[i], desPath + "/" + array[array.Length - 1]);
        }
        MoveDirectory(sourcePath,desPath);
    }
    public static void MoveDirectory(string sourcePath, string desPath)
    {
        string[] directoryPaths = Directory.GetDirectories(sourcePath);
        for (int i = 0; i < directoryPaths.Length; i++)
        {
            Debug.Log(directoryPaths[i]);
            string[] array = directoryPaths[i].Split('\\');
            MoveFile(directoryPaths[i], desPath + "/" + array[array.Length - 1]);
        }
    }
}
