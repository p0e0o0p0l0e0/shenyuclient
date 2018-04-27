using System;
using System.Collections.Generic;

public class FlyCameraPosDir : CameraPosDirInterface
{
    public ViVector3 Position { get { return _position; } }

    public ViVector3 LookAt { get { return _lookAt; } }

    public float Distance { get { return 1.0f; } set { } }

    public float Field { get { return _field; } }

    public FlyCameraPosDir(ViVector3 position, ViVector3 lookAt, float field)
    {
        _position = position;
        _lookAt = lookAt;
        _field = field;
    }

    public void Update(float deltaTime)
    {

    }
    private ViVector3 _position;
    private ViVector3 _lookAt;
    private float _field;
}
public struct FlyInfo
{
    public List<ViVector3> PosList;
    public Int32 AirDuration;
    public Int32 DownDuration;
    public string AirAnim;
    public string DownAnim;

    public FlyInfo(List<ViVector3> posList, Int32 airDuration, Int32 downDuration, string airAnim,string downAnim)
    {
        PosList = posList;
        AirDuration = airDuration;
        DownDuration = downDuration;
        AirAnim = airAnim;
        DownAnim = downAnim;
    }
    public void Clear()
    {
        PosList.Clear();
        PosList = null;
        AirAnim = null;
        DownAnim = null;
    }
}
