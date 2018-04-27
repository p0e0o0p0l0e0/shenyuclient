using System;
using System.Collections.Generic;

using ViEntityID = System.UInt64;
using ViArrayIdx = System.Int32;


public static class ViEntitySerialize
{
	public static ViEntityManager EntityNameger { get { return _entityManager; } set { _entityManager = value; } }
	static ViEntityManager _entityManager;

	public static void Append(ViOStream OS, ViEntity value)
	{
		OS.Append24(value.PackID);
	}
	public static void Append<TEntity>(ViOStream OS, TEntity value) where TEntity : class, ViEntity
	{
		if (value != null)
		{
			OS.Append24(value.PackID);
		}
		else
		{
			UInt32 packID = 0;
			OS.Append24(packID);
		}
	}
	public static void Append<TEntity>(ViOStream OS, List<TEntity> list) where TEntity : class, ViEntity
	{
		ViArrayIdx size = (ViArrayIdx)list.Count;
		OS.AppendPacked(size);
		for (int iter = 0; iter < list.Count; ++iter)
		{
			TEntity value = list[iter];
			Append(OS, value);
		}
	}
	public static void Read(ViIStream IS, out ViEntity value)
	{
		UInt32 packID;
		IS.Read24(out packID);
		value = EntityNameger.GetPackEntity(packID);
	}
	public static void Read<TEntity>(ViIStream IS, out TEntity value) where TEntity : class, ViEntity
	{
		UInt32 packID;
		IS.Read24(out packID);
		value = EntityNameger.GetPackEntity<TEntity>(packID);
	}
	public static void Read<TEntity>(ViIStream IS, out List<TEntity> list) where TEntity : class, ViEntity
	{
		ViArrayIdx size;
		IS.ReadPacked(out size);
		if (size > IS.RemainLength)
		{
			ViDebuger.Warning("Read List<TEntity>.size Error");
			list = new List<TEntity>();
			return;
		}
		list = new List<TEntity>();
		for (ViArrayIdx idx = 0; idx < size; ++idx)
		{
			TEntity value;
			Read(IS, out value);
			list.Add(value);
		}
	}
	public static bool Read<TEntity>(ViStringIStream IS, out TEntity value) where TEntity : class, ViEntity
	{
		value = default(TEntity);
		UInt32 packID;
		if (IS.Read(out packID) == false) { return false; }
		value = EntityNameger.GetPackEntity<TEntity>(packID);
		return true;
	}
	public static bool Read<TEntity>(ViStringIStream IS, out List<TEntity> list) where TEntity : class, ViEntity
	{
		list = null;
		ViArrayIdx size;
		if (IS.Read(out size) == false) { return false; }
		list = new List<TEntity>();
		for (ViArrayIdx idx = 0; idx < size; ++idx)
		{
			TEntity value;
			if (Read(IS, out value)) { return false; }
			list.Add(value);
		}
		return true;
	}
}
