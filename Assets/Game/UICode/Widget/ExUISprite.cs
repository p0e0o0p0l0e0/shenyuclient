/******************************************************************************** 
** Copyright(c)
** auth: HooVan
** mail: opecwang@sina.com
** date: 2017.8.22
** desc: ExUISprite  
** Ver : V1.0.0 
*********************************************************************************/
using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

[ExecuteInEditMode]
[AddComponentMenu("UI/Extends/ExUISprite")]
public class ExUISprite : Image
{
    public UIAtlas Atlas
    {
        get
        {
            return _mAtlas;
        }
        set
        {
            if (_isInitial)
            {
                if (_mAtlas != null && _mAtlas.name != value.name)
                    _mAtlas.Release();
            }
            _mAtlas = value;
        }
    }
    public string SpriteName
    {
        get
        {
            return _mSpriteName;
        }
        set
        {
            if (value != _mSpriteName)
            {
                _mSpriteName = value;
                UpdateSprite();
            }
        }
    }

    private Sprite _mSprite = null;
    [SerializeField] string _mSpriteName = "";
    [SerializeField] UIAtlas _mAtlas = null;
    [SerializeField] UIMerDrawCallCtrl _mDCC = null;
    private Color _oldSpColor = Color.white;
    private bool _isInitial = false;
    public bool isGrandient = false;
    //[SerializeField] Vector3 _gradientOffset = Vector2.zero;
    //[SerializeField] Vector3 _gradientSize = Vector2.zero;
    //[SerializeField] Color _gradientColor = Color.white;
    [SerializeField] float _gradientFactor = 1;
    [SerializeField] float _gradientFactorScale = 1;
    public string GetTopParentName()
    {
        return NGUITools.FindInParents<Canvas>(this.gameObject).name;
    }
    protected override void Awake()
    {
        base.Awake();
        getDCC();
        if (_mDCC != null)
            _mDCC.OnRebuild = OnRebuild;
        UpdateSprite();
        if (_mAtlas != null)
        {
            _mAtlas.Retain();
#if UNITY_EDITOR
            _mAtlas.spriteMaterial.shader = Shader.Find(_mAtlas.spriteMaterial.shader.name);
#endif
        }
        _isInitial = true;
    }
    private void OnRebuild()
    {
        UpdateSprite();
    }
    private void UpdateSprite()
    {
        UISpriteData spData = null;
        try
        {
            if (_mAtlas != null && _mAtlas.texture != null && !string.IsNullOrEmpty(_mSpriteName))
            {
                if (_mSprite != null)
                    GameObject.DestroyImmediate(_mSprite);
                spData = _mAtlas.GetSprite(_mSpriteName);
                if (spData != null)
                {
                    Vector2 pivot = new Vector2(0.5f, 0.5f);
                    if (_mSprite != null)
                        pivot = _mSprite.pivot;
                    _mSprite = Sprite.Create(_mAtlas.texture as Texture2D, new Rect(spData.x, _mAtlas.texture.height - spData.height - spData.y, spData.width, spData.height), pivot, 100, 0, SpriteMeshType.Tight, new Vector4(spData.borderLeft, spData.borderBottom, spData.borderRight, spData.borderTop));
                    this.sprite = _mSprite;
                }
                else
                    this.sprite = null;
                if (_mDCC != null)
                    _mDCC.TAG = _mAtlas.name;
                this.material = this.Atlas.spriteMaterial;
            }
        }
        catch (Exception ex)
        {
            ViDebuger.Record(ex.ToString());
        }
    }
    void getDCC()
    {
        if (!Application.isPlaying)
            _mDCC = this.GetComponent<UIMerDrawCallCtrl>();
    }
    public void SetGray(bool isGray)
    {
        this.color = new Color(color.r, color.g, color.b, isGray ? 0.009f : 1f);

    }
#if UNITY_EDITOR
    protected override void OnValidate()
    {
        base.OnValidate();
        if (Application.isEditor && !Application.isPlaying)
        {
            getDCC();
            UpdateSprite();
            if (_mAtlas != null && _mDCC != null)
                _mDCC.BasicMaterial = _mAtlas.spriteMaterial;
        }

    }
#endif
    protected override void OnDestroy()
    {
        this.material = null;
        _mSprite = null;
        if (_mAtlas != null)
            _mAtlas.Release();
        _mAtlas = null;
        base.OnDestroy();
    }

    protected override void OnPopulateMesh(VertexHelper vh)
    {
        base.OnPopulateMesh(vh);
        //进行渐变处理
        if (isGrandient)
        {
#if USE_ADDMESH
            List<UIVertex> vertexs = new List<UIVertex>();
            vh.GetUIVertexStream(vertexs);

            int step = vertexs.Count / 6;
            Vector3 leftTop = Vector3.zero;
            Vector3 leftBottom = Vector3.zero;
            Vector3 rightTop = Vector3.zero;
            Vector3 rightBottom = Vector3.zero;
            for (int i = 0; i < vertexs.Count; ++i)
            {
                UIVertex curVer = vertexs[i];
                curVer.uv1 =  Vector2.zero;
                if (curVer.position.x <= leftBottom.x && curVer.position.y <= leftBottom.y)
                    leftBottom = curVer.position;
                if (curVer.position.x <= leftBottom.x && curVer.position.y >= leftTop.y)
                    leftTop = curVer.position;
                if (curVer.position.x >= rightTop.x && curVer.position.y >= rightTop.y)
                    rightTop = curVer.position;
                if (curVer.position.x >= rightBottom.x && curVer.position.y <= rightBottom.y)
                    rightBottom = curVer.position;
            }

            UIVertex v0 = new UIVertex();
            v0.color = _gradientColor;
            v0.position = leftBottom + _gradientOffset;
            v0.uv0 = new Vector2(0,0);
            v0.uv1 = new Vector2(2, _gradientFactor);
            vh.AddVert(v0);
            UIVertex v1 = new UIVertex();
            v1.color = _gradientColor;
            //v1.position = leftTop + _gradientOffset;
            v1.position = v0.position + new Vector3(0, _gradientSize.y);
            v1.uv0 = new Vector2(0, 1);
            v1.uv1 = new Vector2(2, _gradientFactor);
            vh.AddVert(v1);
            UIVertex v2 = new UIVertex();
            v2.color = _gradientColor;
            //v2.position = rightTop + _gradientOffset;
            v2.position = v0.position + new Vector3(_gradientSize.x, _gradientSize.y, 0);
            v2.uv0 = new Vector2(1, 1);
            v2.uv1 = new Vector2(2, _gradientFactor);
            vh.AddVert(v2);
            UIVertex v3 = new UIVertex();
            v3.color = _gradientColor;
            v3.position = v0.position + new Vector3(_gradientSize.x, 0, 0);
            v3.uv0 = new Vector2(1, 0);
            v3.uv1 = new Vector2(2, _gradientFactor);
            vh.AddVert(v3);
           vh.AddUIVertexQuad(new UIVertex[] { v0, v1, v2, v3 });
#else
            List<UIVertex> vertexs = new List<UIVertex>();
            vh.GetUIVertexStream(vertexs);
            vh.Clear();
            float minU = (vertexs[0].uv0.x);
            float maxU = vertexs[vertexs.Count - 2].uv0.x;
            for (int i = 0; i < vertexs.Count;i ++)
            {
                UIVertex curVer = vertexs[i];
                float distance = maxU - minU;
                curVer.normal = new Vector3(2+ _gradientFactorScale, minU + distance * _gradientFactor, maxU);
                vh.AddVert(curVer);
                if ((i + 1) % 3 == 0)
                {
                    vh.AddTriangle(i-2, i-1, i);
                }
            }
#endif
        }

    }
} 
