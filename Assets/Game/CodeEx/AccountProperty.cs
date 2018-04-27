using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViString = System.String;
using ViArrayIdx = System.Int32;
public class AccountProperty
{
	public static readonly int TYPE_SIZE = 59;
	public static readonly int INDEX_PROPERTY_COUNT = 0;
	//
	public UInt64 DataVersion;//DB
	public Int16 MergeCount;//DB
	public UInt64 OnlineVersion;//DB
	public EntityServerProperty Server;//OWN_CLIENT+DB
	public ViString SourceTag;//DB
	public ViString SourceDate;//DB
	public ViString CDKey;//DB
	public ViString CDKeyTag;//DB
	public ViString ProtoName;//OWN_CLIENT+DB
	public ViString PassWord;//DB
	public UInt16 LastSelectRole;//OWN_CLIENT+DB
	public Int32 DayRoleCreatedCount;//OWN_CLIENT+DB
	public UInt16PtrProperty AutoSelectRole;//DB
	public List<AccountRoleProperty> PlayerList;//OWN_CLIENT+DB
	public List<AccountRoleProperty> DestroyedPlayerList;//OWN_CLIENT+DB
	public ViString IP;//DB
	public ViString MacAdress;//DB
	public List<ClientDeviceProperty> ClientDeviceList;//DB
	public UInt8 GMLevel;//OWN_CLIENT+DB
	public Int64 ActiveTime;//OWN_CLIENT
	public Int64 CreateTime;//OWN_CLIENT+DB
	public Int64 CreateTime1970;//OWN_CLIENT+DB
	public Int64 LoginTime;//OWN_CLIENT+DB
	public Int64 LastOnlineTime1970;//OWN_CLIENT+DB
	public Int64 AccumulateOnlineDuration;//OWN_CLIENT+DB
	public Int32 CreateDayNumber1970;//DB
	public Int32 CurrentDayNumber1970;//DB
	public ClientSettingForAccountProperty ClientSetting;//OWN_CLIENT+DB
	public Dictionary<UInt32, KeyboardValueProperty> KeyboardValueList;//OWN_CLIENT+DB
	public Int64 JinZi;//OWN_CLIENT+DB
	public Int64 RechargeValue;//OWN_CLIENT+DB
	public Int32 RechargeCount;//OWN_CLIENT+DB
	public Dictionary<ViString, RechargeExecProperty> RechargeList;//DB
	public StringPtrProperty ShenFenZhengName;//OWN_CLIENT
	public StringPtrProperty ShenFenZhengID;//OWN_CLIENT
	public StringPtrProperty MobilePhoneNumber;//OWN_CLIENT
	public StringPtrProperty BankNumber;//OWN_CLIENT
	public ViString MobilePhoneDynamicPassword;//DB
	public Int64 MobilePhoneDynamicPasswordEndTime;//OWN_CLIENT+DB
	public Int16 MobilePhoneDynamicPasswordTakeCount;//OWN_CLIENT+DB
	public Int64 GameNoteReadTime1970;//OWN_CLIENT+DB
	public void Read(ViIStream IS)
	{
		ViGameSerializer<UInt64>.Read(IS, out DataVersion);
		ViGameSerializer<Int16>.Read(IS, out MergeCount);
		ViGameSerializer<UInt64>.Read(IS, out OnlineVersion);
		ViGameSerializer<EntityServerProperty>.Read(IS, out Server);
		ViGameSerializer<ViString>.Read(IS, out SourceTag);
		ViGameSerializer<ViString>.Read(IS, out SourceDate);
		ViGameSerializer<ViString>.Read(IS, out CDKey);
		ViGameSerializer<ViString>.Read(IS, out CDKeyTag);
		ViGameSerializer<ViString>.Read(IS, out ProtoName);
		ViGameSerializer<ViString>.Read(IS, out PassWord);
		ViGameSerializer<UInt16>.Read(IS, out LastSelectRole);
		ViGameSerializer<Int32>.Read(IS, out DayRoleCreatedCount);
		ViGameSerializer<UInt16PtrProperty>.Read(IS, out AutoSelectRole);
		ViGameSerializer<AccountRoleProperty>.Read(IS, out PlayerList);
		ViGameSerializer<AccountRoleProperty>.Read(IS, out DestroyedPlayerList);
		ViGameSerializer<ViString>.Read(IS, out IP);
		ViGameSerializer<ViString>.Read(IS, out MacAdress);
		ViGameSerializer<ClientDeviceProperty>.Read(IS, out ClientDeviceList);
		ViGameSerializer<UInt8>.Read(IS, out GMLevel);
		ViGameSerializer<Int64>.Read(IS, out ActiveTime);
		ViGameSerializer<Int64>.Read(IS, out CreateTime);
		ViGameSerializer<Int64>.Read(IS, out CreateTime1970);
		ViGameSerializer<Int64>.Read(IS, out LoginTime);
		ViGameSerializer<Int64>.Read(IS, out LastOnlineTime1970);
		ViGameSerializer<Int64>.Read(IS, out AccumulateOnlineDuration);
		ViGameSerializer<Int32>.Read(IS, out CreateDayNumber1970);
		ViGameSerializer<Int32>.Read(IS, out CurrentDayNumber1970);
		ViGameSerializer<ClientSettingForAccountProperty>.Read(IS, out ClientSetting);
		ViGameSerializer<KeyboardValueProperty>.Read(IS, out KeyboardValueList);
		ViGameSerializer<Int64>.Read(IS, out JinZi);
		ViGameSerializer<Int64>.Read(IS, out RechargeValue);
		ViGameSerializer<Int32>.Read(IS, out RechargeCount);
		ViGameSerializer<RechargeExecProperty>.Read(IS, out RechargeList);
		ViGameSerializer<StringPtrProperty>.Read(IS, out ShenFenZhengName);
		ViGameSerializer<StringPtrProperty>.Read(IS, out ShenFenZhengID);
		ViGameSerializer<StringPtrProperty>.Read(IS, out MobilePhoneNumber);
		ViGameSerializer<StringPtrProperty>.Read(IS, out BankNumber);
		ViGameSerializer<ViString>.Read(IS, out MobilePhoneDynamicPassword);
		ViGameSerializer<Int64>.Read(IS, out MobilePhoneDynamicPasswordEndTime);
		ViGameSerializer<Int16>.Read(IS, out MobilePhoneDynamicPasswordTakeCount);
		ViGameSerializer<Int64>.Read(IS, out GameNoteReadTime1970);
	}
	public void Print(string head, ViStringDictionaryStream OS)
	{
		ViGameSerializer<UInt64>.Append(OS, head + "DataVersion", DataVersion);
		ViGameSerializer<Int16>.Append(OS, head + "MergeCount", MergeCount);
		ViGameSerializer<UInt64>.Append(OS, head + "OnlineVersion", OnlineVersion);
		ViGameSerializer<EntityServerProperty>.Append(OS, head + "Server", Server);
		ViGameSerializer<ViString>.Append(OS, head + "SourceTag", SourceTag);
		ViGameSerializer<ViString>.Append(OS, head + "SourceDate", SourceDate);
		ViGameSerializer<ViString>.Append(OS, head + "CDKey", CDKey);
		ViGameSerializer<ViString>.Append(OS, head + "CDKeyTag", CDKeyTag);
		ViGameSerializer<ViString>.Append(OS, head + "ProtoName", ProtoName);
		ViGameSerializer<ViString>.Append(OS, head + "PassWord", PassWord);
		ViGameSerializer<UInt16>.Append(OS, head + "LastSelectRole", LastSelectRole);
		ViGameSerializer<Int32>.Append(OS, head + "DayRoleCreatedCount", DayRoleCreatedCount);
		ViGameSerializer<UInt16PtrProperty>.Append(OS, head + "AutoSelectRole", AutoSelectRole);
		ViGameSerializer<AccountRoleProperty>.Append(OS, head + "PlayerList", PlayerList);
		ViGameSerializer<AccountRoleProperty>.Append(OS, head + "DestroyedPlayerList", DestroyedPlayerList);
		ViGameSerializer<ViString>.Append(OS, head + "IP", IP);
		ViGameSerializer<ViString>.Append(OS, head + "MacAdress", MacAdress);
		ViGameSerializer<ClientDeviceProperty>.Append(OS, head + "ClientDeviceList", ClientDeviceList);
		ViGameSerializer<UInt8>.Append(OS, head + "GMLevel", GMLevel);
		ViGameSerializer<Int64>.Append(OS, head + "ActiveTime", ActiveTime);
		ViGameSerializer<Int64>.Append(OS, head + "CreateTime", CreateTime);
		ViGameSerializer<Int64>.Append(OS, head + "CreateTime1970", CreateTime1970);
		ViGameSerializer<Int64>.Append(OS, head + "LoginTime", LoginTime);
		ViGameSerializer<Int64>.Append(OS, head + "LastOnlineTime1970", LastOnlineTime1970);
		ViGameSerializer<Int64>.Append(OS, head + "AccumulateOnlineDuration", AccumulateOnlineDuration);
		ViGameSerializer<Int32>.Append(OS, head + "CreateDayNumber1970", CreateDayNumber1970);
		ViGameSerializer<Int32>.Append(OS, head + "CurrentDayNumber1970", CurrentDayNumber1970);
		ViGameSerializer<ClientSettingForAccountProperty>.Append(OS, head + "ClientSetting", ClientSetting);
		ViGameSerializer<KeyboardValueProperty>.Append(OS, head + "KeyboardValueList", KeyboardValueList);
		ViGameSerializer<Int64>.Append(OS, head + "JinZi", JinZi);
		ViGameSerializer<Int64>.Append(OS, head + "RechargeValue", RechargeValue);
		ViGameSerializer<Int32>.Append(OS, head + "RechargeCount", RechargeCount);
		ViGameSerializer<RechargeExecProperty>.Append(OS, head + "RechargeList", RechargeList);
		ViGameSerializer<StringPtrProperty>.Append(OS, head + "ShenFenZhengName", ShenFenZhengName);
		ViGameSerializer<StringPtrProperty>.Append(OS, head + "ShenFenZhengID", ShenFenZhengID);
		ViGameSerializer<StringPtrProperty>.Append(OS, head + "MobilePhoneNumber", MobilePhoneNumber);
		ViGameSerializer<StringPtrProperty>.Append(OS, head + "BankNumber", BankNumber);
		ViGameSerializer<ViString>.Append(OS, head + "MobilePhoneDynamicPassword", MobilePhoneDynamicPassword);
		ViGameSerializer<Int64>.Append(OS, head + "MobilePhoneDynamicPasswordEndTime", MobilePhoneDynamicPasswordEndTime);
		ViGameSerializer<Int16>.Append(OS, head + "MobilePhoneDynamicPasswordTakeCount", MobilePhoneDynamicPasswordTakeCount);
		ViGameSerializer<Int64>.Append(OS, head + "GameNoteReadTime1970", GameNoteReadTime1970);
	}
}

public class AccountReceiveProperty : ViReceiveProperty
{
	public static readonly new int TYPE_SIZE = 59;
	public static readonly new int INDEX_PROPERTY_COUNT = 0;
	//
	private ViReceiveDataUInt64 DataVersion = new ViReceiveDataUInt64();//DB
	private ViReceiveDataInt16 MergeCount = new ViReceiveDataInt16();//DB
	private ViReceiveDataUInt64 OnlineVersion = new ViReceiveDataUInt64();//DB
	public ReceiveDataEntityServerProperty Server = new ReceiveDataEntityServerProperty();//OWN_CLIENT+DB
	private ViReceiveDataString SourceTag = new ViReceiveDataString();//DB
	private ViReceiveDataString SourceDate = new ViReceiveDataString();//DB
	private ViReceiveDataString CDKey = new ViReceiveDataString();//DB
	private ViReceiveDataString CDKeyTag = new ViReceiveDataString();//DB
	public ViReceiveDataString ProtoName = new ViReceiveDataString();//OWN_CLIENT+DB
	private ViReceiveDataString PassWord = new ViReceiveDataString();//DB
	public ViReceiveDataUInt16 LastSelectRole = new ViReceiveDataUInt16();//OWN_CLIENT+DB
	public ViReceiveDataInt32 DayRoleCreatedCount = new ViReceiveDataInt32();//OWN_CLIENT+DB
	private ReceiveDataUInt16PtrProperty AutoSelectRole = new ReceiveDataUInt16PtrProperty();//DB
	public ViReceiveDataArray<ReceiveDataAccountRoleProperty, AccountRoleProperty> PlayerList = new ViReceiveDataArray<ReceiveDataAccountRoleProperty, AccountRoleProperty>();//OWN_CLIENT+DB
	public ViReceiveDataArray<ReceiveDataAccountRoleProperty, AccountRoleProperty> DestroyedPlayerList = new ViReceiveDataArray<ReceiveDataAccountRoleProperty, AccountRoleProperty>();//OWN_CLIENT+DB
	private ViReceiveDataString IP = new ViReceiveDataString();//DB
	private ViReceiveDataString MacAdress = new ViReceiveDataString();//DB
	private ViReceiveDataArray<ReceiveDataClientDeviceProperty, ClientDeviceProperty> ClientDeviceList = new ViReceiveDataArray<ReceiveDataClientDeviceProperty, ClientDeviceProperty>();//DB
	public ViReceiveDataUInt8 GMLevel = new ViReceiveDataUInt8();//OWN_CLIENT+DB
	public ViReceiveDataInt64 ActiveTime = new ViReceiveDataInt64();//OWN_CLIENT
	public ViReceiveDataInt64 CreateTime = new ViReceiveDataInt64();//OWN_CLIENT+DB
	public ViReceiveDataInt64 CreateTime1970 = new ViReceiveDataInt64();//OWN_CLIENT+DB
	public ViReceiveDataInt64 LoginTime = new ViReceiveDataInt64();//OWN_CLIENT+DB
	public ViReceiveDataInt64 LastOnlineTime1970 = new ViReceiveDataInt64();//OWN_CLIENT+DB
	public ViReceiveDataInt64 AccumulateOnlineDuration = new ViReceiveDataInt64();//OWN_CLIENT+DB
	private ViReceiveDataInt32 CreateDayNumber1970 = new ViReceiveDataInt32();//DB
	private ViReceiveDataInt32 CurrentDayNumber1970 = new ViReceiveDataInt32();//DB
	public ReceiveDataClientSettingForAccountProperty ClientSetting = new ReceiveDataClientSettingForAccountProperty();//OWN_CLIENT+DB
	public ViReceiveDataDictionary<UInt32, ReceiveDataKeyboardValueProperty, KeyboardValueProperty> KeyboardValueList = new ViReceiveDataDictionary<UInt32, ReceiveDataKeyboardValueProperty, KeyboardValueProperty>();//OWN_CLIENT+DB
	public ViReceiveDataInt64 JinZi = new ViReceiveDataInt64();//OWN_CLIENT+DB
	public ViReceiveDataInt64 RechargeValue = new ViReceiveDataInt64();//OWN_CLIENT+DB
	public ViReceiveDataInt32 RechargeCount = new ViReceiveDataInt32();//OWN_CLIENT+DB
	private ViReceiveDataDictionary<ViString, ReceiveDataRechargeExecProperty, RechargeExecProperty> RechargeList = new ViReceiveDataDictionary<ViString, ReceiveDataRechargeExecProperty, RechargeExecProperty>();//DB
	public ReceiveDataStringPtrProperty ShenFenZhengName = new ReceiveDataStringPtrProperty();//OWN_CLIENT
	public ReceiveDataStringPtrProperty ShenFenZhengID = new ReceiveDataStringPtrProperty();//OWN_CLIENT
	public ReceiveDataStringPtrProperty MobilePhoneNumber = new ReceiveDataStringPtrProperty();//OWN_CLIENT
	public ReceiveDataStringPtrProperty BankNumber = new ReceiveDataStringPtrProperty();//OWN_CLIENT
	private ViReceiveDataString MobilePhoneDynamicPassword = new ViReceiveDataString();//DB
	public ViReceiveDataInt64 MobilePhoneDynamicPasswordEndTime = new ViReceiveDataInt64();//OWN_CLIENT+DB
	public ViReceiveDataInt16 MobilePhoneDynamicPasswordTakeCount = new ViReceiveDataInt16();//OWN_CLIENT+DB
	public ViReceiveDataInt64 GameNoteReadTime1970 = new ViReceiveDataInt64();//OWN_CLIENT+DB
	//
	public AccountReceiveProperty()
	{
		ReservePropertySize(TYPE_SIZE);
		DataVersion.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		MergeCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		OnlineVersion.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		Server.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		SourceTag.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		SourceDate.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		CDKey.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		CDKeyTag.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		ProtoName.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		PassWord.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		LastSelectRole.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		DayRoleCreatedCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		AutoSelectRole.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		PlayerList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		DestroyedPlayerList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		IP.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		MacAdress.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		ClientDeviceList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		GMLevel.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		ActiveTime.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT)), this, ChildList);
		CreateTime.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		CreateTime1970.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		LoginTime.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		LastOnlineTime1970.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		AccumulateOnlineDuration.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		CreateDayNumber1970.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		CurrentDayNumber1970.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		ClientSetting.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		KeyboardValueList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		JinZi.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		RechargeValue.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		RechargeCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		RechargeList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		ShenFenZhengName.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT)), this, ChildList);
		ShenFenZhengID.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT)), this, ChildList);
		MobilePhoneNumber.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT)), this, ChildList);
		BankNumber.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT)), this, ChildList);
		MobilePhoneDynamicPassword.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.DB)), this, ChildList);
		MobilePhoneDynamicPasswordEndTime.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		MobilePhoneDynamicPasswordTakeCount.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		GameNoteReadTime1970.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT) | (1 << (int)ProjectAChannel.DB)), this, ChildList);
		//
		ReserveIdxPropertySize(INDEX_PROPERTY_COUNT);
	}
	public override void OnPropertyUpdate(UInt8 channel, ViIStream IS, ViEntity entity)
	{
		UInt16 slot;
		IS.Read(out slot);
		OnUpdateAsContainer(slot, channel, IS, entity);
	}
	public override void StartProperty(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		base.StartProperty(channelMask, IS, entity);
		DataVersion.Start(channelMask, IS, entity);
		MergeCount.Start(channelMask, IS, entity);
		OnlineVersion.Start(channelMask, IS, entity);
		Server.Start(channelMask, IS, entity);
		SourceTag.Start(channelMask, IS, entity);
		SourceDate.Start(channelMask, IS, entity);
		CDKey.Start(channelMask, IS, entity);
		CDKeyTag.Start(channelMask, IS, entity);
		ProtoName.Start(channelMask, IS, entity);
		PassWord.Start(channelMask, IS, entity);
		LastSelectRole.Start(channelMask, IS, entity);
		DayRoleCreatedCount.Start(channelMask, IS, entity);
		AutoSelectRole.Start(channelMask, IS, entity);
		PlayerList.Start(channelMask, IS, entity);
		DestroyedPlayerList.Start(channelMask, IS, entity);
		IP.Start(channelMask, IS, entity);
		MacAdress.Start(channelMask, IS, entity);
		ClientDeviceList.Start(channelMask, IS, entity);
		GMLevel.Start(channelMask, IS, entity);
		ActiveTime.Start(channelMask, IS, entity);
		CreateTime.Start(channelMask, IS, entity);
		CreateTime1970.Start(channelMask, IS, entity);
		LoginTime.Start(channelMask, IS, entity);
		LastOnlineTime1970.Start(channelMask, IS, entity);
		AccumulateOnlineDuration.Start(channelMask, IS, entity);
		CreateDayNumber1970.Start(channelMask, IS, entity);
		CurrentDayNumber1970.Start(channelMask, IS, entity);
		ClientSetting.Start(channelMask, IS, entity);
		KeyboardValueList.Start(channelMask, IS, entity);
		JinZi.Start(channelMask, IS, entity);
		RechargeValue.Start(channelMask, IS, entity);
		RechargeCount.Start(channelMask, IS, entity);
		RechargeList.Start(channelMask, IS, entity);
		ShenFenZhengName.Start(channelMask, IS, entity);
		ShenFenZhengID.Start(channelMask, IS, entity);
		MobilePhoneNumber.Start(channelMask, IS, entity);
		BankNumber.Start(channelMask, IS, entity);
		MobilePhoneDynamicPassword.Start(channelMask, IS, entity);
		MobilePhoneDynamicPasswordEndTime.Start(channelMask, IS, entity);
		MobilePhoneDynamicPasswordTakeCount.Start(channelMask, IS, entity);
		GameNoteReadTime1970.Start(channelMask, IS, entity);
	}
	public override void EndProperty(ViEntity entity)
	{
		base.EndProperty(entity);
		DataVersion.End(entity);
		MergeCount.End(entity);
		OnlineVersion.End(entity);
		Server.End(entity);
		SourceTag.End(entity);
		SourceDate.End(entity);
		CDKey.End(entity);
		CDKeyTag.End(entity);
		ProtoName.End(entity);
		PassWord.End(entity);
		LastSelectRole.End(entity);
		DayRoleCreatedCount.End(entity);
		AutoSelectRole.End(entity);
		PlayerList.End(entity);
		DestroyedPlayerList.End(entity);
		IP.End(entity);
		MacAdress.End(entity);
		ClientDeviceList.End(entity);
		GMLevel.End(entity);
		ActiveTime.End(entity);
		CreateTime.End(entity);
		CreateTime1970.End(entity);
		LoginTime.End(entity);
		LastOnlineTime1970.End(entity);
		AccumulateOnlineDuration.End(entity);
		CreateDayNumber1970.End(entity);
		CurrentDayNumber1970.End(entity);
		ClientSetting.End(entity);
		KeyboardValueList.End(entity);
		JinZi.End(entity);
		RechargeValue.End(entity);
		RechargeCount.End(entity);
		RechargeList.End(entity);
		ShenFenZhengName.End(entity);
		ShenFenZhengID.End(entity);
		MobilePhoneNumber.End(entity);
		BankNumber.End(entity);
		MobilePhoneDynamicPassword.End(entity);
		MobilePhoneDynamicPasswordEndTime.End(entity);
		MobilePhoneDynamicPasswordTakeCount.End(entity);
		GameNoteReadTime1970.End(entity);
	}
	public override void Clear()
	{
		base.Clear();
		DataVersion.Clear();
		MergeCount.Clear();
		OnlineVersion.Clear();
		Server.Clear();
		SourceTag.Clear();
		SourceDate.Clear();
		CDKey.Clear();
		CDKeyTag.Clear();
		ProtoName.Clear();
		PassWord.Clear();
		LastSelectRole.Clear();
		DayRoleCreatedCount.Clear();
		AutoSelectRole.Clear();
		PlayerList.Clear();
		DestroyedPlayerList.Clear();
		IP.Clear();
		MacAdress.Clear();
		ClientDeviceList.Clear();
		GMLevel.Clear();
		ActiveTime.Clear();
		CreateTime.Clear();
		CreateTime1970.Clear();
		LoginTime.Clear();
		LastOnlineTime1970.Clear();
		AccumulateOnlineDuration.Clear();
		CreateDayNumber1970.Clear();
		CurrentDayNumber1970.Clear();
		ClientSetting.Clear();
		KeyboardValueList.Clear();
		JinZi.Clear();
		RechargeValue.Clear();
		RechargeCount.Clear();
		RechargeList.Clear();
		ShenFenZhengName.Clear();
		ShenFenZhengID.Clear();
		MobilePhoneNumber.Clear();
		BankNumber.Clear();
		MobilePhoneDynamicPassword.Clear();
		MobilePhoneDynamicPasswordEndTime.Clear();
		MobilePhoneDynamicPasswordTakeCount.Clear();
		GameNoteReadTime1970.Clear();
	}
}
