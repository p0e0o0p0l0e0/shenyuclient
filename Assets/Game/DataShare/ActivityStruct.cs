using System;

public class ActivityStruct : ViSealedData
{
	public struct RequestStruct
	{
		public ViValueRange Level;
		public ViForeignKey<ViStateConditionStruct> Condition;
		public Int32 Reserve_2;
		public Int32 Reserve_3;
		public Int32 Reserve_4;
	}

	public class TimeStruct
	{
		public ViDurationStruct Start;
		public ViDurationStruct Duration;
		public Int32 Reserve_0;
		public Int32 Reserve_1;
		public Int32 Reserve_2;
		public Int32 Reserve_3;
		public Int32 Reserve_4;
		public ViStaticArray<ViMiscInt32> MiscValue = new ViStaticArray<ViMiscInt32>(3);
	}

	public class MiscStruct
	{
		public Int32 Reserve_0;
		public Int32 Reserve_1;
		public Int32 Reserve_2;
		public Int32 Reserve_3;
		public string VisualScript;
		public ViStaticArray<ViMiscInt32> MiscValue = new ViStaticArray<ViMiscInt32>(3);
	}

	public ViForeignKey<ViSealedDataTypeStruct> Type;
	public Int32 UpdateSpan;
	public string Title;
	public string Description;
	public string Icon;
	public string ScoreIcon;
	public Int32 Quality;
	public LoopCountStruct EnterCount;
	public RequestStruct Request = new RequestStruct();
	public ViEnum32<BoolValue> StartIgnoreDuration;
	public ViEnum32<ViDateLoopType> TimeLoop;
	public ViStaticArray<TimeStruct> Time = new ViStaticArray<TimeStruct>(30);
	public MiscStruct MiscValue = new MiscStruct();
}

//+---------------------------------------------------------------------------------------------------------------------------------------------------------------------
public class ActivityScriptStruct : ViSealedData
{
	public string Icon;
	public string Desc;
	public ViEnum32<ViDateLoopType> StartTimeFormat;
	public ViActiveDuration Duration;
	public Int32 Reserve_0;
	public Int32 Reserve_1;
	public Int32 Reserve_2;
	public Int32 Reserve_3;
	public Int32 Reserve_4;
	public ViStaticArray<ViMiscInt32> MiscValue = new ViStaticArray<ViMiscInt32>(3);
}
