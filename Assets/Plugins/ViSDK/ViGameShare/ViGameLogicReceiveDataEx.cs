using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViString = System.String;
using ViArrayIdx = System.Int32;
public class ReceiveDataAuraCasterProperty: ViReceiveDataNode
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
	public static implicit operator AuraCasterProperty(ReceiveDataAuraCasterProperty data)
	{
		AuraCasterProperty value = new AuraCasterProperty();
		value.Value = data.Value;
		return value;
	}
}

public class ReceiveDataAuraCasterPtrProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 1;
	public ViReceiveDataPtr<AuraCasterProperty> Value = new ViReceiveDataPtr<AuraCasterProperty>();
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
	public static implicit operator AuraCasterPtrProperty(ReceiveDataAuraCasterPtrProperty data)
	{
		AuraCasterPtrProperty value = new AuraCasterPtrProperty();
		value.Value = data.Value;
		return value;
	}
}

public class ReceiveDataLogicAuraValueArray: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 5;
	public static readonly int Length = 5;
	//
	public int GetLength() { return Length; }
	//
	public ViReceiveDataInt32 E0 = new ViReceiveDataInt32();
	public ViReceiveDataInt32 E1 = new ViReceiveDataInt32();
	public ViReceiveDataInt32 E2 = new ViReceiveDataInt32();
	public ViReceiveDataInt32 E3 = new ViReceiveDataInt32();
	public ViReceiveDataInt32 E4 = new ViReceiveDataInt32();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		E0.Start(channelMask, IS, entity);
		E1.Start(channelMask, IS, entity);
		E2.Start(channelMask, IS, entity);
		E3.Start(channelMask, IS, entity);
		E4.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		E0.End(entity);
		E1.End(entity);
		E2.End(entity);
		E3.End(entity);
		E4.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		E0.Clear();
		E1.Clear();
		E2.Clear();
		E3.Clear();
		E4.Clear();
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
	}
	public static implicit operator LogicAuraValueArray(ReceiveDataLogicAuraValueArray data)
	{
		LogicAuraValueArray value = new LogicAuraValueArray();
		value.E0 = data.E0;
		value.E1 = data.E1;
		value.E2 = data.E2;
		value.E3 = data.E3;
		value.E4 = data.E4;
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
				case 4:
					return E4;
			}
			ViDebuger.Error("");
			return E0;
		}
	}
}

public class ReceiveDataLogicAuraCasterValueArray: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 5;
	public static readonly int Length = 5;
	//
	public int GetLength() { return Length; }
	//
	public ViReceiveDataInt32 E0 = new ViReceiveDataInt32();
	public ViReceiveDataInt32 E1 = new ViReceiveDataInt32();
	public ViReceiveDataInt32 E2 = new ViReceiveDataInt32();
	public ViReceiveDataInt32 E3 = new ViReceiveDataInt32();
	public ViReceiveDataInt32 E4 = new ViReceiveDataInt32();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		E0.Start(channelMask, IS, entity);
		E1.Start(channelMask, IS, entity);
		E2.Start(channelMask, IS, entity);
		E3.Start(channelMask, IS, entity);
		E4.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		E0.End(entity);
		E1.End(entity);
		E2.End(entity);
		E3.End(entity);
		E4.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		E0.Clear();
		E1.Clear();
		E2.Clear();
		E3.Clear();
		E4.Clear();
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
	}
	public static implicit operator LogicAuraCasterValueArray(ReceiveDataLogicAuraCasterValueArray data)
	{
		LogicAuraCasterValueArray value = new LogicAuraCasterValueArray();
		value.E0 = data.E0;
		value.E1 = data.E1;
		value.E2 = data.E2;
		value.E3 = data.E3;
		value.E4 = data.E4;
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
				case 4:
					return E4;
			}
			ViDebuger.Error("");
			return E0;
		}
	}
}

public class ReceiveDataDisSpellProperty: ViReceiveDataNode
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
	public static implicit operator DisSpellProperty(ReceiveDataDisSpellProperty data)
	{
		DisSpellProperty value = new DisSpellProperty();
		value.EndTime = data.EndTime;
		return value;
	}
}

public class ReceiveDataVisualAuraProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 3;
	public ViReceiveDataUInt32 Effect = new ViReceiveDataUInt32();
	public ViReceiveDataInt32 EndTime = new ViReceiveDataInt32();
	public ReceiveDataAuraCasterPtrProperty Caster = new ReceiveDataAuraCasterPtrProperty();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		Effect.Start(channelMask, IS, entity);
		EndTime.Start(channelMask, IS, entity);
		Caster.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		Effect.End(entity);
		EndTime.End(entity);
		Caster.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		Effect.Clear();
		EndTime.Clear();
		Caster.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		Effect.RegisterAsChild(channelMask, this, childList);
		EndTime.RegisterAsChild(channelMask, this, childList);
		Caster.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator VisualAuraProperty(ReceiveDataVisualAuraProperty data)
	{
		VisualAuraProperty value = new VisualAuraProperty();
		value.Effect = data.Effect;
		value.EndTime = data.EndTime;
		value.Caster = data.Caster;
		return value;
	}
}

public class ReceiveDataLogicAuraProperty: ViReceiveDataNode
{
	public static readonly new int TYPE_SIZE = 13;
	public ViReceiveDataUInt32 Effect = new ViReceiveDataUInt32();
	public ViReceiveDataInt32 EndTime = new ViReceiveDataInt32();
	public ViReceiveDataInt32 LevelValue = new ViReceiveDataInt32();
	public ReceiveDataLogicAuraCasterValueArray CasterValue = new ReceiveDataLogicAuraCasterValueArray();
	public ReceiveDataLogicAuraValueArray Value = new ReceiveDataLogicAuraValueArray();
	//
	public override int GetSize() { return TYPE_SIZE; }
	public override void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		Effect.Start(channelMask, IS, entity);
		EndTime.Start(channelMask, IS, entity);
		LevelValue.Start(channelMask, IS, entity);
		CasterValue.Start(channelMask, IS, entity);
		Value.Start(channelMask, IS, entity);
	}
	public override void End(ViEntity entity)
	{
		Effect.End(entity);
		EndTime.End(entity);
		LevelValue.End(entity);
		CasterValue.End(entity);
		Value.End(entity);
		base.End(entity);
	}
	public override void Clear()
	{
		Effect.Clear();
		EndTime.Clear();
		LevelValue.Clear();
		CasterValue.Clear();
		Value.Clear();
		base.Clear();
	}
	public override void RegisterAsChild(UInt16 channelMask, ViReceiveDataNode parent, List<ViReceiveDataNode> childList)
	{
		_RegisterAsChild(channelMask, parent);
		Effect.RegisterAsChild(channelMask, this, childList);
		EndTime.RegisterAsChild(channelMask, this, childList);
		LevelValue.RegisterAsChild(channelMask, this, childList);
		CasterValue.RegisterAsChild(channelMask, this, childList);
		Value.RegisterAsChild(channelMask, this, childList);
	}
	public static implicit operator LogicAuraProperty(ReceiveDataLogicAuraProperty data)
	{
		LogicAuraProperty value = new LogicAuraProperty();
		value.Effect = data.Effect;
		value.EndTime = data.EndTime;
		value.LevelValue = data.LevelValue;
		value.CasterValue = data.CasterValue;
		value.Value = data.Value;
		return value;
	}
}

