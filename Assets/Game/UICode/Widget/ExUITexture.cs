/******************************************************************************** 
** Copyright(c)
** auth: HooVan
** mail: opecwang@sina.com
** date: 2017.8.22
** desc: ExUITexture  
** Ver : V1.0.0 
*********************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("UI/Extends/ExUITexture")]
public class ExUITexture : RawImage
{
    private UIDrawCallCtrl _mDCC = null;

    public int Width
    {
        get
        {
            return this.texture.width;
        }
        set
        {
            this.rectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 0, value);
            this.rectTransform.localPosition = Vector3.zero;
        }
    }
    public int Height
    {
        get
        {
            return this.texture.height;
        }
        set
        {
            this.rectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, 0, value);
            this.rectTransform.localPosition = Vector3.zero;
        }
    }
    public Vector2 Size
    {
        get
        {
            return new Vector2(Width, Height);
        }
        set
        {
            Width = (int)value.x;
            Height = (int)value.y;
        }
    }
    public float AspectRatio
    {
        get
        {
            return (1.0f * this.rectTransform.sizeDelta.x) / this.rectTransform.sizeDelta.y;
        }
    }
    public bool IsVisible//可不可见，只是单纯设置了alpha值
    {
        get
        {
            return _isVisible;
        }
        set
        {
            _isVisible = value;
            this.color = new Color(color.r, color.g, color.b, _isVisible ? 1f : 0.02f);
        }
    }
    public bool IsNeedAutoMatertial = true;
    public List<string> LoadResName = new List<string>();//动态载入的资源记录
    private bool _isVisible = true;
    public bool isGrandient = false;
    [SerializeField] float _gradientFactor = 1;
    [SerializeField] float _gradientFactorScale = 1;
    protected override void Awake()
    {
        base.Awake();
        _mDCC = this.GetComponent<UIDrawCallCtrl>();
        if (IsNeedAutoMatertial && ((_mDCC == null && this.material == null) || (this.material != null && this.material.shader.name == "UI/Default")))
        {
            _makeMaterial();
        }
    }

    protected override void UpdateMaterial()
    {
        base.UpdateMaterial();
        if (Application.isEditor && !Application.isPlaying)
        {
            if (_mDCC != null)
                _mDCC.OnUpdateMaterial();
        }
    }
    private void _makeMaterial()
    {
        Shader shader = Shader.Find(UIDefine.UI_SHADER_NORMAL);
        Material mat = new Material(shader);
        mat.name = "[UI]" + transform.name;
        mat.hideFlags = HideFlags.DontSave;
        this.material = mat;
    }
    public void UpdateMaterial(Material mat)
    {
        this.material = mat;
    }
    protected override void OnPopulateMesh(VertexHelper vh)
    {
        base.OnPopulateMesh(vh);
        //进行渐变处理
        if (isGrandient)
        {
            List<UIVertex> vertexs = new List<UIVertex>();
            vh.GetUIVertexStream(vertexs);
            vh.Clear();
            float minU = (vertexs[0].uv0.x);
            float maxU = vertexs[vertexs.Count - 2].uv0.x;
            for (int i = 0; i < vertexs.Count; i++)
            {
                UIVertex curVer = vertexs[i];
                float distance = maxU - minU;
                curVer.normal = new Vector3(2 + _gradientFactorScale, minU + distance * _gradientFactor, maxU - minU);
                vh.AddVert(curVer);
                if ((i + 1) % 3 == 0)
                {
                    vh.AddTriangle(i - 2, i - 1, i);
                }
            }
        }
    }
}
