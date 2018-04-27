using UnityEngine;
using System.Collections;

public static class MtlibSDK
{
	public static ViConstValue<string> VALUE_AppID = new ViConstValue<string>("AppID", "");
	public static ViConstValue<string> VALUE_AppKey = new ViConstValue<string>("AppKey", "");

	public static bool Pausing = false;
	public static bool Inited = false;
	public static bool Logining = false;
	public static MtlibSDKScript Script;

	public static void InitSDK(string gameObjectName, ViDelegateAssisstant.Dele<string> callback)
	{
		GameObject obj = new GameObject(gameObjectName);
		Script = obj.AddComponent<MtlibSDKScript>();
		Script.LoginSuccessCallback = callback;
		InitSDK(VALUE_AppID, VALUE_AppKey, gameObjectName);
	}

	public static void InitSDK(string appuid, string appkey, string gameObjectName)
	{
		Call("InitSDK", appuid, appkey, gameObjectName);
		Inited = true;
		//
		if (Application.isEditor)
		{
			Script.OnInitSuccess("");
		}
	}

	public static void Login()
	{
		Call("Login");
		//
		Logining = true;
		//
		if (Application.isEditor)
		{
			Script.OnLoginSuccess("yisa");
		}
	}

	public static void LogOut()
	{
		Call("LogOut");
	}

	public static void Pay(string accountID, string productID, string productName, int price, string orderID, string extra, string backURL)
	{
		Call("Pay", accountID, productID, productName, price, orderID, extra, backURL);
	}

	public static void OnDestroy()
	{
		Call("onDestroy");
	}

	public static void OnPause()
	{
		Call("onPause");
	}

	public static void OnResume()
	{
		Call("onResume");
	}

	public static void InstallAPK(string file)
	{
		Call("InstallAPK", file);
	}

	public static bool IsCanWrite()
	{
		return Call<bool>("IsCanWrite");
	}

	static string Android_CLASS_DEFINE = "com.unity3d.player.UnityPlayer";
	static string Android_OBJECRT_DEFINE = "currentActivity";
	static void Call(string methodName, params object[] args)
	{
		Log(methodName);
		//
		if (!Application.isEditor)
		{
			using (AndroidJavaClass jc = new AndroidJavaClass(Android_CLASS_DEFINE))
			{
				using (AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>(Android_OBJECRT_DEFINE))
				{
					jo.Call(methodName, args);
				}
			}
		}
	}

	static T Call<T>(string methodName, params object[] args)
	{
		Log(methodName);
		//
		if (!Application.isEditor)
		{
			using (AndroidJavaClass jc = new AndroidJavaClass(Android_CLASS_DEFINE))
			{
				using (AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>(Android_OBJECRT_DEFINE))
				{
					return jo.Call<T>(methodName, args);
				}
			}
		}
		else
		{
			return default(T);
		}
	}

	static void Log(string str)
	{
		if (ViDebuger.RecordCallback != null)
		{
			ViDebuger.Record("InvokeJava." + str);
		}
		else
		{
			Debug.Log("InvokeJava." + str + "/TIME=" + Time.time);
		}
	}

}
