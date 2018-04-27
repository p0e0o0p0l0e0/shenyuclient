using UnityEngine;
using System;
using System.Collections.Generic;

/// <summary>
/// 剧情条件触发者
/// zlj
/// </summary>
/// 
[RequireComponent(typeof(StoryConditionData))]
public class StoryCondition : MonoBehaviour
{
    public enum STATE
    {
        /// <summary>
        /// 暂停状态
        /// </summary>
        PAUSE,
        /// <summary>
        /// 检查状态
        /// </summary>
        RUN,
        /// <summary>
        /// 播放状态.
        /// </summary>
        PLAY,
        /// <summary>
        /// 停止状态
        /// </summary>
        CLOSE,

    }
    /// <summary>
    /// 状态
    /// </summary>
    private STATE state;

    /// <summary>
    /// 数据
    /// </summary>
    private StoryConditionData data;

    /// <summary>
    /// 触发者
    /// </summary>
    private Transform triggerTr;

    /// <summary>
    /// 当前触发区域
    /// </summary>
    private BoxCollider boxCollider;
    /// <summary>
    /// 结束回调
    /// </summary>
    private Action<StoryConditionData.CONDITION_TYPE,string,bool> EndCallBack = null;
    /// <summary>
    /// 剧情功能实现者
    /// </summary>
    private StoryFunction[] functiondataArray;
    //串行功能
    private List<StoryFunction> serialFunList = new List<StoryFunction>();
    private int curSerialFunIndex = 0;
    private bool isSerialEnd = false;
    //并行功能
    private List<StoryFunction> concurrencyFunList = new List<StoryFunction>();
    private int curConFunIndex = 0;
    private bool isConcurrencyEnd = false;
    /// <summary>
    /// 是否播放过在区域内
    /// </summary>
    private bool isPlayedTriggerRect = false;
    /// <summary>
    /// 区域触发不需要其他条件
    /// </summary>
    private bool isRectNoNeedOtherCondition = true;
    /// <summary>
    /// 触发数量
    /// </summary>
    private int triggerCount = 0;

    #region Start
    private void Reset()
    {
        serialFunList.Clear();
        concurrencyFunList.Clear();
        curSerialFunIndex = 0;
        curConFunIndex = 0;
        isSerialEnd = false;
        isConcurrencyEnd = false;
    }
    /// <summary>
    /// 初始化数据
    /// </summary>
    private void InitData()
    {
        //自己重置高度
        ViVector3 v3 = transform.position.ToViV3();
        if (GroundHeight.GetGroundHeight(ref v3))
            transform.position = v3.ToV3();
        else
            UConsole.LogError("当前Condition位置有问题");

        Reset();
        if (data == null)
            data = GetComponent<StoryConditionData>();

        functiondataArray = GetComponentsInChildren<StoryFunction>();
        for (int i = 0; i < functiondataArray.Length; i++)
        {
            StoryFunctionData funData = functiondataArray[i].GetComponent<StoryFunctionData>();
            if (funData != null)
            {
                if (funData.type == StoryFunctionData.FUCTION_TYPE.TEXTURE)
                    serialFunList.Add(functiondataArray[i]);
                else
                    concurrencyFunList.Add(functiondataArray[i]);
            }
        }
        if (serialFunList.Count == 0)
            isSerialEnd = true;
        if (concurrencyFunList.Count == 0)
            isConcurrencyEnd = true;
        Ob_Init();
    }
    /// <summary>
    /// 载入关卡初始化开始启动条件
    /// </summary>
    public void StartRun(Action<StoryConditionData.CONDITION_TYPE,string,bool> callBack)
    {
        EndCallBack = callBack;
        InitData();
        if (state != STATE.CLOSE)
        {
            SetState(STATE.RUN);
        }
        AutoPlay();
    }
    /// <summary>
    /// 开启剧情模式
    /// </summary>
    private void StartStoryModel()
    {
        if (data.playInStoryModel && !StoryManager.GetInstance.IsInStoryModel)
        {
            UConsole.Log("当前不在特殊剧情模式中，不能播放此剧情");
            return;
        }
        if (state != STATE.RUN)
        {
            UConsole.Log("正在播剧情，多重触发被忽略。");
            return;
        }
        UConsole.Log(string.Format("开始播放剧情，剧情名字：{0}, 触发物体名字: {1},触发类型：{2}", transform.parent.name, gameObject.name, data.type));
        StoryManager.GetInstance.CancelAutoFighting();
        if(data.isNoticeServerLoadNPC)
            EventDispatcher.TriggerEvent<string>(Events.StoryEvent.StoryStart,transform.parent.name);
        if(data.isNoticeServerEnterStoryModel)
            StoryManager.GetInstance.NoticeServerEnterStoryModel(data.goalID);
        LoadLocalEntity();
        SetState(STATE.PLAY);
    }
    /// <summary>
    /// 关闭剧情触发和剧情
    /// </summary>
    private void Close(bool callBack = true)
    {
        Ob_Release();
        SetState(STATE.CLOSE);

        DestoryLocalEntity();

        //if (callBack)
        {
            if (EndCallBack != null)
                EndCallBack(data.type, gameObject.name,data.isEndForceDestory);
        }
        //else
        //{
        //    StoryControl control = transform.parent.GetComponent<StoryControl>();
        //    if (control != null)
        //        control.EndNotCallBack(data.type, gameObject.name, data.isEndForceDestory);
        //}
    }
    /// <summary>
    /// 强制停止剧情
    /// </summary>
    public void Stop()
    {
        StopFunction();
        Close();
    }
    /// <summary>
    /// 设置播放状态
    /// </summary>
    /// <param name="_state"></param>
    private void SetState(STATE _state)
    {
        state = _state;
        switch (state)
        {
            case STATE.PLAY:
                {
                    PlayFucntion();
                }
                break;
        }
    }
    #endregion
    #region PlayAndEnd
    /// <summary>
    /// 播放剧情功能
    /// </summary>
    private void PlayFucntion()
    {
        if (serialFunList.Count == 0 && concurrencyFunList.Count == 0)
        {
            Close(false);
        }
        else
        {
            PlaySerialFunction();
            PlayConcurrencyFunction();
            if (serialFunList.Count > 0 && serialFunList[0].IsChangCameraView())
                StoryManager.GetInstance.ChangeCameraView(true, serialFunList[0].FunData.textData.appearanceData.newView);
        }
    }
    private void PlaySerialFunction()
    {
        if (serialFunList.Count > 0)
            serialFunList[curSerialFunIndex].Play(curSerialFunIndex, SerialCallback);
    }
    private void PlayConcurrencyFunction()
    {
        for (int i = 0; i < concurrencyFunList.Count; i++)
        {
            if (concurrencyFunList[i].isAutoPlay)
                concurrencyFunList[i].Play(i, ConcurrencyCallback);
        }
    }
    private void StopFunction()
    {
        for (int i = 0; i < serialFunList.Count; i++)
            serialFunList[i].Stop();

        for (int i = 0; i < concurrencyFunList.Count; i++)
            concurrencyFunList[i].Stop();

        StoryManager.GetInstance.ChangeCameraView(false);
    }
    private bool PlayReqFunction(StoryFunction fun)
    {
        StoryFunction nextFunc = fun.FunData.reqStoryFunction;
        if (nextFunc == null)
        {
            return false;
        }
        if (nextFunc.IsCanNotNext())
        {
            return false;
        }
        if (!nextFunc.isAutoPlay)
        {
            int flag = concurrencyFunList.FindIndex(_item => _item == nextFunc);
            if (flag >= 0)
            {
                nextFunc.Play(flag, ConcurrencyCallback);
                return true;
            }
        }
        return false;
    }
    private void SerialCallback(StoryFunction fun)
    {
        UConsole.Log("[剧情单条完成]StoryFunttion SerialCallback，name：" + fun.name);
        curSerialFunIndex++;

        if (curSerialFunIndex >= serialFunList.Count)
        {
            isSerialEnd = true;
            StoryManager.GetInstance.ChangeCameraView(false);
            End();
        }
        else
        {
            PlaySerialFunction();
        }
        PlayReqFunction(fun);
    }
    private void ConcurrencyCallback(StoryFunction fun)
    {
        UConsole.Log("[剧情单条完成]StoryFunttion ConcurrencyCallback，name：" + fun.name);
        curConFunIndex++;

        if (curConFunIndex >= concurrencyFunList.Count)
        {
            isConcurrencyEnd = true;
            End();
        }
        else
        {
            PlayReqFunction(fun);
        }
    }
    private void End()
    {
        if (isSerialEnd && isConcurrencyEnd)
            Close();
    }
#endregion
    #region
    public bool IsResultEndType()
    {
        return data == null ? false : data.type == StoryConditionData.CONDITION_TYPE.RESUILTEND;
    }
    public bool IsBattleWinType()
    {
        return data == null ? false : data.type == StoryConditionData.CONDITION_TYPE.BATTLEWIN;
    }
    public bool IsRunningStory()
    {
        return state == STATE.PLAY;
    }
    public void EnterStoryModel()
    {

    }
    public void ExitStoryModel()
    {

    }
    private void DestoryLocalEntity()
    {
        for (int i = 0; i < data.roleDataList.Count; i++)
        {
            if (data.roleDataList[i].isDestory)
            {
                switch (data.roleDataList[i].controlType)
                {
                    case StoryRoleData.ROLETYPE.LEAD:
                        StoryCharacterFactory.DestoryStoryCharacter();
                        break;
                    case StoryRoleData.ROLETYPE.ENEMY:
                    case StoryRoleData.ROLETYPE.SceneNPC:
                        StoryCharacterFactory.DestoryStoryCharacter(data.roleDataList[i].npcBirthPositionID, data.roleDataList[i].npcBirthPositionIndex);
                        break;
                }
            }
        }
    }
    private void LoadLocalEntity()
    {
        for (int i = 0; i < data.roleDataList.Count; i++)
        {
            switch (data.roleDataList[i].controlType)
            {
                case StoryRoleData.ROLETYPE.LEAD:
                    {
                        StoryCharacterFactory.Generate(data.roleDataList[i].position, data.roleDataList[i].angle);
                    }
                    break;
                case StoryRoleData.ROLETYPE.ENEMY:
                case StoryRoleData.ROLETYPE.SceneNPC:
                    {
                        IStoryCharacter character = StoryCharacterFactory.Generate(data.roleDataList[i]);
                        if (character != null && data.isBroadCast)
                            character.LookAtPlayer();
                    }
                    break;
            }
        }
    }
    #endregion
    #region 触发条件
    void OnTriggerEnter(Collider collider)
    {
        if (state != STATE.RUN)
            return;
        if (data.type != StoryConditionData.CONDITION_TYPE.RECT)
            return;
        if (!IsTriggerTrans(collider))
            return;
        triggerCount++;
        if (isRectNoNeedOtherCondition)
            PlayRectStory();
    }
    void OnTriggerExit(Collider collider)
    {
        if (state != STATE.RUN)
            return;
        if (data.type != StoryConditionData.CONDITION_TYPE.RECT)
            return;
        if (!IsTriggerTrans(collider))
            return;
        triggerCount--;
        if (triggerCount < 0)
            triggerCount = 0;

    }
    private bool IsTriggerTrans(Collider collider)
    {
        if (triggerTr == null)
            GetTriggerTrans();
        if (triggerTr == null)
            return false;
        return triggerTr.Equals(collider.transform);
    }
    private void GetTriggerTrans()
    {
        IStoryCharacter character = StoryManager.GetInstance.GetCharacter(data.roleData);

        if (character != null)
        {
            BoxCollider bc = character.gameObject.GetComponentInChildren<BoxCollider>();
            if (bc != null)
                triggerTr = bc.transform;
            else
                UConsole.LogError(UConsoleDefine.Story, "角色身上没有找到碰撞器," + data.roleData.controlType);
            Rigidbody rigidbody = character.gameObject.GetComponentInChildren<Rigidbody>();
            if (rigidbody == null)
                UConsole.LogError(UConsoleDefine.Story, "角色身上没有找到Rigidbody," + data.roleData.controlType);
        }
        else
            UConsole.LogError("区域触发初始化没有找到对应角色," + data.roleData.controlType);
    }
    /// <summary>
    /// 检查触发者是否触发
    /// </summary>
    /// <returns><c>true</c>, if trigger was checked, <c>false</c> otherwise.</returns>
    private bool CheckTrigger()
    {
        if (triggerTr != null)
        {
            if (boxCollider.bounds.Contains(triggerTr.position))
            {
                return true;
            }
        }
        return false;
    }
    /// <summary>
    /// 区域触发
    /// </summary>
    private void TriggerRect()
    {
        if (triggerCount <= 0)
        {
            return;
        }

        if (data.type == StoryConditionData.CONDITION_TYPE.RECT)
            PlayRectStory();
    }
    private void PlayRectStory()
    {
        UConsole.Log("[触发剧情事件] 进入区域");
        StartStoryModel();
    }
    /// <summary>
    /// 进入闯关
    /// </summary>
    /// <param ></param>
    private void EnterBattle()
    {
        if (data.type == StoryConditionData.CONDITION_TYPE.ENTER)
        {
            UConsole.Log("[触发剧情事件] 进入闯关");
            StartStoryModel();
        }
    }
    /// <summary>
    ///战斗开始
    /// </summary>
    /// <param ></param>
    private void BattleBeginning()
    {
        if (data.type == StoryConditionData.CONDITION_TYPE.BEGINNING)
        {
            UConsole.Log("[触发剧情事件] 战斗开始");
            StartStoryModel();
        }
    }
    /// <summary>
    /// 战斗胜利
    /// </summary>
    private void BattleWin()
    {
        if (data.type == StoryConditionData.CONDITION_TYPE.BATTLEWIN)
        {
            UConsole.Log("[触发剧情事件]  战斗胜利");
            StartStoryModel();
        }
    }
    /// <summary>
    /// 一组角色死亡
    /// </summary>
    /// <param ></param>
    private void GroupCharacterDead(int waveID)
    {
        if (data.type == StoryConditionData.CONDITION_TYPE.GROUPDEAD)
        {
            int flag = data.waveData.waveBirthPosList.FindIndex(_item=>_item == waveID);
            if (flag >= 0)
            {
                data.waveData.waveBirthPosList.RemoveAt(flag);

                if (data.waveData.waveBirthPosList.Count == 0)
                {
                    UConsole.Log("[触发剧情事件]  一波怪物死亡，waveID:" + waveID + "，当前condition波ID：" + waveID);
                    StartStoryModel();
                }
            }
        }
    }
    /// <summary>
    /// 某波角色加载后 (敌军，援军，剧情NPC)
    /// </summary>
    private void WaveLoaded(int waveID)
    {
        if (data.type == StoryConditionData.CONDITION_TYPE.LOADEDWAVEROLES)
        {
            int flag = data.waveData.waveBirthPosList.FindIndex(_item => _item == waveID);
            if (flag >= 0)
            {
                UConsole.Log("[触发剧情事件]  某波角色加载后，waveID:" + waveID);
                StartStoryModel();
            }
        }
    }
    /// <summary>
    /// 某只怪加载
    /// </summary>
    private void OnNPCCreated(IGoalFlag goalNPC)
    {
        if (data.type == StoryConditionData.CONDITION_TYPE.LOADEDWAVEROLES)
        {
            //UConsole.LogError(goalNPC.BirthID + "");
            if (data.waveData.waveBirthPosList.Contains(goalNPC.BirthID))
            {
                data.waveData.waveBirthPosList.Remove(goalNPC.BirthID);

                if (data.waveData.waveBirthPosList.Count == 0)
                {
                    UConsole.Log("[触发剧情事件]  某波角色加载后");
                    StartStoryModel();
                }
            }
        }
    }

    /// <summary>
    /// 到达第几波怪的CENTER点
    /// </summary>
    private void ArriveCenter(int waveID)
    {
        if (data.type == StoryConditionData.CONDITION_TYPE.ARRIVEWAVECENTER)
        {
            int flag = data.waveData.waveBirthPosList.FindIndex(_item => _item == waveID);
            if (flag >= 0)
            {
                UConsole.Log("[触发剧情事件]  到达第几波怪的CENTER点，waveID:" + waveID);
                StartStoryModel();
            }
        }
    }
    /// <summary>
    /// 血量低于一定值
    /// </summary>
    /// <param ></param>
    private void BloodLimit(IStoryCharacter character, float bloodPercent)
    {
        if (character == null)
        {
            UConsole.LogError("IStoryCharacter==null.");
            return;
        }

        if (data.type == StoryConditionData.CONDITION_TYPE.BLOODMINLIMIT)
        {
            IStoryCharacter role = StoryManager.GetInstance.GetCharacter(data.waveData.roleData);

            if (role != null && character.Equals(role))
            {
                if (data.bloodLimitPercent >= bloodPercent)
                {
                    UConsole.Log("[触发剧情事件]  血量低于一定值，bloodPercent:" + bloodPercent + ", IStoryCharacter: " + character);
                    StartStoryModel();
                }
            }
        }
    }
    /// <summary>
    /// 释放技能
    /// </summary>
    /// <param name="skillID"></param>
    private void PlaySkill(UInt32 skillID, IStoryCharacter character)
    {
        if (data.type == StoryConditionData.CONDITION_TYPE.PLAYSKILL)
        {
            IStoryCharacter role = StoryManager.GetInstance.GetCharacter(data.roleData);

            if (data.skillID == skillID && role != null && role.Equals(character))
            {
                UConsole.Log("[触发剧情事件]  释放技能，skillID:" + skillID + ", IStoryCharacter: " + character);
                StartStoryModel();
            }
        }
    }
    /// <summary>
    /// 自动播放
    /// </summary>
    private void AutoPlay()
    {
        if (data.type == StoryConditionData.CONDITION_TYPE.AUTOPLAY)
        {
            UConsole.Log("[触发剧情事件]  自动播放");
            StartStoryModel();
        }
    }
    /// <summary>
    /// 其他剧情条件完成触发此条件
    /// </summary>
    private void TriggerCondition(string storyRootName, string storyConditionName, object arg)
    {
        if (data.type == StoryConditionData.CONDITION_TYPE.TRIGGERCONDITION)
        {
            //1.在同一父物体下2.不是本条件3.id相同
            if (transform.parent.name.Equals(storyRootName) && 
                !gameObject.name.Equals(storyConditionName) &&
                data.storyConditionID.ToString().Equals(storyConditionName))
                StartStoryModel();
        }
    }
    /// <summary>
    /// 任务完成触发
    /// </summary>
    /// <param name="storyRootName"></param>
    /// <param name="storyConditionName"></param>
    /// <param name="arg"></param>
    private void GoalComplete(uint goalID)
    {
        if (data.type == StoryConditionData.CONDITION_TYPE.GOALCOMPLETE)
        {
            if (goalID == data.goalID)
            {
                StartStoryModel();
            }
        }
    }
    /// <summary>
    /// 测试用
    /// </summary>
    private void Test()
    {
        if (data.type == StoryConditionData.CONDITION_TYPE.TEST)
        {
            UConsole.Log("[触发剧情事件]  测试用");
            StartStoryModel();
        }
    }
    #endregion
    #region Ob_Init
    /// <summary>
    /// 初始化观察者（把自己注册到要观察的对象中去）
    /// </summary>
    public void Ob_Init()
    {
        switch (data.type)
        {
            case StoryConditionData.CONDITION_TYPE.RECT:
                {
                    if (boxCollider == null)
                    {
                        boxCollider = GetComponent<BoxCollider>();
                        float y = boxCollider.size.y / 2;
                        boxCollider.center = Vector3.up * y;
                    }
                    GetTriggerTrans();
                    isRectNoNeedOtherCondition = data.rectConditionID < 0;
                    if (!isRectNoNeedOtherCondition)
                        EventDispatcher.AddEventListener(Events.StoryEvent.ArriveTargetPlace,TriggerRect);
                }
                break;
            case StoryConditionData.CONDITION_TYPE.ENTER:
                EventDispatcher.AddEventListener(Events.BattleEvent.BattleEnter, EnterBattle);
                break;
            case StoryConditionData.CONDITION_TYPE.RESUILTEND:
                break;
            case StoryConditionData.CONDITION_TYPE.GROUPDEAD:
                EventDispatcher.AddEventListener<int>(Events.BattleEvent.BattleWaveDie, GroupCharacterDead);
                break;
            case StoryConditionData.CONDITION_TYPE.LOADEDWAVEROLES:
                EventDispatcher.AddEventListener<IGoalFlag>(Events.SceneCommonEvent.NPCCreated, OnNPCCreated);
                //EventDispatcher.AddEventListener<int>(Events.BattleEvent.BattleWaveLoaded, WaveLoaded);
                break;
            case StoryConditionData.CONDITION_TYPE.ARRIVEWAVECENTER:
                EventDispatcher.AddEventListener<int>(Events.BattleEvent.ArriveWaveCenter, ArriveCenter);
                break;
            case StoryConditionData.CONDITION_TYPE.BLOODMINLIMIT:
                EventDispatcher.AddEventListener<IStoryCharacter, float>(Events.BattleEvent.HpChanged, BloodLimit);
                break;
            case StoryConditionData.CONDITION_TYPE.BEGINNING:
                EventDispatcher.AddEventListener(Events.StoryEvent.BattleBeginning, BattleBeginning);
                break;
            case StoryConditionData.CONDITION_TYPE.BATTLEWIN:
                EventDispatcher.AddEventListener(Events.StoryEvent.BattleWin, BattleWin);
                break;
            case StoryConditionData.CONDITION_TYPE.PLAYSKILL:
                EventDispatcher.AddEventListener<UInt32, IStoryCharacter>(Events.SkillEvent.SkillStart,PlaySkill);
                break;
            case StoryConditionData.CONDITION_TYPE.TRIGGERCONDITION:
                EventDispatcher.AddEventListener<string, string, object>(Events.StoryEvent.PlayStoryEnd, TriggerCondition);
                break;
            case StoryConditionData.CONDITION_TYPE.GOALCOMPLETE:
                EventDispatcher.AddEventListener<uint>(Events.GoalEvent.OnGoalComplete, GoalComplete);
                break;
        }
    }
    #endregion
    #region Ob_Release
    /// <summary>
    /// 释放观察者（把自己从那些观察的对象中删除掉）
    /// </summary>
    public void Ob_Release()
    {
        switch (data.type)
        {
            case StoryConditionData.CONDITION_TYPE.RECT:
                triggerTr = null;
                if (!isRectNoNeedOtherCondition)
                    EventDispatcher.RemoveEventListener(Events.StoryEvent.ArriveTargetPlace, TriggerRect);
                break;
            case StoryConditionData.CONDITION_TYPE.ENTER:
                EventDispatcher.RemoveEventListener(Events.BattleEvent.BattleEnter, EnterBattle);
                break;
            case StoryConditionData.CONDITION_TYPE.RESUILTEND:
                break;
            case StoryConditionData.CONDITION_TYPE.GROUPDEAD:
                EventDispatcher.RemoveEventListener<int>(Events.BattleEvent.BattleWaveDie, GroupCharacterDead);
                break;
            case StoryConditionData.CONDITION_TYPE.LOADEDWAVEROLES:
                EventDispatcher.RemoveEventListener<IGoalFlag>(Events.SceneCommonEvent.NPCCreated, OnNPCCreated);
                //EventDispatcher.RemoveEventListener<int>(Events.BattleEvent.BattleWaveLoaded, WaveLoaded);
                break;
            case StoryConditionData.CONDITION_TYPE.ARRIVEWAVECENTER:
                EventDispatcher.RemoveEventListener<int>(Events.BattleEvent.ArriveWaveCenter, ArriveCenter);
                break;
            case StoryConditionData.CONDITION_TYPE.BLOODMINLIMIT:
                EventDispatcher.RemoveEventListener<IStoryCharacter, float>(Events.BattleEvent.HpChanged, BloodLimit);
                break;
            case StoryConditionData.CONDITION_TYPE.BEGINNING:
                EventDispatcher.RemoveEventListener(Events.StoryEvent.BattleBeginning, BattleBeginning);
                break;
            case StoryConditionData.CONDITION_TYPE.BATTLEWIN:
                EventDispatcher.RemoveEventListener(Events.StoryEvent.BattleWin, BattleWin);
                break;
            case StoryConditionData.CONDITION_TYPE.PLAYSKILL:
                EventDispatcher.RemoveEventListener<UInt32, IStoryCharacter>(Events.SkillEvent.SkillStart, PlaySkill);
                break;
            case StoryConditionData.CONDITION_TYPE.TRIGGERCONDITION:
                EventDispatcher.RemoveEventListener<string, string, object>(Events.StoryEvent.PlayStoryEnd, TriggerCondition);
                break;
            case StoryConditionData.CONDITION_TYPE.GOALCOMPLETE:
                EventDispatcher.RemoveEventListener<uint>(Events.GoalEvent.OnGoalComplete, GoalComplete);
                break;
        }
    }
    #endregion
}
