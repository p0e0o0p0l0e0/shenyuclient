using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FollowCharacter : MonoBehaviour
{
    private ulong _id;
    public GameObject DialogMenuObject;
    public Camera WorldCamera;
    public Camera UICamera;
    public Transform Target;
    
    private CanvasScaler scaler;

    private float _highOffset = 3.5f;
    private Vector3 _topPos;
    private Vector3 _screenPos;
    private Vector3 _uiPos;

    public void Init(ulong id,Camera world, Camera ui, Transform target)
    {
        _id = id;
        WorldCamera = world;
        UICamera = ui;
        DialogMenuObject = gameObject;
        Target = target;
    }
    void LateUpdate()
    {
        if (Target == null)
            return;

        _topPos = Target.position;
        _topPos.y += _highOffset;
        transform.position = WorldToUIPoint(_topPos);
    }
    public void SetWorldCamera(Camera cam)
    {
        if (cam == null)
        {
            return;
        }
        WorldCamera = cam;
    }

    public void SetLayer(int layer,float highOffset)
    {
        if (layer == 0)
        {
            return;
        }
        _highOffset = highOffset;
        DialogMenuObject.transform.parent.gameObject.layer = layer;
        DialogMenuObject.transform.parent.parent.gameObject.layer = layer;
        Layers.SetlayerRecursively(DialogMenuObject,layer);
    }

    public void SetVisible(bool val)
    {
        gameObject.SetActive(val);
    }
    private Vector3 WorldToUIPoint(Vector3 worldPos)
    {
        _screenPos = WorldCamera.WorldToScreenPoint(worldPos);
        _uiPos = UICamera.ScreenToWorldPoint(_screenPos);
        _uiPos.z = 2;
        return _uiPos;
    }
    private Vector3 WorldToUGUIUI(Camera camera, Vector3 pos)
    {
        float resolutionX = scaler.referenceResolution.x;
        float resolutionY = scaler.referenceResolution.y;

        Vector3 viewportPos = camera.WorldToViewportPoint(pos);

        Vector3 uiPos = new Vector3(viewportPos.x * resolutionX - resolutionX * 0.5f,
            viewportPos.y * resolutionY - resolutionY * 0.5f, 0);

        return uiPos;
    }
}
