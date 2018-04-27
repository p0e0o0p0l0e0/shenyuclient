using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StoryCDCameraGroup : StoryCDGroup
{
    protected override void Operate<T>(T t, object obj = null)
    {
        StoryCDCameraItem item = t as StoryCDCameraItem;

        if (item.IsNotNull())
        {
            Camera cam = item.gameObject.AddComponent<Camera>();

            item.Camera = cam;

            StoryCDCameraInfo info = obj as StoryCDCameraInfo;

            if (info.IsNotNull())
            {
                item.SetInfo(info);
            }
        }
    }
}

[System.Serializable]
public class StoryCDCameraInfo
{
    public bool AllowHDR = false;
    public bool AllowMSAA = false;

    public float FieldOfView = 50;
    public float NearClipPlane = 0.1f;
    public float FarClipPlane = 300;
}
