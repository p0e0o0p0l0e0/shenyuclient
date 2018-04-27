using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("UI/Extends/UISubPanel")]
public class UISubPanel : MonoBehaviour, ICanvasRaycastFilter
{

    public bool _mIsControlDepth = false;
    [SerializeField] bool _mIsBlocking = false;
    public bool _mIsCollider = false;

    public bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera)
    {
        return !_mIsBlocking;
    }

    /// <summary>
    /// inspector will call this
    /// </summary>
    public void MakeChange()
    {
        if (_mIsCollider)
        {
            GraphicRaycaster gr = this.GetComponent<GraphicRaycaster>();
            if (gr == null)
                this.gameObject.AddComponent<GraphicRaycaster>();
        }
        else
        {
            GraphicRaycaster gr = this.GetComponent<GraphicRaycaster>();
            if (gr != null)
            {
                GameObject.DestroyImmediate(gr);
                Canvas canvas = this.GetComponent<Canvas>();
                if (canvas)
                    GameObject.DestroyImmediate(canvas);
            }

        }
    }
}
