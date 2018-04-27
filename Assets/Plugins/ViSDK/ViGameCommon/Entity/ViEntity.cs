using System;
using System.Collections.Generic;

using ViEntityTypeID = System.Byte;
using ViEntityID = System.UInt64;
using Int8 = System.SByte;
using UInt8 = System.Byte;

public interface ViEntity
{
	ViEntityID ID { get; }
	UInt32 PackID { get; }
	ViEntityTypeID Type { get; }
	string Name { get; }
	bool IsLocal { get; }
	bool Active { get; }

	void Enable(ViEntityID ID, UInt32 PackID, bool asLocal);
	void PreStart();
	void Start();
	void AftStart();
	void Tick(float fDeltaTime);
	void ClearCallback();
	void PreEnd();
	void End();
	void AftEnd();
	void SetActive(bool value);
}

public class ViEntityAssisstant
{
	public static bool IsNullOrEmpty(ViEntity entity)
	{
		if (System.Object.ReferenceEquals(entity, null))
		{
			return true;
		}
		if (entity.Active == false)
		{
			return true;
		}
		return false;
	}

	public static bool Requals(ViEntity left, ViEntity right)
	{
		return System.Object.ReferenceEquals(left, right);
	}

	public static bool Contain<TEntity>(List<TEntity> list, TEntity entity) where TEntity : class, ViEntity
	{
		for (int iter = 0; iter < list.Count; ++iter)
		{
			if (System.Object.ReferenceEquals(list[iter], entity))
			{
				return true;
			}
		}
		return false;
	}

	public static bool Remove<TEntity>(List<TEntity> list, TEntity entity) where TEntity : class, ViEntity
	{
		for (int iter = 0; iter < list.Count; ++iter)
		{
			if (System.Object.ReferenceEquals(list[iter], entity))
			{
				list.RemoveAt(iter);
				return true;
			}
		}
		return false;
	}

}
