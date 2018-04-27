using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViString = System.String;
using ViArrayIdx = System.Int32;
public class AccountClientExecer : ViRPCExecer
{
	public static AccountClientExecer Create() { return new AccountClientExecer(); }
	public override ViEntityID ID() { ViDebuger.AssertError(_entity); return _entity.ID; }
	public override ViRPCEntity Entity { get { return _entity; } }
	protected void SetEntity(Account entity)
	{
		_entity = entity;
	}
	public override void Start(ViEntityID ID, UInt32 PackID, bool asLocal, ViEntityManager entityManager, UInt16 channelMask, ViIStream IS)
	{
		_entity = new Account();
		SetEntity(_entity);
		_entity.Enable(ID, PackID, asLocal);
		_entity.StartProperty(channelMask, IS);
		entityManager.AddEntity(ID, PackID, _entity);
		_entity.SetActive(true);
	}
	public override void OnPropertyUpdateStart(UInt8 channel)
	{
		ViDebuger.AssertError(_entity);
		_entity.OnPropertyUpdateStart(channel);
	}
	public override void OnPropertyUpdate(UInt8 channel, ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		_entity.OnPropertyUpdate(channel, IS);
	}
	public override void OnPropertyUpdateEnd(UInt8 channel)
	{
		ViDebuger.AssertError(_entity);
		_entity.OnPropertyUpdateEnd(channel);
	}
	public override void End(ViEntityManager entityManager)
	{
		ViDebuger.AssertError(_entity);
		_entity.SetActive(false);
		_entity.EndProperty();
		entityManager.DelEntity(_entity);
		_entity.ClearProperty();
		_entity = null;
	}
	public override void OnMessage(UInt16 funcIdx, ViIStream IS)
	{
		switch((AccountClientMethod)funcIdx)
		{
			case AccountClientMethod.METHOD_0_OnCreateStart: 
				_0_OnCreateStart(IS);
				break;
			case AccountClientMethod.METHOD_1_OnSelectStart: 
				_1_OnSelectStart(IS);
				break;
			case AccountClientMethod.METHOD_2_OnRoleName: 
				_2_OnRoleName(IS);
				break;
			case AccountClientMethod.METHOD_3_OnCreateResult: 
				_3_OnCreateResult(IS);
				break;
			case AccountClientMethod.METHOD_4_OnIndulgeWarning: 
				_4_OnIndulgeWarning(IS);
				break;
			case AccountClientMethod.METHOD_5_OnPreventIndulgeResult: 
				_5_OnPreventIndulgeResult(IS);
				break;
			case AccountClientMethod.METHOD_6_ResponseTime: 
				_6_ResponseTime(IS);
				break;
			case AccountClientMethod.METHOD_7_UpdateLoginContent: 
				_7_UpdateLoginContent(IS);
				break;
			case AccountClientMethod.METHOD_8_OnUpdateVisualLoading: 
				_8_OnUpdateVisualLoading(IS);
				break;
			case AccountClientMethod.METHOD_9_MessageBox: 
				_9_MessageBox(IS);
				break;
			case AccountClientMethod.METHOD_10_DebugMessage: 
				_10_DebugMessage(IS);
				break;
			case AccountClientMethod.METHOD_11_ContainReserveWord: 
				_11_ContainReserveWord(IS);
				break;
			case AccountClientMethod.METHOD_12_HTTPRequest: 
				_12_HTTPRequest(IS);
				break;
			case AccountClientMethod.METHOD_13_OnLogoutPlayer: 
				_13_OnLogoutPlayer(IS);
				break;
			default:
				base.OnMessage(funcIdx, IS);
				break;
		}
	}
	void _0_OnCreateStart(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		UInt8 Gender;
		ViGameSerializer<UInt8>.Read(IS, out Gender);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnCreateStart(" + ", " + Gender + ")");
		}
		_entity.OnCreateStart(Gender);
	}

	void _1_OnSelectStart(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnSelectStart(" + ")");
		}
		_entity.OnSelectStart();
	}

	void _2_OnRoleName(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		ViString Name;
		ViGameSerializer<ViString>.Read(IS, out Name);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnRoleName(" + ", " + Name + ")");
		}
		_entity.OnRoleName(Name);
	}

	void _3_OnCreateResult(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		UInt8 Result;
		ViGameSerializer<UInt8>.Read(IS, out Result);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnCreateResult(" + ", " + Result + ")");
		}
		_entity.OnCreateResult(Result);
	}

	void _4_OnIndulgeWarning(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		Int32 ReserveTime;
		ViGameSerializer<Int32>.Read(IS, out ReserveTime);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnIndulgeWarning(" + ", " + ReserveTime + ")");
		}
		_entity.OnIndulgeWarning(ReserveTime);
	}

	void _5_OnPreventIndulgeResult(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		UInt8 Error;
		ViGameSerializer<UInt8>.Read(IS, out Error);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnPreventIndulgeResult(" + ", " + Error + ")");
		}
		_entity.OnPreventIndulgeResult(Error);
	}

	void _6_ResponseTime(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		ViRPCCallback<Int64> Result;
		ViRPCCallbackSerializer.Read(IS, out Result);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].ResponseTime(" + ", " + Result + ")");
		}
		_entity.ResponseTime(Result);
	}

	void _7_UpdateLoginContent(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		ViString Content;
		ViGameSerializer<ViString>.Read(IS, out Content);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].UpdateLoginContent(" + ", " + Content + ")");
		}
		_entity.UpdateLoginContent(Content);
	}

	void _8_OnUpdateVisualLoading(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		UInt32 VisualLoading;
		ViGameSerializer<UInt32>.Read(IS, out VisualLoading);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnUpdateVisualLoading(" + ", " + VisualLoading + ")");
		}
		_entity.OnUpdateVisualLoading(VisualLoading);
	}

	void _9_MessageBox(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		ViString Title;
		ViGameSerializer<ViString>.Read(IS, out Title);
		ViString Content;
		ViGameSerializer<ViString>.Read(IS, out Content);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].MessageBox(" + ", " + Title + ", " + Content + ")");
		}
		_entity.MessageBox(Title, Content);
	}

	void _10_DebugMessage(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		ViString Title;
		ViGameSerializer<ViString>.Read(IS, out Title);
		ViString Content;
		ViGameSerializer<ViString>.Read(IS, out Content);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].DebugMessage(" + ", " + Title + ", " + Content + ")");
		}
		_entity.DebugMessage(Title, Content);
	}

	void _11_ContainReserveWord(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		ViString OrgValue;
		ViGameSerializer<ViString>.Read(IS, out OrgValue);
		ViString FmtValue;
		ViGameSerializer<ViString>.Read(IS, out FmtValue);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].ContainReserveWord(" + ", " + OrgValue + ", " + FmtValue + ")");
		}
		_entity.ContainReserveWord(OrgValue, FmtValue);
	}

	void _12_HTTPRequest(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		ViString Value;
		ViGameSerializer<ViString>.Read(IS, out Value);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].HTTPRequest(" + ", " + Value + ")");
		}
		_entity.HTTPRequest(Value);
	}

	void _13_OnLogoutPlayer(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnLogoutPlayer(" + ")");
		}
		_entity.OnLogoutPlayer();
	}

	protected Account _entity;
}
