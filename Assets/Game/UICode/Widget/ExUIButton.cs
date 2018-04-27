using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[AddComponentMenu("UI/Extends/ExUIButton")]
public class ExUIButton : Button, IPointerDownHandler, IPointerUpHandler
{
    public int Id { get; set; }
    public UICallback.VIO_CB onClickEx;
    public UICallback.VIO_CB OnTouchDownCallBack;
    public UICallback.VIO_CB OnTouchUpCallBack;
    public ExUISprite _mSprite = null;
    public string mNormalSprite = "";
    public string mPressSprite = "";
    public string mDisableSprite = "";
    private ExText _text = null;
    
    

    //new public ButtonClickedEvent onClick
    //{
    //    set { }
    //}
    protected override void Awake()
    {
        base.Awake();
        _mSprite = this.GetComponent<ExUISprite>();
    }
    protected ExUIButton()
    {
        base.onClick.AddListener(_OnClick);
    }
    private void _OnClick()
    {
        if (onClickEx != null)
            onClickEx(Id, this);
    }
    protected override void DoStateTransition(SelectionState state, bool instant)
    {
        if (transition == Transition.SpriteSwap)
        {
            switch (state)
            {
                case SelectionState.Normal: _UpdateSprite(mNormalSprite); break;
                case SelectionState.Pressed: _UpdateSprite(mPressSprite); break;
                case SelectionState.Disabled: _UpdateSprite(mDisableSprite); break;
                default: _UpdateSprite(mNormalSprite); break;
            }
        }
        else
            base.DoStateTransition(state, instant);

    }
    private void _UpdateSprite(string name)
    {
        if (_mSprite != null && _mSprite.Atlas != null)
        {
            _mSprite.SpriteName = name;
        }
    }
    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        if (OnTouchDownCallBack != null) OnTouchDownCallBack(Id, eventData);
    }
    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        if (OnTouchUpCallBack != null) OnTouchUpCallBack(Id, eventData);
    }

    public void SetCanClick(bool canClick)
    {
        interactable = canClick;
        if (canClick)
            //_UpdateSprite(mNormalSprite);
            SetGray(false);
        else
            //_UpdateSprite(mDisableSprite);
            SetGray(true);
    }
    public void SetGray(bool isGray)
    {
        if (this.targetGraphic is ExUISprite)
        {
            ExUISprite targetSp = this.targetGraphic as ExUISprite;
            if (targetSp != null)
                targetSp.SetGray(isGray);
            if (_text == null)
                _text = this.GetComponentInChildren<ExText>();
            if (_text != null)
                _text.SetGray(isGray);
        }
    }
    protected override void OnDestroy()
    {
        base.OnDestroy();
        this.targetGraphic = null;
    }
}
