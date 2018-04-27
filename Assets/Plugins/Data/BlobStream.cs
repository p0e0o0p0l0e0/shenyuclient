using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.IO;


// ScriptableObject的子类必须一个类一个文件, 并且类和文件名保持一致


public class BlobStream : MonoBehaviour
{
	public void Reset()
	{
		DataSize = 0;
	}

	public void SaveFile(string fileName)
	{
		FileStream bw = File.Create(fileName);
		if (bw != null)
		{
			bw.Write(_data, 0, _data.Length);
			bw.Close();
		}
	}

	public Byte[] GetData()
	{
		return _data;
	}

	public void SetData(Byte[] data)
	{
		_data = data;
		DataSize = data.Length;
	}

	public Int64 DataSize;

	[HideInInspector]
	[SerializeField]
	Byte[] _data;
}