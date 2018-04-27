using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("UI/Extends/UIBlock")]
public class UIBlock : MonoBehaviour, ICanvasRaycastFilter
{
    public bool isBlock = false;
    public bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera)
    {
        return !isBlock;
    }
}
