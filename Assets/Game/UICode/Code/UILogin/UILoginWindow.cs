using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Text;

public class UILoginWindow : UIWindow<UILoginWindow, UILoginController>
{
    #region ui control name define
    private const string LoginBtn = "UILoginWindow/BackGroup/LoginBtn";
    private const string InfoGroup = "UILoginWindow/InfoGroup";
    private const string InfoOkBtn = "UILoginWindow/InfoGroup/OkBtn";
    private const string UserName = "UILoginWindow/InfoGroup/UserName";
    private const string UserPass = "UILoginWindow/InfoGroup/Password";
    private const string InfoBtn = "UILoginWindow/InfoBtn";
    private const string SettingBtn = "UILoginWindow/InfoBtn/Setting";
    private const string AnnouncementBtn = "UILoginWindow/InfoBtn/Announcement";
    private const string LogOutBtn = "UILoginWindow/InfoBtn/LogOut";
    private const string BarrageBtn = "UILoginWindow/InfoBtn/Barrage";
    private const string BackTex = "UILoginWindow/BackGroup/BackGround";

    private const string ChangeServerBtn = "UILoginWindow/ServerInfo/ChangeServer";      // 点击换服   
    private const string CloseBtn = "UILoginWindow/ServerGroup/CloseBtn";                // 关闭按钮


    private const string ServerGroup = "UILoginWindow/ServerGroup";                      // 服务器列表
    private const string ServerShowName = "UILoginWindow/ServerInfo/ServerName";         // 当前选择名字 
    private const string LeftTag = "UILoginWindow/ServerGroup/LeftTag";
    private const string LeftTagView = "UILoginWindow/ServerGroup/LeftTag/Viewport";
    private const string SeverList = "UILoginWindow/ServerGroup/ServerList";
    private const string LeftTagText = "/Text";
    private const string LeftTagShow = "/Show";
    private const string Herolist = "UILoginWindow/ServerGroup/HeroList";

    #endregion
    public static string USERNAME_KEY = "USERNAME_KEY";
    public static string PASSWORD_KEY = "PASSWORD_KEY";
    public static string LOGIN_SERVER = "LOGIN_SERVER";

    public static string SeverListSeverPath = "";
    public static string SeverListName = "SeverList.json";
    public static string SeverListLocalPath =
#if UNITY_ANDROID
        "jar:file://" + Application.dataPath + "!/assets/";
    
#elif UNITY_IPHONE
        Application.dataPath + "/Raw/";  
#else
    "";
#endif
    private Transform _infoGroupTran = null;
    private InputField _userNameText = null;
    private InputField _passText = null;

    Transform _LoginBtnTrans = null;
    Transform _ServerGroup = null;
    Transform _InfoBtnTrans = null;
    ExText _SelectServerName = null;
    ExUITexture _backTex = null;
    private int currentShow = -1;
    bool isFirstRush = true;
    protected override void Initial()
    {
        base.Initial();
        Button loginBtn = this.GetComponent<Button>(LoginBtn);
        loginBtn.onClick.AddListener(_OnLoginClick);
        _infoGroupTran = this.FindTransform(InfoGroup);
        Button infoOkBtn = this.GetComponent<Button>(InfoOkBtn);
        infoOkBtn.onClick.AddListener(_OnInfoGroupOKClick);
        _userNameText = this.GetComponent<InputField>(UserName);
        _passText = this.GetComponent<InputField>(UserPass);
        Button setBtn = this.GetComponent<Button>(SettingBtn);
        setBtn.onClick.AddListener(_OnClickSetting);
        Button annBtn = this.GetComponent<Button>(AnnouncementBtn);
        annBtn.onClick.AddListener(_OnClickAnnouncement);
        Button logOutBtn = this.GetComponent<Button>(LogOutBtn);
        logOutBtn.onClick.AddListener(_OnClickLogOut);
        Button barr = this.GetComponent<Button>(BarrageBtn);
        barr.onClick.AddListener(_OnClickBarrage);
        _backTex = this.GetComponent<ExUITexture>(BackTex);
        GetSeverList();
        LoopVerticalScrollRect leftTag = this.GetComponent<LoopVerticalScrollRect>(LeftTag);
        leftTag.Init(_LoopLeftTag, _mController.severList.SeverDataArrer.Length + 1);
        leftTag.RefillCells();
        ExUIButton btn;
        for (int i = 0; i < 8; i++)
        {
            btn = this.GetComponent<ExUIButton>(LeftTagView + "/" + i);
            btn.onClickEx = _ClickLeftTag;
        }
        for (int i = 0; i < 16; i++)
        {
            btn = this.GetComponent<ExUIButton>(SeverList + "/Content/Server" + i);
            btn.onClickEx = _OnClickSeverCell;
        }
        _InfoBtnTrans = FindTransform(InfoBtn);
        _LoginBtnTrans = FindTransform(LoginBtn);
        _ServerGroup = FindTransform(ServerGroup);
        Button pSelServer = GetComponent<Button>(ChangeServerBtn);
        pSelServer.onClick.AddListener(_OnEventClickChangeServer);
        Button pBtn = GetComponent<Button>(CloseBtn);
        pBtn.onClick.AddListener(_OnEventCloseServerGroup);
        _SelectServerName = GetComponent<ExText>(ServerShowName);

        InitServerInfo();
    }

    void InitServerInfo()
    {
        SetServerGroupVisible(false);
        SetSelectServerName(true);

    }
    private void _OnLoginClick()
    {
        this._mController.OnClickLogin();
    }
    public void SetInfoGroupVisible(bool isVisible)
    {
        if (_infoGroupTran != null)
            _infoGroupTran.gameObject.SetActive(isVisible);
    }
    public void SetLocalNamePassword(string name, string password)
    {
        _userNameText.text = name;
        _passText.text = password;
    }

    private void _OnClickSetting()
    {

    }

    private void _OnClickAnnouncement()
    {

    }
    private void _OnClickLogOut()
    {
        SetInfoGroupVisible(true);
    }
    private void _OnClickBarrage()
    {

    }

    private void _OnInfoGroupOKClick()
    {
        if (!string.IsNullOrEmpty(_userNameText.text) && !string.IsNullOrEmpty(_passText.text))
        {
            GameLocalData.Save(USERNAME_KEY, _userNameText.text);
            GameLocalData.Save(PASSWORD_KEY, _passText.text);
            this._mController.OnInfoOKClick();
            SetInfoGroupVisible(false);
        }
        else
        {

        }
    }

    void SetServerGroupVisible(bool bSetting)
    {
        if (_ServerGroup != null)
        {
            _ServerGroup.gameObject.SetActive(bSetting);
        }
        if (_InfoBtnTrans != null)
        {
            _InfoBtnTrans.gameObject.SetActive(!bSetting);
        }
        if (_LoginBtnTrans != null)
        {
            _LoginBtnTrans.gameObject.SetActive(!bSetting);
        }
    }




    #region 服务器选择面板
    private void _OnEventClickChangeServer()
    {
        SetServerGroupVisible(true);
        _ClickLeftTag(0, GetComponent<ExUIButton>(LeftTagView + "/0"));
    }

    private void _OnEventCloseServerGroup()
    {
        SetServerGroupVisible(false);
        HildLastClick();
        currentShow = -1;
    }
    private void _LoopLeftTag(string path, int id)
    {
        ExText tex = this.GetComponent<ExText>(LeftTagView + "/" + path + LeftTagText);
        ExText tex1 = this.GetComponent<ExText>(LeftTagView + "/" + path + LeftTagShow + LeftTagText);
        GameObject obj = this.GetComponent<ExUISprite>(LeftTagView + "/" + path + LeftTagShow).gameObject;
        if (id == 0)
        {
            tex.text = tex1.text = _mController.severList.SeverDataArrer[0].Tags;
        }
        else if (id == 1)
        {
            tex.text = tex1.text = I18NManager.Instance.GetWord("tips_145");
        }
        else
        {
            tex.text = tex1.text = _mController.severList.SeverDataArrer[id - 1].Tags;
        }
        obj.SetActive(currentShow == id ? true : false);
    }

    private void _ClickLeftTag(int id, object ob)
    {
        ExUIButton obj = ob as ExUIButton;
        LoopVerticalScrollRect leftTag = this.GetComponent<LoopVerticalScrollRect>(LeftTag);

        int index = leftTag.GetIndexByTransform(obj.transform);
        if (currentShow != index)
        {
            FindTransform(LeftTagView + "/" + obj.name + "/Show").gameObject.SetActive(true);
            HildLastClick();
            currentShow = index;
            if (index == 1)
            {
                SetSeverShow(false);
            }
            else
            {
                SetSeverShow(true);
                LoopVerticalScrollRect sever = this.GetComponent<LoopVerticalScrollRect>(SeverList);
                if (isFirstRush)
                {
                    sever.Init(_LoopSever, _mController.severList.SeverDataArrer[0].SeverList.Length);
                    isFirstRush = false;
                }
                else
                {
                    if (index == 0)
                        sever.ChangeTotalCount(_mController.severList.SeverDataArrer[0].SeverList.Length);
                    else
                        sever.ChangeTotalCount(_mController.severList.SeverDataArrer[index - 1].SeverList.Length);            
                }
                sever.RefillAllCells();
            }
        }
    }

    private void HildLastClick()
    {
        LoopVerticalScrollRect leftTag = this.GetComponent<LoopVerticalScrollRect>(LeftTag);
        if (currentShow != -1)
        {
            string trns = leftTag.GetNodeNameByIndex(currentShow);
            if (!string.IsNullOrEmpty(trns))
                FindTransform(LeftTagView + "/" + trns + "/Show").gameObject.SetActive(false);
        }
    }
    private void SetSeverShow(bool isShow)
    {
        Transform severTrs = FindTransform(SeverList);
        Transform heroTrs = FindTransform(Herolist);
        severTrs.gameObject.SetActive(isShow);
        heroTrs.gameObject.SetActive(!isShow);
    }
    private void _LoopSever(string path, int id)
    {
        ExText name = this.GetComponent<ExText>(path + "/Text");
        ExUISprite spr = this.GetComponent<ExUISprite>(path + "/State");
        Transform newStage = FindTransform(path + "/New");
        SeverListType.SeverData severData;
        if (currentShow == 0)
            severData = _mController.severList.SeverDataArrer[0];
        else
            severData = _mController.severList.SeverDataArrer[currentShow - 1];
        name.text = severData.SeverList[id].Name;
        spr.SpriteName = ShowSeverStage(severData.SeverList[id].Stage);
    }

    private string ShowSeverStage(int id)
    {
        if (id == 0)
            return "icon_point";
        else if (id == 1)
            return "icon_point2";
        else if (id == 2)
            return "icon_point3";
        else
            return "icon_point4";
    }

    private void _OnClickSeverCell(int id, object obj)
    {
        ExUIButton btn = obj as ExUIButton;
        LoopVerticalScrollRect sever = this.GetComponent<LoopVerticalScrollRect>(SeverList);
        int index = sever.GetIndexByTransform(btn.transform);
        SeverListType.SeverDetail detail;
        if (currentShow == 0)
            detail = _mController.severList.SeverDataArrer[currentShow].SeverList[index];
        else if (currentShow > 1)
            detail = _mController.severList.SeverDataArrer[currentShow - 1].SeverList[index];
        else
            detail = new SeverListType.SeverDetail();
        _mController.SetSelectServer(detail.Name, detail.IP, detail.Point);
        SetSelectServerName(false);
        _OnEventCloseServerGroup();
    }
    #endregion

    /// <summary>
    /// 
    /// </summary>
    /// <param name="isLoop"></param>是否遍历查找是否在列表中
    void SetSelectServerName(bool isLoop)
    {
        string sServerName = GameLocalData.Load(UILoginWindow.LOGIN_SERVER);
        if (_SelectServerName != null)
        {
            if (sServerName != null)
            {
                if (isLoop)
                {
                    bool canFind = false;
                    for (int i = 0; i < _mController.severList.SeverDataArrer.Length; i++)
                    {
                        for (int j = 0; j < _mController.severList.SeverDataArrer[i].SeverList.Length; j++)
                        {
                            if (_mController.severList.SeverDataArrer[i].SeverList[j].Name == sServerName)
                            {
                                _mController.SetSelectServer(sServerName, _mController.severList.SeverDataArrer[i].SeverList[j].IP, _mController.severList.SeverDataArrer[i].SeverList[j].Point);
                                canFind = true;
                                break;
                            }
                        }
                        if (canFind)
                            break;
                    }
                    if (!canFind)
                    {
                        SeverListType.SeverDetail detail = _mController.severList.SeverDataArrer[0].SeverList[0];
                        sServerName = detail.Name;
                        _mController.SetSelectServer(detail.Name, detail.IP, detail.Point);
                    }
                }
                _SelectServerName.text = sServerName;
            }
            else
            {
                SeverListType.SeverDetail tex = _mController.severList.SeverDataArrer[0].SeverList[0];
                _SelectServerName.text = tex.Name;
                _mController.SetSelectServer(tex.Name, tex.IP, tex.Point);
            }
        }
    }

    /// <summary>
    /// 获取json数据
    /// </summary>
    private void GetSeverList()
    {
        _mController.severList = JsonUtility.FromJson<SeverListType>(GameDataManager.mTempServerList);
        //        string path;
        //#if UNITY_EDITOR
        //        path = "file:" + Application.dataPath + "/StreamingAssets/config/configstream";
        //        AssetBundleWWW wwwLoad = AssetBundleWWW.Load(path, 1, false);
        //        GameObject obj = wwwLoad.assetBundle.LoadAsset("assets/vibprefab/severlist.prefab") as GameObject;
        //        wwwLoad.download.assetBundle.Unload(false);
        //        byte[] data = obj.GetComponent<BlobStream>().GetData();
        //        string jsonText = Encoding.Default.GetString(data);
        //        _mController.severList = JsonUtility.FromJson<SeverListType>(jsonText);
        //#elif UNITY_IOS
        //         path = Application.streamingAssetsPath + "/config/configstream";
        //         AssetBundleWWW wwwLoad = AssetBundleWWW.Load(path, 1, false);
        //        GameObject obj = wwwLoad.assetBundle.LoadAsset("assets/vibprefab/severlist.prefab") as GameObject;
        //        if (obj == null)
        //        {
        //            Debug.Log("加载服务器列表失败");
        //            return;
        //        }
        //        byte[] data = obj.GetComponent<BlobStream>().GetData();
        //        string jsonText = Encoding.Default.GetString(data);
        //        _mController.severList = JsonUtility.FromJson<SeverListType>(jsonText);
        //#elif UNITY_ANDROID
        //        // path ="jar:file://"+ Application.dataPath + "!/assets/config/configstream";  
        //        // AssetBundleWWW wwwLoad = AssetBundleWWW.Load(path, 1, false);
        //        //GameObject obj = wwwLoad.assetBundle.LoadAsset("assets/vibprefab/severlist.prefab") as GameObject;
        //        //byte[] data = obj.GetComponent<BlobStream>().GetData();
        //        //string jsonText = Encoding.Default.GetString(data);
        //        //_mController.severList = JsonUtility.FromJson<SeverListType>(jsonText);
        //#endif


        //string path = SeverListLocalPath +SeverListName;
        // if (File.Exists(path))
        //{
        //    string jsonText = File.ReadAllText(path, Encoding.UTF8);
        //    _mController.severList = JsonUtility.FromJson<SeverListType>(jsonText);
        //}
    }
    public override void Show()
    {
        base.Show();
        UIUtility.MakeFullScreen(this.GetPanelSize(), _backTex, true);
    }
}
