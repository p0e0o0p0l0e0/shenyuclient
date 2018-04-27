using System;
using System.Collections.Generic;
using UnityEngine;

using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;

public static class DataExAssisstant
{
	public static CursorCamera.ConfigStruct Convert(SpaceCameraStruct.DataStruct data)
	{
		CursorCamera.ConfigStruct newData = new CursorCamera.ConfigStruct();
		newData.Pitch = data.Pitch;
		newData.Field = data.Field;
		newData.Height = data.Height * 0.01f;
		newData.Front = data.Front * 0.01f;
		newData.Distance = data.Distance * 0.01f;
		return newData;
	}

}

public static class ClientDevicePlatformAssisstent
{
	public static ClientDevicePlatform Convert(UnityEngine.RuntimePlatform type)
	{
		switch (type)
		{
			case UnityEngine.RuntimePlatform.IPhonePlayer:
				return ClientDevicePlatform.IOS;
			default:
				return ClientDevicePlatform.ANDROID;
		}
	}

	public static ClientDeviceProperty GetDeviceProperty()
	{
		ClientDeviceProperty deviceProperty = new ClientDeviceProperty();
		deviceProperty.Platform = (UInt8)Convert(Application.platform);
		deviceProperty.DeviceName = SystemInfo.deviceName;
		deviceProperty.DeviceModel = SystemInfo.deviceModel;
		deviceProperty.DeviceUniqueIdentifier = SystemInfo.deviceUniqueIdentifier;
		deviceProperty.OperatingSystem = SystemInfo.operatingSystem;
		deviceProperty.SystemMemorySize = SystemInfo.systemMemorySize;
		deviceProperty.ProcessorType = SystemInfo.processorType;
		deviceProperty.ProcessorCount = (Int8)SystemInfo.processorCount;
		deviceProperty.ProcessorFrequency = SystemInfo.processorFrequency;
		deviceProperty.GraphicsDeviceName = SystemInfo.graphicsDeviceName;
		deviceProperty.GraphicsDeviceVendor = SystemInfo.graphicsDeviceVendor;
		deviceProperty.GraphicsDeviceVersion = SystemInfo.graphicsDeviceVersion;
		deviceProperty.GraphicsMemorySize = SystemInfo.graphicsMemorySize;
		deviceProperty.ScreenX = (Int16)Screen.width;
		deviceProperty.ScreenY = (Int16)Screen.height;
		return deviceProperty;
	}
}

public class ItemCountPropertySet
{
	public List<ItemCountProperty> List { get { return _list; } }

	public void Set(List<ItemCountProperty> list)
	{
		Clear();
		for (int iter = 0; iter < list.Count; ++iter)
		{
			Add(list[iter]);
		}
	}

	public void Add(ItemCountProperty item)
	{
		for (int iter = 0; iter < _list.Count; ++iter)
		{
			if (_list[iter].Info == item.Info)
			{
				ItemCountProperty newProperty = _list[iter];
				newProperty.Count += item.Count;
				_list[iter] = newProperty;
				return;
			}
		}
		_list.Add(item);
	}

	public void Clear()
	{
		_list.Clear();
	}
	List<ItemCountProperty> _list = new List<ItemCountProperty>();
}

public class ItemWithCountSet
{
	public List<ItemCountStruct> List { get { return _list; } }

	public void Set(List<ItemCountStruct> list)
	{
		Clear();
		for (int iter = 0; iter < list.Count; ++iter)
		{
			Add(list[iter]);
		}
	}

	public void Add(ItemCountStruct item)
	{
		for (int iter = 0; iter < _list.Count; ++iter)
		{
			if (_list[iter].Item == item.Item)
			{
				ItemCountStruct newProperty = _list[iter];
				newProperty.Count += item.Count;
				_list[iter] = newProperty;
				return;
			}
		}
		_list.Add(item);
	}
	public void Clear()
	{
		_list.Clear();
	}
	List<ItemCountStruct> _list = new List<ItemCountStruct>();
}