using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UISoundManager : IDisposable
{
    private static UISoundManager _handler = null;
    public static UISoundManager Instance
    {
        get
        {
            if (_handler == null)
                _handler = new UISoundManager();
            return _handler;
        }
    }
    private UISoundManager() { }
    private Dictionary<int, AudioSource> _bgmDic = new Dictionary<int, AudioSource>();
    private Dictionary<int, AudioSource> _soundDic = new Dictionary<int, AudioSource>();
    //private ViTimeNode1 _closeSoundTimeNode = new ViTimeNode1();
    private GameObject UISoundTop { get; set; }


    public void PlayBGM(MusicStruct info, bool IsLoop, bool isStopAll = false)
    {
        if (isStopAll)
            StopAllUIBGM();
        int resourceId = info.Res.Data.ID;
        AudioSource audioSource = null;
        if (!_bgmDic.TryGetValue(resourceId, out audioSource))
        {
            _bgmDic.Add(resourceId, null);

            ResourceRequest mResLoader = new ResourceRequest();
            mResLoader.Start(info.Res.Data, (UnityEngine.Object pAsset) =>
            {
                if (pAsset != null)
                {
                    if (UISoundTop == null)
                        UISoundTop = new GameObject();
                    GameObject soundGo = UnityAssisstant.InstantiateAsChild(pAsset as GameObject, UISoundTop.transform);
                    AudioSource audio = soundGo.GetComponent<AudioSource>();
                    if (audio != null)
                    {
                        audio.loop = IsLoop;
                        audio.volume = info.GetVolume();
                        audio.Play();
                        _bgmDic[resourceId] = audio;

                        if (info.Duration > 0 && !IsLoop)
                        {
                            //每个声音还得搭配个timer去关掉卸载它
                            ViTimeNode1 _closeSoundTimeNode = new ViTimeNode1();
                            ViTimerInstance.SetTime(_closeSoundTimeNode, info.Duration, (ViTimeNodeInterface node) => { node.Detach(); DestroyBGM(resourceId); });
                        }
                    }
                    else
                    {
                        ViDebuger.Warning("UISoundManger res[" + resourceId + "] not find AudioSource");
                    }
                }
                else
                    ViDebuger.Warning("UISoundManger load res[" + resourceId + "] failed");

                mResLoader.End();
            }
            );
        }
        else
        {
            if (audioSource != null)
            {
                audioSource.loop = IsLoop;
                audioSource.volume = info.GetVolume();
                audioSource.Play();
            }
        }
    }
    public void DestroyBGM(int resourceId)
    {
        AudioSource audioSource = null;
        if (_bgmDic.TryGetValue(resourceId, out audioSource))
        {
            _bgmDic.Remove(resourceId);
            GameObject.DestroyImmediate(audioSource.gameObject);
        }
    }
    public void PlayShortSound(MusicStruct info, bool isStopAll = false)
    {
        if (isStopAll)
            StopAllUIShortSound();

    }
    public void StopAllUIBGM()
    {
        foreach (KeyValuePair<int, AudioSource> kvp in _bgmDic)
        {
            if (kvp.Value != null)//有可能正在加载当中,暂时不处理这样的情况
                kvp.Value.Stop();
        }
    }
    public void StopAllUIShortSound()
    {
        foreach (KeyValuePair<int, AudioSource> kvp in _soundDic)
        {
            kvp.Value.Stop();
        }
    }
    public void DestoryAllBGM()
    {
        if (_bgmDic != null)
        {
            foreach (KeyValuePair<int, AudioSource> kvp in _bgmDic)
            {
                GameObject.DestroyImmediate(kvp.Value.gameObject);
            }
        }

    }
    public void DestroyAllShortSound()
    {
        if (_soundDic != null)
        {
            foreach (KeyValuePair<int, AudioSource> kvp in _soundDic)
            {
                GameObject.DestroyImmediate(kvp.Value.gameObject);
            }
        }
    }
    public void Dispose()
    {
        DestoryAllBGM();
        _bgmDic.Clear();
        _bgmDic = null;
        DestroyAllShortSound();
        _soundDic.Clear();
        _soundDic = null;
        _handler = null;
    }
}
