using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using UnityEngine;

public static class PublishSDKAssisstant
{
	public static ViConstValue<string> VALUE_AccountLoginURL = new ViConstValue<string>("AccountLoginURL", "http://192.168.100.71:8090/login/");
	public static ViConstValue<string> VALUE_AccountLoginMD5 = new ViConstValue<string>("AccountLoginMD5", "WorldX");
	public static ViConstValue<float> VALUE_PublishSDKHTTPTimeOut = new ViConstValue<float>("PublishSDKHTTPTimeOut", 3.0f);
	
	public static char EnterServerSplitSign = '-';
	public static char[] EnterServerSplitSigns = { EnterServerSplitSign };

	public static string GetURLResult(string URL)
	{
		try
		{
			System.Net.WebRequest wReq = System.Net.WebRequest.Create(URL);
			wReq.Timeout = ViMathDefine.IntNear(VALUE_PublishSDKHTTPTimeOut * 1000);
			System.Net.WebResponse wResp = wReq.GetResponse();
			System.IO.Stream respStream = wResp.GetResponseStream();
			using (System.IO.StreamReader reader = new System.IO.StreamReader(respStream, Encoding.UTF8))
			{
				return reader.ReadToEnd();
			}
		}
		catch (System.Exception ex)
		{
			ViDebuger.Warning("GetUrltoHtml.Error=" + ex.ToString());
		}
		return "";
	}

	public static string MD5Encrypt(string content)
	{
		MD5 md5 = MD5.Create();
		byte[] data = md5.ComputeHash(Encoding.Default.GetBytes(content));
		StringBuilder sBuilder = new StringBuilder();
		for (int iter = 0; iter < data.Length; ++iter)
		{
			sBuilder.Append(data[iter].ToString("x2"));
		}
		return sBuilder.ToString();
	}

	public static Int64 GetTime1970()
	{
		System.DateTime time1970 = new System.DateTime(1970, 1, 1);
		System.DateTime timeNow = DateTime.UtcNow;
		TimeSpan ts = timeNow.Subtract(time1970);
		return (Int64)ts.TotalSeconds;
	}

	public static string SearchAccountURL(string token)
	{
		string timeStamp = PublishSDKAssisstant.GetTime1970().ToString();
		string sign = PublishSDKAssisstant.MD5Encrypt(token + timeStamp + VALUE_AccountLoginMD5.Value);
		string result = PublishSDKAssisstant.GetURLResult(PublishSDKAssisstant.VALUE_AccountLoginURL.Value + "?token=" + token + "&time_stamp=" + timeStamp + "&sign=" + sign);
		ViDebuger.Record("SearchAccount.Result: " + result);
		return result;
	}

}
