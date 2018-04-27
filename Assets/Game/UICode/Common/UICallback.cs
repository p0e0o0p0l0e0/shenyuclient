using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICallback  {

    public delegate void VV_CB();
    public delegate void VS_CB(string val);
    public delegate UIControllerBase UICTRL_CB(string name);
    public delegate void UIResLoad_CB(string name, object go);
    public delegate void VIO_CB(int val, object obj);
    public delegate void VOO_CB(object obj1, object obj2);
    public delegate void VO_CB(object obj);
}
