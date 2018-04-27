using UnityEngine;
using System.Collections.Generic;
using System;

/// <summary>
/// 空类型回调
/// </summary>
public delegate void VoidDelegate();

public delegate void V3Delegate(Vector3 v3);

public delegate void FunctionDelegate(StoryFunction fun);

public interface IStoryCharacter
{
    UInt64 ID { get; }
    /// <summary>
    /// 监听对象的transform
    /// </summary>
    Transform transform { get; }
    /// <summary>
    /// 可以完整控制监听对象的gameObject
    /// </summary>
    GameObject gameObject { get; }
    /// <summary>
    /// 人物头顶对话框
    /// </summary>
    GameObject GetDialogText();
    GameObject CreateDialogText();
    void MoveTo(Vector3 point,Action<object> moveEndCallback = null, object obj = null);
    void SetPosition(Vector3 point);
    void Play(string name, float speed = 1, Action action = null);
    void PlaySkill(int id, GameUnit target, float dir, int hitID, Action callback = null);
    bool PlaySound(int id);
    void LookAtPlayer();
    void SetYaw(float value);
}
/// <summary>
/// 游戏剧情管理器
/// 接口层处理与其他管理器的交互
/// zlj
/// </summary>
public class StoryManager : DataManagerBase<StoryManager>, IRelease
{
    private UIStoryController _uiController;
    public UIStoryController UIController
    {
        get
        {
            if (_uiController == null)
                _uiController = UIManager.Instance.GetController<UIStoryController, UIStoryWindow>(UIControllerDefine.WIN_Story);
            return _uiController;
        }
    }
    /// <summary>
    /// 剧情字典
    /// </summary>
    public Dictionary<string, StoryControl> stroyDict = new Dictionary<string, StoryControl>();
    /// <summary>
    /// 是否正在播放剧情
    /// </summary>
    public bool IsPlaying
    {
        get
        {
            foreach (var item in stroyDict)
            {
                if (item.Value.IsRunningStory())
                    return true;
            }
            return false;
        }
    }
    /// <summary>
    /// 进入剧情模式
    /// </summary>
    public bool IsInStoryModel { private set; get; }
    /// <summary>
    /// 游戏暂停次数
    /// </summary>
    private int gamePauseCount = 0;

    /// <summary>
    /// 开始视角范围
    /// </summary>
    private float startView = -1;

    public void Init()
    {
        if (UIController == null)
            UIManager.Instance.Show(UIControllerDefine.WIN_Story);
        startView = -1;
        EventDispatcher.AddEventListener<string, object>(Events.BattleEvent.LoadNewStory, LoadNewStoryFun);
        EventDispatcher.AddEventListener<string>(Events.BattleEvent.DestroySceneStory, DestroySceneStory);
    }
    public void Release()
    {
        Clear();
    }
    /// <summary>
    /// 销毁
    /// </summary>
    public void Clear()
    {
        startView = -1;
        foreach (StoryControl controlItem in stroyDict.Values)
        {
            if (controlItem != null)
                GameObject.Destroy(controlItem.gameObject);
        }
        stroyDict.Clear();

        EventDispatcher.RemoveEventListener<string, object>(Events.BattleEvent.LoadNewStory, LoadNewStoryFun);
        EventDispatcher.RemoveEventListener<string>(Events.BattleEvent.DestroySceneStory, DestroySceneStory);
        StoryCharacterFactory.ClearStoryCharacter();
    }
    private void LoadNewStoryFun(string stroyPrefab, object arg)
    {
        LoadStory(stroyPrefab, arg);
    }
    private void DestroySceneStory(string storyName)
    {
        if (stroyDict.ContainsKey(storyName))
        {
            if (stroyDict[storyName].IsRunningStory())
                UConsole.Log("剧情正在播放，延迟删除。");
            else
            {
                UConsole.Log("跳过剧情，卸载剧情数据，storyName：" + storyName);
                stroyDict[storyName].Stop();
            }
        }
    }
    /// <summary>
    /// 外部调用播放剧情接口
    /// </summary>
    /// <param name="arg"></param>
    public bool LoadStory(string storyPrefab, object arg = null)
    {
        if (string.IsNullOrEmpty(storyPrefab))
        {
            if (string.IsNullOrEmpty(storyPrefab))
                UConsole.LogError(" storyPrefab is null,storyPrefab:" + storyPrefab + ",arg:" + arg);
            return false;
        }

        if (stroyDict.ContainsKey(storyPrefab))
        {
            UConsole.Log("此场景已经加载过此剧情,storyPrefab:" + storyPrefab);
            //刷新旧的数据
            StoryControl sc = stroyDict[storyPrefab];
            if (sc != null)
                sc.RefreshData(arg);
            return false;
        }
        if (!LoadStoryRes(storyPrefab, arg))
        {
            UConsole.Log("加载剧情" + storyPrefab + "失败。");
            return false;
        }
        return true;
    }
    private bool LoadStoryRes(string storyPrefab, object arg = null)
    {
        try
        {
            string path = GetStoryResourcesPath(ResType.Prefab, storyPrefab);
            GameObject obj = LoadGameObject(path);

            if (obj == null)
            {
                UConsole.Log("没有加载到此剧情,storyPrefab:" + path);
                return false;
            }
            else
            {
                obj.name = storyPrefab;
                StoryControl control = obj.GetComponent<StoryControl>();
                stroyDict.Add(storyPrefab, control);
                control.InitData(arg);
                control.Play();
                UConsole.Log("加载剧情成功，storyPrefab：" + storyPrefab + ",path:" + path);
                return true;
            }
        }
        catch (System.Exception e)
        {
            UConsole.LogError("【剧情】" + e);
            return false;
        }
    }
    /// <summary>
    /// 某个条件播放结束 
    /// </summary>
    /// <param name="lastType"></param>
    public void SomeoneStoryEnd(StoryConditionData.CONDITION_TYPE lastType, string storyRootName, string storyConditionName, bool isAllEnd = false, object arg = null)
    {
        if (!IsPlaying)
        {
            ContinueAutoFighting();
            RemoveGamePause(true);

            if (UIController.IsNotNull())
                UIController.Hide();
        }

        UConsole.Log(string.Format("[Story]PlayStoryEnd : storyRootName = {0},storyConditionName = {1},object = {2}", storyRootName, storyConditionName, arg));
        EventDispatcher.TriggerEvent<string, string, object>(Events.StoryEvent.PlayStoryEnd, storyRootName, storyConditionName, arg);

        if (isAllEnd)
        {
            if (stroyDict.ContainsKey(storyRootName))
            {
                GameObject.Destroy(stroyDict[storyRootName].gameObject);
                stroyDict.Remove(storyRootName);
                UConsole.Log("剧情播放结束，删除剧情文件，storyName：" + storyRootName);
            }
            else
                UConsole.Log("剧情播放结束，删除剧情文件(已删除)，storyName：" + storyRootName);
        }
    }
    /// <summary>
    /// 取消自动战斗
    /// </summary>
    public void CancelAutoFighting()
    {

    }
    /// <summary>
    /// 继续自动战斗
    /// </summary>
    public void ContinueAutoFighting()
    {

    }

    public void AddGamePause()
    {
        gamePauseCount++;
        if (gamePauseCount == 1)
            GameStateChange(true);
    }
    public void RemoveGamePause(bool force = false)
    {
        if (force)
        {
            gamePauseCount = 0;
            GameStateChange(false);
        }
        else
        {
            gamePauseCount--;
            if (gamePauseCount < 0)
                gamePauseCount = 0;
            if (gamePauseCount == 0)
            {
                GameStateChange(false);
            }
        }
    }
    /// <summary>
    /// 游戏AI暂停和开启 
    /// </summary>
    /// <param name="isPause"></param>
    public void GameStateChange(bool isPause)
    {
        if (isPause)
        {
            SendAllCharacterIdle();
            UIManager.Instance.HideWindowsKeepThis(UIControllerDefine.WIN_Story);
        }
        else
        {
            SendAllCharacterFree();
            try { UIManager.Instance.RecoverWindows(); }
            catch (Exception e) { UConsole.LogError(e.ToString()); }
        }
    }
    public void ChangeCameraView(bool start, float view = -1, float duration = 0.5f)
    {
        Camera cam = GetMainCamera();
        if (cam == null)
        {
            UConsole.LogError("【剧情】没有找到该场景相机.");
            return;
        }
        if (start)
        {
            startView = cam.fieldOfView;
            SlowChangeCameraView(cam, view, duration);
        }
        else
        {
            if (startView > 0)
            {
                SlowChangeCameraView(cam, startView);
                startView = -1;
            }
        }
    }
    public void SlowChangeCameraView(Camera cam, float newView, float duration = 0.5f)
    {
        if (cam == null)
            return;

        TweenFOV tweenFOV = cam.GetComponent<TweenFOV>();
        if (tweenFOV == null)
            tweenFOV = cam.gameObject.AddComponent<TweenFOV>();

        tweenFOV.duration = duration;
        tweenFOV.from = cam.fieldOfView;
        tweenFOV.to = newView;
        tweenFOV.PlayForward();
    }
    /// <summary>
    /// 播放声音,3Dmusic id = pathFileResStructID ,  UI music id = musicStructID
    /// </summary>
    /// <param name="audioPath"></param>
    /// <returns></returns>
    public void PlaySound(int id, IStoryCharacter character = null)
    {
        if (id <= 0)
            return;

        if (character != null)
        {
            character.PlaySound(id);
        }
        else
        {
            MusicStruct music = ViSealedDB<MusicStruct>.Data(id);
            UISoundManager.Instance.PlayBGM(music, false);
        }
    }
    public void SetBackMusic(int musicStructID, float volume)
    {
        if (musicStructID == 0)
        {
            GameApplication.Instance.MusicManager.Del(GameKeyWord.Story);
            GameApplication.Instance.MusicManager.SetVolume(volume);
        }
        else
        {
            MusicStruct musicData = ViSealedDB<MusicStruct>.Data(musicStructID);
            if (musicData.IsNotNull())
            {
                GameApplication.Instance.MusicManager.Add(GameKeyWord.Story, 100, musicData);
                GameApplication.Instance.MusicManager.SetVolume(volume);
            }
        }
    }
    public T LoadAsset<T>(string path) where T : UnityEngine.Object
    {
        return Resources.Load<T>(path);
    }
    public GameObject LoadGameObject(string path)
    {
        return LoadAsset<GameObject>(path).Instantiate();
    }
    public RenderTexture CreateRenderTexture(int width = 512, int height = 512, int depth = 24)
    {
        RenderTexture tex = new RenderTexture(width, height, depth);
        tex.Create();
        return tex;
    }
    public void SetTime(ViTimeNode1 node, float time, ViTimeNode1.Callback dele)
    {
        ViTimerInstance.SetTime(node, (UInt32)(time * 100), dele);
    }
    /// <summary>
    /// 获取触发器trans
    /// </summary>
    public IStoryCharacter GetCharacter(StoryRoleData data)
    {
        if (data == null)
            return null;
        IStoryCharacter character = null;
        string log = "";

        switch (data.controlType)
        {
            case StoryRoleData.ROLETYPE.LEAD:
                {
                    if (data.isLocal)
                        character = StoryCharacterFactory.GetStoryCharacter();
                    else
                        character = CellHero.LocalHero;
                    log = string.Format("人物：{0}", data.controlType);
                }
                break;
            case StoryRoleData.ROLETYPE.ENEMY:
            case StoryRoleData.ROLETYPE.SceneNPC:
                {
                    if (data.isLocal)
                        character = StoryCharacterFactory.GetStoryCharacter(data.npcBirthPositionID, data.npcBirthPositionIndex);
                    else
                        character = HeroController.Instance.GetNPCByPos(data.npcBirthPositionID, data.npcBirthPositionIndex);
                    log = string.Format("{0}  人物：{1},出生点id：{2},,出生点index：{3}", "", data.controlType, data.npcBirthPositionID, data.npcBirthPositionIndex);
                }
                break;
        }
        if (character == null)
            UConsole.LogError("没有找到此角色," + log);
        return character;
    }
    /// <summary>
    /// 获取编辑器下剧情路径
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public static string GetEditorStoryPath(ResType type)
    {
        string str = "";
        switch (type)
        {
            case ResType.Texture:
                str = string.Format("{0}/Resources/StoryResource/{1}", Application.dataPath, "Texture");
                break;
            case ResType.Audio:
                str = string.Format("{0}/Resources/StoryResource/{1}", Application.dataPath, "Audio");
                break;
            case ResType.Movie:
                str = string.Format("{0}/Resources/{1}", Application.dataPath, "Videos");
                break;
            case ResType.Prefab:
                str = string.Format("{0}/Resources/StoryResource/Story", Application.dataPath);
                break;
            case ResType.Character:
                str = string.Format("{0}/Resources/StoryResource/Characters", Application.dataPath);
                break;
            case ResType.CameraPath:
                str = string.Format("{0}/Resources/StoryResource/CameraPath", Application.dataPath);
                break;
            case ResType.Text:
                break;
            default:
                break;
        }
        return str;
    }
    /// <summary>
    /// 获取剧情资源名称路径
    /// </summary>
    /// <param name="type"></param>
    /// <param name="resName"></param>
    /// <returns></returns>
    public static string GetStoryResourcesPath(ResType type, string resName)
    {
        string str = "";
        switch (type)
        {
            case ResType.Texture:
                str = string.Format("{0}/{1}", "Texture", resName);
                break;
            case ResType.Audio:
                str = string.Format("{0}/{1}", "Audio", resName);
                break;
            case ResType.Movie:
                str = string.Format("{0}/{1}", "Videos", resName);
                break;
            case ResType.Prefab:
                str = string.Format("Story/{0}", resName);
                break;
            case ResType.Character:
                str = string.Format("Characters/AModels/{0}", resName);
                break;
            case ResType.Text:
                break;
            case ResType.CameraPath:
                str = string.Format("CameraPath/{0}", resName);
                break;
            default:
                break;
        }
        return "StoryResource/" + str;
    }
    public Camera GetMainCamera()
    {
        return CameraController.Instance.Camera;
    }
    public Camera GetUICamera()
    {
        return UIManager.Instance.UICamera;
    }
    public Transform GetPlayer()
    {
        return CellHero.LocalHero.transform;
    }
    public string GetPlayerName()
    {
        return Player.Instance.Property.NameAlias;
    }
    public int GetPlayerID()
    {
        return CellHero.LocalHero.LogicInfo.ID;
    }
    public int GetPlayerGender()
    {
        return CellHero.LocalHero.LogicInfo.Gender;
    }
    public int GetPlayerProfessionID(StoryRoleData.ROLETYPE type)
    {
        return type == StoryRoleData.ROLETYPE.LEAD ? CellHero.LocalHero.LogicInfo.HeroClass : -1;
    }
    public void SetPlayerState(bool show)
    {
        CellHero.LocalHero.SetBodyVisiable(show);
    }
    public void SendAllCharacterIdle()
    {
        HeroController.Instance.StopMove();
    }
    public void SendAllCharacterFree()
    {

    }
    public void EnterStoryModel(string storyName)
    {
        IsInStoryModel = true;
        if (stroyDict.ContainsKey(storyName))
        {
            if (UIController == null)
                UIManager.Instance.Show(UIControllerDefine.WIN_Story);
            stroyDict[storyName].EnterStoryModel();
        }
    }
    public void ExitStoryModel(string storyName)
    {
        IsInStoryModel = false;
        if (stroyDict.ContainsKey(storyName))
        {
            stroyDict[storyName].ExitStoryModel();
        }
    }
    public void NoticeServerEnterStoryModel(int goalID)
    {
        if (goalID > 0)
        {
            PlayerServerInvoker.EnterStoryModel(Player.Instance,(uint)goalID);
        }
        else
        {
            UConsole.LogError("NoticeServerEnterStoryModel  goalID <=0");
        }
    }
}
/// <summary>
/// 资源类型
/// </summary>
public enum ResType
{
    Texture,
    Audio,
    Movie,
    Prefab,
    Text,
    Character,
    CameraPath,
}
/// <summary>
/// 主角职业类型
/// </summary>
[System.Serializable]
public enum LeaderProfession
{
    Cleric,
    Fighter,
    Ranger,
    Rogue,
    Wizard,
    Knight,

    Count,
}

public static class EnumTranslation
{
    public static string ToProfession(this LeaderProfession profession)
    {
        switch (profession)
        {
            case LeaderProfession.Cleric:
                return "牧师";
            case LeaderProfession.Fighter:
                return "战士";
            case LeaderProfession.Ranger:
                return "弓手";
            case LeaderProfession.Rogue:
                return "盗贼";
            case LeaderProfession.Wizard:
                return "法师";
            case LeaderProfession.Knight:
                return "骑士";
            default:
                break;
        }
        return profession.ToString();
    }
}