using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;


public enum ViSealDataState
{
	ACTIVE,
	DEACTIVE,
}

public class ViSealedData
{
	public Int32 ID;
	public string Name = string.Empty;
	public string Note = string.Empty;
	public ViEnum32<ViSealDataState> State;

	public virtual void Format() { }
	public virtual void Start() { }

	public void _ReadHead(ViIStream stream)
	{
		stream.Read(out ID);
		stream.Read(out Name);
		stream.Read(out Note);
		Int32 value;
		stream.Read(out value);
		State = new ViEnum32<ViSealDataState>(value);
	}

	public void _Ready(ViIStream stream)
	{
		ViBinaryReader.Read(stream, this);
	}
}

public class ViSealedFile<T>
	where T : ViSealedData, new()
{
	public static string Name = string.Empty;
}

public class ViSealedDataLoadNode<T>
	where T : ViSealedData, new()
{
	public static bool ClearName = false;
	public static bool ClearNote = false;

	public Int32 ID { get { return _head.ID; } }
	public string Name { get { return _head.Name; } }
	public bool Active { get { return _head.State == (Int32)ViSealDataState.ACTIVE; } }
	public T Data { get { return _data; } }
	public bool IsReady { get { return _stream == null; } }

	public void ReadHead(ViIStream stream)
	{
		_head._ReadHead(stream);
		_stream = stream;
		//
		if (ClearName)
		{
			_head.Name = string.Empty;
		}
		if (ClearNote)
		{
			_head.Note = string.Empty;
		}
	}

	public void Ready()
	{
		if (_stream != null)
		{
			_data = new T();
			_stream.ReWind();
			_data._Ready(_stream);
			_data.Format();
			_stream.Clear();
			_stream = null;
			_head = _data;
			//_data.Start();
			//
			if (ClearName)
			{
				_head.Name = string.Empty;
			}
			if (ClearNote)
			{
				_head.Note = string.Empty;
			}
		}
	}
	ViSealedData _head = new ViSealedData();
	T _data;
	ViIStream _stream;
}

public static class ViSealedDB<T>
	where T : ViSealedData, new()
{
	public static Dictionary<Int32, T> Dict
	{
		get
		{
			UpdateStream();
			if (_dict == null)
			{
				Ready();
				_dict = new Dictionary<Int32, T>(_idxDatas.Count);
				foreach (KeyValuePair<Int32, ViSealedDataLoadNode<T>> iter in _idxDatas)
				{
					_dict[iter.Key] = iter.Value.Data;
				}
			}
			return _dict;
		}
	}

	public static List<T> Array
	{
		get
		{
			UpdateStream();
			if (_list == null)
			{
				Ready();
				_list = new List<T>(_idxDatas.Count);
				foreach (KeyValuePair<Int32, ViSealedDataLoadNode<T>> iter in _idxDatas)
				{
					if (!IncludeZero && iter.Key == 0)
					{
						continue;
					}
					_list.Add(iter.Value.Data);
				}
			}
			return _list;
		}
	}

	public static bool IncludeZero = true;

	public static Int32 MaxID
	{
		get
		{
			UpdateStream();
			return _maxID;
		}
	}

	public static bool IsLoaded
	{
		get
		{
			return _idxDatas != null || _stream != null;
		}
	}

	public static T Data(Int32 ID)
	{
		UpdateStream();
		ViSealedDataLoadNode<T> data = null;
		if (_idxDatas.TryGetValue(ID, out data))
		{
			data.Ready();
			return data.Data;
		}
		ViDebuger.Warning("There is no data<" + typeof(T).Name + ">[" + ID + "]");
		if (_idxDatas.TryGetValue(0, out data))
		{
			data.Ready();
			return data.Data;
		}
		return _defaultData;
	}

	public static T Data(UInt32 ID)
	{
		return Data((Int32)ID);
	}

	public static T GetData(Int32 ID)
	{
		return GetData(ID, true);
	}

	public static T GetData(Int32 ID, bool includeZero)
	{
		if (ID == 0 && !includeZero)
		{
			return null;
		}
		UpdateStream();
		ViSealedDataLoadNode<T> data = null;
		_idxDatas.TryGetValue(ID, out data);
		if (data == null)
		{
			//ViDebuger.Warning("There is no data<" + typeof(T).Name + ">[" + ID + "]");
			return default(T);
		}
		else
		{
			data.Ready();
			return data.Data;
		}
	}

	public static T GetData(UInt32 ID)
	{
		return GetData((Int32)ID);
	}

	public static T GetData(UInt32 ID, bool IncludeZero)
	{
		return GetData((Int32)ID, IncludeZero);
	}

	public static T Data(string name)
	{
		if (string.IsNullOrEmpty(name))
		{
			name = string.Empty;
		}
		UpdateStream();
		ViSealedDataLoadNode<T> data = null;
		if (_nameDatas.TryGetValue(name, out data))
		{
			data.Ready();
			return data.Data;
		}
		if (_idxDatas.TryGetValue(0, out data))
		{
			data.Ready();
			return data.Data;
		}
		return _defaultData;
	}

	public static T GetData(string name)
	{
		if (string.IsNullOrEmpty(name))
		{
			name = string.Empty;
		}
		UpdateStream();
		ViSealedDataLoadNode<T> data = null;
		_nameDatas.TryGetValue(name, out data);
		if (data != null)
		{
			data.Ready();
			return data.Data;
		}
		return default(T);
	}

	public static void Clear()
	{
		_stream = null;
		//
		if (_idxDatas != null)
		{
			_idxDatas.Clear();
		}
		if (_nameDatas != null)
		{
			_nameDatas.Clear();
		}
		if (_dict != null)
		{
			_dict.Clear();
			_dict = null;
		}
		if (_list != null)
		{
			_list.Clear();
			_list = null;
		}
	}

	public static void Load(string file, bool ready)
	{
		Clear();
		if (File.Exists(file) == false)
		{
			ViDebuger.Warning("Can not find " + file);
			return;
		}
		FileStream br = File.Open(file, FileMode.Open, FileAccess.Read, FileShare.Read);
		if (br == null)
		{
			return;
		}
		byte[] bufferArray = new byte[br.Length];
		br.Read(bufferArray, 0, bufferArray.Length);
		ViIStream IS = new ViIStream();
		IS.Init(bufferArray, 0, bufferArray.Length);
		Load(IS, ready);
		br.Close();
	}

	public static void Load(ViIStream IS, bool ready)
	{
		Clear();
		//
		_stream = IS;
		_ready = ready;
		//
		if (_ready)
		{
			UpdateStream();
			Ready();
		}
	}

	static void UpdateStream()
	{
		if (_stream == null)
		{
			return;
		}
		//
		//ViDebuger.Record("SealedData<" + typeof(T).Name + ">UpdateStream.Size=" + _stream.RemainLength);
		//
		Int32 count = 0;
		_stream.Read(out count);
		if (count > _stream.RemainLength)
		{
			ViDebuger.Warning("SealedData<" + typeof(T).Name + ">Load Stream Error!");
			return;
		}
		//
		_idxDatas = new Dictionary<Int32, ViSealedDataLoadNode<T>>(count);// Capibility
		_nameDatas = new Dictionary<string, ViSealedDataLoadNode<T>>(count);// Capibility
		_maxID = 0;
		while (count > 0 && _stream.RemainLength > 0)
		{
			ViIStream iterStream;
			_stream.Read(out iterStream);
			ViSealedDataLoadNode<T> data = new ViSealedDataLoadNode<T>();
			data.ReadHead(iterStream);
			if (data.Active)
			{
				AddData(data);
			}
			--count;
		}
		//
		_stream.Clear();
		_stream = null;
	}

	public static void Ready()
	{
		UpdateStream();
		//
		if (_ready)
		{
			return;
		}
		//ViDebuger.Record("SealedData<" + typeof(T).Name + ">Ready");
		foreach (KeyValuePair<Int32, ViSealedDataLoadNode<T>> pair in _idxDatas)
		{
			pair.Value.Ready();
		}
		_ready = true;
	}

	static void AddData(ViSealedDataLoadNode<T> data)
	{
		//ViDebuger.Note("ViSealedDB<" + typeof(T).Name + ">AddData(ID = " + data.ID + ", Name = " + data.Name + ")");
		//
		if (_idxDatas.ContainsKey(data.ID))
		{
			ViDebuger.Warning("ID Conflicted<" + data.ID + ", " + data.Name + ">");
			return;
		}
		_maxID = Math.Max(data.ID, _maxID);
		_idxDatas.Add(data.ID, data);
		if (!string.IsNullOrEmpty(data.Name))
		{
			if (_nameDatas.ContainsKey(data.Name))
			{

			}
			else
			{
				_nameDatas.Add(data.Name, data);
			}
		}
	}

	public static void SetData(Int32 ID, T value)
	{
		UpdateStream();
		if (Dict.ContainsKey(ID))
		{
			Dict[ID] = value;
		}
		else
		{
			Dict.Add(ID, value);
		}
	}
    public static bool IsContainId(int id)
    {
        return _idxDatas.ContainsKey(id);
    }

	static Dictionary<Int32, ViSealedDataLoadNode<T>> _idxDatas = new Dictionary<Int32, ViSealedDataLoadNode<T>>();
	static Dictionary<string, ViSealedDataLoadNode<T>> _nameDatas = new Dictionary<string, ViSealedDataLoadNode<T>>();
	static Dictionary<Int32, T> _dict;
	static List<T> _list;
	static T _defaultData = new T();
	static bool _ready = false;
	static ViIStream _stream;
	static Int32 _maxID = 0;
}

public static class ViSealedDataAssisstant
{
	public static readonly BindingFlags BindingFlag = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

	public static FieldInfo[] GetFeilds(Type type)
	{
		if (type.IsSubclassOf(typeof(ViSealedData)))
		{
			FieldInfo[] fields = type.GetFields(BindingFlag);
			// 修正继承属性的位置
			FieldInfo[] fieldList = new FieldInfo[fields.Length];
			int headSize = 4;
			for (int idx = headSize; idx < fields.Length; ++idx)
			{
				fieldList[idx] = fields[idx - headSize];
			}
			for (int idx = 0; idx < headSize; ++idx)
			{
				fieldList[idx] = fields[fields.Length - headSize + idx];
			}
			return fieldList;
		}
		else
		{
			FieldInfo[] fieldList = type.GetFields(BindingFlag);
			return fieldList;
		}
	}
}

public class ViEmptySealedData : ViSealedData { }
public class ViSealedDataTypeStruct : ViSealedData { }

public class ViSealedArray<T>
{
	public List<T> List { get { return _list; } }
	List<T> _list = new List<T>();
}

