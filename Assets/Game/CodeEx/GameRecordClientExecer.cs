using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViString = System.String;
using ViArrayIdx = System.Int32;
public class GameRecordClientExecer : ViRPCExecer
{
	public static GameRecordClientExecer Create() { return new GameRecordClientExecer(); }
	public override ViEntityID ID() { ViDebuger.AssertError(_entity); return _entity.ID; }
	public override ViRPCEntity Entity { get { return _entity; } }
	protected void SetEntity(GameRecord entity)
	{
		_entity = entity;
	}
	public override void Start(ViEntityID ID, UInt32 PackID, bool asLocal, ViEntityManager entityManager, UInt16 channelMask, ViIStream IS)
	{
		_entity = new GameRecord();
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
		switch((GameRecordClientMethod)funcIdx)
		{
			case GameRecordClientMethod.METHOD_0_OnTimeScaleUpdated: 
				_0_OnTimeScaleUpdated(IS);
				break;
			case GameRecordClientMethod.METHOD_1_OnTimeBoard: 
				_1_OnTimeBoard(IS);
				break;
			case GameRecordClientMethod.METHOD_2_OnLoot: 
				_2_OnLoot(IS);
				break;
			case GameRecordClientMethod.METHOD_3_OnNote: 
				_3_OnNote(IS);
				break;
			case GameRecordClientMethod.METHOD_4_DebugMessage: 
				_4_DebugMessage(IS);
				break;
			case GameRecordClientMethod.METHOD_5_SetConstBool: 
				_5_SetConstBool(IS);
				break;
			case GameRecordClientMethod.METHOD_6_SetConstBools: 
				_6_SetConstBools(IS);
				break;
			case GameRecordClientMethod.METHOD_7_SetConstInt: 
				_7_SetConstInt(IS);
				break;
			case GameRecordClientMethod.METHOD_8_SetConstInts: 
				_8_SetConstInts(IS);
				break;
			case GameRecordClientMethod.METHOD_9_SetConstFloat: 
				_9_SetConstFloat(IS);
				break;
			case GameRecordClientMethod.METHOD_10_SetConstFloats: 
				_10_SetConstFloats(IS);
				break;
			case GameRecordClientMethod.METHOD_11_SetConstString: 
				_11_SetConstString(IS);
				break;
			case GameRecordClientMethod.METHOD_12_SetConstStrings: 
				_12_SetConstStrings(IS);
				break;
			case GameRecordClientMethod.METHOD_13_SetConstVector3: 
				_13_SetConstVector3(IS);
				break;
			case GameRecordClientMethod.METHOD_14_SetConstVector3s: 
				_14_SetConstVector3s(IS);
				break;
			default:
				base.OnMessage(funcIdx, IS);
				break;
		}
	}
	void _0_OnTimeScaleUpdated(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		float Value;
		ViGameSerializer<float>.Read(IS, out Value);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnTimeScaleUpdated(" + ", " + Value + ")");
		}
		_entity.OnTimeScaleUpdated(Value);
	}

	void _1_OnTimeBoard(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		UInt8 Type;
		ViGameSerializer<UInt8>.Read(IS, out Type);
		ViString Content;
		ViGameSerializer<ViString>.Read(IS, out Content);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnTimeBoard(" + ", " + Type + ", " + Content + ")");
		}
		_entity.OnTimeBoard(Type, Content);
	}

	void _2_OnLoot(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		PlayerIdentificationProperty Player;
		ViGameSerializer<PlayerIdentificationProperty>.Read(IS, out Player);
		Int32 Loot;
		ViGameSerializer<Int32>.Read(IS, out Loot);
		List<ItemCountProperty> ItemList;
		ViGameSerializer<ItemCountProperty>.Read(IS, out ItemList);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnLoot(" + ", " + Player + ", " + Loot + ", " + ItemList + ")");
		}
		_entity.OnLoot(Player, Loot, ItemList);
	}

	void _3_OnNote(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		ViString Note;
		ViGameSerializer<ViString>.Read(IS, out Note);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].OnNote(" + ", " + Note + ")");
		}
		_entity.OnNote(Note);
	}

	void _4_DebugMessage(ViIStream IS)
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

	void _5_SetConstBool(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		ViString Name;
		ViGameSerializer<ViString>.Read(IS, out Name);
		UInt8 Value;
		ViGameSerializer<UInt8>.Read(IS, out Value);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].SetConstBool(" + ", " + Name + ", " + Value + ")");
		}
		_entity.SetConstBool(Name, Value);
	}

	void _6_SetConstBools(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		ViString Name;
		ViGameSerializer<ViString>.Read(IS, out Name);
		List<UInt8> Value;
		ViGameSerializer<UInt8>.Read(IS, out Value);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].SetConstBools(" + ", " + Name + ", " + Value + ")");
		}
		_entity.SetConstBools(Name, Value);
	}

	void _7_SetConstInt(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		ViString Name;
		ViGameSerializer<ViString>.Read(IS, out Name);
		Int32 Value;
		ViGameSerializer<Int32>.Read(IS, out Value);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].SetConstInt(" + ", " + Name + ", " + Value + ")");
		}
		_entity.SetConstInt(Name, Value);
	}

	void _8_SetConstInts(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		ViString Name;
		ViGameSerializer<ViString>.Read(IS, out Name);
		List<Int32> Value;
		ViGameSerializer<Int32>.Read(IS, out Value);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].SetConstInts(" + ", " + Name + ", " + Value + ")");
		}
		_entity.SetConstInts(Name, Value);
	}

	void _9_SetConstFloat(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		ViString Name;
		ViGameSerializer<ViString>.Read(IS, out Name);
		float Value;
		ViGameSerializer<float>.Read(IS, out Value);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].SetConstFloat(" + ", " + Name + ", " + Value + ")");
		}
		_entity.SetConstFloat(Name, Value);
	}

	void _10_SetConstFloats(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		ViString Name;
		ViGameSerializer<ViString>.Read(IS, out Name);
		List<float> Value;
		ViGameSerializer<float>.Read(IS, out Value);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].SetConstFloats(" + ", " + Name + ", " + Value + ")");
		}
		_entity.SetConstFloats(Name, Value);
	}

	void _11_SetConstString(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		ViString Name;
		ViGameSerializer<ViString>.Read(IS, out Name);
		ViString Value;
		ViGameSerializer<ViString>.Read(IS, out Value);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].SetConstString(" + ", " + Name + ", " + Value + ")");
		}
		_entity.SetConstString(Name, Value);
	}

	void _12_SetConstStrings(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		ViString Name;
		ViGameSerializer<ViString>.Read(IS, out Name);
		List<ViString> Value;
		ViGameSerializer<ViString>.Read(IS, out Value);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].SetConstStrings(" + ", " + Name + ", " + Value + ")");
		}
		_entity.SetConstStrings(Name, Value);
	}

	void _13_SetConstVector3(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		ViString Name;
		ViGameSerializer<ViString>.Read(IS, out Name);
		ViVector3 Value;
		ViGameSerializer<ViVector3>.Read(IS, out Value);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].SetConstVector3(" + ", " + Name + ", " + Value + ")");
		}
		_entity.SetConstVector3(Name, Value);
	}

	void _14_SetConstVector3s(ViIStream IS)
	{
		ViDebuger.AssertError(_entity);
		ViString Name;
		ViGameSerializer<ViString>.Read(IS, out Name);
		List<ViVector3> Value;
		ViGameSerializer<ViVector3>.Read(IS, out Value);
		if(ViDebuger.LogLevel == ViLogLevel.OK)
		{
			ViDebuger.Note("Execer >> [" + _entity.ID +"].SetConstVector3s(" + ", " + Name + ", " + Value + ")");
		}
		_entity.SetConstVector3s(Name, Value);
	}

	protected GameRecord _entity;
}
