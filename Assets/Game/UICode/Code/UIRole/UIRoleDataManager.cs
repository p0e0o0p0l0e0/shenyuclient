using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text.RegularExpressions;


public class UIRoleDataManager : DataManagerBase<UIRoleDataManager>, IRelease
{

    //因为2个界面的结构问题，凭空增加了很多装填 代码质量不太好 稳定版本后优化
    public enum Gender
    {
        MALE,
        FEMALE,
        Null,
    }
    public enum CreateRoleResult
    {
        SUCCESS,
        FAIL_NAME_EMPTY,
        FAIL_NAME_USED,
        FAIL_NAME_RESERVE,
        FAIL_NAME_LEN,
        FAIL_MAX_PLAYER,
    }

    private bool isCreat = false; //记录创建跳转使用跳转使用 

    public UICallback.VIO_CB OnAvatarShow;
    private Dictionary<int, Avatar> _mAvatars = new Dictionary<int, Avatar>();
    public int CurSelectAvatarId { get; set; } //创建角色的时候选择的id；
    public byte CurSelectGender { get; set; }
    private UICallback.VV_CB _OnPlayerCreateSuccessCB;
    bool isPlayingAnim = false;


    ViConstValue<int> VALUE_PlayerNameLenSup = new ViConstValue<int>("PlayerNameLenSup", 8);
    ViConstValue<int> VALUE_PlayerNameLenInf = new ViConstValue<int>("PlayerNameLenInf", 2);

    public UIRoleDataManager()
    {
        CurSelectGender = (byte)Gender.Null;
    }
    public void ShowAvatar(int id, byte gender, Action callBack = null)
    {
        AccountScene.Instance.ShowAvatar(id, gender, callBack);
    }


    /// <summary>
    /// 根据id创建男女两个英雄接口
    /// </summary>
    /// <param name="malId"></param>
    public void ShowAllAvatar(int id, Action callback = null)
    {
        CurSelectGender = (byte)Gender.Null;
        AccountScene.Instance.ShowAllAvatar(id, CurSelectGender, callback);
    }
    public void Clear()
    {
        foreach (KeyValuePair<int, Avatar> kvp in _mAvatars)
        {
            kvp.Value.Clear();
        }
        _mAvatars.Clear();
        OnAvatarShow = null;
    }

    public void ClearSelect()
    {
        CurSelectAvatarId = -1;
        CurSelectGender = (byte)Gender.Null;
    }
    public void OnPlayerCreateSuccess()
    {
        if (_OnPlayerCreateSuccessCB != null) _OnPlayerCreateSuccessCB();
    }
    public void RegisterPlayerCreate(UICallback.VV_CB callback)
    {
        _OnPlayerCreateSuccessCB += callback;
    }
    public void UnRegisterPlayerCreate(UICallback.VV_CB callback)
    {
        _OnPlayerCreateSuccessCB -= callback;
    }

    public void SetCreatTag(bool isTrue)
    {
        isCreat = isTrue;
    }

    public bool GetCreatTag()
    {
        return isCreat;
    }
    public int GetVisId()
    {
        if (CurSelectGender == (byte)Gender.FEMALE)
            return 6 + CurSelectAvatarId;
        else
            return CurSelectAvatarId;
    }


    string inputName = "";
    public string ValueChange(string name)
    {
        string noMoji = Regex.Replace(name, @"\p{Cs}", ""); //moji
        int allLe = 0;
        Regex reg = new Regex("^[0-9|A-Z|a-z|]+$");
        char[] namelist = noMoji.ToCharArray();
        for (int i = 0; i < namelist.Length; i++)
        {
            if (reg.IsMatch(namelist[i].ToString()))
                allLe += 1;
            else
                allLe += 2;
        }
        if (allLe <= VALUE_PlayerNameLenSup)
            inputName = noMoji;
        return inputName;
    }



    public bool IsNameIllegal(string inputName)
    {
        if (string.IsNullOrEmpty(inputName))
        {
            UIManagerUtility.ShowHint(I18NManager.Instance.GetWord("tips_148"));
            return false;
        }
        if (inputName.Length < VALUE_PlayerNameLenInf)
        {
            UIManagerUtility.ShowHint(I18NManager.Instance.GetWord("tips_149"));
            return false;
        }
        Regex regex = new Regex("^[\u4e00-\u9fa5|0-9|A-Z|a-z|]+$");
        if (!regex.IsMatch(inputName))
        {
            UIManagerUtility.ShowHint(I18NManager.Instance.GetWord("tips_150"));
            return false;
        }
        List<MaskWordStruct> list = ViSealedDB<MaskWordStruct>.Array;
        for (int i = 0; i < list.Count; i++)
        {
            if (!string.IsNullOrEmpty(list[i].maskString) && inputName.Contains(list[i].maskString))
            {
                UIManagerUtility.ShowHint(I18NManager.Instance.GetWord("tips_150"));
                return false;
            }
        }
        return true;
    }

    public void Release()
    {
        Clear();
    }


    public void SetAnimation(bool isAnim)
    {
        isPlayingAnim = isAnim;
    }

    public bool GetIsPlayingAniation()
    {
        return isPlayingAnim;
    }
}
