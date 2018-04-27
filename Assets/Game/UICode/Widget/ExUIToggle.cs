using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

[AddComponentMenu("UI/Extends/ExToggle")]
[RequireComponent(typeof(RectTransform))]
public class ExUIToggle : Selectable, IPointerClickHandler, ISubmitHandler, ICanvasElement
{
    public enum ToggleTransition
    {
        None,
        Fade
    }

    [Serializable]
    public class ToggleEvent : UnityEvent<bool>
    { }

    /// <summary>
    /// Transition type.
    /// </summary>
    public ToggleTransition toggleTransition = ToggleTransition.Fade;

    /// <summary>
    /// Graphic the toggle should be working with.
    /// </summary>
    public ExUISprite rednerSp;

    public string normalSpName = "";
    public string toggleSpName = "";

    public UIAtlas _mAtlas = null;


    /// <summary>
    /// Allow for delegate-based subscriptions for faster events than 'eventReceiver', and allowing for multiple receivers.
    /// </summary>
    public ToggleEvent onValueChanged = new ToggleEvent();

    // Whether the toggle is on
    [FormerlySerializedAs("m_IsActive")]
    [Tooltip("Is the toggle currently on or off?")]
    [SerializeField]
    private bool m_IsOn;

    protected ExUIToggle()
    { }

#if UNITY_EDITOR
    protected override void OnValidate()
    {
        base.OnValidate();
        if (_mAtlas != null && rednerSp != null)
        {
            rednerSp.SpriteName = normalSpName;
            rednerSp.Atlas = _mAtlas;
        }
            
    }

#endif // if UNITY_EDITOR

    public virtual void Rebuild(CanvasUpdate executing)
    {
#if UNITY_EDITOR
        if (executing == CanvasUpdate.Prelayout)
            onValueChanged.Invoke(m_IsOn);
#endif
    }

    public virtual void LayoutComplete()
    { }

    public virtual void GraphicUpdateComplete()
    { }


    protected override void OnDisable()
    {
        SetToggleGroup(null, false);
        base.OnDisable();
    }

    protected override void OnDidApplyAnimationProperties()
    {
        // Check if isOn has been changed by the animation.
        // Unfortunately there is no way to check if we don�t have a graphic.
        if (rednerSp != null && rednerSp.canvasRenderer != null)
        {
            bool oldValue = !Mathf.Approximately(rednerSp.canvasRenderer.GetColor().a, 0);
            if (m_IsOn != oldValue)
            {
                m_IsOn = oldValue;
                Set(!oldValue);
            }
        }

        base.OnDidApplyAnimationProperties();
    }

    private void SetToggleGroup(ToggleGroup newGroup, bool setMemberValue)
    {
        //ToggleGroup oldGroup = m_Group;

        //// Sometimes IsActive returns false in OnDisable so don't check for it.
        //// Rather remove the toggle too often than too little.
        //if (m_Group != null)
        //    m_Group.UnregisterToggle(this);

        //// At runtime the group variable should be set but not when calling this method from OnEnable or OnDisable.
        //// That's why we use the setMemberValue parameter.
        //if (setMemberValue)
        //    m_Group = newGroup;

        //// Only register to the new group if this Toggle is active.
        //if (newGroup != null && IsActive())
        //    newGroup.RegisterToggle(this);

        //// If we are in a new group, and this toggle is on, notify group.
        //// Note: Don't refer to m_Group here as it's not guaranteed to have been set.
        //if (newGroup != null && newGroup != oldGroup && isOn && IsActive())
        //    newGroup.NotifyToggleOn(this);
    }

    /// <summary>
    /// Whether the toggle is currently active.
    /// </summary>
    public bool isOn
    {
        get { return m_IsOn; }
        set
        {
            Set(value);
        }
    }

    void Set(bool value)
    {
        Set(value, true);
    }

    void Set(bool value, bool sendCallback)
    {
        if (m_IsOn == value)
            return;

        // if we are in a group and set to true, do group logic
        m_IsOn = value;
        this.rednerSp.SpriteName = (m_IsOn? toggleSpName : normalSpName);

        if (sendCallback)
            onValueChanged.Invoke(m_IsOn);
    }


    /// <summary>
    /// Assume the correct visual state.
    /// </summary>
    protected override void Start()
    {
        this.transition = Transition.None;
    }

    private void InternalToggle()
    {
        if (!IsActive() || !IsInteractable())
            return;

        isOn = !isOn;
    }

    /// <summary>
    /// React to clicks.
    /// </summary>
    public virtual void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Left)
            return;

        InternalToggle();
    }

    public virtual void OnSubmit(BaseEventData eventData)
    {
        InternalToggle();
    }

}
