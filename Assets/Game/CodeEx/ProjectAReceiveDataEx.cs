using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViString = System.String;
using ViArrayIdx = System.Int32;
public class ReceiveDataUInt8Property: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 1;
	public ViReceiveDataUInt8 Value = new ViReceiveDataUInt8();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		Value.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		Value.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		Value.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		Value.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator UInt8Property(ReceiveDataUInt8Property data)
	{
		UInt8Property value = new UInt8Property();
		value.Value = data.Value;
		return value;
	}
}

public class ReceiveDataUInt16Property: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 1;
	public ViReceiveDataUInt16 Value = new ViReceiveDataUInt16();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		Value.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		Value.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		Value.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		Value.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator UInt16Property(ReceiveDataUInt16Property data)
	{
		UInt16Property value = new UInt16Property();
		value.Value = data.Value;
		return value;
	}
}

public class ReceiveDataInt32Property: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 1;
	public ViReceiveDataInt32 Value = new ViReceiveDataInt32();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		Value.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		Value.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		Value.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		Value.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator Int32Property(ReceiveDataInt32Property data)
	{
		Int32Property value = new Int32Property();
		value.Value = data.Value;
		return value;
	}
}

public class ReceiveDataUInt32Property: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 1;
	public ViReceiveDataUInt32 Value = new ViReceiveDataUInt32();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		Value.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		Value.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		Value.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		Value.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator UInt32Property(ReceiveDataUInt32Property data)
	{
		UInt32Property value = new UInt32Property();
		value.Value = data.Value;
		return value;
	}
}

public class ReceiveDataInt64Property: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 1;
	public ViReceiveDataInt64 Value = new ViReceiveDataInt64();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		Value.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		Value.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		Value.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		Value.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator Int64Property(ReceiveDataInt64Property data)
	{
		Int64Property value = new Int64Property();
		value.Value = data.Value;
		return value;
	}
}

public class ReceiveDataUInt64Property: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 1;
	public ViReceiveDataUInt64 Value = new ViReceiveDataUInt64();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		Value.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		Value.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		Value.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		Value.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator UInt64Property(ReceiveDataUInt64Property data)
	{
		UInt64Property value = new UInt64Property();
		value.Value = data.Value;
		return value;
	}
}

public class ReceiveDataStringProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 1;
	public ViReceiveDataString Value = new ViReceiveDataString();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		Value.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		Value.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		Value.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		Value.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator StringProperty(ReceiveDataStringProperty data)
	{
		StringProperty value = new StringProperty();
		value.Value = data.Value;
		return value;
	}
}

public class ReceiveDataUInt16PtrProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 1;
	public ViReceiveDataPtr<UInt16Property> Ptr = new ViReceiveDataPtr<UInt16Property>();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		Ptr.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		Ptr.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		Ptr.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		Ptr.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator UInt16PtrProperty(ReceiveDataUInt16PtrProperty data)
	{
		UInt16PtrProperty value = new UInt16PtrProperty();
		value.Ptr = data.Ptr;
		return value;
	}
}

public class ReceiveDataUInt64PtrProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 1;
	public ViReceiveDataPtr<UInt64Property> Ptr = new ViReceiveDataPtr<UInt64Property>();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		Ptr.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		Ptr.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		Ptr.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		Ptr.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator UInt64PtrProperty(ReceiveDataUInt64PtrProperty data)
	{
		UInt64PtrProperty value = new UInt64PtrProperty();
		value.Ptr = data.Ptr;
		return value;
	}
}

public class ReceiveDataStringPtrProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 1;
	public ViReceiveDataPtr<StringProperty> Ptr = new ViReceiveDataPtr<StringProperty>();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		Ptr.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		Ptr.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		Ptr.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		Ptr.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator StringPtrProperty(ReceiveDataStringPtrProperty data)
	{
		StringPtrProperty value = new StringPtrProperty();
		value.Ptr = data.Ptr;
		return value;
	}
}

public class ReceiveDataTimeProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 1;
	public ViReceiveDataInt64 Value = new ViReceiveDataInt64();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		Value.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		Value.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		Value.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		Value.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator TimeProperty(ReceiveDataTimeProperty data)
	{
		TimeProperty value = new TimeProperty();
		value.Value = data.Value;
		return value;
	}
}

public class ReceiveDataTime1970Property: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 1;
	public ViReceiveDataInt64 Value = new ViReceiveDataInt64();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		Value.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		Value.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		Value.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		Value.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator Time1970Property(ReceiveDataTime1970Property data)
	{
		Time1970Property value = new Time1970Property();
		value.Value = data.Value;
		return value;
	}
}

public class ReceiveDataLoopCountProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 2;
	public ViReceiveDataInt32 Count = new ViReceiveDataInt32();
	public ViReceiveDataInt64 AccumulateCount = new ViReceiveDataInt64();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		Count.Start(channelMask, IS, entity);
		AccumulateCount.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		Count.End(entity);
		AccumulateCount.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		Count.Clear();
		AccumulateCount.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		Count.RegisterAsChild(channelMask, this, childList);
		AccumulateCount.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator LoopCountProperty(ReceiveDataLoopCountProperty data)
	{
		LoopCountProperty value = new LoopCountProperty();
		value.Count = data.Count;
		value.AccumulateCount = data.AccumulateCount;
		return value;
	}
}

public class ReceiveDataShortCutProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 2;
	public ViReceiveDataUInt8 Type = new ViReceiveDataUInt8();
	public ViReceiveDataUInt64 Value = new ViReceiveDataUInt64();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		Type.Start(channelMask, IS, entity);
		Value.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		Type.End(entity);
		Value.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		Type.Clear();
		Value.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		Type.RegisterAsChild(channelMask, this, childList);
		Value.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator ShortCutProperty(ReceiveDataShortCutProperty data)
	{
		ShortCutProperty value = new ShortCutProperty();
		value.Type = data.Type;
		value.Value = data.Value;
		return value;
	}
}

public class ReceiveDataKeyboardValueProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 2;
	public ViReceiveDataUInt16 Value0 = new ViReceiveDataUInt16();
	public ViReceiveDataUInt16 Value1 = new ViReceiveDataUInt16();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		Value0.Start(channelMask, IS, entity);
		Value1.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		Value0.End(entity);
		Value1.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		Value0.Clear();
		Value1.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		Value0.RegisterAsChild(channelMask, this, childList);
		Value1.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator KeyboardValueProperty(ReceiveDataKeyboardValueProperty data)
	{
		KeyboardValueProperty value = new KeyboardValueProperty();
		value.Value0 = data.Value0;
		value.Value1 = data.Value1;
		return value;
	}
}

public class ReceiveDataMessageProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 2;
	public ViReceiveDataInt64 Time1970 = new ViReceiveDataInt64();
	public ViReceiveDataString Content = new ViReceiveDataString();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		Time1970.Start(channelMask, IS, entity);
		Content.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		Time1970.End(entity);
		Content.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		Time1970.Clear();
		Content.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		Time1970.RegisterAsChild(channelMask, this, childList);
		Content.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator MessageProperty(ReceiveDataMessageProperty data)
	{
		MessageProperty value = new MessageProperty();
		value.Time1970 = data.Time1970;
		value.Content = data.Content;
		return value;
	}
}

public class ReceiveDataEntityIDNameProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 2;
	public ViReceiveDataUInt64 ID = new ViReceiveDataUInt64();
	public ViReceiveDataString Name = new ViReceiveDataString();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		ID.Start(channelMask, IS, entity);
		Name.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		ID.End(entity);
		Name.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		ID.Clear();
		Name.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		ID.RegisterAsChild(channelMask, this, childList);
		Name.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator EntityIDNameProperty(ReceiveDataEntityIDNameProperty data)
	{
		EntityIDNameProperty value = new EntityIDNameProperty();
		value.ID = data.ID;
		value.Name = data.Name;
		return value;
	}
}

public class ReceiveDataPlayerIdentificationProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 4;
	public ViReceiveDataUInt64 ID = new ViReceiveDataUInt64();
	public ViReceiveDataString Name = new ViReceiveDataString();
	public ViReceiveDataString NameAlias = new ViReceiveDataString();
	public ViReceiveDataUInt8 Photo = new ViReceiveDataUInt8();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		ID.Start(channelMask, IS, entity);
		Name.Start(channelMask, IS, entity);
		NameAlias.Start(channelMask, IS, entity);
		Photo.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		ID.End(entity);
		Name.End(entity);
		NameAlias.End(entity);
		Photo.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		ID.Clear();
		Name.Clear();
		NameAlias.Clear();
		Photo.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		ID.RegisterAsChild(channelMask, this, childList);
		Name.RegisterAsChild(channelMask, this, childList);
		NameAlias.RegisterAsChild(channelMask, this, childList);
		Photo.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator PlayerIdentificationProperty(ReceiveDataPlayerIdentificationProperty data)
	{
		PlayerIdentificationProperty value = new PlayerIdentificationProperty();
		value.ID = data.ID;
		value.Name = data.Name;
		value.NameAlias = data.NameAlias;
		value.Photo = data.Photo;
		return value;
	}
}

public class ReceiveDataCountValue64Property: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 2;
	public ViReceiveDataInt64 Count = new ViReceiveDataInt64();
	public ViReceiveDataInt64 Value = new ViReceiveDataInt64();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		Count.Start(channelMask, IS, entity);
		Value.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		Count.End(entity);
		Value.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		Count.Clear();
		Value.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		Count.RegisterAsChild(channelMask, this, childList);
		Value.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator CountValue64Property(ReceiveDataCountValue64Property data)
	{
		CountValue64Property value = new CountValue64Property();
		value.Count = data.Count;
		value.Value = data.Value;
		return value;
	}
}

public class ReceiveDataStatisticsValueProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 2;
	public ViReceiveDataInt64 Count = new ViReceiveDataInt64();
	public ViReceiveDataInt64 Sum = new ViReceiveDataInt64();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		Count.Start(channelMask, IS, entity);
		Sum.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		Count.End(entity);
		Sum.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		Count.Clear();
		Sum.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		Count.RegisterAsChild(channelMask, this, childList);
		Sum.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator StatisticsValueProperty(ReceiveDataStatisticsValueProperty data)
	{
		StatisticsValueProperty value = new StatisticsValueProperty();
		value.Count = data.Count;
		value.Sum = data.Sum;
		return value;
	}
}

public class ReceiveDataProgressProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 2;
	public ViReceiveDataInt64 StartTime = new ViReceiveDataInt64();
	public ViReceiveDataInt64 EndTime = new ViReceiveDataInt64();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		StartTime.Start(channelMask, IS, entity);
		EndTime.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		StartTime.End(entity);
		EndTime.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		StartTime.Clear();
		EndTime.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		StartTime.RegisterAsChild(channelMask, this, childList);
		EndTime.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator ProgressProperty(ReceiveDataProgressProperty data)
	{
		ProgressProperty value = new ProgressProperty();
		value.StartTime = data.StartTime;
		value.EndTime = data.EndTime;
		return value;
	}
}

public class ReceiveDataAccmulateDurationProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 2;
	public ViReceiveDataInt64 StartTime = new ViReceiveDataInt64();
	public ViReceiveDataInt64 Duration = new ViReceiveDataInt64();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		StartTime.Start(channelMask, IS, entity);
		Duration.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		StartTime.End(entity);
		Duration.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		StartTime.Clear();
		Duration.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		StartTime.RegisterAsChild(channelMask, this, childList);
		Duration.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator AccmulateDurationProperty(ReceiveDataAccmulateDurationProperty data)
	{
		AccmulateDurationProperty value = new AccmulateDurationProperty();
		value.StartTime = data.StartTime;
		value.Duration = data.Duration;
		return value;
	}
}

public class ReceiveDataChatRecordProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 6;
	public ReceiveDataPlayerIdentificationProperty Sayer = new ReceiveDataPlayerIdentificationProperty();
	public ViReceiveDataString Content = new ViReceiveDataString();
	public ViReceiveDataInt64 Time1970 = new ViReceiveDataInt64();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		Sayer.Start(channelMask, IS, entity);
		Content.Start(channelMask, IS, entity);
		Time1970.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		Sayer.End(entity);
		Content.End(entity);
		Time1970.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		Sayer.Clear();
		Content.Clear();
		Time1970.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		Sayer.RegisterAsChild(channelMask, this, childList);
		Content.RegisterAsChild(channelMask, this, childList);
		Time1970.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator ChatRecordProperty(ReceiveDataChatRecordProperty data)
	{
		ChatRecordProperty value = new ChatRecordProperty();
		value.Sayer = data.Sayer;
		value.Content = data.Content;
		value.Time1970 = data.Time1970;
		return value;
	}
}

public class ReceiveDataPlayerShotHeroProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 6;
	public ViReceiveDataForeignKey<HeroStruct> Info = new ViReceiveDataForeignKey<HeroStruct>();
	public ViReceiveDataInt16 Level = new ViReceiveDataInt16();
	public ViReceiveDataInt16 Star = new ViReceiveDataInt16();
	public ViReceiveDataInt16 Quality = new ViReceiveDataInt16();
	public ViReceiveDataInt16 WeaponLevel = new ViReceiveDataInt16();
	public ViReceiveDataInt32 FightPower = new ViReceiveDataInt32();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		Info.Start(channelMask, IS, entity);
		Level.Start(channelMask, IS, entity);
		Star.Start(channelMask, IS, entity);
		Quality.Start(channelMask, IS, entity);
		WeaponLevel.Start(channelMask, IS, entity);
		FightPower.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		Info.End(entity);
		Level.End(entity);
		Star.End(entity);
		Quality.End(entity);
		WeaponLevel.End(entity);
		FightPower.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		Info.Clear();
		Level.Clear();
		Star.Clear();
		Quality.Clear();
		WeaponLevel.Clear();
		FightPower.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		Info.RegisterAsChild(channelMask, this, childList);
		Level.RegisterAsChild(channelMask, this, childList);
		Star.RegisterAsChild(channelMask, this, childList);
		Quality.RegisterAsChild(channelMask, this, childList);
		WeaponLevel.RegisterAsChild(channelMask, this, childList);
		FightPower.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator PlayerShotHeroProperty(ReceiveDataPlayerShotHeroProperty data)
	{
		PlayerShotHeroProperty value = new PlayerShotHeroProperty();
		value.Info = data.Info;
		value.Level = data.Level;
		value.Star = data.Star;
		value.Quality = data.Quality;
		value.WeaponLevel = data.WeaponLevel;
		value.FightPower = data.FightPower;
		return value;
	}
}

public class ReceiveDataPlayerShotHeroArrayProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 18;
	public static readonly int Length = 3;
	//
	public int GetLength() { return Length; }
	//
	public ReceiveDataPlayerShotHeroProperty E0 = new ReceiveDataPlayerShotHeroProperty();
	public ReceiveDataPlayerShotHeroProperty E1 = new ReceiveDataPlayerShotHeroProperty();
	public ReceiveDataPlayerShotHeroProperty E2 = new ReceiveDataPlayerShotHeroProperty();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		E0.Start(channelMask, IS, entity);
		E1.Start(channelMask, IS, entity);
		E2.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		E0.End(entity);
		E1.End(entity);
		E2.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		E0.Clear();
		E1.Clear();
		E2.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		E0.RegisterAsChild(channelMask, this, childList);
		E1.RegisterAsChild(channelMask, this, childList);
		E2.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator PlayerShotHeroArrayProperty(ReceiveDataPlayerShotHeroArrayProperty data)
	{
		PlayerShotHeroArrayProperty value = new PlayerShotHeroArrayProperty();
		value.E0 = data.E0;
		value.E1 = data.E1;
		value.E2 = data.E2;
		return value;
	}
	public ReceiveDataPlayerShotHeroProperty this[int index]
	{
		get
		{
			switch(index)
			{
				case 0:
					return E0;
				case 1:
					return E1;
				case 2:
					return E2;
			}
			ViDebuger.Error("");
			return E0;
		}
	}
}

public class ReceiveDataPlayerShotProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 12;
	public ReceiveDataPlayerIdentificationProperty Identify = new ReceiveDataPlayerIdentificationProperty();
	public ViReceiveDataUInt8 Gender = new ViReceiveDataUInt8();
	public ViReceiveDataInt16 Level = new ViReceiveDataInt16();
	public ViReceiveDataUInt8 Class = new ViReceiveDataUInt8();
	public ViReceiveDataInt32 FightPower = new ViReceiveDataInt32();
	public ViReceiveDataUInt8 State = new ViReceiveDataUInt8();
	public ViReceiveDataInt64 LastActiveTime1970 = new ViReceiveDataInt64();
	public ViReceiveDataString Guild = new ViReceiveDataString();
	public ViReceiveDataPtr<PlayerShotHeroArrayProperty> HeroList = new ViReceiveDataPtr<PlayerShotHeroArrayProperty>();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		Identify.Start(channelMask, IS, entity);
		Gender.Start(channelMask, IS, entity);
		Level.Start(channelMask, IS, entity);
		Class.Start(channelMask, IS, entity);
		FightPower.Start(channelMask, IS, entity);
		State.Start(channelMask, IS, entity);
		LastActiveTime1970.Start(channelMask, IS, entity);
		Guild.Start(channelMask, IS, entity);
		HeroList.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		Identify.End(entity);
		Gender.End(entity);
		Level.End(entity);
		Class.End(entity);
		FightPower.End(entity);
		State.End(entity);
		LastActiveTime1970.End(entity);
		Guild.End(entity);
		HeroList.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		Identify.Clear();
		Gender.Clear();
		Level.Clear();
		Class.Clear();
		FightPower.Clear();
		State.Clear();
		LastActiveTime1970.Clear();
		Guild.Clear();
		HeroList.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		Identify.RegisterAsChild(channelMask, this, childList);
		Gender.RegisterAsChild(channelMask, this, childList);
		Level.RegisterAsChild(channelMask, this, childList);
		Class.RegisterAsChild(channelMask, this, childList);
		FightPower.RegisterAsChild(channelMask, this, childList);
		State.RegisterAsChild(channelMask, this, childList);
		LastActiveTime1970.RegisterAsChild(channelMask, this, childList);
		Guild.RegisterAsChild(channelMask, this, childList);
		HeroList.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator PlayerShotProperty(ReceiveDataPlayerShotProperty data)
	{
		PlayerShotProperty value = new PlayerShotProperty();
		value.Identify = data.Identify;
		value.Gender = data.Gender;
		value.Level = data.Level;
		value.Class = data.Class;
		value.FightPower = data.FightPower;
		value.State = data.State;
		value.LastActiveTime1970 = data.LastActiveTime1970;
		value.Guild = data.Guild;
		value.HeroList = data.HeroList;
		return value;
	}
}

public class ReceiveDataScoreProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 2;
	public ViReceiveDataForeignKey<ScoreStruct> Info = new ViReceiveDataForeignKey<ScoreStruct>();
	public ViReceiveDataInt32 Value = new ViReceiveDataInt32();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		Info.Start(channelMask, IS, entity);
		Value.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		Info.End(entity);
		Value.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		Info.Clear();
		Value.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		Info.RegisterAsChild(channelMask, this, childList);
		Value.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator ScoreProperty(ReceiveDataScoreProperty data)
	{
		ScoreProperty value = new ScoreProperty();
		value.Info = data.Info;
		value.Value = data.Value;
		return value;
	}
}

public class ReceiveDataScoreArray6Property: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 12;
	public static readonly int Length = 6;
	//
	public int GetLength() { return Length; }
	//
	public ReceiveDataScoreProperty E0 = new ReceiveDataScoreProperty();
	public ReceiveDataScoreProperty E1 = new ReceiveDataScoreProperty();
	public ReceiveDataScoreProperty E2 = new ReceiveDataScoreProperty();
	public ReceiveDataScoreProperty E3 = new ReceiveDataScoreProperty();
	public ReceiveDataScoreProperty E4 = new ReceiveDataScoreProperty();
	public ReceiveDataScoreProperty E5 = new ReceiveDataScoreProperty();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		E0.Start(channelMask, IS, entity);
		E1.Start(channelMask, IS, entity);
		E2.Start(channelMask, IS, entity);
		E3.Start(channelMask, IS, entity);
		E4.Start(channelMask, IS, entity);
		E5.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		E0.End(entity);
		E1.End(entity);
		E2.End(entity);
		E3.End(entity);
		E4.End(entity);
		E5.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		E0.Clear();
		E1.Clear();
		E2.Clear();
		E3.Clear();
		E4.Clear();
		E5.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		E0.RegisterAsChild(channelMask, this, childList);
		E1.RegisterAsChild(channelMask, this, childList);
		E2.RegisterAsChild(channelMask, this, childList);
		E3.RegisterAsChild(channelMask, this, childList);
		E4.RegisterAsChild(channelMask, this, childList);
		E5.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator ScoreArray6Property(ReceiveDataScoreArray6Property data)
	{
		ScoreArray6Property value = new ScoreArray6Property();
		value.E0 = data.E0;
		value.E1 = data.E1;
		value.E2 = data.E2;
		value.E3 = data.E3;
		value.E4 = data.E4;
		value.E5 = data.E5;
		return value;
	}
	public ReceiveDataScoreProperty this[int index]
	{
		get
		{
			switch(index)
			{
				case 0:
					return E0;
				case 1:
					return E1;
				case 2:
					return E2;
				case 3:
					return E3;
				case 4:
					return E4;
				case 5:
					return E5;
			}
			ViDebuger.Error("");
			return E0;
		}
	}
}

public class ReceiveDataItemCountProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 2;
	public ViReceiveDataForeignKey<ItemStruct> Info = new ViReceiveDataForeignKey<ItemStruct>();
	public ViReceiveDataInt32 Count = new ViReceiveDataInt32();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		Info.Start(channelMask, IS, entity);
		Count.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		Info.End(entity);
		Count.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		Info.Clear();
		Count.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		Info.RegisterAsChild(channelMask, this, childList);
		Count.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator ItemCountProperty(ReceiveDataItemCountProperty data)
	{
		ItemCountProperty value = new ItemCountProperty();
		value.Info = data.Info;
		value.Count = data.Count;
		return value;
	}
}

public class ReceiveDataItemCountArray6Property: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 12;
	public static readonly int Length = 6;
	//
	public int GetLength() { return Length; }
	//
	public ReceiveDataItemCountProperty E0 = new ReceiveDataItemCountProperty();
	public ReceiveDataItemCountProperty E1 = new ReceiveDataItemCountProperty();
	public ReceiveDataItemCountProperty E2 = new ReceiveDataItemCountProperty();
	public ReceiveDataItemCountProperty E3 = new ReceiveDataItemCountProperty();
	public ReceiveDataItemCountProperty E4 = new ReceiveDataItemCountProperty();
	public ReceiveDataItemCountProperty E5 = new ReceiveDataItemCountProperty();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		E0.Start(channelMask, IS, entity);
		E1.Start(channelMask, IS, entity);
		E2.Start(channelMask, IS, entity);
		E3.Start(channelMask, IS, entity);
		E4.Start(channelMask, IS, entity);
		E5.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		E0.End(entity);
		E1.End(entity);
		E2.End(entity);
		E3.End(entity);
		E4.End(entity);
		E5.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		E0.Clear();
		E1.Clear();
		E2.Clear();
		E3.Clear();
		E4.Clear();
		E5.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		E0.RegisterAsChild(channelMask, this, childList);
		E1.RegisterAsChild(channelMask, this, childList);
		E2.RegisterAsChild(channelMask, this, childList);
		E3.RegisterAsChild(channelMask, this, childList);
		E4.RegisterAsChild(channelMask, this, childList);
		E5.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator ItemCountArray6Property(ReceiveDataItemCountArray6Property data)
	{
		ItemCountArray6Property value = new ItemCountArray6Property();
		value.E0 = data.E0;
		value.E1 = data.E1;
		value.E2 = data.E2;
		value.E3 = data.E3;
		value.E4 = data.E4;
		value.E5 = data.E5;
		return value;
	}
	public ReceiveDataItemCountProperty this[int index]
	{
		get
		{
			switch(index)
			{
				case 0:
					return E0;
				case 1:
					return E1;
				case 2:
					return E2;
				case 3:
					return E3;
				case 4:
					return E4;
				case 5:
					return E5;
			}
			ViDebuger.Error("");
			return E0;
		}
	}
}

public class ReceiveDataBagSlot: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 2;
	public ViReceiveDataUInt8 Bag = new ViReceiveDataUInt8();
	public ViReceiveDataUInt16 Slot = new ViReceiveDataUInt16();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		Bag.Start(channelMask, IS, entity);
		Slot.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		Bag.End(entity);
		Slot.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		Bag.Clear();
		Slot.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		Bag.RegisterAsChild(channelMask, this, childList);
		Slot.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator BagSlot(ReceiveDataBagSlot data)
	{
		BagSlot value = new BagSlot();
		value.Bag = data.Bag;
		value.Slot = data.Slot;
		return value;
	}
}

public class ReceiveDataItemScriptValuePropertyList: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 4;
	public static readonly int Length = 4;
	//
	public int GetLength() { return Length; }
	//
	public ViReceiveDataInt32 E0 = new ViReceiveDataInt32();
	public ViReceiveDataInt32 E1 = new ViReceiveDataInt32();
	public ViReceiveDataInt32 E2 = new ViReceiveDataInt32();
	public ViReceiveDataInt32 E3 = new ViReceiveDataInt32();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		E0.Start(channelMask, IS, entity);
		E1.Start(channelMask, IS, entity);
		E2.Start(channelMask, IS, entity);
		E3.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		E0.End(entity);
		E1.End(entity);
		E2.End(entity);
		E3.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		E0.Clear();
		E1.Clear();
		E2.Clear();
		E3.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		E0.RegisterAsChild(channelMask, this, childList);
		E1.RegisterAsChild(channelMask, this, childList);
		E2.RegisterAsChild(channelMask, this, childList);
		E3.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator ItemScriptValuePropertyList(ReceiveDataItemScriptValuePropertyList data)
	{
		ItemScriptValuePropertyList value = new ItemScriptValuePropertyList();
		value.E0 = data.E0;
		value.E1 = data.E1;
		value.E2 = data.E2;
		value.E3 = data.E3;
		return value;
	}
	public ViReceiveDataInt32 this[int index]
	{
		get
		{
			switch(index)
			{
				case 0:
					return E0;
				case 1:
					return E1;
				case 2:
					return E2;
				case 3:
					return E3;
			}
			ViDebuger.Error("");
			return E0;
		}
	}
}

public class ReceiveDataItemProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 15;
	public ViReceiveDataUInt64 ID = new ViReceiveDataUInt64();
	public ViReceiveDataForeignKey<ItemStruct> Info = new ViReceiveDataForeignKey<ItemStruct>();
	public ViReceiveDataUInt8 State = new ViReceiveDataUInt8();
	public ReceiveDataBagSlot Slot = new ReceiveDataBagSlot();
	public ViReceiveDataInt64 CreateTime1970 = new ViReceiveDataInt64();
	public ViReceiveDataInt64 StartTime = new ViReceiveDataInt64();
	public ViReceiveDataInt64 EndTime = new ViReceiveDataInt64();
	public ViReceiveDataInt64 RecoverTime = new ViReceiveDataInt64();
	public ViReceiveDataInt32 StackCount = new ViReceiveDataInt32();
	public ViReceiveDataUInt8 Color = new ViReceiveDataUInt8();
	public ViReceiveDataInt16 Durability = new ViReceiveDataInt16();
	public ViReceiveDataPtr<ItemScriptValuePropertyList> ScriptValues = new ViReceiveDataPtr<ItemScriptValuePropertyList>();
	public ViReceiveDataUInt16 OperateMask0 = new ViReceiveDataUInt16();
	public ViReceiveDataUInt16 OperateMask1 = new ViReceiveDataUInt16();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		ID.Start(channelMask, IS, entity);
		Info.Start(channelMask, IS, entity);
		State.Start(channelMask, IS, entity);
		Slot.Start(channelMask, IS, entity);
		CreateTime1970.Start(channelMask, IS, entity);
		StartTime.Start(channelMask, IS, entity);
		EndTime.Start(channelMask, IS, entity);
		RecoverTime.Start(channelMask, IS, entity);
		StackCount.Start(channelMask, IS, entity);
		Color.Start(channelMask, IS, entity);
		Durability.Start(channelMask, IS, entity);
		ScriptValues.Start(channelMask, IS, entity);
		OperateMask0.Start(channelMask, IS, entity);
		OperateMask1.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		ID.End(entity);
		Info.End(entity);
		State.End(entity);
		Slot.End(entity);
		CreateTime1970.End(entity);
		StartTime.End(entity);
		EndTime.End(entity);
		RecoverTime.End(entity);
		StackCount.End(entity);
		Color.End(entity);
		Durability.End(entity);
		ScriptValues.End(entity);
		OperateMask0.End(entity);
		OperateMask1.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		ID.Clear();
		Info.Clear();
		State.Clear();
		Slot.Clear();
		CreateTime1970.Clear();
		StartTime.Clear();
		EndTime.Clear();
		RecoverTime.Clear();
		StackCount.Clear();
		Color.Clear();
		Durability.Clear();
		ScriptValues.Clear();
		OperateMask0.Clear();
		OperateMask1.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		ID.RegisterAsChild(channelMask, this, childList);
		Info.RegisterAsChild(channelMask, this, childList);
		State.RegisterAsChild(channelMask, this, childList);
		Slot.RegisterAsChild(channelMask, this, childList);
		CreateTime1970.RegisterAsChild(channelMask, this, childList);
		StartTime.RegisterAsChild(channelMask, this, childList);
		EndTime.RegisterAsChild(channelMask, this, childList);
		RecoverTime.RegisterAsChild(channelMask, this, childList);
		StackCount.RegisterAsChild(channelMask, this, childList);
		Color.RegisterAsChild(channelMask, this, childList);
		Durability.RegisterAsChild(channelMask, this, childList);
		ScriptValues.RegisterAsChild(channelMask, this, childList);
		OperateMask0.RegisterAsChild(channelMask, this, childList);
		OperateMask1.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator ItemProperty(ReceiveDataItemProperty data)
	{
		ItemProperty value = new ItemProperty();
		value.ID = data.ID;
		value.Info = data.Info;
		value.State = data.State;
		value.Slot = data.Slot;
		value.CreateTime1970 = data.CreateTime1970;
		value.StartTime = data.StartTime;
		value.EndTime = data.EndTime;
		value.RecoverTime = data.RecoverTime;
		value.StackCount = data.StackCount;
		value.Color = data.Color;
		value.Durability = data.Durability;
		value.ScriptValues = data.ScriptValues;
		value.OperateMask0 = data.OperateMask0;
		value.OperateMask1 = data.OperateMask1;
		return value;
	}
}

public class ReceiveDataItemSaledProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 16;
	public ReceiveDataItemProperty Item = new ReceiveDataItemProperty();
	public ViReceiveDataInt64 Time = new ViReceiveDataInt64();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		Item.Start(channelMask, IS, entity);
		Time.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		Item.End(entity);
		Time.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		Item.Clear();
		Time.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		Item.RegisterAsChild(channelMask, this, childList);
		Time.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator ItemSaledProperty(ReceiveDataItemSaledProperty data)
	{
		ItemSaledProperty value = new ItemSaledProperty();
		value.Item = data.Item;
		value.Time = data.Time;
		return value;
	}
}

public class ReceiveDataPackageSlotProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 2;
	public ViReceiveDataUInt32 Item = new ViReceiveDataUInt32();
	public ViReceiveDataInt32 Count = new ViReceiveDataInt32();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		Item.Start(channelMask, IS, entity);
		Count.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		Item.End(entity);
		Count.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		Item.Clear();
		Count.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		Item.RegisterAsChild(channelMask, this, childList);
		Count.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator PackageSlotProperty(ReceiveDataPackageSlotProperty data)
	{
		PackageSlotProperty value = new PackageSlotProperty();
		value.Item = data.Item;
		value.Count = data.Count;
		return value;
	}
}

public class ReceiveDataItemDelRecordProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 17;
	public ViReceiveDataUInt32 Type = new ViReceiveDataUInt32();
	public ViReceiveDataInt64 Time1970 = new ViReceiveDataInt64();
	public ReceiveDataItemProperty Item = new ReceiveDataItemProperty();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		Type.Start(channelMask, IS, entity);
		Time1970.Start(channelMask, IS, entity);
		Item.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		Type.End(entity);
		Time1970.End(entity);
		Item.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		Type.Clear();
		Time1970.Clear();
		Item.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		Type.RegisterAsChild(channelMask, this, childList);
		Time1970.RegisterAsChild(channelMask, this, childList);
		Item.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator ItemDelRecordProperty(ReceiveDataItemDelRecordProperty data)
	{
		ItemDelRecordProperty value = new ItemDelRecordProperty();
		value.Type = data.Type;
		value.Time1970 = data.Time1970;
		value.Item = data.Item;
		return value;
	}
}

public class ReceiveDataItemDelCountProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 4;
	public ViReceiveDataUInt32 Type = new ViReceiveDataUInt32();
	public ViReceiveDataInt64 Time1970 = new ViReceiveDataInt64();
	public ViReceiveDataForeignKey<ItemStruct> Info = new ViReceiveDataForeignKey<ItemStruct>();
	public ViReceiveDataInt32 Count = new ViReceiveDataInt32();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		Type.Start(channelMask, IS, entity);
		Time1970.Start(channelMask, IS, entity);
		Info.Start(channelMask, IS, entity);
		Count.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		Type.End(entity);
		Time1970.End(entity);
		Info.End(entity);
		Count.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		Type.Clear();
		Time1970.Clear();
		Info.Clear();
		Count.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		Type.RegisterAsChild(channelMask, this, childList);
		Time1970.RegisterAsChild(channelMask, this, childList);
		Info.RegisterAsChild(channelMask, this, childList);
		Count.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator ItemDelCountProperty(ReceiveDataItemDelCountProperty data)
	{
		ItemDelCountProperty value = new ItemDelCountProperty();
		value.Type = data.Type;
		value.Time1970 = data.Time1970;
		value.Info = data.Info;
		value.Count = data.Count;
		return value;
	}
}

public class ReceiveDataItemLicenceRecordProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 4;
	public ViReceiveDataString Licence = new ViReceiveDataString();
	public ViReceiveDataInt64 Time1970 = new ViReceiveDataInt64();
	public ViReceiveDataForeignKey<ItemStruct> Info = new ViReceiveDataForeignKey<ItemStruct>();
	public ViReceiveDataInt32 Count = new ViReceiveDataInt32();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		Licence.Start(channelMask, IS, entity);
		Time1970.Start(channelMask, IS, entity);
		Info.Start(channelMask, IS, entity);
		Count.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		Licence.End(entity);
		Time1970.End(entity);
		Info.End(entity);
		Count.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		Licence.Clear();
		Time1970.Clear();
		Info.Clear();
		Count.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		Licence.RegisterAsChild(channelMask, this, childList);
		Time1970.RegisterAsChild(channelMask, this, childList);
		Info.RegisterAsChild(channelMask, this, childList);
		Count.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator ItemLicenceRecordProperty(ReceiveDataItemLicenceRecordProperty data)
	{
		ItemLicenceRecordProperty value = new ItemLicenceRecordProperty();
		value.Licence = data.Licence;
		value.Time1970 = data.Time1970;
		value.Info = data.Info;
		value.Count = data.Count;
		return value;
	}
}

public class ReceiveDataHeroEquipProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 15;
	public ReceiveDataItemProperty ItemInfo = new ReceiveDataItemProperty();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		ItemInfo.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		ItemInfo.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		ItemInfo.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		ItemInfo.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator HeroEquipProperty(ReceiveDataHeroEquipProperty data)
	{
		HeroEquipProperty value = new HeroEquipProperty();
		value.ItemInfo = data.ItemInfo;
		return value;
	}
}

public class ReceiveDataHeroEquipArrayProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 120;
	public static readonly int Length = 8;
	//
	public int GetLength() { return Length; }
	//
	public ReceiveDataHeroEquipProperty E0 = new ReceiveDataHeroEquipProperty();
	public ReceiveDataHeroEquipProperty E1 = new ReceiveDataHeroEquipProperty();
	public ReceiveDataHeroEquipProperty E2 = new ReceiveDataHeroEquipProperty();
	public ReceiveDataHeroEquipProperty E3 = new ReceiveDataHeroEquipProperty();
	public ReceiveDataHeroEquipProperty E4 = new ReceiveDataHeroEquipProperty();
	public ReceiveDataHeroEquipProperty E5 = new ReceiveDataHeroEquipProperty();
	public ReceiveDataHeroEquipProperty E6 = new ReceiveDataHeroEquipProperty();
	public ReceiveDataHeroEquipProperty E7 = new ReceiveDataHeroEquipProperty();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		E0.Start(channelMask, IS, entity);
		E1.Start(channelMask, IS, entity);
		E2.Start(channelMask, IS, entity);
		E3.Start(channelMask, IS, entity);
		E4.Start(channelMask, IS, entity);
		E5.Start(channelMask, IS, entity);
		E6.Start(channelMask, IS, entity);
		E7.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		E0.End(entity);
		E1.End(entity);
		E2.End(entity);
		E3.End(entity);
		E4.End(entity);
		E5.End(entity);
		E6.End(entity);
		E7.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		E0.Clear();
		E1.Clear();
		E2.Clear();
		E3.Clear();
		E4.Clear();
		E5.Clear();
		E6.Clear();
		E7.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		E0.RegisterAsChild(channelMask, this, childList);
		E1.RegisterAsChild(channelMask, this, childList);
		E2.RegisterAsChild(channelMask, this, childList);
		E3.RegisterAsChild(channelMask, this, childList);
		E4.RegisterAsChild(channelMask, this, childList);
		E5.RegisterAsChild(channelMask, this, childList);
		E6.RegisterAsChild(channelMask, this, childList);
		E7.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator HeroEquipArrayProperty(ReceiveDataHeroEquipArrayProperty data)
	{
		HeroEquipArrayProperty value = new HeroEquipArrayProperty();
		value.E0 = data.E0;
		value.E1 = data.E1;
		value.E2 = data.E2;
		value.E3 = data.E3;
		value.E4 = data.E4;
		value.E5 = data.E5;
		value.E6 = data.E6;
		value.E7 = data.E7;
		return value;
	}
	public ReceiveDataHeroEquipProperty this[int index]
	{
		get
		{
			switch(index)
			{
				case 0:
					return E0;
				case 1:
					return E1;
				case 2:
					return E2;
				case 3:
					return E3;
				case 4:
					return E4;
				case 5:
					return E5;
				case 6:
					return E6;
				case 7:
					return E7;
			}
			ViDebuger.Error("");
			return E0;
		}
	}
}

public class ReceiveDataItemTradeRecordProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 25;
	public ReceiveDataPlayerIdentificationProperty FromPlayer = new ReceiveDataPlayerIdentificationProperty();
	public ReceiveDataPlayerIdentificationProperty ToPlayer = new ReceiveDataPlayerIdentificationProperty();
	public ViReceiveDataInt64 Time1970 = new ViReceiveDataInt64();
	public ViReceiveDataInt64 Price = new ViReceiveDataInt64();
	public ReceiveDataItemProperty ItemProperty = new ReceiveDataItemProperty();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		FromPlayer.Start(channelMask, IS, entity);
		ToPlayer.Start(channelMask, IS, entity);
		Time1970.Start(channelMask, IS, entity);
		Price.Start(channelMask, IS, entity);
		ItemProperty.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		FromPlayer.End(entity);
		ToPlayer.End(entity);
		Time1970.End(entity);
		Price.End(entity);
		ItemProperty.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		FromPlayer.Clear();
		ToPlayer.Clear();
		Time1970.Clear();
		Price.Clear();
		ItemProperty.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		FromPlayer.RegisterAsChild(channelMask, this, childList);
		ToPlayer.RegisterAsChild(channelMask, this, childList);
		Time1970.RegisterAsChild(channelMask, this, childList);
		Price.RegisterAsChild(channelMask, this, childList);
		ItemProperty.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator ItemTradeRecordProperty(ReceiveDataItemTradeRecordProperty data)
	{
		ItemTradeRecordProperty value = new ItemTradeRecordProperty();
		value.FromPlayer = data.FromPlayer;
		value.ToPlayer = data.ToPlayer;
		value.Time1970 = data.Time1970;
		value.Price = data.Price;
		value.ItemProperty = data.ItemProperty;
		return value;
	}
}

public class ReceiveDataItemTradeProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 27;
	public ViReceiveDataUInt64 ID = new ViReceiveDataUInt64();
	public ReceiveDataItemProperty ItemProperty = new ReceiveDataItemProperty();
	public ViReceiveDataInt64 Price = new ViReceiveDataInt64();
	public ReceiveDataPlayerIdentificationProperty Player = new ReceiveDataPlayerIdentificationProperty();
	public ViReceiveDataInt64 EndTime = new ViReceiveDataInt64();
	public ViReceiveDataInt64 AuctionPrice = new ViReceiveDataInt64();
	public ReceiveDataPlayerIdentificationProperty Auctioner = new ReceiveDataPlayerIdentificationProperty();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		ID.Start(channelMask, IS, entity);
		ItemProperty.Start(channelMask, IS, entity);
		Price.Start(channelMask, IS, entity);
		Player.Start(channelMask, IS, entity);
		EndTime.Start(channelMask, IS, entity);
		AuctionPrice.Start(channelMask, IS, entity);
		Auctioner.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		ID.End(entity);
		ItemProperty.End(entity);
		Price.End(entity);
		Player.End(entity);
		EndTime.End(entity);
		AuctionPrice.End(entity);
		Auctioner.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		ID.Clear();
		ItemProperty.Clear();
		Price.Clear();
		Player.Clear();
		EndTime.Clear();
		AuctionPrice.Clear();
		Auctioner.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		ID.RegisterAsChild(channelMask, this, childList);
		ItemProperty.RegisterAsChild(channelMask, this, childList);
		Price.RegisterAsChild(channelMask, this, childList);
		Player.RegisterAsChild(channelMask, this, childList);
		EndTime.RegisterAsChild(channelMask, this, childList);
		AuctionPrice.RegisterAsChild(channelMask, this, childList);
		Auctioner.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator ItemTradeProperty(ReceiveDataItemTradeProperty data)
	{
		ItemTradeProperty value = new ItemTradeProperty();
		value.ID = data.ID;
		value.ItemProperty = data.ItemProperty;
		value.Price = data.Price;
		value.Player = data.Player;
		value.EndTime = data.EndTime;
		value.AuctionPrice = data.AuctionPrice;
		value.Auctioner = data.Auctioner;
		return value;
	}
}

public class ReceiveDataItemTradeOfficialPriceProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 4;
	public ViReceiveDataInt32 Inf = new ViReceiveDataInt32();
	public ViReceiveDataInt32 Sup = new ViReceiveDataInt32();
	public ViReceiveDataInt32 Standard = new ViReceiveDataInt32();
	public ViReceiveDataInt32 Current = new ViReceiveDataInt32();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		Inf.Start(channelMask, IS, entity);
		Sup.Start(channelMask, IS, entity);
		Standard.Start(channelMask, IS, entity);
		Current.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		Inf.End(entity);
		Sup.End(entity);
		Standard.End(entity);
		Current.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		Inf.Clear();
		Sup.Clear();
		Standard.Clear();
		Current.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		Inf.RegisterAsChild(channelMask, this, childList);
		Sup.RegisterAsChild(channelMask, this, childList);
		Standard.RegisterAsChild(channelMask, this, childList);
		Current.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator ItemTradeOfficialPriceProperty(ReceiveDataItemTradeOfficialPriceProperty data)
	{
		ItemTradeOfficialPriceProperty value = new ItemTradeOfficialPriceProperty();
		value.Inf = data.Inf;
		value.Sup = data.Sup;
		value.Standard = data.Standard;
		value.Current = data.Current;
		return value;
	}
}

public class ReceiveDataMoneyModRecordProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 4;
	public ViReceiveDataUInt32 Type = new ViReceiveDataUInt32();
	public ViReceiveDataInt64 FromMoney = new ViReceiveDataInt64();
	public ViReceiveDataInt64 ToMoney = new ViReceiveDataInt64();
	public ViReceiveDataInt64 Time1970 = new ViReceiveDataInt64();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		Type.Start(channelMask, IS, entity);
		FromMoney.Start(channelMask, IS, entity);
		ToMoney.Start(channelMask, IS, entity);
		Time1970.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		Type.End(entity);
		FromMoney.End(entity);
		ToMoney.End(entity);
		Time1970.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		Type.Clear();
		FromMoney.Clear();
		ToMoney.Clear();
		Time1970.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		Type.RegisterAsChild(channelMask, this, childList);
		FromMoney.RegisterAsChild(channelMask, this, childList);
		ToMoney.RegisterAsChild(channelMask, this, childList);
		Time1970.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator MoneyModRecordProperty(ReceiveDataMoneyModRecordProperty data)
	{
		MoneyModRecordProperty value = new MoneyModRecordProperty();
		value.Type = data.Type;
		value.FromMoney = data.FromMoney;
		value.ToMoney = data.ToMoney;
		value.Time1970 = data.Time1970;
		return value;
	}
}

public class ReceiveDataScriptDurationProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 1;
	public ViReceiveDataInt64 EndTime = new ViReceiveDataInt64();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		EndTime.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		EndTime.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		EndTime.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		EndTime.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator ScriptDurationProperty(ReceiveDataScriptDurationProperty data)
	{
		ScriptDurationProperty value = new ScriptDurationProperty();
		value.EndTime = data.EndTime;
		return value;
	}
}

public class ReceiveDataAccountRoleProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 130;
	public ReceiveDataPlayerIdentificationProperty Identification = new ReceiveDataPlayerIdentificationProperty();
	public ViReceiveDataUInt8 Gender = new ViReceiveDataUInt8();
	public ViReceiveDataInt16 Level = new ViReceiveDataInt16();
	public ViReceiveDataUInt8 FaceType = new ViReceiveDataUInt8();
	public ViReceiveDataUInt8 HairType = new ViReceiveDataUInt8();
	public ViReceiveDataForeignKey<HeroStruct> HeroConfig = new ViReceiveDataForeignKey<HeroStruct>();
	public ReceiveDataHeroEquipArrayProperty EquipList = new ReceiveDataHeroEquipArrayProperty();
	public ViReceiveDataInt64 EndTime = new ViReceiveDataInt64();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		Identification.Start(channelMask, IS, entity);
		Gender.Start(channelMask, IS, entity);
		Level.Start(channelMask, IS, entity);
		FaceType.Start(channelMask, IS, entity);
		HairType.Start(channelMask, IS, entity);
		HeroConfig.Start(channelMask, IS, entity);
		EquipList.Start(channelMask, IS, entity);
		EndTime.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		Identification.End(entity);
		Gender.End(entity);
		Level.End(entity);
		FaceType.End(entity);
		HairType.End(entity);
		HeroConfig.End(entity);
		EquipList.End(entity);
		EndTime.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		Identification.Clear();
		Gender.Clear();
		Level.Clear();
		FaceType.Clear();
		HairType.Clear();
		HeroConfig.Clear();
		EquipList.Clear();
		EndTime.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		Identification.RegisterAsChild(channelMask, this, childList);
		Gender.RegisterAsChild(channelMask, this, childList);
		Level.RegisterAsChild(channelMask, this, childList);
		FaceType.RegisterAsChild(channelMask, this, childList);
		HairType.RegisterAsChild(channelMask, this, childList);
		HeroConfig.RegisterAsChild(channelMask, this, childList);
		EquipList.RegisterAsChild(channelMask, this, childList);
		EndTime.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator AccountRoleProperty(ReceiveDataAccountRoleProperty data)
	{
		AccountRoleProperty value = new AccountRoleProperty();
		value.Identification = data.Identification;
		value.Gender = data.Gender;
		value.Level = data.Level;
		value.FaceType = data.FaceType;
		value.HairType = data.HairType;
		value.HeroConfig = data.HeroConfig;
		value.EquipList = data.EquipList;
		value.EndTime = data.EndTime;
		return value;
	}
}

public class ReceiveDataRechargeProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 4;
	public ViReceiveDataString OrderNo = new ViReceiveDataString();
	public ViReceiveDataInt64 Time1970 = new ViReceiveDataInt64();
	public ViReceiveDataInt64 Money = new ViReceiveDataInt64();
	public ViReceiveDataInt64 Value = new ViReceiveDataInt64();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		OrderNo.Start(channelMask, IS, entity);
		Time1970.Start(channelMask, IS, entity);
		Money.Start(channelMask, IS, entity);
		Value.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		OrderNo.End(entity);
		Time1970.End(entity);
		Money.End(entity);
		Value.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		OrderNo.Clear();
		Time1970.Clear();
		Money.Clear();
		Value.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		OrderNo.RegisterAsChild(channelMask, this, childList);
		Time1970.RegisterAsChild(channelMask, this, childList);
		Money.RegisterAsChild(channelMask, this, childList);
		Value.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator RechargeProperty(ReceiveDataRechargeProperty data)
	{
		RechargeProperty value = new RechargeProperty();
		value.OrderNo = data.OrderNo;
		value.Time1970 = data.Time1970;
		value.Money = data.Money;
		value.Value = data.Value;
		return value;
	}
}

public class ReceiveDataRechargeExecProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 5;
	public ViReceiveDataInt64 CreateTime1970 = new ViReceiveDataInt64();
	public ViReceiveDataInt32 CreateDayNumber1970 = new ViReceiveDataInt32();
	public ViReceiveDataInt64 ExecTime1970 = new ViReceiveDataInt64();
	public ViReceiveDataInt32 ExecDayNumber1970 = new ViReceiveDataInt32();
	public ViReceiveDataInt64 Value = new ViReceiveDataInt64();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		CreateTime1970.Start(channelMask, IS, entity);
		CreateDayNumber1970.Start(channelMask, IS, entity);
		ExecTime1970.Start(channelMask, IS, entity);
		ExecDayNumber1970.Start(channelMask, IS, entity);
		Value.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		CreateTime1970.End(entity);
		CreateDayNumber1970.End(entity);
		ExecTime1970.End(entity);
		ExecDayNumber1970.End(entity);
		Value.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		CreateTime1970.Clear();
		CreateDayNumber1970.Clear();
		ExecTime1970.Clear();
		ExecDayNumber1970.Clear();
		Value.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		CreateTime1970.RegisterAsChild(channelMask, this, childList);
		CreateDayNumber1970.RegisterAsChild(channelMask, this, childList);
		ExecTime1970.RegisterAsChild(channelMask, this, childList);
		ExecDayNumber1970.RegisterAsChild(channelMask, this, childList);
		Value.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator RechargeExecProperty(ReceiveDataRechargeExecProperty data)
	{
		RechargeExecProperty value = new RechargeExecProperty();
		value.CreateTime1970 = data.CreateTime1970;
		value.CreateDayNumber1970 = data.CreateDayNumber1970;
		value.ExecTime1970 = data.ExecTime1970;
		value.ExecDayNumber1970 = data.ExecDayNumber1970;
		value.Value = data.Value;
		return value;
	}
}

public class ReceiveDataGameUnitIndexProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 60;
	public ViReceiveDataInt32 HPMax0 = new ViReceiveDataInt32();
	public ViReceiveDataInt32 HPMax1 = new ViReceiveDataInt32();
	public ViReceiveDataInt32 HPMax2 = new ViReceiveDataInt32();
	public ViReceiveDataInt32 MPMax0 = new ViReceiveDataInt32();
	public ViReceiveDataInt32 MPMax1 = new ViReceiveDataInt32();
	public ViReceiveDataInt32 MPMax2 = new ViReceiveDataInt32();
	public ViReceiveDataInt32 SPMax0 = new ViReceiveDataInt32();
	public ViReceiveDataInt32 SPMax1 = new ViReceiveDataInt32();
	public ViReceiveDataInt32 SPMax2 = new ViReceiveDataInt32();
	public ViReceiveDataInt32 HPRegenerate0 = new ViReceiveDataInt32();
	public ViReceiveDataInt32 HPRegenerate1 = new ViReceiveDataInt32();
	public ViReceiveDataInt32 HPRegenerate2 = new ViReceiveDataInt32();
	public ViReceiveDataInt32 MPRegenerate0 = new ViReceiveDataInt32();
	public ViReceiveDataInt32 MPRegenerate1 = new ViReceiveDataInt32();
	public ViReceiveDataInt32 MPRegenerate2 = new ViReceiveDataInt32();
	public ViReceiveDataInt32 SPRegenerate0 = new ViReceiveDataInt32();
	public ViReceiveDataInt32 SPRegenerate1 = new ViReceiveDataInt32();
	public ViReceiveDataInt32 SPRegenerate2 = new ViReceiveDataInt32();
	public ViReceiveDataInt32 PhysicsAttack0 = new ViReceiveDataInt32();
	public ViReceiveDataInt32 PhysicsAttack1 = new ViReceiveDataInt32();
	public ViReceiveDataInt32 PhysicsAttack2 = new ViReceiveDataInt32();
	public ViReceiveDataInt32 PhysicsDefence0 = new ViReceiveDataInt32();
	public ViReceiveDataInt32 PhysicsDefence1 = new ViReceiveDataInt32();
	public ViReceiveDataInt32 PhysicsDefence2 = new ViReceiveDataInt32();
	public ViReceiveDataInt32 MagicAttack0 = new ViReceiveDataInt32();
	public ViReceiveDataInt32 MagicAttack1 = new ViReceiveDataInt32();
	public ViReceiveDataInt32 MagicAttack2 = new ViReceiveDataInt32();
	public ViReceiveDataInt32 MagicDefence0 = new ViReceiveDataInt32();
	public ViReceiveDataInt32 MagicDefence1 = new ViReceiveDataInt32();
	public ViReceiveDataInt32 MagicDefence2 = new ViReceiveDataInt32();
	public ViReceiveDataInt32 MoveSpeed0 = new ViReceiveDataInt32();
	public ViReceiveDataInt32 MoveSpeed1 = new ViReceiveDataInt32();
	public ViReceiveDataInt32 MoveSpeed2 = new ViReceiveDataInt32();
	public ViReceiveDataInt32 CriticalHit0 = new ViReceiveDataInt32();
	public ViReceiveDataInt32 CriticalHit1 = new ViReceiveDataInt32();
	public ViReceiveDataInt32 CriticalHit2 = new ViReceiveDataInt32();
	public ViReceiveDataInt32 CriticalMiss0 = new ViReceiveDataInt32();
	public ViReceiveDataInt32 CriticalMiss1 = new ViReceiveDataInt32();
	public ViReceiveDataInt32 CriticalMiss2 = new ViReceiveDataInt32();
	public ViReceiveDataInt32 CriticalHitRate0 = new ViReceiveDataInt32();
	public ViReceiveDataInt32 CriticalHitRate1 = new ViReceiveDataInt32();
	public ViReceiveDataInt32 CriticalHitRate2 = new ViReceiveDataInt32();
	public ViReceiveDataInt32 CriticalMissRate0 = new ViReceiveDataInt32();
	public ViReceiveDataInt32 CriticalMissRate1 = new ViReceiveDataInt32();
	public ViReceiveDataInt32 CriticalMissRate2 = new ViReceiveDataInt32();
	public ViReceiveDataInt32 CriticalDamageAttack0 = new ViReceiveDataInt32();
	public ViReceiveDataInt32 CriticalDamageAttack1 = new ViReceiveDataInt32();
	public ViReceiveDataInt32 CriticalDamageAttack2 = new ViReceiveDataInt32();
	public ViReceiveDataInt32 CriticalDamageDefence0 = new ViReceiveDataInt32();
	public ViReceiveDataInt32 CriticalDamageDefence1 = new ViReceiveDataInt32();
	public ViReceiveDataInt32 CriticalDamageDefence2 = new ViReceiveDataInt32();
	public ViReceiveDataInt32 Penetrate0 = new ViReceiveDataInt32();
	public ViReceiveDataInt32 Penetrate1 = new ViReceiveDataInt32();
	public ViReceiveDataInt32 Penetrate2 = new ViReceiveDataInt32();
	public ViReceiveDataInt32 AttackVampire0 = new ViReceiveDataInt32();
	public ViReceiveDataInt32 AttackVampire1 = new ViReceiveDataInt32();
	public ViReceiveDataInt32 AttackVampire2 = new ViReceiveDataInt32();
	public ViReceiveDataInt32 AttackSpeedMultiply0 = new ViReceiveDataInt32();
	public ViReceiveDataInt32 AttackSpeedMultiply1 = new ViReceiveDataInt32();
	public ViReceiveDataInt32 AttackSpeedMultiply2 = new ViReceiveDataInt32();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		HPMax0.Start(channelMask, IS, entity);
		HPMax1.Start(channelMask, IS, entity);
		HPMax2.Start(channelMask, IS, entity);
		MPMax0.Start(channelMask, IS, entity);
		MPMax1.Start(channelMask, IS, entity);
		MPMax2.Start(channelMask, IS, entity);
		SPMax0.Start(channelMask, IS, entity);
		SPMax1.Start(channelMask, IS, entity);
		SPMax2.Start(channelMask, IS, entity);
		HPRegenerate0.Start(channelMask, IS, entity);
		HPRegenerate1.Start(channelMask, IS, entity);
		HPRegenerate2.Start(channelMask, IS, entity);
		MPRegenerate0.Start(channelMask, IS, entity);
		MPRegenerate1.Start(channelMask, IS, entity);
		MPRegenerate2.Start(channelMask, IS, entity);
		SPRegenerate0.Start(channelMask, IS, entity);
		SPRegenerate1.Start(channelMask, IS, entity);
		SPRegenerate2.Start(channelMask, IS, entity);
		PhysicsAttack0.Start(channelMask, IS, entity);
		PhysicsAttack1.Start(channelMask, IS, entity);
		PhysicsAttack2.Start(channelMask, IS, entity);
		PhysicsDefence0.Start(channelMask, IS, entity);
		PhysicsDefence1.Start(channelMask, IS, entity);
		PhysicsDefence2.Start(channelMask, IS, entity);
		MagicAttack0.Start(channelMask, IS, entity);
		MagicAttack1.Start(channelMask, IS, entity);
		MagicAttack2.Start(channelMask, IS, entity);
		MagicDefence0.Start(channelMask, IS, entity);
		MagicDefence1.Start(channelMask, IS, entity);
		MagicDefence2.Start(channelMask, IS, entity);
		MoveSpeed0.Start(channelMask, IS, entity);
		MoveSpeed1.Start(channelMask, IS, entity);
		MoveSpeed2.Start(channelMask, IS, entity);
		CriticalHit0.Start(channelMask, IS, entity);
		CriticalHit1.Start(channelMask, IS, entity);
		CriticalHit2.Start(channelMask, IS, entity);
		CriticalMiss0.Start(channelMask, IS, entity);
		CriticalMiss1.Start(channelMask, IS, entity);
		CriticalMiss2.Start(channelMask, IS, entity);
		CriticalHitRate0.Start(channelMask, IS, entity);
		CriticalHitRate1.Start(channelMask, IS, entity);
		CriticalHitRate2.Start(channelMask, IS, entity);
		CriticalMissRate0.Start(channelMask, IS, entity);
		CriticalMissRate1.Start(channelMask, IS, entity);
		CriticalMissRate2.Start(channelMask, IS, entity);
		CriticalDamageAttack0.Start(channelMask, IS, entity);
		CriticalDamageAttack1.Start(channelMask, IS, entity);
		CriticalDamageAttack2.Start(channelMask, IS, entity);
		CriticalDamageDefence0.Start(channelMask, IS, entity);
		CriticalDamageDefence1.Start(channelMask, IS, entity);
		CriticalDamageDefence2.Start(channelMask, IS, entity);
		Penetrate0.Start(channelMask, IS, entity);
		Penetrate1.Start(channelMask, IS, entity);
		Penetrate2.Start(channelMask, IS, entity);
		AttackVampire0.Start(channelMask, IS, entity);
		AttackVampire1.Start(channelMask, IS, entity);
		AttackVampire2.Start(channelMask, IS, entity);
		AttackSpeedMultiply0.Start(channelMask, IS, entity);
		AttackSpeedMultiply1.Start(channelMask, IS, entity);
		AttackSpeedMultiply2.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		HPMax0.End(entity);
		HPMax1.End(entity);
		HPMax2.End(entity);
		MPMax0.End(entity);
		MPMax1.End(entity);
		MPMax2.End(entity);
		SPMax0.End(entity);
		SPMax1.End(entity);
		SPMax2.End(entity);
		HPRegenerate0.End(entity);
		HPRegenerate1.End(entity);
		HPRegenerate2.End(entity);
		MPRegenerate0.End(entity);
		MPRegenerate1.End(entity);
		MPRegenerate2.End(entity);
		SPRegenerate0.End(entity);
		SPRegenerate1.End(entity);
		SPRegenerate2.End(entity);
		PhysicsAttack0.End(entity);
		PhysicsAttack1.End(entity);
		PhysicsAttack2.End(entity);
		PhysicsDefence0.End(entity);
		PhysicsDefence1.End(entity);
		PhysicsDefence2.End(entity);
		MagicAttack0.End(entity);
		MagicAttack1.End(entity);
		MagicAttack2.End(entity);
		MagicDefence0.End(entity);
		MagicDefence1.End(entity);
		MagicDefence2.End(entity);
		MoveSpeed0.End(entity);
		MoveSpeed1.End(entity);
		MoveSpeed2.End(entity);
		CriticalHit0.End(entity);
		CriticalHit1.End(entity);
		CriticalHit2.End(entity);
		CriticalMiss0.End(entity);
		CriticalMiss1.End(entity);
		CriticalMiss2.End(entity);
		CriticalHitRate0.End(entity);
		CriticalHitRate1.End(entity);
		CriticalHitRate2.End(entity);
		CriticalMissRate0.End(entity);
		CriticalMissRate1.End(entity);
		CriticalMissRate2.End(entity);
		CriticalDamageAttack0.End(entity);
		CriticalDamageAttack1.End(entity);
		CriticalDamageAttack2.End(entity);
		CriticalDamageDefence0.End(entity);
		CriticalDamageDefence1.End(entity);
		CriticalDamageDefence2.End(entity);
		Penetrate0.End(entity);
		Penetrate1.End(entity);
		Penetrate2.End(entity);
		AttackVampire0.End(entity);
		AttackVampire1.End(entity);
		AttackVampire2.End(entity);
		AttackSpeedMultiply0.End(entity);
		AttackSpeedMultiply1.End(entity);
		AttackSpeedMultiply2.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		HPMax0.Clear();
		HPMax1.Clear();
		HPMax2.Clear();
		MPMax0.Clear();
		MPMax1.Clear();
		MPMax2.Clear();
		SPMax0.Clear();
		SPMax1.Clear();
		SPMax2.Clear();
		HPRegenerate0.Clear();
		HPRegenerate1.Clear();
		HPRegenerate2.Clear();
		MPRegenerate0.Clear();
		MPRegenerate1.Clear();
		MPRegenerate2.Clear();
		SPRegenerate0.Clear();
		SPRegenerate1.Clear();
		SPRegenerate2.Clear();
		PhysicsAttack0.Clear();
		PhysicsAttack1.Clear();
		PhysicsAttack2.Clear();
		PhysicsDefence0.Clear();
		PhysicsDefence1.Clear();
		PhysicsDefence2.Clear();
		MagicAttack0.Clear();
		MagicAttack1.Clear();
		MagicAttack2.Clear();
		MagicDefence0.Clear();
		MagicDefence1.Clear();
		MagicDefence2.Clear();
		MoveSpeed0.Clear();
		MoveSpeed1.Clear();
		MoveSpeed2.Clear();
		CriticalHit0.Clear();
		CriticalHit1.Clear();
		CriticalHit2.Clear();
		CriticalMiss0.Clear();
		CriticalMiss1.Clear();
		CriticalMiss2.Clear();
		CriticalHitRate0.Clear();
		CriticalHitRate1.Clear();
		CriticalHitRate2.Clear();
		CriticalMissRate0.Clear();
		CriticalMissRate1.Clear();
		CriticalMissRate2.Clear();
		CriticalDamageAttack0.Clear();
		CriticalDamageAttack1.Clear();
		CriticalDamageAttack2.Clear();
		CriticalDamageDefence0.Clear();
		CriticalDamageDefence1.Clear();
		CriticalDamageDefence2.Clear();
		Penetrate0.Clear();
		Penetrate1.Clear();
		Penetrate2.Clear();
		AttackVampire0.Clear();
		AttackVampire1.Clear();
		AttackVampire2.Clear();
		AttackSpeedMultiply0.Clear();
		AttackSpeedMultiply1.Clear();
		AttackSpeedMultiply2.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		HPMax0.RegisterAsChild(channelMask, this, childList);
		HPMax1.RegisterAsChild(channelMask, this, childList);
		HPMax2.RegisterAsChild(channelMask, this, childList);
		MPMax0.RegisterAsChild(channelMask, this, childList);
		MPMax1.RegisterAsChild(channelMask, this, childList);
		MPMax2.RegisterAsChild(channelMask, this, childList);
		SPMax0.RegisterAsChild(channelMask, this, childList);
		SPMax1.RegisterAsChild(channelMask, this, childList);
		SPMax2.RegisterAsChild(channelMask, this, childList);
		HPRegenerate0.RegisterAsChild(channelMask, this, childList);
		HPRegenerate1.RegisterAsChild(channelMask, this, childList);
		HPRegenerate2.RegisterAsChild(channelMask, this, childList);
		MPRegenerate0.RegisterAsChild(channelMask, this, childList);
		MPRegenerate1.RegisterAsChild(channelMask, this, childList);
		MPRegenerate2.RegisterAsChild(channelMask, this, childList);
		SPRegenerate0.RegisterAsChild(channelMask, this, childList);
		SPRegenerate1.RegisterAsChild(channelMask, this, childList);
		SPRegenerate2.RegisterAsChild(channelMask, this, childList);
		PhysicsAttack0.RegisterAsChild(channelMask, this, childList);
		PhysicsAttack1.RegisterAsChild(channelMask, this, childList);
		PhysicsAttack2.RegisterAsChild(channelMask, this, childList);
		PhysicsDefence0.RegisterAsChild(channelMask, this, childList);
		PhysicsDefence1.RegisterAsChild(channelMask, this, childList);
		PhysicsDefence2.RegisterAsChild(channelMask, this, childList);
		MagicAttack0.RegisterAsChild(channelMask, this, childList);
		MagicAttack1.RegisterAsChild(channelMask, this, childList);
		MagicAttack2.RegisterAsChild(channelMask, this, childList);
		MagicDefence0.RegisterAsChild(channelMask, this, childList);
		MagicDefence1.RegisterAsChild(channelMask, this, childList);
		MagicDefence2.RegisterAsChild(channelMask, this, childList);
		MoveSpeed0.RegisterAsChild(channelMask, this, childList);
		MoveSpeed1.RegisterAsChild(channelMask, this, childList);
		MoveSpeed2.RegisterAsChild(channelMask, this, childList);
		CriticalHit0.RegisterAsChild(channelMask, this, childList);
		CriticalHit1.RegisterAsChild(channelMask, this, childList);
		CriticalHit2.RegisterAsChild(channelMask, this, childList);
		CriticalMiss0.RegisterAsChild(channelMask, this, childList);
		CriticalMiss1.RegisterAsChild(channelMask, this, childList);
		CriticalMiss2.RegisterAsChild(channelMask, this, childList);
		CriticalHitRate0.RegisterAsChild(channelMask, this, childList);
		CriticalHitRate1.RegisterAsChild(channelMask, this, childList);
		CriticalHitRate2.RegisterAsChild(channelMask, this, childList);
		CriticalMissRate0.RegisterAsChild(channelMask, this, childList);
		CriticalMissRate1.RegisterAsChild(channelMask, this, childList);
		CriticalMissRate2.RegisterAsChild(channelMask, this, childList);
		CriticalDamageAttack0.RegisterAsChild(channelMask, this, childList);
		CriticalDamageAttack1.RegisterAsChild(channelMask, this, childList);
		CriticalDamageAttack2.RegisterAsChild(channelMask, this, childList);
		CriticalDamageDefence0.RegisterAsChild(channelMask, this, childList);
		CriticalDamageDefence1.RegisterAsChild(channelMask, this, childList);
		CriticalDamageDefence2.RegisterAsChild(channelMask, this, childList);
		Penetrate0.RegisterAsChild(channelMask, this, childList);
		Penetrate1.RegisterAsChild(channelMask, this, childList);
		Penetrate2.RegisterAsChild(channelMask, this, childList);
		AttackVampire0.RegisterAsChild(channelMask, this, childList);
		AttackVampire1.RegisterAsChild(channelMask, this, childList);
		AttackVampire2.RegisterAsChild(channelMask, this, childList);
		AttackSpeedMultiply0.RegisterAsChild(channelMask, this, childList);
		AttackSpeedMultiply1.RegisterAsChild(channelMask, this, childList);
		AttackSpeedMultiply2.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator GameUnitIndexProperty(ReceiveDataGameUnitIndexProperty data)
	{
		GameUnitIndexProperty value = new GameUnitIndexProperty();
		value.HPMax0 = data.HPMax0;
		value.HPMax1 = data.HPMax1;
		value.HPMax2 = data.HPMax2;
		value.MPMax0 = data.MPMax0;
		value.MPMax1 = data.MPMax1;
		value.MPMax2 = data.MPMax2;
		value.SPMax0 = data.SPMax0;
		value.SPMax1 = data.SPMax1;
		value.SPMax2 = data.SPMax2;
		value.HPRegenerate0 = data.HPRegenerate0;
		value.HPRegenerate1 = data.HPRegenerate1;
		value.HPRegenerate2 = data.HPRegenerate2;
		value.MPRegenerate0 = data.MPRegenerate0;
		value.MPRegenerate1 = data.MPRegenerate1;
		value.MPRegenerate2 = data.MPRegenerate2;
		value.SPRegenerate0 = data.SPRegenerate0;
		value.SPRegenerate1 = data.SPRegenerate1;
		value.SPRegenerate2 = data.SPRegenerate2;
		value.PhysicsAttack0 = data.PhysicsAttack0;
		value.PhysicsAttack1 = data.PhysicsAttack1;
		value.PhysicsAttack2 = data.PhysicsAttack2;
		value.PhysicsDefence0 = data.PhysicsDefence0;
		value.PhysicsDefence1 = data.PhysicsDefence1;
		value.PhysicsDefence2 = data.PhysicsDefence2;
		value.MagicAttack0 = data.MagicAttack0;
		value.MagicAttack1 = data.MagicAttack1;
		value.MagicAttack2 = data.MagicAttack2;
		value.MagicDefence0 = data.MagicDefence0;
		value.MagicDefence1 = data.MagicDefence1;
		value.MagicDefence2 = data.MagicDefence2;
		value.MoveSpeed0 = data.MoveSpeed0;
		value.MoveSpeed1 = data.MoveSpeed1;
		value.MoveSpeed2 = data.MoveSpeed2;
		value.CriticalHit0 = data.CriticalHit0;
		value.CriticalHit1 = data.CriticalHit1;
		value.CriticalHit2 = data.CriticalHit2;
		value.CriticalMiss0 = data.CriticalMiss0;
		value.CriticalMiss1 = data.CriticalMiss1;
		value.CriticalMiss2 = data.CriticalMiss2;
		value.CriticalHitRate0 = data.CriticalHitRate0;
		value.CriticalHitRate1 = data.CriticalHitRate1;
		value.CriticalHitRate2 = data.CriticalHitRate2;
		value.CriticalMissRate0 = data.CriticalMissRate0;
		value.CriticalMissRate1 = data.CriticalMissRate1;
		value.CriticalMissRate2 = data.CriticalMissRate2;
		value.CriticalDamageAttack0 = data.CriticalDamageAttack0;
		value.CriticalDamageAttack1 = data.CriticalDamageAttack1;
		value.CriticalDamageAttack2 = data.CriticalDamageAttack2;
		value.CriticalDamageDefence0 = data.CriticalDamageDefence0;
		value.CriticalDamageDefence1 = data.CriticalDamageDefence1;
		value.CriticalDamageDefence2 = data.CriticalDamageDefence2;
		value.Penetrate0 = data.Penetrate0;
		value.Penetrate1 = data.Penetrate1;
		value.Penetrate2 = data.Penetrate2;
		value.AttackVampire0 = data.AttackVampire0;
		value.AttackVampire1 = data.AttackVampire1;
		value.AttackVampire2 = data.AttackVampire2;
		value.AttackSpeedMultiply0 = data.AttackSpeedMultiply0;
		value.AttackSpeedMultiply1 = data.AttackSpeedMultiply1;
		value.AttackSpeedMultiply2 = data.AttackSpeedMultiply2;
		return value;
	}
}

public class ReceiveDataHeroSpellProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 5;
	public ViReceiveDataForeignKey<OwnSpellStruct> Info = new ViReceiveDataForeignKey<OwnSpellStruct>();
	public ViReceiveDataForeignKey<ViSpellStruct> WorkingInfo = new ViReceiveDataForeignKey<ViSpellStruct>();
	public ViReceiveDataInt16 Level = new ViReceiveDataInt16();
	public ViReceiveDataInt32 LevelValue = new ViReceiveDataInt32();
	public ViReceiveDataInt16 SetupIdx = new ViReceiveDataInt16();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		Info.Start(channelMask, IS, entity);
		WorkingInfo.Start(channelMask, IS, entity);
		Level.Start(channelMask, IS, entity);
		LevelValue.Start(channelMask, IS, entity);
		SetupIdx.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		Info.End(entity);
		WorkingInfo.End(entity);
		Level.End(entity);
		LevelValue.End(entity);
		SetupIdx.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		Info.Clear();
		WorkingInfo.Clear();
		Level.Clear();
		LevelValue.Clear();
		SetupIdx.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		Info.RegisterAsChild(channelMask, this, childList);
		WorkingInfo.RegisterAsChild(channelMask, this, childList);
		Level.RegisterAsChild(channelMask, this, childList);
		LevelValue.RegisterAsChild(channelMask, this, childList);
		SetupIdx.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator HeroSpellProperty(ReceiveDataHeroSpellProperty data)
	{
		HeroSpellProperty value = new HeroSpellProperty();
		value.Info = data.Info;
		value.WorkingInfo = data.WorkingInfo;
		value.Level = data.Level;
		value.LevelValue = data.LevelValue;
		value.SetupIdx = data.SetupIdx;
		return value;
	}
}

public class ReceiveDataHeroSpellArrayProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 50;
	public static readonly int Length = 10;
	//
	public int GetLength() { return Length; }
	//
	public ReceiveDataHeroSpellProperty E0 = new ReceiveDataHeroSpellProperty();
	public ReceiveDataHeroSpellProperty E1 = new ReceiveDataHeroSpellProperty();
	public ReceiveDataHeroSpellProperty E2 = new ReceiveDataHeroSpellProperty();
	public ReceiveDataHeroSpellProperty E3 = new ReceiveDataHeroSpellProperty();
	public ReceiveDataHeroSpellProperty E4 = new ReceiveDataHeroSpellProperty();
	public ReceiveDataHeroSpellProperty E5 = new ReceiveDataHeroSpellProperty();
	public ReceiveDataHeroSpellProperty E6 = new ReceiveDataHeroSpellProperty();
	public ReceiveDataHeroSpellProperty E7 = new ReceiveDataHeroSpellProperty();
	public ReceiveDataHeroSpellProperty E8 = new ReceiveDataHeroSpellProperty();
	public ReceiveDataHeroSpellProperty E9 = new ReceiveDataHeroSpellProperty();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		E0.Start(channelMask, IS, entity);
		E1.Start(channelMask, IS, entity);
		E2.Start(channelMask, IS, entity);
		E3.Start(channelMask, IS, entity);
		E4.Start(channelMask, IS, entity);
		E5.Start(channelMask, IS, entity);
		E6.Start(channelMask, IS, entity);
		E7.Start(channelMask, IS, entity);
		E8.Start(channelMask, IS, entity);
		E9.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		E0.End(entity);
		E1.End(entity);
		E2.End(entity);
		E3.End(entity);
		E4.End(entity);
		E5.End(entity);
		E6.End(entity);
		E7.End(entity);
		E8.End(entity);
		E9.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		E0.Clear();
		E1.Clear();
		E2.Clear();
		E3.Clear();
		E4.Clear();
		E5.Clear();
		E6.Clear();
		E7.Clear();
		E8.Clear();
		E9.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		E0.RegisterAsChild(channelMask, this, childList);
		E1.RegisterAsChild(channelMask, this, childList);
		E2.RegisterAsChild(channelMask, this, childList);
		E3.RegisterAsChild(channelMask, this, childList);
		E4.RegisterAsChild(channelMask, this, childList);
		E5.RegisterAsChild(channelMask, this, childList);
		E6.RegisterAsChild(channelMask, this, childList);
		E7.RegisterAsChild(channelMask, this, childList);
		E8.RegisterAsChild(channelMask, this, childList);
		E9.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator HeroSpellArrayProperty(ReceiveDataHeroSpellArrayProperty data)
	{
		HeroSpellArrayProperty value = new HeroSpellArrayProperty();
		value.E0 = data.E0;
		value.E1 = data.E1;
		value.E2 = data.E2;
		value.E3 = data.E3;
		value.E4 = data.E4;
		value.E5 = data.E5;
		value.E6 = data.E6;
		value.E7 = data.E7;
		value.E8 = data.E8;
		value.E9 = data.E9;
		return value;
	}
	public ReceiveDataHeroSpellProperty this[int index]
	{
		get
		{
			switch(index)
			{
				case 0:
					return E0;
				case 1:
					return E1;
				case 2:
					return E2;
				case 3:
					return E3;
				case 4:
					return E4;
				case 5:
					return E5;
				case 6:
					return E6;
				case 7:
					return E7;
				case 8:
					return E8;
				case 9:
					return E9;
			}
			ViDebuger.Error("");
			return E0;
		}
	}
}

public class ReceiveDataHeroProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 177;
	public ViReceiveDataString Note = new ViReceiveDataString();
	public ViReceiveDataForeignKey<HeroStruct> Info = new ViReceiveDataForeignKey<HeroStruct>();
	public ViReceiveDataInt16 Level = new ViReceiveDataInt16();
	public ViReceiveDataInt64 XP = new ViReceiveDataInt64();
	public ViReceiveDataInt32 FightPower = new ViReceiveDataInt32();
	public ReceiveDataHeroSpellArrayProperty SpellList = new ReceiveDataHeroSpellArrayProperty();
	public ReceiveDataHeroEquipArrayProperty EquipList = new ReceiveDataHeroEquipArrayProperty();
	public ViReceiveDataUInt8 FaceType = new ViReceiveDataUInt8();
	public ViReceiveDataUInt8 HairType = new ViReceiveDataUInt8();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		Note.Start(channelMask, IS, entity);
		Info.Start(channelMask, IS, entity);
		Level.Start(channelMask, IS, entity);
		XP.Start(channelMask, IS, entity);
		FightPower.Start(channelMask, IS, entity);
		SpellList.Start(channelMask, IS, entity);
		EquipList.Start(channelMask, IS, entity);
		FaceType.Start(channelMask, IS, entity);
		HairType.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		Note.End(entity);
		Info.End(entity);
		Level.End(entity);
		XP.End(entity);
		FightPower.End(entity);
		SpellList.End(entity);
		EquipList.End(entity);
		FaceType.End(entity);
		HairType.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		Note.Clear();
		Info.Clear();
		Level.Clear();
		XP.Clear();
		FightPower.Clear();
		SpellList.Clear();
		EquipList.Clear();
		FaceType.Clear();
		HairType.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		Note.RegisterAsChild(channelMask, this, childList);
		Info.RegisterAsChild(channelMask, this, childList);
		Level.RegisterAsChild(channelMask, this, childList);
		XP.RegisterAsChild(channelMask, this, childList);
		FightPower.RegisterAsChild(channelMask, this, childList);
		SpellList.RegisterAsChild(channelMask, this, childList);
		EquipList.RegisterAsChild(channelMask, this, childList);
		FaceType.RegisterAsChild(channelMask, this, childList);
		HairType.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator HeroProperty(ReceiveDataHeroProperty data)
	{
		HeroProperty value = new HeroProperty();
		value.Note = data.Note;
		value.Info = data.Info;
		value.Level = data.Level;
		value.XP = data.XP;
		value.FightPower = data.FightPower;
		value.SpellList = data.SpellList;
		value.EquipList = data.EquipList;
		value.FaceType = data.FaceType;
		value.HairType = data.HairType;
		return value;
	}
}

public class ReceiveDataSpaceRecordProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 3;
	public ViReceiveDataInt8 Score = new ViReceiveDataInt8();
	public ViReceiveDataInt32 WinCount = new ViReceiveDataInt32();
	public ViReceiveDataInt32 Count = new ViReceiveDataInt32();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		Score.Start(channelMask, IS, entity);
		WinCount.Start(channelMask, IS, entity);
		Count.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		Score.End(entity);
		WinCount.End(entity);
		Count.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		Score.Clear();
		WinCount.Clear();
		Count.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		Score.RegisterAsChild(channelMask, this, childList);
		WinCount.RegisterAsChild(channelMask, this, childList);
		Count.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator SpaceRecordProperty(ReceiveDataSpaceRecordProperty data)
	{
		SpaceRecordProperty value = new SpaceRecordProperty();
		value.Score = data.Score;
		value.WinCount = data.WinCount;
		value.Count = data.Count;
		return value;
	}
}

public class ReceiveDataSpaceBirthControllerProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 7;
	public ViReceiveDataUInt8 State = new ViReceiveDataUInt8();
	public ViReceiveDataInt16 ReserveCount = new ViReceiveDataInt16();
	public ViReceiveDataVector3 Position = new ViReceiveDataVector3();
	public ViReceiveDataUInt8 Faction = new ViReceiveDataUInt8();
	public ViReceiveDataInt64 FactionStartTime = new ViReceiveDataInt64();
	public ViReceiveDataPtr<UInt64Property> Team = new ViReceiveDataPtr<UInt64Property>();
	public ViReceiveDataInt16 Level = new ViReceiveDataInt16();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		State.Start(channelMask, IS, entity);
		ReserveCount.Start(channelMask, IS, entity);
		Position.Start(channelMask, IS, entity);
		Faction.Start(channelMask, IS, entity);
		FactionStartTime.Start(channelMask, IS, entity);
		Team.Start(channelMask, IS, entity);
		Level.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		State.End(entity);
		ReserveCount.End(entity);
		Position.End(entity);
		Faction.End(entity);
		FactionStartTime.End(entity);
		Team.End(entity);
		Level.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		State.Clear();
		ReserveCount.Clear();
		Position.Clear();
		Faction.Clear();
		FactionStartTime.Clear();
		Team.Clear();
		Level.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		State.RegisterAsChild(channelMask, this, childList);
		ReserveCount.RegisterAsChild(channelMask, this, childList);
		Position.RegisterAsChild(channelMask, this, childList);
		Faction.RegisterAsChild(channelMask, this, childList);
		FactionStartTime.RegisterAsChild(channelMask, this, childList);
		Team.RegisterAsChild(channelMask, this, childList);
		Level.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator SpaceBirthControllerProperty(ReceiveDataSpaceBirthControllerProperty data)
	{
		SpaceBirthControllerProperty value = new SpaceBirthControllerProperty();
		value.State = data.State;
		value.ReserveCount = data.ReserveCount;
		value.Position = data.Position;
		value.Faction = data.Faction;
		value.FactionStartTime = data.FactionStartTime;
		value.Team = data.Team;
		value.Level = data.Level;
		return value;
	}
}

public class ReceiveDataSpaceBirthControllerShowProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 2;
	public ViReceiveDataUInt32 Show = new ViReceiveDataUInt32();
	public ViReceiveDataVector3 Position = new ViReceiveDataVector3();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		Show.Start(channelMask, IS, entity);
		Position.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		Show.End(entity);
		Position.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		Show.Clear();
		Position.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		Show.RegisterAsChild(channelMask, this, childList);
		Position.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator SpaceBirthControllerShowProperty(ReceiveDataSpaceBirthControllerShowProperty data)
	{
		SpaceBirthControllerShowProperty value = new SpaceBirthControllerShowProperty();
		value.Show = data.Show;
		value.Position = data.Position;
		return value;
	}
}

public class ReceiveDataSpaceEventCacheProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 5;
	public ViReceiveDataForeignKey<SpaceEventStruct> Info = new ViReceiveDataForeignKey<SpaceEventStruct>();
	public ViReceiveDataUInt8 Faction = new ViReceiveDataUInt8();
	public ViReceiveDataInt64 Time = new ViReceiveDataInt64();
	public ViReceiveDataVector3 Position = new ViReceiveDataVector3();
	public ViReceiveDataFloat Yaw = new ViReceiveDataFloat();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		Info.Start(channelMask, IS, entity);
		Faction.Start(channelMask, IS, entity);
		Time.Start(channelMask, IS, entity);
		Position.Start(channelMask, IS, entity);
		Yaw.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		Info.End(entity);
		Faction.End(entity);
		Time.End(entity);
		Position.End(entity);
		Yaw.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		Info.Clear();
		Faction.Clear();
		Time.Clear();
		Position.Clear();
		Yaw.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		Info.RegisterAsChild(channelMask, this, childList);
		Faction.RegisterAsChild(channelMask, this, childList);
		Time.RegisterAsChild(channelMask, this, childList);
		Position.RegisterAsChild(channelMask, this, childList);
		Yaw.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator SpaceEventCacheProperty(ReceiveDataSpaceEventCacheProperty data)
	{
		SpaceEventCacheProperty value = new SpaceEventCacheProperty();
		value.Info = data.Info;
		value.Faction = data.Faction;
		value.Time = data.Time;
		value.Position = data.Position;
		value.Yaw = data.Yaw;
		return value;
	}
}

public class ReceiveDataSpaceEventProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 3;
	public ViReceiveDataUInt8 Faction = new ViReceiveDataUInt8();
	public ViReceiveDataInt64 Time = new ViReceiveDataInt64();
	public ViReceiveDataInt16 Count = new ViReceiveDataInt16();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		Faction.Start(channelMask, IS, entity);
		Time.Start(channelMask, IS, entity);
		Count.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		Faction.End(entity);
		Time.End(entity);
		Count.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		Faction.Clear();
		Time.Clear();
		Count.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		Faction.RegisterAsChild(channelMask, this, childList);
		Time.RegisterAsChild(channelMask, this, childList);
		Count.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator SpaceEventProperty(ReceiveDataSpaceEventProperty data)
	{
		SpaceEventProperty value = new SpaceEventProperty();
		value.Faction = data.Faction;
		value.Time = data.Time;
		value.Count = data.Count;
		return value;
	}
}

public class ReceiveDataSpaceBlockSlotProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 5;
	public ViReceiveDataInt16 X = new ViReceiveDataInt16();
	public ViReceiveDataInt16 Y = new ViReceiveDataInt16();
	public ViReceiveDataForeignKey<SpaceBlockSlotStruct> Info = new ViReceiveDataForeignKey<SpaceBlockSlotStruct>();
	public ViReceiveDataUInt8 State = new ViReceiveDataUInt8();
	public ViReceiveDataInt64 RecoverTime = new ViReceiveDataInt64();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		X.Start(channelMask, IS, entity);
		Y.Start(channelMask, IS, entity);
		Info.Start(channelMask, IS, entity);
		State.Start(channelMask, IS, entity);
		RecoverTime.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		X.End(entity);
		Y.End(entity);
		Info.End(entity);
		State.End(entity);
		RecoverTime.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		X.Clear();
		Y.Clear();
		Info.Clear();
		State.Clear();
		RecoverTime.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		X.RegisterAsChild(channelMask, this, childList);
		Y.RegisterAsChild(channelMask, this, childList);
		Info.RegisterAsChild(channelMask, this, childList);
		State.RegisterAsChild(channelMask, this, childList);
		RecoverTime.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator SpaceBlockSlotProperty(ReceiveDataSpaceBlockSlotProperty data)
	{
		SpaceBlockSlotProperty value = new SpaceBlockSlotProperty();
		value.X = data.X;
		value.Y = data.Y;
		value.Info = data.Info;
		value.State = data.State;
		value.RecoverTime = data.RecoverTime;
		return value;
	}
}

public class ReceiveDataSpaceHideSlotProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 5;
	public ViReceiveDataInt16 X = new ViReceiveDataInt16();
	public ViReceiveDataInt16 Y = new ViReceiveDataInt16();
	public ViReceiveDataForeignKey<SpaceHideSlotStruct> Info = new ViReceiveDataForeignKey<SpaceHideSlotStruct>();
	public ViReceiveDataUInt8 State = new ViReceiveDataUInt8();
	public ViReceiveDataInt64 RecoverTime = new ViReceiveDataInt64();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		X.Start(channelMask, IS, entity);
		Y.Start(channelMask, IS, entity);
		Info.Start(channelMask, IS, entity);
		State.Start(channelMask, IS, entity);
		RecoverTime.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		X.End(entity);
		Y.End(entity);
		Info.End(entity);
		State.End(entity);
		RecoverTime.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		X.Clear();
		Y.Clear();
		Info.Clear();
		State.Clear();
		RecoverTime.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		X.RegisterAsChild(channelMask, this, childList);
		Y.RegisterAsChild(channelMask, this, childList);
		Info.RegisterAsChild(channelMask, this, childList);
		State.RegisterAsChild(channelMask, this, childList);
		RecoverTime.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator SpaceHideSlotProperty(ReceiveDataSpaceHideSlotProperty data)
	{
		SpaceHideSlotProperty value = new SpaceHideSlotProperty();
		value.X = data.X;
		value.Y = data.Y;
		value.Info = data.Info;
		value.State = data.State;
		value.RecoverTime = data.RecoverTime;
		return value;
	}
}

public class ReceiveDataSpacePlayerMemberProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 10;
	public ReceiveDataPlayerIdentificationProperty Identification = new ReceiveDataPlayerIdentificationProperty();
	public ViReceiveDataUInt8 ClientState = new ViReceiveDataUInt8();
	public ViReceiveDataFloat LoadProgress = new ViReceiveDataFloat();
	public ViReceiveDataUInt8 ClientSpaceCompleted = new ViReceiveDataUInt8();
	public ViReceiveDataString Guild = new ViReceiveDataString();
	public ViReceiveDataInt16 Level = new ViReceiveDataInt16();
	public ViReceiveDataUInt8 Faction = new ViReceiveDataUInt8();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		Identification.Start(channelMask, IS, entity);
		ClientState.Start(channelMask, IS, entity);
		LoadProgress.Start(channelMask, IS, entity);
		ClientSpaceCompleted.Start(channelMask, IS, entity);
		Guild.Start(channelMask, IS, entity);
		Level.Start(channelMask, IS, entity);
		Faction.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		Identification.End(entity);
		ClientState.End(entity);
		LoadProgress.End(entity);
		ClientSpaceCompleted.End(entity);
		Guild.End(entity);
		Level.End(entity);
		Faction.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		Identification.Clear();
		ClientState.Clear();
		LoadProgress.Clear();
		ClientSpaceCompleted.Clear();
		Guild.Clear();
		Level.Clear();
		Faction.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		Identification.RegisterAsChild(channelMask, this, childList);
		ClientState.RegisterAsChild(channelMask, this, childList);
		LoadProgress.RegisterAsChild(channelMask, this, childList);
		ClientSpaceCompleted.RegisterAsChild(channelMask, this, childList);
		Guild.RegisterAsChild(channelMask, this, childList);
		Level.RegisterAsChild(channelMask, this, childList);
		Faction.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator SpacePlayerMemberProperty(ReceiveDataSpacePlayerMemberProperty data)
	{
		SpacePlayerMemberProperty value = new SpacePlayerMemberProperty();
		value.Identification = data.Identification;
		value.ClientState = data.ClientState;
		value.LoadProgress = data.LoadProgress;
		value.ClientSpaceCompleted = data.ClientSpaceCompleted;
		value.Guild = data.Guild;
		value.Level = data.Level;
		value.Faction = data.Faction;
		return value;
	}
}

public class ReceiveDataSpaceHeroMemberProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 8;
	public ReceiveDataPlayerIdentificationProperty Identification = new ReceiveDataPlayerIdentificationProperty();
	public ViReceiveDataForeignKey<HeroStruct> Info = new ViReceiveDataForeignKey<HeroStruct>();
	public ViReceiveDataString Guild = new ViReceiveDataString();
	public ViReceiveDataInt16 Level = new ViReceiveDataInt16();
	public ViReceiveDataUInt8 Faction = new ViReceiveDataUInt8();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		Identification.Start(channelMask, IS, entity);
		Info.Start(channelMask, IS, entity);
		Guild.Start(channelMask, IS, entity);
		Level.Start(channelMask, IS, entity);
		Faction.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		Identification.End(entity);
		Info.End(entity);
		Guild.End(entity);
		Level.End(entity);
		Faction.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		Identification.Clear();
		Info.Clear();
		Guild.Clear();
		Level.Clear();
		Faction.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		Identification.RegisterAsChild(channelMask, this, childList);
		Info.RegisterAsChild(channelMask, this, childList);
		Guild.RegisterAsChild(channelMask, this, childList);
		Level.RegisterAsChild(channelMask, this, childList);
		Faction.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator SpaceHeroMemberProperty(ReceiveDataSpaceHeroMemberProperty data)
	{
		SpaceHeroMemberProperty value = new SpaceHeroMemberProperty();
		value.Identification = data.Identification;
		value.Info = data.Info;
		value.Guild = data.Guild;
		value.Level = data.Level;
		value.Faction = data.Faction;
		return value;
	}
}

public class ReceiveDataSpaceHeroLevelRandomEffectProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 3;
	public static readonly int Length = 3;
	//
	public int GetLength() { return Length; }
	//
	public ViReceiveDataUInt32 E0 = new ViReceiveDataUInt32();
	public ViReceiveDataUInt32 E1 = new ViReceiveDataUInt32();
	public ViReceiveDataUInt32 E2 = new ViReceiveDataUInt32();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		E0.Start(channelMask, IS, entity);
		E1.Start(channelMask, IS, entity);
		E2.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		E0.End(entity);
		E1.End(entity);
		E2.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		E0.Clear();
		E1.Clear();
		E2.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		E0.RegisterAsChild(channelMask, this, childList);
		E1.RegisterAsChild(channelMask, this, childList);
		E2.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator SpaceHeroLevelRandomEffectProperty(ReceiveDataSpaceHeroLevelRandomEffectProperty data)
	{
		SpaceHeroLevelRandomEffectProperty value = new SpaceHeroLevelRandomEffectProperty();
		value.E0 = data.E0;
		value.E1 = data.E1;
		value.E2 = data.E2;
		return value;
	}
	public ViReceiveDataUInt32 this[int index]
	{
		get
		{
			switch(index)
			{
				case 0:
					return E0;
				case 1:
					return E1;
				case 2:
					return E2;
			}
			ViDebuger.Error("");
			return E0;
		}
	}
}

public class ReceiveDataSpaceDamageOutProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 8;
	public ReceiveDataPlayerIdentificationProperty Identification = new ReceiveDataPlayerIdentificationProperty();
	public ViReceiveDataInt16 Level = new ViReceiveDataInt16();
	public ViReceiveDataUInt8 Faction = new ViReceiveDataUInt8();
	public ViReceiveDataInt64 CurrentDamageOut = new ViReceiveDataInt64();
	public ViReceiveDataInt64 AccumulateDamageOut = new ViReceiveDataInt64();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		Identification.Start(channelMask, IS, entity);
		Level.Start(channelMask, IS, entity);
		Faction.Start(channelMask, IS, entity);
		CurrentDamageOut.Start(channelMask, IS, entity);
		AccumulateDamageOut.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		Identification.End(entity);
		Level.End(entity);
		Faction.End(entity);
		CurrentDamageOut.End(entity);
		AccumulateDamageOut.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		Identification.Clear();
		Level.Clear();
		Faction.Clear();
		CurrentDamageOut.Clear();
		AccumulateDamageOut.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		Identification.RegisterAsChild(channelMask, this, childList);
		Level.RegisterAsChild(channelMask, this, childList);
		Faction.RegisterAsChild(channelMask, this, childList);
		CurrentDamageOut.RegisterAsChild(channelMask, this, childList);
		AccumulateDamageOut.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator SpaceDamageOutProperty(ReceiveDataSpaceDamageOutProperty data)
	{
		SpaceDamageOutProperty value = new SpaceDamageOutProperty();
		value.Identification = data.Identification;
		value.Level = data.Level;
		value.Faction = data.Faction;
		value.CurrentDamageOut = data.CurrentDamageOut;
		value.AccumulateDamageOut = data.AccumulateDamageOut;
		return value;
	}
}

public class ReceiveDataSpaceFactionHeroMemberProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 4;
	public ViReceiveDataUInt32 ActionState = new ViReceiveDataUInt32();
	public ViReceiveDataInt32 HP = new ViReceiveDataInt32();
	public ViReceiveDataInt32 HPMax = new ViReceiveDataInt32();
	public ViReceiveDataVector3 Position = new ViReceiveDataVector3();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		ActionState.Start(channelMask, IS, entity);
		HP.Start(channelMask, IS, entity);
		HPMax.Start(channelMask, IS, entity);
		Position.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		ActionState.End(entity);
		HP.End(entity);
		HPMax.End(entity);
		Position.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		ActionState.Clear();
		HP.Clear();
		HPMax.Clear();
		Position.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		ActionState.RegisterAsChild(channelMask, this, childList);
		HP.RegisterAsChild(channelMask, this, childList);
		HPMax.RegisterAsChild(channelMask, this, childList);
		Position.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator SpaceFactionHeroMemberProperty(ReceiveDataSpaceFactionHeroMemberProperty data)
	{
		SpaceFactionHeroMemberProperty value = new SpaceFactionHeroMemberProperty();
		value.ActionState = data.ActionState;
		value.HP = data.HP;
		value.HPMax = data.HPMax;
		value.Position = data.Position;
		return value;
	}
}

public class ReceiveDataPublicSpaceEnterMemberProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 10;
	public ReceiveDataPlayerIdentificationProperty Identification = new ReceiveDataPlayerIdentificationProperty();
	public ViReceiveDataUInt8 Gender = new ViReceiveDataUInt8();
	public ViReceiveDataUInt8 FactionIdx = new ViReceiveDataUInt8();
	public ViReceiveDataString Guild = new ViReceiveDataString();
	public ViReceiveDataInt16 Level = new ViReceiveDataInt16();
	public ViReceiveDataInt64 EnterTime = new ViReceiveDataInt64();
	public ViReceiveDataUInt8 Ready = new ViReceiveDataUInt8();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		Identification.Start(channelMask, IS, entity);
		Gender.Start(channelMask, IS, entity);
		FactionIdx.Start(channelMask, IS, entity);
		Guild.Start(channelMask, IS, entity);
		Level.Start(channelMask, IS, entity);
		EnterTime.Start(channelMask, IS, entity);
		Ready.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		Identification.End(entity);
		Gender.End(entity);
		FactionIdx.End(entity);
		Guild.End(entity);
		Level.End(entity);
		EnterTime.End(entity);
		Ready.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		Identification.Clear();
		Gender.Clear();
		FactionIdx.Clear();
		Guild.Clear();
		Level.Clear();
		EnterTime.Clear();
		Ready.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		Identification.RegisterAsChild(channelMask, this, childList);
		Gender.RegisterAsChild(channelMask, this, childList);
		FactionIdx.RegisterAsChild(channelMask, this, childList);
		Guild.RegisterAsChild(channelMask, this, childList);
		Level.RegisterAsChild(channelMask, this, childList);
		EnterTime.RegisterAsChild(channelMask, this, childList);
		Ready.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator PublicSpaceEnterMemberProperty(ReceiveDataPublicSpaceEnterMemberProperty data)
	{
		PublicSpaceEnterMemberProperty value = new PublicSpaceEnterMemberProperty();
		value.Identification = data.Identification;
		value.Gender = data.Gender;
		value.FactionIdx = data.FactionIdx;
		value.Guild = data.Guild;
		value.Level = data.Level;
		value.EnterTime = data.EnterTime;
		value.Ready = data.Ready;
		return value;
	}
}

public class ReceiveDataPublicSpaceEnterGroupMemberProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 6;
	public ReceiveDataPlayerIdentificationProperty Identification = new ReceiveDataPlayerIdentificationProperty();
	public ViReceiveDataInt16 Level = new ViReceiveDataInt16();
	public ViReceiveDataUInt8 FactionIdx = new ViReceiveDataUInt8();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		Identification.Start(channelMask, IS, entity);
		Level.Start(channelMask, IS, entity);
		FactionIdx.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		Identification.End(entity);
		Level.End(entity);
		FactionIdx.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		Identification.Clear();
		Level.Clear();
		FactionIdx.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		Identification.RegisterAsChild(channelMask, this, childList);
		Level.RegisterAsChild(channelMask, this, childList);
		FactionIdx.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator PublicSpaceEnterGroupMemberProperty(ReceiveDataPublicSpaceEnterGroupMemberProperty data)
	{
		PublicSpaceEnterGroupMemberProperty value = new PublicSpaceEnterGroupMemberProperty();
		value.Identification = data.Identification;
		value.Level = data.Level;
		value.FactionIdx = data.FactionIdx;
		return value;
	}
}

public class ReceiveDataPublicSpaceEnterGroupMemberArrayProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 60;
	public static readonly int Length = 10;
	//
	public int GetLength() { return Length; }
	//
	public ReceiveDataPublicSpaceEnterGroupMemberProperty E0 = new ReceiveDataPublicSpaceEnterGroupMemberProperty();
	public ReceiveDataPublicSpaceEnterGroupMemberProperty E1 = new ReceiveDataPublicSpaceEnterGroupMemberProperty();
	public ReceiveDataPublicSpaceEnterGroupMemberProperty E2 = new ReceiveDataPublicSpaceEnterGroupMemberProperty();
	public ReceiveDataPublicSpaceEnterGroupMemberProperty E3 = new ReceiveDataPublicSpaceEnterGroupMemberProperty();
	public ReceiveDataPublicSpaceEnterGroupMemberProperty E4 = new ReceiveDataPublicSpaceEnterGroupMemberProperty();
	public ReceiveDataPublicSpaceEnterGroupMemberProperty E5 = new ReceiveDataPublicSpaceEnterGroupMemberProperty();
	public ReceiveDataPublicSpaceEnterGroupMemberProperty E6 = new ReceiveDataPublicSpaceEnterGroupMemberProperty();
	public ReceiveDataPublicSpaceEnterGroupMemberProperty E7 = new ReceiveDataPublicSpaceEnterGroupMemberProperty();
	public ReceiveDataPublicSpaceEnterGroupMemberProperty E8 = new ReceiveDataPublicSpaceEnterGroupMemberProperty();
	public ReceiveDataPublicSpaceEnterGroupMemberProperty E9 = new ReceiveDataPublicSpaceEnterGroupMemberProperty();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		E0.Start(channelMask, IS, entity);
		E1.Start(channelMask, IS, entity);
		E2.Start(channelMask, IS, entity);
		E3.Start(channelMask, IS, entity);
		E4.Start(channelMask, IS, entity);
		E5.Start(channelMask, IS, entity);
		E6.Start(channelMask, IS, entity);
		E7.Start(channelMask, IS, entity);
		E8.Start(channelMask, IS, entity);
		E9.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		E0.End(entity);
		E1.End(entity);
		E2.End(entity);
		E3.End(entity);
		E4.End(entity);
		E5.End(entity);
		E6.End(entity);
		E7.End(entity);
		E8.End(entity);
		E9.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		E0.Clear();
		E1.Clear();
		E2.Clear();
		E3.Clear();
		E4.Clear();
		E5.Clear();
		E6.Clear();
		E7.Clear();
		E8.Clear();
		E9.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		E0.RegisterAsChild(channelMask, this, childList);
		E1.RegisterAsChild(channelMask, this, childList);
		E2.RegisterAsChild(channelMask, this, childList);
		E3.RegisterAsChild(channelMask, this, childList);
		E4.RegisterAsChild(channelMask, this, childList);
		E5.RegisterAsChild(channelMask, this, childList);
		E6.RegisterAsChild(channelMask, this, childList);
		E7.RegisterAsChild(channelMask, this, childList);
		E8.RegisterAsChild(channelMask, this, childList);
		E9.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator PublicSpaceEnterGroupMemberArrayProperty(ReceiveDataPublicSpaceEnterGroupMemberArrayProperty data)
	{
		PublicSpaceEnterGroupMemberArrayProperty value = new PublicSpaceEnterGroupMemberArrayProperty();
		value.E0 = data.E0;
		value.E1 = data.E1;
		value.E2 = data.E2;
		value.E3 = data.E3;
		value.E4 = data.E4;
		value.E5 = data.E5;
		value.E6 = data.E6;
		value.E7 = data.E7;
		value.E8 = data.E8;
		value.E9 = data.E9;
		return value;
	}
	public ReceiveDataPublicSpaceEnterGroupMemberProperty this[int index]
	{
		get
		{
			switch(index)
			{
				case 0:
					return E0;
				case 1:
					return E1;
				case 2:
					return E2;
				case 3:
					return E3;
				case 4:
					return E4;
				case 5:
					return E5;
				case 6:
					return E6;
				case 7:
					return E7;
				case 8:
					return E8;
				case 9:
					return E9;
			}
			ViDebuger.Error("");
			return E0;
		}
	}
}

public class ReceiveDataPublicSpaceEnterGroupProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 72;
	public ViReceiveDataString Name = new ViReceiveDataString();
	public ViReceiveDataForeignKey<SpaceStruct> Space = new ViReceiveDataForeignKey<SpaceStruct>();
	public ViReceiveDataInt64 StartTime = new ViReceiveDataInt64();
	public ReceiveDataPlayerIdentificationProperty Leader = new ReceiveDataPlayerIdentificationProperty();
	public ReceiveDataPublicSpaceEnterGroupMemberArrayProperty MemberList = new ReceiveDataPublicSpaceEnterGroupMemberArrayProperty();
	public ViReceiveDataInt8 FactionCount = new ViReceiveDataInt8();
	public ViReceiveDataInt16 FactionMemberCount = new ViReceiveDataInt16();
	public ViReceiveDataInt16 MemberCount = new ViReceiveDataInt16();
	public ViReceiveDataInt16 WatcherCount = new ViReceiveDataInt16();
	public ViReceiveDataUInt8 HasPassword = new ViReceiveDataUInt8();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		Name.Start(channelMask, IS, entity);
		Space.Start(channelMask, IS, entity);
		StartTime.Start(channelMask, IS, entity);
		Leader.Start(channelMask, IS, entity);
		MemberList.Start(channelMask, IS, entity);
		FactionCount.Start(channelMask, IS, entity);
		FactionMemberCount.Start(channelMask, IS, entity);
		MemberCount.Start(channelMask, IS, entity);
		WatcherCount.Start(channelMask, IS, entity);
		HasPassword.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		Name.End(entity);
		Space.End(entity);
		StartTime.End(entity);
		Leader.End(entity);
		MemberList.End(entity);
		FactionCount.End(entity);
		FactionMemberCount.End(entity);
		MemberCount.End(entity);
		WatcherCount.End(entity);
		HasPassword.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		Name.Clear();
		Space.Clear();
		StartTime.Clear();
		Leader.Clear();
		MemberList.Clear();
		FactionCount.Clear();
		FactionMemberCount.Clear();
		MemberCount.Clear();
		WatcherCount.Clear();
		HasPassword.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		Name.RegisterAsChild(channelMask, this, childList);
		Space.RegisterAsChild(channelMask, this, childList);
		StartTime.RegisterAsChild(channelMask, this, childList);
		Leader.RegisterAsChild(channelMask, this, childList);
		MemberList.RegisterAsChild(channelMask, this, childList);
		FactionCount.RegisterAsChild(channelMask, this, childList);
		FactionMemberCount.RegisterAsChild(channelMask, this, childList);
		MemberCount.RegisterAsChild(channelMask, this, childList);
		WatcherCount.RegisterAsChild(channelMask, this, childList);
		HasPassword.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator PublicSpaceEnterGroupProperty(ReceiveDataPublicSpaceEnterGroupProperty data)
	{
		PublicSpaceEnterGroupProperty value = new PublicSpaceEnterGroupProperty();
		value.Name = data.Name;
		value.Space = data.Space;
		value.StartTime = data.StartTime;
		value.Leader = data.Leader;
		value.MemberList = data.MemberList;
		value.FactionCount = data.FactionCount;
		value.FactionMemberCount = data.FactionMemberCount;
		value.MemberCount = data.MemberCount;
		value.WatcherCount = data.WatcherCount;
		value.HasPassword = data.HasPassword;
		return value;
	}
}

public class ReceiveDataGoalProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 5;
	public ViReceiveDataForeignKey<GoalStruct> Info = new ViReceiveDataForeignKey<GoalStruct>();
	public ViReceiveDataInt64 CompleteTime1970 = new ViReceiveDataInt64();
	public ViReceiveDataUInt8 State = new ViReceiveDataUInt8();
	public ViReceiveDataInt32 Value = new ViReceiveDataInt32();
	public ViReceiveDataInt32 ValueSup = new ViReceiveDataInt32();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		Info.Start(channelMask, IS, entity);
		CompleteTime1970.Start(channelMask, IS, entity);
		State.Start(channelMask, IS, entity);
		Value.Start(channelMask, IS, entity);
		ValueSup.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		Info.End(entity);
		CompleteTime1970.End(entity);
		State.End(entity);
		Value.End(entity);
		ValueSup.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		Info.Clear();
		CompleteTime1970.Clear();
		State.Clear();
		Value.Clear();
		ValueSup.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		Info.RegisterAsChild(channelMask, this, childList);
		CompleteTime1970.RegisterAsChild(channelMask, this, childList);
		State.RegisterAsChild(channelMask, this, childList);
		Value.RegisterAsChild(channelMask, this, childList);
		ValueSup.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator GoalProperty(ReceiveDataGoalProperty data)
	{
		GoalProperty value = new GoalProperty();
		value.Info = data.Info;
		value.CompleteTime1970 = data.CompleteTime1970;
		value.State = data.State;
		value.Value = data.Value;
		value.ValueSup = data.ValueSup;
		return value;
	}
}

public class ReceiveDataClientSettingForPlayerProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 4;
	public ViReceiveDataFloat CameraDistance = new ViReceiveDataFloat();
	public ViReceiveDataUInt8 MinMap = new ViReceiveDataUInt8();
	public ViReceiveDataUInt8 MouseControllerType = new ViReceiveDataUInt8();
	public ViReceiveDataUInt8 AutoAct = new ViReceiveDataUInt8();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		CameraDistance.Start(channelMask, IS, entity);
		MinMap.Start(channelMask, IS, entity);
		MouseControllerType.Start(channelMask, IS, entity);
		AutoAct.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		CameraDistance.End(entity);
		MinMap.End(entity);
		MouseControllerType.End(entity);
		AutoAct.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		CameraDistance.Clear();
		MinMap.Clear();
		MouseControllerType.Clear();
		AutoAct.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		CameraDistance.RegisterAsChild(channelMask, this, childList);
		MinMap.RegisterAsChild(channelMask, this, childList);
		MouseControllerType.RegisterAsChild(channelMask, this, childList);
		AutoAct.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator ClientSettingForPlayerProperty(ReceiveDataClientSettingForPlayerProperty data)
	{
		ClientSettingForPlayerProperty value = new ClientSettingForPlayerProperty();
		value.CameraDistance = data.CameraDistance;
		value.MinMap = data.MinMap;
		value.MouseControllerType = data.MouseControllerType;
		value.AutoAct = data.AutoAct;
		return value;
	}
}

public class ReceiveDataClientSettingForAccountProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 16;
	public ViReceiveDataUInt8 SpellLODLevel = new ViReceiveDataUInt8();
	public ViReceiveDataUInt8 GraphicsMainLevel = new ViReceiveDataUInt8();
	public ViReceiveDataUInt8 GraphicsMirrorCharacter = new ViReceiveDataUInt8();
	public ViReceiveDataUInt8 GraphicsMirrorScene = new ViReceiveDataUInt8();
	public ViReceiveDataUInt8 GraphicsShadow = new ViReceiveDataUInt8();
	public ViReceiveDataUInt8 GraphicsColorEnhance = new ViReceiveDataUInt8();
	public ViReceiveDataUInt8 GraphicsBloom = new ViReceiveDataUInt8();
	public ViReceiveDataUInt8 GraphicsDistort = new ViReceiveDataUInt8();
	public ViReceiveDataFloat CameraShakeScale = new ViReceiveDataFloat();
	public ViReceiveDataUInt8 FPSLevel = new ViReceiveDataUInt8();
	public ViReceiveDataUInt8 EnergySave = new ViReceiveDataUInt8();
	public ViReceiveDataFloat MainVolume = new ViReceiveDataFloat();
	public ViReceiveDataFloat MusicVolume = new ViReceiveDataFloat();
	public ViReceiveDataFloat SoundVolume = new ViReceiveDataFloat();
	public ViReceiveDataFloat CharacterVolume = new ViReceiveDataFloat();
	public ViReceiveDataFloat AutoLockFocusScale = new ViReceiveDataFloat();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		SpellLODLevel.Start(channelMask, IS, entity);
		GraphicsMainLevel.Start(channelMask, IS, entity);
		GraphicsMirrorCharacter.Start(channelMask, IS, entity);
		GraphicsMirrorScene.Start(channelMask, IS, entity);
		GraphicsShadow.Start(channelMask, IS, entity);
		GraphicsColorEnhance.Start(channelMask, IS, entity);
		GraphicsBloom.Start(channelMask, IS, entity);
		GraphicsDistort.Start(channelMask, IS, entity);
		CameraShakeScale.Start(channelMask, IS, entity);
		FPSLevel.Start(channelMask, IS, entity);
		EnergySave.Start(channelMask, IS, entity);
		MainVolume.Start(channelMask, IS, entity);
		MusicVolume.Start(channelMask, IS, entity);
		SoundVolume.Start(channelMask, IS, entity);
		CharacterVolume.Start(channelMask, IS, entity);
		AutoLockFocusScale.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		SpellLODLevel.End(entity);
		GraphicsMainLevel.End(entity);
		GraphicsMirrorCharacter.End(entity);
		GraphicsMirrorScene.End(entity);
		GraphicsShadow.End(entity);
		GraphicsColorEnhance.End(entity);
		GraphicsBloom.End(entity);
		GraphicsDistort.End(entity);
		CameraShakeScale.End(entity);
		FPSLevel.End(entity);
		EnergySave.End(entity);
		MainVolume.End(entity);
		MusicVolume.End(entity);
		SoundVolume.End(entity);
		CharacterVolume.End(entity);
		AutoLockFocusScale.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		SpellLODLevel.Clear();
		GraphicsMainLevel.Clear();
		GraphicsMirrorCharacter.Clear();
		GraphicsMirrorScene.Clear();
		GraphicsShadow.Clear();
		GraphicsColorEnhance.Clear();
		GraphicsBloom.Clear();
		GraphicsDistort.Clear();
		CameraShakeScale.Clear();
		FPSLevel.Clear();
		EnergySave.Clear();
		MainVolume.Clear();
		MusicVolume.Clear();
		SoundVolume.Clear();
		CharacterVolume.Clear();
		AutoLockFocusScale.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		SpellLODLevel.RegisterAsChild(channelMask, this, childList);
		GraphicsMainLevel.RegisterAsChild(channelMask, this, childList);
		GraphicsMirrorCharacter.RegisterAsChild(channelMask, this, childList);
		GraphicsMirrorScene.RegisterAsChild(channelMask, this, childList);
		GraphicsShadow.RegisterAsChild(channelMask, this, childList);
		GraphicsColorEnhance.RegisterAsChild(channelMask, this, childList);
		GraphicsBloom.RegisterAsChild(channelMask, this, childList);
		GraphicsDistort.RegisterAsChild(channelMask, this, childList);
		CameraShakeScale.RegisterAsChild(channelMask, this, childList);
		FPSLevel.RegisterAsChild(channelMask, this, childList);
		EnergySave.RegisterAsChild(channelMask, this, childList);
		MainVolume.RegisterAsChild(channelMask, this, childList);
		MusicVolume.RegisterAsChild(channelMask, this, childList);
		SoundVolume.RegisterAsChild(channelMask, this, childList);
		CharacterVolume.RegisterAsChild(channelMask, this, childList);
		AutoLockFocusScale.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator ClientSettingForAccountProperty(ReceiveDataClientSettingForAccountProperty data)
	{
		ClientSettingForAccountProperty value = new ClientSettingForAccountProperty();
		value.SpellLODLevel = data.SpellLODLevel;
		value.GraphicsMainLevel = data.GraphicsMainLevel;
		value.GraphicsMirrorCharacter = data.GraphicsMirrorCharacter;
		value.GraphicsMirrorScene = data.GraphicsMirrorScene;
		value.GraphicsShadow = data.GraphicsShadow;
		value.GraphicsColorEnhance = data.GraphicsColorEnhance;
		value.GraphicsBloom = data.GraphicsBloom;
		value.GraphicsDistort = data.GraphicsDistort;
		value.CameraShakeScale = data.CameraShakeScale;
		value.FPSLevel = data.FPSLevel;
		value.EnergySave = data.EnergySave;
		value.MainVolume = data.MainVolume;
		value.MusicVolume = data.MusicVolume;
		value.SoundVolume = data.SoundVolume;
		value.CharacterVolume = data.CharacterVolume;
		value.AutoLockFocusScale = data.AutoLockFocusScale;
		return value;
	}
}

public class ReceiveDataClientDeviceProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 16;
	public ViReceiveDataUInt8 Platform = new ViReceiveDataUInt8();
	public ViReceiveDataString DeviceName = new ViReceiveDataString();
	public ViReceiveDataString DeviceModel = new ViReceiveDataString();
	public ViReceiveDataString DeviceUniqueIdentifier = new ViReceiveDataString();
	public ViReceiveDataString OperatingSystem = new ViReceiveDataString();
	public ViReceiveDataInt8 OperatingSystemAPILevel = new ViReceiveDataInt8();
	public ViReceiveDataInt32 SystemMemorySize = new ViReceiveDataInt32();
	public ViReceiveDataString ProcessorType = new ViReceiveDataString();
	public ViReceiveDataInt8 ProcessorCount = new ViReceiveDataInt8();
	public ViReceiveDataInt32 ProcessorFrequency = new ViReceiveDataInt32();
	public ViReceiveDataString GraphicsDeviceName = new ViReceiveDataString();
	public ViReceiveDataString GraphicsDeviceVendor = new ViReceiveDataString();
	public ViReceiveDataString GraphicsDeviceVersion = new ViReceiveDataString();
	public ViReceiveDataInt32 GraphicsMemorySize = new ViReceiveDataInt32();
	public ViReceiveDataInt16 ScreenX = new ViReceiveDataInt16();
	public ViReceiveDataInt16 ScreenY = new ViReceiveDataInt16();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		Platform.Start(channelMask, IS, entity);
		DeviceName.Start(channelMask, IS, entity);
		DeviceModel.Start(channelMask, IS, entity);
		DeviceUniqueIdentifier.Start(channelMask, IS, entity);
		OperatingSystem.Start(channelMask, IS, entity);
		OperatingSystemAPILevel.Start(channelMask, IS, entity);
		SystemMemorySize.Start(channelMask, IS, entity);
		ProcessorType.Start(channelMask, IS, entity);
		ProcessorCount.Start(channelMask, IS, entity);
		ProcessorFrequency.Start(channelMask, IS, entity);
		GraphicsDeviceName.Start(channelMask, IS, entity);
		GraphicsDeviceVendor.Start(channelMask, IS, entity);
		GraphicsDeviceVersion.Start(channelMask, IS, entity);
		GraphicsMemorySize.Start(channelMask, IS, entity);
		ScreenX.Start(channelMask, IS, entity);
		ScreenY.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		Platform.End(entity);
		DeviceName.End(entity);
		DeviceModel.End(entity);
		DeviceUniqueIdentifier.End(entity);
		OperatingSystem.End(entity);
		OperatingSystemAPILevel.End(entity);
		SystemMemorySize.End(entity);
		ProcessorType.End(entity);
		ProcessorCount.End(entity);
		ProcessorFrequency.End(entity);
		GraphicsDeviceName.End(entity);
		GraphicsDeviceVendor.End(entity);
		GraphicsDeviceVersion.End(entity);
		GraphicsMemorySize.End(entity);
		ScreenX.End(entity);
		ScreenY.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		Platform.Clear();
		DeviceName.Clear();
		DeviceModel.Clear();
		DeviceUniqueIdentifier.Clear();
		OperatingSystem.Clear();
		OperatingSystemAPILevel.Clear();
		SystemMemorySize.Clear();
		ProcessorType.Clear();
		ProcessorCount.Clear();
		ProcessorFrequency.Clear();
		GraphicsDeviceName.Clear();
		GraphicsDeviceVendor.Clear();
		GraphicsDeviceVersion.Clear();
		GraphicsMemorySize.Clear();
		ScreenX.Clear();
		ScreenY.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		Platform.RegisterAsChild(channelMask, this, childList);
		DeviceName.RegisterAsChild(channelMask, this, childList);
		DeviceModel.RegisterAsChild(channelMask, this, childList);
		DeviceUniqueIdentifier.RegisterAsChild(channelMask, this, childList);
		OperatingSystem.RegisterAsChild(channelMask, this, childList);
		OperatingSystemAPILevel.RegisterAsChild(channelMask, this, childList);
		SystemMemorySize.RegisterAsChild(channelMask, this, childList);
		ProcessorType.RegisterAsChild(channelMask, this, childList);
		ProcessorCount.RegisterAsChild(channelMask, this, childList);
		ProcessorFrequency.RegisterAsChild(channelMask, this, childList);
		GraphicsDeviceName.RegisterAsChild(channelMask, this, childList);
		GraphicsDeviceVendor.RegisterAsChild(channelMask, this, childList);
		GraphicsDeviceVersion.RegisterAsChild(channelMask, this, childList);
		GraphicsMemorySize.RegisterAsChild(channelMask, this, childList);
		ScreenX.RegisterAsChild(channelMask, this, childList);
		ScreenY.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator ClientDeviceProperty(ReceiveDataClientDeviceProperty data)
	{
		ClientDeviceProperty value = new ClientDeviceProperty();
		value.Platform = data.Platform;
		value.DeviceName = data.DeviceName;
		value.DeviceModel = data.DeviceModel;
		value.DeviceUniqueIdentifier = data.DeviceUniqueIdentifier;
		value.OperatingSystem = data.OperatingSystem;
		value.OperatingSystemAPILevel = data.OperatingSystemAPILevel;
		value.SystemMemorySize = data.SystemMemorySize;
		value.ProcessorType = data.ProcessorType;
		value.ProcessorCount = data.ProcessorCount;
		value.ProcessorFrequency = data.ProcessorFrequency;
		value.GraphicsDeviceName = data.GraphicsDeviceName;
		value.GraphicsDeviceVendor = data.GraphicsDeviceVendor;
		value.GraphicsDeviceVersion = data.GraphicsDeviceVersion;
		value.GraphicsMemorySize = data.GraphicsMemorySize;
		value.ScreenX = data.ScreenX;
		value.ScreenY = data.ScreenY;
		return value;
	}
}

public class ReceiveDataFriendProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 2;
	public ViReceiveDataString Name = new ViReceiveDataString();
	public ViReceiveDataString Note = new ViReceiveDataString();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		Name.Start(channelMask, IS, entity);
		Note.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		Name.End(entity);
		Note.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		Name.Clear();
		Note.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		Name.RegisterAsChild(channelMask, this, childList);
		Note.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator FriendProperty(ReceiveDataFriendProperty data)
	{
		FriendProperty value = new FriendProperty();
		value.Name = data.Name;
		value.Note = data.Note;
		return value;
	}
}

public class ReceiveDataFriendViewProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 14;
	public ReceiveDataPlayerIdentificationProperty Identification = new ReceiveDataPlayerIdentificationProperty();
	public ViReceiveDataInt16 Level = new ViReceiveDataInt16();
	public ViReceiveDataUInt8 Gender = new ViReceiveDataUInt8();
	public ViReceiveDataUInt8 Class = new ViReceiveDataUInt8();
	public ViReceiveDataInt32 FightPower = new ViReceiveDataInt32();
	public ViReceiveDataUInt8 ClientState = new ViReceiveDataUInt8();
	public ViReceiveDataUInt8 HasGuild = new ViReceiveDataUInt8();
	public ViReceiveDataString GuildName = new ViReceiveDataString();
	public ViReceiveDataUInt8 Photo = new ViReceiveDataUInt8();
	public ViReceiveDataInt64 LastActiveTime1970 = new ViReceiveDataInt64();
	public ViReceiveDataUInt32 Space = new ViReceiveDataUInt32();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		Identification.Start(channelMask, IS, entity);
		Level.Start(channelMask, IS, entity);
		Gender.Start(channelMask, IS, entity);
		Class.Start(channelMask, IS, entity);
		FightPower.Start(channelMask, IS, entity);
		ClientState.Start(channelMask, IS, entity);
		HasGuild.Start(channelMask, IS, entity);
		GuildName.Start(channelMask, IS, entity);
		Photo.Start(channelMask, IS, entity);
		LastActiveTime1970.Start(channelMask, IS, entity);
		Space.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		Identification.End(entity);
		Level.End(entity);
		Gender.End(entity);
		Class.End(entity);
		FightPower.End(entity);
		ClientState.End(entity);
		HasGuild.End(entity);
		GuildName.End(entity);
		Photo.End(entity);
		LastActiveTime1970.End(entity);
		Space.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		Identification.Clear();
		Level.Clear();
		Gender.Clear();
		Class.Clear();
		FightPower.Clear();
		ClientState.Clear();
		HasGuild.Clear();
		GuildName.Clear();
		Photo.Clear();
		LastActiveTime1970.Clear();
		Space.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		Identification.RegisterAsChild(channelMask, this, childList);
		Level.RegisterAsChild(channelMask, this, childList);
		Gender.RegisterAsChild(channelMask, this, childList);
		Class.RegisterAsChild(channelMask, this, childList);
		FightPower.RegisterAsChild(channelMask, this, childList);
		ClientState.RegisterAsChild(channelMask, this, childList);
		HasGuild.RegisterAsChild(channelMask, this, childList);
		GuildName.RegisterAsChild(channelMask, this, childList);
		Photo.RegisterAsChild(channelMask, this, childList);
		LastActiveTime1970.RegisterAsChild(channelMask, this, childList);
		Space.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator FriendViewProperty(ReceiveDataFriendViewProperty data)
	{
		FriendViewProperty value = new FriendViewProperty();
		value.Identification = data.Identification;
		value.Level = data.Level;
		value.Gender = data.Gender;
		value.Class = data.Class;
		value.FightPower = data.FightPower;
		value.ClientState = data.ClientState;
		value.HasGuild = data.HasGuild;
		value.GuildName = data.GuildName;
		value.Photo = data.Photo;
		value.LastActiveTime1970 = data.LastActiveTime1970;
		value.Space = data.Space;
		return value;
	}
}

public class ReceiveDataFriendInvitorProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 11;
	public ReceiveDataPlayerIdentificationProperty Identification = new ReceiveDataPlayerIdentificationProperty();
	public ViReceiveDataInt16 Level = new ViReceiveDataInt16();
	public ViReceiveDataUInt8 Gender = new ViReceiveDataUInt8();
	public ViReceiveDataUInt8 Class = new ViReceiveDataUInt8();
	public ViReceiveDataInt32 FightPower = new ViReceiveDataInt32();
	public ViReceiveDataUInt8 ClientState = new ViReceiveDataUInt8();
	public ViReceiveDataUInt8 HasGuild = new ViReceiveDataUInt8();
	public ViReceiveDataString GuildName = new ViReceiveDataString();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		Identification.Start(channelMask, IS, entity);
		Level.Start(channelMask, IS, entity);
		Gender.Start(channelMask, IS, entity);
		Class.Start(channelMask, IS, entity);
		FightPower.Start(channelMask, IS, entity);
		ClientState.Start(channelMask, IS, entity);
		HasGuild.Start(channelMask, IS, entity);
		GuildName.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		Identification.End(entity);
		Level.End(entity);
		Gender.End(entity);
		Class.End(entity);
		FightPower.End(entity);
		ClientState.End(entity);
		HasGuild.End(entity);
		GuildName.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		Identification.Clear();
		Level.Clear();
		Gender.Clear();
		Class.Clear();
		FightPower.Clear();
		ClientState.Clear();
		HasGuild.Clear();
		GuildName.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		Identification.RegisterAsChild(channelMask, this, childList);
		Level.RegisterAsChild(channelMask, this, childList);
		Gender.RegisterAsChild(channelMask, this, childList);
		Class.RegisterAsChild(channelMask, this, childList);
		FightPower.RegisterAsChild(channelMask, this, childList);
		ClientState.RegisterAsChild(channelMask, this, childList);
		HasGuild.RegisterAsChild(channelMask, this, childList);
		GuildName.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator FriendInvitorProperty(ReceiveDataFriendInvitorProperty data)
	{
		FriendInvitorProperty value = new FriendInvitorProperty();
		value.Identification = data.Identification;
		value.Level = data.Level;
		value.Gender = data.Gender;
		value.Class = data.Class;
		value.FightPower = data.FightPower;
		value.ClientState = data.ClientState;
		value.HasGuild = data.HasGuild;
		value.GuildName = data.GuildName;
		return value;
	}
}

public class ReceiveDataFriendInviteeProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 11;
	public ReceiveDataPlayerIdentificationProperty Identification = new ReceiveDataPlayerIdentificationProperty();
	public ViReceiveDataInt16 Level = new ViReceiveDataInt16();
	public ViReceiveDataUInt8 Gender = new ViReceiveDataUInt8();
	public ViReceiveDataUInt8 Class = new ViReceiveDataUInt8();
	public ViReceiveDataInt32 FightPower = new ViReceiveDataInt32();
	public ViReceiveDataUInt8 ClientState = new ViReceiveDataUInt8();
	public ViReceiveDataUInt8 HasGuild = new ViReceiveDataUInt8();
	public ViReceiveDataString GuildName = new ViReceiveDataString();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		Identification.Start(channelMask, IS, entity);
		Level.Start(channelMask, IS, entity);
		Gender.Start(channelMask, IS, entity);
		Class.Start(channelMask, IS, entity);
		FightPower.Start(channelMask, IS, entity);
		ClientState.Start(channelMask, IS, entity);
		HasGuild.Start(channelMask, IS, entity);
		GuildName.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		Identification.End(entity);
		Level.End(entity);
		Gender.End(entity);
		Class.End(entity);
		FightPower.End(entity);
		ClientState.End(entity);
		HasGuild.End(entity);
		GuildName.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		Identification.Clear();
		Level.Clear();
		Gender.Clear();
		Class.Clear();
		FightPower.Clear();
		ClientState.Clear();
		HasGuild.Clear();
		GuildName.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		Identification.RegisterAsChild(channelMask, this, childList);
		Level.RegisterAsChild(channelMask, this, childList);
		Gender.RegisterAsChild(channelMask, this, childList);
		Class.RegisterAsChild(channelMask, this, childList);
		FightPower.RegisterAsChild(channelMask, this, childList);
		ClientState.RegisterAsChild(channelMask, this, childList);
		HasGuild.RegisterAsChild(channelMask, this, childList);
		GuildName.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator FriendInviteeProperty(ReceiveDataFriendInviteeProperty data)
	{
		FriendInviteeProperty value = new FriendInviteeProperty();
		value.Identification = data.Identification;
		value.Level = data.Level;
		value.Gender = data.Gender;
		value.Class = data.Class;
		value.FightPower = data.FightPower;
		value.ClientState = data.ClientState;
		value.HasGuild = data.HasGuild;
		value.GuildName = data.GuildName;
		return value;
	}
}

public class ReceiveDataBlackFriendProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 11;
	public ReceiveDataPlayerIdentificationProperty Identification = new ReceiveDataPlayerIdentificationProperty();
	public ViReceiveDataInt16 Level = new ViReceiveDataInt16();
	public ViReceiveDataUInt8 Gender = new ViReceiveDataUInt8();
	public ViReceiveDataUInt8 Class = new ViReceiveDataUInt8();
	public ViReceiveDataInt32 FightPower = new ViReceiveDataInt32();
	public ViReceiveDataUInt8 ClientState = new ViReceiveDataUInt8();
	public ViReceiveDataUInt8 HasGuild = new ViReceiveDataUInt8();
	public ViReceiveDataString GuildName = new ViReceiveDataString();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		Identification.Start(channelMask, IS, entity);
		Level.Start(channelMask, IS, entity);
		Gender.Start(channelMask, IS, entity);
		Class.Start(channelMask, IS, entity);
		FightPower.Start(channelMask, IS, entity);
		ClientState.Start(channelMask, IS, entity);
		HasGuild.Start(channelMask, IS, entity);
		GuildName.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		Identification.End(entity);
		Level.End(entity);
		Gender.End(entity);
		Class.End(entity);
		FightPower.End(entity);
		ClientState.End(entity);
		HasGuild.End(entity);
		GuildName.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		Identification.Clear();
		Level.Clear();
		Gender.Clear();
		Class.Clear();
		FightPower.Clear();
		ClientState.Clear();
		HasGuild.Clear();
		GuildName.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		Identification.RegisterAsChild(channelMask, this, childList);
		Level.RegisterAsChild(channelMask, this, childList);
		Gender.RegisterAsChild(channelMask, this, childList);
		Class.RegisterAsChild(channelMask, this, childList);
		FightPower.RegisterAsChild(channelMask, this, childList);
		ClientState.RegisterAsChild(channelMask, this, childList);
		HasGuild.RegisterAsChild(channelMask, this, childList);
		GuildName.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator BlackFriendProperty(ReceiveDataBlackFriendProperty data)
	{
		BlackFriendProperty value = new BlackFriendProperty();
		value.Identification = data.Identification;
		value.Level = data.Level;
		value.Gender = data.Gender;
		value.Class = data.Class;
		value.FightPower = data.FightPower;
		value.ClientState = data.ClientState;
		value.HasGuild = data.HasGuild;
		value.GuildName = data.GuildName;
		return value;
	}
}

public class ReceiveDataMailProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 39;
	public ViReceiveDataUInt8 State = new ViReceiveDataUInt8();
	public ViReceiveDataUInt8 Type = new ViReceiveDataUInt8();
	public ViReceiveDataInt64 Time1970 = new ViReceiveDataInt64();
	public ViReceiveDataString Title = new ViReceiveDataString();
	public ViReceiveDataString Content = new ViReceiveDataString();
	public ReceiveDataPlayerIdentificationProperty Sender = new ReceiveDataPlayerIdentificationProperty();
	public ViReceiveDataInt64 AttachmentReceiveTime1970 = new ViReceiveDataInt64();
	public ViReceiveDataInt64 AttachmentXP = new ViReceiveDataInt64();
	public ViReceiveDataInt64 AttachmentYinPiao = new ViReceiveDataInt64();
	public ViReceiveDataInt64 AttachmentJinPiao = new ViReceiveDataInt64();
	public ViReceiveDataInt64 AttachmentJinZi = new ViReceiveDataInt64();
	public ReceiveDataScoreArray6Property AttachmentScores = new ReceiveDataScoreArray6Property();
	public ReceiveDataItemCountArray6Property AttachmentItems = new ReceiveDataItemCountArray6Property();
	public ViReceiveDataPtr<ItemProperty> AttachmentItem = new ViReceiveDataPtr<ItemProperty>();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		State.Start(channelMask, IS, entity);
		Type.Start(channelMask, IS, entity);
		Time1970.Start(channelMask, IS, entity);
		Title.Start(channelMask, IS, entity);
		Content.Start(channelMask, IS, entity);
		Sender.Start(channelMask, IS, entity);
		AttachmentReceiveTime1970.Start(channelMask, IS, entity);
		AttachmentXP.Start(channelMask, IS, entity);
		AttachmentYinPiao.Start(channelMask, IS, entity);
		AttachmentJinPiao.Start(channelMask, IS, entity);
		AttachmentJinZi.Start(channelMask, IS, entity);
		AttachmentScores.Start(channelMask, IS, entity);
		AttachmentItems.Start(channelMask, IS, entity);
		AttachmentItem.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		State.End(entity);
		Type.End(entity);
		Time1970.End(entity);
		Title.End(entity);
		Content.End(entity);
		Sender.End(entity);
		AttachmentReceiveTime1970.End(entity);
		AttachmentXP.End(entity);
		AttachmentYinPiao.End(entity);
		AttachmentJinPiao.End(entity);
		AttachmentJinZi.End(entity);
		AttachmentScores.End(entity);
		AttachmentItems.End(entity);
		AttachmentItem.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		State.Clear();
		Type.Clear();
		Time1970.Clear();
		Title.Clear();
		Content.Clear();
		Sender.Clear();
		AttachmentReceiveTime1970.Clear();
		AttachmentXP.Clear();
		AttachmentYinPiao.Clear();
		AttachmentJinPiao.Clear();
		AttachmentJinZi.Clear();
		AttachmentScores.Clear();
		AttachmentItems.Clear();
		AttachmentItem.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		State.RegisterAsChild(channelMask, this, childList);
		Type.RegisterAsChild(channelMask, this, childList);
		Time1970.RegisterAsChild(channelMask, this, childList);
		Title.RegisterAsChild(channelMask, this, childList);
		Content.RegisterAsChild(channelMask, this, childList);
		Sender.RegisterAsChild(channelMask, this, childList);
		AttachmentReceiveTime1970.RegisterAsChild(channelMask, this, childList);
		AttachmentXP.RegisterAsChild(channelMask, this, childList);
		AttachmentYinPiao.RegisterAsChild(channelMask, this, childList);
		AttachmentJinPiao.RegisterAsChild(channelMask, this, childList);
		AttachmentJinZi.RegisterAsChild(channelMask, this, childList);
		AttachmentScores.RegisterAsChild(channelMask, this, childList);
		AttachmentItems.RegisterAsChild(channelMask, this, childList);
		AttachmentItem.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator MailProperty(ReceiveDataMailProperty data)
	{
		MailProperty value = new MailProperty();
		value.State = data.State;
		value.Type = data.Type;
		value.Time1970 = data.Time1970;
		value.Title = data.Title;
		value.Content = data.Content;
		value.Sender = data.Sender;
		value.AttachmentReceiveTime1970 = data.AttachmentReceiveTime1970;
		value.AttachmentXP = data.AttachmentXP;
		value.AttachmentYinPiao = data.AttachmentYinPiao;
		value.AttachmentJinPiao = data.AttachmentJinPiao;
		value.AttachmentJinZi = data.AttachmentJinZi;
		value.AttachmentScores = data.AttachmentScores;
		value.AttachmentItems = data.AttachmentItems;
		value.AttachmentItem = data.AttachmentItem;
		return value;
	}
}

public class ReceiveDataGuildMemberProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 14;
	public ReceiveDataPlayerIdentificationProperty Identification = new ReceiveDataPlayerIdentificationProperty();
	public ViReceiveDataUInt8 Position = new ViReceiveDataUInt8();
	public ViReceiveDataInt16 Level = new ViReceiveDataInt16();
	public ViReceiveDataUInt8 Gender = new ViReceiveDataUInt8();
	public ViReceiveDataInt32 FightPower = new ViReceiveDataInt32();
	public ViReceiveDataInt32 DailyContribution = new ViReceiveDataInt32();
	public ViReceiveDataInt32 TotalContribution = new ViReceiveDataInt32();
	public ViReceiveDataInt32 TotalContributionBadgeCount = new ViReceiveDataInt32();
	public ViReceiveDataUInt8 ClientState = new ViReceiveDataUInt8();
	public ViReceiveDataInt64 LastOnlineTime = new ViReceiveDataInt64();
	public ViReceiveDataInt64 LastOnlineTime1970 = new ViReceiveDataInt64();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		Identification.Start(channelMask, IS, entity);
		Position.Start(channelMask, IS, entity);
		Level.Start(channelMask, IS, entity);
		Gender.Start(channelMask, IS, entity);
		FightPower.Start(channelMask, IS, entity);
		DailyContribution.Start(channelMask, IS, entity);
		TotalContribution.Start(channelMask, IS, entity);
		TotalContributionBadgeCount.Start(channelMask, IS, entity);
		ClientState.Start(channelMask, IS, entity);
		LastOnlineTime.Start(channelMask, IS, entity);
		LastOnlineTime1970.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		Identification.End(entity);
		Position.End(entity);
		Level.End(entity);
		Gender.End(entity);
		FightPower.End(entity);
		DailyContribution.End(entity);
		TotalContribution.End(entity);
		TotalContributionBadgeCount.End(entity);
		ClientState.End(entity);
		LastOnlineTime.End(entity);
		LastOnlineTime1970.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		Identification.Clear();
		Position.Clear();
		Level.Clear();
		Gender.Clear();
		FightPower.Clear();
		DailyContribution.Clear();
		TotalContribution.Clear();
		TotalContributionBadgeCount.Clear();
		ClientState.Clear();
		LastOnlineTime.Clear();
		LastOnlineTime1970.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		Identification.RegisterAsChild(channelMask, this, childList);
		Position.RegisterAsChild(channelMask, this, childList);
		Level.RegisterAsChild(channelMask, this, childList);
		Gender.RegisterAsChild(channelMask, this, childList);
		FightPower.RegisterAsChild(channelMask, this, childList);
		DailyContribution.RegisterAsChild(channelMask, this, childList);
		TotalContribution.RegisterAsChild(channelMask, this, childList);
		TotalContributionBadgeCount.RegisterAsChild(channelMask, this, childList);
		ClientState.RegisterAsChild(channelMask, this, childList);
		LastOnlineTime.RegisterAsChild(channelMask, this, childList);
		LastOnlineTime1970.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator GuildMemberProperty(ReceiveDataGuildMemberProperty data)
	{
		GuildMemberProperty value = new GuildMemberProperty();
		value.Identification = data.Identification;
		value.Position = data.Position;
		value.Level = data.Level;
		value.Gender = data.Gender;
		value.FightPower = data.FightPower;
		value.DailyContribution = data.DailyContribution;
		value.TotalContribution = data.TotalContribution;
		value.TotalContributionBadgeCount = data.TotalContributionBadgeCount;
		value.ClientState = data.ClientState;
		value.LastOnlineTime = data.LastOnlineTime;
		value.LastOnlineTime1970 = data.LastOnlineTime1970;
		return value;
	}
}

public class ReceiveDataGuildMessageProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 10;
	public ViReceiveDataUInt8 Type = new ViReceiveDataUInt8();
	public ViReceiveDataInt64 Time1970 = new ViReceiveDataInt64();
	public ReceiveDataPlayerIdentificationProperty Member = new ReceiveDataPlayerIdentificationProperty();
	public ViReceiveDataInt64 IntValue0 = new ViReceiveDataInt64();
	public ViReceiveDataInt64 IntValue1 = new ViReceiveDataInt64();
	public ViReceiveDataString StringValue0 = new ViReceiveDataString();
	public ViReceiveDataString StringValue1 = new ViReceiveDataString();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		Type.Start(channelMask, IS, entity);
		Time1970.Start(channelMask, IS, entity);
		Member.Start(channelMask, IS, entity);
		IntValue0.Start(channelMask, IS, entity);
		IntValue1.Start(channelMask, IS, entity);
		StringValue0.Start(channelMask, IS, entity);
		StringValue1.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		Type.End(entity);
		Time1970.End(entity);
		Member.End(entity);
		IntValue0.End(entity);
		IntValue1.End(entity);
		StringValue0.End(entity);
		StringValue1.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		Type.Clear();
		Time1970.Clear();
		Member.Clear();
		IntValue0.Clear();
		IntValue1.Clear();
		StringValue0.Clear();
		StringValue1.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		Type.RegisterAsChild(channelMask, this, childList);
		Time1970.RegisterAsChild(channelMask, this, childList);
		Member.RegisterAsChild(channelMask, this, childList);
		IntValue0.RegisterAsChild(channelMask, this, childList);
		IntValue1.RegisterAsChild(channelMask, this, childList);
		StringValue0.RegisterAsChild(channelMask, this, childList);
		StringValue1.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator GuildMessageProperty(ReceiveDataGuildMessageProperty data)
	{
		GuildMessageProperty value = new GuildMessageProperty();
		value.Type = data.Type;
		value.Time1970 = data.Time1970;
		value.Member = data.Member;
		value.IntValue0 = data.IntValue0;
		value.IntValue1 = data.IntValue1;
		value.StringValue0 = data.StringValue0;
		value.StringValue1 = data.StringValue1;
		return value;
	}
}

public class ReceiveDataGuildApplyProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 7;
	public ReceiveDataPlayerIdentificationProperty Identification = new ReceiveDataPlayerIdentificationProperty();
	public ViReceiveDataInt16 Level = new ViReceiveDataInt16();
	public ViReceiveDataUInt8 Gender = new ViReceiveDataUInt8();
	public ViReceiveDataInt32 FightPower = new ViReceiveDataInt32();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		Identification.Start(channelMask, IS, entity);
		Level.Start(channelMask, IS, entity);
		Gender.Start(channelMask, IS, entity);
		FightPower.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		Identification.End(entity);
		Level.End(entity);
		Gender.End(entity);
		FightPower.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		Identification.Clear();
		Level.Clear();
		Gender.Clear();
		FightPower.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		Identification.RegisterAsChild(channelMask, this, childList);
		Level.RegisterAsChild(channelMask, this, childList);
		Gender.RegisterAsChild(channelMask, this, childList);
		FightPower.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator GuildApplyProperty(ReceiveDataGuildApplyProperty data)
	{
		GuildApplyProperty value = new GuildApplyProperty();
		value.Identification = data.Identification;
		value.Level = data.Level;
		value.Gender = data.Gender;
		value.FightPower = data.FightPower;
		return value;
	}
}

public class ReceiveDataGuildActivitySeatProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 2;
	public ViReceiveDataUInt32 Activity = new ViReceiveDataUInt32();
	public ViReceiveDataInt64 Time1970 = new ViReceiveDataInt64();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		Activity.Start(channelMask, IS, entity);
		Time1970.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		Activity.End(entity);
		Time1970.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		Activity.Clear();
		Time1970.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		Activity.RegisterAsChild(channelMask, this, childList);
		Time1970.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator GuildActivitySeatProperty(ReceiveDataGuildActivitySeatProperty data)
	{
		GuildActivitySeatProperty value = new GuildActivitySeatProperty();
		value.Activity = data.Activity;
		value.Time1970 = data.Time1970;
		return value;
	}
}

public class ReceiveDataGuildActivityProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 4;
	public ViReceiveDataUInt64 Leader = new ViReceiveDataUInt64();
	public ViReceiveDataUInt8 State = new ViReceiveDataUInt8();
	public ViReceiveDataInt64 StartTime1970 = new ViReceiveDataInt64();
	public ViReceiveDataInt16 Count = new ViReceiveDataInt16();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		Leader.Start(channelMask, IS, entity);
		State.Start(channelMask, IS, entity);
		StartTime1970.Start(channelMask, IS, entity);
		Count.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		Leader.End(entity);
		State.End(entity);
		StartTime1970.End(entity);
		Count.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		Leader.Clear();
		State.Clear();
		StartTime1970.Clear();
		Count.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		Leader.RegisterAsChild(channelMask, this, childList);
		State.RegisterAsChild(channelMask, this, childList);
		StartTime1970.RegisterAsChild(channelMask, this, childList);
		Count.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator GuildActivityProperty(ReceiveDataGuildActivityProperty data)
	{
		GuildActivityProperty value = new GuildActivityProperty();
		value.Leader = data.Leader;
		value.State = data.State;
		value.StartTime1970 = data.StartTime1970;
		value.Count = data.Count;
		return value;
	}
}

public class ReceiveDataGuildActivityEnterProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 2;
	public ViReceiveDataInt16 EnterCount = new ViReceiveDataInt16();
	public ViReceiveDataInt16 BuyCount = new ViReceiveDataInt16();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		EnterCount.Start(channelMask, IS, entity);
		BuyCount.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		EnterCount.End(entity);
		BuyCount.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		EnterCount.Clear();
		BuyCount.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		EnterCount.RegisterAsChild(channelMask, this, childList);
		BuyCount.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator GuildActivityEnterProperty(ReceiveDataGuildActivityEnterProperty data)
	{
		GuildActivityEnterProperty value = new GuildActivityEnterProperty();
		value.EnterCount = data.EnterCount;
		value.BuyCount = data.BuyCount;
		return value;
	}
}

public class ReceiveDataActivityProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 3;
	public ViReceiveDataUInt8 State = new ViReceiveDataUInt8();
	public ViReceiveDataInt64 EndTime1970 = new ViReceiveDataInt64();
	public ViReceiveDataInt64 Version = new ViReceiveDataInt64();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		State.Start(channelMask, IS, entity);
		EndTime1970.Start(channelMask, IS, entity);
		Version.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		State.End(entity);
		EndTime1970.End(entity);
		Version.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		State.Clear();
		EndTime1970.Clear();
		Version.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		State.RegisterAsChild(channelMask, this, childList);
		EndTime1970.RegisterAsChild(channelMask, this, childList);
		Version.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator ActivityProperty(ReceiveDataActivityProperty data)
	{
		ActivityProperty value = new ActivityProperty();
		value.State = data.State;
		value.EndTime1970 = data.EndTime1970;
		value.Version = data.Version;
		return value;
	}
}

public class ReceiveDataActivityStatisticsProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 4;
	public ViReceiveDataInt64 Version = new ViReceiveDataInt64();
	public ViReceiveDataInt32 EnterCount = new ViReceiveDataInt32();
	public ViReceiveDataInt32 ExistCount = new ViReceiveDataInt32();
	public ViReceiveDataInt32 MaxExistCount = new ViReceiveDataInt32();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		Version.Start(channelMask, IS, entity);
		EnterCount.Start(channelMask, IS, entity);
		ExistCount.Start(channelMask, IS, entity);
		MaxExistCount.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		Version.End(entity);
		EnterCount.End(entity);
		ExistCount.End(entity);
		MaxExistCount.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		Version.Clear();
		EnterCount.Clear();
		ExistCount.Clear();
		MaxExistCount.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		Version.RegisterAsChild(channelMask, this, childList);
		EnterCount.RegisterAsChild(channelMask, this, childList);
		ExistCount.RegisterAsChild(channelMask, this, childList);
		MaxExistCount.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator ActivityStatisticsProperty(ReceiveDataActivityStatisticsProperty data)
	{
		ActivityStatisticsProperty value = new ActivityStatisticsProperty();
		value.Version = data.Version;
		value.EnterCount = data.EnterCount;
		value.ExistCount = data.ExistCount;
		value.MaxExistCount = data.MaxExistCount;
		return value;
	}
}

public class ReceiveDataActivityStatisticsRecordProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 9;
	public ViReceiveDataUInt32 ID = new ViReceiveDataUInt32();
	public ViReceiveDataString Name = new ViReceiveDataString();
	public ViReceiveDataInt64 StartTime = new ViReceiveDataInt64();
	public ViReceiveDataInt64 StartTime1970 = new ViReceiveDataInt64();
	public ViReceiveDataInt64 Duration = new ViReceiveDataInt64();
	public ReceiveDataActivityStatisticsProperty Statistics = new ReceiveDataActivityStatisticsProperty();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		ID.Start(channelMask, IS, entity);
		Name.Start(channelMask, IS, entity);
		StartTime.Start(channelMask, IS, entity);
		StartTime1970.Start(channelMask, IS, entity);
		Duration.Start(channelMask, IS, entity);
		Statistics.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		ID.End(entity);
		Name.End(entity);
		StartTime.End(entity);
		StartTime1970.End(entity);
		Duration.End(entity);
		Statistics.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		ID.Clear();
		Name.Clear();
		StartTime.Clear();
		StartTime1970.Clear();
		Duration.Clear();
		Statistics.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		ID.RegisterAsChild(channelMask, this, childList);
		Name.RegisterAsChild(channelMask, this, childList);
		StartTime.RegisterAsChild(channelMask, this, childList);
		StartTime1970.RegisterAsChild(channelMask, this, childList);
		Duration.RegisterAsChild(channelMask, this, childList);
		Statistics.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator ActivityStatisticsRecordProperty(ReceiveDataActivityStatisticsRecordProperty data)
	{
		ActivityStatisticsRecordProperty value = new ActivityStatisticsRecordProperty();
		value.ID = data.ID;
		value.Name = data.Name;
		value.StartTime = data.StartTime;
		value.StartTime1970 = data.StartTime1970;
		value.Duration = data.Duration;
		value.Statistics = data.Statistics;
		return value;
	}
}

public class ReceiveDataActivityEnterProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 7;
	public ViReceiveDataForeignKey<ActivityStruct> Info = new ViReceiveDataForeignKey<ActivityStruct>();
	public ViReceiveDataInt16 Count = new ViReceiveDataInt16();
	public ViReceiveDataInt64 AccumulateCount = new ViReceiveDataInt64();
	public ViReceiveDataInt64 LastVersion = new ViReceiveDataInt64();
	public ViReceiveDataUInt32 Rank = new ViReceiveDataUInt32();
	public ReceiveDataAccmulateDurationProperty Duration = new ReceiveDataAccmulateDurationProperty();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		Info.Start(channelMask, IS, entity);
		Count.Start(channelMask, IS, entity);
		AccumulateCount.Start(channelMask, IS, entity);
		LastVersion.Start(channelMask, IS, entity);
		Rank.Start(channelMask, IS, entity);
		Duration.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		Info.End(entity);
		Count.End(entity);
		AccumulateCount.End(entity);
		LastVersion.End(entity);
		Rank.End(entity);
		Duration.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		Info.Clear();
		Count.Clear();
		AccumulateCount.Clear();
		LastVersion.Clear();
		Rank.Clear();
		Duration.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		Info.RegisterAsChild(channelMask, this, childList);
		Count.RegisterAsChild(channelMask, this, childList);
		AccumulateCount.RegisterAsChild(channelMask, this, childList);
		LastVersion.RegisterAsChild(channelMask, this, childList);
		Rank.RegisterAsChild(channelMask, this, childList);
		Duration.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator ActivityEnterProperty(ReceiveDataActivityEnterProperty data)
	{
		ActivityEnterProperty value = new ActivityEnterProperty();
		value.Info = data.Info;
		value.Count = data.Count;
		value.AccumulateCount = data.AccumulateCount;
		value.LastVersion = data.LastVersion;
		value.Rank = data.Rank;
		value.Duration = data.Duration;
		return value;
	}
}

public class ReceiveDataPartyMemberProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 18;
	public ReceiveDataPlayerIdentificationProperty Identification = new ReceiveDataPlayerIdentificationProperty();
	public ReceiveDataPlayerIdentificationProperty Recommander = new ReceiveDataPlayerIdentificationProperty();
	public ViReceiveDataUInt8 Ready = new ViReceiveDataUInt8();
	public ViReceiveDataUInt8 AutoReady = new ViReceiveDataUInt8();
	public ViReceiveDataUInt8 Gender = new ViReceiveDataUInt8();
	public ViReceiveDataInt16 Level = new ViReceiveDataInt16();
	public ViReceiveDataUInt8 Online = new ViReceiveDataUInt8();
	public ViReceiveDataUInt8 Class = new ViReceiveDataUInt8();
	public ViReceiveDataUInt16 Power = new ViReceiveDataUInt16();
	public ViReceiveDataUInt8 Channel = new ViReceiveDataUInt8();
	public ViReceiveDataUInt32 SpaceID = new ViReceiveDataUInt32();
	public ViReceiveDataUInt8 KickOutTimes = new ViReceiveDataUInt8();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		Identification.Start(channelMask, IS, entity);
		Recommander.Start(channelMask, IS, entity);
		Ready.Start(channelMask, IS, entity);
		AutoReady.Start(channelMask, IS, entity);
		Gender.Start(channelMask, IS, entity);
		Level.Start(channelMask, IS, entity);
		Online.Start(channelMask, IS, entity);
		Class.Start(channelMask, IS, entity);
		Power.Start(channelMask, IS, entity);
		Channel.Start(channelMask, IS, entity);
		SpaceID.Start(channelMask, IS, entity);
		KickOutTimes.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		Identification.End(entity);
		Recommander.End(entity);
		Ready.End(entity);
		AutoReady.End(entity);
		Gender.End(entity);
		Level.End(entity);
		Online.End(entity);
		Class.End(entity);
		Power.End(entity);
		Channel.End(entity);
		SpaceID.End(entity);
		KickOutTimes.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		Identification.Clear();
		Recommander.Clear();
		Ready.Clear();
		AutoReady.Clear();
		Gender.Clear();
		Level.Clear();
		Online.Clear();
		Class.Clear();
		Power.Clear();
		Channel.Clear();
		SpaceID.Clear();
		KickOutTimes.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		Identification.RegisterAsChild(channelMask, this, childList);
		Recommander.RegisterAsChild(channelMask, this, childList);
		Ready.RegisterAsChild(channelMask, this, childList);
		AutoReady.RegisterAsChild(channelMask, this, childList);
		Gender.RegisterAsChild(channelMask, this, childList);
		Level.RegisterAsChild(channelMask, this, childList);
		Online.RegisterAsChild(channelMask, this, childList);
		Class.RegisterAsChild(channelMask, this, childList);
		Power.RegisterAsChild(channelMask, this, childList);
		Channel.RegisterAsChild(channelMask, this, childList);
		SpaceID.RegisterAsChild(channelMask, this, childList);
		KickOutTimes.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator PartyMemberProperty(ReceiveDataPartyMemberProperty data)
	{
		PartyMemberProperty value = new PartyMemberProperty();
		value.Identification = data.Identification;
		value.Recommander = data.Recommander;
		value.Ready = data.Ready;
		value.AutoReady = data.AutoReady;
		value.Gender = data.Gender;
		value.Level = data.Level;
		value.Online = data.Online;
		value.Class = data.Class;
		value.Power = data.Power;
		value.Channel = data.Channel;
		value.SpaceID = data.SpaceID;
		value.KickOutTimes = data.KickOutTimes;
		return value;
	}
}

public class ReceiveDataPartySpaceMatchProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 5;
	public ViReceiveDataInt32 AverageScore = new ViReceiveDataInt32();
	public ViReceiveDataUInt32 Space = new ViReceiveDataUInt32();
	public ViReceiveDataUInt8 MatchType = new ViReceiveDataUInt8();
	public ViReceiveDataInt64 StartTime = new ViReceiveDataInt64();
	public ViReceiveDataFloat Progress = new ViReceiveDataFloat();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		AverageScore.Start(channelMask, IS, entity);
		Space.Start(channelMask, IS, entity);
		MatchType.Start(channelMask, IS, entity);
		StartTime.Start(channelMask, IS, entity);
		Progress.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		AverageScore.End(entity);
		Space.End(entity);
		MatchType.End(entity);
		StartTime.End(entity);
		Progress.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		AverageScore.Clear();
		Space.Clear();
		MatchType.Clear();
		StartTime.Clear();
		Progress.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		AverageScore.RegisterAsChild(channelMask, this, childList);
		Space.RegisterAsChild(channelMask, this, childList);
		MatchType.RegisterAsChild(channelMask, this, childList);
		StartTime.RegisterAsChild(channelMask, this, childList);
		Progress.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator PartySpaceMatchProperty(ReceiveDataPartySpaceMatchProperty data)
	{
		PartySpaceMatchProperty value = new PartySpaceMatchProperty();
		value.AverageScore = data.AverageScore;
		value.Space = data.Space;
		value.MatchType = data.MatchType;
		value.StartTime = data.StartTime;
		value.Progress = data.Progress;
		return value;
	}
}

public class ReceiveDataPartyInvitorProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 23;
	public ViReceiveDataUInt64 PartyID = new ViReceiveDataUInt64();
	public ReceiveDataPlayerIdentificationProperty Leader = new ReceiveDataPlayerIdentificationProperty();
	public ReceiveDataPartyMemberProperty PlayerDetailLite = new ReceiveDataPartyMemberProperty();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		PartyID.Start(channelMask, IS, entity);
		Leader.Start(channelMask, IS, entity);
		PlayerDetailLite.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		PartyID.End(entity);
		Leader.End(entity);
		PlayerDetailLite.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		PartyID.Clear();
		Leader.Clear();
		PlayerDetailLite.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		PartyID.RegisterAsChild(channelMask, this, childList);
		Leader.RegisterAsChild(channelMask, this, childList);
		PlayerDetailLite.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator PartyInvitorProperty(ReceiveDataPartyInvitorProperty data)
	{
		PartyInvitorProperty value = new PartyInvitorProperty();
		value.PartyID = data.PartyID;
		value.Leader = data.Leader;
		value.PlayerDetailLite = data.PlayerDetailLite;
		return value;
	}
}

public class ReceiveDataPartyPartnerRecordProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 6;
	public ReceiveDataPlayerIdentificationProperty Identification = new ReceiveDataPlayerIdentificationProperty();
	public ViReceiveDataUInt8 Gender = new ViReceiveDataUInt8();
	public ViReceiveDataUInt8 State = new ViReceiveDataUInt8();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		Identification.Start(channelMask, IS, entity);
		Gender.Start(channelMask, IS, entity);
		State.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		Identification.End(entity);
		Gender.End(entity);
		State.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		Identification.Clear();
		Gender.Clear();
		State.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		Identification.RegisterAsChild(channelMask, this, childList);
		Gender.RegisterAsChild(channelMask, this, childList);
		State.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator PartyPartnerRecordProperty(ReceiveDataPartyPartnerRecordProperty data)
	{
		PartyPartnerRecordProperty value = new PartyPartnerRecordProperty();
		value.Identification = data.Identification;
		value.Gender = data.Gender;
		value.State = data.State;
		return value;
	}
}

public class ReceiveDataPartyDetailLite: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 4;
	public ViReceiveDataUInt64 ID = new ViReceiveDataUInt64();
	public ViReceiveDataString Name = new ViReceiveDataString();
	public ViReceiveDataUInt16 MaxPlayer = new ViReceiveDataUInt16();
	public ViReceiveDataUInt16 Type = new ViReceiveDataUInt16();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		ID.Start(channelMask, IS, entity);
		Name.Start(channelMask, IS, entity);
		MaxPlayer.Start(channelMask, IS, entity);
		Type.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		ID.End(entity);
		Name.End(entity);
		MaxPlayer.End(entity);
		Type.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		ID.Clear();
		Name.Clear();
		MaxPlayer.Clear();
		Type.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		ID.RegisterAsChild(channelMask, this, childList);
		Name.RegisterAsChild(channelMask, this, childList);
		MaxPlayer.RegisterAsChild(channelMask, this, childList);
		Type.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator PartyDetailLite(ReceiveDataPartyDetailLite data)
	{
		PartyDetailLite value = new PartyDetailLite();
		value.ID = data.ID;
		value.Name = data.Name;
		value.MaxPlayer = data.MaxPlayer;
		value.Type = data.Type;
		return value;
	}
}

public class ReceiveDataScoreRankStasticsProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 14;
	public ViReceiveDataInt32 Score = new ViReceiveDataInt32();
	public ViReceiveDataUInt32 RankPosition = new ViReceiveDataUInt32();
	public ViReceiveDataUInt32 RankPositionBest = new ViReceiveDataUInt32();
	public ViReceiveDataInt32 MatchScore = new ViReceiveDataInt32();
	public ViReceiveDataInt32 ContinueWinCount = new ViReceiveDataInt32();
	public ViReceiveDataInt32 ContinueLoseCount = new ViReceiveDataInt32();
	public ViReceiveDataInt32 TotalCount = new ViReceiveDataInt32();
	public ViReceiveDataInt32 TotalWinCount = new ViReceiveDataInt32();
	public ViReceiveDataInt32 TotalLoseCount = new ViReceiveDataInt32();
	public ViReceiveDataInt32 VersionCount = new ViReceiveDataInt32();
	public ViReceiveDataInt32 VersionWinCount = new ViReceiveDataInt32();
	public ViReceiveDataInt32 VersionLoseCount = new ViReceiveDataInt32();
	public ViReceiveDataInt64 Version = new ViReceiveDataInt64();
	public ViReceiveDataInt64 RewardVersion = new ViReceiveDataInt64();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		Score.Start(channelMask, IS, entity);
		RankPosition.Start(channelMask, IS, entity);
		RankPositionBest.Start(channelMask, IS, entity);
		MatchScore.Start(channelMask, IS, entity);
		ContinueWinCount.Start(channelMask, IS, entity);
		ContinueLoseCount.Start(channelMask, IS, entity);
		TotalCount.Start(channelMask, IS, entity);
		TotalWinCount.Start(channelMask, IS, entity);
		TotalLoseCount.Start(channelMask, IS, entity);
		VersionCount.Start(channelMask, IS, entity);
		VersionWinCount.Start(channelMask, IS, entity);
		VersionLoseCount.Start(channelMask, IS, entity);
		Version.Start(channelMask, IS, entity);
		RewardVersion.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		Score.End(entity);
		RankPosition.End(entity);
		RankPositionBest.End(entity);
		MatchScore.End(entity);
		ContinueWinCount.End(entity);
		ContinueLoseCount.End(entity);
		TotalCount.End(entity);
		TotalWinCount.End(entity);
		TotalLoseCount.End(entity);
		VersionCount.End(entity);
		VersionWinCount.End(entity);
		VersionLoseCount.End(entity);
		Version.End(entity);
		RewardVersion.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		Score.Clear();
		RankPosition.Clear();
		RankPositionBest.Clear();
		MatchScore.Clear();
		ContinueWinCount.Clear();
		ContinueLoseCount.Clear();
		TotalCount.Clear();
		TotalWinCount.Clear();
		TotalLoseCount.Clear();
		VersionCount.Clear();
		VersionWinCount.Clear();
		VersionLoseCount.Clear();
		Version.Clear();
		RewardVersion.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		Score.RegisterAsChild(channelMask, this, childList);
		RankPosition.RegisterAsChild(channelMask, this, childList);
		RankPositionBest.RegisterAsChild(channelMask, this, childList);
		MatchScore.RegisterAsChild(channelMask, this, childList);
		ContinueWinCount.RegisterAsChild(channelMask, this, childList);
		ContinueLoseCount.RegisterAsChild(channelMask, this, childList);
		TotalCount.RegisterAsChild(channelMask, this, childList);
		TotalWinCount.RegisterAsChild(channelMask, this, childList);
		TotalLoseCount.RegisterAsChild(channelMask, this, childList);
		VersionCount.RegisterAsChild(channelMask, this, childList);
		VersionWinCount.RegisterAsChild(channelMask, this, childList);
		VersionLoseCount.RegisterAsChild(channelMask, this, childList);
		Version.RegisterAsChild(channelMask, this, childList);
		RewardVersion.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator ScoreRankStasticsProperty(ReceiveDataScoreRankStasticsProperty data)
	{
		ScoreRankStasticsProperty value = new ScoreRankStasticsProperty();
		value.Score = data.Score;
		value.RankPosition = data.RankPosition;
		value.RankPositionBest = data.RankPositionBest;
		value.MatchScore = data.MatchScore;
		value.ContinueWinCount = data.ContinueWinCount;
		value.ContinueLoseCount = data.ContinueLoseCount;
		value.TotalCount = data.TotalCount;
		value.TotalWinCount = data.TotalWinCount;
		value.TotalLoseCount = data.TotalLoseCount;
		value.VersionCount = data.VersionCount;
		value.VersionWinCount = data.VersionWinCount;
		value.VersionLoseCount = data.VersionLoseCount;
		value.Version = data.Version;
		value.RewardVersion = data.RewardVersion;
		return value;
	}
}

public class ReceiveDataSpaceMatchProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 3;
	public ViReceiveDataUInt32 Space = new ViReceiveDataUInt32();
	public ViReceiveDataInt32 Size = new ViReceiveDataInt32();
	public ViReceiveDataInt32 PlayerCount = new ViReceiveDataInt32();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		Space.Start(channelMask, IS, entity);
		Size.Start(channelMask, IS, entity);
		PlayerCount.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		Space.End(entity);
		Size.End(entity);
		PlayerCount.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		Space.Clear();
		Size.Clear();
		PlayerCount.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		Space.RegisterAsChild(channelMask, this, childList);
		Size.RegisterAsChild(channelMask, this, childList);
		PlayerCount.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator SpaceMatchProperty(ReceiveDataSpaceMatchProperty data)
	{
		SpaceMatchProperty value = new SpaceMatchProperty();
		value.Space = data.Space;
		value.Size = data.Size;
		value.PlayerCount = data.PlayerCount;
		return value;
	}
}

public class ReceiveDataMatchSpaceMemberScoreProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 3;
	public ViReceiveDataInt32 Score = new ViReceiveDataInt32();
	public ViReceiveDataInt32 PartyScore = new ViReceiveDataInt32();
	public ViReceiveDataInt32 ScoreMod = new ViReceiveDataInt32();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		Score.Start(channelMask, IS, entity);
		PartyScore.Start(channelMask, IS, entity);
		ScoreMod.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		Score.End(entity);
		PartyScore.End(entity);
		ScoreMod.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		Score.Clear();
		PartyScore.Clear();
		ScoreMod.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		Score.RegisterAsChild(channelMask, this, childList);
		PartyScore.RegisterAsChild(channelMask, this, childList);
		ScoreMod.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator MatchSpaceMemberScoreProperty(ReceiveDataMatchSpaceMemberScoreProperty data)
	{
		MatchSpaceMemberScoreProperty value = new MatchSpaceMemberScoreProperty();
		value.Score = data.Score;
		value.PartyScore = data.PartyScore;
		value.ScoreMod = data.ScoreMod;
		return value;
	}
}

public class ReceiveDataSpaceMatchEnterMemberProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 8;
	public ReceiveDataPlayerIdentificationProperty Player = new ReceiveDataPlayerIdentificationProperty();
	public ViReceiveDataUInt8 FactionIdx = new ViReceiveDataUInt8();
	public ViReceiveDataUInt8 Ready = new ViReceiveDataUInt8();
	public ViReceiveDataUInt32 Hero = new ViReceiveDataUInt32();
	public ViReceiveDataUInt8 HeroReady = new ViReceiveDataUInt8();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		Player.Start(channelMask, IS, entity);
		FactionIdx.Start(channelMask, IS, entity);
		Ready.Start(channelMask, IS, entity);
		Hero.Start(channelMask, IS, entity);
		HeroReady.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		Player.End(entity);
		FactionIdx.End(entity);
		Ready.End(entity);
		Hero.End(entity);
		HeroReady.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		Player.Clear();
		FactionIdx.Clear();
		Ready.Clear();
		Hero.Clear();
		HeroReady.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		Player.RegisterAsChild(channelMask, this, childList);
		FactionIdx.RegisterAsChild(channelMask, this, childList);
		Ready.RegisterAsChild(channelMask, this, childList);
		Hero.RegisterAsChild(channelMask, this, childList);
		HeroReady.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator SpaceMatchEnterMemberProperty(ReceiveDataSpaceMatchEnterMemberProperty data)
	{
		SpaceMatchEnterMemberProperty value = new SpaceMatchEnterMemberProperty();
		value.Player = data.Player;
		value.FactionIdx = data.FactionIdx;
		value.Ready = data.Ready;
		value.Hero = data.Hero;
		value.HeroReady = data.HeroReady;
		return value;
	}
}

public class ReceiveDataNotifyProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 2;
	public ViReceiveDataUInt8 State = new ViReceiveDataUInt8();
	public ViReceiveDataInt64 EndTime1970 = new ViReceiveDataInt64();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		State.Start(channelMask, IS, entity);
		EndTime1970.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		State.End(entity);
		EndTime1970.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		State.Clear();
		EndTime1970.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		State.RegisterAsChild(channelMask, this, childList);
		EndTime1970.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator NotifyProperty(ReceiveDataNotifyProperty data)
	{
		NotifyProperty value = new NotifyProperty();
		value.State = data.State;
		value.EndTime1970 = data.EndTime1970;
		return value;
	}
}

public class ReceiveDataCellStateProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 5;
	public ViReceiveDataInt32 OnlineCount = new ViReceiveDataInt32();
	public ViReceiveDataInt32 BigSpaceCount = new ViReceiveDataInt32();
	public ViReceiveDataInt32 ActivitySpaceCount = new ViReceiveDataInt32();
	public ViReceiveDataInt32 PublicSmallSpaceCount = new ViReceiveDataInt32();
	public ViReceiveDataInt32 PrivateSmallSpaceCount = new ViReceiveDataInt32();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		OnlineCount.Start(channelMask, IS, entity);
		BigSpaceCount.Start(channelMask, IS, entity);
		ActivitySpaceCount.Start(channelMask, IS, entity);
		PublicSmallSpaceCount.Start(channelMask, IS, entity);
		PrivateSmallSpaceCount.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		OnlineCount.End(entity);
		BigSpaceCount.End(entity);
		ActivitySpaceCount.End(entity);
		PublicSmallSpaceCount.End(entity);
		PrivateSmallSpaceCount.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		OnlineCount.Clear();
		BigSpaceCount.Clear();
		ActivitySpaceCount.Clear();
		PublicSmallSpaceCount.Clear();
		PrivateSmallSpaceCount.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		OnlineCount.RegisterAsChild(channelMask, this, childList);
		BigSpaceCount.RegisterAsChild(channelMask, this, childList);
		ActivitySpaceCount.RegisterAsChild(channelMask, this, childList);
		PublicSmallSpaceCount.RegisterAsChild(channelMask, this, childList);
		PrivateSmallSpaceCount.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator CellStateProperty(ReceiveDataCellStateProperty data)
	{
		CellStateProperty value = new CellStateProperty();
		value.OnlineCount = data.OnlineCount;
		value.BigSpaceCount = data.BigSpaceCount;
		value.ActivitySpaceCount = data.ActivitySpaceCount;
		value.PublicSmallSpaceCount = data.PublicSmallSpaceCount;
		value.PrivateSmallSpaceCount = data.PrivateSmallSpaceCount;
		return value;
	}
}

public class ReceiveDataDisableRecordProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 3;
	public ViReceiveDataString Value = new ViReceiveDataString();
	public ViReceiveDataString Note = new ViReceiveDataString();
	public ViReceiveDataInt64 EndTime1970 = new ViReceiveDataInt64();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		Value.Start(channelMask, IS, entity);
		Note.Start(channelMask, IS, entity);
		EndTime1970.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		Value.End(entity);
		Note.End(entity);
		EndTime1970.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		Value.Clear();
		Note.Clear();
		EndTime1970.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		Value.RegisterAsChild(channelMask, this, childList);
		Note.RegisterAsChild(channelMask, this, childList);
		EndTime1970.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator DisableRecordProperty(ReceiveDataDisableRecordProperty data)
	{
		DisableRecordProperty value = new DisableRecordProperty();
		value.Value = data.Value;
		value.Note = data.Note;
		value.EndTime1970 = data.EndTime1970;
		return value;
	}
}

public class ReceiveDataEntityServerProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 4;
	public ViReceiveDataUInt16 Create = new ViReceiveDataUInt16();
	public ViReceiveDataUInt16 Current = new ViReceiveDataUInt16();
	public ViReceiveDataInt64 Time = new ViReceiveDataInt64();
	public ViReceiveDataInt64 Time1970 = new ViReceiveDataInt64();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		Create.Start(channelMask, IS, entity);
		Current.Start(channelMask, IS, entity);
		Time.Start(channelMask, IS, entity);
		Time1970.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		Create.End(entity);
		Current.End(entity);
		Time.End(entity);
		Time1970.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		Create.Clear();
		Current.Clear();
		Time.Clear();
		Time1970.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		Create.RegisterAsChild(channelMask, this, childList);
		Current.RegisterAsChild(channelMask, this, childList);
		Time.RegisterAsChild(channelMask, this, childList);
		Time1970.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator EntityServerProperty(ReceiveDataEntityServerProperty data)
	{
		EntityServerProperty value = new EntityServerProperty();
		value.Create = data.Create;
		value.Current = data.Current;
		value.Time = data.Time;
		value.Time1970 = data.Time1970;
		return value;
	}
}

public class ReceiveDataMemoryUseProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 4;
	public ViReceiveDataString Name = new ViReceiveDataString();
	public ViReceiveDataUInt32 Size = new ViReceiveDataUInt32();
	public ViReceiveDataInt32 UseCount = new ViReceiveDataInt32();
	public ViReceiveDataInt32 ReserveCount = new ViReceiveDataInt32();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		Name.Start(channelMask, IS, entity);
		Size.Start(channelMask, IS, entity);
		UseCount.Start(channelMask, IS, entity);
		ReserveCount.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		Name.End(entity);
		Size.End(entity);
		UseCount.End(entity);
		ReserveCount.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		Name.Clear();
		Size.Clear();
		UseCount.Clear();
		ReserveCount.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		Name.RegisterAsChild(channelMask, this, childList);
		Size.RegisterAsChild(channelMask, this, childList);
		UseCount.RegisterAsChild(channelMask, this, childList);
		ReserveCount.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator MemoryUseProperty(ReceiveDataMemoryUseProperty data)
	{
		MemoryUseProperty value = new MemoryUseProperty();
		value.Name = data.Name;
		value.Size = data.Size;
		value.UseCount = data.UseCount;
		value.ReserveCount = data.ReserveCount;
		return value;
	}
}

public class ReceiveDataPlayerOnlineProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 18;
	public ReceiveDataPlayerIdentificationProperty Player = new ReceiveDataPlayerIdentificationProperty();
	public ViReceiveDataString AccountName = new ViReceiveDataString();
	public ViReceiveDataString IP = new ViReceiveDataString();
	public ViReceiveDataString MacAdress = new ViReceiveDataString();
	public ViReceiveDataUInt32 Space = new ViReceiveDataUInt32();
	public ViReceiveDataInt16 Level = new ViReceiveDataInt16();
	public ViReceiveDataUInt32 OnlineNumber = new ViReceiveDataUInt32();
	public ViReceiveDataString SourceTag = new ViReceiveDataString();
	public ViReceiveDataString SourceDate = new ViReceiveDataString();
	public ViReceiveDataString CDKey = new ViReceiveDataString();
	public ViReceiveDataString CDKeyTag = new ViReceiveDataString();
	public ViReceiveDataUInt16 AccessServerID = new ViReceiveDataUInt16();
	public ViReceiveDataUInt16 HomeServerID = new ViReceiveDataUInt16();
	public ViReceiveDataUInt16 ServerBaseID = new ViReceiveDataUInt16();
	public ViReceiveDataUInt16 ServerCellID = new ViReceiveDataUInt16();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		Player.Start(channelMask, IS, entity);
		AccountName.Start(channelMask, IS, entity);
		IP.Start(channelMask, IS, entity);
		MacAdress.Start(channelMask, IS, entity);
		Space.Start(channelMask, IS, entity);
		Level.Start(channelMask, IS, entity);
		OnlineNumber.Start(channelMask, IS, entity);
		SourceTag.Start(channelMask, IS, entity);
		SourceDate.Start(channelMask, IS, entity);
		CDKey.Start(channelMask, IS, entity);
		CDKeyTag.Start(channelMask, IS, entity);
		AccessServerID.Start(channelMask, IS, entity);
		HomeServerID.Start(channelMask, IS, entity);
		ServerBaseID.Start(channelMask, IS, entity);
		ServerCellID.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		Player.End(entity);
		AccountName.End(entity);
		IP.End(entity);
		MacAdress.End(entity);
		Space.End(entity);
		Level.End(entity);
		OnlineNumber.End(entity);
		SourceTag.End(entity);
		SourceDate.End(entity);
		CDKey.End(entity);
		CDKeyTag.End(entity);
		AccessServerID.End(entity);
		HomeServerID.End(entity);
		ServerBaseID.End(entity);
		ServerCellID.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		Player.Clear();
		AccountName.Clear();
		IP.Clear();
		MacAdress.Clear();
		Space.Clear();
		Level.Clear();
		OnlineNumber.Clear();
		SourceTag.Clear();
		SourceDate.Clear();
		CDKey.Clear();
		CDKeyTag.Clear();
		AccessServerID.Clear();
		HomeServerID.Clear();
		ServerBaseID.Clear();
		ServerCellID.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		Player.RegisterAsChild(channelMask, this, childList);
		AccountName.RegisterAsChild(channelMask, this, childList);
		IP.RegisterAsChild(channelMask, this, childList);
		MacAdress.RegisterAsChild(channelMask, this, childList);
		Space.RegisterAsChild(channelMask, this, childList);
		Level.RegisterAsChild(channelMask, this, childList);
		OnlineNumber.RegisterAsChild(channelMask, this, childList);
		SourceTag.RegisterAsChild(channelMask, this, childList);
		SourceDate.RegisterAsChild(channelMask, this, childList);
		CDKey.RegisterAsChild(channelMask, this, childList);
		CDKeyTag.RegisterAsChild(channelMask, this, childList);
		AccessServerID.RegisterAsChild(channelMask, this, childList);
		HomeServerID.RegisterAsChild(channelMask, this, childList);
		ServerBaseID.RegisterAsChild(channelMask, this, childList);
		ServerCellID.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator PlayerOnlineProperty(ReceiveDataPlayerOnlineProperty data)
	{
		PlayerOnlineProperty value = new PlayerOnlineProperty();
		value.Player = data.Player;
		value.AccountName = data.AccountName;
		value.IP = data.IP;
		value.MacAdress = data.MacAdress;
		value.Space = data.Space;
		value.Level = data.Level;
		value.OnlineNumber = data.OnlineNumber;
		value.SourceTag = data.SourceTag;
		value.SourceDate = data.SourceDate;
		value.CDKey = data.CDKey;
		value.CDKeyTag = data.CDKeyTag;
		value.AccessServerID = data.AccessServerID;
		value.HomeServerID = data.HomeServerID;
		value.ServerBaseID = data.ServerBaseID;
		value.ServerCellID = data.ServerCellID;
		return value;
	}
}

public class ReceiveDataQuestGameRecordProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 3;
	public ViReceiveDataUInt32 Quest = new ViReceiveDataUInt32();
	public ViReceiveDataInt64 ReceiveCount = new ViReceiveDataInt64();
	public ViReceiveDataInt64 CommitCount = new ViReceiveDataInt64();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		Quest.Start(channelMask, IS, entity);
		ReceiveCount.Start(channelMask, IS, entity);
		CommitCount.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		Quest.End(entity);
		ReceiveCount.End(entity);
		CommitCount.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		Quest.Clear();
		ReceiveCount.Clear();
		CommitCount.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		Quest.RegisterAsChild(channelMask, this, childList);
		ReceiveCount.RegisterAsChild(channelMask, this, childList);
		CommitCount.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator QuestGameRecordProperty(ReceiveDataQuestGameRecordProperty data)
	{
		QuestGameRecordProperty value = new QuestGameRecordProperty();
		value.Quest = data.Quest;
		value.ReceiveCount = data.ReceiveCount;
		value.CommitCount = data.CommitCount;
		return value;
	}
}

public class ReceiveDataItemGameRecordProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 4;
	public ViReceiveDataUInt32 Item = new ViReceiveDataUInt32();
	public ViReceiveDataInt64 ReceiveCount = new ViReceiveDataInt64();
	public ViReceiveDataInt64 ComsumeCount = new ViReceiveDataInt64();
	public ViReceiveDataInt64 AbandonCount = new ViReceiveDataInt64();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		Item.Start(channelMask, IS, entity);
		ReceiveCount.Start(channelMask, IS, entity);
		ComsumeCount.Start(channelMask, IS, entity);
		AbandonCount.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		Item.End(entity);
		ReceiveCount.End(entity);
		ComsumeCount.End(entity);
		AbandonCount.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		Item.Clear();
		ReceiveCount.Clear();
		ComsumeCount.Clear();
		AbandonCount.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		Item.RegisterAsChild(channelMask, this, childList);
		ReceiveCount.RegisterAsChild(channelMask, this, childList);
		ComsumeCount.RegisterAsChild(channelMask, this, childList);
		AbandonCount.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator ItemGameRecordProperty(ReceiveDataItemGameRecordProperty data)
	{
		ItemGameRecordProperty value = new ItemGameRecordProperty();
		value.Item = data.Item;
		value.ReceiveCount = data.ReceiveCount;
		value.ComsumeCount = data.ComsumeCount;
		value.AbandonCount = data.AbandonCount;
		return value;
	}
}

public class ReceiveDataPlayerLevelCountProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 2;
	public ViReceiveDataInt16 Level = new ViReceiveDataInt16();
	public ViReceiveDataInt32 Count = new ViReceiveDataInt32();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		Level.Start(channelMask, IS, entity);
		Count.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		Level.End(entity);
		Count.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		Level.Clear();
		Count.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		Level.RegisterAsChild(channelMask, this, childList);
		Count.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator PlayerLevelCountProperty(ReceiveDataPlayerLevelCountProperty data)
	{
		PlayerLevelCountProperty value = new PlayerLevelCountProperty();
		value.Level = data.Level;
		value.Count = data.Count;
		return value;
	}
}

public class ReceiveDataBoardProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 5;
	public ViReceiveDataInt64 StartTime1970 = new ViReceiveDataInt64();
	public ViReceiveDataInt64 EndTime1970 = new ViReceiveDataInt64();
	public ViReceiveDataInt64 Span = new ViReceiveDataInt64();
	public ViReceiveDataUInt8 LoopType = new ViReceiveDataUInt8();
	public ViReceiveDataString Content = new ViReceiveDataString();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		StartTime1970.Start(channelMask, IS, entity);
		EndTime1970.Start(channelMask, IS, entity);
		Span.Start(channelMask, IS, entity);
		LoopType.Start(channelMask, IS, entity);
		Content.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		StartTime1970.End(entity);
		EndTime1970.End(entity);
		Span.End(entity);
		LoopType.End(entity);
		Content.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		StartTime1970.Clear();
		EndTime1970.Clear();
		Span.Clear();
		LoopType.Clear();
		Content.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		StartTime1970.RegisterAsChild(channelMask, this, childList);
		EndTime1970.RegisterAsChild(channelMask, this, childList);
		Span.RegisterAsChild(channelMask, this, childList);
		LoopType.RegisterAsChild(channelMask, this, childList);
		Content.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator BoardProperty(ReceiveDataBoardProperty data)
	{
		BoardProperty value = new BoardProperty();
		value.StartTime1970 = data.StartTime1970;
		value.EndTime1970 = data.EndTime1970;
		value.Span = data.Span;
		value.LoopType = data.LoopType;
		value.Content = data.Content;
		return value;
	}
}

public class ReceiveDataGameNoteProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 3;
	public ViReceiveDataInt64 Time1970 = new ViReceiveDataInt64();
	public ViReceiveDataString Title = new ViReceiveDataString();
	public ViReceiveDataString Content = new ViReceiveDataString();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		Time1970.Start(channelMask, IS, entity);
		Title.Start(channelMask, IS, entity);
		Content.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		Time1970.End(entity);
		Title.End(entity);
		Content.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		Time1970.Clear();
		Title.Clear();
		Content.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		Time1970.RegisterAsChild(channelMask, this, childList);
		Title.RegisterAsChild(channelMask, this, childList);
		Content.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator GameNoteProperty(ReceiveDataGameNoteProperty data)
	{
		GameNoteProperty value = new GameNoteProperty();
		value.Time1970 = data.Time1970;
		value.Title = data.Title;
		value.Content = data.Content;
		return value;
	}
}

public class ReceiveDataRechargeInGameRecordProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 4;
	public ViReceiveDataString Account = new ViReceiveDataString();
	public ViReceiveDataInt64 LastTime = new ViReceiveDataInt64();
	public ViReceiveDataInt64 LastValue = new ViReceiveDataInt64();
	public ViReceiveDataInt64 TotalValue = new ViReceiveDataInt64();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		Account.Start(channelMask, IS, entity);
		LastTime.Start(channelMask, IS, entity);
		LastValue.Start(channelMask, IS, entity);
		TotalValue.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		Account.End(entity);
		LastTime.End(entity);
		LastValue.End(entity);
		TotalValue.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		Account.Clear();
		LastTime.Clear();
		LastValue.Clear();
		TotalValue.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		Account.RegisterAsChild(channelMask, this, childList);
		LastTime.RegisterAsChild(channelMask, this, childList);
		LastValue.RegisterAsChild(channelMask, this, childList);
		TotalValue.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator RechargeInGameRecordProperty(ReceiveDataRechargeInGameRecordProperty data)
	{
		RechargeInGameRecordProperty value = new RechargeInGameRecordProperty();
		value.Account = data.Account;
		value.LastTime = data.LastTime;
		value.LastValue = data.LastValue;
		value.TotalValue = data.TotalValue;
		return value;
	}
}

public class ReceiveDataServerBaseViewProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 33;
	public ViReceiveDataString ServerName = new ViReceiveDataString();
	public ViReceiveDataUInt16 ID = new ViReceiveDataUInt16();
	public ViReceiveDataInt64 Time = new ViReceiveDataInt64();
	public ViReceiveDataInt64 Time1970 = new ViReceiveDataInt64();
	public ViReceiveDataInt64 StartTime1970 = new ViReceiveDataInt64();
	public ViReceiveDataUInt64 Fragment0RecordID = new ViReceiveDataUInt64();
	public ViReceiveDataUInt64 Fragment1RecordID = new ViReceiveDataUInt64();
	public ViReceiveDataInt32 PlayerCount = new ViReceiveDataInt32();
	public ViReceiveDataInt32 AccountCount = new ViReceiveDataInt32();
	public ViReceiveDataInt32 GuildCount = new ViReceiveDataInt32();
	public ViReceiveDataInt32 OnlineCount = new ViReceiveDataInt32();
	public ViReceiveDataInt32 MaxOnlineCount = new ViReceiveDataInt32();
	public ViReceiveDataInt32 DayMaxOnlineCount = new ViReceiveDataInt32();
	public ViReceiveDataInt32 WeekMaxOnlineCount = new ViReceiveDataInt32();
	public ViReceiveDataInt32 MonthMaxOnlineCount = new ViReceiveDataInt32();
	public ViReceiveDataInt32 DayLoginCount = new ViReceiveDataInt32();
	public ViReceiveDataInt32 WeekLoginCount = new ViReceiveDataInt32();
	public ViReceiveDataInt32 MonthLoginCount = new ViReceiveDataInt32();
	public ViReceiveDataInt32 DayNewAccountCount = new ViReceiveDataInt32();
	public ViReceiveDataInt32 WeekNewAccountCount = new ViReceiveDataInt32();
	public ViReceiveDataInt32 MonthNewAccountCount = new ViReceiveDataInt32();
	public ViReceiveDataInt32 DayNewPlayerCount = new ViReceiveDataInt32();
	public ViReceiveDataInt32 WeekNewPlayerCount = new ViReceiveDataInt32();
	public ViReceiveDataInt32 MonthNewPlayerCount = new ViReceiveDataInt32();
	public ViReceiveDataInt32 DayNewGuildCount = new ViReceiveDataInt32();
	public ViReceiveDataInt32 WeekNewGuildCount = new ViReceiveDataInt32();
	public ViReceiveDataInt32 MonthNewGuildCount = new ViReceiveDataInt32();
	public ViReceiveDataInt32 LuckLootDayCount = new ViReceiveDataInt32();
	public ViReceiveDataInt32 LuckLootAccumulateCount = new ViReceiveDataInt32();
	public ViReceiveDataInt32 EntityCount = new ViReceiveDataInt32();
	public ViReceiveDataInt32 EntityIDCount = new ViReceiveDataInt32();
	public ViReceiveDataInt32 EntityPackIDCount = new ViReceiveDataInt32();
	public ViReceiveDataInt32 SpaceCount = new ViReceiveDataInt32();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		ServerName.Start(channelMask, IS, entity);
		ID.Start(channelMask, IS, entity);
		Time.Start(channelMask, IS, entity);
		Time1970.Start(channelMask, IS, entity);
		StartTime1970.Start(channelMask, IS, entity);
		Fragment0RecordID.Start(channelMask, IS, entity);
		Fragment1RecordID.Start(channelMask, IS, entity);
		PlayerCount.Start(channelMask, IS, entity);
		AccountCount.Start(channelMask, IS, entity);
		GuildCount.Start(channelMask, IS, entity);
		OnlineCount.Start(channelMask, IS, entity);
		MaxOnlineCount.Start(channelMask, IS, entity);
		DayMaxOnlineCount.Start(channelMask, IS, entity);
		WeekMaxOnlineCount.Start(channelMask, IS, entity);
		MonthMaxOnlineCount.Start(channelMask, IS, entity);
		DayLoginCount.Start(channelMask, IS, entity);
		WeekLoginCount.Start(channelMask, IS, entity);
		MonthLoginCount.Start(channelMask, IS, entity);
		DayNewAccountCount.Start(channelMask, IS, entity);
		WeekNewAccountCount.Start(channelMask, IS, entity);
		MonthNewAccountCount.Start(channelMask, IS, entity);
		DayNewPlayerCount.Start(channelMask, IS, entity);
		WeekNewPlayerCount.Start(channelMask, IS, entity);
		MonthNewPlayerCount.Start(channelMask, IS, entity);
		DayNewGuildCount.Start(channelMask, IS, entity);
		WeekNewGuildCount.Start(channelMask, IS, entity);
		MonthNewGuildCount.Start(channelMask, IS, entity);
		LuckLootDayCount.Start(channelMask, IS, entity);
		LuckLootAccumulateCount.Start(channelMask, IS, entity);
		EntityCount.Start(channelMask, IS, entity);
		EntityIDCount.Start(channelMask, IS, entity);
		EntityPackIDCount.Start(channelMask, IS, entity);
		SpaceCount.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		ServerName.End(entity);
		ID.End(entity);
		Time.End(entity);
		Time1970.End(entity);
		StartTime1970.End(entity);
		Fragment0RecordID.End(entity);
		Fragment1RecordID.End(entity);
		PlayerCount.End(entity);
		AccountCount.End(entity);
		GuildCount.End(entity);
		OnlineCount.End(entity);
		MaxOnlineCount.End(entity);
		DayMaxOnlineCount.End(entity);
		WeekMaxOnlineCount.End(entity);
		MonthMaxOnlineCount.End(entity);
		DayLoginCount.End(entity);
		WeekLoginCount.End(entity);
		MonthLoginCount.End(entity);
		DayNewAccountCount.End(entity);
		WeekNewAccountCount.End(entity);
		MonthNewAccountCount.End(entity);
		DayNewPlayerCount.End(entity);
		WeekNewPlayerCount.End(entity);
		MonthNewPlayerCount.End(entity);
		DayNewGuildCount.End(entity);
		WeekNewGuildCount.End(entity);
		MonthNewGuildCount.End(entity);
		LuckLootDayCount.End(entity);
		LuckLootAccumulateCount.End(entity);
		EntityCount.End(entity);
		EntityIDCount.End(entity);
		EntityPackIDCount.End(entity);
		SpaceCount.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		ServerName.Clear();
		ID.Clear();
		Time.Clear();
		Time1970.Clear();
		StartTime1970.Clear();
		Fragment0RecordID.Clear();
		Fragment1RecordID.Clear();
		PlayerCount.Clear();
		AccountCount.Clear();
		GuildCount.Clear();
		OnlineCount.Clear();
		MaxOnlineCount.Clear();
		DayMaxOnlineCount.Clear();
		WeekMaxOnlineCount.Clear();
		MonthMaxOnlineCount.Clear();
		DayLoginCount.Clear();
		WeekLoginCount.Clear();
		MonthLoginCount.Clear();
		DayNewAccountCount.Clear();
		WeekNewAccountCount.Clear();
		MonthNewAccountCount.Clear();
		DayNewPlayerCount.Clear();
		WeekNewPlayerCount.Clear();
		MonthNewPlayerCount.Clear();
		DayNewGuildCount.Clear();
		WeekNewGuildCount.Clear();
		MonthNewGuildCount.Clear();
		LuckLootDayCount.Clear();
		LuckLootAccumulateCount.Clear();
		EntityCount.Clear();
		EntityIDCount.Clear();
		EntityPackIDCount.Clear();
		SpaceCount.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		ServerName.RegisterAsChild(channelMask, this, childList);
		ID.RegisterAsChild(channelMask, this, childList);
		Time.RegisterAsChild(channelMask, this, childList);
		Time1970.RegisterAsChild(channelMask, this, childList);
		StartTime1970.RegisterAsChild(channelMask, this, childList);
		Fragment0RecordID.RegisterAsChild(channelMask, this, childList);
		Fragment1RecordID.RegisterAsChild(channelMask, this, childList);
		PlayerCount.RegisterAsChild(channelMask, this, childList);
		AccountCount.RegisterAsChild(channelMask, this, childList);
		GuildCount.RegisterAsChild(channelMask, this, childList);
		OnlineCount.RegisterAsChild(channelMask, this, childList);
		MaxOnlineCount.RegisterAsChild(channelMask, this, childList);
		DayMaxOnlineCount.RegisterAsChild(channelMask, this, childList);
		WeekMaxOnlineCount.RegisterAsChild(channelMask, this, childList);
		MonthMaxOnlineCount.RegisterAsChild(channelMask, this, childList);
		DayLoginCount.RegisterAsChild(channelMask, this, childList);
		WeekLoginCount.RegisterAsChild(channelMask, this, childList);
		MonthLoginCount.RegisterAsChild(channelMask, this, childList);
		DayNewAccountCount.RegisterAsChild(channelMask, this, childList);
		WeekNewAccountCount.RegisterAsChild(channelMask, this, childList);
		MonthNewAccountCount.RegisterAsChild(channelMask, this, childList);
		DayNewPlayerCount.RegisterAsChild(channelMask, this, childList);
		WeekNewPlayerCount.RegisterAsChild(channelMask, this, childList);
		MonthNewPlayerCount.RegisterAsChild(channelMask, this, childList);
		DayNewGuildCount.RegisterAsChild(channelMask, this, childList);
		WeekNewGuildCount.RegisterAsChild(channelMask, this, childList);
		MonthNewGuildCount.RegisterAsChild(channelMask, this, childList);
		LuckLootDayCount.RegisterAsChild(channelMask, this, childList);
		LuckLootAccumulateCount.RegisterAsChild(channelMask, this, childList);
		EntityCount.RegisterAsChild(channelMask, this, childList);
		EntityIDCount.RegisterAsChild(channelMask, this, childList);
		EntityPackIDCount.RegisterAsChild(channelMask, this, childList);
		SpaceCount.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator ServerBaseViewProperty(ReceiveDataServerBaseViewProperty data)
	{
		ServerBaseViewProperty value = new ServerBaseViewProperty();
		value.ServerName = data.ServerName;
		value.ID = data.ID;
		value.Time = data.Time;
		value.Time1970 = data.Time1970;
		value.StartTime1970 = data.StartTime1970;
		value.Fragment0RecordID = data.Fragment0RecordID;
		value.Fragment1RecordID = data.Fragment1RecordID;
		value.PlayerCount = data.PlayerCount;
		value.AccountCount = data.AccountCount;
		value.GuildCount = data.GuildCount;
		value.OnlineCount = data.OnlineCount;
		value.MaxOnlineCount = data.MaxOnlineCount;
		value.DayMaxOnlineCount = data.DayMaxOnlineCount;
		value.WeekMaxOnlineCount = data.WeekMaxOnlineCount;
		value.MonthMaxOnlineCount = data.MonthMaxOnlineCount;
		value.DayLoginCount = data.DayLoginCount;
		value.WeekLoginCount = data.WeekLoginCount;
		value.MonthLoginCount = data.MonthLoginCount;
		value.DayNewAccountCount = data.DayNewAccountCount;
		value.WeekNewAccountCount = data.WeekNewAccountCount;
		value.MonthNewAccountCount = data.MonthNewAccountCount;
		value.DayNewPlayerCount = data.DayNewPlayerCount;
		value.WeekNewPlayerCount = data.WeekNewPlayerCount;
		value.MonthNewPlayerCount = data.MonthNewPlayerCount;
		value.DayNewGuildCount = data.DayNewGuildCount;
		value.WeekNewGuildCount = data.WeekNewGuildCount;
		value.MonthNewGuildCount = data.MonthNewGuildCount;
		value.LuckLootDayCount = data.LuckLootDayCount;
		value.LuckLootAccumulateCount = data.LuckLootAccumulateCount;
		value.EntityCount = data.EntityCount;
		value.EntityIDCount = data.EntityIDCount;
		value.EntityPackIDCount = data.EntityPackIDCount;
		value.SpaceCount = data.SpaceCount;
		return value;
	}
}

public class ReceiveDataGMContentProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 8;
	public ViReceiveDataUInt8 State = new ViReceiveDataUInt8();
	public ViReceiveDataUInt64 Time1970 = new ViReceiveDataUInt64();
	public ViReceiveDataString Requestor = new ViReceiveDataString();
	public ViReceiveDataString Confirmer = new ViReceiveDataString();
	public ViReceiveDataUInt64 StartTime = new ViReceiveDataUInt64();
	public ViReceiveDataUInt64 EndTime = new ViReceiveDataUInt64();
	public ViReceiveDataString Func = new ViReceiveDataString();
	public ViReceiveDataString Params = new ViReceiveDataString();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		State.Start(channelMask, IS, entity);
		Time1970.Start(channelMask, IS, entity);
		Requestor.Start(channelMask, IS, entity);
		Confirmer.Start(channelMask, IS, entity);
		StartTime.Start(channelMask, IS, entity);
		EndTime.Start(channelMask, IS, entity);
		Func.Start(channelMask, IS, entity);
		Params.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		State.End(entity);
		Time1970.End(entity);
		Requestor.End(entity);
		Confirmer.End(entity);
		StartTime.End(entity);
		EndTime.End(entity);
		Func.End(entity);
		Params.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		State.Clear();
		Time1970.Clear();
		Requestor.Clear();
		Confirmer.Clear();
		StartTime.Clear();
		EndTime.Clear();
		Func.Clear();
		Params.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		State.RegisterAsChild(channelMask, this, childList);
		Time1970.RegisterAsChild(channelMask, this, childList);
		Requestor.RegisterAsChild(channelMask, this, childList);
		Confirmer.RegisterAsChild(channelMask, this, childList);
		StartTime.RegisterAsChild(channelMask, this, childList);
		EndTime.RegisterAsChild(channelMask, this, childList);
		Func.RegisterAsChild(channelMask, this, childList);
		Params.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator GMContentProperty(ReceiveDataGMContentProperty data)
	{
		GMContentProperty value = new GMContentProperty();
		value.State = data.State;
		value.Time1970 = data.Time1970;
		value.Requestor = data.Requestor;
		value.Confirmer = data.Confirmer;
		value.StartTime = data.StartTime;
		value.EndTime = data.EndTime;
		value.Func = data.Func;
		value.Params = data.Params;
		return value;
	}
}

public class ReceiveDataGMRequestProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 9;
	public ViReceiveDataUInt32 OccupationMask = new ViReceiveDataUInt32();
	public ViReceiveDataInt16 LevelInf = new ViReceiveDataInt16();
	public ViReceiveDataInt16 LevelSup = new ViReceiveDataInt16();
	public ViReceiveDataUInt32 QuestReceived = new ViReceiveDataUInt32();
	public ViReceiveDataUInt32 QuestNotReceived = new ViReceiveDataUInt32();
	public ViReceiveDataUInt32 QuestCompleted = new ViReceiveDataUInt32();
	public ViReceiveDataUInt32 QuestNotCompleted = new ViReceiveDataUInt32();
	public ViReceiveDataUInt32 FuncOpened = new ViReceiveDataUInt32();
	public ViReceiveDataUInt32 FuncNotOpened = new ViReceiveDataUInt32();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		OccupationMask.Start(channelMask, IS, entity);
		LevelInf.Start(channelMask, IS, entity);
		LevelSup.Start(channelMask, IS, entity);
		QuestReceived.Start(channelMask, IS, entity);
		QuestNotReceived.Start(channelMask, IS, entity);
		QuestCompleted.Start(channelMask, IS, entity);
		QuestNotCompleted.Start(channelMask, IS, entity);
		FuncOpened.Start(channelMask, IS, entity);
		FuncNotOpened.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		OccupationMask.End(entity);
		LevelInf.End(entity);
		LevelSup.End(entity);
		QuestReceived.End(entity);
		QuestNotReceived.End(entity);
		QuestCompleted.End(entity);
		QuestNotCompleted.End(entity);
		FuncOpened.End(entity);
		FuncNotOpened.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		OccupationMask.Clear();
		LevelInf.Clear();
		LevelSup.Clear();
		QuestReceived.Clear();
		QuestNotReceived.Clear();
		QuestCompleted.Clear();
		QuestNotCompleted.Clear();
		FuncOpened.Clear();
		FuncNotOpened.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		OccupationMask.RegisterAsChild(channelMask, this, childList);
		LevelInf.RegisterAsChild(channelMask, this, childList);
		LevelSup.RegisterAsChild(channelMask, this, childList);
		QuestReceived.RegisterAsChild(channelMask, this, childList);
		QuestNotReceived.RegisterAsChild(channelMask, this, childList);
		QuestCompleted.RegisterAsChild(channelMask, this, childList);
		QuestNotCompleted.RegisterAsChild(channelMask, this, childList);
		FuncOpened.RegisterAsChild(channelMask, this, childList);
		FuncNotOpened.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator GMRequestProperty(ReceiveDataGMRequestProperty data)
	{
		GMRequestProperty value = new GMRequestProperty();
		value.OccupationMask = data.OccupationMask;
		value.LevelInf = data.LevelInf;
		value.LevelSup = data.LevelSup;
		value.QuestReceived = data.QuestReceived;
		value.QuestNotReceived = data.QuestNotReceived;
		value.QuestCompleted = data.QuestCompleted;
		value.QuestNotCompleted = data.QuestNotCompleted;
		value.FuncOpened = data.FuncOpened;
		value.FuncNotOpened = data.FuncNotOpened;
		return value;
	}
}

public class ReceiveDataGMRequestContentProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 17;
	public ReceiveDataGMRequestProperty Request = new ReceiveDataGMRequestProperty();
	public ReceiveDataGMContentProperty Content = new ReceiveDataGMContentProperty();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		Request.Start(channelMask, IS, entity);
		Content.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		Request.End(entity);
		Content.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		Request.Clear();
		Content.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		Request.RegisterAsChild(channelMask, this, childList);
		Content.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator GMRequestContentProperty(ReceiveDataGMRequestContentProperty data)
	{
		GMRequestContentProperty value = new GMRequestContentProperty();
		value.Request = data.Request;
		value.Content = data.Content;
		return value;
	}
}

public class ReceiveDataGMRequestMailProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 48;
	public ReceiveDataGMRequestProperty Request = new ReceiveDataGMRequestProperty();
	public ReceiveDataMailProperty Content = new ReceiveDataMailProperty();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		Request.Start(channelMask, IS, entity);
		Content.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		Request.End(entity);
		Content.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		Request.Clear();
		Content.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		Request.RegisterAsChild(channelMask, this, childList);
		Content.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator GMRequestMailProperty(ReceiveDataGMRequestMailProperty data)
	{
		GMRequestMailProperty value = new GMRequestMailProperty();
		value.Request = data.Request;
		value.Content = data.Content;
		return value;
	}
}

