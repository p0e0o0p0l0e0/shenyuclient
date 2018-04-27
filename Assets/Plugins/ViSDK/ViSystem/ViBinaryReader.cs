using System;
using System.Collections.Generic;
using System.Reflection;

public static class ViBinaryReader
{
	public static readonly BindingFlags BindingFlag = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

	public static readonly Type TTYPE_StaticArray = typeof(ViStaticArray<object>).GetGenericTypeDefinition();
	public static readonly Type TYPE_Enum = typeof(ViEnum32<object>).GetGenericTypeDefinition();
	public static readonly Type TYPE_Mask = typeof(ViMask32<object>).GetGenericTypeDefinition();
	public static readonly Type TYPE_ForeignKey = typeof(ViForeignKey<ViSealedData>).GetGenericTypeDefinition();
	public static readonly Type TYPE_ForeignGroup = typeof(ViForeignGroup<ViSealedData>).GetGenericTypeDefinition();
	public static readonly Type TYPE_SealedArray = typeof(ViSealedArray<Int32>).GetGenericTypeDefinition();
	public static readonly Type TYPE_Int32 = typeof(Int32);
	public static readonly Type TYPE_Int64 = typeof(Int64);
	public static readonly Type TYPE_String = typeof(string);
	public static readonly Type TYPE_LazyString = typeof(ViLazyString);

	public static bool Read<T>(ViIStream IS, out T obj)
		where T : class, new()
	{
		obj = new T();
		Read(IS, obj);
		return true;
	}
	public static bool ReadSealedData<T>(ViIStream IS, out T obj)
		where T : ViSealedData, new()
	{
		obj = new T();
		Read(IS, obj);
		return true;
	}

	public static void Read(ViIStream IS, object obj)
	{
		FieldInfo[] fieldList = CacheField0(obj.GetType());
		for (int iter = 0; iter < fieldList.Length; ++iter)
		{
			FieldInfo field = fieldList[iter];
			if (field.FieldType.Equals(TYPE_Int32))
			{
				ReadInt32Field(IS, field, ref obj);
			}
			else if (field.FieldType.Equals(TYPE_Int64))
			{
				ReadInt64Field(IS, field, ref obj);
			}
			else if (field.FieldType.Equals(TYPE_String))
			{
				ReadStringField(IS, field, ref obj);
			}
			else if (field.FieldType.Equals(TYPE_LazyString))
			{
				ReadLazyStringField(IS, field, ref obj);
			}
			else
			{
				if (field.FieldType.IsGenericType)
				{
					field.FieldType.GetGenericTypeDefinition();
					if (field.FieldType.GetGenericTypeDefinition() == TTYPE_StaticArray)
					{
						ReadArray(IS, field, ref obj);
					}
					else if (field.FieldType.GetGenericTypeDefinition() == TYPE_ForeignGroup)
					{
						// 不处理
					}
					else if (field.FieldType.GetGenericTypeDefinition() == TYPE_SealedArray)
					{
						// 不处理
					}
					else
					{
						ReadStructInt32Field(IS, field, ref obj);
					}
				}
				else
				{
					object fieldObject = field.GetValue(obj);
					Read(IS, fieldObject);
					field.SetValue(obj, fieldObject);
				}
			}
		}
	}

	static void ReadArray(ViIStream IS, FieldInfo field, ref object data)
	{
		object fieldObject = field.GetValue(data);
		int len = ViArrayParser.Length(fieldObject);
		for (int idx = 0; idx < len; ++idx)
		{
			object elementObject = ViArrayParser.Object(fieldObject, idx);
			if (elementObject.GetType().Equals(TYPE_Int32))
			{
				Int32 value;
				IS.Read(out value);
				ViArrayParser.SetObject(fieldObject, idx, value);
			}
			else if (elementObject.GetType().Equals(TYPE_String))
			{
				string value;
				IS.Read(out value);
				ViArrayParser.SetObject(fieldObject, idx, elementObject);
			}
			else
			{
				Read(IS, elementObject);
				ViArrayParser.SetObject(fieldObject, idx, elementObject);
			}
		}
		field.SetValue(data, fieldObject);
	}
	static void ReadStringField(ViIStream IS, FieldInfo field, ref object data)
	{
		string value;
		IS.Read(out value);
		field.SetValue(data, value);
	}
	static void ReadLazyStringField(ViIStream IS, FieldInfo field, ref object data)
	{
		ViLazyString value;
		IS.Read(out value);
		field.SetValue(data, value);
	}
	static void ReadInt32Field(ViIStream IS, FieldInfo field, ref object data)
	{
		Int32 value;
		IS.Read(out value);
		field.SetValue(data, value);
	}
	static void ReadInt64Field(ViIStream IS, FieldInfo field, ref object data)
	{
		Int64 value;
		IS.Read(out value);
		field.SetValue(data, value);
	}
	static void ReadStructInt32Field(ViIStream IS, FieldInfo field, ref object data)
	{
		object obj = field.GetValue(data);
		FieldInfo[] fieldList = CacheField1(obj.GetType());
		//ViDebuger.AssertError(fieldList.Length == 1);
		Int32 value;
		IS.Read(out value);
		fieldList[0].SetValue(obj, value);
		field.SetValue(data, obj);
	}

	static FieldInfo[] CacheField0(Type type)
	{
		FieldInfo[] fields;
		if (_fieldList.TryGetValue(type, out fields))
		{
			return fields;
		}
		else
		{
			fields = ViSealedDataAssisstant.GetFeilds(type);
			_fieldList[type] = fields;
			return fields;
		}
	}

	static FieldInfo[] CacheField1(Type type)
	{
		FieldInfo[] fields;
		if (_fieldList.TryGetValue(type, out fields))
		{
			return fields;
		}
		else
		{
			fields = type.GetFields(BindingFlag);
			_fieldList[type] = fields;
			return fields;
		}
	}
	static Dictionary<Type, FieldInfo[]> _fieldList = new Dictionary<Type, FieldInfo[]>();

}

public static class ViBinaryCopy
{
	public static void Copy<T>(T from, T to)
		where T : ViSealedData, new()
	{
		_Copy(from, to);
	}

	static void _Copy(object from, object to)
	{
		FieldInfo[] fieldList = ViSealedDataAssisstant.GetFeilds(from.GetType());
		for (int iter = 0; iter < fieldList.Length; ++iter)
		{
			FieldInfo iterfield = fieldList[iter];
			object iterFrom = iterfield.GetValue(from);
			object iterTo = iterfield.GetValue(to);
			if (iterfield.FieldType.Equals(ViBinaryReader.TYPE_Int32))
			{
				_CopyValue(iterfield, iterFrom, to);
			}
			else if (iterfield.FieldType.Equals(ViBinaryReader.TYPE_Int64))
			{
				_CopyValue(iterfield, iterFrom, to);
			}
			else if (iterfield.FieldType.Equals(ViBinaryReader.TYPE_String))
			{
				_CopyValue(iterfield, iterFrom, to);
			}
			else if (iterfield.FieldType.Equals(ViBinaryReader.TYPE_LazyString))
			{
				_CopyValue(iterfield, iterFrom, to);
			}
			else
			{
				if (iterfield.FieldType.IsGenericType)
				{
					iterfield.FieldType.GetGenericTypeDefinition();
					if (iterfield.FieldType.GetGenericTypeDefinition() == ViBinaryReader.TTYPE_StaticArray)
					{
						_CopyArray(iterfield, iterFrom, iterTo);
					}
					else if (iterfield.FieldType.GetGenericTypeDefinition() == ViBinaryReader.TYPE_ForeignGroup)
					{
						// 不处理
					}
					else if (iterfield.FieldType.GetGenericTypeDefinition() == ViBinaryReader.TYPE_SealedArray)
					{
						// 不处理
					}
					else
					{
						_Copy(iterFrom, iterTo);
						iterfield.SetValue(to, iterTo);
					}
				}
				else
				{
					_Copy(iterFrom, iterTo);
					iterfield.SetValue(to, iterTo);
				}
			}
		}
	}

	static void _CopyArray(FieldInfo field, object from, object to)
	{
		int len = ViArrayParser.Length(from);
		for (int idx = 0; idx < len; ++idx)
		{
			object iterFrom = ViArrayParser.Object(from, idx);
			object iterTo = ViArrayParser.Object(to, idx);
			_Copy(iterFrom, iterTo);
			ViArrayParser.SetObject(to, idx, iterTo);
		}
	}

	static void _CopyValue(FieldInfo field, object from, object to)
	{
		field.SetValue(to, from);
	}
}