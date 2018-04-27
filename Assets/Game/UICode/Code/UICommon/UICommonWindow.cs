using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public enum HintElementType
{
    None,
    Nomal,
    Max,
}
public class UICommonWindow : UIWindow<UICommonWindow, UICommonController>
{
    #region ui control name define
    private const string LoadingTran = "/Loading";
    private const string MaskTran = "/Mask";
    private const string HintTran = "/Hint";
    private const string ProgressTran = "/Loading/Progress";
    private const string HintText = "/Hint/Text";
    private const string Root = "/Confirm";
    private const string PathFinding = "/Pathfinding";
    private const string BackGroundTex = "/Loading/BackGround";
    #endregion

    private const float MAX_FAKE_PROGRESS = 0.95f;
    private const float STEP = 0.2f;
    private float lastDeltaTime = 0;
    private Transform _mLoadingTran = null;
    private Transform _mMaskTran = null;
    private Transform _mHintTran = null;
    private Transform _mPathFinding = null;
    private int _mTimerId = 0;
    private float _mCurrentProgress = 0;
    private float _mTargetProgress = 0;
    private Slider _mProgress = null;
    private float _mDuringTime = 0;
    private const float _mTotalTime = 0.1f;
    private const float _mSpeed = 2;
    private DOTweenAnimation[] _tweenAnimations = null;
    private Text _msgText = null;
    private ViTimeNode4 _processBarUpdate = new ViTimeNode4();

    private ConfirmWin confirmWin;
    private bool isShowMask = false;
    private bool isShowPathFinding = false;
    private ExUITexture _backTex = null;

    protected override void Initial()
    {
        _mLoadingTran = this.FindTransform(LoadingTran);
        _mMaskTran = this.FindTransform(MaskTran);
        _mHintTran = this.FindTransform(HintTran);
        _mProgress = this.GetComponent<Slider>(ProgressTran);
        confirmWin = new ConfirmWin();
        confirmWin.Initial(this, Root);
        _mPathFinding = this.FindTransform(PathFinding);
        _backTex = this.GetComponent<ExUITexture>(BackGroundTex);

    }
    public override void Show()
    {
        base.Show();
        SetWinType(this._mController.GetWindowType());
        //_mTimerId = UITimerManager.Instance.CreateTimer( TimerType.REPEAT, 0.05f, _TimerTimeOutDelegate);
        //UITimerManager.Instance.StartTimer(_mTimerId);

        UIUtility.MakeFullScreen(this.GetPanelSize(), _backTex, true);
    }
    public override void Hide()
    {
        base.Hide();
        //if (_mTimerId != 0)
        //    UITimerManager.Instance.RemoveTimer(_mTimerId);
        _processBarUpdate.Detach();

    }

    private void _ResetTimer()
    {
        //if (_mTimerId != 0)
        //    UITimerManager.Instance.ResetTimer(_mTimerId);
        _processBarUpdate.Detach();
        Clear();
    }
    public void UpdateWindowType()
    {
        SetWinType(this._mController.GetWindowType());
    }
    public void SetWinType(UICommonController.WinType type)
    {
        switch (type)
        {
            case UICommonController.WinType.NONE: _HideAll(); break;
            case UICommonController.WinType.HINT: _ShowHint(); break;
            case UICommonController.WinType.LOADING: _ShowLoading(); break;
            case UICommonController.WinType.MASK: _ShowMask(); break;
            case UICommonController.WinType.CONFIRM: break;
        }
    }

    public override void Destroy()
    {
        if (this.hintPool != null)
        {
            hintPool.Dispose();
            hintPool = null;
        }

        base.Destroy();
    }

    private void _HideAll()
    {
        _mLoadingTran.gameObject.SetActive(false);
        ShowMaskPanel(false);
        _mHintTran.gameObject.SetActive(false);
        _ResetTimer();
    }

    private void _ShowLoading()
    {
        if (!_mLoadingTran.gameObject.activeSelf)
        {
            _mLoadingTran.gameObject.SetActive(true);
            ShowMaskPanel(false);
            _mHintTran.gameObject.SetActive(false);
            _processBarUpdate.Start(ViTimerRealInstance.Timer, 5, this._TimerTimeOutDelegate);
            lastDeltaTime = 0;
            _mProgress.value = 0f;
        }
    }
    private void _ShowMask()
    {
        ShowMaskPanel(true);
        _mLoadingTran.gameObject.SetActive(false);
        _mHintTran.gameObject.SetActive(false);
        //_ResetTimer();
    }
    private void _ShowHint()
    {
        //_mHintTran.gameObject.SetActive(true);        
        _mLoadingTran.gameObject.SetActive(false);
        //_ResetTimer();
    }
    public void ShowHint(string msg)
    {
        SpawanHint(msg);
    }

    public void ShowConfirm(string content, UICallback.VIO_CB yesAction, UICallback.VIO_CB noAction = null, string yesStr = null, string noStr = null, string title = null, ConfirmType confirmType = ConfirmType.YesAndNo)
    {
        confirmWin.Show(content,yesAction,noAction,yesStr,noStr,title, confirmType);
    }

    public void SetProgress(float val)
    {
        _mTargetProgress = val;
        _mDuringTime = 0;
        //ViDebuger.Record("----------->SetProgress:"+val);
    }
    public void Clear()
    {
        _mCurrentProgress = 0;
        _mTargetProgress = 0;
        lastDeltaTime = 0;
    }
    private void _TimerTimeOutDelegate(ViTimeNodeInterface node)
    {
        if (_mTargetProgress > _mCurrentProgress)
        {
            //Debug.Log("_TimerTimeOutDelegate:time="+Time.time);
            _mDuringTime += Time.deltaTime * _mSpeed;
            float progress = _mDuringTime / _mTotalTime;
            if (progress < 1f)
            {
                float val = Mathf.Lerp(_mCurrentProgress, _mTargetProgress, progress);
                _mProgress.value = Mathf.Clamp01(val);
                //Debug.Log("------------>progress="+ _mProgress.value);
            }
            else
            {
                _mCurrentProgress = _mTargetProgress;
                _mProgress.value = 1f;
            }

        }
        else
        {
            float timeStep = lastDeltaTime / _mTotalTime * STEP;
            if (lastDeltaTime >= _mTotalTime)
            {
                lastDeltaTime = 0;
            }
            else
                lastDeltaTime += GameTimeScale.DeltaTime;
            _mCurrentProgress += timeStep;
            _mCurrentProgress = Mathf.Min(_mCurrentProgress, MAX_FAKE_PROGRESS);
            _mProgress.value = Mathf.Min(1, _mCurrentProgress);
        }
        //Debug.Log("------------>progress=" + _mProgress.value);
    }

    private class ConfirmWin : UIWindowComponent<UICommonWindow,UICommonController>
    {
        private const string Title = "/title";
        private const string Content = "/content";
        private const string YesBtn = "/confirm";
        private const string YesText = "/confirm/Text";
        private const string NoBtn = "/cancel";
        private const string NoText = "/cancel/Text";

        private Text title;
        private Text content;
        private ExUIButton yesBtn;
        private Text yesText;
        private ExUIButton noBtn;
        private Text noText;

        private ConfirmType lastConfirmType = ConfirmType.YesAndNo;

        public override void Initial(UICommonWindow window, string topPath)
        {
            base.Initial(window,topPath);
            title = this.GetComponent<Text>(Title);
            content = this.GetComponent<Text>(Content);
            yesBtn = this.GetComponent<ExUIButton>(YesBtn);
            yesText = this.GetComponent<Text>(YesText);
            noBtn = this.GetComponent<ExUIButton>(NoBtn);
            noText = this.GetComponent<Text>(NoText);
        }

        public void Show(string content, UICallback.VIO_CB yesAction, UICallback.VIO_CB noAction =null,string yesStr=null,string noStr = null,string title=null, ConfirmType confirmType = ConfirmType.YesAndNo)
        {
            if (lastConfirmType != confirmType)
            {
                lastConfirmType = confirmType;
                BtnToNormal();
                switch (confirmType)
                {
                    case ConfirmType.Yes:
                        OnlyYesBtn();
                        break;
                    case ConfirmType.No:
                        OnlyNoBtn();
                        break;
                    default:
                        break;
                }
            }

            _rootTran.gameObject.SetActive(true);
            this.content.text = content;
            yesText.text = yesStr ?? I18NManager.Instance.GetWord("tips_29");
            noText.text = noStr ?? I18NManager.Instance.GetWord("tips_30");

            yesBtn.onClickEx = yesAction;
            yesBtn.onClickEx += (a, b) => Hide();
            noBtn.onClickEx = noAction;
            noBtn.onClickEx +=((a,b)=>Hide());
        }
        
        public void Hide()
        {
            _rootTran.gameObject.SetActive(false);
        }

        private void BtnToNormal()
        {
            yesBtn.gameObject.SetActive(true);
            yesBtn.transform.localPosition = new Vector3(-150, yesBtn.transform.localPosition.y, yesBtn.transform.localPosition.z);
            noBtn.gameObject.SetActive(true);
            noBtn.transform.localPosition = new Vector3(150, noBtn.transform.localPosition.y, noBtn.transform.localPosition.z);
        }

        private void OnlyYesBtn()
        {
            yesBtn.gameObject.SetActive(true);
            yesBtn.transform.localPosition = new Vector3(0, yesBtn.transform.localPosition.y, yesBtn.transform.localPosition.z);
            noBtn.gameObject.SetActive(false);            
        }

        private void OnlyNoBtn()
        {
            yesBtn.gameObject.SetActive(false);           
            noBtn.gameObject.SetActive(true);
            noBtn.transform.localPosition = new Vector3(0, noBtn.transform.localPosition.y, noBtn.transform.localPosition.z);
        }
    }

    public void ShowPathFinding(bool isShow)
    {
        if (_mPathFinding != null && isShowPathFinding != isShow)
        {
            _mPathFinding.gameObject.SetActive(isShow);
            isShowPathFinding = isShow;            
        }
    }

    public void ShowMaskPanel(bool isShow)
    {
        if (_mMaskTran != null && isShowMask != isShow)
        {
            _mMaskTran.gameObject.SetActive(isShow);
            isShowMask = isShow;
        }
    }

    public class HintElement: PoolElement<HintElementType>
    {
        public Transform Tran;
        public Transform textTran;        
        public Text text;
        public TweenAnim_alpha tweenAnim_Alpha { get; set; }

        public TweenPosition tweenAnim_Position { get; set; }

        public UICallback.VOO_CB Callback { get; set; }

        private void OnElementEnd()
        {
            if (Callback != null)
            {
                Callback(KeyType, this);
            }
        }
        public void Fire()
        {
            tweenAnim_Alpha.ResetToBeginning();
            tweenAnim_Position.ResetToBeginning();
            tweenAnim_Position.PlayForward();            
            tweenAnim_Alpha.PlayForward();
            tweenAnim_Alpha.SetOnFinished(OnElementEnd);
        }

        public override void Close()
        {
            base.Close();
            Tran.gameObject.SetActive(false);
        }
    }

    private PoolManager<HintElementType, HintElement> hintPool = new PoolManager<HintElementType, HintElement>();

    private void SpawanHint(string msg,HintElementType hintType = HintElementType.Nomal)
    {
        HintElement hint = _spwanHint(msg, hintType);
        hint.Tran.SetActive(true);        
        hint.Fire();
    }

    private HintElement _spwanHint(string msg,HintElementType hintType)
    {
        HintElement hintElement = null;
        bool isNeedCreate = hintPool.Spwan(hintType, out hintElement);
        if (isNeedCreate)
        {
            _createHintElement(hintType, ref hintElement);
        }
        hintElement.text.text = msg;
        return hintElement;
    }

    private void _createHintElement(HintElementType hintType, ref HintElement hintElement)
    {
        Transform tran = UnityAssisstant.Instantiate(_mHintTran.gameObject, Vector3.zero, Quaternion.identity).transform;
        tran.SetParent(_mHintTran.parent);
        tran.localPosition = _mHintTran.localPosition;
        tran.localScale = Vector3.one;
        hintElement.Tran = tran;
        hintElement.textTran = hintElement.Tran.Find("Text");
        hintElement.text = hintElement.textTran.GetComponent<Text>();
        hintElement.tweenAnim_Alpha = hintElement.textTran.GetComponent<TweenAnim_alpha>();
        hintElement.tweenAnim_Position = hintElement.textTran.GetComponent<TweenPosition>();
        hintElement.Callback = OnHintElementEnd;
    }

    private void OnHintElementEnd(object type, object element)
    {
        CloseHintElement((HintElementType)type, (HintElement)element);
    }

    private void CloseHintElement(HintElementType hintElementType, HintElement hintElement)
    {
        hintPool.Close(hintElementType, hintElement);        
    }
}
