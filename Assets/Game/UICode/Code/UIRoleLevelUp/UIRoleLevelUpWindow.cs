using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRoleLevelUpWindow : UIWindow<UIRoleLevelUpWindow, UIRoleLevelUpController>
{
    private const string ClickBtn = "UIRoleLevelUpWindow/ClickBtn";
    private const string effectRoot = "UIRoleLevelUpWindow/EffectRoot";
    private const float delayTime = 2.0f;

    private ExUIButton clickBtn = null;
    private GameObject effctObRoot;
    private ViTimeNode1 timeNode;

    protected override void Initial()
    {
        base.Initial();
        clickBtn = this.GetComponent<ExUIButton>(ClickBtn);
        clickBtn.onClick.AddListener(OnEventClickBtn);
        effctObRoot = this.FindTransform(effectRoot).gameObject;
    }

    public override void Show()
    {
        base.Show();
        if (effctObRoot != null)
        {
            effctObRoot.SetModelAndChildrenLayer(UIDefine.UI_VISIBLE_LAYER);
        }
        timeNode = new ViTimeNode1();
        ViTimerInstance.SetTime(timeNode, delayTime, (ViTimeNodeInterface node) => { OnEventClickBtn(); });
    }

    public override void Hide()
    {
        base.Hide();
        if (effctObRoot != null)
        {
            effctObRoot.SetModelAndChildrenLayer(UIDefine.UI_INVISIBLE_LAYER);
        }
        if (timeNode != null)
        {
            timeNode.Detach();
        }
    }

    public override void Destroy()
    {
        base.Destroy();
    }

    private void OnEventClickBtn()
    {
        UIManager.Instance.Hide(UIControllerDefine.WIN_LevelUp);
    }
}
