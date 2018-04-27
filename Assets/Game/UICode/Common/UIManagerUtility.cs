using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManagerUtility
{
    public static void ShowLoading()
    {
        UICommonController controller = UIManager.Instance.GetController<UICommonController, UICommonWindow>(UIControllerDefine.WIN_Common);
        if (controller.GetWindowType() != UICommonController.WinType.LOADING)
        {
            controller.SetWindowType(UICommonController.WinType.LOADING);
            controller.SetProgress(0f);
        }

    }
    public static void HideLoading(bool isDelay = false)
    {
        UICommonController controller = UIManager.Instance.GetController<UICommonController, UICommonWindow>(UIControllerDefine.WIN_Common);
        UICommonController preController = UIManager.Instance.GetController<UICommonController, UICommonWindow>(UIControllerDefine.WIN_PreloadCommon);
        if (controller != null && controller.IsShow)
            controller.SetWindowType(UICommonController.WinType.NONE, isDelay);
        else if (preController != null && preController.IsShow)
            preController.SetWindowType(UICommonController.WinType.NONE, isDelay);
    }
    public static void UpdateLoadingProgress(float val)
    {
        UICommonController controller = UIManager.Instance.GetController<UICommonController, UICommonWindow>(UIControllerDefine.WIN_Common);
        if (controller != null)
            controller.SetProgress(val);
    }
    public static UIRoleCreateController GetRoleCreateController()
    {
        return UIManager.Instance.GetController<UIRoleCreateController, UIRoleCreateWindow>(UIControllerDefine.WIN_CreateRole);
    }
    public static void ShowHint(string msg)
    {
        UICommonController controller = UIManager.Instance.GetController<UICommonController, UICommonWindow>(UIControllerDefine.WIN_Common);
        controller.SetWindowType(UICommonController.WinType.HINT);
        controller.ShowHint(msg);
    }
    public static void ShowConfirm(string content, UICallback.VIO_CB yesAction, UICallback.VIO_CB noAction = null, string yesStr = null, string noStr = null, string title = null)
    {
        UICommonController controller = UIManager.Instance.GetController<UICommonController, UICommonWindow>(UIControllerDefine.WIN_Common);
        controller.SetWindowType(UICommonController.WinType.CONFIRM);
        if (noAction == null && yesAction != null)
        {
            controller.ShowConfirm(content, yesAction, noAction, yesStr, noStr, title, ConfirmType.Yes);
        }
        else if (noAction != null && yesAction != null)
        {
            controller.ShowConfirm(content, yesAction, noAction, yesStr, noStr, title, ConfirmType.YesAndNo);
        }
        else if (noAction != null && yesAction == null)
        {
            controller.ShowConfirm(content, yesAction, noAction, yesStr, noStr, title, ConfirmType.No);
        }
    }

    public static void ShowPlayerInfo(UIPlayerInfoController.WinType type = UIPlayerInfoController.WinType.Prop)
    {
        var controller = UIManager.Instance.GetController<UIPlayerInfoController, UIPlayerInfoWindow>(UIControllerDefine.WIN_PlayerInfo);
        if (controller == null)
        {
            controller = UIManager.Instance.Show(UIControllerDefine.WIN_PlayerInfo) as UIPlayerInfoController;
            controller.curType = type;
        }
        else
        {
            controller.curType = type;
            UIManager.Instance.Show(UIControllerDefine.WIN_PlayerInfo);
        }
    }

    public static void RefreshTalent()
    {
        var controller = UIManager.Instance.GetController<UIPlayerInfoController, UIPlayerInfoWindow>(UIControllerDefine.WIN_PlayerInfo);
        if (controller.Null())
            return;
        if (controller.IsShow)
            controller.RefreshTalent();
    }

    public static void ShowTips(bool isEquip, int id, ushort pos, bool inBag)
    {
        var controller = UIManager.Instance.GetController<UITipsController, UITipsWindow>(UIControllerDefine.WIN_Tips);
        if (controller.Null())
        {
            controller = UIManager.Instance.Show(UIControllerDefine.WIN_Tips) as UITipsController;
            controller.SetId(isEquip, id, pos, inBag);
        }
        else
        {
            controller.SetId(isEquip, id, pos, inBag);
            UIManager.Instance.Show(UIControllerDefine.WIN_Tips);
        }
    }

    public static UIFightController GetFightController()
    {
        UIFightController controller = UIManager.Instance.GetController<UIFightController, UIFightWindow>(UIControllerDefine.WIN_FightWindow);
        return controller;
    }

    public static void GotoSpace()
    {
        UIManager.Instance.Hide(UIControllerDefine.WIN_CreateRole);
        UIManager.Instance.Hide(UIControllerDefine.WIN_Role);
        //PlayerServerInvoker.GotoBigSpace(Player.Instance, id);
        AccountScene.Instance.Clear();
        UIManager.Instance.OnChageSpace();
    }
    public static void OnEnterSpace()
    {
        HideLoading(true);
        ShowMiniMap();
        UIMiniMapController controller = GetMiniMapController();
        if (controller != null && controller.IsShow)
        {
            controller.OnChangeSpace();
        }
        ShowGoal();
        ShowChat();
    }
    public static void OnLeaveSpace()
    {
        UITextureManager.Instance.Destroy();
        UIManager.Instance.OnChageSpace();
    }
    public static void ShowMiniMap()
    {
        UIManager.Instance.Show(UIControllerDefine.WIN_MiniMap);
    }
    public static UIMiniMapController GetMiniMapController()
    {
        UIMiniMapController controller = UIManager.Instance.GetController<UIMiniMapController, UIMiniMapWindow>(UIControllerDefine.WIN_MiniMap);
        return controller;
    }
    public static void ShowGoal()
    {
        UIManager.Instance.Show(UIControllerDefine.WIN_Goal);
    }

    public static void ShowChat()
    {
        UIManager.Instance.Show(UIControllerDefine.WIN_ChatSys);
    }

    public static void ShowTeamList()
    {
        UIManager.Instance.Show(UIControllerDefine.WIN_TeamList);
    }
    public static void ShowTeamInvite(bool Show, List<PartyInfoStruct> inviteList, UICallback.VO_CB leftCallback, UICallback.VO_CB rightCallback)
    {
        UITeamInviteController uc = UIManager.Instance.GetController<UITeamInviteController, UITeamInviteWindow>(UIControllerDefine.WIN_TeamInvite);
        if(uc == null || !uc.IsShow)
            UIManager.Instance.Show(UIControllerDefine.WIN_TeamInvite,()=> {
                uc = UIManager.Instance.GetController<UITeamInviteController, UITeamInviteWindow>(UIControllerDefine.WIN_TeamInvite);
                uc.ShowInviteTipButton(Show, inviteList, leftCallback, rightCallback);
            });
        else
            uc.ShowInviteTipButton(Show, inviteList, leftCallback, rightCallback);
    }
    public static void ShowTeamInviteFriend()
    {
        UIManager.Instance.Show(UIControllerDefine.WIN_TeamInviteFriend);
    }
    public static void ShowTeamInviteTip(TeamInviteTipType inviteType, UICallback.VO_CB leftCallback, UICallback.VO_CB rightCallback, PartyInfoStruct p)
    {
        UITeamInviteTipController uc = UIManager.Instance.GetController<UITeamInviteTipController, UITeamInviteTipWindow>(UIControllerDefine.WIN_TeamInviteTip);
        if (uc == null || !uc.IsShow)
        {
            UIManager.Instance.Show(UIControllerDefine.WIN_TeamInviteTip, () =>
            {
                uc = UIManager.Instance.GetController<UITeamInviteTipController, UITeamInviteTipWindow>(UIControllerDefine.WIN_TeamInviteTip);
                uc.InitInviteJoinTeam(leftCallback, rightCallback, p);
            });
        }
        else
        {
            uc.InitInviteJoinTeam(leftCallback, rightCallback, p);
        }

    }

    public static void ShowPleaseLeaveTip( UICallback.VO_CB leftCallback, UICallback.VO_CB rightCallback, PartyInfoStruct p)
    {
        UITeamInviteTipController uc = UIManager.Instance.GetController<UITeamInviteTipController, UITeamInviteTipWindow>(UIControllerDefine.WIN_TeamInviteTip);
        if (uc == null || !uc.IsShow)
        {
            UIManager.Instance.Show(UIControllerDefine.WIN_TeamInviteTip, () =>
            {
                uc = UIManager.Instance.GetController<UITeamInviteTipController, UITeamInviteTipWindow>(UIControllerDefine.WIN_TeamInviteTip);
                uc.InitPleaseLeave(leftCallback, rightCallback, p);
            });
        }
        else
        {
            uc.InitPleaseLeave(leftCallback, rightCallback, p);
        }

    }

    public static void UpdateEnemyHp(UInt64 unitId, float hp, bool isHostile)
    {
        //UIDirectController controller = UIManager.Instance.GetController<UIDirectController, UIDirectWindow>(UIControllerDefine.WIN_Direct);
        //if (controller != null && controller.IsShow)
        //{
        //    controller.UpdateEnemyHp(unitId, hp, isHostile);
        //}
        UpdateFocusHp(unitId, hp);

    }
    public static void UpdateLocalPlayerHp(float hp)
    {
        //UIDirectController controller = UIManager.Instance.GetController<UIDirectController, UIDirectWindow>(UIControllerDefine.WIN_Direct);
        //if (controller != null && controller.IsShow)
        //{
        //    controller.UpdateLocalPlayerHp(hp);
        //}
        UIFightController fightController = GetFightController();
        if (fightController != null && fightController.IsShow)
        {
            fightController.UpdateLocalPlayerHp(hp);
        }
        UpdateFocusHp(CellHero.LocalHeroID, hp);
    }

    public static void UpdatePlayerHp(float curHp,float maxHp,float rate)
    {
        var controller = UIManager.Instance.GetController<UIPlayerInfoController, UIPlayerInfoWindow>(UIControllerDefine.WIN_PlayerInfo);
        if (controller != null && controller.IsShow)
        {
            controller.UpdateHp(curHp, maxHp, rate);
        }
    }
    public static void UpdateLocalPlayerBoom(float val)
    {
        //UIDirectController controller = UIManager.Instance.GetController<UIDirectController, UIDirectWindow>(UIControllerDefine.WIN_Direct);
        //if (controller != null && controller.IsShow)
        //{
        //    controller.UpdateLocalPlayerBoom(val);
        //}
        UIFightController fightController = GetFightController();
        if (fightController != null && fightController.IsShow)
        {
            fightController.UpdateLocalPlayerBoom(val);
        }
    }
    public static void UpdateBossHp(ulong unitId, float hp)
    {
        //UIDirectController controller = UIManager.Instance.GetController<UIDirectController, UIDirectWindow>(UIControllerDefine.WIN_Direct);
        //if (controller != null && controller.IsShow)
        //{
        //    controller.UpdateBossHp(unitId, hp);
        //}
        UpdateFocusHp(unitId, hp);
    }
    public static void KillHp(ulong unitId)
    {
        //UIDirectController controller = UIManager.Instance.GetController<UIDirectController, UIDirectWindow>(UIControllerDefine.WIN_Direct);
        //if (controller != null && controller.IsShow)
        //{
        //    controller.KillHp(unitId);
        //}
        //KillFocus(unitId);
    }
    public static void KillLocalPlayerHp()
    {
        //UIDirectController controller = UIManager.Instance.GetController<UIDirectController, UIDirectWindow>(UIControllerDefine.WIN_Direct);
        //if (controller != null && controller.IsShow)
        //{
        //    controller.KillLocalPlayerHp();
        //}
        UIFightController fightController = GetFightController();
        if (fightController != null && fightController.IsShow)
        {
            fightController.UpdateLocalPlayerHp(0);
        }
    }
    public static void ShowFightUIs()
    {
        UIManager.Instance.Show(UIControllerDefine.WIN_FightWindow);
        //UIManager.Instance.Show(UIControllerDefine.WIN_Direct);
    }
    public static void UpdateHpPosition(ulong unitId, ViProvider<ViVector3> pos)
    {
        //UIDirectController controller = UIManager.Instance.GetController<UIDirectController, UIDirectWindow>(UIControllerDefine.WIN_Direct);
        //if (controller != null && controller.IsShow)
        //{
        //    controller.UpdateHpPos(unitId, pos);
        //}
    }
    public static void UpdateFocusHp(UInt64 unitId, float val)
    {
        UIFightController fightController = GetFightController();
        if (fightController != null && fightController.IsShow)
        {
            UInt64 id = FocusManager.Instance.CurFocusUnitId;
            UInt64 targetId = FocusManager.Instance.CurFocusTargetId;
            if (id == unitId)
            {
                fightController.UpdateFocusHp(val);
            }
            else if (unitId == targetId)
                fightController.UpdateFocusTargetHp(val);

        }
    }
    public static void UpdateFocusSp(float val)
    {
        UIFightController fightController = GetFightController();
        if (fightController != null && fightController.IsShow)
        {
            UInt64 id = FocusManager.Instance.CurFocusUnitId;
            UInt64 targetId = FocusManager.Instance.CurFocusTargetId;
            if (id == CellHero.LocalHeroID)
            {
                fightController.UpdateFocusBoom(val);
            }
            else if (CellHero.LocalHeroID == targetId)
                fightController.UpdateFocusTargetBoom(val);
        }
    }
    /// <summary>
    /// 资源AB加载完成后使用的commomwindow
    /// </summary>
    public static void ReplaceCommonWindow()
    {

        UIManager.Instance.Show(UIControllerDefine.WIN_Common, ()=> {
            UIManager.Instance.DestroyController(UIControllerDefine.WIN_PreloadCommon);
            UIManager.Instance.DestroyPreloadCommonWindow();
        });
    }
}
