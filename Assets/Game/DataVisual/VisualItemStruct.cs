using System;
using System.Collections.Generic;

public class VisualItemStruct : ViSealedData
{
	public class OutputStruct
	{
		public struct ScoreMarketStruct
		{
			public ViForeignKey<ScoreStruct> Score;
			public ViForeignKey<GameFuncStruct> ReqFunc;
		}

		public string Desc;
		public ViStaticArray<ScoreMarketStruct> ScoreMarketArray = new ViStaticArray<ScoreMarketStruct>(5);
	}

	public string Icon;
	public string Desc;
	public ViForeignKey<Icon3DStruct> Icon3D;
	public ViForeignKey<ViSealedDataTypeStruct> Class;
	public OutputStruct Output = new OutputStruct();
	public Int32 ChessLevel;
    public string EquipSlotName;
    public ViForeignKey<EquipInfoStruct> EquipInfo;
    public string PinJie;
    public Int32 LimitClass;
    public ViForeignKey<PathFileResStruct> MalePathFile;
    public ViForeignKey<PathFileResStruct> FeMalePathFile;
}

public class Icon3DStruct : ViSealedData
{
	public ViForeignKey<PathFileResStruct> Res;
}


public class EquipInfoStruct : ViSealedData
{
    public class ModelNameStruct
    {
        public string MName;
    }

    //public string ModelJoint;
    public ViEnum32<AvatarAttachNode> ModelJoint;
    public string EquipSlotName;
    public ViStaticArray<ModelNameStruct> ModelArray = new ViStaticArray<ModelNameStruct>(3);
}
