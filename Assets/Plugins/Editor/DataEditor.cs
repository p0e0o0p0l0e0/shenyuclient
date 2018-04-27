using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.IO;
using System.Reflection;


public struct ViewData
{
    public ViSealedData data;
    public EditableContainer title;
}

public class DataEditor
{
    string VISDir = "../Binaries/Data/VIS/";
    string VIBDir = "../Binaries/Data/BinaryStream/";

    public static Boolean IS_START = false;
    public List<ViewData> mDataList = new List<ViewData>();
    protected static Dictionary<Type, DataEditor> mTypeViews = new Dictionary<Type, DataEditor>();

    public bool Loaded { get { return (mDataList.Count != 0); } }
    public Int32 GetFreeID()
    {
        Int32 freeID = 0;
        for (int i = 0; i < mDataList.Count; ++i)
        {
            if (IsFreeID(freeID))
            {
                break;
            }
            ++freeID;
        }
        return freeID;
    }
    public bool IsFreeID(Int32 id)
    {
        for (int i = 0; i < mDataList.Count; ++i)
        {
            if (mDataList[i].data.ID == id)
            {
                return false;
            }
        }
        return true;
    }

    public virtual void Load() { }
    public virtual string Save() { return ""; }
    public virtual ViSealedData GetNewData(int vIndex) { return null; }
    public virtual int DeleteData(int vIndex) { return 0; }
    public virtual int DeleteDataByID(int vID) { return 0; }
    public virtual ViSealedData GetData(int vIndex) { return null; }
    public virtual ViewData GetDataEx(int vID) { return new ViewData(); }
    public virtual void OnGUI(int vIndex) { }

    public void Load<T>() where T : ViSealedData, new()
    {
        Type type = typeof(T);
        string pathString = VISDir + type.Name + ".vis";
        //string vv =  Directory.GetCurrentDirectory();
        if (File.Exists(pathString) == false)
        {
            return;
        }
        StreamReader sr = new StreamReader(new FileStream(pathString, FileMode.Open, FileAccess.Read, FileShare.ReadWrite), System.Text.Encoding.Default);
        if (sr == null)
        {
            return;
        }

        string pathBinary = VIBDir + type.Name + ".vib";
        ViSealedDB<T>.Load(pathBinary, true);

        string s = "";
        sr.ReadLine();
        sr.ReadLine();
        while ((s = sr.ReadLine()) != null)
        {
            string[] splitStr = { "\t" };
            string[] strList = s.Split(splitStr, StringSplitOptions.None);
            T data = new T();
            ViStringIStream IS = new ViStringIStream();
            IS.Init(new List<string>(strList));
            EditableContainer parse = new EditableContainer();
            parse.ResName = pathString;
            parse.Parse(data);
            parse.Read(IS, data);

            T ddate = ViSealedDB<T>.Data(data.ID);
            ddate.Name = data.Name;

            Insert(parse, ddate);
        }
        sr.Close();
    }

    public string Insert(EditableContainer title, ViSealedData data)
    {
        string sErrorStr = null;
        for (int i = 0; i < mDataList.Count; ++i)
        {
            if (data.ID == mDataList[i].data.ID)
            {
                sErrorStr = "ID[" + data.ID + "]重复!";
            }
        }
        
        if (sErrorStr == null)
        {
            ViewData node;
            node.data = data;
            node.title = title;
            mDataList.Add(node);
        }
        return sErrorStr;
    }

    public string SaveVis<T>() where T : ViSealedData, new()
    {
        string returnValueString = "";
        string pathString = VISDir + typeof(T).Name + ".vis";
        StreamWriter sw = null;

        if (!File.Exists(pathString))
        {
            FileStream fs = File.Create(pathString);
            if (fs != null)
            {
                fs.Close();
            }
        }
        try
        {
            sw = new StreamWriter(pathString, false, System.Text.Encoding.Default);
        }
        catch (System.Exception ex)
        {
            sw = null;
        }
        if (sw != null)
        {
            IS_START = true;
            PrintName<T>(sw);
            sw.WriteLine();
            IS_START = true;
            PrintAliasName<T>(sw);
            sw.WriteLine();
            for (int i = 0; i < mDataList.Count; ++i)
            {
                IS_START = true;
                mDataList[i].title.AppendTo(sw);
                sw.WriteLine();
            }
            sw.Close();
        }
        return returnValueString;
    }

    public string Save<T>() where T : ViSealedData, new()
    {
        string returnValueString = SaveVis<T>();
        //-----------------------------------------------------------------------------------------------------
        string pathFomat = VIBDir + typeof(T).Name + ".vifmt";
        FileStream fmtw = File.Create(pathFomat);
        if (fmtw != null)
        {
            ViOStream OS = new ViOStream();
            string strFomat = "";
            PrintFomat<T>(ref strFomat);
            OS.Append(strFomat);
            fmtw.Write(OS.Cache, 0, OS.Length);
            fmtw.Close();
        }
        //
        string pathBinary = VIBDir + typeof(T).Name + ".vib";
        FileStream bw = File.Create(pathBinary);
        if (bw != null)
        {
            ViOStream OS = new ViOStream();
            Int32 count = mDataList.Count;
            OS.Append(count);

            for (int i = 0; i < mDataList.Count; ++i)
            {
                ViOStream iterOS = new ViOStream();
                mDataList[i].title.AppendTo(iterOS);
                OS.Append(iterOS);
            }
            bw.Write(OS.Cache, 0, OS.Length);
            bw.Close();

            if (!string.IsNullOrEmpty(returnValueString))
            {
                returnValueString += "但是 vib 正常输出完成..\n";
            }
        }
        else
        {
            returnValueString += " vib 输出失败..\n";
        }

        return returnValueString;
    }

    public ViSealedData GetNewData<T>(int vIndex) where T : ViSealedData, new()
    {
        if (vIndex < 0 || vIndex >= mDataList.Count)
        {
            return null;
        }

        ViOStream OS = new ViOStream();
        OS.Append(1);
        ViOStream iterOS = new ViOStream();
        mDataList[vIndex].title.AppendTo(iterOS);
        OS.Append(iterOS);

        ViIStream _stream = new ViIStream();
        _stream.Init(OS.Cache, 0, OS.Length);

        Int32 count = 0;
        _stream.Read(out count);

        if (count > 0 && _stream.RemainLength > 0)
        {
            ViIStream iterStream;
            _stream.Read(out iterStream);
            ViSealedDataLoadNode<T> data = new ViSealedDataLoadNode<T>();
            data.ReadHead(iterStream);
            if (data.Active)
            {
                //AddData(data);
                data.Ready();
                return data.Data;
            }
        }

        return null;
    }

    public static void PrintName<T>(StreamWriter sw) where T : ViSealedData, new()
    {
        T data = new T();
        PrintName("", data, sw);
    }

    public static void PrintName(string direction, object data, StreamWriter sw)
    {
        FieldInfo[] fields = ViSealedDataAssisstant.GetFeilds(data.GetType());

        foreach (FieldInfo element in fields)
        {
            if (element.FieldType.Name.StartsWith("Int32")
                || element.FieldType.Name.StartsWith("Int64")
                || element.FieldType.Name.StartsWith("String")
                || element.FieldType.Name.StartsWith("ViLazyString")
                || element.FieldType.Name.StartsWith("ViMask32")
                || element.FieldType.Name.StartsWith("ViEnum32")
                || element.FieldType.Name.StartsWith("ViForeignKey"))
            {
                if (DataEditor.IS_START)
                {
                    DataEditor.IS_START = false;
                    sw.Write(direction + "." + element.Name);
                }
                else
                {
                    sw.Write("\t" + direction + "." + element.Name);
                }
            }
            else if (element.FieldType.Name.StartsWith("ViForeignGroup"))
            {

            }
            else if (element.FieldType.Name.StartsWith("ViSealedArray"))
            {

            }
            else if (element.FieldType.Name.StartsWith("ViStaticArray"))
            {
                object fieldObject = element.GetValue(data);
                int len = ViArrayParser.Length(fieldObject);
                for (int idx = 0; idx < len; ++idx)
                {
                    object elementObject = ViArrayParser.Object(fieldObject, idx);
                    PrintName(direction + "." + element.Name + "[" + idx + "]", elementObject, sw);
                }
            }
            else
            {
                object fieldObject = element.GetValue(data);
                PrintName(direction + "." + element.Name, fieldObject, sw);
            }
        }
    }
    public static void PrintAliasName<T>(StreamWriter sw)
            where T : ViSealedData, new()
    {
        T data = new T();
        PrintAliasName("", data, sw);
    }
    public static void PrintAliasName(string direction, object data, StreamWriter sw)
    {
        FieldInfo[] fields = ViSealedDataAssisstant.GetFeilds(data.GetType());
        foreach (FieldInfo element in fields)
        {
            if (element.FieldType.Name.StartsWith("Int32")
                || element.FieldType.Name.StartsWith("Int64")
                || element.FieldType.Name.StartsWith("String")
                || element.FieldType.Name.StartsWith("ViLazyString")
                || element.FieldType.Name.StartsWith("ViMask32")
                || element.FieldType.Name.StartsWith("ViEnum32")
                || element.FieldType.Name.StartsWith("ViForeignKey"))
            {
                if (DataEditor.IS_START)
                {
                    DataEditor.IS_START = false;
                    sw.Write(direction + "." + Alias.Get(element.Name));
                }
                else
                {
                    sw.Write("\t" + direction + "." + Alias.Get(element.Name));
                }
            }
            else if (element.FieldType.Name.StartsWith("ViForeignGroup"))
            {

            }
            else if (element.FieldType.Name.StartsWith("ViSealedArray"))
            {

            }
            else if (element.FieldType.Name.StartsWith("ViStaticArray"))
            {
                object fieldObject = element.GetValue(data);
                int len = ViArrayParser.Length(fieldObject);
                for (int idx = 0; idx < len; ++idx)
                {
                    object elementObject = ViArrayParser.Object(fieldObject, idx);
                    PrintAliasName(direction + "." + Alias.Get(element.Name) + "[" + idx + "]", elementObject, sw);
                }
            }
            else
            {
                object fieldObject = element.GetValue(data);
                PrintAliasName(direction + "." + Alias.Get(element.Name), fieldObject, sw);
            }
        }
    }
    public static bool FileCompare(string file1, string file2)
    {
        if (file1 == file2)
        {
            return true;
        }
        int file1Byte = 0;
        int file2Byte = 0;
        FileStream fs1 = null;
        FileStream fs2 = null;
        try
        {
            fs2 = new FileStream(file2, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            using (fs1 = new FileStream(file1, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                if (fs1 == null || fs2 == null)
                {
                    return false;
                }
                if (fs1.Length != fs2.Length)
                {
                    fs1.Close();
                    fs2.Close();
                    return false;
                }
                do
                {
                    file1Byte = fs1.ReadByte();
                    file2Byte = fs2.ReadByte();
                } while ((file1Byte == file2Byte) && file1Byte != -1);
                fs1.Close();
                fs2.Close();
            }
            return file1Byte == file2Byte;
        }
        catch (System.Exception ex)//有异常就判定不相等吧
        {
            if (fs1 != null)
            {
                fs1.Close();
            }
            if (fs2 != null)
            {
                fs2.Close();
            }
            return false;
        }
    }

    public static void PrintFomat<T>(ref string fomat)
            where T : ViSealedData, new()
    {
        T data = new T();
        PrintFomat(data, ref fomat);
    }
    public static void PrintFomat(object data, ref string fomat)
    {
        FieldInfo[] fields = ViSealedDataAssisstant.GetFeilds(data.GetType());
        foreach (FieldInfo element in fields)
        {
            if (element.FieldType.Name.StartsWith("Int32"))
            {
                fomat += "i";
            }
            else if (element.FieldType.Name.StartsWith("ViMask32")
                || element.FieldType.Name.StartsWith("ViEnum32"))
            {
                fomat += "e";
            }
            else if (element.FieldType.Name.StartsWith("ViForeignKey"))
            {
                fomat += "k";
            }
            else if (element.FieldType.Name.StartsWith("ViForeignGroup"))
            {
                fomat += "g";
            }
            else if (element.FieldType.Name.StartsWith("ViSealedArray"))
            {
                fomat += "a";
            }
            else if (element.FieldType.Name.StartsWith("Int64"))
            {
                fomat += "l";
            }
            else if (element.FieldType.Name.StartsWith("String"))
            {
                fomat += "s";
            }
            else if (element.FieldType.Name.StartsWith("ViLazyString"))
            {
                fomat += "s";
            }
            else if (element.FieldType.Name.StartsWith("ViStaticArray"))
            {
                object fieldObject = element.GetValue(data);
                int len = ViArrayParser.Length(fieldObject);
                for (int idx = 0; idx < len; ++idx)
                {
                    object elementObject = ViArrayParser.Object(fieldObject, idx);
                    PrintFomat(elementObject, ref fomat);
                }
            }
            else
            {
                object fieldObject = element.GetValue(data);
                PrintFomat(fieldObject, ref fomat);
            }
        }
    }

    public static List<ViewData> GetDatas(Type type)
    {
        DataEditor handler;
        if (mTypeViews.TryGetValue(type, out handler))
        {
            if (!handler.Loaded)
            {
                handler.Load();
            }
            return handler.mDataList;
        }
        else
        {
            return null;
        }
    }

    public static List<ViewData> GetDatas<T>()
    {
        return GetDatas(typeof(T));
    }
}

public class StructHandler<T> : DataEditor where T : ViSealedData, new()
{
    public static StructHandler<T> Instance = new StructHandler<T>();
    static StructHandler()
    {
        mTypeViews[typeof(T)] = Instance;
    }

    public override void Load()
    {
        mDataList.Clear();
        Load<T>();
    }

    public override string Save()
    {
        string sMsg = Save<T>();
        if (string.IsNullOrEmpty(sMsg))
        {
            sMsg = "保存完成";
        }
        Debug.Log(sMsg);
        return sMsg;
    }

    public override void OnGUI(int vIndex)
    {
        if (vIndex > -1 && vIndex < mDataList.Count)
        {
            for (int i = 0; i < mDataList[vIndex].title.Children.Count; ++i)
            {
                mDataList[vIndex].title.Children[i].OnGUI();
            }
        }
    }

    public override ViSealedData GetData(int vIndex)
    {
        if (vIndex > -1 && vIndex < mDataList.Count)
        {
            return mDataList[vIndex].data;
        }
        return null;
    }

    public override ViewData GetDataEx(int vID)
    {
        for (int i = 0; i < mDataList.Count; ++i)
        {
            if (mDataList[i].data.ID == vID)
            {
                return mDataList[i];
            }
        }
        return new ViewData();
    }

    public override int DeleteData(int vIndex)
    {
        if (vIndex > -1 && vIndex < mDataList.Count)
        {
            mDataList.RemoveAt(vIndex);
            return Mathf.Min(vIndex, mDataList.Count - 1);
        }
        return vIndex;
    }

    public override int DeleteDataByID(int vID)
    {
        int vIndex = 0;
        for (int i = 0; i < mDataList.Count; ++i)
        {
            if (vID == mDataList[i].data.ID)
            {
                mDataList.RemoveAt(i);
                break;
            }
        }

        return Mathf.Min(vIndex, mDataList.Count - 1);
    }

    public int AddNewData()
    {
        T data = new T();
        data.ID = GetFreeID();
        data.Name = "新建" + data.ID;
        EditableContainer parse = new EditableContainer();
        parse.Parse(data);
        Insert(parse, data);
        return mDataList.Count - 1;
    }

    public override ViSealedData GetNewData(int vIndex)
    {
        return GetNewData<T>(vIndex);
    }
}