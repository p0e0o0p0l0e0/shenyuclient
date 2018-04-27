using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UIMapBase : IDisposable
{
    public bool IsDirectionInvert
    {
        get
        {
            return directionFlag == -1;
        }
        set
        {
            directionFlag = (short)(value ? -1 : 1);
        }
    }

    public Vector2 TerrianSize { get; set; }
    public Vector2 TerrianCenter { get; set; }
    public float OffsetAngle { get; set; }
    public float DirectionAngle { get; set; }
    public Vector2 UIMapSize { get; set; }
    protected Vector2 _Scale = Vector2.one;
    protected short directionFlag = 1;

    public static UIMapBase CreateMap(Vector2 terrianSize,Vector2 terrianCenter, Vector2 uimapSize, bool isRevertDir, float offsetAngle = 270, float directionAngle = 0)
    {
        UIMapBase map = new UIMapBase();
        map.TerrianCenter = terrianCenter;
        map.TerrianSize = terrianSize;
        map.UIMapSize = uimapSize;
        map.OffsetAngle = (offsetAngle == 0? 270: offsetAngle);
        map.IsDirectionInvert = isRevertDir;
        map.DirectionAngle = directionAngle;
        map.Initial();
        
        return map;
    }
    protected void Initial()
    {
        if (TerrianSize != Vector2.zero)
        {
            _Scale.x = TerrianSize.x / UIMapSize.x;
            _Scale.y = TerrianSize.y / UIMapSize.y;
        }

    }
    public virtual Vector2 ConvertPosition(Vector3 worldPosition, bool isNeedToConvert = true)
    {
        Vector2 localPosition = Vector2.zero;
        Vector2 pos = Vector2.zero;
        if (isNeedToConvert)
            pos = new Vector2(worldPosition.x - TerrianCenter.x, worldPosition.z - TerrianCenter.y);
        else
            pos = new Vector2(worldPosition.x - TerrianCenter.x, worldPosition.y - TerrianCenter.y);
        //localPosition = directionFlag * _offSet(pos);
        localPosition = Quaternion.Euler(0, 0, DirectionAngle) * _offSet(pos);
        return localPosition;
    }
    public virtual Quaternion ConvertRotation(Quaternion targetQuaternion)
    {
        Quaternion quaternion = Quaternion.identity;
        Vector3 euler = targetQuaternion.eulerAngles;
        //quaternion = Quaternion.Euler(euler.x, euler.z, 180 - euler.y);
        quaternion = Quaternion.Euler(euler.x, euler.z, OffsetAngle - euler.y);
        return quaternion;
    }
    protected virtual Vector2 _offSet(Vector2 worldOffset)
    {
        Vector2 offset = Vector2.zero;
        offset.x = worldOffset.x / _Scale.x;
        offset.y = worldOffset.y / _Scale.y;
        return offset;
    }
    public virtual void Dispose()
    {

    }
}
