using UnityEngine;
using System.Collections;
using CinemaDirector;

/// <summary>
/// 剧情动画插件
/// </summary>
public class StoryCinemaDirector : MonoBehaviour
{
    /// <summary>
    /// 控制器组建
    /// </summary>
    public Cutscene Cutscene;
    /// <summary>
    /// 子物体列表组控制器
    /// </summary>
    public StoryCDGroup[] Parents;
    /// <summary>
    /// 完成回调 
    /// </summary>
    private VoidDelegate callBack = null;

    void Awake()
    {
        if (Cutscene != null)
        {
            Cutscene.Optimize();
        }
    }

    void OnEnable()
    {
        if (Cutscene != null)
        {
            Cutscene.CutsceneStarted += StartedCallBack;
            Cutscene.CutscenePaused += PausedCallBack;
            Cutscene.CutsceneFinished += FinishedCallBack;
        }
    }
    void OnDisable()
    {
        if (Cutscene != null)
        {
            Cutscene.CutsceneStarted -= StartedCallBack;
            Cutscene.CutscenePaused -= PausedCallBack;
            Cutscene.CutsceneFinished -= FinishedCallBack;
        }
    }

    public bool Init(VoidDelegate callback = null)
    {
        if (Cutscene == null)
        {
            return false;
        }

#if !NoChange
        Cutscene.Initialize();
#endif

        for (int i = 0; i < Parents.Length; i++)
        {
            if (Parents[i] == null)
            {
                continue;
            }
            Parents[i].Init();
        }
        callBack = callback;
        return true;
    }

    public void Clear()
    {

        for (int i = 0; i < Parents.Length; i++)
        {
            if (Parents[i] == null)
            {
                continue;
            }
            Parents[i].Clear();
        }
        callBack = null;
        GameObject.Destroy(gameObject);
    }

    public bool Play()
    {
        if (Cutscene != null)
        {
            Cutscene.Play();
            return true;
        }
        return false;
    }
    public bool Pause()
    {
        if (Cutscene != null)
        {
            Cutscene.Pause();
            return true;
        }
        return false;
    }

    public bool Stop()
    {
        if (Cutscene != null && Cutscene.State == Cutscene.CutsceneState.Playing)
        {
            Cutscene.Skip();
            return true;
        }
        return false;
    }

    private void StartedCallBack(object sender, CutsceneEventArgs e)
    {

    }

    private void FinishedCallBack(object sender, CutsceneEventArgs e)
    {
        if (callBack != null)
        {
            callBack();
            callBack = null;
        }
    }

    private void PausedCallBack(object sender, CutsceneEventArgs e)
    {

    }
}

