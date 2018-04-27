using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using UnityEngine;

public delegate void AsyncReadDataCallBack(byte[] bytes);
public class FilePackage
{
    public static FilePackage Instance = new FilePackage();
    public static readonly int nHashTableSize = 65535;
    struct PakFile
    {
        public bool bIsExist;
        public uint nHashA;
        public uint nHashB;
        public uint nFilePos;
        public uint nFileSize;
    };

    class FileData
    {
        public byte[] bytes;
        public Thread pThread;
        public AsyncReadDataCallBack callBack;
    }

    // StreamingAssets 包
    PakFile[] pInnerPakHashTable = new PakFile[65535];

    // PersistentDataPath 包
    //PakFile[] pWithoutPakHashTable = new PakFile[nHashTableSize];
    uint[] cryptTable = new uint[0x500];

#if UNITY_ANDROID && !UNITY_EDITOR
        [DllImport("filenative")]
        private static extern void GetNativeStreamFromAssets(byte[] data, int offset, int length);
#endif

    List<FileData> pReadyDataList = new List<FileData>();

    BinaryReader mPakFileReader = null;

    public FilePackage()
    {
        PrepareCryptTable();
    }

    public void Initialize()
    {
        ReadPackage();
        ResourceLoadManager.Instance.Initialize();
    }

    void ReadPackage()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        byte[] datanum = new byte[4];
        GetNativeStreamFromAssets(datanum, 0, 4);
        // 文件数量
        int nFileCount = BitConverter.ToInt32(datanum, 0);

        int headsize = sizeof(uint) * 5 * nFileCount + sizeof(int);
        byte[] datahead = new byte[headsize];
        GetNativeStreamFromAssets(datahead, 4, headsize);
        BinaryReader br = new BinaryReader(new MemoryStream(datahead));
        for (int i = 0; i < nFileCount; ++i)
        {
            uint nHashIndex = br.ReadUInt32();
            pInnerPakHashTable[nHashIndex].bIsExist = true;
            pInnerPakHashTable[nHashIndex].nHashA = br.ReadUInt32();
            pInnerPakHashTable[nHashIndex].nHashB = br.ReadUInt32();
            pInnerPakHashTable[nHashIndex].nFilePos = br.ReadUInt32();
            pInnerPakHashTable[nHashIndex].nFileSize = br.ReadUInt32();
        }
#else
        FileStream pPakFile = File.OpenRead(Application.streamingAssetsPath + "/ss.png");
        mPakFileReader = new BinaryReader(pPakFile);

        int nFileNum = mPakFileReader.ReadInt32();
        for (int i = 0; i < nFileNum; ++i)
        {
            uint nHashIndex = mPakFileReader.ReadUInt32();
            pInnerPakHashTable[nHashIndex].bIsExist = true;
            pInnerPakHashTable[nHashIndex].nHashA = mPakFileReader.ReadUInt32();
            pInnerPakHashTable[nHashIndex].nHashB = mPakFileReader.ReadUInt32();
            pInnerPakHashTable[nHashIndex].nFilePos = mPakFileReader.ReadUInt32();
            pInnerPakHashTable[nHashIndex].nFileSize = mPakFileReader.ReadUInt32();
        }
#endif
    }

    void PrepareCryptTable()
    {
        uint seed = 0x00100001, index1 = 0, index2 = 0, i;
        for (index1 = 0; index1 < 0x100; index1++)
        {
            for (index2 = index1, i = 0; i < 5; i++, index2 += 0x100)
            {
                uint temp1, temp2;
                seed = (seed * 125 + 3) % 0x2AAAAB;
                temp1 = (seed & 0xFFFF) << 0x10;
                seed = (seed * 125 + 3) % 0x2AAAAB;
                temp2 = (seed & 0xFFFF);
                cryptTable[index2] = (temp1 | temp2);
            }
        }
    }

    public uint HashString(string lpszFileName, ulong dwHashType)
    {
        uint seed1 = 0x7FED7FED;
        uint seed2 = 0xEEEEEEEE;
        uint ch;
        for (int i = 0; i < lpszFileName.Length; ++i)
        {
            ch = lpszFileName[i];
            seed1 = cryptTable[(dwHashType << 8) + ch] ^ (seed1 + seed2);
            seed2 = ch + seed1 + seed2 + (seed2 << 5) + 3;
        }
        return seed1;
    }

    int GetHashTableIndex(string lpszString)
    {
        const int HASH_OFFSET = 0, HASH_A = 1, HASH_B = 2;

        uint nHash = HashString(lpszString, HASH_OFFSET);
        uint nHashA = HashString(lpszString, HASH_A);
        uint nHashB = HashString(lpszString, HASH_B);
        uint nHashStart = nHash % (uint)nHashTableSize;
        int nHashIndex = (int)nHashStart;

        while (pInnerPakHashTable[nHashIndex].bIsExist)
        {
            if (pInnerPakHashTable[nHashIndex].nHashA == nHashA && pInnerPakHashTable[nHashIndex].nHashB == nHashB)
            {
                return nHashIndex;
            }
            else
            {
                nHashIndex = (nHashIndex + 1) % pInnerPakHashTable.Length;
            }

            if (nHashIndex == nHashStart)
                break;
        }
        return -1;
    }

    public byte[] GetFileMemory(string sPath)
    {
        int vIndex = GetHashTableIndex(sPath.ToUpper());

        if (vIndex != -1)
        {
            PakFile pFileInfo = pInnerPakHashTable[vIndex];
            byte[] dataArray = new byte[pFileInfo.nFileSize];
#if UNITY_ANDROID && !UNITY_EDITOR
            GetNativeStreamFromAssets(dataArray, (int)pFileInfo.nFilePos, (int)pFileInfo.nFileSize);
#else
            mPakFileReader.BaseStream.Seek((int)pFileInfo.nFilePos, SeekOrigin.Begin);
            mPakFileReader.Read(dataArray, 0, (int)pFileInfo.nFileSize);
#endif
            return dataArray;
        }
        Debug.LogError(sPath + " 在pak中没有找到!");
        return null;
    }

    public void Update()
    {
        for (int i = 0; i < pReadyDataList.Count; ++i)
        {
            pReadyDataList[i].callBack(pReadyDataList[i].bytes);
            pReadyDataList[i].pThread.Abort();
        }
        pReadyDataList.Clear();
    }

    public void AddReadFileMemoryReq(string sBundleName, AsyncReadDataCallBack Callback)
    {
        FileData data = new FileData();
        data.callBack = Callback;
        data.pThread = new Thread(delegate ()
        {
            lock (pReadyDataList)
            {
                data.bytes = GetFileMemory(sBundleName);
                pReadyDataList.Add(data);
            }
        });

        data.pThread.IsBackground = true;
        data.pThread.Start();
    }
}