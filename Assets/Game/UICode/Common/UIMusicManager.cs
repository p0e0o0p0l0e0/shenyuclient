using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMusicManager
{

    private static UIMusicManager _hander = null;
    public static UIMusicManager Instance
    {
        get {
            if (_hander == null)
                _hander = new UIMusicManager();
            return _hander;
        }
    }
    private UIMusicManager()
    { }
}
