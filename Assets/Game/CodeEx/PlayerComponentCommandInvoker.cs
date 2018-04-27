using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViString = System.String;
using ViArrayIdx = System.Int32;
public class PlayerComponentCommandInvoker : ViEntityCommandInvoker<PlayerComponent>
{
	public static void Start()
	{
		ViEntityCommandInvoker.Register(Exec);
		AddFunc("/MessageBox", Client_0_MessageBox);
		AddFunc("/DebugMessage", Client_1_DebugMessage);
		AddFunc("/ContainReserveWord", Client_2_ContainReserveWord);
	}
	public static new bool Exec(PlayerComponent entity, string name, List<string> paramList)
	{
		return ViEntityCommandInvoker<PlayerComponent>.Exec(entity, name, paramList);
	}
	public static bool Exec( ViEntity entity, string name, List<string> paramList)
	{
		PlayerComponent deriveEntity = entity as PlayerComponent;
		if (deriveEntity == null) { return false; };
		return Exec(deriveEntity, name, paramList);
	}
	static bool Client_0_MessageBox(PlayerComponent entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Title = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Title) == false) { return false; }
		ViString Content = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Content) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.MessageBox(Title, Content);
		return true;
	}
	static bool Client_1_DebugMessage(PlayerComponent entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString Title = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Title) == false) { return false; }
		ViString Content = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out Content) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.DebugMessage(Title, Content);
		return true;
	}
	static bool Client_2_ContainReserveWord(PlayerComponent entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		ViString OrgValue = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out OrgValue) == false) { return false; }
		ViString FmtValue = default(ViString); if (ViGameSerializer<ViString>.Read(IS, out FmtValue) == false) { return false; }
		if (IS.RemainLength != 0) { return false; }
		entity.ContainReserveWord(OrgValue, FmtValue);
		return true;
	}
}
