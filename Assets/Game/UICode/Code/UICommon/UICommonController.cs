using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ConfirmType
{
    None,
    Yes,
    No,
    YesAndNo,
    Max,
}

public class UICommonController : UIController<UICommonController, UICommonWindow>
{
    public enum WinType
    {
        NONE,
        MASK,
        LOADING,
        HINT,
        CONFIRM,
        MAX ,
    }
    private WinType _mWinType = WinType.NONE;

    protected override void Initial()
    {
        base.Initial();
        this._mLayerType = UIControllerDefine.LayerType.TOP;
        EventDispatcher.AddEventListener<bool>(Events.PlayerEvent.PlayerPathFinding, _mWinHandler.ShowPathFinding);
        EventDispatcher.AddEventListener<bool>(Events.SceneCommonEvent.WaitConnectUI, _mWinHandler.ShowMaskPanel);
        
    }
    public override void Show()
    {
        base.Show();
        this.SetDistance(0);
    }
    public override void Hide()
    {
        base.Hide();
    }
    public void SetWindowType(WinType type, bool isDelayHide = false)
    {
        _mWinType = type;
        if (type == WinType.NONE && isDelayHide)
        {
             ViTimeNode1 _delayTimeNode = new ViTimeNode1();
             ViTimerInstance.SetTime(_delayTimeNode, 1f, (ViTimeNodeInterface node) =>
             {
                 if (IsShow)
                     this._mWinHandler.UpdateWindowType();
                 node.Detach();
              });

        }
        else
        {
            if (IsShow)
                this._mWinHandler.UpdateWindowType();
        }
    }
    public WinType GetWindowType()
    {
        return _mWinType;
    }
    public void SetProgress(float val)
    {
        if (IsShow)
        {
            //if (_mWinType == WinType.NONE)
            //{
            //    _mWinType = WinType.LOADING;
            //    this._mWinHandler.UpdateWindowType();
            //}
           
            this._mWinHandler.SetProgress(val);
        }
            
    }
    public void ShowHint(string msg)
    {
        if (IsShow)
            this._mWinHandler.ShowHint(msg);
    }

    public void ShowConfirm(string content, UICallback.VIO_CB yesAction, UICallback.VIO_CB noAction = null, string yesStr = null, string noStr = null, string title = null, ConfirmType confirmType = ConfirmType.YesAndNo)
    {
        _mWinHandler.ShowConfirm(content, yesAction, noAction, yesStr, noStr, title, confirmType);
    }
}
