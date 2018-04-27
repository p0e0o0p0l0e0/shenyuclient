using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMiniMap : UIMapBase
{
    public Vector2 MapScale
    {
        get
        {
            return _mapScale;
        }
        set
        {
            _mapScale = value;
        }
    }
    private Vector2 _mapScale = Vector2.one;
    public new static UIMiniMap CreateMap(Vector2 terrianSize, Vector2 terrianCenter, Vector2 uimapSize)
    {
        UIMiniMap map = new UIMiniMap();
        map.TerrianCenter = terrianCenter;
        map.TerrianSize = terrianSize;
        map.UIMapSize = uimapSize;
        map.Initial();
        return map;
    }
    //public override Vector2 ConvertPosition(Vector3 worldPosition)
    //{
    //    return base.ConvertPosition(worldPosition);
    //}
    public override Quaternion ConvertRotation(Quaternion targetQuaternion)
    {
        return base.ConvertRotation(targetQuaternion);
    }
    protected override Vector2 _offSet(Vector2 worldOffset)
    {
        Vector2 offset = Vector2.zero;
        offset.x = worldOffset.x / _Scale.x * MapScale.x;
        offset.y = worldOffset.y / _Scale.y * MapScale.y;
        return offset;
    }
}
