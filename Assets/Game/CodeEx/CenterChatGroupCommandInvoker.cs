using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViString = System.String;
using ViArrayIdx = System.Int32;
public class CenterChatGroupCommandInvoker : ViEntityCommandInvoker<CenterChatGroup>
{
	public static void Start()
	{
		ViEntityCommandInvoker.Register(Exec);
		AddFunc("/OnChatScriptBegin", Client_0_OnChatScriptBegin);
		AddFunc("/OnChatScriptShowItem", Client_1_OnChatScriptShowItem);
		AddFunc("/OnChatScriptEnd", Client_2_OnChatScriptEnd);
		AddFunc("/OnChatMessage", Client_3_OnChatMessage);
	}
	public static new bool Exec(CenterChatGroup entity, string name, List<string> paramList)
	{
		return ViEntityCommandInvoker<CenterChatGroup>.Exec(entity, name, paramList);
	}
	public static bool Exec( ViEntity entity, string name, List<string> paramList)
	{
		CenterChatGroup deriveEntity = entity as CenterChatGroup;
		if (deriveEntity == null) { return false; };
		return Exec(deriveEntity, name, paramList);
	}
	static bool Client_0_OnChatScriptBegin(CenterChatGroup entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		PlayerIdentificationProperty Name = default(PlayerIdentificationProperty); if (ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out Name) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnChatScriptBegin(Name);
		return true;
	}
	static bool Client_1_OnChatScriptShowItem(CenterChatGroup entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		UInt32 Item = default(UInt32); if (ViGameSerializer<UInt32>.Read(IS, out Item) == false) { return false; }
		UInt64 ID = default(UInt64); if (ViGameSerializer<UInt64>.Read(IS, out ID) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnChatScriptShowItem(Item, ID);
		return true;
	}
	static bool Client_2_OnChatScriptEnd(CenterChatGroup entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Script = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Script) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnChatScriptEnd(Script);
		return true;
	}
	static bool Client_3_OnChatMessage(CenterChatGroup entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		PlayerIdentificationProperty Name = default(PlayerIdentificationProperty); if (ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out Name) == false) { return false; }
		ViString Content = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Content) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.OnChatMessage(Name, Content);
		return true;
	}
}
