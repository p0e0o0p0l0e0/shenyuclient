using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using DG.Tweening;
public class UIRoleSkillShowWindow : MonoBehaviour
{
    #region ui define

    private string UpShow = "UpShow";
    private string HeroDe = "UpShow/HeroDe";

    private string DownShow = "DownShow";
    private string Skill1 = "DownShow/Skill1";
    private string Skill2 = "DownShow/Skill2";
    private string Skill3 = "DownShow/Skill3";
    #endregion

    #region 
    private UICanvasGroupTween _upAlpha = null;
    private RectTransform _upPos = null;
    private ExUISprite _heroType = null;
    private Text _heroDe = null;
    private ExUIToggle toggle;
    private UICanvasGroupTween _downAlpha = null;
    private RectTransform _downPos = null;
    private float upOldPosX =84;
    private float upNewPosX = -180 ;
    private float downOldPosX = 84;
    private float downNewPosX =-190;
    private List<ExCircleSprite> _skillSprite = new List<ExCircleSprite>();
    private List<GameObject> showObj = new List<GameObject>();
    private Action<int> skillAction = null;
    private Action<bool> toggleShow = null;
    private bool isCreatShow = true;
    private int skillCkickId;
    #endregion
    private void Init()
    {
        _upAlpha = transform.Find(UpShow).GetComponent<UICanvasGroupTween>();
        _upPos = _upAlpha.GetComponent<RectTransform>();
        toggle = _upPos.Find("Toggle").GetComponent<ExUIToggle>();
        toggle.onValueChanged.AddListener(ClickToggle);
        toggle.gameObject.SetActive(false);
        _heroType = _upAlpha.GetComponent<ExUISprite>();
        _heroDe = transform.Find(HeroDe).GetComponent<Text>();
        _downAlpha = transform.Find(DownShow).GetComponent<UICanvasGroupTween>();
        _downPos = _downAlpha.GetComponent<RectTransform>();

        for (int i = 1; i <= 3; i++)
        {
            ExUIButton _skill1 = _downPos.Find("Skill" + i).GetComponent<ExUIButton>();
            _skillSprite.Add(_skill1.GetComponent<ExCircleSprite>());
            showObj.Add(_skill1.transform.Find("Click").gameObject);
            _skill1.Id = i;
            _skill1.onClickEx = OnClickSkill;
        }
    }


    public void SetParent(Transform tra)
    {
        transform.SetParent(tra, false);
        transform.localPosition = Vector3.zero;
    }

    public void Init(Action<int> SkillShow)
    {
        isCreatShow = true;
        skillAction = SkillShow;
    }
    public void Init(bool isShow, Action<bool> ac)
    {
        if (_upAlpha == null)
            Init();
        isCreatShow = isShow;
        toggle.gameObject.SetActive(true);
        toggleShow = ac;
    }
    public void PlayFirstTween()
    {
      
        if (_upAlpha == null)
            Init();
        _downPos.gameObject.SetActive(isCreatShow);
        ReSetTween();
        _upAlpha.PlayForward();
        _upPos.DOLocalMoveX(upNewPosX, 0.2f);
        if (isCreatShow)
        {
            _downAlpha.PlayForward();
            _downPos.DOLocalMoveX(downNewPosX, 0.2f).SetDelay(0.1f);
        }

    }

    public void PlayReAndFor(Action callBack)
    {
        _upAlpha.PlayReverse();     
        float time = (float)0.2 / (upNewPosX - upOldPosX) * (_upPos.localPosition.x - upOldPosX);    
        if (isCreatShow)
        {
            _upPos.DOLocalMoveX(upOldPosX, time, false);
            _downAlpha.PlayReverse();
            _downPos.DOLocalMoveX(downOldPosX, time, false).SetDelay(0.1f).OnComplete(() => { callBack(); });
        }
        else
        {
            _upPos.DOLocalMoveX(upOldPosX, time, false).OnComplete(() => { callBack(); });
        }
    }

    private void ReSetTween()
    {
        _upAlpha.ResetToStart();
        if (isCreatShow)
        {
            _downAlpha.ResetToStart();
        }       
    }

    public void RushInfo(int id)
    {
        VisualCorner visualInfo = ViSealedDB<VisualCorner>.Data(id);
        _heroType.SpriteName = visualInfo.descriptionIcon;
        _heroDe.text = visualInfo.description;
        if (isCreatShow)
        {
            for (int i = 0; i < visualInfo.Spell.Length; i++)
            {
                IconData icon = IconDataManager.GetIcon(visualInfo.Spell[i].PData.Icon);
                UIUtility.SetSprite(_skillSprite[i], icon);
               // _skillSprite[i].SetGray(true);
                showObj[i].SetActive(false);
            }
        }   
    }
    public void ClearClallBack()
    {
        _downAlpha.OnCompleteCallback = null;
    }

    public bool IsRuning()
    {
        return _downAlpha.Runnig;
    }
    private void OnClickSkill(int id, object obj)
    {
        //skillCkickId = id-1;
        //showObj[skillCkickId].SetActive(true);
        //if (skillAction != null)
        //    skillAction(skillCkickId);
    }

    public void CloseSkillShow()
    {
        showObj[skillCkickId].SetActive(false);
    }
    public void ClickToggle(bool isOpen)
    {
        if (toggleShow != null)
            toggleShow(isOpen);
    }

    public void SetToggleIsOn(bool isShow)
    {
        toggle.isOn = false;
    }
    public bool GetToggleIsOn()
    {
        return toggle.isOn;
    }
}
