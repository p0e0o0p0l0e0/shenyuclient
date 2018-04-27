using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UILoginController : UIController<UILoginController, UILoginWindow>
{
    private string _userName = null;
    private string _passWord = null;
    private string _curSelServer = null;
    private string IP = null;
    private ushort Point = 0;
    public SeverListType severList = null;
    protected override void Initial()
    {
        base.Initial();
        GetUserInfo();
    }
    public override void Show()
    {
        base.Show();
        if (!string.IsNullOrEmpty(_userName) && !string.IsNullOrEmpty(_passWord))
        {
            this._mWinHandler.SetInfoGroupVisible(false);
            this._mWinHandler.SetLocalNamePassword(_userName, _passWord);
        }
        else
            this._mWinHandler.SetInfoGroupVisible(true);
    }

    public void SetSelectServer(string sServerName, string ip, ushort point)
    {
        _curSelServer = sServerName;
        IP = ip;
        Point = point;
        GameLocalData.Save(UILoginWindow.LOGIN_SERVER, sServerName);
    }

    /// <summary>
    /// 获得用户名，密码和上次使用的服务器信息那些
    /// </summary>
    private void GetUserInfo()
    {
        _userName = GameLocalData.Load(UILoginWindow.USERNAME_KEY);
        _passWord = GameLocalData.Load(UILoginWindow.PASSWORD_KEY);
        _curSelServer = GameLocalData.Load(UILoginWindow.LOGIN_SERVER);
    }
    public void OnClickLogin()
    {
        UIManagerUtility.ShowHint("正在登陆中!");
        EventDispatcher.TriggerEvent<bool>(Events.SceneCommonEvent.WaitConnectUI, true);
        GetUserInfo();
        if (!string.IsNullOrEmpty(_userName) && !string.IsNullOrEmpty(_passWord))
        {
            string loginTimeStr = PublishSDKAssisstant.GetTime1970().ToString();
            string loginSignStr = PublishSDKAssisstant.MD5Encrypt(_userName + loginTimeStr + "");
            if (IP != null)
            {
                GameApplication.Instance.Client.Login(IP, Point, _userName, loginTimeStr, loginSignStr);
            }
           
        }
    }

    public void OnInfoOKClick()
    {
        //PlayerServerInvoker.GotoBigSpace(Player.Instance, (UInt32)_spaceList[spaceIndex].ID);
    }
}

[System.Serializable]
public class SeverListType
{
    public SeverData[] SeverDataArrer;

    [System.Serializable]
    public struct SeverData
    {
        public string Tags;
        public SeverDetail[] SeverList;

    }
    [System.Serializable]
    public struct SeverDetail
    {
        public string Name;
        public ushort Stage;
        public string IP;
        public ushort Point;
    }
}
