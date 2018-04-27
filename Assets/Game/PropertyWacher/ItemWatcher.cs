using System;
using System.Collections.Generic;
using UInt8 = System.Byte;

public class ItemWatcher : ViReceiveDataArrayNodeWatcher<ReceiveDataItemProperty>
{
	public UInt8 Bag { get { return Property.Slot.Bag; } }

	public UInt16 Slot
	{
		get { return Property.Slot.Slot; }
	}

	public Int32 StackCount
	{
		get { return Property.StackCount.Value; }
	}

	public ItemStruct LogicInfo { get { return _logicInfo; } }
	public VisualItemStruct VisualInfo { get { return _visualInfo; } }

	public override void OnStart(ReceiveDataItemProperty property, ViEntity entity)
	{
		_UpdateItem(property);
	}

	public override void OnUpdate(ReceiveDataItemProperty property, ViEntity entity)
	{
		_UpdateItem(property);
	}
	//
	public override void OnEnd(ReceiveDataItemProperty property, ViEntity entity)
	{
		_logicInfo = null;
		_visualInfo = null;
	}

	void _UpdateItem(ReceiveDataItemProperty property)
	{
		_logicInfo = property.Info.Value;
		_visualInfo = ViSealedDB<VisualItemStruct>.Data(property.Info);
	}

	ItemStruct _logicInfo = null;
	VisualItemStruct _visualInfo = null;
}
