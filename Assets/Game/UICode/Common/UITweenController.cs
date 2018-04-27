using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UITweenController<ControllerT, WindowT> : UIController<ControllerT, WindowT>
    where WindowT : UITweenWindow<WindowT, ControllerT>, new()
    where ControllerT : UITweenController<ControllerT, WindowT>, new()
{
    public override void Hide()
    {
        _mWinHandler.HideTween =()=>{
            base.Hide();
        };
        _mWinHandler.Hide();
    }
}