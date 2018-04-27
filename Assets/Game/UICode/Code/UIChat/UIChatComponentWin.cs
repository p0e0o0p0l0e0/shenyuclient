using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIChatComponentWin : UIWindowComponent<UIChatWindow, UIChatController>
{
    public abstract void Show();
    public abstract void Hide();
    
}

