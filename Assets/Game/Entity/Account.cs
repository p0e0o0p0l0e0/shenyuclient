using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;

using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViEntityTypeID = System.Byte;
using ViString = System.String;
using ViArrayIdx = System.Int32;
using System.Text;
using UnityEngine;
//
//
public class Account : ViRPCEntity, ViEntity
{
	public static Account Instance { get { return _instance; } }
	static Account _instance;
	//
	public ViRPCInvoker RPC { get { return _RPC; } }
	ViRPCInvoker _RPC = new ViRPCInvoker();
	public string Name { get { return "Account"; } }
	public ViEntityID ID { get { return _ID; } }
	public UInt32 PackID { get { return _PackID; } }
	public ViEntityTypeID Type { get { return (ViEntityTypeID)(ID >> 56); } }
	public bool IsLocal { get { return _asLocal; } }
	public bool Active { get { return _active; } }
	public AccountReceiveProperty Property { get { ViDebuger.AssertError(_property); return _property; } }
	public void Enable(ViEntityID ID, UInt32 PackID, bool asLocal)
	{
		_ID = ID;
		_PackID = PackID;
		_asLocal = asLocal;
	}
	public void SetActive(bool value)
	{
		_active = value;
	}
	public void PreStart(){}
	public void Start()
	{
		_instance = this;
	}
	public void AftStart(){}
	public void ClearCallback(){}
	public void PreEnd()
	{
		_instance = null;
	}
	public void End(){}
	public void AftEnd(){}
	public void Tick(float fDeltaTime){}
	public void StartProperty(UInt16 channelMask, ViIStream IS)
	{
		_property = ViReceiveDataCache<AccountReceiveProperty>.Alloc();
		_property.StartProperty(channelMask, IS, this);
	}
	public void EndProperty()
	{
		_property.EndProperty(this);
	}
	public void ClearProperty()
	{
		ViReceiveDataCache<AccountReceiveProperty>.Free(_property);
		_property = null;
	}
	public void OnPropertyUpdateStart(UInt8 channel){}
	public void OnPropertyUpdateEnd(UInt8 channel){}
	public void OnPropertyUpdate(UInt8 channel, ViIStream IS)
	{
		_property.OnPropertyUpdate(channel, IS, this);
	}
	public void OnCreateStart(UInt8 gender)
	{
        UIRoleDataManager.GetInstance.SetCreatTag(true);
        UIManager.Instance.Show(UIControllerDefine.WIN_Role, (()=> { UIManagerUtility.HideLoading(); }));
	}
    public void CreateRole(string name,UInt8 id, UInt8 gender,UInt8 hair,UInt8 face)
    {
        CreateRoleProperty propperty = new CreateRoleProperty();
        propperty.NameAlias = name;
        propperty.PlayerInitConfigID = id;
        propperty.Gender = gender;
        propperty.HairType = hair;
        propperty.FaceType = face;
        AccountServerInvoker.CreateRole(this, propperty);
        AccountServerInvoker.ResetClientSetting(this, ClientDevicePlatformAssisstent.GetDeviceProperty());
    }
    public void OnSelectStart()
	{
        UIManager.Instance.Show(UIControllerDefine.WIN_CreateRole, () => { UIManagerUtility.HideLoading(); });
    }

	public void OnRoleName(ViString name)
    { 
        UIRoleCreateController roleController = UIManagerUtility.GetRoleCreateController();
        if (roleController != null && roleController.IsShow)
            roleController.OnRandName(name);

    }

	public void OnCreateResult(UInt8 result)
	{
        UIRoleCreateController roleController = UIManagerUtility.GetRoleCreateController();
        if (roleController != null && roleController.IsShow)
            roleController.OnRoleCreate(result);
    }

	public void OnIndulgeWarning(Int32 reserveTime)
	{

	}

	public void OnPreventIndulgeResult(UInt8 error)
	{

	}

	public void ResponseTime(ViRPCCallback<Int64> result)
	{
		result.Invoke(this, ViRPCSide.CENTER, 1);
	}

	public void UpdateLoginContent(ViString content)
	{
		Client.Current.SetLoginContent(content);
	}

	public void OnUpdateVisualLoading(UInt32 visualLoading)
	{

	}
    public void OnLogoutPlayer()
    {

    }

    public void MessageBox(ViString title, ViString content)
	{
		//ViewControllerManager.PrintMSGView.SetMessage(content);
	}

	public void DebugMessage(ViString title, ViString content)
	{
		EntityMessageController.OnDebugMessage(title, content);
	}

	public void ContainReserveWord(ViString orgValue, ViString fmtValue)
	{
		//ViewControllerManager.PrintMSGView.SetMessage("包含禁用词汇(" + orgValue + "->" + fmtValue + ")");
	}

	public void HTTPRequest(string value)
	{
		ViDebuger.CritOK("Account.HTTPRequest(" + value + ")");
		System.Net.WebRequest webReq = System.Net.WebRequest.Create(value);
		webReq.BeginGetResponse(this.OnHTTPRequestResponse, webReq);
	}

	void OnHTTPRequestResponse(IAsyncResult result)
	{
		WebRequest request = (WebRequest)result.AsyncState;
		WebResponse response = request.EndGetResponse(result);
		System.IO.Stream respStream = response.GetResponseStream();
		string resultValue = string.Empty;
		if (respStream != null)
		{
			using (System.IO.StreamReader reader = new System.IO.StreamReader(respStream, Encoding.UTF8))
			{
				resultValue = reader.ReadToEnd();
			}
		}
	}

	ViEntityID _ID;
	UInt32 _PackID;
	bool _active;
	bool _asLocal;
	AccountReceiveProperty _property;
}
