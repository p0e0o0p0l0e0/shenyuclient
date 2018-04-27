using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class STMQuadAnimData
{
    public List<STMQuadData> AnimSprites = new List<STMQuadData>();
    public SuperTextMesh Owner { get; set; }
    public UIAtlas Atlas { get; set; }
    public float Delta { get; set; }
    private float _lastDeltaTime { get; set; }
    private int _stmQuadIndex { get; set; }
    public void CreateAnim(UIAtlas atlas, string[] sprites, float delta = 0f)
    {
        if (atlas != null)
        {
            for (int i = 0; i < sprites.Length; ++i)
            {
                STMQuadData newQuadData = new STMQuadData();
                newQuadData.Atlas = atlas;
                newQuadData.SpriteName = sprites[i];
                AnimSprites.Add(newQuadData);
            }
            Atlas = atlas;
            Delta = delta;
        }
    }
    public void DeleteAnim()
    {
        AnimSprites.Clear();
        Delta = 0f;
        Atlas = null;
    }
    public STMQuadData GetSTMQuadData(float deltaTime)
    {
        STMQuadData stmQuadData = null;
        if (_stmQuadIndex < AnimSprites.Count)
            stmQuadData = AnimSprites[_stmQuadIndex];
        return stmQuadData;
    }
    public bool UpdateSTMQuadData(float deltaTime)
    {
        _lastDeltaTime += deltaTime;
        if (_lastDeltaTime >= Delta)
        {
            _stmQuadIndex = (++_stmQuadIndex) % AnimSprites.Count;
            _lastDeltaTime = 0;
            return true;
        }
        return false;
    }
}
