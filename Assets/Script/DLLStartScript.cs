
#if SCRIPT_DLL
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System;

public class DLLStartScript : MonoBehaviour
{
	public bool UsePresistentPath = false;
	public bool UsePublishSDK = false;
	public bool PrintSystem = false;
	public bool SealedDataEditor = false;
	//
	void Start()
	{
		UnityEngine.Application.logMessageReceived += this.OnUnityLog;
		StartCoroutine(LoadDll());
	}

	IEnumerator LoadDll()
	{
		string URLRoot = UsePresistentPath ? ApplicationPlatform.PersistentDataURL : ApplicationPlatform.StreamingDataURL;
		string dllName = "game";
		string URLDll = URLRoot + "start/external/" + dllName;
		string URLRes = URLRoot + "pro/game/game";
		//
		WWW dllWWW = new WWW(URLDll);
		yield return dllWWW;
		//
		WWW resWWW = new WWW(URLRes);
		yield return resWWW;
		//
		try
		{
			Print(AppDomain.CurrentDomain);
			Assembly dllAssembly = LoadDll(dllWWW, dllName);
			Print(AppDomain.CurrentDomain);
			//
			Type[] types = dllAssembly.GetTypes();
			//
			Print(dllName, dllAssembly);
			Print("GetEntryAssembly", Assembly.GetEntryAssembly());
			Print("GetCallingAssembly", Assembly.GetCallingAssembly());
			Print("GetExecutingAssembly", Assembly.GetExecutingAssembly());
			//
			GameObject gameObj = GameObject.Instantiate(resWWW.assetBundle.LoadAsset<GameObject>("game"));
			AddComponent(gameObj, dllAssembly, "MainScript");
		}
		catch (System.Exception ex)
		{
			Debug.Log(ex.Message);
		}
	}

	void AddComponent(GameObject gameObj, Assembly dllAssembly, string name)
	{
		Type componentType = dllAssembly.GetType(name);
		Component component = gameObj.GetComponent(name);
		if (component == null)
		{
			Debug.Log("StartScript.AddComponent(" + name + ")Time=" + Time.time);
			component = gameObj.AddComponent(componentType);
		}
		//
		SetScriptValue(componentType, component, "UsePresistentPath", (System.Object)UsePresistentPath);
		SetScriptValue(componentType, component, "UsePublishSDK", (System.Object)UsePublishSDK);
		SetScriptValue(componentType, component, "PrintSystem", (System.Object)PrintSystem);
		SetScriptValue(componentType, component, "SealedDataEditor", (System.Object)SealedDataEditor);
	}

	static void SetScriptValue(Type type, Component obj, string name, System.Object value)
	{
		FieldInfo field = type.GetField(name);
		field.SetValue(obj, value);
	}

	static Assembly LoadDll(WWW www, string name)
	{
		AssetBundle bundle = www.assetBundle;
		byte[] bytes = ((TextAsset)bundle.LoadAsset(name, typeof(TextAsset))).bytes;
		return System.Reflection.Assembly.Load(bytes);
	}

	static void Print(string name, Assembly assembly)
	{
		//if (assembly != null)
		//{
		//    Type[] array = assembly.GetExportedTypes();
		//    Debug.Log(name + ".TypeSize = " + array.Length);
		//}
		//else
		//{
		//    Debug.Log(name + " is NULL");
		//}
	}
	static void Print(AppDomain domain)
	{
		//Assembly[] array = domain.GetAssemblies();
		//Debug.Log("AppDomain.Assemblies.Size = " + array.Length);
		//foreach(Assembly iter in array)
		//{
		//    Debug.Log(iter.FullName);
		//}
	}

	void OnUnityLog(string condition, string stackTrace, UnityEngine.LogType type)
	{
		if (type != LogType.Exception)
		{
			stackTrace = string.Empty;
		}
		//
		_log += condition + "\r\n[Statck]\r\n" + stackTrace + "\r\n";
	}

	//public void OnGUI()
	//{
	//    GUI.TextArea(new Rect(0, 0, 500, 500), _log);
	//}

	string _log = string.Empty;
}
#endif