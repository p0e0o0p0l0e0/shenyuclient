using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface  IUIController:IDisposable
{
    void Show();//界面显示时调用
    void Hide();//界面关闭时调用
    void ClearData();//界面清除数据时调用
    void Destroy();
}
