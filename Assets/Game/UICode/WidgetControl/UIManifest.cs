using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class UIManifest : MonoBehaviour
{
    Dictionary<string, Transform> _mTrans = new Dictionary<string, Transform>();
    [HideInInspector] [SerializeField] List<string> _pathes = new List<string>();
    [HideInInspector] [SerializeField] List<Transform> _trans = new List<Transform>();
    public Action<bool> OnApplicationFocusChange = null;
    public Action<bool> OnApplicationPauseChange = null;
    private CanvasScaler _canvasScaler;
    private Vector2 _panelSize = Vector2.zero;
    void Awake()
    {
        _UpdateTransforms();

#if UNITY_EDITOR
        Canvas canvas = this.GetComponent<Canvas>();
        if (Application.isEditor && !Application.isPlaying)
        {
            this._ConfigCanvas(canvas);
        }
#endif
    }

    [ContextMenu("将text的id转移到正式id中")]
    void UpdateId()
    {
        var textList = transform.GetComponentsInChildren<ExText>(true);
        for (int i = 0; i < textList.Length; i++)
        {
            string id = textList[i].text;
            id = id.Replace("\r", "");
            id = id.Replace("\n", "");
            textList[i].FormateId = id;
        }
    }
#if UNITY_EDITOR
    [ContextMenu("id映射text")]
    void MapIdToText()
    {
        if (Application.isPlaying) return;
        UnityEngine.Object pAsset =
            UnityEditor.AssetDatabase.LoadAssetAtPath<UnityEngine.Object>("Assets/VIBPrefab/FormatStringStruct.prefab");
        ViIStream stream = new ViIStream();
        BlobStream blob = ((GameObject)pAsset).GetComponent<BlobStream>();
        stream.Init(blob.GetData(), 0, blob.GetData().Length);
        ViSealedDB<FormatStringStruct>.Load(stream, false);

        List<FormatStringStruct> infoList = ViSealedDB<FormatStringStruct>.Array;
        for (int iter = 0; iter < infoList.Count; ++iter)
        {
            FormatStringStruct iterInfo = infoList[iter];
            ViFomatString.Dictionary.Set(iterInfo.Name, iterInfo.Value);
            ViFomatString.Dictionary.Broadcast();
            I18NManager.Instance.Append(iterInfo.Name, iterInfo.Value);
        }
        ViSealedDB<FormatStringStruct>.Clear();

        var textList = transform.GetComponentsInChildren<ExText>(true);
        for (int i = 0; i < textList.Length; i++)
        {
            textList[i].FormateId = textList[i].FormateId.Trim();
            textList[i].FormateId = textList[i].FormateId.Replace("\r", "");
            textList[i].FormateId = textList[i].FormateId.Replace("\n", "");
            if (textList[i].FormateId.Usable())
                textList[i].text = I18NManager.Instance.GetWord(textList[i].FormateId);
        }

    }
#endif
    void OnTransformChildrenChanged()
    {
        if (!Application.isPlaying)
            _UpdateTransforms();
    }
    void OnTransformParentChanged()
    {
        if (!Application.isPlaying)
            _UpdateTransforms();
    }
    [ContextMenu("Refresh")]
    private void _UpdateTransforms()
    {
#if UNITY_EDITOR
        if (Application.isEditor && !Application.isPlaying)
        {
            _pathes.Clear();
            _trans.Clear();
            _mTrans.Clear();
            Transform[] trans = this.transform.GetComponentsInChildren<Transform>(true);
            for (int i = 0; i < trans.Length; ++i)
            {
                string fullPath = _GetHierarchy(trans[i].gameObject);
                if (!string.IsNullOrEmpty(fullPath))
                {
                    _pathes.Add(fullPath);
                    _trans.Add(trans[i]);
                }
            }
        }
#endif
        _mTrans.Clear();
        int count = Mathf.Min(_pathes.Count, _trans.Count);
        for (int i = 0; i < count; ++i)
        {
            if (!_mTrans.ContainsKey(_pathes[i]))
                _mTrans.Add(_pathes[i], _trans[i]);
            else
            {
                Debug.LogError("UIManifest same key find=" + _pathes[i] + ", modify it");
            }
        }

    }
    void OnValidate()
    {
#if UNITY_EDITOR
        if (Application.isEditor && !Application.isPlaying)
            _UpdateTransforms();
#endif
    }
    public void Destroy()
    {
        if (_mTrans != null)
            _mTrans.Clear();
        _mTrans = null;
    }
    void OnDestroy()
    {
        Destroy();
    }

    /// <summary>
    /// 得到transform的全路径，最终以该节点名字为根
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    private string _GetHierarchy(GameObject obj)
    {
        if (obj == null) return "";
        string path = obj.name;
        while (obj.transform.parent != null)
        {
            if (obj.transform.name != this.transform.name)
            {
                obj = obj.transform.parent.gameObject;
                path = obj.name + "/" + path;
            }
            else
                break;
        }
        return path;
    }
    public Transform FindTransform(string path)
    {
        Transform tran = null;
        if (!string.IsNullOrEmpty(path))
        {
            if (!_mTrans.TryGetValue(path, out tran) || tran == null)//全路徑搜索
            {
                //部分路徑搜索
                int index = _pathes.FindIndex(0, delegate (string allPath)
                {
                    if (allPath.IndexOf(path) >= 0) return true;
                    else if (allPath.IndexOf(path) < 0) return false;
                    else return false;
                });
                if (index >= 0)
                    tran = _trans[index];
                else
                {
                    tran = this.transform.Find(path);//走unity自然搜索
                    _mTrans[path] = tran;//找过一次就缓存，下次再找就不用Unity搜索了
                    //ViDebuger.Record("Manifest find tranform failed, use the transform.find path=" + path + "");
                }
            }
        }
        return tran;
    }
    /// <summary>
    /// 暂时不做控件缓存处理
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="path"></param>
    /// <returns></returns>
    public T GetComponent<T>(string path)
    {
        Transform tran = FindTransform(path);
        if (tran == null)
        {
            ViDebuger.Record("UIManifest GetComponent:not find transform[" + path + "]");
            return default(T);
        }
        return tran.GetComponent<T>();
    }
    public T[] GetComponents<T>(string path)
    {
        Transform tran = FindTransform(path);
        return tran.GetComponents<T>();
    }
    private void _ConfigCanvas(Canvas canvas)
    {
        if (canvas == null)
        {
            ViDebuger.Record("not find canvas");
            return;
        }
        canvas.renderMode = RenderMode.ScreenSpaceCamera;
        canvas.pixelPerfect = true;
        canvas.planeDistance = 7;
        CanvasScaler canvasScaler = this.GetComponent<CanvasScaler>();
        if (canvasScaler == null)
        {
            ViDebuger.Record("UIPanelCtrl not find canvasScaler");
            return;
        }
        canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        canvasScaler.referenceResolution = UIDefine.DESIGN_RESOLUTION;
        canvasScaler.screenMatchMode = CanvasScaler.ScreenMatchMode.MatchWidthOrHeight;
        canvasScaler.matchWidthOrHeight = 0f;
        canvasScaler.referencePixelsPerUnit = 100f;
    }
    public void ResolutionModity()
    {
        float curRate = 1.0f * Screen.width / Screen.height;
        float designRate = 1.0f * UIDefine.DESIGN_RESOLUTION.x / UIDefine.DESIGN_RESOLUTION.y;
        if (curRate < designRate)
        {
            _canvasScaler = this.GetComponent<CanvasScaler>();
            _canvasScaler.matchWidthOrHeight = 0f;
        }
            
    }
    public bool IsMatchWidthOrHeight()
    {
        if(_canvasScaler ==null)
            _canvasScaler = this.GetComponent<CanvasScaler>();
        return _canvasScaler.matchWidthOrHeight == 0;
    }
    public Vector2 GetPanelSize()
    {
        if (_panelSize == Vector2.zero)
        {
            RectTransform rectTran = this.GetComponent<RectTransform>();
            if (rectTran != null)
                _panelSize = new Vector2(rectTran.rect.width, rectTran.rect.height);
        }
        return _panelSize;
    }
    void OnApplicationFocus(bool hasFocus)
    {
        if (OnApplicationFocusChange != null)
            OnApplicationFocusChange(hasFocus);
    }
    void OnApplicationPause(bool pauseStatus)
    {
        if (OnApplicationPauseChange != null)
            OnApplicationPauseChange(pauseStatus);
    }
}
