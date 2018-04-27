using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("UI/Effects/FontGradient")]
[ExecuteInEditMode]
public class FontGradient : BaseMeshEffect
{
    public Color32 TopColor = Color.white;
    public Color32 BottomColor = Color.white;


    public override void ModifyMesh(VertexHelper vh)
    {
        if (!IsActive()|| vh.currentVertCount == 0) return;
        List<UIVertex> vertexList = new List<UIVertex>();
        vh.GetUIVertexStream(vertexList);
        int count = vertexList.Count ;
        if (count > 0)
        {
            float bottomY = vertexList[0].position.y;
            float topY = vertexList[0].position.y;
            for (int i = 1; i < count; ++i)
            {
                float y = vertexList[i].position.y;
                if (y > topY)
                    topY = y;
                else if (y < bottomY)
                    bottomY = y;
            }
            List<Color32> colors = new List<Color32>();
            float uiElementHeight = topY - bottomY;
            for (int i = 0; i < count; ++i)
            {
                UIVertex uiVerText = vertexList[i];
                Color32 color = Color32.Lerp(BottomColor, TopColor, (vertexList[i].position.y - bottomY) / uiElementHeight);
                color = new Color32(color.r, color.g, color.b, color.a);
                color.a = (byte)((color.a * uiVerText.color.a) / 255);
                uiVerText.color = color;
                vertexList[i] = uiVerText;
            }
            vh.Clear();
            vh.AddUIVertexTriangleStream(vertexList);
        }
    }
}
