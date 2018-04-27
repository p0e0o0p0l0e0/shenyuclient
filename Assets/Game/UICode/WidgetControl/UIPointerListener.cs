using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[AddComponentMenu("UI/Extends/UIPointerListener(需要有渲染控件才能监听事件)")]
public class UIPointerListener : MonoBehaviour ,IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IDropHandler, IPointerExitHandler
{
    public UICallback.VIO_CB OnBeginDragCallBack;
    public UICallback.VIO_CB OnDragCallBack;
    public UICallback.VIO_CB OnEndCallBack;
    public UICallback.VIO_CB OnTouchDownCallBack;
    public UICallback.VIO_CB OnTouchUpCallBack;
    public UICallback.VIO_CB OnMovingInCallBack;
    public UICallback.VIO_CB OnMovingOutCallBack;
    public UICallback.VIO_CB OnDropCallBack;
    public UICallback.VIO_CB OnHoldingCallBack;
    public int Id { get; set; }
    private bool _isHolding { get; set; }
    private PointerEventData _lastHoldingEventData { get; set; }
    [Tooltip("监听屏幕中的区域")]
    public bool IsUseScreenAreaTouch = false;
    private RectTransform rectTransform
    {
        get { return m_RectTransform ?? (m_RectTransform = GetComponent<RectTransform>()); }
    }
    private RectTransform m_RectTransform;
    void Awake()
    {
    }
    public virtual void OnBeginDrag(PointerEventData eventData)
    {
        _lastHoldingEventData = eventData;
        if (OnBeginDragCallBack != null) OnBeginDragCallBack(Id, eventData);
    }

    public virtual void OnDrag(PointerEventData eventData)
    {
        _lastHoldingEventData = eventData;
        if (OnDragCallBack != null) OnDragCallBack(Id, eventData);
    }
    public virtual void OnEndDrag(PointerEventData eventData)
    {
        _lastHoldingEventData = eventData;
        if (OnEndCallBack != null) OnEndCallBack(Id, eventData);
    }
    public virtual void OnPointerDown(PointerEventData eventData)
    {
        _isHolding = true;
        _lastHoldingEventData = eventData;
        if (OnTouchDownCallBack != null) OnTouchDownCallBack(Id, eventData);
    }
    public virtual void OnPointerUp(PointerEventData eventData)
    {
        _isHolding = false;
        _lastHoldingEventData = eventData;
        if (OnTouchUpCallBack != null) OnTouchUpCallBack(Id, eventData);
    }
    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        if (OnMovingInCallBack != null) OnMovingInCallBack(Id, eventData);
    }
    public virtual void OnPointerExit(PointerEventData eventData)
    {
        if (OnMovingOutCallBack != null) OnMovingOutCallBack(Id, eventData);
    }
    public virtual void OnDrop(PointerEventData eventData)
    {
        if (OnDropCallBack != null) OnDropCallBack(Id, eventData);
    }
    void Update()
    {
        if (IsUseScreenAreaTouch)            
        {
            Vector2 screenPoint = Input.mousePosition;
            if (Input.GetMouseButtonDown(0))
            {              
                if (RectTransformUtility.RectangleContainsScreenPoint(rectTransform, screenPoint, UIManager.Instance.UICamera))
                {
                    PointerEventData evtData = new PointerEventData(EventSystem.current);
                    evtData.position = screenPoint;
                    OnPointerDown(evtData);
                }
            }
            else if(Input.GetMouseButtonUp(0) && _isHolding)
            {
                PointerEventData evtData = new PointerEventData(EventSystem.current);
                evtData.position = screenPoint;
                this.OnEndDrag(evtData);
                OnPointerUp(evtData);
                
            }

        }
    
        if (_isHolding)
        {
            if (IsUseScreenAreaTouch)
            {
                Vector2 screenPoint = Input.mousePosition;
                _lastHoldingEventData = new PointerEventData(EventSystem.current);
                _lastHoldingEventData.position = screenPoint;
            }
            if (OnHoldingCallBack != null)
               OnHoldingCallBack(Id, _lastHoldingEventData);
        }

    }
    public void RelaseAllCallback()
    {
        OnBeginDragCallBack = null;
        OnDragCallBack = null;
        OnEndCallBack = null;
        OnTouchDownCallBack = null;
        OnTouchUpCallBack = null;
        OnHoldingCallBack = null;
    }
}
