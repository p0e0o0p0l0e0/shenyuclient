using System;
using System.Collections.Generic;

public class HeroWatcher : ViReceiveDataDictionaryNodeWatcher<UInt32, ReceiveDataHeroProperty>
{
	public Int16 Level { get { return Property.Level; } }
	public Int16 Quality { get { return 1; } }
	public Int16 Star { get { return 1; } }

	public HeroStruct LogicInfo { get { return _logicInfo; } }
	public VisualHeroStruct VisualInfo { get { return _visualInfo; } }

	public override void OnStart(UInt32 key, ReceiveDataHeroProperty property, ViEntity entity)
	{
		_UpdateHeroInfo();
	}

	public override void OnUpdate(UInt32 key, ReceiveDataHeroProperty property, ViEntity entity)
	{
		_UpdateHeroInfo();
	}
	//
	public override void OnEnd(UInt32 key, ReceiveDataHeroProperty property, ViEntity entity)
	{
		_logicInfo = null;
		_visualInfo = null;
	}

	void _UpdateHeroInfo()
	{
		_logicInfo = ViSealedDB<HeroStruct>.Data(Key);
		_visualInfo = ViSealedDB<VisualHeroStruct>.Data(Key);
	}

	HeroStruct _logicInfo = null;
	VisualHeroStruct _visualInfo = null;
}
