using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[AddComponentMenu("UI/Extends/ExCircleSprite")]
public class ExCircleSprite : CircleImage
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

}
