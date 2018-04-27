using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/********************************************************************
	created:	2018/02/01
	created:	1:2:2018   15:05
	filename: 	E:\work_0\Program\Program\Client\Assets\Game\UICode\Code\UIChat\UIChatPlaneComWin.cs
	file path:	E:\work_0\Program\Program\Client\Assets\Game\UICode\Code\UIChat
	file base:	UIChatPlaneComWin
	file ext:	cs
	author:		meixuelei
	
	purpose:	聊天面板 (主界面下方的聊天窗口)
*********************************************************************/
public class UIChatPlaneWin : UIChatComponentWin
{
    #region 节点路径
    // 根节点
    private const string TopRoot = "/ChatBg/Top/";
    private const string TopShieldBtn = TopRoot + "ShieldBtn";
    private const string TopHangUpBtn = TopRoot + "Hang_UpBtn";
    private const string TopFollowBtn = TopRoot + "FollowBtn";
    private const string TopFreeBtn = TopRoot + "FreeBtn";
    private const string TopSpreadBtn = TopRoot + "SpreadButton";

    // select
    private const string TopShieldSelect = TopShieldBtn + "/Select";
    private const string TopHangUpSelect = TopHangUpBtn + "/Select";
    private const string TopFollowSelect = TopFollowBtn + "/Select";
    private const string TopFreeSelect = TopFreeBtn + "/Select";

    private const string ChatListRoot = "/ChatList";
    //private const string ChatListLoop = ;

    #endregion
    /// <summary>
    /// 功能按钮控件
    /// </summary>
    private ButtonHandler _shieldHandler;
    private ButtonHandler _hangUpHandler;
    private ButtonHandler _followHandler;
    private ButtonHandler _freeHandler;
    private ExUIButton _SpreadBtn;

    /***
     * 语音按钮先放放
     * ***/

    public override void Initial(UIChatWindow window, string topPath)
    {
        base.Initial(window, topPath);
        GetComponentObj();
    }

    #region 获取对应的组件
    private void GetComponentObj()
    {
        _shieldHandler = new ButtonHandler
        {
            CurrentBtn = this.GetComponent<ExUIButton>(TopShieldBtn),
            SelectTran = this.GetComponent<Transform>(TopShieldSelect)
        };
        _shieldHandler.Initial(Events.ChatSystemEvent.ShieldBtnFunc);

        _hangUpHandler = new ButtonHandler
        {
            CurrentBtn = this.GetComponent<ExUIButton>(TopHangUpBtn),
            SelectTran = this.GetComponent<Transform>(TopHangUpSelect)
        };
        _hangUpHandler.Initial(Events.ChatSystemEvent.HangUpBtnFunc);

        _followHandler = new ButtonHandler
        {
            CurrentBtn = this.GetComponent<ExUIButton>(TopFreeBtn),
            SelectTran = this.GetComponent<Transform>(TopFollowSelect)
        };
        _followHandler.Initial(Events.ChatSystemEvent.FollowBtnFunc);

        _freeHandler = new ButtonHandler
        {
            CurrentBtn = this.GetComponent<ExUIButton>(TopFollowBtn),
            SelectTran = this.GetComponent<Transform>(TopFreeSelect)
        };
        _freeHandler.Initial(Events.ChatSystemEvent.FreeBtnFunc);

        _SpreadBtn = this.GetComponent<ExUIButton>(TopSpreadBtn);
        _SpreadBtn.onClickEx = SpreadCB;
    }

    /// <summary>
    /// 箭头回调
    /// </summary>
    /// <param name="val"></param>
    /// <param name="obj"></param>
    private void SpreadCB(int val, object obj)
    {

    }
    #endregion

    public override void Show()
    {
        // _rootTran.gameObject.SetActive(true); // 根据相关的标识显示
        /// 请求一次显示数据 -- 这块需要再和策划确认下-- 如果需要 要显示多少条
    }

    public override void Hide()
    {
        _rootTran.gameObject.SetActive(false);
    }

    public override void Dispose()
    {
        // do...
        _shieldHandler.Dispose();
        _hangUpHandler.Dispose();
        _followHandler.Dispose();
        _freeHandler.Dispose();
        _shieldHandler = null;
        _hangUpHandler = null;
        _followHandler = null;
        _freeHandler = null;
        _SpreadBtn = null;

        base.Dispose();
    }

    #region ButtonInfoHandler   button 相关的处理
    private class ButtonHandler : IDisposable
    {
        public ExUIButton CurrentBtn;
        public Transform SelectTran; // 选择状态
        private bool _isSelectState;

        public void Initial(string eventStr)
        {
            ReSetState();
            if (CurrentBtn != null) CurrentBtn.onClickEx = (id, obj) => SetBtnEvent(eventStr, !_isSelectState);
        }

        /// <summary>
        /// 重置状态
        /// </summary>
        public void ReSetState()
        {
            _isSelectState = false;
            SelectTran.gameObject.SetActive(_isSelectState);
        }

        public void Dispose()
        {
            CurrentBtn = null;
            SelectTran = null;
        }

        private void SetBtnEvent(string eventStr, bool state)
        {
            EventDispatcher.TriggerEvent<bool>(eventStr, state);
            SelectTran.gameObject.SetActive(state);
        }

    }
    #endregion

}  // UIChatPlaneWin  class end
