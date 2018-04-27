using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("UI/Extends/EXUIPointerListener(空渲染监听事件控件)")]
[RequireComponent(typeof(CanvasRenderer))]
[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(RectTransform))]
[ExecuteInEditMode]
public class EXUIPointerListener : UIPointerListener
{
    [HideInInspector][SerializeField] BoxCollider _boxCollider = null;
    [HideInInspector][SerializeField] RectTransform _rectTran = null;

    void Awake()
    {
        if (_boxCollider == null)
            MakeDirty();
        
    }
    public void SetColliderNative()
    {
        _boxCollider.center = Vector3.zero;
        _boxCollider.size = _rectTran.rect.size;
    }
    [ContextMenu("MakeDirty")]
    public void MakeDirty()
    {
        _boxCollider = this.GetComponent<BoxCollider>();
        _rectTran = this.GetComponent<RectTransform>();
        _boxCollider.isTrigger = true;
        SetColliderNative();
    }
#if UNITY_EDITOR
    void OnValidate()
    {
        if (Application.isEditor && !Application.isPlaying)
        {
            MakeDirty();
            GraphicRaycaster gr = this.GetComponentInParent<GraphicRaycaster>();
            if (gr != null && !(gr is ExGraphicRaycaster))
            {
                GameObject targetGo = gr.gameObject;
                GameObject.Destroy(gr);
                ExGraphicRaycaster exGr = targetGo.GetComponent<ExGraphicRaycaster>();
                if (exGr == null)
                    targetGo.AddComponent<ExGraphicRaycaster>();
            }
        }
    }
#endif
}
