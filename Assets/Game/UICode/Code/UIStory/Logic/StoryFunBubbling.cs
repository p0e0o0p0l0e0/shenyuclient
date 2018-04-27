using UnityEngine.UI;
using UnityEngine;
/********************************************************************
	created:	2016/10/19
	created:	19:10:2016   17:32
	filename: 	D:\Resource\client\trunk\Project\Assets\Scripts\StoryFunBubbling.cs
	file path:	D:\Resource\client\trunk\Project\Assets\Scripts
	file base:	StoryFunBubbling
	file ext:	cs
	author:		zlj
	
	purpose:	冒泡逻辑处理类
*********************************************************************/
public class StoryFunBubbling : StoryFunBase
{
    #region ui control name define
    private const string TxtStoryText = "text_speak";
    private const string TexBG = "sprite_bg";
    #endregion

    public int Index { get; private set; }

    //冒泡数据
    private StoryFunctionBubblingData _bubblingData;

    /// 角色对象
    public IStoryCharacter _character;
    /// 对话数据
    public StoryPlayDialog _playDialog;

    private GameObject _bubblingObj;
    private ExUITexture _texBG;
    private Text _txtStoryText;

    /// 对话播放是否结束
    private bool IsDialogEnd = false;

    private ViTimeNode1 _node1 = new ViTimeNode1();
    private ViTimeNode1 _dialogNote1 = new ViTimeNode1();

    /// 对话等待时间
    private float _dialogWaitTime = 0;

    private float _dialogDuration;

    public StoryFunBubbling() { }

    public override void Run(StoryFunctionData data, VoidDelegate callBack)
    {
        Reset();
        base.Run(data, callBack);

        _bubblingData = data.bubblingData;
        Index = data.index;

        InitBubbling();
    }
    private void InitBubbling()
    {
        IStoryCharacter character = StoryManager.GetInstance.GetCharacter(_bubblingData.roleData);

        if (character != null)
        {
            GameObject bubblingObj = character.GetDialogText();
            if (bubblingObj == null)
                bubblingObj = character.CreateDialogText();

            if(bubblingObj != null)
            {
                InitBubbling(character, _functionData, bubblingObj);
            }
            else
            {
                UConsole.LogError(UConsoleDefine.Story, string.Format(
                    "没有找到角色的冒泡UI DialogText .StoryPrefabName:{0},ConditionName:{1},FunctionName:{2}",
                    _functionData.transform.parent.parent.gameObject.name,
                    _functionData.transform.parent.gameObject.name,
                    _functionData.gameObject.name));

                IsDialogEnd = true;
            }
        }
        else
        {
            IsDialogEnd = true;
        }
    }
    /// <summary>
    /// 初始化冒泡数据
    /// </summary>
    /// <param name="character"></param>
    /// <param name="data"></param>
    /// <param name="dialogObj"></param>
    /// <param name="callBack"></param>
    private void InitBubbling(IStoryCharacter character, StoryFunctionData data, GameObject bubblingObj)
    {
        _character = character;

        _bubblingObj = bubblingObj;
        _txtStoryText = bubblingObj.GetComponentPro<Text>(TxtStoryText);
        _texBG = bubblingObj.GetComponentPro<ExUITexture>(TexBG);
        
        _dialogWaitTime = data.bubblingData.dialogWaitTime;

        InitPlayDialog();

        StoryManager.GetInstance.SetTime(_node1, data.startWaitTime, _OnStartWait);
    }
    private void _OnStartWait(ViTimeNodeInterface noteInterface)
    {
        StoryManager.GetInstance.SetTime(_dialogNote1, _dialogWaitTime, (dialogNote) => { PlayDialog(); });
        PlaySound();
    }
    /// <summary>
    /// 重置数据
    /// </summary>
    private void Reset()
    {
        IsDialogEnd = false;

        _dialogDuration = 0;
        _dialogNote1.Detach();
    }
    public override void Stop()
    {
        End();
    }
    /// <summary>
    /// 初始化对话框数据
    /// </summary>
    private void InitPlayDialog()
    {
        //文本对话内容
        _playDialog = new StoryPlayDialog();
        int flag = _bubblingData.roleData.controlType == StoryRoleData.ROLETYPE.HERO ?
            _bubblingData.heroList.FindIndex(_hero => _hero == _bubblingData.roleData.roleId && _hero > 0) : -1;
        if (flag >= 0)
            _playDialog.SetStoryTextData(_bubblingObj,_txtStoryText, _bubblingData.soundDataList[flag].storyTextArray, _bubblingData.soundDataList[flag].waitTime);
        else
        {
            //如果是女主角或者怪物碰到女主角
            if (IsWomanLeaderOrAttachWomanLeader())
                _playDialog.SetStoryTextData(_bubblingObj, _txtStoryText, _bubblingData.soundData1.storyTextArray, _bubblingData.soundData1.waitTime);
            else
                _playDialog.SetStoryTextData(_bubblingObj, _txtStoryText, _bubblingData.soundData.storyTextArray, _bubblingData.soundData.waitTime);
        }
        _playDialog.storyText = _txtStoryText;
        _dialogDuration = _playDialog != null ? _playDialog.GetAllWaitTimes() : 0;
    }
    /// <summary>
    /// 播放对话
    /// </summary>
    public void PlayDialog()
    {
        if (_dialogDuration > 0 && _playDialog != null)
        {
            SetEnable(true);
            _playDialog.PlayDialog(DialogEndCallBack);
        }
        else
        {
            DialogEnd();
        }
    }
    /// <summary>
    /// 播放声音
    /// </summary>
    public void PlaySound()
    {
        if (_playDialog == null)
            return;

        StoryManager.GetInstance.PlaySound(IsWomanLeaderOrAttachWomanLeader() ? 
            _bubblingData.soundData1.soundID : _bubblingData.soundData.soundID,_character);
    }
    /// <summary>
    /// 是否是女主角
    /// </summary>
    /// <returns></returns>
    private bool IsWomanLeader()
    {
        return _bubblingData.roleData.controlType == StoryRoleData.ROLETYPE.LEAD &&
                    StoryManager.GetInstance.GetPlayerGender() == 1;
    }
    /// <summary>
    /// 是否是女主角或者怪物碰到了女主角
    /// </summary>
    /// <returns></returns>
    private bool IsWomanLeaderOrAttachWomanLeader()
    {
        return (_bubblingData.roleData.controlType == StoryRoleData.ROLETYPE.LEAD ||
                    _bubblingData.roleData.controlType == StoryRoleData.ROLETYPE.ENEMY ||
                    _bubblingData.roleData.controlType == StoryRoleData.ROLETYPE.SceneNPC) &&
                    StoryManager.GetInstance.GetPlayerGender() == 1;
    }
    /// <summary>
    /// 设置显示和关闭冒泡
    /// </summary>
    /// <param name="enable"></param>
    private void SetEnable(bool enable)
    {
        if(_bubblingObj != null)
            _bubblingObj.SetActive(enable);
    }
    /// <summary>
    /// 冒泡功能是否结束
    /// </summary>
    /// <returns></returns>
    public bool IsEnd()
    {
        return IsDialogEnd;
    }
    /// <summary>
    /// 冒泡结束
    /// </summary>
    public void End()
    {
        if (_character != null)
        {
            StoryCharacterFactory.DestroyCharacterBubbling(_character);
            if (_bubblingData.isHideCharacter)
            {
                if (_bubblingData.roleData.isLocal)
                    _character.gameObject.SetActive(false);
            }
        }

        EndCallBack();
        Reset();
    }
    public void DialogEnd()
    {
        IsDialogEnd = true;

        if (IsEnd())
            End();
    }
    /// <summary>
    /// 对话播放结束回调
    /// </summary>
    public void DialogEndCallBack()
    {
        SetEnable(false);
        DialogEnd();
    }
}
