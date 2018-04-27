using System.Collections;
using System.Collections.Generic;
using System;

public interface IUIWindow : IDisposable
{
    void Show();
    void Hide();

    void Destroy();
    bool IsResAvaliable();
}
