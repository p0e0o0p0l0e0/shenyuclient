using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMapNavLineComponent : UIWindowComponent<UIMiniMapWindow, UIMiniMapController>
{
    #region ui control name define
    private const string Line = "Line";
    #endregion

    private LineRenderer _lineRender = null;
    private Vector2 _lineSize = Vector2.zero;
    public override void Initial(UIMiniMapWindow window, string topPath)
    {
        base.Initial(window, topPath);
        _lineRender = this.GetComponent<LineRenderer>(Line);
        if (_lineRender != null)
        {
            Texture lineTex = _lineRender.material.mainTexture;
            if (lineTex != null)
                 _lineSize = new Vector2(lineTex.width, lineTex.height);
        }
    }
    public void SetPath(List<Vector2> path)
    {
        float lineLength = 0;
        _lineRender.positionCount = path.Count;
        for (int i = 0; i < path.Count; ++i)
        {
            _lineRender.SetPosition(i, path[i]);
            if (i > 0)
            {
                lineLength += Vector2.Distance(path[i], path[i - 1]);
            }
        }
        UpdateLineParam(lineLength);
    }
    public void ClearPath()
    {
        if (_lineRender != null)
            _lineRender.positionCount = 0;
    }
    private void UpdateLineParam(float lineLength)
    {
        _lineRender.startWidth = (_lineSize.y / 100);
        _lineRender.endWidth = (_lineSize.y / 100);
        float scaleVale = lineLength / _lineSize.x;
        _lineRender.material.SetTextureScale("_MainTex", new Vector2(scaleVale, 1.0f));
    }
    public override void Dispose()
    {
        _lineRender = null;
        base.Dispose();
    }
}
