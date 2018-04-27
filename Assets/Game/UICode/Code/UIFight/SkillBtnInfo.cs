using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SkillBtnInfo
{
    public Transform Tran { get; set; }
    public UIPointerListener Btn { get; set; }
    public ExUIButton LockObj { get; set; }

    public ExUISprite ProgressSP { get; set; }
    public ExText ProgressText { get; set; }
    public ExCircleSprite Icon { get; set; }
   // private int _timerId = -1;
    private const int RepeatCount = 100;
    private float _stepPercent = 0f;
    private float _curPercent = 0f;
    public float During { get; set; }
    private float Speed { get; set; }
    private float _lastDeltaTime { get; set; }
    private float _totalDuring { get; set; }
    private bool cdIng;

  //  private ViTimeNode4 _updateCD = new ViTimeNode4();
    private ViTickNode _updateCDTimer = new ViTickNode();
    
    public SkillBtnInfo()
    {
    }
    int curRepeatCount = 0;
   // float durinTime = 0;
    //private void _OnTimeOut(ViTimeNodeInterface node)
    //{
    //    //Debug.Log(node.Time);

    //    _lastDeltaTime += Time.deltaTime;
    //    //_curPercent -= Speed * 0.05f;
    //    _curPercent = 1 - _lastDeltaTime / (_totalDuring / 100f);
    //    _curPercent = Math.Max(0, _curPercent);
    //    if (_curPercent <= 0)
    //    {
    //        _updateCD.Detach();
    //    }
    //    SetProgress(_curPercent);
    //}

    private void _OnTimeUpdate(float detalTime)
    {
        _lastDeltaTime += detalTime;
        //_curPercent -= Speed * 0.05f;
        _curPercent = 1 - _lastDeltaTime / (_totalDuring / 100f);
        _curPercent = Math.Max(0, _curPercent);
        if (_curPercent <= 0)
        {
            cdIng = false;
            _updateCDTimer.Detach();
        }
        SetProgress(_curPercent, (_totalDuring / 100f) - _lastDeltaTime);
    }

    public void ResetCD(Int64 curTime, Int64 startTime, Int64 endTime)
    {
        if (cdIng)
            return;
        Int64 leftTime = endTime - curTime;
        _totalDuring = endTime - startTime;
        _lastDeltaTime = 0;
        if (_totalDuring <= 0f)
        {
            _updateCDTimer.Detach();
            _curPercent = 0;
        }
        else
        {
            cdIng = true;
            _curPercent = 1.0f * leftTime / _totalDuring;
            //_updateCD.Start(ViTimerRealInstance.Timer, 0, _OnTimeOut);
            _updateCDTimer.Attach(_OnTimeUpdate);
            //Speed = 100.0f / _totalDuring;
        }
        
        SetProgress(_curPercent,leftTime);
    }
    public void SetProgress(float val,float time)
    {
        if (ProgressSP != null)
        {
            ProgressSP.fillAmount = val;
            if (val <= 0)
            {
                ProgressSP.gameObject.SetActive(false);
                ProgressText.SetTextContent("");
            }
            else
            {
                ProgressText.SetTextContent(time.ToString("F2"));
                ProgressSP.gameObject.SetActive(true);
            }
        }

    }
    public void SetIcon(UIAtlas atlas, string name)
    {
        if (Icon != null && atlas != null)
        {
            Icon.Atlas = atlas;
            Icon.SpriteName = name;
            Icon.material = atlas.spriteMaterial;
            Icon.gameObject.SetActive(true);
            Icon.SetNativeSize();
        }
        else
            Icon.gameObject.SetActive(false);

    }
    public void Close()
    {
        if (ProgressSP != null)
            ProgressSP.gameObject.SetActive(false);
        if (Icon != null)
            Icon.gameObject.SetActive(false);
        if (Btn.Id != 4)
        {
            LockObj.gameObject.SetActive(TalentDataMgr.GetInstance.SpellGridLock(Btn.Id));
        }
        else
        {
            LockObj.SetActive(false);
            Icon.transform.parent.gameObject.SetActive(false);
        }
        Tran.SetActive(!TalentDataMgr.GetInstance.SpellGridLock(Btn.Id));
    }
    public void Open()
    {
        if (ProgressSP != null)
            ProgressSP.gameObject.SetActive(true);
        if (Icon != null)
            Icon.gameObject.SetActive(true);
        Tran.SetActive(true);
    }
    public void Destroy()
    {
        Btn.RelaseAllCallback();
    }
}
