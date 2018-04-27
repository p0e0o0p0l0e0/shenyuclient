using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UIRoleCreateController : UIController<UIRoleCreateController, UIRoleCreateWindow>
{

    private string _randomName = "";

    protected override void Initial()
    {
        base.Initial();
        UIRoleDataManager.GetInstance.RegisterPlayerCreate(_OnPlayerCreate);
    }
    public override void Show()
    {
        base.Show();
        HeroController.Instance.AddTouchHandle("RoleCreate", 20, TouchHandle_RoleCreate.Instace);
        EventDispatcher.AddEventListener(Events.SpaceEvent.SpaceLoadStart, _OnEnterSpace);
    }

    public override void Hide()
    {  
        base.Hide();
        HeroController.Instance.RemoveTouchHandle("RoleCreate");       
        EventDispatcher.RemoveEventListener(Events.SpaceEvent.SpaceLoadStart, _OnEnterSpace);
    }
    public override void Destroy()
    {
        UIGoManager.Instance.UnLoad("UIRoleSkillShowWindow");
        UIRoleDataManager.GetInstance.UnRegisterPlayerCreate(_OnPlayerCreate);    
        base.Destroy();  
    }

    private void _OnEnterSpace()
    {
        UIManagerUtility.GotoSpace();
    }
    /// <summary>
    /// 返回按钮
    /// </summary>
    public void OnClickBack()
    {
        if (UIRoleDataManager.GetInstance.GetCreatTag()) //返回创建
        {
            UIManager.Instance.Hide(UIControllerDefine.WIN_CreateRole);
            UIManager.Instance.Show(UIControllerDefine.WIN_Role);
        }
        else //返回login
        {
            UIManager.Instance.Show(UIControllerDefine.WIN_Login);
            UIManager.Instance.Hide(UIControllerDefine.WIN_CreateRole);
           // AccountScene.Instance.Clear();
            GameApplication.Instance.Client.CloseConnect();
            ClearDataManager.ClearAllData();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    public void OnClickEnter(string name)
    {
        if (!UIRoleDataManager.GetInstance.GetCreatTag())//选择角色进入
        {
            AccountServerInvoker.SelectRole(Account.Instance, (ushort)_mWinHandler.lastClickHero);
        }
        else
        {
            if (UIRoleDataManager.GetInstance.IsNameIllegal(name)) //创建角色进入
            {
                Account.Instance.CreateRole(name, (byte)(UIRoleDataManager.GetInstance.GetVisId()), UIRoleDataManager.GetInstance.CurSelectGender, (byte)_mWinHandler.lastFair, (byte)_mWinHandler.lastFace);
            }
        }

    }
    /// <summary>
    /// 人物创建后的回调
    /// </summary>
    private void _OnPlayerCreate()
    {
        if (this.IsShow)
        {
            this._mWinHandler.UpdateRoleInfo();
            int index = Account.Instance.Property.PlayerList.Count - 1;
            AccountServerInvoker.SelectRole(Account.Instance, (ushort)index);
            _enterSpace();
        }
    }

    /// <summary>
    /// 场景切换
    /// </summary>
    /// <param name="index"></param>
    private void _enterSpace(int index = 1)
    {
        List<SpaceStruct> _spaceList = new List<SpaceStruct>();
        List<SpaceStruct> infoList = ViSealedDB<SpaceStruct>.Array;
        for (int iter = 0; iter < infoList.Count; ++iter)
        {
            SpaceStruct iterInfo = infoList[iter];
            if (iterInfo.ID == 0)
            {
                continue;
            }
            if (iterInfo.Enter.Mask.HasAny((Int32)SpaceEnterMask.STORY))
            {
                continue;
            }
            _spaceList.Add(iterInfo);
        }
        //UInt32 spaceId = Player.Instance.Property.LastBigSpace > 0 ? Player.Instance.Property.LastBigSpace : (UInt32)_spaceList[0].ID;
        //UIManagerUtility.ShowLoading();
        //PlayerServerInvoker.GotoBigSpace(Player.Instance, spaceId);

    }
    public void OnRoleCreate(byte result)
    {
        ViDebuger.Record("-->UIRoleCreateController.OnRoleCreate. ret=" + result);
        if (result == 0)
        {
        }
        else
        {
            UIManagerUtility.ShowHint("Create role failed:ret =" + result);
        }
    }
    public void OnClickRandomName()
    {
        AccountServerInvoker.RandomName(Account.Instance, UIRoleDataManager.GetInstance.CurSelectGender);
    }
    public void OnRandName(string name)
    {
        _randomName = name;
        this._mWinHandler.SetRandomName(_randomName);
    }
}
