/******************************************************************************** 
** Copyright(c)
** auth: HooVan
** mail: opecwang@sina.com
** date: 2017.8.22
** desc: 存储控件的depth  
** Ver : V1.0.0 
*********************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
//[ExecuteInEditMode]
public class UIDrawCallCtrl : MonoBehaviour
{
    public enum UIRenderType
    {
        T_NONE = -1,
        T_Graphic = 0,
        T_Particle = 1,
        T_Render = 2,
    }
    public UIPanelCtrl  PanelCtrl { get; set; }
    public int Depth
    {
        get {
            return _mDepth;
        }
        set {
            if (value != _mDepth)
            {
                _mDepth = value;
                if(PanelCtrl != null)
                    PanelCtrl.IsDirty = true;
            }
        }
    }
    public Material RenderMaterial
    {
        get
        {
            return _mDynamicMat;
        }
        set
        {
            if (_mDynamicMat != value)
            {
                if (_mDynamicMat != null)
                    GameObject.DestroyImmediate(_mDynamicMat);
                _mDynamicMat = value;
                this.SetMaterial(_mDynamicMat);
            }
                
        }
    }
    public Material BasicMaterial
    {
        get {
            return _mMaterial;
        }
        set
        {
            _mMaterial = value;
        }
    }
    public int RenderQ
    {
        set {
            if (value != _mRenderQ || _mDynamicMat == null)
            {
                _mRenderQ = value;
                RebuildMaterial();
            }
        }
    }
    [SerializeField]int _mDepth = 0;
    [HideInInspector]Material _mMaterial = null;//樣板材質，複製樣本
    private Material _mDynamicMat = null;
    [SerializeField] protected int _mRenderQ = 3000;
    [HideInInspector][SerializeField] UIRenderType _curRenderType = UIRenderType.T_NONE;//當前UI的渲染器類型
    [HideInInspector][SerializeField] Component _renderComponet = null;
    private bool _mIsRebuild = false;
    public delegate void CallOnRebuild();
    public CallOnRebuild OnRebuild;
    protected virtual void Awake()
    {
         ReFindMaterial(false);
        if (PanelCtrl == null)
            this.RebuildMaterial();         
    }
    /// <summary>
    /// 找到当前节点的material
    /// </summary>
    public void ReFindMaterial(bool isForce)
    {
        if (_mMaterial == null || isForce)
        {
            Material matC = null, matP = null;
            Graphic g = this.GetComponent<Graphic>();
            if (g != null)
            {
                _renderComponet = g;
                matC = g.material;
                _curRenderType = UIRenderType.T_Graphic;
            }

            ParticleSystemRenderer ps = this.GetComponent<ParticleSystemRenderer>();
            if (ps != null)
            {
                _renderComponet = ps;
                matP = ps.sharedMaterial;
                _curRenderType = UIRenderType.T_Particle;
            }

            Renderer render = this.GetComponent<Renderer>();
            if (render != null)
            {
                _renderComponet = render;
                matP = render.sharedMaterial;
                _curRenderType = UIRenderType.T_Render;
            }

            if (matC != null && matP != null)
                Debug.LogError("UI:This node shouldn't have two renders, please modity it[" + this.transform.name + "]");
            _mMaterial = (matC == null ? matP : matC);
        }
    }
    /// <summary>
    /// 重新建立材質，設置新的renderq
    /// </summary>
    public void RebuildMaterial()
    {
        //2017/10/25添加，重新创建前，删除旧的mat
        if (_mDynamicMat != null)
            ClearMat();
        _mIsRebuild = true;
        Shader shader = null;
        if (_mMaterial != null)
        {
            _mDynamicMat = new Material(_mMaterial);
            _mDynamicMat.CopyPropertiesFromMaterial(_mMaterial);
            string[] keywords = _mMaterial.shaderKeywords;
            for (int i = 0; i < keywords.Length; ++i)
                _mDynamicMat.EnableKeyword(keywords[i]);
            shader = Shader.Find(_mMaterial.shader.name);
            if (shader != null)
            {
                _mDynamicMat.shader = shader;
            }
        }
        else
        {
            shader = Shader.Find(UIDefine.UI_SHADER_NORMAL);
            _mDynamicMat = new Material(shader);
        }
        //shader = Shader.Find(UIDefine.UI_SHADER_NORMAL);
        //_mDynamicMat = new Material(shader);
        //_mDynamicMat.name = "[UI]" + transform.name;
        //_mDynamicMat.hideFlags = HideFlags.DontSave | HideFlags.NotEditable;       
        SetMaterial(_mDynamicMat);
        if (OnRebuild != null)
            OnRebuild();
    }
    //void Update()
    //{
    //    SetMaterial(_mDynamicMat);
    //}
    /// <summary>
    ///
    /// </summary>
    public void ForceRebuild()
    {
        //ReFindMaterial(true);
        RebuildMaterial();
    }
    private void SetMaterial(Material mat)
    {
        if (mat != null)
            mat.renderQueue = _mRenderQ;
        if (_curRenderType == UIRenderType.T_Graphic)
        {
            Graphic g = _renderComponet as Graphic;
            g.material = mat;
        }
        else if (_curRenderType == UIRenderType.T_Particle)
        {
            ParticleSystemRenderer ps = _renderComponet as ParticleSystemRenderer;
            ps.material = mat;
        }
        else if (_curRenderType == UIRenderType.T_Render)
        {
            Renderer render = _renderComponet as Renderer;
            render.material = mat;
        }
    }
    public string GetTranName()
    {
        return this.transform.name;
    }
    public void ClearMat()
    {
        SetMaterial(null);
        GameObject.DestroyImmediate(_mDynamicMat);
        _mDynamicMat = null;
    }
    public void OnUpdateMaterial()
    {
        this.ReFindMaterial(true);
    }
    void OnDestroy()
    {
        if (_mIsRebuild)
            ClearMat();
    }
}
