using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;


public class FileBuilder
{
    public static FileBuilder Instance = new FileBuilder();

    bool[] pHashMapIndex = new bool[FilePackage.nHashTableSize];
    
    int nPakHeadPos = 0;
    int nPakSeekPos = 0;

    string sResPath = "";

    int GetHashTableIndex(uint nHashPos)
    {
        uint nHashStart = nHashPos % (uint)FilePackage.nHashTableSize;
        uint nHashIndex = nHashStart;
        while (true)
        {
            if (!pHashMapIndex[nHashIndex])
            {
                pHashMapIndex[nHashIndex] = true;
                return (int)nHashIndex;
            }
            else
            {
                Debug.Log("重复   " + nHashStart);
                nHashIndex = (nHashIndex + 1) % (uint)FilePackage.nHashTableSize;
            }

            if (nHashIndex == nHashStart)
                break;
        }
        Debug.LogError("Hash 索引值 = -1!!!!!!");
        return -1;
    }

    public void MakePackage()
    {
        sResPath = Application.dataPath.Replace("Assets", BuildScript.AssetBundlesOutputPath);
        List<string> sFileList = Directory.GetFiles(sResPath, "*.*", SearchOption.AllDirectories).Where(f => !(f.ToLower().EndsWith(".meta") || f.ToLower().EndsWith(".manifest"))).ToList();

        Array.Clear(pHashMapIndex, 0, pHashMapIndex.Length);

        nPakHeadPos = 0;
        nPakSeekPos = sizeof(uint) * 5 * sFileList.Count + sizeof(int); // 文件头大小 + 文件个数4

        FileStream fs = File.Create(Application.streamingAssetsPath + "/ss.png", nPakSeekPos);
        BinaryWriter bw = new BinaryWriter(fs);
        bw.Write(sFileList.Count);
        nPakHeadPos += sizeof(int);

        EditorApplication.CallbackFunction PackFileUpdate = null;

        try
        {
            int nIndex = 0;
            PackFileUpdate = () =>
            {
                bool isFinish = EditorUtility.DisplayCancelableProgressBar("AssetBundles 打包 (" + nIndex + "/" + sFileList.Count + ")", sFileList[nIndex], (float)nIndex / (float)sFileList.Count);
                if (!isFinish)
                {
                    PackFileToPackage(sFileList[nIndex++], bw);
                }
                
                if (isFinish || nIndex >= sFileList.Count)
                {
                    bw.Close();
                    fs.Close();

                    EditorUtility.ClearProgressBar();
                    EditorApplication.update -= PackFileUpdate;
                }
            };
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
            EditorApplication.update -= PackFileUpdate;
        }
        
        EditorApplication.update += PackFileUpdate;
    }

    public void PackFileToPackage(string sPath, BinaryWriter bw)
    {
        const int HASH_OFFSET = 0, HASH_A = 1, HASH_B = 2;

        FileInfo pFileInfo = new FileInfo(sPath);
        string sKey = sPath.Replace(sResPath + "\\", "");
        sKey = sKey.ToUpper().Replace("\\", "/");

        uint nHashPos = FilePackage.Instance.HashString(sKey, HASH_OFFSET);
        uint nHashIndex = (uint)GetHashTableIndex(nHashPos);

        bw.Seek(nPakHeadPos, SeekOrigin.Begin);
        bw.Write(nHashIndex);               // hash表索引
        bw.Write(FilePackage.Instance.HashString(sKey, HASH_A)); // hash 校验值A
        bw.Write(FilePackage.Instance.HashString(sKey, HASH_B)); // hash 校验值B
        bw.Write((uint)nPakSeekPos);              // 文件位置
        bw.Write((uint)pFileInfo.Length);         // 文件大小

        nPakHeadPos += sizeof(uint) * 5;

        bw.Seek(nPakSeekPos, SeekOrigin.Begin);
        byte[] data = new byte[pFileInfo.Length];
        pFileInfo.OpenRead().Read(data, 0, (int)pFileInfo.Length);
        bw.Write(data);

        nPakSeekPos += (int)pFileInfo.Length;
    }
}