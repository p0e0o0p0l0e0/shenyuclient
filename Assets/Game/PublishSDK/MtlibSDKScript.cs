using UnityEngine;

public class MtlibSDKScript : MonoBehaviour
{
	public ViDelegateAssisstant.Dele<string> LoginSuccessCallback;

	public void OnInitSuccess(string text)
	{
		Log("MtlibSDKScript.OnInitSuccess:" + text);
		//
		MtlibSDK.Login();
	}

	public void OnInitFail(string text)
	{
		Log("MtlibSDKScript.OnInitFail:" + text);
		//
		string log = "SDK初始化失败, 请检查网络是否异常";
		//ViewControllerManager.ConfirmView.ShowConfirm1(log, this.OnExitGame, null);
	}

	public void OnLoginSuccess(string token)
	{
		Log("MtlibSDKScript.OnLoginSuccess:" + token);
		//
		MtlibSDK.Logining = false;
		ViDelegateAssisstant.Invoke(LoginSuccessCallback, PublishSDKAssisstant.SearchAccountURL(token));
	}

	public void OnLoginFail(string text)
	{
		Log("MtlibSDKScript.OnLoginFail:" + text);
		//
		MtlibSDK.Logining = false;
		string log = "SDK登录失败, 请检查网络是否异常";
		//ViewControllerManager.ConfirmView.ShowConfirm1(log, this.OnExitGame, null);
	}

	public void OnLoginCannel(string text)
	{
		Log("MtlibSDKScript.OnLoginCannel:" + text);
		//
		MtlibSDK.Login();
	}

	public void OnLogOut(string text)
	{
		Log("MtlibSDKScript.OnLogOut:" + text);
	}

	public void OnPaySuccess(string text)
	{
		Log("MtlibSDKScript.OnPaySuccess:" + text);
	}

	public void OnPayFail(string text)
	{
		Log("MtlibSDKScript.OnPayFail:" + text);
	}

	public void OnPayCancel(string text)
	{
		Log("MtlibSDKScript.OnPayCancel:" + text);
	}

	void OnExitGame(System.Object obj)
	{
		GameApplication.Instance.ExitApp();
	}

	void Log(string log)
	{
		ViDebuger.Record(log);
	}
}

