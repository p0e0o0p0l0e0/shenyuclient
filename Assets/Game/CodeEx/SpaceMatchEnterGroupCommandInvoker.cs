using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViString = System.String;
using ViArrayIdx = System.Int32;
public class SpaceMatchEnterGroupCommandInvoker : ViEntityCommandInvoker<SpaceMatchEnterGroup>
{
	public static void Start()
	{
		ViEntityCommandInvoker.Register(Exec);
		AddFunc("/OnReadyAll", Client_0_OnReadyAll);
		AddFunc("/OnDisReady", Client_1_OnDisReady);
	}
	public static new bool Exec(SpaceMatchEnterGroup entity, string name, List<string> paramList)
	{
		return ViEntityCommandInvoker<SpaceMatchEnterGroup>.Exec(entity, name, paramList);
	}
	public static bool Exec( ViEntity entity, string name, List<string> paramList)
	{
		SpaceMatchEnterGroup deriveEntity = entity as SpaceMatchEnterGroup;
		if (deriveEntity == null) { return false; };
		return Exec(deriveEntity, name, paramList);
	}
	static bool Client_0_OnReadyAll(SpaceMatchEnterGroup entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		entity.OnReadyAll();
		return true;
	}
	static bool Client_1_OnDisReady(SpaceMatchEnterGroup entity, List<string> paramList)
	{
		ViStringIStream IS = new ViStringIStream();
		IS.Init(paramList);
		if (IS.RemainLength != 0) { return false; }
		entity.OnDisReady();
		return true;
	}
}
