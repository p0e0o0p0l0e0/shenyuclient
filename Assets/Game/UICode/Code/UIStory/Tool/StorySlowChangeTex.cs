using UnityEngine.UI;
using UnityEngine;
/********************************************************************
	created:	2016/09/24
	created:	24:9:2016   11:25
	filename: 	D:\Resource\client\trunk\Project\Assets\Scripts\StorySlowChangeTex.cs
	file path:	D:\Resource\client\trunk\Project\Assets\Scripts\
	file base:	StorySlowChangeTex
	file ext:	cs
	author:		zlj
	
	purpose:	
*********************************************************************/

public class StorySlowChangeTex
{
    //是否在变
    protected bool IsSlow = false;
    //渐隐还是渐现
    protected bool IsShow = true;
    protected float duration = 0;
    protected ExUITexture _uTex = null;
    protected UITexture _nTex = null;
    protected float speed = 0;
    protected float flag = 0;
    protected Color color;

    protected ViTimeNode1 _note1 = new ViTimeNode1();

    public void Init(ExUITexture _tex, float _duration, bool _show)
    {
        _uTex = _tex;
        color = _uTex.color;
        _uTex.color = new Color(color.r, color.g, color.b, _show ? 0 : 1);
        duration = _duration;
        speed = 256f / duration * Time.deltaTime / Time.timeScale;
        flag = 0;
        IsShow = _show;
        IsSlow = true;

        ViTimerVisualInstance.SetTime(_note1,GameTimeScale.DeltaTime, _OnUpdate);
    }

    public void Init(UITexture _tex, float _duration, bool _show)
    {
        _nTex = _tex;
        color = _nTex.color;
        _nTex.color = new Color(color.r, color.g, color.b, _show ? 0 : 1);
        duration = _duration;
        speed = 256f / duration * Time.deltaTime / Time.timeScale;
        flag = 0;
        IsShow = _show;
        IsSlow = true;

        ViTimerVisualInstance.SetTime(_note1, GameTimeScale.DeltaTime, _OnUpdate);
    }
    public bool IsPlaying()
    {
        return IsSlow;
    }
    private void _OnUpdate(ViTimeNodeInterface node)
    {
        if (!IsSlow)
            _note1.Detach();

        SlowTex();
    }

    protected void SlowTex()
    {
        if (flag <= 255)
        {
            flag += speed;
            _uTex.color = new Color(color.r, color.g, color.b, (IsShow ? flag : (255 - flag)) / 255f);
        }
        else
        {
            Reset();
        }
    }

    protected void Reset()
    {
        _note1.Detach();
        IsSlow = false;
        duration = 0;
        _uTex = null;
        _nTex = null;
        speed = 0;
        flag = 0;
    }
}

