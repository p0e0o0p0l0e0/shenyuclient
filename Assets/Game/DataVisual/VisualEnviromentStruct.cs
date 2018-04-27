/*--------------------------------------------------------------------------------
//
// Copyright (C) 2017 netcosmos.com
// 
// 文件名 ： VisualEnviromentStruct
// 文件名功能描述:
//
// 创建者: 王骏(wangjun)
// 时间： (9/6/2017 2:05:46 PM)
//
// 修改人:
// 修改时间：
// 修改说明：
//
// 修改人:
// 修改时间：
// 修改说明：
//
// 版本: V1.0.0
//
//---------------------------------------------------------------------------------*/


using System;

public class VisualSpaceRegionStruct : ViSealedData
{
    public string RegionName;
    public string Description;
    public ViForeignKey<VisualSpaceStruct> FatherSpace;

    public ViVector3Struct CenterPostion;
    public Int32 Height;
    public Int32 Width;

    public ViEnum32<BoolValue> RegionNameDisplay;

    public Int32 Reserve0;
    public Int32 Reserve1;

    public ViForeignKey<VisualEnvironmentStruct> RegionEnvironment;


    public override void Format()
    {
    }
    public override void Start()
    {
        if (FatherSpace.NotEmpty())
        {
            VisualSpaceStruct fatherSpace = FatherSpace.Data;
            fatherSpace.SpaceRegions.Add(this);
        }

    }
}


public class VisualEnvironmentStruct : ViSealedData
{

    // light fog environment , maybe wind direction
    public ViVector3Struct SunColor;
    public Int32 LightIntensityHDR;
    public Int32 LightIntensiryLDR;
    public ViVector3Struct RoleParam;

    public Int32 FogHeight;
    public Int32 FogDensity;

    public Int32 WindDirectionX;
    public Int32 WindDirectionY;


}



