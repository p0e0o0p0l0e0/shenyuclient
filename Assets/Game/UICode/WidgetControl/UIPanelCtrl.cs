/******************************************************************************** 
** Copyright(c)
** auth: HooVan
** mail: opecwang@sina.com
** date: 2017.8.22
** desc: 管理控件的depth  
** Ver : V1.0.0 
*********************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
[DisallowMultipleComponent]
[AddComponentMenu("UI/Extends/UIPanelCtrl")]
public class UIPanelCtrl : MonoBehaviour {

    public bool IsDirty { get; set; }//是否重新redepth
    private List<UIDrawCallCtrl> _mDCCtrls = new List<UIDrawCallCtrl>();
    public int BaseRQ = UIDefine.UI_BASE_RENDER_QUEUE;
    [SerializeField] int _mDepth = 0;
    public int Depth
    {
        get
        {
            return _mDepth;
        }
        set
        {
            if (value != _mDepth)
            {
                _mDepth = value;
                this.IsDirty = true;
            }
        }
    }
    public List<UIDrawCallCtrl> DrawList
    {
        get {
            return _mDCCtrls;
        }
    }
    private Canvas _canvas = null;                
    void Awake()
    {
        _canvas = this.GetComponent<Canvas>();
#if UNITY_EDITOR
        if (Application.isEditor && !Application.isPlaying)
        {
            this.ConfigCanvas(_canvas);
        }
#endif
    }
    public Canvas GetCanvas()
    {
        return _canvas;
    }
    void LateUpdate()
    {
        if (IsDirty)
        {//重新计算depth
            SortDepth();
            MakeDirty();
            IsDirty = false;
        }
    }

    /// <summary>
    /// 按照depth的值進行UI控件的排序
    /// </summary>
    //[ContextMenu("make all dirty")]
    void MakeDirty()
    {
        int finalQ = BaseRQ + _mDepth;
        for (int i = 0; i < _mDCCtrls.Count; ++i)
        {
            UIDrawCallCtrl curDCC = _mDCCtrls[i];
            Material curMat = curDCC.RenderMaterial;
            int curMatDepth = curDCC.Depth;
            UIDrawCallCtrl priorDCC = null;
            //if (curMat)
            //    Debug.Log("[UI]UIPanelCtrl find mat is null[" + curDCC.GetTranName() + "], will rebuild its material");
            if (i > 0)
            {
                priorDCC = _mDCCtrls[i - 1];
                bool ret = CheckBatch(priorDCC, curDCC);
                if (!ret)//不可合并，或者同屬於一個批處理
                {
                    if (priorDCC.RenderMaterial == curDCC.RenderMaterial)
                    {//同一批次下，判斷depth是否跟slibingindex一致，如果不一致則交換
                        if (IsNeedResort(priorDCC, curDCC))
                            Switch(priorDCC, curDCC);
                    }
                    else
                    {
                        finalQ += curDCC.Depth;
                        curDCC.RenderQ = finalQ;
                    }
                }
            }
            else
            {
                finalQ += curDCC.Depth;
                curDCC.RenderQ = finalQ;
            }
        }
    }
    void SortDepth()
    {
        _mDCCtrls.Sort(delegate (UIDrawCallCtrl val1, UIDrawCallCtrl val2)
        {
            if (val1.Depth < val2.Depth) return -1;
            else if (val1.Depth > val2.Depth) return 1;
            else 
                return 0;
        }
        );
        //紧凑调整，使得depth相同的UIDrawcall中UIMerDrawCallCtrl都往前移动找到离自己最近的UIMerDrawCallCtrl
        int lastIndex = -1;
        for (int i = 0; i < _mDCCtrls.Count; ++i)
        {
            if (_mDCCtrls[i] is UIMerDrawCallCtrl && lastIndex == -1)//找到第一个可以合并的UIMerDrawCallCtrl
                lastIndex = i;
            if (lastIndex >= 0 && (_mDCCtrls[lastIndex] is UIMerDrawCallCtrl) && (_mDCCtrls[i] is UIMerDrawCallCtrl) && lastIndex != (i - 1))
            {
                if ((lastIndex + 1) < _mDCCtrls.Count && _mDCCtrls[i].Depth == _mDCCtrls[lastIndex + 1].Depth)
                {
                    UIDrawCallCtrl temp = _mDCCtrls[i];
                    _mDCCtrls[i] = _mDCCtrls[lastIndex + 1];
                    _mDCCtrls[lastIndex + 1] = temp;
                    lastIndex++;
                }
                else
                    lastIndex = i;

            }
                
        }
    }
    [ContextMenu("ForceRebuildAll")]
    public void ForceRebuildAll()
    {
        RefreshList();
        this.IsDirty = true;

    }
    void RefreshList()
    {
        _mDCCtrls.Clear();
        UIDrawCallCtrl[] depths = this.transform.GetComponentsInChildren<UIDrawCallCtrl>();
        if (depths.Length > 0)
        {
            for (int i = 0; i < depths.Length; ++i)
            {
                depths[i].PanelCtrl = this;
                _mDCCtrls.Add(depths[i]);
            }
        }
    }
    public void ForceImmediate()
    {
        RefreshList();
        SortDepth();
        MakeDirty();
    }
    void OnEnable()
    {
        ForceRebuildAll();
    }
    void OnDisable()
    {
        //暂时注释掉，忘了当时为什么加这块了2017/10/25
        //for (int i = 0; i < _mDCCtrls.Count; ++i)
        //{
        //    _mDCCtrls[i].ClearMat();
        //}
    }
    private bool CanMerge(UIDrawCallCtrl cc1, UIDrawCallCtrl cc2)
    {
        if (cc1 == null || cc2 == null || !(cc1 is UIMerDrawCallCtrl) || !(cc2 is UIMerDrawCallCtrl)) return false;
        UIMerDrawCallCtrl md1 = (UIMerDrawCallCtrl)cc1;
        UIMerDrawCallCtrl md2 = (UIMerDrawCallCtrl)cc2;
        if (md1 != null && md2 != null && md1.TAG == md2.TAG && md1.RenderMaterial != md2.RenderMaterial) return true;
        else return false;
    }
    private bool CheckBatch(UIDrawCallCtrl priorDCC, UIDrawCallCtrl curDCC)
    {
        if (CanMerge(priorDCC, curDCC))
        {
            //進行合并
            UIMerDrawCallCtrl curMc = curDCC as UIMerDrawCallCtrl;
            curMc.MergeTo(priorDCC.RenderMaterial);
            Debug.Log("[UI]Batch [" + curDCC.name + "] -->" + "[" + priorDCC.name + "]");
            return true;
        }
        return false;
    }
    private bool IsNeedResort(UIDrawCallCtrl priorDCC, UIDrawCallCtrl curDCC)
    {
        bool ret = false;
        int preSiblingInde = priorDCC.transform.GetSiblingIndex();
        int curSiblingInde = curDCC.transform.GetSiblingIndex();
        if ((preSiblingInde < curSiblingInde && priorDCC.Depth < curDCC.Depth) || (preSiblingInde > curSiblingInde && priorDCC.Depth > curDCC.Depth) || (priorDCC.Depth == curDCC.Depth))
        {
            ret = false;
        }
        else
            ret = true;
        return ret;
    }
    private void Switch(UIDrawCallCtrl priorDCC, UIDrawCallCtrl curDCC)
    {
        int preSiblingInde = priorDCC.transform.GetSiblingIndex();
        int curSiblingInde = curDCC.transform.GetSiblingIndex();
        priorDCC.transform.SetSiblingIndex(curSiblingInde);
        curDCC.transform.SetSiblingIndex(preSiblingInde);
    }
    private void ConfigCanvas(Canvas canvas)
    {
        //if (canvas == null)
        //{
        //    Debug.LogError("UIPanelCtrl not find canvas");
        //    return;
        //}
        //canvas.renderMode = RenderMode.ScreenSpaceCamera;
        //canvas.pixelPerfect = true;
        //canvas.planeDistance = 7;
        //CanvasScaler canvasScaler = this.GetComponent<CanvasScaler>();
        //if (canvasScaler == null)
        //{
        //    Debug.LogError("UIPanelCtrl not find CanvasScaler");
        //    return;
        //}
        //canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        //canvasScaler.referenceResolution = new Vector2(1336, 750);
        //canvasScaler.screenMatchMode = CanvasScaler.ScreenMatchMode.MatchWidthOrHeight;
        //canvasScaler.matchWidthOrHeight = 0f;
        //canvasScaler.referencePixelsPerUnit = 100f;
    }
    public void DisableAllDrawCtrl()
    {
        for (int i = 0; i < _mDCCtrls.Count; ++i)
        {
            _mDCCtrls[i].enabled = false;
        }
    }

}
