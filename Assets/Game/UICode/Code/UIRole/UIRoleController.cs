using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRoleController : UIController<UIRoleController, UIRoleWindow>
{

    protected override void Initial()
    {
        base.Initial();
    }
    public override void Show()
    {
        base.Show();
        HeroController.Instance.AddTouchHandle("Role", 20, TouchHandle_RoleCreate.Instace);//旋转估计不需要
    }

    public override void Hide()
    {
        HeroController.Instance.RemoveTouchHandle("Role");
        base.Hide();
    }
    public override void Destroy()
    {
        base.Destroy();

        HeroController.Instance.RemoveTouchHandle("Role");
        //UIRoleDataManager.GetInstance.SetCreatTag(false);
        //UIRoleDataManager.GetInstance.ClearSelect();
        UIGoManager.Instance.UnLoad("UIRoleSkillShowWindow");
    }
    /// <summary>
    /// 返回
    /// </summary>
    public void OnClickBack()
    {
        AccountReceiveProperty property = Account.Instance.Property;
        if (property.PlayerList.Count > 0)
        {
            UIRoleDataManager.GetInstance.SetCreatTag(false);
            UIRoleDataManager.GetInstance.ClearSelect();
            UIManager.Instance.Hide(UIControllerDefine.WIN_Role, (() => { UIManager.Instance.Show(UIControllerDefine.WIN_CreateRole); }));
        }
        else
        {
            UIManager.Instance.Show(UIControllerDefine.WIN_Login);
            UIManager.Instance.Hide(UIControllerDefine.WIN_Role);
            GameApplication.Instance.Client.CloseConnect();
            ClearDataManager.ClearAllData();
        }    
    }


    /// <summary>
    /// 创建下一步
    /// </summary>
    public void OnClickNext()
    {      
        if(UIRoleDataManager.GetInstance.CurSelectGender != (byte)UIRoleDataManager.Gender.Null)
        {
            UIRoleDataManager.GetInstance.SetCreatTag(true);
            UIManager.Instance.Hide(UIControllerDefine.WIN_Role, (() => { UIManager.Instance.Show(UIControllerDefine.WIN_CreateRole); }));
        }
        else
        {
            UIManagerUtility.ShowHint(I18NManager.Instance.GetWord("tips_147"));
        }
    }  
}

