using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class SkillJoy
{
    public static int RIGHT_JOY_RADIUS = 100;
    public int Radius { get; set; }
    public Transform Tran { get; set; }
    public Transform Joy { get; set; }
    public bool IsVisible { get { return _mIsVisible; } }

    private bool _mIsVisible = false;
    private Vector3 _originPos = Vector3.zero;

    public void Open()
    {
        _originPos = Joy.localPosition;
        Tran.gameObject.SetActive(true);
        _mIsVisible = true;
    }
    public void Close()
    {
        Joy.localPosition = _originPos;
        Tran.gameObject.SetActive(false);
        _mIsVisible = false;
    }
    public void UpdateJoyPosition(object obj)
    {
        if (IsVisible && obj is PointerEventData)
        {
            PointerEventData pointerData = obj as PointerEventData;
            Vector3 localPos = UIUtility.ScreenToLocalPosition(Joy, pointerData.position);
            Vector3 joyDir = localPos - _originPos;
            if (Vector3.Distance(_originPos, localPos) <= RIGHT_JOY_RADIUS)
                Joy.localPosition = localPos;
            else
                Joy.localPosition = _originPos + joyDir.normalized * RIGHT_JOY_RADIUS;
            Joy.localPosition = new Vector3(Joy.localPosition.x, Joy.localPosition.y, 0);
        }
    }
    public void SetTargetCenter(Vector3 center)
    {
        Tran.localPosition = center;
    }

}
